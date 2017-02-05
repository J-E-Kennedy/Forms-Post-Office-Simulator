namespace JPostOffice
{
    partial class PostOfficeSimulatorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.EmployeesAvailableLabel = new System.Windows.Forms.Label();
            this.updateTimer = new System.Windows.Forms.Timer(this.components);
            this.peopleWaitingLabel = new System.Windows.Forms.Label();
            this.customerScalarTrackBar = new System.Windows.Forms.TrackBar();
            this.timeScalarTrackBar = new System.Windows.Forms.TrackBar();
            this.customerScalarLabel = new System.Windows.Forms.Label();
            this.timeScalarLabel = new System.Windows.Forms.Label();
            this.packagesDeliveredLabel = new System.Windows.Forms.Label();
            this.visualizerBox = new System.Windows.Forms.PictureBox();
            this.addEmployeeButton = new System.Windows.Forms.Button();
            this.removeEmployeeButton = new System.Windows.Forms.Button();
            this.addTruckButton = new System.Windows.Forms.Button();
            this.removeTruckButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.timeLabel = new System.Windows.Forms.Label();
            this.statusLabel = new System.Windows.Forms.Label();
            this.packagesStoredLabel = new System.Windows.Forms.Label();
            this.packagesWaitingLabel = new System.Windows.Forms.Label();
            this.peopleServedLabel = new System.Windows.Forms.Label();
            this.moneyLabel = new System.Windows.Forms.Label();
            this.helpButton = new System.Windows.Forms.Button();
            this.skipNightButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.customerScalarTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeScalarTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.visualizerBox)).BeginInit();
            this.SuspendLayout();
            // 
            // EmployeesAvailableLabel
            // 
            this.EmployeesAvailableLabel.AutoSize = true;
            this.EmployeesAvailableLabel.Location = new System.Drawing.Point(12, 31);
            this.EmployeesAvailableLabel.Name = "EmployeesAvailableLabel";
            this.EmployeesAvailableLabel.Size = new System.Drawing.Size(110, 13);
            this.EmployeesAvailableLabel.TabIndex = 0;
            this.EmployeesAvailableLabel.Text = "Employees Available: ";
            // 
            // updateTimer
            // 
            this.updateTimer.Enabled = true;
            this.updateTimer.Interval = 25;
            this.updateTimer.Tick += new System.EventHandler(this.updateTimer_Tick);
            // 
            // peopleWaitingLabel
            // 
            this.peopleWaitingLabel.AutoSize = true;
            this.peopleWaitingLabel.Location = new System.Drawing.Point(193, 31);
            this.peopleWaitingLabel.Name = "peopleWaitingLabel";
            this.peopleWaitingLabel.Size = new System.Drawing.Size(82, 13);
            this.peopleWaitingLabel.TabIndex = 1;
            this.peopleWaitingLabel.Text = "People Waiting:";
            // 
            // customerScalarTrackBar
            // 
            this.customerScalarTrackBar.Location = new System.Drawing.Point(12, 505);
            this.customerScalarTrackBar.Maximum = 200;
            this.customerScalarTrackBar.Minimum = 1;
            this.customerScalarTrackBar.Name = "customerScalarTrackBar";
            this.customerScalarTrackBar.Size = new System.Drawing.Size(450, 45);
            this.customerScalarTrackBar.TabIndex = 2;
            this.customerScalarTrackBar.Value = 10;
            // 
            // timeScalarTrackBar
            // 
            this.timeScalarTrackBar.Location = new System.Drawing.Point(470, 505);
            this.timeScalarTrackBar.Maximum = 600;
            this.timeScalarTrackBar.Minimum = 1;
            this.timeScalarTrackBar.Name = "timeScalarTrackBar";
            this.timeScalarTrackBar.Size = new System.Drawing.Size(450, 45);
            this.timeScalarTrackBar.TabIndex = 3;
            this.timeScalarTrackBar.Value = 5;
            // 
            // customerScalarLabel
            // 
            this.customerScalarLabel.AutoSize = true;
            this.customerScalarLabel.Location = new System.Drawing.Point(12, 490);
            this.customerScalarLabel.Name = "customerScalarLabel";
            this.customerScalarLabel.Size = new System.Drawing.Size(87, 13);
            this.customerScalarLabel.TabIndex = 4;
            this.customerScalarLabel.Text = "Customer Scalar:";
            // 
            // timeScalarLabel
            // 
            this.timeScalarLabel.AutoSize = true;
            this.timeScalarLabel.Location = new System.Drawing.Point(500, 490);
            this.timeScalarLabel.Name = "timeScalarLabel";
            this.timeScalarLabel.Size = new System.Drawing.Size(66, 13);
            this.timeScalarLabel.TabIndex = 5;
            this.timeScalarLabel.Text = "Time Scalar:";
            // 
            // packagesDeliveredLabel
            // 
            this.packagesDeliveredLabel.AutoSize = true;
            this.packagesDeliveredLabel.Location = new System.Drawing.Point(368, 50);
            this.packagesDeliveredLabel.Name = "packagesDeliveredLabel";
            this.packagesDeliveredLabel.Size = new System.Drawing.Size(109, 13);
            this.packagesDeliveredLabel.TabIndex = 6;
            this.packagesDeliveredLabel.Text = "Packages Delivered: ";
            // 
            // visualizerBox
            // 
            this.visualizerBox.Location = new System.Drawing.Point(12, 68);
            this.visualizerBox.Name = "visualizerBox";
            this.visualizerBox.Size = new System.Drawing.Size(960, 420);
            this.visualizerBox.TabIndex = 0;
            this.visualizerBox.TabStop = false;
            // 
            // addEmployeeButton
            // 
            this.addEmployeeButton.Location = new System.Drawing.Point(538, 37);
            this.addEmployeeButton.Name = "addEmployeeButton";
            this.addEmployeeButton.Size = new System.Drawing.Size(75, 23);
            this.addEmployeeButton.TabIndex = 7;
            this.addEmployeeButton.Text = "Add";
            this.addEmployeeButton.UseVisualStyleBackColor = true;
            this.addEmployeeButton.Click += new System.EventHandler(this.addEmployeeButton_Click);
            // 
            // removeEmployeeButton
            // 
            this.removeEmployeeButton.Location = new System.Drawing.Point(619, 37);
            this.removeEmployeeButton.Name = "removeEmployeeButton";
            this.removeEmployeeButton.Size = new System.Drawing.Size(75, 23);
            this.removeEmployeeButton.TabIndex = 8;
            this.removeEmployeeButton.Text = "Remove";
            this.removeEmployeeButton.UseVisualStyleBackColor = true;
            this.removeEmployeeButton.Click += new System.EventHandler(this.removeEmployeeButton_Click);
            // 
            // addTruckButton
            // 
            this.addTruckButton.Location = new System.Drawing.Point(733, 37);
            this.addTruckButton.Name = "addTruckButton";
            this.addTruckButton.Size = new System.Drawing.Size(75, 23);
            this.addTruckButton.TabIndex = 9;
            this.addTruckButton.Text = "Add";
            this.addTruckButton.UseVisualStyleBackColor = true;
            this.addTruckButton.Click += new System.EventHandler(this.addTruckButton_Click);
            // 
            // removeTruckButton
            // 
            this.removeTruckButton.Location = new System.Drawing.Point(814, 37);
            this.removeTruckButton.Name = "removeTruckButton";
            this.removeTruckButton.Size = new System.Drawing.Size(75, 23);
            this.removeTruckButton.TabIndex = 10;
            this.removeTruckButton.Text = "Remove";
            this.removeTruckButton.UseVisualStyleBackColor = true;
            this.removeTruckButton.Click += new System.EventHandler(this.removeTruckButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(592, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Employee";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(796, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Truck";
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.Location = new System.Drawing.Point(12, 10);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(36, 13);
            this.timeLabel.TabIndex = 13;
            this.timeLabel.Text = "Time: ";
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(193, 10);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(40, 13);
            this.statusLabel.TabIndex = 14;
            this.statusLabel.Text = "Status:";
            // 
            // packagesStoredLabel
            // 
            this.packagesStoredLabel.AutoSize = true;
            this.packagesStoredLabel.Location = new System.Drawing.Point(12, 50);
            this.packagesStoredLabel.Name = "packagesStoredLabel";
            this.packagesStoredLabel.Size = new System.Drawing.Size(95, 13);
            this.packagesStoredLabel.TabIndex = 15;
            this.packagesStoredLabel.Text = "Packages Stored: ";
            // 
            // packagesWaitingLabel
            // 
            this.packagesWaitingLabel.AutoSize = true;
            this.packagesWaitingLabel.Location = new System.Drawing.Point(193, 52);
            this.packagesWaitingLabel.Name = "packagesWaitingLabel";
            this.packagesWaitingLabel.Size = new System.Drawing.Size(97, 13);
            this.packagesWaitingLabel.TabIndex = 16;
            this.packagesWaitingLabel.Text = "Packages Waiting:";
            // 
            // peopleServedLabel
            // 
            this.peopleServedLabel.AutoSize = true;
            this.peopleServedLabel.Location = new System.Drawing.Point(368, 31);
            this.peopleServedLabel.Name = "peopleServedLabel";
            this.peopleServedLabel.Size = new System.Drawing.Size(80, 13);
            this.peopleServedLabel.TabIndex = 17;
            this.peopleServedLabel.Text = "People Served:";
            // 
            // moneyLabel
            // 
            this.moneyLabel.AutoSize = true;
            this.moneyLabel.Location = new System.Drawing.Point(368, 10);
            this.moneyLabel.Name = "moneyLabel";
            this.moneyLabel.Size = new System.Drawing.Size(45, 13);
            this.moneyLabel.TabIndex = 18;
            this.moneyLabel.Text = "Money: ";
            // 
            // helpButton
            // 
            this.helpButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpButton.Location = new System.Drawing.Point(917, 10);
            this.helpButton.Name = "helpButton";
            this.helpButton.Size = new System.Drawing.Size(55, 50);
            this.helpButton.TabIndex = 19;
            this.helpButton.Text = "?";
            this.helpButton.UseVisualStyleBackColor = true;
            this.helpButton.Click += new System.EventHandler(this.helpButton_Click);
            // 
            // skipNightButton
            // 
            this.skipNightButton.Location = new System.Drawing.Point(926, 505);
            this.skipNightButton.Name = "skipNightButton";
            this.skipNightButton.Size = new System.Drawing.Size(50, 45);
            this.skipNightButton.TabIndex = 20;
            this.skipNightButton.Text = "Skip\r\nNight";
            this.skipNightButton.UseVisualStyleBackColor = true;
            this.skipNightButton.Click += new System.EventHandler(this.skipNightButton_Click);
            // 
            // PostOfficeSimulatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.skipNightButton);
            this.Controls.Add(this.helpButton);
            this.Controls.Add(this.moneyLabel);
            this.Controls.Add(this.peopleServedLabel);
            this.Controls.Add(this.packagesWaitingLabel);
            this.Controls.Add(this.packagesStoredLabel);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.removeTruckButton);
            this.Controls.Add(this.addTruckButton);
            this.Controls.Add(this.removeEmployeeButton);
            this.Controls.Add(this.addEmployeeButton);
            this.Controls.Add(this.visualizerBox);
            this.Controls.Add(this.packagesDeliveredLabel);
            this.Controls.Add(this.timeScalarLabel);
            this.Controls.Add(this.customerScalarLabel);
            this.Controls.Add(this.timeScalarTrackBar);
            this.Controls.Add(this.customerScalarTrackBar);
            this.Controls.Add(this.peopleWaitingLabel);
            this.Controls.Add(this.EmployeesAvailableLabel);
            this.Name = "PostOfficeSimulatorForm";
            this.Text = "Post Office Simulator 2017: Silver Edition";
            this.SizeChanged += new System.EventHandler(this.PostOfficeSimulatorForms_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.customerScalarTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeScalarTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.visualizerBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label EmployeesAvailableLabel;
        private System.Windows.Forms.Timer updateTimer;
        private System.Windows.Forms.Label peopleWaitingLabel;
        private System.Windows.Forms.TrackBar customerScalarTrackBar;
        private System.Windows.Forms.TrackBar timeScalarTrackBar;
        private System.Windows.Forms.Label customerScalarLabel;
        private System.Windows.Forms.Label timeScalarLabel;
        private System.Windows.Forms.Label packagesDeliveredLabel;
        private System.Windows.Forms.PictureBox visualizerBox;
        private System.Windows.Forms.Button addEmployeeButton;
        private System.Windows.Forms.Button removeEmployeeButton;
        private System.Windows.Forms.Button addTruckButton;
        private System.Windows.Forms.Button removeTruckButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Label packagesStoredLabel;
        private System.Windows.Forms.Label packagesWaitingLabel;
        private System.Windows.Forms.Label peopleServedLabel;
        private System.Windows.Forms.Label moneyLabel;
        private System.Windows.Forms.Button helpButton;
        private System.Windows.Forms.Button skipNightButton;
    }
}

