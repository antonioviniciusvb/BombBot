using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Clicker
{
    public static class Json
    {
        public static void SaveObject(string output, List<GameObject> gameObject)
        {
            //open file stream
            using (StreamWriter file = System.IO.File.CreateText(output))
            {
                JsonSerializer serializer = new JsonSerializer();

                var json = JsonConvert.SerializeObject(gameObject);

                file.WriteLine(json);

                //serialize object directly into file stream
                //serializer.Serialize(file, layout);
            }
        }

        public static List<GameObject> FileJsonToLayout(string path)
        {
            var gameObject = JsonConvert.DeserializeObject<List<GameObject>>(System.IO.File.ReadAllText(path));

            return gameObject;
        }

    }
}