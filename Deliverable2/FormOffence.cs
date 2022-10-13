using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Deliverable2
{
    /// <summary>
    /// Rhane Mercado
    /// 1529860
    /// This class controls the functionality of the FormOffence. 
    /// All the offences and corresponding offenders are displayed.
    /// </summary>
    public partial class FormOffence : Form
    {
        private string MESSAGE = "Please select an offence.";
        private List<int> OFFENCE_ID_LIST;

        public FormOffence()
        {
            InitializeComponent();
            CentreFormElements();
            GetOffences("SELECT * FROM offence_info");
            
        }

        /// <summary>
        /// This method centres all the elements in the form.
        /// </summary>
        private void CentreFormElements()
        {
            label1.Left = (this.ClientSize.Width - label1.Size.Width) / 2;
            label2.Left = (this.ClientSize.Width - label2.Size.Width) / 2;
            listViewOffence.Left = (this.ClientSize.Width - listViewOffence.Width) / 2;
            panel1.Left = (this.ClientSize.Width - panel1.Size.Width) / 2;
        }

        /// <summary>
        /// This method gets all the offences specified by the query.
        /// </summary>
        /// <param name="query">Query for the database</param>
        private void GetOffences(string query)
        {
            //get offence and offender data from the database and check if anyhting has been returned
            try
            {
                SQL.SelectQuery(query);
                if (SQL.read.HasRows)
                {
                    OFFENCE_ID_LIST = new List<int>();
                    //read and display the data valid to the user
                    while (SQL.read.Read())
                    {
                        //store the id of the offence
                        OFFENCE_ID_LIST.Add(int.Parse(SQL.read[0].ToString()));

                        //display the offence
                        string name = String.Format("{0} {1}", SQL.read[2].ToString(), SQL.read[3].ToString());
                        string[] row = { SQL.read[1].ToString(), name };
                        ListViewItem item = new ListViewItem(row);
                        listViewOffence.Items.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }            
        }

        /// <summary>
        /// This method queries the database for all the data related to the 
        /// infringement notice to show to the user.
        /// </summary>
        /// <param name="index">Index of the select item in the list box</param>
        private void GetNotice(int index)
        {
            try
            {
                //get the data corresponding to the offence choosen
                SQL.SelectQuery(String.Format("EXEC get_notice {0}", OFFENCE_ID_LIST.ElementAt(index)));
                if (SQL.read.HasRows)
                {
                    //display very infringement notice
                    while (SQL.read.Read())
                    {
                        FormNotice formNotice = new FormNotice();
                        formNotice.Show();
                    }
                    //this.Show();
                }
                else
                {
                    MessageBox.Show("There are no infringement notice\nassociated with this offence.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }
        }


        private void AddOffence()
        {
            this.Hide();
            FormEditOffence formAdd = new FormEditOffence("Add Offence", -1);
            formAdd.ShowDialog();
            this.Close();
        }

        /// <summary>
        /// This method gets the selected offence and allows the user to update the 
        /// data.
        /// </summary>
        private void UpdateOffence()
        {
            try
            {
                //check that the user has selected an offence
                if (listViewOffence.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Please select an offence");
                    return;
                }

                //show offence to be edited.
                this.Hide();
                FormEditOffence edit = new FormEditOffence("Update Offence", OFFENCE_ID_LIST.ElementAt(listViewOffence.FocusedItem.Index));
                edit.ShowDialog();
                this.Close();
            } 
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }
        }

        /// <summary>
        /// Queries the database. The data received is then use to create a new Chart.
        /// </summary>
        /// <param name="query">Query for the database</param>
        /// <param name="name">Name of the chart</param>
        /// <param name="title">Title of the x axis</param>
        private void Statistics(string query, string name, string title)
        {
            try
            {
                List<int> data = new List<int>();
                List<string> labels = new List<string>();

                SQL.SelectQuery(query);

                if (SQL.read.HasRows)
                {
                    while (SQL.read.Read())
                    {
                        string label = SQL.read[0].ToString();

                        //check if there is a value to display
                        if (label == null || label == "")
                        {
                            label = "No Data";
                        }
                        //number of offences
                        int n = int.Parse(SQL.read[1].ToString());

                        data.Add(n);
                        labels.Add(label);
                    }

                    //show a new chart
                    FormChart chart = new FormChart(name, title, labels, data);
                    chart.Show();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }
        }

        /// <summary>
        /// This method displays a form to allow the user to add a new offence
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addOffenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddOffence();
        }

        /// <summary>
        /// Calls UpdateOffence on the selected offence.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void updateOffenceToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            UpdateOffence();
        }

        /// <summary>
        /// Filter offences: without an infringement notice.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void withoutInfringmentNoticeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listViewOffence.Items.Clear();
            GetOffences("SELECT * FROM filter_without_notice");
        }

        /// <summary>
        /// Filter offences: with unpaid infringement notice.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void unpaidInfringementsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listViewOffence.Items.Clear();
            GetOffences("SELECT * FROM filter_unpaid_notice");
        }

        /// <summary>
        /// Filter offences: overdue infringement notice payment.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void overdueInfringementsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listViewOffence.Items.Clear();
            GetOffences("SELECT * FROM filter_overdue_notice");
        }

        /// <summary>
        /// View all the offences
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void allOffencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listViewOffence.Items.Clear();
            GetOffences("SELECT * FROM offence_info");
        }

        /// <summary>
        /// When a list view item is clicked twice, the infringement notice 
        /// corresponding to that notice will display.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            GetNotice(listViewOffence.FocusedItem.Index);
        }

        /// <summary>
        /// Show summary the offences.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void summaryReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSummary summary = new FormSummary();
            summary.Show();
        }

        /// <summary>
        /// Chart: number of lanes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numberOfLanesToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            string query =
                "SELECT l.roadLane, COUNT(*) " +
                "FROM offence o INNER JOIN location l ON o.locationX = l.locationX AND o.locationY = l.locationY " +
                "GROUP BY l.roadLane";

            Statistics(query, "Number of offences affected by: Number of lanes", "Number of Lanes");
        }

        /// <summary>
        /// Chart: speed limit.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void speedLimitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string query =
                "SELECT l.speedLimit, COUNT(*) as num_offence " +
                "FROM offence o INNER JOIN location l ON o.locationX = l.locationX AND o.locationY = l.locationY " +
                "GROUP BY l.speedLimit";

            Statistics(query, "Number of offences affected by: Speed Limit", "Speed Limit (km)");
        }

        /// <summary>
        /// Chart: light condition.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>.
        private void lightConditionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string query =
                "SELECT lightConditions, COUNT(*) as num_offences " +
                "FROM offence " +
                "GROUP BY lightConditions";

            Statistics(query, "Number of offences affected by: Light Conditions", "Light Conditions");
        }

        /// <summary>
        /// Chart: hour of day.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timeOfDayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string query = 
                "SELECT DATEPART(HOUR, o.datetime) as _time, COUNT(*) as num_offence " +
                "FROM offence o " +
                "GROUP BY DATEPART(HOUR, o.datetime)";
            Statistics(query, "Number of offences affected by: Time of Day", "Time (24 hr)");
        }
        
        /// <summary>
        /// Chart: day of week.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dayOfWeekToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string query =
                "SELECT DATENAME(WEEKDAY, o.datetime) as _day, COUNT(*) as num_offence " +
                "FROM offence o " +
                "GROUP BY DATENAME(WEEKDAY, o.datetime) " +
                "ORDER BY " +
                    "CASE " +
                        "WHEN DATENAME(WEEKDAY, o.datetime) = 'Sunday' THEN 1 " +
                        "WHEN DATENAME(WEEKDAY, o.datetime) = 'Monday' THEN 2 " +
                        "WHEN DATENAME(WEEKDAY, o.datetime) = 'Tuesday' THEN 3 " +
                        "WHEN DATENAME(WEEKDAY, o.datetime) = 'Wednesday' THEN 4 " +
                        "WHEN DATENAME(WEEKDAY, o.datetime) = 'Thursday' THEN 5 " +
                        "WHEN DATENAME(WEEKDAY, o.datetime) = 'Friday' THEN 6 " +
                        "WHEN DATENAME(WEEKDAY, o.datetime) = 'Saturday' THEN 7 " +
                    "END ASC";
            Statistics(query, "Number of offences affected by: Day of Week", "Day");
        }

        /// <summary>
        /// Chart: age of driver.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ageOfTheDriverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string query =
                "SELECT DATEDIFF(YY, od.dateOfBirth, GETDATE()), COUNT(*) " +
                "FROM offence oc " +
                "INNER JOIN offender od ON oc.offenderId = od.offenderId " +
                "GROUP BY DATEDIFF(YY, od.dateOfBirth, GETDATE())";

            Statistics(query, "Number of offences affected by: Age of Driver", "Age");
        }

        /// <summary>
        /// Chart: gender of driver.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void genderOfDriverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string query =
                "SELECT od.gender, COUNT(*) " +
                "FROM offence oc " +
                "INNER JOIN offender od ON oc.offenderId = od.offenderId " +
                "GROUP BY od.gender";
            Statistics(query, "Number of offences commited by each Gender", "Gender");
        }

        /// <summary>
        /// Chart: colour of vehicle.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void colourOfTheVehicleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string query =
                "SELECT v.colour, COUNT(*) " +
                "FROM offence o " +
                "INNER JOIN vehicle v ON o.registrationNumber = v.registrationNumber " +
                "GROUP BY v.colour";
            Statistics(query, "Number of offences commited in the same coloured Vehicle", "Colour");
        }

        /// <summary>
        /// Chart: registration year of vehicle.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void registrationYearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string query = 
                "SELECT v.registrationYear, COUNT(*) " +
                "FROM offence o " +
                "INNER JOIN vehicle v ON o.registrationNumber = v.registrationNumber " +
                "GROUP BY v.registrationYear";

            Statistics(query, "Number of offences commited in the same Registration Year", "Year");
        }


        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AddOffence();
        }


        /// <summary>
        /// Calls UpdateOffence.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            UpdateOffence();
        }

        /// <summary>
        /// Calls GetNotice to get the notice for the selected offence.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonView_Click(object sender, EventArgs e)
        {
            if (listViewOffence.SelectedItems.Count > 0)
                GetNotice(listViewOffence.FocusedItem.Index);
            else
                MessageBox.Show(MESSAGE);

        }
    }
}
