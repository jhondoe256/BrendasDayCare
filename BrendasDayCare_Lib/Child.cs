using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrendasDayCare_Lib
{
    //1st poco 
    public class Child
    {
        public Child()
        {
        }
        public Child( string fisrstName, string lastName)
        {
            FirstName = fisrstName;
            LastName = lastName;
        }
        //I am the unique identifier....
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
