using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashCode_2019
{
    static public class Testing
    {
        static public void CountTag(List<Picture> pp) {
            var a = pp.SelectMany(p => p.Tags).GroupBy(p => p).Select(p => (p.Key, p.Count())).OrderByDescending(t => t.Item2).ToList();
            var top = a[0];
            var last = a[a.Count - 1];
            var avg = a.Average(aa => aa.Item2);
            int hh = 0;
        }


        static public void CountFotoTag(List<Picture> pp) {
            var vert = pp.Select(p => p.orientation == EOrientation.Horizontal).ToList();
            var hor = pp.Select(p => p.orientation == EOrientation.Vertical).ToList();
            var gg = pp.Select(p => p.Tags.Count()).GroupBy(n => n).Select(n => (n.Key, n.Count())).ToList().OrderByDescending(jj => jj.Key);
            int hh = 0;
        }




        static public BestMatch(List<Picture> listPicture, Picture picture) {
            var listMatch = listPicture.Select(p => p.Tags).Select(p)
        }
    }
}
