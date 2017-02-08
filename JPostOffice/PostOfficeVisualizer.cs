using System.Drawing;
using System.Linq;
namespace JPostOffice
{
    class PostOfficeVisualizer
    {
        Color BackgroundWhenOpen = Color.LightBlue;
        Color BackgroundWhenClosed = Color.MidnightBlue;
        Brush TruckColor = Brushes.White;
        Brush TruckFilling = Brushes.LimeGreen;
        Brush TruckTravelling = Brushes.Gray;
        Brush EmployeeWorking = Brushes.Blue;
        Brush EmployeeOnBreak = Brushes.Red;
        Brush EmployeeAvailable = Brushes.Green;
        Brush EmployeeAway = Brushes.Gray;

        PostOffice office;
        int truckSize;
        int employeeSize;
        int customerSize;
        public PostOfficeVisualizer(PostOffice office, int truckSize, int employeeSize, int customerSize)
        {
            this.office = office;
            this.truckSize = truckSize;
            this.employeeSize = employeeSize;
            this.customerSize = customerSize;
        }

        public void Draw(Graphics gfx)
        {
            gfx.Clear( office.IsOpen ? BackgroundWhenOpen : BackgroundWhenClosed);
            for (int i = 0; i < office.Trucks.Count(); i++)
            {
                var active = office.Trucks.ElementAt(i);
                var location = new Rectangle(5 + i * (truckSize + truckSize / 4), 5, truckSize, truckSize/2);
                gfx.FillRectangle(Brushes.Black, new Rectangle( location.X + 5, location.Y - 2, 8, location.Height + 5));
                gfx.FillRectangle(Brushes.Black, new Rectangle(location.X + 5 + 3 * location.Width / 5, location.Y - 2, 8, location.Height + 5));
                gfx.FillRectangle(TruckColor, location);
                gfx.FillRectangle(
                    active.OnTrip ? TruckTravelling : TruckFilling, 
                    new RectangleF(location.X, location.Y, location.Width * active.FractionFilled, location.Height));
                gfx.DrawString(active.FractionFilled * 100 + "%", SystemFonts.DefaultFont, Brushes.Black, 
                    new Point(location.X + truckSize * 2 / 5, location.Y + truckSize / 6));
                gfx.DrawRectangle(Pens.Black, location);
            }

            for (int i = 0; i < office.Employees.Count(); i++)
            {
                var active = office.Employees.ElementAt(i);
                var location = new Rectangle(5 + i * (employeeSize + employeeSize / 4), (truckSize / 2 + truckSize / 4), employeeSize, employeeSize);
                gfx.FillEllipse(
                    active.Available ? EmployeeAvailable : (active.OnBreak ? EmployeeOnBreak : (active.Away ? EmployeeOnBreak: EmployeeWorking)), 
                    location);
                gfx.DrawString(active.PackagesHeld.ToString(), SystemFonts.DefaultFont, Brushes.White,
                    new Point(location.X + employeeSize * 2 / 5, location.Y + employeeSize * 2 / 5));
                gfx.DrawEllipse(Pens.Black, location);
            }
            int personSpace = customerSize + 10;
            int rowItemsLength = office.DisplayWidth / personSpace;
            for (int i = 0; i < office.Queue.Count; i++)
            {
                var active = office.Queue.ElementAt(i);
                var location = new Rectangle( 5 + ( i / rowItemsLength % 2 == 0 ? i % rowItemsLength * personSpace
                    : (rowItemsLength - 1 - i % rowItemsLength) * personSpace), 
                    3 * (truckSize + employeeSize + customerSize) / 4 + (i / rowItemsLength) * personSpace, customerSize, customerSize);
                gfx.FillEllipse(new SolidBrush(active.Color), location);
                gfx.DrawString(active.PackagesHeld.ToString(), SystemFonts.DefaultFont, Brushes.White, 
                    new Rectangle(location.X + customerSize / 3, location.Y + customerSize / 3, location.Width, location.Height));
                gfx.DrawEllipse(Pens.White, location);
            }


        }
    }
}
