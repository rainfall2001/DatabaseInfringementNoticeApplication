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
    public partial class FormEditOffence : Form
    {
        private List<Location> LOCATIONS;
        private bool OFFENDER_DETAILS = true;
        private bool OFFENCE_DETAILS = true;
        private int OFFENDER_ID = -1;
        private int OFFENCE_ID = -1;
        private string TITLE;

        public FormEditOffence(string title, int id)
        {
            InitializeComponent();

            LOCATIONS = new List<Location>();
            TITLE = title;
            OFFENCE_ID = id;
            SetForm();
        }        

        /// <summary>
        /// Close the form and open the offence form.
        /// </summary>
        private void CloseForm()
        {
            this.Hide();
            FormOffence offence = new FormOffence();
            offence.ShowDialog();
            this.Close();
        }

        /// <summary>
        /// Set up the form from the data in the database.
        /// </summary>
        /// <param name="title">What the form is doing.</param>
        private void SetForm()
        {
            try
            {
                //format the dates
                dateTimePickerBirthDate.Format = DateTimePickerFormat.Custom;
                dateTimePickerBirthDate.CustomFormat = "yyyy-MM-dd";

                dateTimePickerDate.Format = DateTimePickerFormat.Custom;
                dateTimePickerDate.CustomFormat = "dd-MM-yyyy HH:mm:ss";
                //set the date and time of the offence 1 day ahead of today.
                //can be used to check if the user has entered a date and time
                dateTimePickerDate.Value = DateTime.Now.AddDays(1);

                labelTitle.Text = TITLE;

                //fill all the combo box with the data in the database
                SQL.SelectQuery("SELECT v.registrationNumber FROM vehicle v ORDER BY v.registrationNumber ASC");
                if (SQL.read.HasRows)
                {
                    while (SQL.read.Read())
                        comboBoxVehicle.Items.Add(SQL.read[0]);
                }

                SQL.SelectQuery("SELECT DISTINCT icn FROM offence");
                if (SQL.read.HasRows)
                {
                    while(SQL.read.Read())
                        comboBoxICN.Items.Add(SQL.read[0]);
                }

                SQL.SelectQuery("SELECT l.licenseNumber FROM license l ORDER BY l.licenseNumber ASC");
                if (SQL.read.HasRows)
                {
                    while (SQL.read.Read())
                        comboBoxLicNo.Items.Add(SQL.read[0]);
                }

                SQL.SelectQuery("SELECT l.locationX, l.locationY, l.road, l.location FROM location l ORDER BY l.location ASC");
                if (SQL.read.HasRows)
                {
                    while (SQL.read.Read())
                    {
                        int lat = int.Parse(SQL.read[0].ToString());
                        int lon = int.Parse(SQL.read[1].ToString());
                        string road = String.Format("{1}, {0}", SQL.read[2].ToString(), SQL.read[3].ToString());
                        Location l = new Location(lat, lon, road);
                        LOCATIONS.Add(l);
                        comboBoxLocation.Items.Add(road);
                    }
                }
                if (OFFENCE_ID > 0) FillForm();
            } 
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }
        }

        /// <summary>
        /// The method fills out the form if the user has chosen to update a offence
        /// </summary>
        private void FillForm()
        {
            try
            {
                //query the database to get the offence and offender data
                SQL.SelectQuery(String.Format("EXEC get_offence_info {0}", OFFENCE_ID));
                if (SQL.read.HasRows)
                {
                    SQL.read.Read();

                    //display the info
                    OFFENCE_ID = int.Parse(SQL.read[0].ToString());
                    Console.WriteLine(SQL.read[1].ToString());
                    textBoxDescription.Text = SQL.read[1].ToString();
                    textBoxSpeed.Text = SQL.read[2].ToString();
                    dateTimePickerDate.Text = SQL.read[3].ToString();
                    comboBoxICN.SelectedItem = int.Parse(SQL.read[4].ToString());
                    comboBoxLocation.SelectedIndex = LOCATIONS.FindIndex(l => l.Lat == int.Parse(SQL.read[5].ToString()) && l.Lon == int.Parse(SQL.read[6].ToString()));
                    textBoxRain.Text = SQL.read[8].ToString();
                    textBoxLight.Text = SQL.read[9].ToString();
                    textBoxWind.Text = SQL.read[10].ToString();
                    comboBoxVehicle.SelectedItem = SQL.read[11].ToString();

                    OFFENDER_ID = int.Parse(SQL.read[12].ToString());

                    textBoxFirstName.Text = SQL.read[13].ToString();
                    textBoxLastName.Text = SQL.read[14].ToString();
                    dateTimePickerBirthDate.Text = SQL.read[15].ToString();
                    textBoxGender.Text = SQL.read[16].ToString();
                    textBoxPhone.Text = SQL.read[17].ToString();
                    textBoxStreet.Text = SQL.read[18].ToString();
                    textBoxCity.Text = SQL.read[19].ToString();
                    textBoxRegion.Text = SQL.read[20].ToString();
                    comboBoxLicNo.SelectedItem = SQL.read[21].ToString();

                }
                else
                {
                    //something went wrong, reset the offence id so that the form will add a new offence instead
                    MessageBox.Show("There is no valid data.");
                    OFFENCE_ID = -1;
                    labelTitle.Text = "Add Offence";
                }

            }
            catch (Exception ex)
            {
                //something went wrong, reset the offence id so that the form will add a new offence instead
                Console.WriteLine("ERROR:" + ex.Message);
                MessageBox.Show("There is no valid data.");
                OFFENCE_ID = -1;
                labelTitle.Text = "Add Offence";
            }

        }

        /// <summary>
        /// When the form is submitted it will check if all the neccessary fields
        /// has been filled out.
        /// </summary>
        private void CheckForm()
        {
            OFFENCE_DETAILS = true;
            OFFENDER_DETAILS = true;
            errorProvider1.Clear();

            if (string.IsNullOrEmpty(textBoxFirstName.Text)) {
                errorProvider1.SetError(textBoxFirstName, "Please enter First Name");
                OFFENDER_DETAILS = false;
            }

            if (string.IsNullOrEmpty(textBoxStreet.Text)) {
                errorProvider1.SetError(textBoxStreet, "Please enter Street Address");
                OFFENDER_DETAILS = false;
            }

            if (string.IsNullOrEmpty(textBoxCity.Text)) {
                errorProvider1.SetError(textBoxCity, "Please enter City");
                OFFENDER_DETAILS = false;
            }

            if (string.IsNullOrEmpty(textBoxRegion.Text)) {
                errorProvider1.SetError(textBoxRegion, "Please enter Region");
                OFFENDER_DETAILS = false;
            }

            DateTime date = Convert.ToDateTime(dateTimePickerDate.Value);
            if(date >= DateTime.Now) {
                errorProvider1.SetError(dateTimePickerDate, "Please enter Date");
                OFFENCE_DETAILS = false;
            }

            if (string.IsNullOrEmpty(comboBoxLocation.Text)) {
                errorProvider1.SetError(comboBoxLocation, "Please select a Location");
                OFFENCE_DETAILS = false;
            }
            if (string.IsNullOrEmpty(comboBoxVehicle.Text)) {
                errorProvider1.SetError(comboBoxVehicle, "Please select a Vehicle Registration");
                OFFENCE_DETAILS = false;
            }

            try
            {
                if (string.IsNullOrEmpty(textBoxSpeed.Text))
                {
                    errorProvider1.SetError(textBoxSpeed, "Please enter Alleged Speed");
                    OFFENCE_DETAILS = false;
                } else if (int.Parse(textBoxSpeed.Text) <= 0)
                {
                    errorProvider1.SetError(textBoxSpeed, "Alleged Speed not valid");
                    OFFENCE_DETAILS = false;
                }
                if (string.IsNullOrEmpty(comboBoxICN.Text))
                {
                    errorProvider1.SetError(comboBoxICN, "Please enter ICN");
                    OFFENCE_DETAILS = false;
                }
                else if (int.Parse(comboBoxICN.Text) <= 0)
                {
                    errorProvider1.SetError(comboBoxICN, "ICN must be greater than 1.");
                    OFFENCE_DETAILS = false;
                }                
            }
            catch 
            {
                OFFENCE_DETAILS = false;
                MessageBox.Show("Alleged Speed and ICN must only contain numbers");
            }
        }

        /// <summary>
        /// Method will check all the details. If valid, then the data will either be
        /// inserted.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            //validate the form
            CheckForm();
            
            if(OFFENCE_DETAILS && OFFENDER_DETAILS)
            {
                //query the database
                OffenderDetails();
                OffenceDetails();

                //show the offence form
                CloseForm();
            }
            else
            {
                //Show error message to the user
                if(!OFFENDER_DETAILS) MessageBox.Show("Please fill out all the neccessary\nOffender Details.");
                if(!OFFENCE_DETAILS) MessageBox.Show("Please fill out all the neccessary\nOffence Details.");
            }            
        }

        /// <summary>
        /// Queries the database with the data provided.
        /// Either add or updated a offender.
        /// </summary>
        private void OffenderDetails()
        {
            string lastName, dob, gender, phone, licNo;

            if (string.IsNullOrEmpty(textBoxLastName.Text))
                lastName = null;
            else
                lastName = textBoxLastName.Text;

            Console.WriteLine(dateTimePickerBirthDate.Value >= DateTime.Today);
            if (dateTimePickerBirthDate.Value >= DateTime.Today)
                dob = null;
            else
                dob = dateTimePickerBirthDate.Value.ToString("yyyy-MM-dd");
   
            if(string.IsNullOrEmpty(textBoxGender.Text))
                gender = null;
            else
                gender = textBoxGender.Text;

            if(string.IsNullOrEmpty(textBoxPhone.Text))
                phone = null;
            else
                phone = textBoxPhone.Text;

            if(string.IsNullOrEmpty(comboBoxLicNo.Text))
                licNo = null;
            else 
                licNo = comboBoxLicNo.Text;

            string firstName = textBoxFirstName.Text;
            string street = textBoxStreet.Text;
            string city = textBoxCity.Text;
            string region = textBoxRegion.Text;

            //remove possible sql commands
            string[] input = { firstName, lastName, gender, phone, street, city, region, licNo };
            for(int i = 0; i < input.Length; i++)
            {
                if(input[i] != null) input[i] = SQL.CheckString(input[i]);
            }

            try
            {
                //check if the offender details will be added or updated
                if (OFFENDER_ID > 0)
                    SQL.UpdateOffender(OFFENDER_ID, input[0], input[1], dob, input[2], input[3], input[4], input[5], input[6], input[7]);

                else
                {
                    //get the id for the new offender
                    SQL.SelectQuery("SELECT * FROM last_offender_id");
                    if (SQL.read.HasRows)
                    {
                        SQL.read.Read();
                        OFFENDER_ID = int.Parse(SQL.read[0].ToString()) + 1;
                    }
                    else
                        OFFENDER_ID = 1;

                    SQL.AddOffender(OFFENDER_ID, input[0], input[1], dob, input[2], input[3], input[4], input[5], input[6], input[7]);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }
        }

        /// <summary>
        /// Queries the database with the data provided.
        /// Either add or update offence.
        /// </summary>
        private void OffenceDetails()
        {
            string description, rain, light, wind;

            if(string.IsNullOrEmpty(textBoxDescription.Text))
                description = null;
            else
                description = textBoxDescription.Text;

            if(string.IsNullOrEmpty(textBoxRain.Text))
                rain = null;
            else
                rain = textBoxRain.Text;

            if(string.IsNullOrEmpty(textBoxLight.Text))
                light = null;
            else
                light = textBoxLight.Text;

            if(string.IsNullOrEmpty(textBoxWind.Text))
                wind = null;
            else
                wind = textBoxWind.Text;

            int speed = int.Parse(textBoxSpeed.Text);

            DateTime date = Convert.ToDateTime(dateTimePickerDate.Text);
            
            int icn = int.Parse(comboBoxICN.Text);
            int lat = LOCATIONS.ElementAt(comboBoxLocation.SelectedIndex).Lat;
            int lon = LOCATIONS.ElementAt(comboBoxLocation.SelectedIndex).Lon;
            string rego = comboBoxVehicle.Text;

            //remove all possible sql code
            string[] input = { description, rain, light, wind, rego };
            for(int i = 0; i < input.Length; i++)
            {
                if(input[i] != null) input[i] = SQL.CheckString(input[i]);
            }

            try
            {
                //check if offence is being updated or added
                if (OFFENCE_ID > 0)
                    SQL.UpdateOffence(OFFENCE_ID, input[0], speed, date.ToString("yyyy-MM-dd HH:mm:ss"), icn, lat, lon, input[1], input[2], input[3], input[4], OFFENDER_ID);

                else
                {
                    //get id for the offence to be added
                    SQL.SelectQuery("SELECT * FROM last_offence_id");
                    if (SQL.read.HasRows)
                    {
                        SQL.read.Read();
                        OFFENCE_ID = int.Parse(SQL.read[0].ToString()) + 1;
                    }
                    else
                        OFFENCE_ID = 1;

                    SQL.AddOffence(OFFENCE_ID, input[0], speed, date.ToString("yyyy-MM-dd HH:mm:ss"), icn, lat, lon, input[1], input[2], input[3], input[4], OFFENDER_ID);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }
        }

        /// <summary>
        /// OnClick method to close the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            CloseForm();
        }

        /// <summary>
        /// Will display all the contents of the combo box
        /// Source: https://stackoverflow.com/questions/48573024/add-scrollbar-to-winforms-combobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxLocation_DropDown(object sender, EventArgs e)
        {
            ComboBox senderComboBox = (ComboBox)sender;
            int width = senderComboBox.DropDownWidth;
            Graphics g = senderComboBox.CreateGraphics();
            Font font = senderComboBox.Font;
            int vertScrollBarWidth =
                (senderComboBox.Items.Count > senderComboBox.MaxDropDownItems)
                ? SystemInformation.VerticalScrollBarWidth : 0;

            int newWidth;
            foreach (string s in ((ComboBox)sender).Items)
            {
                newWidth = (int)g.MeasureString(s, font).Width
                    + vertScrollBarWidth;
                if (width < newWidth)
                {
                    width = newWidth;
                }
            }
            senderComboBox.DropDownWidth = width;
        }
    }
}
