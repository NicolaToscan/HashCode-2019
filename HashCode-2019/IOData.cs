using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashCode_2019
{
    static public class IOData
    {
        static public List<Picture> GetFromFile(string fileName) {
            W(" Carico...");

            List<Picture> res = new List<Picture>();

            // Dizionario
            Dictionary<string, int> dic = new Dictionary<string, int>();
            int counter = 0;

            using (StreamReader sr = new StreamReader(fileName)) {
                // Lettura file
                int nLines = Convert.ToInt32(sr.ReadLine());
                for (int i = 0; i < nLines; i++) {
                    // Divido riga
                    string[] line = sr.ReadLine().Split(' ');

                    // Orientamento
                    bool o = line[0] == "H";

                    // ID
                    int id = i;

                    // Tags
                    var strTags = line.Skip(2);
                    List<int> tags = new List<int>();

                    foreach(string str in strTags)
                    {
                        int val = 0;
                        if (!dic.TryGetValue(str, out val))
                        {
                            val = counter;
                            dic.Add(str, counter++);
                        }                    
                        tags.Add(val);
                    }

                    if (o)
                        res.Add(new HorizontalPicture(id, tags));
                    else
                        res.Add(new VerticalPicture(id, tags));
                }
            }
            

            return res;
        }


        static public void GenerateFile(List<IOutput> slides, string outputFile) {
            using (StreamWriter sw = new StreamWriter(outputFile)) {
                sw.WriteLine(slides.Count);
                foreach(IOutput str in slides)
                {
                    sw.WriteLine(str.GetOutput());
                }
            }
        }

        static void W(string txt) => Console.Write(txt);
        static void WL(string txt) => Console.WriteLine(txt);
    }
}
