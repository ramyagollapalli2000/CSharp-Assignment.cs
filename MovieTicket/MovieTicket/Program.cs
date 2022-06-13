using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket
{
    public class Program
    {
        static void Main(string[] args)
        {
            Customer obj=new Customer();
            Admin obj1=new Admin();
            obj1.addmovies();
            obj.availableMovies();
            //obj.movies();
            //obj.bookTickets();
            //obj.cancelTicket(); 
        }
    }
}
