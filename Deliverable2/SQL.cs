using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Deliverable2
{
    //Name: Rhane Mercado 
    //Student ID: 1529860
    class SQL
    {
        //generates the connection to the database       
        //Make sure that in the Database connection you put your Database connection here:
        public static SqlConnection con = new SqlConnection(@"Data Source=PLEASE_ADD_YOUR_OWN_SOURCE;Initial Catalog=PLEASE_ADD_DATABASE;Integrated Security=True");
        public static SqlCommand cmd = new SqlCommand();
        public static SqlDataReader read;

        public static void UpdateOffence(int id, string description, int speed, string dateTime, int icn, int lat, int lon, string rain, string light, string wind, string rego, int offenderId)
        {
            SqlCommand cmd = new SqlCommand("UPDATE offence SET " +
                "description = @description, speedAlleged = @speed, dateTime = @dateTime, " +
                "icn = @icn, locationX = @lat, locationY = @lon, rainConditions = @rain, " +
                "lightConditions = @light, windConditions = @wind, registrationNumber = @rego " +
                "WHERE offenceId = @id");

            QueryOffence(false, cmd, id, description, speed, dateTime, icn, lat, lon, rain, light, wind, rego, offenderId);
        }

        public static void AddOffence(int id, string description, int speed, string dateTime, int icn, int lat, int lon, string rain, string light, string wind, string rego, int offenderId)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO offence VALUES (@id, @description, @speed, @dateTime, @icn, " +
                "@lat, @lon, @rain, @light, @wind, @rego, @offenderId)");
            
            QueryOffence(true, cmd, id, description, speed, dateTime, icn, lat, lon, rain, light, wind, rego, offenderId);
        }

        private static void QueryOffence(bool add, SqlCommand cmd, int id, string description, int speed, string dateTime, int icn, int lat, int lon, string rain, string light, string wind, string rego, int offenderId)
        {
            try
            {
                con.Close();
                cmd.Connection = con;
                con.Open();

                SqlParameter prmId = new SqlParameter("@id", SqlDbType.Int);
                SqlParameter prmDescription = new SqlParameter("@description", SqlDbType.VarChar, 100);
                prmDescription.IsNullable = true;
                SqlParameter prmSpeed = new SqlParameter("@speed", SqlDbType.Int);
                SqlParameter prmDateTime = new SqlParameter("@dateTime", SqlDbType.DateTime);
                SqlParameter prmICN = new SqlParameter("@icn", SqlDbType.Int);
                SqlParameter prmLat = new SqlParameter("@lat", SqlDbType.Int);
                SqlParameter prmLon = new SqlParameter("@lon", SqlDbType.Int);
                SqlParameter prmRain = new SqlParameter("@rain", SqlDbType.VarChar, 20);
                prmRain.IsNullable = true;
                SqlParameter prmLight = new SqlParameter("@light", SqlDbType.VarChar, 20);
                prmLight.IsNullable = true;
                SqlParameter prmWind = new SqlParameter("@wind", SqlDbType.VarChar, 20);
                prmWind.IsNullable = true;
                SqlParameter prmRego = new SqlParameter("@rego", SqlDbType.VarChar, 20);
                SqlParameter prmOffenderId = null;

                prmId.Value = id;

                if (description == null) prmDescription.Value = System.DBNull.Value;
                else prmDescription.Value = description;

                prmSpeed.Value = speed;
                prmDateTime.Value = dateTime;
                prmICN.Value = icn;
                prmLat.Value = lat;
                prmLon.Value = lon;

                if (rain == null) prmRain.Value = System.DBNull.Value;
                else prmRain.Value = rain;

                if (light == null) prmLight.Value = System.DBNull.Value;
                else prmLight.Value = light;

                if (wind == null) prmWind.Value = System.DBNull.Value;
                else prmWind.Value = wind;

                prmRego.Value = rego;                

                cmd.Parameters.Add(prmId);
                cmd.Parameters.Add(prmDescription);
                cmd.Parameters.Add(prmSpeed);
                cmd.Parameters.Add(prmDateTime);
                cmd.Parameters.Add(prmICN);
                cmd.Parameters.Add(prmLat);
                cmd.Parameters.Add(prmLon);
                cmd.Parameters.Add(prmRain);
                cmd.Parameters.Add(prmLight);
                cmd.Parameters.Add(prmWind);
                cmd.Parameters.Add(prmRego);                

                if (add)
                {
                    prmOffenderId = new SqlParameter("@offenderId", SqlDbType.Int);
                    prmOffenderId.Value = offenderId;
                    cmd.Parameters.Add(prmOffenderId);
                }

                cmd.ExecuteNonQuery();
            } catch (Exception ex)
            {
                try
                {
                    //delete the offender that has just been added.
                    SQL.ExecuteQuery(String.Format("DELETE FROM offender WHERE offenderId = " + offenderId));
                }
                catch (Exception e)
                {
                    Console.WriteLine("ERROR: " + e.Message);
                }
                Console.WriteLine("ERROR:" + ex.Message);
                MessageBox.Show("Unable to execute command.");
            }
        }


        public static void UpdateOffender(int id, string firstName, string lastName, string dob, string gender, string phone, string street, string city, string region, string license)
        {
            SqlCommand cmd = new SqlCommand("UPDATE offender SET fname = @firstName, lname = @lastName, dateOfBirth = @dob, " +
                "gender = @gender, phone = @phone, streetAddress = @street, cityAddress = @city, " +
                "regionAddress = @region, licenseNumber = @license " +
                "WHERE offenderId = @id");

            QueryOffender(cmd, id, firstName, lastName, dob, gender, phone, street, city, region, license);
        }

        public static void AddOffender(int id, string firstName, string lastName, string dob, string gender, string phone, string street, string city, string region, string license)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO offender VALUES (@id, @firstName, @lastName, @dob, @gender, @phone, @street, @city, @region, @license)");

            QueryOffender(cmd, id, firstName, lastName, dob, gender, phone, street, city, region, license);
        }

        private static void QueryOffender(SqlCommand cmd, int id, string firstName, string lastName, string dob, string gender, string phone, string street, string city, string region, string license)
        {
            try
            {
                con.Close();
                cmd.Connection = con;
                con.Open();

                SqlParameter prmId = new SqlParameter("@id", SqlDbType.Int);
                SqlParameter prmFName = new SqlParameter("@firstName", SqlDbType.VarChar, 100);
                SqlParameter prmLName = new SqlParameter("@lastName", SqlDbType.VarChar, 100);
                prmLName.IsNullable = true;
                SqlParameter prmDob = new SqlParameter("@dob", SqlDbType.Date);
                prmDob.IsNullable = true;
                SqlParameter prmGender = new SqlParameter("@gender", SqlDbType.VarChar, 100);
                prmGender.IsNullable = true;
                SqlParameter prmPhone = new SqlParameter("@phone", SqlDbType.VarChar, 100);
                prmPhone.IsNullable = true;
                SqlParameter prmStreet = new SqlParameter("@street", SqlDbType.VarChar, 100);
                SqlParameter prmCity = new SqlParameter("@city", SqlDbType.VarChar, 100);
                SqlParameter prmRegion = new SqlParameter("@region", SqlDbType.VarChar, 100);
                SqlParameter prmLicense = new SqlParameter("@license", SqlDbType.VarChar, 20);
                prmLicense.IsNullable = true;

                prmId.Value = id;
                prmFName.Value = firstName;

                if (lastName == null) prmLName.Value = System.DBNull.Value;
                else prmLName.Value = lastName;

                if (dob == null) prmDob.Value = System.DBNull.Value;
                else prmDob.Value = dob;

                if (gender == null) prmGender.Value = System.DBNull.Value;
                else prmGender.Value = gender;

                if (phone == null) prmPhone.Value = System.DBNull.Value;
                else prmPhone.Value = phone;

                prmStreet.Value = street;
                prmCity.Value = city;
                prmRegion.Value = region;

                if (license == null) prmLicense.Value = System.DBNull.Value;
                else prmLicense.Value = license;

                cmd.Parameters.Add(prmId);
                cmd.Parameters.Add(prmFName);
                cmd.Parameters.Add(prmLName);
                cmd.Parameters.Add(prmDob);
                cmd.Parameters.Add(prmGender);
                cmd.Parameters.Add(prmPhone);
                cmd.Parameters.Add(prmStreet);
                cmd.Parameters.Add(prmCity);
                cmd.Parameters.Add(prmRegion);
                cmd.Parameters.Add(prmLicense);

                cmd.ExecuteNonQuery();
            } 
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }
        }

        /// <summary>
        /// Generates an SQL query based on the input
        /// query e.g. "SELECT * FROM staff"
        /// </summary>
        /// <param name="query"></param>
        public static void SelectQuery(string query)
        {
            try
            {
                con.Close();
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = query;
                read = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                //put a message box in here if you are recieving errors and see if you can find out why?
                return;
            }
        }

        /// <summary>
        /// This excecutres the query, used mainly for 
        /// insert/delete/update statements etc. where we don't need
        /// to read from what we are doing.
        /// </summary>
        /// <param name="query"></param>
        public static void ExecuteQuery(string query)
        {
            //try catch to catch any unforseen errors gracefully
            try
            {
                con.Close();
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //put a message box in here if you are recieving errors and see if you can find out why?
                Console.WriteLine("ERROR: " + ex.Message);
                return;
            }
        }

        /// <summary>
        /// Checks for possible sql commands and replaces them with an empty string.
        /// </summary>
        /// <param name="input">String to check</param>
        /// <returns></returns>
        public static string CheckString(string input)
        {
            string[] commands = { "select", "update", "delete", "insert", "into", "value", "table", "from", "create", "database", "alter", "drop", "index", "--", "%", "=", "from" };
            
            //remove *
            input = input.Replace("*", "");

            for (int i = 0; i < commands.Length; i++)
                input = Regex.Replace(input, commands[i], "", RegexOptions.IgnoreCase);

            if (String.IsNullOrWhiteSpace(input))
                return null;
            else
                return input;
        }
    }
}
