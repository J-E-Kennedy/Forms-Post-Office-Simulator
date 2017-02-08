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
        public Customer(Color color, Stack<Package> packages) : base(packages)
        {
            Color = color;
        }
    }
}
