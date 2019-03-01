using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Console;

namespace HashCode_2019
{
    class Program
    {
        static void Main(string[] args) {
            string[] files = { "a.txt", "b.txt", "c.txt", "d.txt", "e.txt" };

            int nFolder = 1;
            while(Directory.Exists(nFolder.ToString()))
            {
                nFolder++;
            }
            Directory.CreateDirectory(nFolder.ToString());
            string SxPath = $"{nFolder.ToString()}\\";

            for(int i = 0; i < files.Length; i++)
            {
                string path = SxPath + files[i];
                Write($"Calcolo file {i + 1}. Attendi...");
                //
                var l = IOData.GetFromFile(files[0]);
                Godi.Ordina(l);
                //
                WriteLine("Ok!");
            }

            ReadLine();
        }
    }
}
