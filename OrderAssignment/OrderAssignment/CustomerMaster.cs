using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Net.Mail;
using System.Net;

namespace OrderAssignment
{
    internal class CustomerMaster
    {
        public static string sqlConnectionStr = @"Data Source=DESKTOP-CEIJQT1;Initial Catalog=MasterDb;Integrated Security=True";
        SqlConnection Connection = new SqlConnection(sqlConnectionStr);
        string FName, LName, Email;
        int Phone;


        public void AddCustomer()
        {

        Add:

            Console.WriteLine(" Enter Customer's First Name to Add");
            FName = Console.ReadLine();

            Console.WriteLine(" Enter Customer's Last Name to Add");
            LName = Console.ReadLine();

            Console.WriteLine(" Enter Customer's Phone No to Add");
            Phone = int.Parse(Console.ReadLine());


        email:

            Console.WriteLine(" Enter Email to Add");
            Email = Console.ReadLine();

            if (!mailValidation(Email))

            {
                Console.WriteLine("Enter Some Valid  Email");
                goto email;

            }
            if (FName != "" && LName != "" && Email != "")
            {
                if (!CustomerExistOrNot(Email) && mailValidation(Email))
                {
                    SqlConnection sqlConnection = new SqlConnection(sqlConnectionStr);
                    string sql = "insert into Customer values('" + FName + "','" + LName + "', " + Phone + ", '" + Email + "')";
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, Connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    Console.WriteLine("Added Succesfully");

                    emailsend(Email, FName, LName);




                }
                else
                {
                    Console.WriteLine("Please enter a Valid Email..it Already Exits");
                }


            }


            else
            {
                Console.WriteLine("Please enter  Email..It can't be null");
            }





        }


        public void UpdateCustomer()
        {
        Update:

            Console.WriteLine(" Enter Customer's First Name to Add");
            FName = Console.ReadLine();

            Console.WriteLine(" Enter Customer's Last Name to Add");
            LName = Console.ReadLine();

            Console.WriteLine(" Enter Customer's Phone No to Add");
            Phone = int.Parse(Console.ReadLine());


        email1:

            Console.WriteLine(" Enter Email to Add");
            Email = Console.ReadLine();

            if (!mailValidation(Email))

            {
                Console.WriteLine("Enter Some   Email..It can not be null");
                goto email1;

            }
            if (Email != "")
            {
                if (!CustomerExistOrNot(Email) && mailValidation(Email))
                {
                    SqlConnection sqlConnection = new SqlConnection(sqlConnectionStr);
                    string sql = "update Item set Customer_Fname='" + FName + "' ,  Customer_Lname='" + LName + "' , Customer_Phone=" + Phone + " where Customer_Email= '" + Email + "' ";
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, Connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    Console.WriteLine("Updated Succesfully");


                }
                else
                {
                    Console.WriteLine("Please enter a Valid Email..it Already Exits");
                    goto Update;
                }


            }


            else
            {
                Console.WriteLine("Please enter  Email..It can't be null");
                goto Update;
            }





        }

        public void DeleteCustomer()
        {
        top2:

            Console.WriteLine("Enter the Email To be Delete");
            string Email = Console.ReadLine();



            if (Email == "")

            {
                Console.WriteLine("Enter Some Email..");
                goto top2;

            }
            else
            {
                if (CustomerExistOrNot(Email))
                {
                    SqlConnection sqlConnection = new SqlConnection(sqlConnectionStr);//connection establishment
                    string sql = "delete from Customer where Customer_Email='" + Email + "'";
                    SqlDataAdapter adp = new SqlDataAdapter(sql, Connection);
                    DataTable table = new DataTable();
                    adp.Fill(table);

                    Console.WriteLine();
                    Console.WriteLine();


                    Console.WriteLine("Deleted Succesfully");


                }
                else
                {
                    Console.WriteLine("Please enter a Valid Email to delete");
                    goto top2;
                }



            }
        }

        public DataTable ListAllCustomers()
        {
            SqlConnection sqlConnection = new SqlConnection(sqlConnectionStr);//connection establishment
            string db = sqlConnection.Database;
            string sql = "select * from Customer";
            SqlDataAdapter adp = new SqlDataAdapter(sql, Connection);
            DataTable dataTable = new DataTable();
            adp.Fill(dataTable);
            Console.WriteLine("FirstName\tLastname\tPhone\t\tEmail");
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                for (int j = 0; j < dataTable.Columns.Count; j++)
                {
                    Console.Write(dataTable.Rows[i][j] + "\t\t");
                }
                Console.WriteLine();
            }
            return dataTable;


        }

        public bool mailValidation(string Email)
        {

            Regex eml = new Regex(@"^[a-zA-Z]+[._]{0,1}[0-9a-zA-Z]+[@][a-zA-Z]+[.][a-zA-Z]{2,3}([.]+[a-zA-Z]{2,3}){0,1}");
            Match m = eml.Match(Email);
            if (m.Success)
            {
                return true;

            }
            else
            {
                return false;
            }

        }
        public bool CustomerExistOrNot(string Email)
        {
            DataTable dataTable = new DataTable();
            string sql = "select * from Customer where Customer_Email='" + Email + "'";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, Connection);
            adapter.Fill(dataTable);
            if (dataTable.Rows.Count > 0)
            {
                return true;
            }

            return false;
        }

        void emailsend(string to, string firstname, string lastname)
        {
            string from = "swati15091999@gmail.com";
            string password = "etrytsqbiphzttyg";
            string subject = "Welcome Dear Customer";
            string body = "<h1>Dear, " + firstname + " " + lastname + " </h1>\nThanks for registering with us..Have a good day";
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress(from);
                message.To.Add(new MailAddress(to));
                message.Subject = subject;
                message.IsBodyHtml = true; //to make message body as html  
                message.Body = body;
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com"; //for gmail host  
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(from, password);
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
                Console.WriteLine("Mail Sent Succesfully");





            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
}
