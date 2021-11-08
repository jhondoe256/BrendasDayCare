using BrendasDayCare_Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrendasDayCare
{
    public class Program_UI
    {
        //we need to use our repositories....
        private readonly ChildRepository _childRepo = new ChildRepository();
        private readonly TeacherRepository _teachRepo = new TeacherRepository();

        public void Run()
        {
            Seed();
            RunApplication();
        }

        private void RunApplication()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("Welcome to Brendas Day Care!\n" +
                                 "1.Add a child\n" +
                                 "2.View children\n" +
                                 "3.View child by Id\n" +
                                 "4.Update existing child data\n" +
                                 "5.Delete existing Child data\n" +
                                 "------------------------------------\n" +
                                 "6.Add A Teacher\n" +
                                 "7.View All Teachers\n" +
                                 "8.View Teacher by Id\n" +
                                 "9.Update existing Teacher\n" +
                                 "10.Delete existing Teacher\n" +
                                 "-------------------------------------\n" +
                                 "50. Close Application\n");

                var userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        AddChild();
                        break;
                    case "2":
                        ViewChildren();
                        break;
                    case "3":
                        ViewChildByID();
                        break;
                    case "4":
                        UpdateChildData();
                        break;
                    case "5":
                        DeleteChild();
                        break;
                    case "6":
                        AddTeacher();
                        break;
                    case "7":
                        ViewAllTeachers();
                        break;
                    case "8":
                        ViewTeachersById();
                        break;
                    case "9":
                        UpdateTeacherData();
                        break;
                    case "10":
                        DeleteTeacher();
                        break;
                    case "50":
                        isRunning = false;
                        Console.WriteLine("Thanks.Press any key to continue....");
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("Invalid selection, Press any key to continue\n");
                        Console.ReadKey();
                        break;
                }
                Console.Clear();
            }
        }

        private void AddChild()
        {
            Console.Clear();
            Child child = new Child();

            Console.WriteLine("Please input the childs first name:");
            var userInputChildNameF = Console.ReadLine();
            child.FirstName = userInputChildNameF;

            Console.WriteLine("Please input the childs last name:");
            var userInputChildNameL = Console.ReadLine();
            child.FirstName = userInputChildNameL;

            //add this guy...
            bool isSuccessfull = _childRepo.AddChild(child);
            if (isSuccessfull)
            {
                Console.WriteLine("Success");
            }
            else
            {
                Console.WriteLine("Failure!");
            }

            Console.ReadKey();
        }

        private void ViewChildren()
        {
            Console.Clear();
            //need to see all of the children in the database
            List<Child> children = _childRepo.GetChildren();

            //loop through each child
            foreach (var child in children)
            {
                DisplayChildData(child);
            }

            Console.ReadKey();
        }

        //helper methodA:
        private void DisplayChildData(Child child)
        {
            Console.WriteLine($"ChildID: {child.ID}\n" +
                              $"ChildName: {child.FirstName} {child.LastName}\n" +
                              $"-----------------------------------\n");
        }

        private void ViewChildByID()
        {
            Console.Clear();
            Console.WriteLine("Please input child Id:");
            var userInputChildID = int.Parse(Console.ReadLine());

            var child = _childRepo.GetChild(userInputChildID);
            if (child != null)
            {
                DisplayChildData(child);
            }
            else
            {
                Console.WriteLine("No child Found");
            }


            Console.ReadKey();
        }

        private void UpdateChildData()
        {
            Console.Clear();
            Console.WriteLine();
            
            Console.WriteLine("Please input child Id:");
            var userInputChildID = int.Parse(Console.ReadLine());

            var child = _childRepo.GetChild(userInputChildID);
            if (child != null)
            {
                Console.Clear();
                Child updatedChildData = new Child();

                Console.WriteLine("Please input the childs first name:");
                var userInputChildNameF = Console.ReadLine();
                updatedChildData.FirstName = userInputChildNameF;

                Console.WriteLine("Please input the childs last name:");
                var userInputChildNameL = Console.ReadLine();
                updatedChildData.FirstName = userInputChildNameL;

                var isSuccess = _childRepo.UpdateChildData(userInputChildID, updatedChildData);

                if (isSuccess)
                {
                    Console.WriteLine("Success!");
                }
                else
                {
                    Console.WriteLine("Failure!");
                }
            }
            else
            {
                Console.WriteLine("Child is not in the database.");
            }

            Console.ReadKey();
        }

        private void DeleteChild()
        {
            Console.Clear();

            Console.WriteLine("Please input child Id:");
            var userInputChildID = int.Parse(Console.ReadLine());

            var child = _childRepo.GetChild(userInputChildID);
            if (child != null)
            {
               bool success= _childRepo.DeleteChild(userInputChildID);
                if (success)
                {
                    Console.WriteLine($"{child.FirstName} {child.LastName} was deleted.");
                }
                else
                {
                    Console.WriteLine($"{child.FirstName} {child.LastName} was NOT deleted.");
                }
            }
            else
            {
                Console.WriteLine("The child was not in the database.");
            }

                Console.ReadKey();
        }

        private void AddTeacher()
        {
            
        }

        private void ViewTeachersById()
        {
            throw new NotImplementedException();
        }

        private void ViewAllTeachers()
        {
            throw new NotImplementedException();
        }

        private void UpdateTeacherData()
        {
            throw new NotImplementedException();
        }

        private void DeleteTeacher()
        {
            throw new NotImplementedException();
        }

        private void Seed()
        {
            var childA = new Child("Bobby", "Wolmack");
            var childB = new Child("Lil", "Wayne");
            var childc = new Child("Juelz", "Santana");

            //this adds children to the child repo
            _childRepo.AddChild(childA);
            _childRepo.AddChild(childB);
            _childRepo.AddChild(childc);
            
            var teacher = new Teacher("Terry","Brown");
            teacher.Students.Add(childc);
            teacher.Students.Add(childB);
            teacher.Students.Add(childA);

            //this adds the newly created teacher to the teacher repo
            _teachRepo.AddTeacher(teacher);


        }

    }
}
