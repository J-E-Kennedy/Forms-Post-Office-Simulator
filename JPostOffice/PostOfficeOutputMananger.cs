using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JPostOffice
{
    class PostOfficeOutputMananger
    {
        Control timeOutput;
        Control statusOutput;
        Control peopleWaitingOutput;
        Control packagesWaitingOutput;
        Control moneyHeldOutput;
        Control peopleServedOutput;
        Control packagesStoredOutput;
        Control employeesAvailableOutput;
        Control deliveredPackagesOutput;
        PostOffice office;
        PostOfficeVisualizer officeVisualizer;

        /// <summary>
        /// Manages the output information of the post office to the GUI.
        /// </summary>
        /// <param name="postOffice">the post office who's information to display</param>
        /// <param name="timeOutput">the control to output the post office's current time</param>
        /// <param name="statusOutput">The control to output the status of the post office</param>
        /// <param name="moneyHeldOutput">The control to output the amount of money the post office has</param>
        /// <param name="peopleWaitingOutput">The control to output how many customers are waiting in the post office</param>
        /// <param name="packagesWaitingOutput">The control to output how many packages are held by waiting customers</param>
        /// <param name="peopleServedOutput">The control to output how many people have been server in total</param>
        /// <param name="packagesStoredOutput">The control to output how many packages are currently in storage</param>
        /// <param name="deliveredPackagesOutput">The control to output the total number of packages delivered by trucks</param>
        /// <param name="employeesAvailableOutput">The control to output the number of employees that are available to take customers</param>
        public PostOfficeOutputMananger(PostOffice postOffice,
            Control timeOutput, Control statusOutput, Control moneyHeldOutput, 
            Control peopleWaitingOutput, Control packagesWaitingOutput, Control peopleServedOutput,
            Control packagesStoredOutput, Control deliveredPackagesOutput, Control employeesAvailableOutput)
        {
            office = postOffice;
            officeVisualizer = new PostOfficeVisualizer(office, 80, 40, 20);
            this.timeOutput = timeOutput;
            this.statusOutput = statusOutput;
            this.peopleWaitingOutput = peopleWaitingOutput;
            this.packagesWaitingOutput = packagesWaitingOutput;
            this.moneyHeldOutput = moneyHeldOutput;
            this.peopleServedOutput = peopleServedOutput;
            this.packagesStoredOutput = packagesStoredOutput;
            this.employeesAvailableOutput = employeesAvailableOutput;
            this.deliveredPackagesOutput = deliveredPackagesOutput;
        }

        /// <summary>
        /// Draws the post office objects into the gfx.
        /// </summary>
        /// <param name="gfx">the gfx to use for drawing</param>
        public void Draw(Graphics gfx)
        {
            officeVisualizer.Draw(gfx);
        }

        /// <summary>
        /// Updates the text of all held controls to the current post office's state.
        /// </summary>
        public void Update()
        {
            peopleWaitingOutput.Text = $"People Waiting: {office.PeopleWaitingCount}";
            packagesWaitingOutput.Text = $"Packages Waiting: {office.PackagesWaitingCount}";
            peopleServedOutput.Text = $"People Served: {office.PeopleServed}";
            packagesStoredOutput.Text = $"Packages Stored: {office.ProcessedPackageCount}";
            employeesAvailableOutput.Text = $"Employees Available: {office.EmployeesAvailable}";
            deliveredPackagesOutput.Text = $"Delivered Packages: {office.DeliveredPackagesCount}";
            moneyHeldOutput.Text = $"Money Held: {Math.Round(office.Money, 2)}";
            timeOutput.Text = $"Day: {office.TotalRunTime.Days} Time: {FormatTime(office.TotalRunTime)}";
            statusOutput.Text = $"Status: " + (office.IsOpen ? "Open" : "Closed");
        }

        /// <summary>
        /// Converts the timeSpan into a day and 12-hour time formatted string.
        /// </summary>
        /// <param name="time">the timespan to convert</param>
        /// <returns></returns>
        public string FormatTime(TimeSpan time)
        {
            string displayTime = "";
            var hours = new int[] { 12, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
            displayTime += hours[time.Hours % 12] + ":";
            if (time.Minutes < 10)
            {
                displayTime += "0";
            }
            displayTime += time.Minutes;
            displayTime += ":";
            if (time.Seconds < 10)
            {
                displayTime += "0";
            }
            displayTime += time.Seconds;
            displayTime += time.Hours > 11 ? "PM" : "AM";
            return displayTime;
        }

    }
}
