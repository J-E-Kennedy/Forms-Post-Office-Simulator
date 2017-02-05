namespace JPostOffice
{
    partial class PostOfficeHelpForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PostOfficeHelpForm));
            this.newCustomerButton = new System.Windows.Forms.Button();
            this.displayBox = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.explanationBox = new System.Windows.Forms.RichTextBox();
            this.updateTimer = new System.Windows.Forms.Timer(this.components);
            this.helpChoiceComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.displayBox)).BeginInit();
            this.SuspendLayout();
            // 
            // newCustomerButton
            // 
            this.newCustomerButton.Location = new System.Drawing.Point(84, 227);
            this.newCustomerButton.Name = "newCustomerButton";
            this.newCustomerButton.Size = new System.Drawing.Size(70, 23);
            this.newCustomerButton.TabIndex = 0;
            this.newCustomerButton.Text = "Customer";
            this.newCustomerButton.UseVisualStyleBackColor = true;
            this.newCustomerButton.Click += new System.EventHandler(this.newCustomerButton_Click);
            // 
            // displayBox
            // 
            this.displayBox.Location = new System.Drawing.Point(12, 12);
            this.displayBox.Name = "displayBox";
            this.displayBox.Size = new System.Drawing.Size(150, 209);
            this.displayBox.TabIndex = 1;
            this.displayBox.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 227);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(66, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // explanationBox
            // 
            this.explanationBox.Location = new System.Drawing.Point(168, 39);
            this.explanationBox.Name = "explanationBox";
            this.explanationBox.ReadOnly = true;
            this.explanationBox.Size = new System.Drawing.Size(169, 211);
            this.explanationBox.TabIndex = 4;
            this.explanationBox.Text = resources.GetString("explanationBox.Text");
            // 
            // updateTimer
            // 
            this.updateTimer.Enabled = true;
            this.updateTimer.Interval = 20;
            this.updateTimer.Tick += new System.EventHandler(this.updateTimer_Tick);
            // 
            // helpChoiceComboBox
            // 
            this.helpChoiceComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.helpChoiceComboBox.FormattingEnabled = true;
            this.helpChoiceComboBox.Items.AddRange(new object[] {
            "Introduction",
            "Trucks/Storage",
            "Employees",
            "Customers",
            "Store Hours",
            "Packages",
            "Money"});
            this.helpChoiceComboBox.Location = new System.Drawing.Point(168, 12);
            this.helpChoiceComboBox.Name = "helpChoiceComboBox";
            this.helpChoiceComboBox.Size = new System.Drawing.Size(169, 21);
            this.helpChoiceComboBox.TabIndex = 5;
            this.helpChoiceComboBox.SelectedIndexChanged += new System.EventHandler(this.helpChoiceComboBox_SelectedIndexChanged);
            // 
            // PostOfficeHelpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 262);
            this.Controls.Add(this.helpChoiceComboBox);
            this.Controls.Add(this.explanationBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.displayBox);
            this.Controls.Add(this.newCustomerButton);
            this.Name = "PostOfficeHelpForm";
            this.Text = "postOfficeHelp";
            ((System.ComponentModel.ISupportInitialize)(this.displayBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button newCustomerButton;
        private System.Windows.Forms.PictureBox displayBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox explanationBox;
        private System.Windows.Forms.Timer updateTimer;
        private System.Windows.Forms.ComboBox helpChoiceComboBox;
    }
}