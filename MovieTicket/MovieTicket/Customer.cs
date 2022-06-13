using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace MovieTicket
{
    public class Customer
    {
        static int ticketAvailable = 10;
        public void movies()
        {
            Console.WriteLine("select the movie you want to see 1.marvel 2.dc 3.avathar 4.don");
            int a=Convert.ToInt32(Console.ReadLine());
            if (a == 1)
            {
                Console.WriteLine("you want to see the movie marvel");
            }
            else if (a == 2)
            {
                Console.WriteLine("you want to see the movie dc");
            }
            else if (a == 3)
            {
                Console.WriteLine("you want to see the movie avathar");
            }
            else if (a == 4)
            {
                Console.WriteLine("you want to see the movie don");
            }
            else
            {
                Console.WriteLine("you did not select any movie");
            }
        }
        public void bookTickets()
        {
            Console.WriteLine("Available tickets:" + ticketAvailable);
            Console.Write("enter how many tickets you want to book, you can book only 10 tickets:");
            int b = Convert.ToInt32(Console.ReadLine());
            ticketAvailable -= b;
            Console.WriteLine("Available tickets after booking:" + ticketAvailable);

        }
        public void cancelTicket()
        {
            Console.WriteLine("enter how many tickets you want to cancel:");
            int c=Convert.ToInt32(Console.ReadLine());
            ticketAvailable += c;
            Console.WriteLine("after cancellation the available  tickets are:" + ticketAvailable);
        }
        public void availableMovies()
        {
            FileStream fileStreamobj = new FileStream(@"D:\CsharpPrograms\MovieTicket\MovieTicket\movies.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fileStreamobj);
            Console.WriteLine("enter the movie name:");
            string name=Console.ReadLine();
            while (sr.Peek() > 0)
            {
                string line = sr.ReadLine();//Moivie name
                if (line != "")
                    if (line.StartsWith("Moivie name"))
                    {
                        string[] myStrs = line.Split(':');

                        Console.WriteLine("\t" + myStrs[1]);
                    }


            }
            sr.Close();
            fileStreamobj.Close();

        }
    }
}
