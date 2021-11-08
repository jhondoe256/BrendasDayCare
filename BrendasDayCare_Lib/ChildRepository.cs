using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrendasDayCare_Lib
{
    public class ChildRepository
    {
        //this is our fake database...
        private readonly List<Child> _childDb = new List<Child>();
        private int _count;

        //lets use crud
        //C
        public bool AddChild(Child child)
        {
            //see if child exists...
            if (child is null)
            {
                //if not....
                return false;
            }
            //if so....
            //increment count
            _count++;
            //assign _count value to child
            child.ID = _count;
            //Add child to database
            _childDb.Add(child);
            //return true
            return true;
        }
        //See all the children in the database
        //R
        public List<Child> GetChildren()
        {
            return _childDb;
        }
        //See individual child
        //R
        public Child GetChild(int id)
        {
            //I need a for loop to get to this data!!!
            //foreach child inside of _childDB
            foreach (Child child in _childDb)
            {
                //if child.ID is equal to the id value thats passed w/n the method
                if (child.ID==id)
                {
                    //give me that child
                    return child;
                }
            }
            //or return nothing
            return null;
        }
        //U
        public bool UpdateChildData(int id, Child updatedChildData)
        {
            //use helper method to be a child from the database
            var child = GetChild(id);
            //check if child exist...
            if (child != null)
            {
                child.FirstName = updatedChildData.FirstName;
                child.LastName = updatedChildData.LastName;
                return true;
            }
            return false;
        }
        //D
        public bool DeleteChild(int id)
        {
            //foreach child inside of _childDB
            foreach (var child in _childDb)
            {
                //if child.ID is equal to the id value thats passed w/n the method
                if (child.ID==id)
                {
                    //then remove child....
                    _childDb.Remove(child);
                    return true;
                }
            }
            return false;
        }

    }
}
