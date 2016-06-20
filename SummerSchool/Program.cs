using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerSchool
{
    class Program
    {
        static string[] Students = new string[15];
        static int[] Fees = new int[15];

        static int DisplayMenuGetInput()
        {
            Console.Clear();

            PrintStudents();

            int menuChoice = 0;

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("SUMMER SCHOOL ENROLLMENT SYSTEM");
            Console.WriteLine("");
            Console.WriteLine("1 - Enroll a student");
            Console.WriteLine("2 - Unenroll a student");
            Console.WriteLine("3 - Print list of enrolled students");
            Console.WriteLine("4 - Exit");
            Console.WriteLine("");
            Console.WriteLine("Enter option:");

            menuChoice = Convert.ToInt32(Console.ReadLine());
            return menuChoice;
        }

        static void EnrollStudent()
        {
            return;
        }

        static void UnenrollStudent()
        {
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

            for (int i=0;i < NumOfEnrolled();i++)
            {
                Console.WriteLine("{0}  {1}", i, Students[i]);
            }
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
                    
            }
            
           
            //Console.ReadKey();

        }
    }
}
