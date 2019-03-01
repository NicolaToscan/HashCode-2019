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

            var res = new List<Picture>();

            using (StreamReader sr = new StreamReader(fileName)) {
                int nLines = Convert.ToInt32(sr.ReadLine());
                for (int i = 0; i < nLines; i++) {
                    string[] line = sr.ReadLine().Split(' ');
                    Orientation o = line[0] == "H" ? Orientation.Horizontal : Orientation.Vertical;
                    int id = i;
                    List<string> tags = line.ToList();
                    tags.RemoveAt(0);
                    tags.RemoveAt(0);

                    res.Add(new Picture() {
                        Id = id,
                        orientation = o,
                        Tags = tags
                    });
                }
            }

            return res;
        }


        static public void GenerateFile(List<Slide> slides) {
            using (StreamWriter sw = new StreamWriter("out.put")) {
                sw.WriteLine(slides.Count);
                for (int i = 0; i < slides.Count; i++) {
                    sw.WriteLine(String.Join(" ", slides[i].pics.Select(p => p.Id)));
                }
            }
        }
    }
}
