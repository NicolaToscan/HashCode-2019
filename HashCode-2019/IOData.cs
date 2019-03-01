using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashCode_2019 {
    static public class IOData {
        static public List<Picture> GetFromFile(string fileName) {
            dic = new Dictionary<string, int>();
            lastTagId = 0;

            var res = new List<Picture>();

            using (StreamReader sr = new StreamReader(fileName)) {

                int nLines = Convert.ToInt32(sr.ReadLine());

                for (int i = 0; i < nLines; i++) {
                    string[] line = sr.ReadLine().Split(' ');
                    List<string> tags = line.Skip(2).ToList();
                    res.Add(new Picture() {
                        Id = i,
                        orientation = line[0] == "H" ? EOrientation.Horizontal : EOrientation.Vertical,
                        Tags = tags.Select(t => TagsMapping(t))
                    });
                }

            }

            dic = new Dictionary<string, int>();
            lastTagId = 0;
            return res;
        }


        static public void GenerateFile(List<Slide> slides, string output) {
            using (StreamWriter sw = new StreamWriter(output)) {
                sw.WriteLine(slides.Count);
                for (int i = 0; i < slides.Count; i++) {
                    sw.WriteLine(slides[i].IDs());
                }
            }
        }

        static private int lastTagId = 0;
        static private Dictionary<string, int> dic = new Dictionary<string, int>();

        static private int TagsMapping(string t) {
            if (dic.ContainsKey(t))
                return dic[t];

            lastTagId++;
            dic.Add(t, lastTagId);
            return lastTagId;
        }

    }
}
