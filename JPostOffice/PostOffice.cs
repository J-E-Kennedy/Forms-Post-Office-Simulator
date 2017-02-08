using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Queue = JPostOffice.Queue<JPostOffice.Customer>;
using Stack = JPostOffice.Stack<JPostOffice.Package>;

namespace JPostOffice
{
    public class PostOffice
    {
        //The hour the office opens.
        int openTime;
        //The hour the office closes.
        int closeTime;
        //The amount of packages that can be stored, based on the size of the packages.
        float storageSpace;
        //The per-hour money penalty of owning the post office.
        float baseMaintainanceCost;
        //The per-hour money penalty of the post office as it runs (Has employees or customers inside).
        float runningMaintainanceCost;
        //The last hour the employees were paid.
        int lastPayout;
        Random random;

        /// <summary>
        /// The known display area that the visualizer can draw into.
        /// </summary>
        public int DisplayWidth { get; set; }
        /// <summary>
        /// Modifies the chance of a customer entering the post office.
        /// </summary>
        public float CustomerVolumeScalar { get; set; }
        /// <summary>
        /// The customers waiting in line.
        /// </summary>
        public Queue Queue { get; private set; }
        public List<Employee> Employees { get; private set; }
        public List<Truck> Trucks { get; private set; }
        /// <summary>
        /// The amount of people that have had their packages taken in by the office.
        /// </summary>
        public int PeopleServed { get; private set; }
        public float Money { get; private set; }
        /// <summary>
        /// Packages that have been taken in by employees that have yet to be put on trucks.
        /// </summary>
        public Stack StoredPackages { get; set; }
        public TimeSpan TotalRunTime { get; private set; }
        public int EmployeesAvailable => Employees.Where(x => x.Available).Count();
        public int PeopleWaitingCount => Queue.Count;
        public int PackagesWaitingCount => Queue.Count > 0 ? Queue.Sum(x => x.Packages.Count()) : 0;
        public int ProcessedPackageCount => StoredPackages.Count;
        public int DeliveredPackagesCount => Trucks.Sum(x => x.DeliveredPackages);
        public float StoredPackagesSum => StoredPackages.Sum(x => x.Size);
        /// <summary>
        /// If the office is open, new customers can come in.
        /// </summary>
        public bool IsOpen => TotalRunTime.Hours >= openTime && TotalRunTime.Hours < closeTime;

        public bool IsRunning => Employees.Any(x => !x.Away);

        /// <summary>
        /// Creates a new post office.
        /// </summary>
        /// <param name="startingCapital">The amount of money the office starts with.</param>
        /// <param name="employeeCount">The number of employees the office starts with.</param>
        /// <param name="truckCount">The number of trucks the office starts with.</param>
        /// <param name="storageSpace">How much storage space the office has.</param>
        /// <param name="startTime">The time when the office is first created.</param>
        /// <param name="openTime">The hour the office opens (24-hour time).</param>
        /// <param name="closeTime">The hour the office closes (24-hour time).</param>
        /// <param name="baseMaintainanceCost">The per-hour money penalty of owning the post office.</param>
        /// <param name="runningMaintainanceCost">The per-hour money penalty of the post office as it run.</param>
        /// <param name="random">The random generator to use in adding customers.</param>
        public PostOffice(int startingCapital, int employeeCount, int truckCount, float storageSpace, TimeSpan startTime, 
            int openTime, int closeTime, float baseMaintainanceCost, float runningMaintainanceCost, Random random)
        {
            Money = startingCapital;
            this.random = random;
            lastPayout = openTime;
            StoredPackages = new Stack();
            Queue = new Queue();
            Employees = new List<Employee>();
            Trucks = new List<Truck>();
            this.storageSpace = storageSpace;
            PeopleServed = 0;
            for (int i = 0; i < employeeCount; i++)
            {
                AddEmployee(true);
            }
            for (int i = 0; i < truckCount; i++)
            {
                AddTruck(true);
            }
            TotalRunTime = startTime;
            this.openTime = openTime;
            this.closeTime = closeTime;
            this.baseMaintainanceCost = baseMaintainanceCost;
            this.runningMaintainanceCost = runningMaintainanceCost;
        }

        /// <summary>
        /// Updates the office, adding new customers, paying employee wages, loads packages into trucks, and lets time pass.
        /// </summary>
        /// <param name="elapsedTime">The amount of in-game time that has elapsed since the last update</param>
        public void Update(TimeSpan elapsedTime)
        {
            TotalRunTime += elapsedTime;
            bool payTime = false;
            //Potentially adds a random customer into the office.
            if (TotalRunTime.Hours >= openTime && TotalRunTime.Hours < closeTime)
            {
                ChanceAddRandomPerson(elapsedTime);
            }
            //Checks if an hour has passed, to pay maitainance costs and wages.
            if (lastPayout < TotalRunTime.Hours)
            {
                lastPayout = TotalRunTime.Hours;
                payTime = true;
                Money -= baseMaintainanceCost;
                if (IsRunning)
                {
                    Money -= runningMaintainanceCost;
                }
                //Checks if in debt at midnight, and increases that debt.
                if(Money < 0 && TotalRunTime.Hours < 1)
                {
                    Money *= 1.1f;
                }
            }
            foreach (var employee in Employees)
            {
                //If there is any space to put packages and if any employee is available to work.
                if ((Trucks.Any(x => !x.OnTrip) || StoredPackagesSum < storageSpace) && employee.Available)
                {
                    if (payTime && !employee.Away)
                    {
                        //Pays an employee, and pays overtime if they are working after closing time.
                        Money -= IsOpen ? employee.Wage : employee.Wage * 10;
                    }
                    //Sends a customer to a employee.
                    if (PeopleWaitingCount > 0)
                    {
                        employee.Process(Queue.Dequeue());
                        PeopleServed++;
                    }
                }
                else
                {
                    employee.Update(elapsedTime);
                }
                employee.Away = !IsOpen && PeopleWaitingCount == 0;
            }
            foreach(Truck truck in Trucks)
            {
                truck.Update(elapsedTime);
                if(!truck.OnTrip)
                {
                    //Truck collects any package waiting in the stored packages.
                    truck.Process(StoredPackages, .9f);
                }
            }
        }

        /// <summary>
        /// Potentially add a person, based on random chance, modified by the customer volume scalar, elapsed time and people waiting.
        /// </summary>
        /// <param name="elapsedTime">The amount of in-game time that has elapsed since the last update</param>
        public void ChanceAddRandomPerson(TimeSpan elapsedTime)
        {
            if (CustomerVolumeScalar > 0 && random.Next() % Math.Max(1,(10000 - PeopleWaitingCount) / (int)((elapsedTime.TotalMilliseconds * CustomerVolumeScalar) + 1)) == 0)
            {
                AddCustomer();
            }
        }

        /// <summary>
        /// Adds a new random person, with a random amount of packages, each with a random size.
        /// </summary>
        public void AddCustomer()
        {
            int rand = random.Next(0, 100);
            int packageCount = 1 + Math.Abs(rand - 49) / 10;
            var packages = new Stack();
            for (int i = 0; i < packageCount; i++)
            {
                packages.Push(new Package(random.Next(1, 2500) / 100f));
            }
            Queue.Enqueue(new Customer(Color.FromArgb(255, Color.FromArgb(random.Next(int.MinValue, int.MaxValue))), packages));
        }
        
        /// <summary>
        /// Adds a new employee with a random processing speed and random work limit.
        /// </summary>
        /// <param name="free">If the employee is not paid when hired.</param>
        public void AddEmployee(bool free = false)
        {
            if(!free)
            {
                Money -= 1000;
            }
            Employees.Add(new Employee(this, 10, (float)random.NextDouble(), random.Next(10, 25), new TimeSpan(0, 5, 0)));
        }

        /// <summary>
        /// Removes a random employee.
        /// </summary>
        public void RemoveEmployee()
        {
            if(Employees.Count > 0)
            {
                Employees.RemoveAt(random.Next(Employees.Count));
            }
        }

        /// <summary>
        /// Adds a new truck.
        /// </summary>
        /// <param name="free">If the truck is paid for when added.</param>
        public void AddTruck(bool free = false)
        {
            if(!free)
            {
                Money -= 10000;
            }
            Trucks.Add(new Truck(1000, new TimeSpan(0, 15, 0)));
        }

        /// <summary>
        /// Removes a random truck, gains half-the cost of the truck back.
        /// </summary>
        public void removeTruck()
        {
            Money += 5000;
            if(Trucks.Count > 0)
            {
                Trucks.RemoveAt(random.Next(Trucks.Count()));
            }
        }

        /// <summary>
        /// Adds money into the office.
        /// </summary>
        /// <param name="money"></param>
        public void AddMoneyFromPackage(float money)
        {
            if(money > 0)
            {
                Money += money;
            }
        }

        public void SkipNight()
        {
            if(!IsRunning)
            {
                int hoursSkipped;
                if(TotalRunTime.Hours > closeTime)
                {
                    hoursSkipped = 24 - TotalRunTime.Hours + openTime;
                    TotalRunTime = new TimeSpan(TotalRunTime.Days + 1, openTime, 0, 0);
                    
                }
                else
                {
                    hoursSkipped = openTime - TotalRunTime.Hours;
                    TotalRunTime = new TimeSpan(TotalRunTime.Days, openTime, 0, 0);
                }
                Money -= baseMaintainanceCost * hoursSkipped;
            }
        }
    }
}