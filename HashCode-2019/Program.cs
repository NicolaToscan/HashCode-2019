using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashCode_2019
{
    class Program
    {
        static void Main(string[] args) {
            var l = IOData.GetFromFile("e.txt");
            Testing.CountFotoTag(l);
            Console.ReadLine();
        }
    }
}
