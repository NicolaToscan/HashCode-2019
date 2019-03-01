using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashCode_2019 {

    public abstract class Slide {
        public IEnumerable<int> Tags { get; set; }
        public Slide() {

        }

        public Slide(IEnumerable<int> tags) {
            Tags = tags;
        }

        public abstract string IDs();
    }


    public class SlideV : Slide {
        public Picture Pic { get; set; }

        public SlideV(Picture pic) : base(pic.Tags) {
            Pic = pic;
        }

        public override string IDs() {
            return Pic.Id.ToString();
        }
    }

    public class SlideH : Slide {
        public Picture Pic1 { get; set; }
        public Picture Pic2 { get; set; }

        public SlideH(Picture pic1, Picture pic2) : base(pic1.Tags.Union(pic2.Tags)) {
            Pic1 = pic1;
            Pic2 = pic2;
        }

        public override string IDs() {
            return $"{Pic1.Id} {Pic2.Id}";
        }
    }

}
