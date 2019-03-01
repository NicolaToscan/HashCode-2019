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

            List<Picture> res = new List<Picture>();

            using (StreamReader sr = new StreamReader(fileName)) {
                int nLines = Convert.ToInt32(sr.ReadLine());
                for (int i = 0; i < nLines; i++) {
                    string[] line = sr.ReadLine().Split(' ');
                    Orientation o = line[0] == "H" ? Orientation.Horizontal : Orientation.Vertical;
                    int id = i;
                    List<string> tags = line.ToList();
                    tags.RemoveAt(0);
                    tags.RemoveAt(0);

                    if (o == Orientation.Horizontal)
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
    }
}
