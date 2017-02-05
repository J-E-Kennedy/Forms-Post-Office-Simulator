using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPostOffice
{
    public class Package : IComparable
    {
        public float Size { get; private set; }
        /// <summary>
        /// Creates a new package.
        /// </summary>
        /// <param name="size">the size of the package.</param>
        public Package(float size)
        {
            Size = size;
        }

        /// <summary>
        /// Compares two packages sizes.
        /// </summary>
        /// <param name="obj">the package to compare to</param>
        /// <returns></returns>
        public int CompareTo(object obj)
        {
            if((obj as Package) == null)
            {
                return -1;
            }
            return (int)(Size - (obj as Package).Size); 
        }
    }
}
