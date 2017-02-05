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
    public partial class PostOfficeHelpForm : Form
    {
        PostOffice exampleOffice;
        PostOfficeVisualizer visualizer;
        Bitmap bitmap;
        Graphics gfx;
        public PostOfficeHelpForm(PostOffice exampleOffice)
        {
            InitializeComponent();
            this.exampleOffice = exampleOffice;
            exampleOffice.CustomerVolumeScalar = 0;
            helpChoiceComboBox.SelectedIndex = 0;
            visualizer = new PostOfficeVisualizer(exampleOffice, 80, 40, 20);
            bitmap = new Bitmap(displayBox.Width, displayBox.Height);
            exampleOffice.DisplayWidth = displayBox.Width;
            gfx = Graphics.FromImage(bitmap);
        }

        private void updateTimer_Tick(object sender, EventArgs e)
        {
            exampleOffice.Update(new TimeSpan(0,0,0,0,100));
            visualizer.Draw(gfx);
            displayBox.Image = bitmap;
        }

        private void newCustomerButton_Click(object sender, EventArgs e)
        {
            exampleOffice.AddCustomer();
        }

        private void helpChoiceComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            helpChoiceComboBox.AutoScrollOffset = Point.Empty;
            switch (helpChoiceComboBox.SelectedIndex)
            {
                case 0:
                    explanationBox.Text = "Welcome to Post Office Simulator 2017.\n\nWhere you control a post office, managing their money, trucks and employees day in, day out, against an endless stream of customers bringing in all their packages.";
                    break;
                case 1:
                    explanationBox.Text = "The white rectangle(s) on the top are your trucks, employees fill the truck up until it is ready to take off.\n\nOnce the truck takes off it will turn gray until it completes their deliveries.\n\nIf no trucks are available then packages will go to storage.\n\nIf storage becomes full while trucks are away the office will come to a halt.";
                    break;
                case 2:
                    explanationBox.Text = "Employees are the large circle(s) below the trucks.They will change color based on what action they're taking\n\nGreen: Available\nBlue: Working with a customer\nRed: Out on break\nGray: Away\n\nThe number represents the number of packages they must deal with before they can work with a new customer or take a break.\n\nEach employee has their own efficiency and constant work limit, higher values increase their hourly wages";
                    break;
                case 3:
                    explanationBox.Text = "Customers bring in an arbitrary number of packages, represented on them by a number.\n\nIf there are more customers than available tellers then they will appear as smaller circles in line below the employees.\n\nWhen working with an employee they will pay for each package based on it's weight.\n\nOnce they are out of packages they will leave the office.";
                    break;
                case 4:
                    explanationBox.Text = "The post office is open from 9am to 5pm.\n\nThe backround of the office is light blue when open and dark blue when closed.\n\nCustomers can come in anytime the office is open.\n\nOnce the office is closed no new customers can come in but those already inside must have their pacakages taken before the employees can leave.\n\nThe employees are paid overtime when kept after the office closes.";
                    break;
                case 5:
                    explanationBox.Text = "Packages are brought in by customers, processed by the employees and shipped out on the trucks.\n\nEach package has an arbitrary size, this affects how long it takes to process and how much space it takes up on a truck or storage.\n\nThe size also affects how much money must be paid by the customer to ship the package.";
                    break;
                case 6:
                    explanationBox.Text = "The post office makes money when it takes in packages from customers.\n\nThe office loses money each hour by paying out their wages, as well as maintainance costs, which are higher when the office is running.\n\nThe post office also loses money when it ships out packages to deliver.\n\nAdding a truck costs $10000, removing a truck gains $5000 back.\n\nAdding an employee costs $1000, nothing is made back when they are removed.\n\nIf you are running in debt you take a cash penalty each hour";
                    break;
            }

        }
    }
}
