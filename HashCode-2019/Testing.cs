using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashCode_2019
{
    static public class Testing
    {
        static List<Picture> hor;

        static public void CountTag(List<Picture> pp) {
            var a = pp.SelectMany(p => p.Tags).GroupBy(p => p).Select(p => (p.Key, p.Count())).OrderByDescending(t => t.Item2).ToList();
            var top = a[0];
            var last = a[a.Count - 1];
            var avg = a.Average(aa => aa.Item2);
            int hh = 0;
        }


        static public void CountFotoTag(List<Picture> pp) {
            var gg = pp.Select(p => p.Tags.Count()).GroupBy(n => n).Select(n => (n.Key, n.Count())).ToList().OrderByDescending(jj => jj.Item2);
            int hh = 0;
        }

        static public void BestMatch(List<Picture> listPicture, Slide slide) {

            var listMatch = listPicture.Select(p => {
                var pt = (0, 0, 0);
                if (p.orientation == EOrientation.Vertical)
                    pt = CalcPoint(slide, p);
                else {
                    Picture compP = BestCompanionPicture(slide);
                    pt = CalcPoint(slide, p, compP);
                }

                return (0);
            });

        }


        static public Picture BestCompanionPicture(Slide origina) {
            //hor.Select(p => p.Tags).Select()
            return new Picture();
        }

        static public (int prev, int comm, int succ) CalcPoint(Slide s1, Slide s2) {
            int comm = s1.Tags.Intersect(s2.Tags).Count();
            int prev = s1.Tags.Count() - comm;
            int succ = s2.Tags.Count() - comm;

            return (prev, comm, succ);
        }

        static public (int prev, int comm, int succ) CalcPoint(Slide s1, Picture s2) {
            int comm = s1.Tags.Intersect(s2.Tags).Count();
            int prev = s1.Tags.Count() - comm;
            int succ = s2.Tags.Count() - comm;

            return (prev, comm, succ);
        }

        static public (int prev, int comm, int succ) CalcPoint(Picture s1, Picture s2) {
            int comm = s1.Tags.Intersect(s2.Tags).Count();
            int prev = s1.Tags.Count() - comm;
            int succ = s2.Tags.Count() - comm;

            return (prev, comm, succ);
        }

        static public (int prev, int comm, int succ) CalcPoint(Slide s1, Picture p1, Picture p2) {
            var tag2 = p1.Tags.Intersect(p2.Tags);

            int comm = s1.Tags.Intersect(tag2).Count();
            int prev = s1.Tags.Count() - comm;
            int succ = tag2.Count() - comm;

            return (prev, comm, succ);
        }

        static public int PTMin((int a, int b, int c) pt) {
            if (pt.a < pt.b && pt.a < pt.b) {
                return pt.a;
            } else if (pt.b < pt.c) {
                return pt.b;
            } else {
                return pt.c;
            }
        }










        static public void SetHorizontal(List<Picture> pp) {
            hor = pp.Where(p => p.orientation == EOrientation.Vertical).ToList();
        }

    }
}
