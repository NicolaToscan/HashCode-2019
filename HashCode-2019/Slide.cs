using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashCode_2019
{
    public class Slide
    {
        public List<Picture> Pics { get; set; }
        public List<string> Tags { get; set; }

        public Slide(List<Picture> pics) {
            Pics = pics;
            if (pics.Count == 1)
                Tags = pics[0].Tags;
            else
                Tags = pics[0].Tags.Union(pics[1].Tags).ToList();
        }
    }
}
