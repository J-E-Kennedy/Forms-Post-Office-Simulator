using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jonstructures;
using System.Drawing;

namespace JPostOffice
{
    public class Customer : Person
    {
        public Color Color { get; private set;}
        /// <summary>
        /// Creates a customer.
        /// </summary>
        /// <param name="color">the color the customer is drawn as</param>
        /// <param name="packages">the packages they are holding</param>
        public Customer(Color color, JStack<Package> packages) : base(packages)
        {
            Color = color;
        }
    }
}
