using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace OrderAssignment
{
    internal class ItemMaster
    {
        public static string sqlConnectionStr = @"Data Source=DESKTOP-CEIJQT1;Initial Catalog=MasterDb;Integrated Security=True";
        SqlConnection Connection = new SqlConnection(sqlConnectionStr);

        public string ItemName;
        Double ItemRate, ItemQty;

        public void AddItem()
        {
        Top:
            try
            {
                Console.WriteLine(" Enter Item Name to Add");
                ItemName = Console.ReadLine();
                Console.WriteLine("Enter Price of Item");
                ItemRate = Double.Parse(Console.ReadLine());
                Console.WriteLine("Enter Quantity Of Item");
                ItemQty = Double.Parse(Console.ReadLine());


                if (ItemName != "")
                {
                    if (!ItemExistOrNot(ItemName))
                    {
                        SqlConnection sqlConnection = new SqlConnection(sqlConnectionStr);
                        string sql = "insert into Item values('" + ItemName + "', " + ItemRate + ", " + ItemQty + ")";
                        SqlDataAdapter adapter = new SqlDataAdapter(sql, Connection);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        Console.WriteLine("Added Succesfully");
                    }

                    else
                    {
                        Console.WriteLine(" This Item Exits Try with another One");
                        goto Top;
                    }
                }

                else
                {
                    Console.WriteLine(" Please Enter the  Value..and try again");
                    goto Top;
                }



            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }

        public void UpdateItem()
        {

        top1:

            if (ItemName != "")
            {

                if (ItemExistOrNot(ItemName))
                {
                    Console.WriteLine(" Enter Item Name to Update");
                    ItemName = Console.ReadLine();
                    Console.WriteLine("Enter Price of Item to Update");
                    ItemRate = Double.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Quantity Of Item to Update");
                    ItemQty = Double.Parse(Console.ReadLine());
                    SqlConnection sqlConnection = new SqlConnection(sqlConnectionStr);//connection establishment
                    string sql = "update Item set Item_Rate=" + ItemRate + " , Item_Qty=" + ItemQty + " where Item_Name= '" + ItemName + "' ";

                    SqlDataAdapter adp = new SqlDataAdapter(sql, Connection);
                    DataTable dataTable = new DataTable();
                    adp.Fill(dataTable);
                    Console.WriteLine("Item Updated Succesfully");

                }

                else
                {
                    Console.WriteLine("Item Does Not Match Please Enter some valid item name");
                    goto top1;
                }
            }

            else
            {
                Console.WriteLine("Please Enter Some Value to update");
                goto top1;
            }


        }


        public void DeleteItem()
        {
        top2:

            Console.WriteLine("Enter the Item Name To be Delete");
            string ItemName = Console.ReadLine();



            if (ItemName == "")

            {
                Console.WriteLine("Enter Some Name");
                goto top2;

            }
            else
            {
                if (ItemExistOrNot(ItemName))
                {
                    SqlConnection sqlConnection = new SqlConnection(sqlConnectionStr);//connection establishment
                    string sql = "delete from Item where Item_Name='" + ItemName + "'";
                    SqlDataAdapter adp = new SqlDataAdapter(sql, Connection);
                    DataTable table = new DataTable();
                    adp.Fill(table);

                    Console.WriteLine();
                    Console.WriteLine();


                    Console.WriteLine("Deleted Succesfully");


                }
                else
                {
                    Console.WriteLine("Please enter a Valid name to delete");
                    goto top2;
                }


            }



        }


        public DataTable ListAllItems()
        {
            SqlConnection sqlConnection = new SqlConnection(sqlConnectionStr);//connection establishment
            string db = sqlConnection.Database;
            string sql = "select * from Item";
            SqlDataAdapter adp = new SqlDataAdapter(sql, Connection);
            DataTable dataTable = new DataTable();
            adp.Fill(dataTable);
            Console.WriteLine("ItemName\tItemRate\tItemQty");
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




        public bool ItemExistOrNot(string ItemName)
        {
            DataTable dataTable = new DataTable();
            string sql = "select * from Item where Item_Name='" + ItemName + "'";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, Connection);
            adapter.Fill(dataTable);
            if (dataTable.Rows.Count > 0)
            {
                return true;
            }

            return false;
        }

    }
}
