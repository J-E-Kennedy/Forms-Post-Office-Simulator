using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jonstructures;
using Stack = Jonstructures.JStack<JPostOffice.Package>;
namespace JPostOffice
{
    public class Employee : Person
    {
        /// <summary>
        /// If the employee is at the post office.
        /// </summary>
        public bool Away { get; set; }
        /// <summary>
        /// If the employee is taking a break.
        /// </summary>
        public bool OnBreak { get; private set; }
        /// <summary>
        /// The hourly wage of an employee.
        /// </summary>
        public float Wage { get; private set; }
        /// <summary>
        /// If the employee is available to take packages.
        /// </summary>
        public bool Available => Packages.Count == 0 && !OnBreak && !Away;

        int workLimit;
        int continuousPackageStreak;
        float processingSpeed;
        Stack completed;
        TimeSpan accumulatedWork;
        TimeSpan breakTime;
        PostOffice office;
        /// <summary>
        /// Creates a new employee.
        /// </summary>
        /// <param name="office">What office they work at.</param>
        /// <param name="baseWage">The base wage of your employees, before being modified by processing speed and work limit.</param>
        /// <param name="processingSpeed">The speed multiplier at which the employee processes packages.</param>
        /// <param name="workLimit">The number of packages they can work consecutively before taking a break.</param>
        /// <param name="breakTime">How long the employee takes a break for.</param>
        public Employee(PostOffice office, float baseWage, float processingSpeed, int workLimit, TimeSpan breakTime) : base(new Stack())
        {
            this.office = office;
            this.processingSpeed = processingSpeed;
            this.workLimit = workLimit;
            this.breakTime = breakTime;
            completed = new Stack();
            Wage = (float)Math.Round(baseWage * (1 + processingSpeed/2) * (1 + workLimit/100f), 2);
            OnBreak = false;
            continuousPackageStreak = 0;
        }

        /// <summary>
        /// Takes in a customer to process their packages.
        /// </summary>
        /// <param name="person">the customer to process</param>
        public void Process(Person person)
        {
            foreach (var package in completed)
            {
                office.StoredPackages.Push(completed.Pop());
            }
            Packages = person.Packages;
            person.Packages = new Stack();
        }

        /// <summary>
        /// Processes any packages being held, and takes breaks.
        /// </summary>
        /// <param name="elapsedTime">the time passed since the last update</param>
        public void Update(TimeSpan elapsedTime)
        {
            if(OnBreak)
            {
                accumulatedWork += elapsedTime;
                if(accumulatedWork >= breakTime)
                {
                    accumulatedWork = TimeSpan.Zero;
                    OnBreak = false;
                }
            }
            else if(PackagesHeld > 0)
            {
                accumulatedWork += elapsedTime;
                if(accumulatedWork.Ticks / 1e7f >= Packages.Peek().Size)
                {
                    accumulatedWork = TimeSpan.Zero;
                    completed.Push(Packages.Pop());
                    office.AddMoneyFromPackage(completed.Peek().Size);
                    continuousPackageStreak++;
                    if(continuousPackageStreak >= workLimit && PackagesHeld == 0)
                    {
                        continuousPackageStreak = continuousPackageStreak - workLimit;
                        OnBreak = true;
                    }
                }
            }
        }

    }
}
