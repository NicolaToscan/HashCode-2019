using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashCode_2019
{
    static public class Testing
    {
        static public List<Picture> listPicture;
        static public List<Picture> vert;

        static public List<Slide> Doeverything(Slide prev) {
            List<Slide> res = new List<Slide>();
            res.Add(prev);
            while (listPicture.Count > 0) {
                Slide curr = BestMatch(prev);
                res.Add(curr);
                RemoveImgSlide(curr);
                prev = curr;
                if (listPicture.Count % 10 == 0)
                    Console.WriteLine(listPicture.Count);
            }

            return res;
        }

        static public void RemoveImgSlide(Slide s) {
            foreach (var p in s.Pics) {
                listPicture.Remove(p);
                if (p.orientation == EOrientation.Vertical)
                    vert.Remove(p);
            }
        }

        static public Slide BestMatch(Slide slide) {

            var aa = listPicture.Take(toDo(listPicture.Count)).Select(p => trovaPunti(p, slide));
            var firstTop = aa.OrderByDescending(p => p.Item1).First();
            var temp = listPicture.Skip(toDo(listPicture.Count)).FirstOrDefault(p => trovaPunti(p, slide).Item1 > firstTop.Item1);

            var top = firstTop;
            if (temp != null)
                top = trovaPunti(temp, slide);

            var tt = top.ToTuple();
            var picsRes = new List<Picture>();
            picsRes.Add(tt.Item2);

            if (tt.Item3 != null)
                picsRes.Add(tt.Item3);

            return new Slide(picsRes);

        }

        static public int toDo(int n) {
            if (n < 1000)
                return n;
            else
                return (n / 100);
        }

        public static (int, Picture, Picture) trovaPunti(Picture p, Slide slide) {
            var pt = (0, 0, 0);
            Picture compP = null;
            if (p.orientation == EOrientation.Horizontal)
                pt = CalcPoint(slide, p);
            else {
                pt = CalcPoint(slide, p);
                if (PTMin(pt) == 0) {
                    compP = BestCompanionPicture(slide, p);
                    pt = CalcPoint(slide, p, compP);
                }
            }

            return (PTMin(pt), p, compP);
        }



        static public Picture BestCompanionPicture(Slide prev, Picture origina) {
            return vert.Take(toDo(vert.Count)).Select(p => {
                var pt = CalcPoint(prev, p, origina);
                return (PTMin(pt), p);
            }).OrderByDescending(p => p.Item1).First().ToTuple().Item2;

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
            var tag2 = p1.Tags.Union(p2.Tags);

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
            vert = pp.Where(p => p.orientation == EOrientation.Vertical).ToList();
        }
        static public void SetAll(List<Picture> pp) {
            listPicture = new List<Picture>(pp);
        }

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

    }
}
