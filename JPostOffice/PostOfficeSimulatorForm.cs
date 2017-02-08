using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace JPostOffice
{
    public partial class PostOfficeSimulatorForm : Form
    {
        float timeScalar;
        PostOffice office;
        Random random;
        Bitmap bitmap;
        Graphics gfx;
        PostOfficeOutputMananger outputManager;

        public PostOfficeSimulatorForm()
        {
            random = new Random();
            InitializeComponent();
            bitmap = new Bitmap(visualizerBox.Width, visualizerBox.Height);
            gfx = Graphics.FromImage(bitmap);
            //Creates an office with some example values.
            office = new PostOffice(0, 3, 1, 1000, new TimeSpan(1,8,59,0,0), 9, 17, 500, 1000, random);
            office.DisplayWidth = bitmap.Width;
            //Passes all labels to an output manager.
            outputManager = new PostOfficeOutputMananger(office, timeLabel, statusLabel, moneyLabel, peopleWaitingLabel,
                packagesWaitingLabel, peopleServedLabel, packagesStoredLabel, packagesDeliveredLabel,
                EmployeesAvailableLabel);
        }

        //checks the trackbars and updates the office accordingly, 
        private void updateTimer_Tick(object sender, EventArgs e)
        {
            timeScalar = timeScalarTrackBar.Value;
            office.Update(new TimeSpan(0,0,0,0,(int)(updateTimer.Interval * timeScalar)));
            office.CustomerVolumeScalar = customerScalarTrackBar.Value / 10f;
            customerScalarLabel.Text = $"Customer Scalar: x{customerScalarTrackBar.Value / 10f}";
            timeScalarLabel.Text = $"Time Scalar: x{timeScalar}";
            outputManager.Update();
            outputManager.Draw(gfx);
            visualizerBox.Image = bitmap;
            skipNightButton.Enabled = !office.IsRunning;
        }

        private void addEmployeeButton_Click(object sender, EventArgs e)
        {
            office.AddEmployee();
        }

        private void removeEmployeeButton_Click(object sender, EventArgs e)
        {
            office.RemoveEmployee();
        }

        private void addTruckButton_Click(object sender, EventArgs e)
        {
            office.AddTruck();
        }

        private void removeTruckButton_Click(object sender, EventArgs e)
        {
            office.removeTruck();
        }
        
        //Scales the form display, move lower objects to keep them below the display.
        private void PostOfficeSimulatorForms_SizeChanged(object sender, EventArgs e)
        {
            customerScalarLabel.Location = new Point(customerScalarLabel.Location.X, Height - 110);
            customerScalarTrackBar.Location = new Point(customerScalarTrackBar.Location.X, Height - 95);
            timeScalarTrackBar.Location = new Point(timeScalarTrackBar.Location.X, Height - 95);
            timeScalarLabel.Location = new Point(timeScalarLabel.Location.X, Height - 95);
            skipNightButton.Location = new Point(skipNightButton.Location.X, Height - 95);
            visualizerBox.Size = new Size(Width - 40, Height - 180);
            bitmap = new Bitmap(visualizerBox.Width, visualizerBox.Height);
            office.DisplayWidth = bitmap.Width;
            gfx = Graphics.FromImage(bitmap);
        }

        //Opens the help guide.
        private void helpButton_Click(object sender, EventArgs e)
        {
            PostOfficeHelpForm help = new PostOfficeHelpForm(new PostOffice(0, 3, 1, 100, TimeSpan.Zero, 0, 12, 500, 500, random));
            help.Show();
        }

        private void skipNightButton_Click(object sender, EventArgs e)
        {
            office.SkipNight();
        }
    }
}
