using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashCode_2019
{
    public class Picture : ITag, IEquatable<Picture>
    {
        public int Id;
        public List<string> Tags;

        public Picture(int Id, List<string> Tags)
        {
            this.Id = Id;
            this.Tags = Tags;
        }

        public bool Equals(Picture other)
        {
            return Id == other.Id;
        }

        List<string> ITag.GetTags()
        {
            return Tags;
        }
    }

    public class HorizontalPicture : Picture, IOutput
    {
        public HorizontalPicture(int Id, List<string> Tags) : base(Id, Tags) { }
        public string GetOutput() => Id.ToString();
    }

    public class VerticalPicture : Picture
    {
        public VerticalPicture(int Id, List<string> Tags) : base(Id, Tags) { }
    }

    /* ---------------------------------------------------------- */

    public class TwoVertical : ITag, IOutput
    {
        VerticalPicture A, B;

        public TwoVertical(VerticalPicture A, VerticalPicture B)
        {
            this.A = A;
            this.B = B;
        }

        public string GetOutput() => $"{A.Id.ToString()} {B.Id.ToString()}";

        List<string> ITag.GetTags()
        {
            return A.Tags.Union(B.Tags).ToList();
        }
    }

    /* ---------------------------------------------------------- */

    //public class Slide
    //{
    //    IOutput Sx, Dx;

    //    public Slide(IOutput Sx, IOutput Dx)
    //    {
    //        this.Sx = Sx;
    //        this.Dx = Dx;
    //    }
    //}

    /* ---------------------------------------------------------- */

    public class Score
    {
        public int i, j;
        public double score;
        public double howgood;

        public Score(int i, int j, double score)
        {
            this.i = i;
            this.j = j;
            this.score = score;

            howgood = 50.0 - score;
            if (howgood < 0)
            {
                howgood = -howgood;
            }
        }
    }

    /* ---------------------------------------------------------- */

    public enum Orientation
    {
        Horizontal, Vertical
    }

    public interface ITag
    {
        List<string> GetTags();
    }
    public interface IOutput
    {
        string GetOutput();
    }

    /* ---------------------------------------------------------- */

    public static class Godi
    {
        /// <summary>
        /// Pictures Per Cycle
        /// </summary>
        public const int PPC = 1000;

        /// <summary>
        /// Slides Per Cycle
        /// </summary>
        public const int SPC = PPC / 4;

        public static void Ordina(List<Picture> pl)
        {
            // Divido verticali e orizzontali
            var verticali = pl.Where(x => x is VerticalPicture).OrderByDescending(x => x.Tags.Count);
            var orizzontali = pl.Where(x => x is HorizontalPicture).OrderByDescending(x => x.Tags.Count);
            
            // Verticali
            int totvert = verticali.Count();
            while(verticali.Count() > 0)
            {
                // Quante foto prendo da tutte le verticali
                int foto_confrontate = PPC;

                List<Picture> sub = new List<Picture>();
                for(int i = 0; i < foto_confrontate && verticali.Count() > 0; i++)
                {
                    //sub.Add(verticali[i]);
                }

                //Score[,] scores = new Score[dim, dim];
                List<Score> ordered = new List<Score>();
                for(int i = 0; i < foto_confrontate; i++)
                {
                    for(int j = 0; j < foto_confrontate; j++)
                    {
                        if(i != j)
                        {
                            //scores[i, j] = new Score(i, j, ContaTagsCondivisi(sub[i], sub[j]));
                            ordered.Add(new Score(i, j, ContaTagsCondivisi(sub[i], sub[j])));
                        }
                    }
                }
                ordered = ordered.OrderBy(x => x.howgood).ToList();

                List<TwoVertical> tieni = new List<TwoVertical>();
                for(int i = 0; i < foto_confrontate / 4; i++)
                {
                    //tieni.Add(new tw)
                }
            }

            // Orizzontali
            // ...
            int hh = 0;
        }

        public static double ContaTagsCondivisi(ITag p1, ITag p2)
        {
            List<string> tot = p1.GetTags().Union(p2.GetTags()).ToList();
            List<string> condivisi = p1.GetTags().Intersect(p2.GetTags()).ToList();
            return (double)condivisi.Count / tot.Count;
        }
    }
    public static class Robe
    {
        static public void CountTag(List<Picture> pp)
        {
            var a = pp.SelectMany(p => p.Tags).GroupBy(p => p).Select(p => (p.Key, p.Count())).OrderByDescending(t => t.Item2).ToList();
            var top = a[0];
            var last = a[a.Count - 1];
            var avg = a.Average(aa => aa.Item2);
        }


        static public void CountFotoTag(List<Picture> pp)
        {
            var gg = pp.Select(p => p.Tags.Count()).GroupBy(n => n).Select(n => (n.Key, n.Count())).ToList().OrderByDescending(jj => jj.Item2);
        }
    }
}
