using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Job.Classes
{
    class Repository
    {
        public Repository()
        {
            List<Specialization> spez = new List<Specialization>();

            List<Specialization> ss = new List<Specialization>()
           {
               new Specialization("It"),
               new Specialization("Hr"),
               new Specialization("Top Management"),
               new Specialization("Economics"),
               new Specialization("Design"),
               new Specialization("Mass Media"),
               new Specialization("Security"),
               new Specialization("Jurisprudence")
           };
            SaveList("spez.json", ss);
            spez = RestoreList<Specialization>("spez.json");
        }

        public static void SaveList<T>(string fileName, List<T> list)
        {
            using (var sw = new StreamWriter(fileName))
            {
                using (var jsonWriter = new JsonTextWriter(sw))
                {
                    jsonWriter.Formatting = Formatting.Indented;
                    var serializer = new JsonSerializer();
                    serializer.Serialize(jsonWriter, list);
                }
            }
        }
        public static List<T> RestoreList<T>(string fileName)
        {
            using (var sr = new StreamReader(fileName))
            {
                using (var jsonReader = new JsonTextReader(sr))
                {
                    var serializer = new JsonSerializer();
                    return serializer.Deserialize<List<T>>(jsonReader);
                }
            }
        }
    }
}
