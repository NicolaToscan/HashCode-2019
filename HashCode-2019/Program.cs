using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashCode_2019
{
    class Program
    {
        List<Picture> res = new List<Picture>();

        static void Main(string[] args) {
            string input = Console.ReadLine();
            string output = Console.ReadLine();
            var l = IOData.GetFromFile(input);
            Testing.SetHorizontal(l);
            Testing.SetAll(l);

            List<Picture> prima = new List<Picture>();
            var trovata = Testing.listPicture.FirstOrDefault(p => p.orientation == EOrientation.Horizontal);
            if (trovata == null) {
                prima = Testing.listPicture.Where(p => p.orientation == EOrientation.Vertical).Take(2).ToList();
                Testing.listPicture.Remove(prima[0]);
                Testing.listPicture.Remove(prima[1]);
            } else {
                prima.Add(trovata);
                Testing.listPicture.Remove(trovata);
            }

            Slide inizio = new Slide(prima);

            var finito = Testing.Doeverything(inizio);
            IOData.GenerateFile(finito, output);
            Console.ReadLine();
        }

    }
}
