using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System.Collections;
using AForge.Imaging.Filters;
using AForge.Imaging;
using System.Drawing.Imaging;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.Win32;
using System.Globalization;
using AutoUpdaterDotNET;

namespace Clicker
{
    //[Flags]
    public enum ClickType
    {
        click = 0,
        rightClick = 1 ,
        doubleClick = 2 ,
        SendKeys = 3,
        MouseWheel = 4
    }

    public struct Dimesion
    {
        public int Width { get; set; }
        public int Height { get; set; }
    }

    public struct GameObject
    {
        public string Name { get; set; }
        public Point Position { get; set; }
        public float SimilarityThreshold { get; set; }
        public string Image { get; set; }
        public Rectangle SearchZone { get; set; }
    }

    public enum GameScreen
    {
        Home = 0,
        TreasureHunt = 1,
        Heroes = 2,
        Setting = 3,
        YourChest = 4,
        Error = 5,
        Main = 6
    }

    public enum DeviceCaps
    {
        /// <summary>
        /// Logical pixels inch in X
        /// </summary>
        LOGPIXELSX = 88,

        /// <summary>
        /// Horizontal width in pixels
        /// </summary>
        HORZRES = 8,

        /// <summary>
        /// Vertical height of entire desktop in pixels
        /// </summary>
        DESKTOPVERTRES = 117,

        /// <summary>
        /// Horizontal width of entire desktop in pixels
        /// </summary>
        DESKTOPHORZRES = 118
    }

    public partial class MainForm : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

        [DllImport("user32")]
        public static extern int SetCursorPos(int x, int y);
        
        #region Fields
        private const int MOUSEEVENTF_MOVE = 0x0001; /* mouse move */
        private const int MOUSEEVENTF_LEFTDOWN = 0x0002; /* left button down */
        private const int MOUSEEVENTF_LEFTUP = 0x0004; /* left button up */
        private const int MOUSEEVENTF_RIGHTDOWN = 0x0008; /* right button down */
        private const int MOUSEEVENTF_RIGHTUP = 0x0010; /* right button up */
        private const int MOUSEEVENTF_MIDDLEDOWN = 0x0020; /* middle button down */
        private const int MOUSEEVENTF_MIDDLEUP = 0x0040; /* middle button up */
        private const int MOUSEEVENTF_XDOWN = 0x0080; /* x button down */
        private const int MOUSEEVENTF_XUP = 0x0100; /* x button down */
        private const int MOUSEEVENTF_WHEEL = 0x0800; /* wheel button rolled */
        private const int MOUSEEVENTF_VIRTUALDESK = 0x4000; /* map to entire virtual desktop */
        private const int MOUSEEVENTF_ABSOLUTE = 0x8000; /* absolute move */

        private SynchronizationContext context = null;
        private DateTime start, end;
        private bool first = true;
        private List<ActionEntry> actions;
        private Thread runActionThread;
        private bool byTextEntry;
        private Hashtable schedualeList;
        private string appPath = Path.GetDirectoryName(Application.ExecutablePath);
        public List<GameObject> gameObjects;
        private GameObject gObject_selected;
        private int timerCheckWorkHeros = 0;
        private Dimesion display;


        #endregion

        /// <summary>
        /// Retrieves device-specific information for the specified device.
        /// </summary>
        /// <param name="hdc">A handle to the DC.</param>
        /// <param name="nIndex">The item to be returned.</param>
        [DllImport("gdi32.dll")]
        private static extern int GetDeviceCaps(IntPtr hdc, DeviceCaps nIndex);


        public static int GetSystemDpi()
        {
            using (Graphics screen = Graphics.FromHwnd(IntPtr.Zero))
            {
                IntPtr hdc = screen.GetHdc();

                int virtualWidth = GetDeviceCaps(hdc, DeviceCaps.HORZRES);
                int physicalWidth = GetDeviceCaps(hdc, DeviceCaps.DESKTOPHORZRES);
                screen.ReleaseHdc(hdc);

                return (int)(96f * physicalWidth / virtualWidth);
            }
        }


        public static int[] GetPhysicalDysplay()
        {
            using (Graphics screen = Graphics.FromHwnd(IntPtr.Zero))
            {
                IntPtr hdc = screen.GetHdc();

                int physicalWidth = GetDeviceCaps(hdc, DeviceCaps.DESKTOPHORZRES);
                int physicalHeigth = GetDeviceCaps(hdc, DeviceCaps.DESKTOPVERTRES);
                screen.ReleaseHdc(hdc);

                return new int[] { physicalWidth, physicalHeigth};
            }
        }

        #region Construction
        public MainForm()
        {

            InitializeComponent();

            //AutoUpdater.HttpUserAgent = "AutoUpdater";
            //AutoUpdater.ReportErrors = true;
            //AutoUpdater.OpenDownloadPage = true;
            //AutoUpdater.RemindLaterAt = 0;
            //AutoUpdater.ShowSkipButton = false;
            AutoUpdater.Mandatory = true;
            AutoUpdater.UpdateMode = Mode.Normal;
            //AutoUpdater.Start("https://storage.googleapis.com/updates-vns-bucket/Updates/Clicker/updater.xml");


            appLog("INFO", "STARTING - PROGRAM ...");
            context = SynchronizationContext.Current;
            actions = new List<ActionEntry>();
            schedualeList = new Hashtable();
            var PhysicalDysplay = GetPhysicalDysplay();
            gameObjects = new List<GameObject>();

            display = new Dimesion() { Width = PhysicalDysplay[0], Height = PhysicalDysplay[1] };

            if (!(File.Exists($"{appPath}\\gameObjects.json")))
            {
                Rectangle SearchZoneBtnOptions = new Rectangle(90, 0, 10, 10);
                Rectangle SearchZoneBtnClaim = new Rectangle(85, 0, 15, 10);
                Rectangle SearchZoneBtnGotoHome = new Rectangle(0, 0, 10, 10);

                Rectangle SearchZoneBtnTreasureHunt = new Rectangle(40, 25, 20, 30);
                Rectangle SearchZoneBtnHero = new Rectangle(90, 80, 10, 20);

                Rectangle SearchZoneDv = new Rectangle(15, 25, 5, 75);
                Rectangle SearchZoneClose = new Rectangle(50, 10, 10, 20);
                Rectangle SearchZoneBtnWorkDisable = new Rectangle(35, 30, 10, 70);
                Rectangle SearchZoneBtnRest = new Rectangle(45, 30, 10, 70);
                Rectangle SearchZoneStamina = new Rectangle(25, 30, 10, 70);

                gameObjects = new List<GameObject>
                {
                new GameObject() { Name = "btnOptions", Position = new Point(), SimilarityThreshold = 0.921f,
                                   Image = "Images\\BTN_OPTIONS.jpg", SearchZone = SearchZoneBtnOptions },

                new GameObject() { Name = "btnClaim", Position = new Point(), SimilarityThreshold = 0.921f,
                                   Image = "Images\\BTN_CLAIM.jpg", SearchZone = SearchZoneBtnClaim },

                new GameObject() { Name = "btnGotoHome", Position = new Point(), SimilarityThreshold = 0.921f,
                                   Image = "Images\\BTN_GO_TO_HOME.jpg", SearchZone = SearchZoneBtnGotoHome },

                new GameObject() { Name = "btnTreasureHunt", Position = new Point(), SimilarityThreshold = 0.921f,
                                   Image = "Images\\BTN_TREASURE_HUNT.jpg", SearchZone = SearchZoneBtnTreasureHunt},

                new GameObject() { Name = "dv", Position = new Point(), SimilarityThreshold = 0.921f,
                                   Image = "Images\\DV.jpg", SearchZone  = SearchZoneDv},

                new GameObject() { Name = "btnClose", Position = new Point(), SimilarityThreshold = 0.921f,
                                   Image = "Images\\BTN_CLOSE.jpg", SearchZone = SearchZoneClose},

                new GameObject() { Name = "btnWorkDisable", Position = new Point(), SimilarityThreshold = 0.921f,
                                   Image = "Images\\BTN_WORK_DISABLE.jpg",  SearchZone =  SearchZoneBtnWorkDisable},

                new GameObject() { Name = "btnRest", Position = new Point(), SimilarityThreshold = 0.921f,
                                   Image = "Images\\BTN_REST.jpg", SearchZone = SearchZoneBtnRest},

                new GameObject() { Name = "btnStamina", Position = new Point(), SimilarityThreshold = 0.961f,
                                   Image = "Images\\STAMINA.jpg", SearchZone = SearchZoneStamina},

                new GameObject() { Name = "btnHero", Position = new Point(), SimilarityThreshold = 0.921f,
                                   Image = "Images\\BTN_HERO.jpg", SearchZone = SearchZoneBtnHero},

                new GameObject() { Name = "btnConnect", Position = new Point(), SimilarityThreshold = 0.921f, Image = "Images\\BTN_CONNECT.jpg" },

                new GameObject() { Name = "btnToSign", Position = new Point(), SimilarityThreshold = 0.921f, Image = "Images\\BTN_TO_SIGN.jpg" },

                new GameObject() { Name = "error", Position = new Point(), SimilarityThreshold = 0.921f, Image = "Images\\ERROR.jpg" }
                };

                Json.SaveObject($"{appPath}\\gameObjects.json", gameObjects);
            }
            else
            {
                gameObjects = Json.FileJsonToLayout($"{appPath}\\gameObjects.json");
            }

            rdCheckHeroesOn.Checked = true;
            defineTime();
            timer1.Start();
        }

        private void appLog(string status, string msg)
        {
            textBox1.AppendText($"{GetDatetime()} - {status} - {msg}" + Environment.NewLine);
        }

        private string GetDatetime()
        {

            CultureInfo culture = new CultureInfo("pt-br");
            return DateTime.Now.ToString("G", culture);
        }

        public static int ConvertMinutesToMilliseconds(int minutes)
        {
            return (int)TimeSpan.FromMinutes(minutes).TotalMilliseconds;
        }

        public static string ConverMillisecondsToMinutes(int minutes)
        {
            TimeSpan t = TimeSpan.FromMilliseconds(minutes);
            return String.Format("{0:00}:{1:00}", t.Minutes, t.Seconds);
        }

        #endregion

        #region Private Methods

        private void RunAction()
        {
            foreach (ActionEntry action in actions)
            {
                if (action.Type.Equals(ClickType.SendKeys))
                {
                    ThreadPool.QueueUserWorkItem(new WaitCallback(WorkSendKeys), action);
                }
                else// if (entry is ClickEntry)
                {
                    ThreadPool.QueueUserWorkItem(new WaitCallback(WorkClick), action);
                }

                int tmpIntervl = action.Interval.Equals(0) ? 0 : action.Interval * 1000 - 100;
                Thread.Sleep(tmpIntervl);
            }

            ThreadPool.QueueUserWorkItem(new WaitCallback(WorkEnableButtons), null);
        }
        private void WorkSendKeys(object state)
        {
            this.context.Send(new SendOrPostCallback(delegate(object _state)
            {
                ActionEntry action = state as ActionEntry;
                SendKeys.Send(action.Text);
            }), state);
        }
        private void WorkClick(object state)
        {
            this.context.Send(new SendOrPostCallback(delegate(object _state)
            {
                ActionEntry action = state as ActionEntry;
                SetCursorPos(action.X, action.Y);
                Thread.Sleep(100);
                if (action.Type.Equals(ClickType.click))
                {
                    mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                    mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                }
                else if (action.Type.Equals(ClickType.doubleClick))
                {
                    mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                    mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                    Thread.Sleep(100);
                    mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                    mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                }
                else
                if (action.Type.Equals(ClickType.MouseWheel))
                {
                    mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                    mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                    mouse_event(MOUSEEVENTF_WHEEL, 0, 0, -10, 0);

                }
                else //if (action.Type.Equals(ClickType.rightClick))
                {
                    mouse_event(MOUSEEVENTF_RIGHTDOWN, 0, 0, 0, 0);
                    mouse_event(MOUSEEVENTF_RIGHTUP, 0, 0, 0, 0);
                }
            }), state);
        }

        private void WorkEnableButtons(object state)
        {
            this.context.Send(new SendOrPostCallback(delegate(object _state)
            {
                enableButtons(true);
            }), state);
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (byTextEntry) return;

            if (e.KeyChar.Equals('c') || e.KeyChar.Equals('d')
                || e.KeyChar.Equals('r') || e.KeyChar.Equals('t') || e.KeyChar.Equals('m'))
            {
                end = DateTime.Now;
                if (first)
                {
                    start = end;
                    first = false;
                }

                ClickType ct = ClickType.click;
                if (e.KeyChar.Equals('c'))
                {
                    //ct = ClickType.MouseWheel;
                }
                else if (e.KeyChar.Equals('d'))
                {
                    ct = ClickType.doubleClick;
                }
                else if (e.KeyChar.Equals('r'))
                {
                    ct = ClickType.rightClick;
                }
                else
                if (e.KeyChar.Equals('m'))
                {
                    ct = ClickType.MouseWheel;
                }
                else //if (e.KeyChar.Equals('t'))
                {
                    ct = ClickType.SendKeys;
                }

                int x = Cursor.Position.X;
                int y = Cursor.Position.Y;
                TimeSpan ts = end - start;
                double sec = 0;
                if (nWait.Value.Equals(0))
                {
                    sec = ts.TotalSeconds;
                    sec = Math.Round(sec, 1);
                }
                else
                {
                    sec = (double)nWait.Value;
                }
                start = end;
                string point = x.ToString() + "," + y.ToString();

                string text = ct.Equals(ClickType.SendKeys) ? txbEntry.Text : string.Empty;
                ListViewItem lvi = new ListViewItem(new string[] { point, ct.ToString(), "0", text });
                ActionEntry acion = new ActionEntry(x, y, text, 0, ct);
                lvi.Tag = acion;
                lvActions.Items.Add(lvi);
                int index = lvActions.Items.Count;
                if (index > 1)
                {
                    lvActions.Items[index - 2].SubItems[2].Text = sec.ToString();
                    (lvActions.Items[index - 2].Tag as ActionEntry).Interval = (int)sec;
                }
            }
            if (e.KeyChar.Equals('S'))
            {
                btnStart.PerformClick();
            }
            else if (e.KeyChar.Equals((char)Keys.Escape))//Esc
            {
                btnCancel.PerformClick();
                this.Focus();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lvActions.Items.Clear();
            first = true;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            runAction();
        }

        private void enableButtons(bool enabel)
        {
            btnClear.Enabled = enabel;
            btnOpen.Enabled = enabel;
            btnSave.Enabled = enabel;
            lvActions.Enabled = enabel;
            nTimeLoop.Enabled = enabel;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (runActionThread != null && runActionThread.IsAlive)
            {
                runActionThread.Abort();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (runActionThread != null && runActionThread.IsAlive)
            {
                runActionThread.Abort();
                enableButtons(true);
            }
        }

        private void txbEntry_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((Char)Keys.Escape))//Esc
            {
                nWait.Focus();
            }
        }

        private void txbEntry_Enter(object sender, EventArgs e)
        {
            byTextEntry = true;
        }

        private void txbEntry_Leave(object sender, EventArgs e)
        {
            byTextEntry = false;
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int cout = lvActions.Items.Count;
            int coutselect = lvActions.SelectedItems.Count;
            if (cout.Equals(coutselect))
            {
                btnClear.PerformClick();
            }
            else
            {
                for (int i = coutselect - 1; i >= 0; --i)
                {
                    int index = lvActions.SelectedItems[i].Index;
                    lvActions.Items[index].Remove();
                }
            }
        }

        private void lvActions_MouseDown(object sender, MouseEventArgs e)
        {
            int coutselect = lvActions.SelectedItems.Count;
            deleteToolStripMenuItem.Available = coutselect > 0;
            editToolStripMenuItem.Available = coutselect == 1;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.SaveFileDialog file = new System.Windows.Forms.SaveFileDialog();
            file.Filter = "XML File |*.xml";
            if (file.ShowDialog() == DialogResult.OK)
            {
                XmlSerializer ser = new XmlSerializer(typeof(ActionsEntry));
                ActionsEntry tmpAction = new ActionsEntry();
                List<ActionsEntryAction> tmpActionsEntryActions = new List<ActionsEntryAction>();
                foreach (ListViewItem lvi in lvActions.Items)
                {
                    ActionEntry tmpActionEntry = lvi.Tag as ActionEntry;
                    ActionsEntryAction tmpActionsEntryAction = new ActionsEntryAction();
                    tmpActionsEntryAction.X = tmpActionEntry.X;
                    tmpActionsEntryAction.Y = tmpActionEntry.Y;
                    tmpActionsEntryAction.Text = tmpActionEntry.Text;
                    tmpActionsEntryAction.interval = tmpActionEntry.Interval;
                    tmpActionsEntryAction.Type = (int)tmpActionEntry.Type;
                    tmpActionsEntryActions.Add(tmpActionsEntryAction);
                }
                tmpAction.Action = tmpActionsEntryActions.ToArray();

                using (XmlWriter writer = XmlWriter.Create(file.FileName))
                {
                    ser.Serialize(writer, tmpAction);
                }
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            bool runIt = false;
            if (MessageBox.Show("After openning configuration, are you want to run it?", "Clicker", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                 == DialogResult.Yes)
            {
                runIt = true;
            }
            System.Windows.Forms.OpenFileDialog file = new System.Windows.Forms.OpenFileDialog();
            file.Filter = "XML File |*.xml";
            file.Multiselect = false;
            if (file.ShowDialog() == DialogResult.OK)
            {
                OpenFileXml(runIt, file.FileName);
                string name = file.SafeFileName;
                this.Text = "Clicer - " + name.Substring(0, name.Length - 4);
            }
        }

        private ActionsEntry OpenFileXml(string file)
        {
            //Get data from XML file
            XmlSerializer ser = new XmlSerializer(typeof(ActionsEntry));
            using (FileStream fs = System.IO.File.Open(file, FileMode.Open))
            {
                try
                {
                    ActionsEntry entry = (ActionsEntry)ser.Deserialize(fs);
                    return entry;

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        private void OpenFileXml(bool runIt, string file)
        {
            //Get data from XML file
            XmlSerializer ser = new XmlSerializer(typeof(ActionsEntry));
            using (FileStream fs = System.IO.File.Open(file, FileMode.Open))
            {
                try

                {
                    ActionsEntry entry = (ActionsEntry)ser.Deserialize(fs);
                    lvActions.Items.Clear();
                    foreach (ActionsEntryAction ae in entry.Action)
                    {
                        string point = ae.X.ToString() + "," + ae.Y.ToString();
                        string interval = (ae.interval).ToString();
                        ListViewItem lvi = new ListViewItem(new string[] { point, ((ClickType)(ae.Type)).ToString(), interval, ae.Text });
                        ActionEntry acion = new ActionEntry(ae.X, ae.Y, ae.Text, ae.interval, (ClickType)(ae.Type));
                        lvi.Tag = acion;
                        lvActions.Items.Add(lvi);
                    }
                    
                    if (runIt)
                    {
                        btnStart.PerformClick();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Clicer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
       
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ActionEntry action = lvActions.SelectedItems[0].Tag as ActionEntry;
            EditWin frm = new EditWin(action);
            frm.Actionentry = action;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                action = frm.Actionentry;
                lvActions.SelectedItems[0].Tag = action;
                lvActions.SelectedItems[0].Text = action.X + "," + action.Y;
                lvActions.SelectedItems[0].SubItems[1].Text = action.Type.ToString();
                lvActions.SelectedItems[0].SubItems[2].Text = action.Interval.ToString();
                lvActions.SelectedItems[0].SubItems[3].Text = action.Text;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.linkLabel.LinkVisited = true;

            // Navigate to a URL.
            System.Diagnostics.Process.Start("http://msdn.microsoft.com/en-us/library/system.windows.forms.sendkeys.aspx");
        }


        private void nTimeLoop_ValueChanged(object sender, EventArgs e)
        {
            defineTime();
        }

        private void defineTime()
        {
            timer1.Interval = (int)((nTimeLoop.Value) * 60000);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
        }

        private void CheckWorkHeroes()
        {
            GotoScreenHero();

            Thread.Sleep(5000);

            var countHeroes = WorkHeroes();

            appLog("INFO", $"HEROES TO WORK: {countHeroes}");

            Thread.Sleep(1000);

            GotoScreenTreasureHunt();

            Thread.Sleep(1000);

            nCheckWorkHeroes.Value = 10;

            if (countHeroes == 0)
            {
                appLog("INFO", $"CHECK - HEROES WORKING ... ");

                GotoScreenHero();

                Thread.Sleep(5000);

                var workedHeroes = QueryWorkHeroes();

                Thread.Sleep(1000);

                GotoScreenTreasureHunt();

                Thread.Sleep(1000);

                appLog("INFO", $"HEROES WORKING: {workedHeroes}");

                if (workedHeroes == 0)
                {
                    var gotoHome = gameObjects.Find(x => x.Name == "btnGotoHome");

                    SetCursorPos(gotoHome.Position.X, gotoHome.Position.Y);

                    Thread.Sleep(200);

                    mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                    mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);

                    nCheckWorkHeroes.Value = 30;

                    appLog("INFO", $"WAITING AT HOME PER: {nCheckWorkHeroes.Value} minutes");
                }
            }

            timerCheckWorkHeros = ConvertMinutesToMilliseconds((int)nCheckWorkHeroes.Value);
        }

        private void GotoScreenHero()
        {
            var gotoHome = gameObjects.Find(x => x.Name == "btnGotoHome");
            var hero = gameObjects.Find(x => x.Name == "btnHero");

            SetCursorPos(gotoHome.Position.X, gotoHome.Position.Y);

            Thread.Sleep(200);

            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);

            Thread.Sleep(1000);

            SetCursorPos(hero.Position.X, hero.Position.Y);

            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
            Thread.Sleep(50);
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
        }

        private void rdLoopOff_CheckedChanged(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void lvActions_DoubleClick(object sender, EventArgs e)
        {
            if (editToolStripMenuItem.Available)
            {
                editToolStripMenuItem.PerformClick();
            }
        }

        private void PrintScreen(string name)
        {
            using (Bitmap printscreen = new Bitmap(display.Width, display.Height))
            {
                Graphics graphics = Graphics.FromImage(printscreen as System.Drawing.Image);
                graphics.CopyFromScreen(0, 0, 0, 0, printscreen.Size);

                File.Delete($"{appPath}\\{name}");

                printscreen.Save($"{appPath}\\{name}", ImageFormat.Jpeg);

                printscreen.Dispose();
                graphics.Dispose();
                GC.Collect();
            }
        }


        private void PrintScreenGrid(string name)
        {
            using (Bitmap printscreen = new Bitmap(display.Width, display.Height))
            {
                Graphics graphics = Graphics.FromImage(printscreen as System.Drawing.Image);
                graphics.CopyFromScreen(0, 0, 0, 0, printscreen.Size);


                Color color = Color.Red;
                int pctWidth = 0, col = 100;
                pctWidth = (int)(display.Width * 0.01);

                if (display.Width % 100 != 0)
                {
                    pctWidth += 1;
                    col = (display.Width / pctWidth) - 1;
                }
                
                int pctHeight = 0, lines = 100;
                pctHeight = (int)(display.Height * 0.01);

                if (display.Height % 100 != 0)
                {
                    pctHeight += 1;
                    lines = (display.Height / pctHeight) - 1;
                }

                int x = pctWidth, countCol = 0;

                while (true)
                {
                    col--;
                    countCol++;

                    if (col == 0)
                        break;

                    if (countCol == 10)
                    {
                        countCol = 0;

                        for (int y = 0; y < display.Height; y++)
                        {
                            printscreen.SetPixel(x, y, color);
                            printscreen.SetPixel(x + 1, y, color);
                        }
                    }

                    x += pctWidth;
                }

                int yy = pctHeight, countLines = 0;

                while (true)
                {
                    lines--;
                    countLines++;

                    if (lines == 0)
                        break;

                    if (countLines == 10)
                    {
                        countLines = 0;

                        for (int l = 0; l < display.Width; l++)
                        {
                            printscreen.SetPixel(l, yy, color);
                            printscreen.SetPixel(l, yy + 1, color);
                        }

                    }

                    yy += pctHeight;
                }

                File.Delete($"{appPath}\\{name}");

                printscreen.Save($"{appPath}\\{name}", ImageFormat.Jpeg);

                printscreen.Dispose();
                graphics.Dispose();
                GC.Collect();

            }
        }
        private void PrintScreen(string name, int width, int heigth, int x, int y)
        {
            using (Bitmap printscreen = new Bitmap(width, heigth))
            {
                Graphics graphics = Graphics.FromImage(printscreen as System.Drawing.Image);
                graphics.CopyFromScreen(x, y, 0, 0, printscreen.Size);

                File.Delete($"{appPath}\\{name}");

                printscreen.Save($"{appPath}\\{name}", ImageFormat.Jpeg);

                printscreen.Dispose();
                graphics.Dispose();
                GC.Collect();
            }
        }

        public static void cropAtRect(string sourceImage, string output, int x, int y, int width, int height)
        {
            using (FileStream fsSource = new FileStream(sourceImage, FileMode.Open, FileAccess.Read))
            {
                using (Bitmap bmpSourceImage = (Bitmap)Bitmap.FromStream(fsSource))
                {
                    using (var croppedBitmap = new Crop(new Rectangle(x, y, width, height)).Apply(bmpSourceImage))
                    {
                        croppedBitmap.Save(output, ImageFormat.Jpeg);

                        croppedBitmap.Dispose();
                    }

                    bmpSourceImage.Dispose();
                }
            }
        }        

        private void FindImage(string sourceImage, string template)
        {
            Bitmap bmpSourceImage = (Bitmap)Bitmap.FromFile(sourceImage);
            Bitmap bmpTemplate = (Bitmap)Bitmap.FromFile(template);

            ExhaustiveTemplateMatching tm = new ExhaustiveTemplateMatching(0.921f);
            // find all matchings with specified above similarity

            TemplateMatch[] matchings = tm.ProcessImage(bmpSourceImage, bmpTemplate);
            // highlight found matchings

            BitmapData data = bmpSourceImage.LockBits(
                 new Rectangle(0, 0, bmpSourceImage.Width, bmpSourceImage.Height),
                 ImageLockMode.ReadWrite, bmpSourceImage.PixelFormat);

            foreach (TemplateMatch m in matchings)
            {
                Drawing.Rectangle(data, m.Rectangle, Color.White);

                Console.WriteLine(m.Rectangle.Location.ToString());
                // do something else with matching
            }
            bmpSourceImage.UnlockBits(data);
        }

        private TemplateMatch[] FindImage(string sourceImage, string template, float compress = 0, float simularity = 0.841f)
        {
            TemplateMatch[] matchings = null;

            using (FileStream fsSource = new FileStream(sourceImage, FileMode.Open, FileAccess.Read))
            {
                using (FileStream fsTemplate = new FileStream(template, FileMode.Open, FileAccess.Read))
                {
                    Bitmap bmpSourceImage = (Bitmap)Bitmap.FromStream(fsSource);
                    Bitmap bmpTemplate = (Bitmap)Bitmap.FromStream(fsTemplate);

                    if (compress > 0)
                    {
                        var w = bmpSourceImage.Width * compress;
                        var h = bmpSourceImage.Height * compress;

                        var filter = new ResizeBicubic((int)w, (int)h);
                        bmpSourceImage = filter.Apply(bmpSourceImage);

                        w = bmpTemplate.Width * compress;
                        h = bmpTemplate.Height * compress;

                        filter = new ResizeBicubic((int)w, (int)h);
                        bmpTemplate = filter.Apply(bmpTemplate);
                    }

                    ExhaustiveTemplateMatching tm = new ExhaustiveTemplateMatching(simularity);
                    // find all matchings with specified above similarity

                    matchings = tm.ProcessImage(bmpSourceImage, bmpTemplate);

                    // highlight found matchings

                    bmpSourceImage.Dispose();
                    bmpTemplate.Dispose();
                    GC.Collect();

                }
            }


            return matchings;

        }

        private TemplateMatch[] FindImage(string sourceImage, GameObject gameObject,  float compress = 0)
        {
            TemplateMatch[] matchings = null;

            using (FileStream fsSource = new FileStream(sourceImage, FileMode.Open, FileAccess.Read))
            {
                using (FileStream fsTemplate = new FileStream(gameObject.Image, FileMode.Open, FileAccess.Read))
                {
                    Bitmap bmpSourceImage = (Bitmap)Bitmap.FromStream(fsSource);
                    Bitmap bmpTemplate = (Bitmap)Bitmap.FromStream(fsTemplate);

                    if (compress > 0)
                    {
                        var w = bmpSourceImage.Width * compress;
                        var h = bmpSourceImage.Height * compress;

                        var filter = new ResizeBicubic((int)w, (int)h);
                        bmpSourceImage = filter.Apply(bmpSourceImage);

                        w = bmpTemplate.Width * compress;
                        h = bmpTemplate.Height * compress;

                        filter = new ResizeBicubic((int)w, (int)h);
                        bmpTemplate = filter.Apply(bmpTemplate);
                    }

                    ExhaustiveTemplateMatching tm = new ExhaustiveTemplateMatching(gameObject.SimilarityThreshold);
                    // find all matchings with specified above similarity

                    var x = display.Width * (decimal)gameObject.SearchZone.X / 100;
                    var y = display.Height * (decimal)gameObject.SearchZone.Y / 100;
                    var width = display.Width * (decimal)gameObject.SearchZone.Width / 100;
                    var height = display.Height * (decimal)gameObject.SearchZone.Height / 100;

                    Rectangle rect = new Rectangle((int)x, (int)y, (int)width, (int)height);

                    matchings = tm.ProcessImage(bmpSourceImage, bmpTemplate, rect);

                    bmpSourceImage.Dispose();
                    bmpTemplate.Dispose();
                    GC.Collect();

                }
            }

            return matchings;
        }

        private void connectGame()
        {
            ActionsEntry actions = null;

            actions = OpenFileXml("Actions\\clickError.xml");
            SimulateClick(actions);
        }

        //private GameScreen WhereScreen(string source)
        //{
        //    if (FindImage(source, "Images\\BTN_CONNECT.jpg", 0.4f).Count() > 0)
        //        return GameScreen.Main;
        //    else
        //    if (FindImage(source, "Images\\BTN_TREASURE_HUNT.jpg", 0.4f).Count() > 0)
        //        return GameScreen.Home;
        //    else
        //        if (FindImage(source, "Images\\BTN_OPTIONS.jpg", 0.4f).Count() > 0)
        //        return GameScreen.TreasureHunt;
        //    else
        //        if (FindImage(source, "Images\\POWER.jpg", 0.4f).Count() > 0)
        //        return GameScreen.Heroes;
        //    else
        //        if (FindImage(source, "Images\\BTN_CLAIM.jpg", 0.4f).Count() > 0)
        //        return GameScreen.YourChest;
        //    else
        //        if (FindImage(source, "Images\\ERROR.jpg", 0.4F).Count() > 0)
        //        return GameScreen.Error;

        //    throw new Exception("Not Match");
        //}

        private void GotoScreenTreasureHunt()
        {
            var btnTreasure = gameObjects.Find(x => x.Name == "btnTreasureHunt");

            SetCursorPos(btnTreasure.Position.X, btnTreasure.Position.Y); ;

            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);

            Thread.Sleep(50);

            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
        }


        private int WorkHeroes()
        {
            var dv = gameObjects.Find(x => x.Name == "dv");
            var stamina = gameObjects.Find(x => x.Name == "btnStamina");
            var workDisable = gameObjects.Find(x => x.Name == "btnWorkDisable");

            int workHeroes = 0;

            string screenCrop = @"Tmp\\ScreenHeroesCrop.jpg";

            for (int prints = 0; prints < 3; prints++)
            {
                PrintScreen(@"Tmp\\ScreenHeroes.jpg");

                var heroes = FindImage(@"Tmp\\ScreenHeroes.jpg", dv).OrderBy(x => x.Rectangle.Location.Y);
                int firstPsX = 0, firstPsY = 0, psx = 0, psy = 0;
                double pctW, pctH;

                var firsthero = FindImage(@"Tmp\\ScreenHeroes.jpg", dv).OrderBy(x => x.Rectangle.Location.Y).First();

                pctW = Math.Round((double)((firsthero.Rectangle.Location.X * 100) / display.Width), 0) / 100;
                pctH = Math.Round((double)((firsthero.Rectangle.Location.Y * 100) / display.Height), 0) / 100;

                firstPsX = (int)(Screen.PrimaryScreen.Bounds.Width * pctW) + firsthero.Rectangle.Size.Width / 2;
                firstPsY = (int)(Screen.PrimaryScreen.Bounds.Height * pctH) + firsthero.Rectangle.Size.Height / 2;


                foreach (var hero in heroes)
                {
                    cropAtRect(@"Tmp\\ScreenHeroes.jpg", screenCrop, hero.Rectangle.Location.X,
                               hero.Rectangle.Location.Y, 550, hero.Rectangle.Size.Height);

                    var queryStamina = FindImage(screenCrop, stamina.Image, 0, stamina.SimilarityThreshold);
                    var queryBtnWork = FindImage(screenCrop, workDisable.Image, 0, workDisable.SimilarityThreshold);

                    if (queryStamina.Count() > 0 && queryBtnWork.Count() > 0)
                    {
                        SetCursorPos(firstPsX, firstPsY);

                        workHeroes++;

                        pctW = hero.Rectangle.Location.X + queryBtnWork[0].Rectangle.Location.X + queryBtnWork[0].Rectangle.Width;

                        pctW = Math.Round(((pctW * 100) / display.Width), 0) / 100;

                        pctH = hero.Rectangle.Location.Y + queryBtnWork[0].Rectangle.Location.Y;
                        pctH = Math.Round(((pctH * 100) / display.Height), 0) / 100;

                        psx = (int)(Screen.PrimaryScreen.Bounds.Width * pctW);
                        psy = (int)(Screen.PrimaryScreen.Bounds.Height * pctH);

                        Thread.Sleep(200);

                        mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                        mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);

                        Thread.Sleep(400);
                        SetCursorPos(psx, psy);

                        mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                        mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                        Thread.Sleep(50);
                        mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                        mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);

                        Thread.Sleep(3000);
                    }

                }

                if (prints < 2)
                {
                    for (int i = 0; i < 20; i++)
                    {
                        WheelMouse();
                    }

                    Thread.Sleep(3000);

                    PrintScreen(@"Tmp\\ScreenHeroes.jpg");

                }
            }

            Thread.Sleep(2000);

            var btnClose = gameObjects.Find(x => x.Name == "btnClose");

            SetCursorPos(btnClose.Position.X, btnClose.Position.Y);

            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
            Thread.Sleep(50);
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);

            return workHeroes;
        }

        private int QueryWorkHeroes()
        {
            var btnRest = gameObjects.Find(x => x.Name == "btnRest");

            PrintScreen(@"Tmp\\ScreenHeroes.jpg");

            var heroes = FindImage(@"Tmp\\ScreenHeroes.jpg", btnRest, 0).Count();


            var btnClose = gameObjects.Find(x => x.Name == "btnClose");

            SetCursorPos(btnClose.Position.X, btnClose.Position.Y);

            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
            Thread.Sleep(50);
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);

            return heroes;
        }

        private static void WheelMouse()
        {
            SetCursorPos(350, 350);

            Thread.Sleep(50);

            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);

            Thread.Sleep(50);

            mouse_event(MOUSEEVENTF_WHEEL, 0, 0, -10, 0);
        }

        private void SimulateClick(ActionsEntry actions)
        {
            foreach (ActionsEntryAction action in actions.Action)
            {
                SetCursorPos(action.X, action.Y);

                Thread.Sleep(100);

                if (action.Type == 0)
                {
                    mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                    mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                }
                else if (action.Type == 1)
                {
                    mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                    mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                    Thread.Sleep(100);
                    mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                    mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                }
                else
                if (action.Type == 4)
                {
                    mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                    mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                    mouse_event(MOUSEEVENTF_WHEEL, 0, 0, -10, 0);

                }
                else //if (action.Type.Equals(ClickType.rightClick))
                {
                    mouse_event(MOUSEEVENTF_RIGHTDOWN, 0, 0, 0, 0);
                    mouse_event(MOUSEEVENTF_RIGHTUP, 0, 0, 0, 0);
                }

                int tmpIntervl = action.interval.Equals(0) ? 0 : action.interval * 1000 - 100;
                Thread.Sleep(tmpIntervl);
            }
        }

        private void timerConnect_Tick(object sender, EventArgs e)
        {

        }

        private void rdCheckHeroesOff_CheckedChanged(object sender, EventArgs e)
        {
            timerCheckWorkHeros = 0;
            TaskWorkHeroes.Stop();


            if (rdCheckHeroesOff.Checked)
                appLog("INFO", "STOP - WORK HEROES ...");
        }

        private void rdCheckHeroesOn_CheckedChanged(object sender, EventArgs e)
        {
            timerCheckWorkHeros = ConvertMinutesToMilliseconds((int)nCheckWorkHeroes.Value);

            TaskWorkHeroes.Start();

            if (rdCheckHeroesOn.Checked)
                appLog("INFO", "STARTING - WORK HEROES ...");
        }

        private void TaskWorkHeroes_Tick(object sender, EventArgs e)
        {
            if(timerCheckWorkHeros == 0)
            {
                appLog("INFO", "*** WORK HEROES ***");

                timerCheckWorkHeros = ConvertMinutesToMilliseconds((int)nCheckWorkHeroes.Value);

                this.WindowState = FormWindowState.Minimized;

                Thread.Sleep(1000);

                CheckWorkHeroes();

                Thread.Sleep(200);

                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                lblNextAtt.Text = $"{ConverMillisecondsToMinutes(timerCheckWorkHeros)}";

                timerCheckWorkHeros -= 1000;

                if (timerCheckWorkHeros < 10000)
                    Console.Beep(2000, 5);
            }
        }

        private void nCheckWorkHeroes_ValueChanged(object sender, EventArgs e)
        {
            lblNextAtt.Text = $"{ConverMillisecondsToMinutes(timerCheckWorkHeros)}";
            timerCheckWorkHeros = ConvertMinutesToMilliseconds((int)nCheckWorkHeroes.Value);
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = cmbImages.GetItemText(cmbImages.SelectedItem);

            selected = selected.Replace("HEROES - ", "").Replace("TREASURE_HUNT - ", "").Replace("HOME - ", "");

            gObject_selected = gameObjects.Find(x => x.Image.EndsWith($"{selected}.jpg"));

            pcbImages.Load(gObject_selected .Image);

            nPsX.Value = gObject_selected .Position.X;
            nPsY.Value = gObject_selected .Position.Y;
            txtSimilarityThreshold.Text = gObject_selected .SimilarityThreshold.ToString();
            nSearchZoneX.Value = gObject_selected .SearchZone.Location.X;
            nSearchZoneY.Value = gObject_selected .SearchZone.Location.Y;
            nSearchZoneW.Value = gObject_selected .SearchZone.Width;
            nSearchZoneH.Value = gObject_selected .SearchZone.Height;

        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            if (gObject_selected.Name != null)
            {
                this.WindowState = FormWindowState.Minimized;

                Thread.Sleep(500);

                var gObj = new GameObject()
                {
                    Image = gObject_selected.Image,
                    Position = new Point((int)nPsX.Value, (int)nPsY.Value),
                    SimilarityThreshold = float.Parse(txtSimilarityThreshold.Text),
                    SearchZone = new Rectangle((int)nSearchZoneX.Value, (int)nSearchZoneY.Value,
                                                                        (int)nSearchZoneW.Value, (int)nSearchZoneH.Value)
                };

                PrintScreen("Test.bmp");

                var find = FindImage("Test.bmp", gObj, 0);

                if (find.Count() > 0)
                {
                    var firstFind = find.OrderByDescending(query => query.Similarity).First();

                    var pctW = Math.Round((double)((firstFind.Rectangle.Location.X * 100) / display.Width), 0) / 100;
                    var pctH = Math.Round((double)((firstFind.Rectangle.Location.Y * 100) / display.Height), 0) / 100;

                    var x = (int)(Screen.PrimaryScreen.Bounds.Width * pctW) + firstFind.Rectangle.Size.Width / 2;
                    var y = (int)(Screen.PrimaryScreen.Bounds.Height * pctH) + firstFind.Rectangle.Size.Height / 2;

                    SetCursorPos(x, y);

                    nPsX.Value = x;
                    nPsY.Value = y;

                    this.WindowState = FormWindowState.Normal;

                    MessageBox.Show($"Matchs: {find.Count()}" + Environment.NewLine +
                                    $"Simularity:  {firstFind.Similarity}", "Objeto encontrado  com sucesso");
                }
                else
                {
                    this.WindowState = FormWindowState.Normal;

                    MessageBox.Show("Objeto não encontrado  com sucesso");
                }

            }

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

            Thread.Sleep(500);

            PrintScreenGrid("Screen.jpg");

            Process.Start($"Screen.jpg");

            this.WindowState = FormWindowState.Normal;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (gObject_selected.Name != null)
            {

                var index = gameObjects.FindIndex(x => x.Name == gObject_selected.Name);
                gameObjects.RemoveAt(index);

                var gObj = new GameObject()
                {
                    Name = gObject_selected.Name,
                    Image = gObject_selected.Image,
                    Position = new Point((int)nPsX.Value, (int)nPsY.Value),
                    SimilarityThreshold = float.Parse(txtSimilarityThreshold.Text),
                    SearchZone = new Rectangle((int)nSearchZoneX.Value, (int)nSearchZoneY.Value,
                                                        (int)nSearchZoneW.Value, (int)nSearchZoneH.Value)
                };

                gameObjects.Add(gObj);

                Json.SaveObject("gameObjects.JSON", gameObjects);

                MessageBox.Show($"{gObject_selected.Name} foi salvo com sucesso.", "Concluido!");

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

            Thread.Sleep(500);

            PrintScreen("Screen.jpg");

            Process.Start($"Screen.jpg");

            this.WindowState = FormWindowState.Normal;
        }

        private void runAction()
        {
            enableButtons(false);

            if (rdLoopOn.Checked)
                timer1.Start();

            if (runActionThread == null || !runActionThread.IsAlive)
            {
                actions.Clear();
                foreach (ListViewItem lvi in lvActions.Items)
                {
                    actions.Add(lvi.Tag as ActionEntry);
                }
                runActionThread = new Thread(RunAction);
                runActionThread.Start();
            }
        }

        #endregion
    }
}
