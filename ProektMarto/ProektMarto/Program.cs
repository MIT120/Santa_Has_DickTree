using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProektMarto
{
    class Program
    {
       
        static void Main(string[] args)
        {
            Methods m = new Methods();
            m.SplitStringToList();
            m.Update();
            m.Display();

            Console.ReadLine();
             
        }
    }
}
