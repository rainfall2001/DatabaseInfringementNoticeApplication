namespace Deliverable2
{
    partial class FormOffence
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.offenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addOffenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateOffenceToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.filterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.withoutInfringmentNoticeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unpaidInfringementsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.overdueInfringementsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allOffencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.summaryReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statisticsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.whereTheOffenceTookPlaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.numberOfLanesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.speedLimitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lightConditionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.whenTheOffenceTookPlaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timeOfDayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dayOfWeekToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.offenderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ageOfTheDriverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.genderOfDriverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vehicleUsedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colourOfTheVehicleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registrationYearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listViewOffence = new System.Windows.Forms.ListView();
            this.colDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colOffender = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonView = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Courier New", 45F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(15)))), ((int)(((byte)(48)))));
            this.label1.Location = new System.Drawing.Point(196, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(422, 103);
            this.label1.TabIndex = 0;
            this.label1.Text = "OFFENCE";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Courier New", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(15)))), ((int)(((byte)(48)))));
            this.label2.Location = new System.Drawing.Point(238, 164);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(321, 37);
            this.label2.TabIndex = 1;
            this.label2.Text = "List of Offences";
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.offenceToolStripMenuItem,
            this.filterToolStripMenuItem,
            this.summaryReportToolStripMenuItem,
            this.statisticsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(862, 33);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // offenceToolStripMenuItem
            // 
            this.offenceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addOffenceToolStripMenuItem,
            this.updateOffenceToolStripMenuItem1});
            this.offenceToolStripMenuItem.Name = "offenceToolStripMenuItem";
            this.offenceToolStripMenuItem.Size = new System.Drawing.Size(90, 29);
            this.offenceToolStripMenuItem.Text = "Offence";
            // 
            // addOffenceToolStripMenuItem
            // 
            this.addOffenceToolStripMenuItem.Name = "addOffenceToolStripMenuItem";
            this.addOffenceToolStripMenuItem.Size = new System.Drawing.Size(239, 34);
            this.addOffenceToolStripMenuItem.Text = "Add Offence";
            this.addOffenceToolStripMenuItem.Click += new System.EventHandler(this.addOffenceToolStripMenuItem_Click);
            // 
            // updateOffenceToolStripMenuItem1
            // 
            this.updateOffenceToolStripMenuItem1.Name = "updateOffenceToolStripMenuItem1";
            this.updateOffenceToolStripMenuItem1.Size = new System.Drawing.Size(239, 34);
            this.updateOffenceToolStripMenuItem1.Text = "Update Offence";
            this.updateOffenceToolStripMenuItem1.Click += new System.EventHandler(this.updateOffenceToolStripMenuItem1_Click);
            // 
            // filterToolStripMenuItem
            // 
            this.filterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.withoutInfringmentNoticeToolStripMenuItem,
            this.unpaidInfringementsToolStripMenuItem,
            this.overdueInfringementsToolStripMenuItem,
            this.allOffencesToolStripMenuItem});
            this.filterToolStripMenuItem.Name = "filterToolStripMenuItem";
            this.filterToolStripMenuItem.Size = new System.Drawing.Size(133, 29);
            this.filterToolStripMenuItem.Text = "Filter Offence";
            // 
            // withoutInfringmentNoticeToolStripMenuItem
            // 
            this.withoutInfringmentNoticeToolStripMenuItem.Name = "withoutInfringmentNoticeToolStripMenuItem";
            this.withoutInfringmentNoticeToolStripMenuItem.Size = new System.Drawing.Size(341, 34);
            this.withoutInfringmentNoticeToolStripMenuItem.Text = "Without Infringement Notice";
            this.withoutInfringmentNoticeToolStripMenuItem.Click += new System.EventHandler(this.withoutInfringmentNoticeToolStripMenuItem_Click);
            // 
            // unpaidInfringementsToolStripMenuItem
            // 
            this.unpaidInfringementsToolStripMenuItem.Name = "unpaidInfringementsToolStripMenuItem";
            this.unpaidInfringementsToolStripMenuItem.Size = new System.Drawing.Size(341, 34);
            this.unpaidInfringementsToolStripMenuItem.Text = "Unpaid Infringements";
            this.unpaidInfringementsToolStripMenuItem.Click += new System.EventHandler(this.unpaidInfringementsToolStripMenuItem_Click);
            // 
            // overdueInfringementsToolStripMenuItem
            // 
            this.overdueInfringementsToolStripMenuItem.Name = "overdueInfringementsToolStripMenuItem";
            this.overdueInfringementsToolStripMenuItem.Size = new System.Drawing.Size(341, 34);
            this.overdueInfringementsToolStripMenuItem.Text = "Overdue Infringements";
            this.overdueInfringementsToolStripMenuItem.Click += new System.EventHandler(this.overdueInfringementsToolStripMenuItem_Click);
            // 
            // allOffencesToolStripMenuItem
            // 
            this.allOffencesToolStripMenuItem.Name = "allOffencesToolStripMenuItem";
            this.allOffencesToolStripMenuItem.Size = new System.Drawing.Size(341, 34);
            this.allOffencesToolStripMenuItem.Text = "All Offences";
            this.allOffencesToolStripMenuItem.Click += new System.EventHandler(this.allOffencesToolStripMenuItem_Click);
            // 
            // summaryReportToolStripMenuItem
            // 
            this.summaryReportToolStripMenuItem.Name = "summaryReportToolStripMenuItem";
            this.summaryReportToolStripMenuItem.Size = new System.Drawing.Size(162, 29);
            this.summaryReportToolStripMenuItem.Text = "Summary Report";
            this.summaryReportToolStripMenuItem.Click += new System.EventHandler(this.summaryReportToolStripMenuItem_Click);
            // 
            // statisticsToolStripMenuItem
            // 
            this.statisticsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.whereTheOffenceTookPlaceToolStripMenuItem,
            this.whenTheOffenceTookPlaceToolStripMenuItem,
            this.offenderToolStripMenuItem,
            this.vehicleUsedToolStripMenuItem});
            this.statisticsToolStripMenuItem.Name = "statisticsToolStripMenuItem";
            this.statisticsToolStripMenuItem.Size = new System.Drawing.Size(185, 29);
            this.statisticsToolStripMenuItem.Text = "Statistics of Offence";
            // 
            // whereTheOffenceTookPlaceToolStripMenuItem
            // 
            this.whereTheOffenceTookPlaceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.numberOfLanesToolStripMenuItem,
            this.speedLimitToolStripMenuItem,
            this.lightConditionsToolStripMenuItem});
            this.whereTheOffenceTookPlaceToolStripMenuItem.Name = "whereTheOffenceTookPlaceToolStripMenuItem";
            this.whereTheOffenceTookPlaceToolStripMenuItem.Size = new System.Drawing.Size(223, 34);
            this.whereTheOffenceTookPlaceToolStripMenuItem.Text = "Location";
            // 
            // numberOfLanesToolStripMenuItem
            // 
            this.numberOfLanesToolStripMenuItem.Name = "numberOfLanesToolStripMenuItem";
            this.numberOfLanesToolStripMenuItem.Size = new System.Drawing.Size(246, 34);
            this.numberOfLanesToolStripMenuItem.Text = "Number of lanes";
            this.numberOfLanesToolStripMenuItem.Click += new System.EventHandler(this.numberOfLanesToolStripMenuItem_Click_1);
            // 
            // speedLimitToolStripMenuItem
            // 
            this.speedLimitToolStripMenuItem.Name = "speedLimitToolStripMenuItem";
            this.speedLimitToolStripMenuItem.Size = new System.Drawing.Size(246, 34);
            this.speedLimitToolStripMenuItem.Text = "Speed limit";
            this.speedLimitToolStripMenuItem.Click += new System.EventHandler(this.speedLimitToolStripMenuItem_Click);
            // 
            // lightConditionsToolStripMenuItem
            // 
            this.lightConditionsToolStripMenuItem.Name = "lightConditionsToolStripMenuItem";
            this.lightConditionsToolStripMenuItem.Size = new System.Drawing.Size(246, 34);
            this.lightConditionsToolStripMenuItem.Text = "Light conditions";
            this.lightConditionsToolStripMenuItem.Click += new System.EventHandler(this.lightConditionsToolStripMenuItem_Click);
            // 
            // whenTheOffenceTookPlaceToolStripMenuItem
            // 
            this.whenTheOffenceTookPlaceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.timeOfDayToolStripMenuItem,
            this.dayOfWeekToolStripMenuItem});
            this.whenTheOffenceTookPlaceToolStripMenuItem.Name = "whenTheOffenceTookPlaceToolStripMenuItem";
            this.whenTheOffenceTookPlaceToolStripMenuItem.Size = new System.Drawing.Size(223, 34);
            this.whenTheOffenceTookPlaceToolStripMenuItem.Text = "Day and Time";
            // 
            // timeOfDayToolStripMenuItem
            // 
            this.timeOfDayToolStripMenuItem.Name = "timeOfDayToolStripMenuItem";
            this.timeOfDayToolStripMenuItem.Size = new System.Drawing.Size(215, 34);
            this.timeOfDayToolStripMenuItem.Text = "Time of Day";
            this.timeOfDayToolStripMenuItem.Click += new System.EventHandler(this.timeOfDayToolStripMenuItem_Click);
            // 
            // dayOfWeekToolStripMenuItem
            // 
            this.dayOfWeekToolStripMenuItem.Name = "dayOfWeekToolStripMenuItem";
            this.dayOfWeekToolStripMenuItem.Size = new System.Drawing.Size(215, 34);
            this.dayOfWeekToolStripMenuItem.Text = "Day of Week";
            this.dayOfWeekToolStripMenuItem.Click += new System.EventHandler(this.dayOfWeekToolStripMenuItem_Click);
            // 
            // offenderToolStripMenuItem
            // 
            this.offenderToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ageOfTheDriverToolStripMenuItem,
            this.genderOfDriverToolStripMenuItem});
            this.offenderToolStripMenuItem.Name = "offenderToolStripMenuItem";
            this.offenderToolStripMenuItem.Size = new System.Drawing.Size(223, 34);
            this.offenderToolStripMenuItem.Text = "Offender";
            // 
            // ageOfTheDriverToolStripMenuItem
            // 
            this.ageOfTheDriverToolStripMenuItem.Name = "ageOfTheDriverToolStripMenuItem";
            this.ageOfTheDriverToolStripMenuItem.Size = new System.Drawing.Size(250, 34);
            this.ageOfTheDriverToolStripMenuItem.Text = "Age of the Driver";
            this.ageOfTheDriverToolStripMenuItem.Click += new System.EventHandler(this.ageOfTheDriverToolStripMenuItem_Click);
            // 
            // genderOfDriverToolStripMenuItem
            // 
            this.genderOfDriverToolStripMenuItem.Name = "genderOfDriverToolStripMenuItem";
            this.genderOfDriverToolStripMenuItem.Size = new System.Drawing.Size(250, 34);
            this.genderOfDriverToolStripMenuItem.Text = "Gender of Driver";
            this.genderOfDriverToolStripMenuItem.Click += new System.EventHandler(this.genderOfDriverToolStripMenuItem_Click);
            // 
            // vehicleUsedToolStripMenuItem
            // 
            this.vehicleUsedToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.colourOfTheVehicleToolStripMenuItem,
            this.registrationYearToolStripMenuItem});
            this.vehicleUsedToolStripMenuItem.Name = "vehicleUsedToolStripMenuItem";
            this.vehicleUsedToolStripMenuItem.Size = new System.Drawing.Size(223, 34);
            this.vehicleUsedToolStripMenuItem.Text = "Vehicle Used";
            // 
            // colourOfTheVehicleToolStripMenuItem
            // 
            this.colourOfTheVehicleToolStripMenuItem.Name = "colourOfTheVehicleToolStripMenuItem";
            this.colourOfTheVehicleToolStripMenuItem.Size = new System.Drawing.Size(278, 34);
            this.colourOfTheVehicleToolStripMenuItem.Text = "Colour of the Vehicle";
            this.colourOfTheVehicleToolStripMenuItem.Click += new System.EventHandler(this.colourOfTheVehicleToolStripMenuItem_Click);
            // 
            // registrationYearToolStripMenuItem
            // 
            this.registrationYearToolStripMenuItem.Name = "registrationYearToolStripMenuItem";
            this.registrationYearToolStripMenuItem.Size = new System.Drawing.Size(278, 34);
            this.registrationYearToolStripMenuItem.Text = "Registration Year";
            this.registrationYearToolStripMenuItem.Click += new System.EventHandler(this.registrationYearToolStripMenuItem_Click);
            // 
            // listViewOffence
            // 
            this.listViewOffence.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(236)))), ((int)(((byte)(240)))));
            this.listViewOffence.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colDescription,
            this.colOffender});
            this.listViewOffence.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewOffence.FullRowSelect = true;
            this.listViewOffence.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewOffence.HideSelection = false;
            this.listViewOffence.Location = new System.Drawing.Point(53, 237);
            this.listViewOffence.MultiSelect = false;
            this.listViewOffence.Name = "listViewOffence";
            this.listViewOffence.Size = new System.Drawing.Size(700, 326);
            this.listViewOffence.TabIndex = 5;
            this.listViewOffence.UseCompatibleStateImageBehavior = false;
            this.listViewOffence.View = System.Windows.Forms.View.Details;
            this.listViewOffence.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            // 
            // colDescription
            // 
            this.colDescription.Text = "Description";
            this.colDescription.Width = 225;
            // 
            // colOffender
            // 
            this.colOffender.Text = "Offender";
            this.colOffender.Width = 222;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonAdd);
            this.panel1.Controls.Add(this.buttonUpdate);
            this.panel1.Controls.Add(this.buttonView);
            this.panel1.Location = new System.Drawing.Point(12, 579);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(598, 69);
            this.panel1.TabIndex = 8;
            // 
            // buttonAdd
            // 
            this.buttonAdd.BackColor = System.Drawing.Color.White;
            this.buttonAdd.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAdd.Location = new System.Drawing.Point(16, 18);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(165, 34);
            this.buttonAdd.TabIndex = 10;
            this.buttonAdd.Text = "Add Offence";
            this.buttonAdd.UseVisualStyleBackColor = false;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.BackColor = System.Drawing.Color.White;
            this.buttonUpdate.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonUpdate.Location = new System.Drawing.Point(199, 18);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(203, 34);
            this.buttonUpdate.TabIndex = 9;
            this.buttonUpdate.Text = "Update Offence";
            this.buttonUpdate.UseVisualStyleBackColor = false;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // buttonView
            // 
            this.buttonView.BackColor = System.Drawing.Color.White;
            this.buttonView.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonView.Location = new System.Drawing.Point(420, 18);
            this.buttonView.Name = "buttonView";
            this.buttonView.Size = new System.Drawing.Size(165, 34);
            this.buttonView.TabIndex = 8;
            this.buttonView.Text = "View Notice";
            this.buttonView.UseVisualStyleBackColor = false;
            this.buttonView.Click += new System.EventHandler(this.buttonView_Click);
            // 
            // FormOffence
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(58)))), ((int)(((byte)(100)))));
            this.ClientSize = new System.Drawing.Size(862, 687);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.listViewOffence);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "FormOffence";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Offence";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem filterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem withoutInfringmentNoticeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unpaidInfringementsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem overdueInfringementsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem offenceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem summaryReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem statisticsToolStripMenuItem;
        private System.Windows.Forms.ListView listViewOffence;
        private System.Windows.Forms.ColumnHeader colDescription;
        private System.Windows.Forms.ColumnHeader colOffender;
        private System.Windows.Forms.ToolStripMenuItem whereTheOffenceTookPlaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem numberOfLanesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem speedLimitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lightConditionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allOffencesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem whenTheOffenceTookPlaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem timeOfDayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dayOfWeekToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem offenderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ageOfTheDriverToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem genderOfDriverToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vehicleUsedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colourOfTheVehicleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registrationYearToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button buttonView;
        private System.Windows.Forms.ToolStripMenuItem addOffenceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateOffenceToolStripMenuItem1;
        private System.Windows.Forms.Button buttonAdd;
    }
}

