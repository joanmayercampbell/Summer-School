using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerSchool
{
    class Program
    {
        static int MaxStudents = 15;
        static string[] Students = new string[MaxStudents];
        static int[] Fees = new int[MaxStudents];
        

        static int DisplayMenuGetInput()
        {
            Console.Clear();

            PrintStudents();

            int menuChoice = 0;

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
          
            if (NumOfEnrolled() < 15)
            {
                Console.WriteLine("1 - Enroll a student");
            }
            
            if (NumOfEnrolled() > 0)
            {
                Console.WriteLine("2 - Unenroll a student");
            }
            
            Console.WriteLine("3 - Print list of enrolled students");
            Console.WriteLine("4 - Exit");
            Console.WriteLine("");
            Console.WriteLine("Enter option:");

            menuChoice = Convert.ToInt32(Console.ReadLine());
            return menuChoice;
        }

        static void EnrollStudent()
        {

            string studentsName = null;

            //prompt for students name
            Console.Clear();
            Console.WriteLine("STUDENT ENROLLMENT");
            Console.WriteLine("");
            Console.WriteLine("");

            // display current list of students
            PrintStudents();

            Console.WriteLine("");
            Console.WriteLine("");


            Console.WriteLine("Please enter new student's name: ");
            studentsName = Console.ReadLine();

            if (studentsName.Contains("Malfoy"))
            {
                Console.WriteLine("Can not enroll {0} ", studentsName);
                return;
            }

            //enter the new students name in the last available position
            int newStudent = NumOfEnrolled();
            int newFee = 200;

            Students[newStudent] = studentsName;

            // check for special fee conditions
            if (studentsName.Contains("Potter"))
            {
                newFee = 100;
            }

            if (studentsName.Contains("Tom") || studentsName.Contains("Riddle") || studentsName.Contains("Voldemort"))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("RED ALERT!!! HE WHO MUST NOT BE NAMED.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
            }

            

            var firstLastName = studentsName.Split(' ');
            string firstName = firstLastName[0];
            string lastName = firstLastName[1];
            if (firstName.First() == lastName.First())
            {
                newFee = 180;
            }

            if (studentsName.Contains("Longbottom"))
            {
                if (NumOfEnrolled() < 10)
                {
                    newFee = 0;
                }

            }

            Fees[newStudent] = newFee;
                        
            return;
        }

        static void UnenrollStudent()
        {
            int studentsNumber = 0;
            string[] tempStudents = new string[MaxStudents];
            int[] tempFees = new int[MaxStudents];

            //prompt for students name
            Console.Clear();
            Console.WriteLine("STUDENT UNENROLLMENT");
            Console.WriteLine("");
            Console.WriteLine("");

            // display current list of students
            PrintStudents();

            Console.WriteLine("");
            Console.WriteLine("");

            Console.WriteLine("Enter the student's number you want to unenroll: ");
            studentsNumber = Convert.ToInt32(Console.ReadLine());
            studentsNumber--;  

            // write out confirmation
            Console.WriteLine("Student : {0}  has been unenrolled. ", Students[studentsNumber]);

            // take out students name from the enrollment list
            Students[studentsNumber] = null;

            //variable to manage the tempStudent array           
            int j = 0;

            // pack the array
            for (int i = 0;i <= NumOfEnrolled();i++)     
            {
                if (Students[i] != null)
                {
                    tempStudents[j] = Students[i];
                    tempFees[j] = Fees[i];
                    j++;
                }
                    
                
            }

            // copy all of the tempStudent array into the Students array
            for (int i=0;i< NumOfEnrolled();i++)
            {
                Students[i] = tempStudents[i];
                Fees[i] = tempFees[i];
            }

            Console.ReadKey();
                

            return;
        }

        static void PrintStudents()
        {
            Console.WriteLine("SUMMER SCHOOL ENROLLMENT SYSTEM");


            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Current Enrollment Rooster");
            Console.WriteLine("--------------------------");

            // if there are no students
            if (NumOfEnrolled() ==0)
            {
                Console.WriteLine("* no students enrolled! *");
                Console.WriteLine("-------------------------");
                return;
            }

            int sumOfFees = 0;

            for (int i=0;i < NumOfEnrolled();i++)
            {
                Console.Write("{0}  {1}   ", i+1, Students[i]);
                if (Fees[i] != 200)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                Console.WriteLine("{0}", Fees[i]);
                Console.ForegroundColor = ConsoleColor.White;
                sumOfFees = sumOfFees + Fees[i];

            }

            Console.WriteLine("");
            Console.WriteLine("");

            Console.WriteLine("Total fees due: {0}", sumOfFees);
            return;
        }

        static int NumOfEnrolled()
        { 
       
            int numberOfStudents = 0;
            for (int i = 0; i < Students.Length; i++) 
            {
                if(Students[i] != null)
                    {
                    numberOfStudents++;
                }
            }
            return numberOfStudents;
        }


        static void Main(string[] args)
        {
            int menuChoice = 0;

            while (menuChoice !=4)
            {
                menuChoice = DisplayMenuGetInput();

                if (menuChoice == 1)
                {
                    EnrollStudent();
                }

                if (menuChoice == 2)
                {
                    UnenrollStudent();
                }

                if (menuChoice == 3)
                {
                    PrintStudents(); 
                }

                if (menuChoice == 4)
                {
                    continue;
                }

                if (menuChoice > 5 || menuChoice < 1)
                {
                    Console.WriteLine("Please enter a number from 1 - 4 ");
                    Console.ReadKey();
                    continue;
                }
                    
            }
            
           
            //Console.ReadKey();

        }
    }
}
