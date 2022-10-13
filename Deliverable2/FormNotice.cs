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
    public partial class FormNotice : Form
    {
        public FormNotice()
        {
            InitializeComponent();
            GetNotice();
        }

        private void GetNotice()
        {
            //display police logo
            pictureBoxLogo.Image = Image.FromFile("../../Pictures/logo.png");
            pictureBoxLogo.SizeMode = PictureBoxSizeMode.StretchImage;

            //display labels first
            labelNoticeNum.Text = SQL.read[0].ToString();
            labelICN.Text = SQL.read[1].ToString();
            labelName.Text = String.Format("{0} {1}", SQL.read[2].ToString(), SQL.read[3].ToString());
            labelAddress.Text = String.Format("{0}\n{1}\n{2}", SQL.read[4].ToString(), SQL.read[5].ToString(), SQL.read[6].ToString());

            //check if a birth date has been provided
            if (SQL.read[7].ToString() == "")
            {
                labelBirthDate.Text = "No data";
            }
            else
            {
                DateTime dob = Convert.ToDateTime(SQL.read[7].ToString());
                labelBirthDate.Text = dob.ToString("MMMM dd, yyyy");
            }

            //check if the offender has a license
            if (SQL.read[8].ToString() == "") labelDriverLic.Text = "No Drivers License";
            else labelDriverLic.Text = SQL.read[8].ToString();

            //get the date, time and day of week of the offence
            DateTime offence = Convert.ToDateTime(SQL.read[9].ToString());
            labelDate.Text = offence.ToString("dd/MM/yyyy");
            labelTime.Text = String.Format("{0} hrs", offence.ToString("HH:mm"));
            labelDay.Text = offence.ToString("dddd");

            //vehicle and location info
            labelVehicleMake.Text = SQL.read[10].ToString();
            labelRego.Text = SQL.read[11].ToString();
            labelRoad.Text = SQL.read[12].ToString();
            labelLocation.Text = SQL.read[13].ToString();
            labelRegion.Text = SQL.read[14].ToString();
            labelOffence.Text = SQL.read[15].ToString();

            //fees
            richTextBoxfee.Text = String.Format("The infringement fee payable is\n    ${0}", SQL.read[16].ToString());

            DateTime notice = Convert.ToDateTime(SQL.read[17].ToString());
            richTextBoxFeeDate.Text = String.Format("The infringement fee is payable within 28 days after:\n\n    {0}", notice.ToString("dd/MM/yyyy"));

            richTextBoxSpeedLimit.Text = String.Format("Speed Limit:\n    {0}km/h", SQL.read[18].ToString());
            richTextBoxSpeedAlleged.Text = String.Format("Speed Alleged:\n    {0}km/h", SQL.read[19].ToString());
            richTextBoxLimitExceeded.Text = String.Format("Limit Exceeded by:\n    {0}km/h", SQL.read[20].ToString());

            //status of the infringement notice
            if (SQL.read[21].ToString() == "Paid")
            {
                pictureBox1.Image = Image.FromFile("../../Pictures/paid.png");
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            } 
            else
            {
                pictureBox1.Image = Image.FromFile("../../Pictures/unpaid.png");
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
    }
}
