using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashCode_2019
{
    public class Picture
    {
        public int Id;
        public EOrientation orientation;
        public IEnumerable<int> Tags;
    }

    public enum EOrientation
    {
        Horizontal, Vertical
    }
}
