using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement
{
    public class Program
    {
        static void Main(string[] args)
        {
            Libraian obj=new Libraian();
            obj.userDetails();
            obj.bookDetails();
            obj.bookIssue();
            obj.manageInventory();
            
           // Console.ReadLine();
        }
    }
}
