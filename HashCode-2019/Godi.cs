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
        public List<int> Tags;

        public Picture(int Id, List<int> Tags)
        {
            this.Id = Id;
            this.Tags = Tags;
        }

        public bool Equals(Picture other)
        {
            return Id == other.Id;
        }

        List<int> ITag.GetTags()
        {
            return Tags;
        }

        public int CountTags()
        {
            return Tags.Count();
        }
    }

    public class HorizontalPicture : Picture, IOutput
    {
        public HorizontalPicture(int Id, List<int> Tags) : base(Id, Tags) { }
        public string GetOutput() => Id.ToString();
    }

    public class VerticalPicture : Picture
    {
        public VerticalPicture(int Id, List<int> Tags) : base(Id, Tags) { }
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

        List<int> ITag.GetTags()
        {
            return A.Tags.Union(B.Tags).ToList();
        }

        public int CountTags()
        {
            return A.Tags.Union(B.Tags).Count();
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
        public Picture i, j;
        public double score;

        public Score(Picture i, Picture j, double score)
        {
            this.i = i;
            this.j = j;
            this.score = score;
        }
    }

    /* ---------------------------------------------------------- */

    public enum Orientation
    {
        Horizontal, Vertical
    }

    public interface ITag
    {
        List<int> GetTags();
        int CountTags();
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

        public static List<IOutput> Ordina(List<Picture> pl)
        {
            W(" Inizializzazione...");

            // Divido verticali e orizzontali
            var verticali = pl.Where(x => x is VerticalPicture).OrderByDescending(x => x.Tags.Count);
            var orizzontali = pl.Where(x => x is HorizontalPicture).OrderByDescending(x => x.Tags.Count);

            List<VerticalPicture> verticaliList = verticali.Select(x => (VerticalPicture)x).ToList();


            W(" Verticali...");
            // Verticali
            int totVerticali = verticali.Count();
            int restanti = totVerticali;
            while(restanti > 0)
            {
                // Quante foto e quanti accoppiamenti devo confrontare questo ciclo
                int toSeeFoto = restanti > PPC ? PPC : restanti;
                int toSeeAccoppiamenti = restanti / 2;

                // Quante foto prendo da tutte le verticali
                int toDoAccoppiamenti = restanti > PPC ? SPC : toSeeAccoppiamenti;

                // Calcolo tutti i punteggi
                List<Score> scores = new List<Score>();
                for (int i = 0; i < toSeeFoto; i++)
                {
                    for(int j = 0; j < toSeeFoto - i && i > j; j++)
                    {
                        //VerticalPicture a = (VerticalPicture)verticali.ElementAt(i);
                        //VerticalPicture b = (VerticalPicture)verticali.ElementAt(j);
                        VerticalPicture a = verticaliList[i];
                        VerticalPicture b = verticaliList[j];

                        int db = CalcolaPunteggioTags(a, b);
                        scores.Add(new Score(a, b, db));
                    }
                }
                var ordered_scores = scores.OrderByDescending(x => x.score);
                
            }

            // Orizzontali
            // ...
            return null;
        }

        public static int CalcolaPunteggioTags(ITag p1, ITag p2)
        {
            int condivisi = p1.GetTags().Intersect(p2.GetTags()).Count();
            int uniciSx = p1.GetTags().Except(p2.GetTags()).Count();
            int uniciDx = p2.GetTags().Except(p1.GetTags()).Count();
            return minore(condivisi, uniciSx, uniciDx);

            // F
            int minore(int a, int b, int c) => (a < b) ? ((a < c) ? a : c) : ((b < c) ? b : c);
        }

        static void W(string txt) => Console.Write(txt);
        static void WL(string txt) => Console.WriteLine(txt);
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
