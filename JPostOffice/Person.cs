using System;
using Stack = JPostOffice.Stack<JPostOffice.Package>;

namespace JPostOffice
{
    public class Person : IComparable
    {
        
        public Stack Packages { get; set; }

        public int PackagesHeld => Packages.Count;

        /// <summary>
        /// A person within the post office.
        /// </summary>
        /// <param name="packages">The packages they are holding.</param>
        public Person(Stack packages)
        {
            Packages = packages;
        }

        public int CompareTo(object obj)
        {
            var person = obj as Person;
            if (person == null)
            {
                return -1;
            }
            else if(Packages == person.Packages)
            {
                return 1;
            }
            return 0;
            
        }

    }
}
