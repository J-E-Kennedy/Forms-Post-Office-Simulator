using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stack = Jonstructures.JStack<JPostOffice.Package>;

namespace JPostOffice
{
    public class Truck : Person
    {
        public int DeliveredPackages { get; private set; }
        public float MaxCapacity { get; private set; }

        public bool OnTrip;
        float collectedIncome;
        TimeSpan tripTime;
        TimeSpan currentTravelTime;

        /// <summary>
        /// The fractional amount the truck is filled, rounded to 2 decimal places.
        /// </summary>
        public float FractionFilled => (float)Math.Round( CurrentCapacity / MaxCapacity, 2);

        /// <summary>
        /// The current total of all packages' size within the truck.
        /// </summary>
        public float CurrentCapacity => Packages.Sum(x => x.Size);
        
        /// <summary>
        /// Creates a new truck.
        /// </summary>
        /// <param name="maxCapacity">The max amount of the total size of all packages a truck can hold</param>
        /// <param name="tripTime">the amount of time the truck takes to come back from it's deliveries</param>
        public Truck(float maxCapacity, TimeSpan tripTime) : base(new Stack())
        {
            DeliveredPackages = 0;
            OnTrip = false;
            this.MaxCapacity = maxCapacity;
            this.tripTime = tripTime;
        }

        /// <summary>
        /// Fills the truck with packages and sends it on trips.
        /// </summary>
        /// <param name="StoredPackages">the packages in storage to fill up the truck with</param>
        /// <param name="earlyLeaveAmount">the fractional amount filled to leave early at if there are no packages in storage</param>
        public void Process(Stack StoredPackages, float earlyLeaveAmount)
        {
            while(StoredPackages.Count > 0 && CurrentCapacity + StoredPackages.Peek().Size <= MaxCapacity)
            {
                Packages.Push(StoredPackages.Pop());
            }
            if(CurrentCapacity >= MaxCapacity * earlyLeaveAmount)
            {
                OnTrip = true;
            }
        }

        /// <summary>
        /// Allows time to pass so the truck can travel on their route and return.
        /// </summary>
        /// <param name="elapsedTime">the amount of time passed since the last update</param>
        public void Update(TimeSpan elapsedTime)
        {
            if(OnTrip)
            {
                currentTravelTime += elapsedTime;
                if(currentTravelTime >= tripTime)
                {
                    OnTrip = false;
                    DeliveredPackages += Packages.Count();
                    collectedIncome += CurrentCapacity;
                    Packages = new Stack();
                    currentTravelTime = TimeSpan.Zero;
                }
            }
        }

        /// <summary>
        /// Takes all money stored on the truck and resets it to zero.
        /// </summary>
        /// <returns></returns>
        public float Collect()
        {
            float toCollect = collectedIncome;
            collectedIncome = 0;
            return toCollect;
        }

    }
}
