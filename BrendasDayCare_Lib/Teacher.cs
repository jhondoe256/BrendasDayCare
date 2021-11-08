using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrendasDayCare_Lib
{
    public class Teacher
    {
        public Teacher()
        {
        }
        public Teacher( string firstName, string lastName)
        {
           
            FirstName = firstName;
            LastName = lastName;
        }
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName{ get; set; }
        public List<Child> Students { get; set; } = new List<Child>();
    }
}
