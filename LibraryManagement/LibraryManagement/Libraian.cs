using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace LibraryManagement
{
    public class Libraian:User
    {
       
        public void addnewBook()
        {
            FileStream fileStreamobj = new FileStream(@"D:\CsharpPrograms\LibraryManagement\LibraryManagement\bookDetails.txt", FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fileStreamobj);
            sw.WriteLine();
            Console.Write("Enter The Book Id:");
            int id = Convert.ToInt32(Console.ReadLine());
            sw.WriteLine("book id:"+id);

            Console.Write("Enter The Book name:");
            string bookname = Console.ReadLine();
            sw.WriteLine("bookname:" + bookname);

            Console.Write("Enter The Book Author Name:");
            string authorName = Console.ReadLine();
            sw.WriteLine("authorName:" + authorName);
            sw.Close();
            fileStreamobj.Close();


        }
        public void manageInventory()
        {
            FileStream fileStreamobj = new FileStream(@"D:\CsharpPrograms\LibraryManagement\LibraryManagement\manageInventory.txt", FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fileStreamobj);
            sw.WriteLine("Available books in Library");
            for (int i = 0; i < book.Length; i++)
            {
                sw.WriteLine(book[i]);
                sw.WriteLine("\n");
            }
            sw.WriteLine("bookdetails");
            for (int i = 0; i < 7; i++)
            {
                sw.WriteLine(user[i]);
                sw.WriteLine("\n");
            }
            sw.WriteLine("user details");
            sw.Close();
            fileStreamobj.Close();
     
        }



    }

}
