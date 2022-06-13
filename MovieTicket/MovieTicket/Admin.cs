using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;
using System.Threading.Tasks;

namespace MovieTicket
{
    public class Admin
    {
        public void addmovies()
        {
            string movie_name;
            string Timings;
            int seats;
            Console.WriteLine("enter the movie name:");
            movie_name = Console.ReadLine();
            Console.WriteLine("enter the movie timings:");
            Timings =Console.ReadLine();
            Console.WriteLine("enter the how many seats available:");
            seats = Convert.ToInt32(Console.ReadLine());
            List<object> admins = new List<object>
            {movie_name,Timings,seats};

            FileStream fs = new FileStream(@"D:\CsharpPrograms\MovieTicket\MovieTicket\movies.txt", FileMode.Append, FileAccess.Write);
            StreamWriter streamWriter = new StreamWriter(fs);
            streamWriter.WriteLine();
            streamWriter.WriteLine("Moivie name:" + admins[0]);
            streamWriter.WriteLine("Timings:" + admins[1]);
            streamWriter.WriteLine("Seats:" + admins[2]);
            streamWriter.Close();
            fs.Close();

        }
    }
}
