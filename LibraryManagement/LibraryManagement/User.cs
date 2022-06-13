using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace LibraryManagement
{
    public class User
    {
        public string[] user = new string[7];
        public string[] book = new string[7];
        int fee = 20;
        public void userDetails()
        {
            FileStream fileStreamobj = new FileStream(@"D:\CsharpPrograms\LibraryManagement\LibraryManagement\userDetails.txt", FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fileStreamobj);
            
            user[0] = "user id:201" + "\n" + "username:lokesh" + "\n" + "branch:cse";
            user[1] = "user id:202" + "\n" + "username:Ravi" + "\n" + "branch:eee";
            user[2] = "user id:203" + "\n" + "username:shyam" + "\n" + "branch:ece";
            user[3] = "user id:204" + "\n" + "username:teja" + "\n" + "branch:cse";
            user[4] = "user id:205" + "\n" + "username:jafar" + "\n" + "branch:civil";
            for (int i = 0; i < user.Length; i++)
            {
                sw.WriteLine(user[i]);
                sw.WriteLine("\n");
            }
            sw.Close();
            fileStreamobj.Close();

        }
        public void bookDetails()
        {
            FileStream fileStreamobj = new FileStream(@"D:\CsharpPrograms\LibraryManagement\LibraryManagement\bookDetails.txt", FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fileStreamobj);
            
            book[0] = "book id:501"+ "\n" + "bookname:java" + "\n" + "authorName:james gosling";
            book[1] = "book id:502" + "\n" + "bookname:c#" + "\n" + "authorName:microsoft";
            book[2] = "book id:503" + "\n" + "bookname:html" + "\n" + "authorName:w3c";
            book[3] = "book id:504" + "\n" + "bookname:python" + "\n" + "authorName:guido";
            book[4] = "book id:505" + "\n" + "bookname:react" + "\n" + "authorName:abc";
            for (int i = 0; i < book.Length; i++)
            {
                sw.WriteLine(book[i]);
                sw.WriteLine("\n");
            }
            sw.Close();
            fileStreamobj.Close();

        }
        public void bookIssue()
        {
            FileStream fileStreamobj = new FileStream(@"D:\CsharpPrograms\LibraryManagement\LibraryManagement\bookIssue.txt", FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fileStreamobj);
            Console.WriteLine("enter the book name you want(java/c#/python/html/react):");
            string search=Console.ReadLine();
            for (int i = 0; i < 5; i++)
            {
                if (book[i].Contains(search))
                {
                    sw.WriteLine(book[i]);
                    Console.WriteLine("enter user id starts with 200 series:");
                    sw.WriteLine();
                    string b=Console.ReadLine();
                    for (int j = 0; j < 5; j++)
                    {
                        if (user[j].Contains(b))
                        {
                            sw.WriteLine(user[i]);
                            string issueDate = DateTime.Now.ToShortDateString();
                            sw.WriteLine("issueDate:" + issueDate);
                            string returndate = "5-May-22";
                            DateTime dt1 = Convert.ToDateTime(returndate);
                            DateTime dt2 = Convert.ToDateTime(issueDate);
                            var d = dt2 - dt1;
                            Console.WriteLine(d.Days);
                            int e = d.Days * fee;
                            sw.WriteLine("Library fee:"+e);

                        }

                    }
                    
                }
            }
            sw.Close ();
            fileStreamobj.Close ();
        }
        /*public void returnAbook()
        {
            FileStream fileStreamobj = new FileStream(@"D:\CsharpPrograms\LibraryManagement\LibraryManagement\bookIssue.txt", FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fileStreamobj);
            sw.WriteLine();
            Console.WriteLine("enter the returned book details:");
            string bookname=Console.ReadLine();
            sw.WriteLine("return book:"+bookname);
            Console.WriteLine("enter the return date in the format of dd-Jan-yy");
            string date=Console.ReadLine();
            sw.WriteLine ("return date:"+date);

           /* string dt=DateTime.Now.ToShortDateString();
            string returndate = "5-May-22";
            DateTime dt1=Convert.ToDateTime(returndate);
            DateTime dt2=Convert.ToDateTime(dt);
            var d=dt2-dt1;
            Console.WriteLine(d.Days);*/

            /*sw.Close();
            fileStreamobj.Close();

        }*/


    }
}
