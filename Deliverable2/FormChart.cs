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
using System.Windows.Forms.DataVisualization.Charting;

namespace Deliverable2
{
    public partial class FormChart : Form
    {
        private string name = "";
        private string title = "";
        private List<string> labels;
        private List<int> data;

        public FormChart(string name, string title, List<string> labels, List<int> data)
        {
            InitializeComponent();
            label1.Left = (this.ClientSize.Width - label1.Size.Width) / 2;
            chartTypeComboBox.Left = (this.ClientSize.Width - chartTypeComboBox.Size.Width) / 2;
            chartGraph.Left = (this.ClientSize.Width - chartGraph.Size.Width) / 2;
            this.name = name;
            this.title = title;
            this.labels = labels;
            this.data = data;
            initChart();

        }

        private void initChart()
        {
        
            string chart_type_strng = (string)((ComboBox)this.Controls["chartTypeComboBox"]).SelectedItem;
            if (chart_type_strng == null)
            {
                chart_type_strng = "Line";
            }
            SeriesChartType chartType = (SeriesChartType)Enum.Parse(typeof(SeriesChartType), chart_type_strng);

            Chart chart = (Chart)this.Controls["chartGraph"];
        

            chart.Series.Clear();
            chart.Titles.Clear();
            
            chart.Titles.Add(name);
            chart.ChartAreas["ChartArea"].AxisX.Title = title; 
            chart.ChartAreas["ChartArea"].AxisX.Interval = 1;
            chart.ChartAreas["ChartArea"].AxisX.MajorGrid.LineWidth = 0;

            Series series = new Series("Offences");
            series.ChartType = chartType;

            for (int i = 0; i < labels.Count; i++)
            {
                series.Points.AddXY(labels.ElementAt(i), data.ElementAt(i));

            }
            chart.Series.Add(series);

        }

        private void chartTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            initChart();
        }
    }
}
