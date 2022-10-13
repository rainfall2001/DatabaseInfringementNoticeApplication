using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Deliverable2
{
    public partial class FormSummary : Form
    {
        string[] dayOfWeek = { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };

        public FormSummary()
        {
            InitializeComponent();
            GetReport();
        }

        private void GetReport()
        {
            try
            {
                //query the database to get the data
                int numOffences = (int) GetData("SELECT COUNT(offenceId) FROM offence");
                double sumAmount = GetData("SELECT SUM(amount) FROM infringementNotice");
                int avgExceed = (int) GetData("SELECT AVG(o.speedAlleged - l.speedLimit) FROM offence o INNER JOIN location l ON o.locationX = l.locationX AND o.locationY = l.locationY");
                List<Pairs> dates = GetDataPair(
                    "SELECT CAST(o.dateTime AS DATE) AS _date, COUNT(o.dateTime) AS num_offence " +
                    "FROM offence o " +
                    "GROUP BY CAST(o.dateTime AS DATE) " +
                    "HAVING COUNT(o.dateTime) = ( " +
                        "SELECT MAX(num_offence) AS num_offence " +
                        "FROM( SELECT COUNT(o.dateTime) AS num_offence, CAST(o.dateTime AS DATE) AS _date " +
                        "FROM offence o " +
                        "GROUP BY CAST(o.dateTime AS DATE)) AS _table) " +
                    "ORDER BY _date ASC");

                List<Pairs> days = GetDataPair(
                    "SELECT DATEPART(WEEKDAY, o.datetime) as _day, COUNT(o.dateTime) AS num_offence " +
                    "FROM offence o " +
                    "GROUP BY DATEPART(WEEKDAY, o.datetime) " +
                    "HAVING COUNT(o.dateTime) = ( " +
                        "SELECT MAX(num_offence) AS num_offence " +
                        "FROM( SELECT COUNT(o.dateTime) AS num_offence, DATEPART(WEEKDAY, o.datetime) as _day " +
                        "FROM offence o " +
                        "GROUP BY DATEPART(WEEKDAY, o.datetime)) AS _table) " +
                    "ORDER BY _day ASC");

                DisplayData(numOffences, sumAmount, avgExceed, dates, days);
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }
        }

        private void DisplayData(int numOffences, double sumAmount, int avgExceed, List<Pairs> dates, List<Pairs> days)
        {
            richTextBox1.Text = String.Format("The number of recorded offences: {0}\n\n" +
                "Total ammount of infringement fees: ${1}\n\n" +
                "Average exceeded limit: {2} km/hr\n\n", numOffences, sumAmount, avgExceed);

            richTextBox1.Text = richTextBox1.Text + dates.ElementAt(0).Value + " offences was the highest recorded number of offences committed in a day.Dates include:\n";
            for (int i = 0; i < dates.Count; i++)
            {
                DateTime d = Convert.ToDateTime(dates.ElementAt(i).Key);
                richTextBox1.Text = richTextBox1.Text + String.Format("        {0}\n", d.ToString("dd/MM/yyyy"));
            }

            richTextBox1.Text = richTextBox1.Text + "\nThe day(s) that most offences occured on:\n";
            for (int i = 0; i < days.Count; i++)
            {
                richTextBox1.Text = richTextBox1.Text + String.Format("    {0}\n", dayOfWeek[(int.Parse(days.ElementAt(i).Key)) - 1]);
            }
        }

        private double GetData(String query)
        {
            try
            {
                SQL.SelectQuery(query);
                if (SQL.read.HasRows)
                {
                    SQL.read.Read();
                    Console.WriteLine(SQL.read[0].ToString());
                    return double.Parse(SQL.read[0].ToString());
                }
                return -1;

            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
                return -1;
            }
        }

        private List<Pairs> GetDataPair(String query)
        {
            try
            {
                List<Pairs> pairs = new List<Pairs>();
                SQL.SelectQuery(query);
                if (SQL.read.HasRows)
                {
                    while (SQL.read.Read())
                    {
                        string key = SQL.read[0].ToString();
                        int value = int.Parse(SQL.read[1].ToString());
                        Pairs pair = new Pairs(key, value);
                        pairs.Add(pair);
                    }
                    return pairs;
                }
                return null;
            } 
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
                return null;
            }
        }
    }
}
