using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerSchool
{
    class Program
    {

        // Maximum number of students
        static int MaxStudents = 15;

        // arrays to hold students and fees
        static string[] Students = new string[MaxStudents];
        static double[] Fees = new double[MaxStudents];
        
        // Displays Menu and gets the user input returns integer
        static int DisplayMenuGetInput()
        {
            // clear the screen and print the list of students
            Console.Clear();
            PrintStudents();

            int menuChoice = 0;

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");


          // if there is still room show the enroll student option
            if (NumOfEnrolled() < MaxStudents)
            {
                Console.WriteLine("1 - Enroll a student");
                
            }
            
            // if there are no enrolled students don't show unenroll option
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

        // method to enroll student
        static void EnrollStudent()
        {

            string studentsName = null;



            // display current list of students
            Console.Clear();
            PrintStudents();

            Console.WriteLine("");
            Console.WriteLine("");

            //prompt for students name
            Console.WriteLine("STUDENT ENROLLMENT");
            Console.WriteLine("");
            Console.WriteLine("");


            Console.WriteLine("Please enter new student's name: ");
            studentsName = Console.ReadLine();

            // special case Malfoy
            if (studentsName.Contains("Malfoy"))
            {
                Console.WriteLine("Can not enroll {0} ", studentsName);
                return;
            }

            //enter the new students name in the last available position
            int newStudent = NumOfEnrolled();
            double newFee = 200;

            Students[newStudent] = studentsName;

            // special case Potter
            // check for special fee conditions
            if (studentsName.Contains("Potter"))
            {
                newFee = newFee / 2;
            }

            string tempName = studentsName.ToLower();

            // special cases
            if (studentsName.Contains("tom") || studentsName.Contains("riddle") || studentsName.Contains("voldemort"))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("RED ALERT!!! HE WHO MUST NOT BE NAMED.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(" ");
                Console.WriteLine("Press any key to continue ");
                Console.ReadKey();
            }

            
            // first and last name start with same letter
            var firstLastName = studentsName.Split(' ');
            string firstName = firstLastName[0];
            string lastName = firstLastName[1];
            if (firstName.First() == lastName.First())
            {
                
                newFee = newFee * .90;
                
            }

            // special case Longbottom
            if (studentsName.Contains("Longbottom"))
            {
                if (NumOfEnrolled() < 10)
                {
                    newFee = 0;
                }

            }

            Fees[newStudent] = newFee;

            Console.WriteLine("{0} is enrolled and owes {1} ", Students[newStudent], Fees[newStudent]);
            Console.WriteLine("Press any key to continue ");
            Console.ReadKey();
                        
            return;
        }

        // method to unenroll student
        static void UnenrollStudent()
        {
            int studentsNumber = 0;
            string[] tempStudents = new string[MaxStudents];
            double[] tempFees = new double[MaxStudents];

            Console.Clear();

            // display current list of students
            PrintStudents();

            Console.WriteLine("");
            Console.WriteLine("");

            Console.WriteLine("STUDENT UNENROLLMENT");
            Console.WriteLine("");
            Console.WriteLine("");

            // prompt for the student's number
            Console.WriteLine("Enter the student's number you want to unenroll: ");
            studentsNumber = Convert.ToInt32(Console.ReadLine());
            studentsNumber--;  

            // write out confirmation
            Console.WriteLine("Student : {0}  has been unenrolled. ", Students[studentsNumber]);

            // take out students name from the enrollment list
            Students[studentsNumber] = null;

            //variable to manage the tempStudent array           
            int j = 0;

            // pack the array getting rid of nulls
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

            Console.WriteLine(" ");
            Console.WriteLine("Press any key to continue ");
            Console.ReadKey();
                

            return;
        }

        // display enrolled students
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

            double sumOfFees = 0;

            // print out the fees in red if not $200
            for (int i=0;i < NumOfEnrolled();i++)
            {
                Console.Write("{0}. \t {1}   ", i+1, Students[i]);
                if (Fees[i] != 200)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                Console.WriteLine("\t{0}", Fees[i]);
                Console.ForegroundColor = ConsoleColor.White;
                sumOfFees = sumOfFees + Fees[i];

            }

            Console.WriteLine("");
            Console.WriteLine("");

            // print total fees due
            Console.WriteLine("Total fees due: {0}", sumOfFees);
            return;
        }

        // method to return number of enrolled students
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

                // enroll student option unless max number of students has been reached
                if (menuChoice == 1)
                {
                    if (NumOfEnrolled() < MaxStudents)
                    {
                        EnrollStudent();
                        continue;

                    }
                    else
                    {
                        Console.WriteLine("Maximum number of students !");
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        continue;
                    }

                    
                }

                // unenroll students unless there are none enrolled
                if (menuChoice == 2)
                {
                    if (NumOfEnrolled() > 0)
                    {
                        UnenrollStudent();
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("There are no students to unenroll !");
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        continue;
                    }
                }

                // print  list of students
                if (menuChoice == 3)
                {
                    PrintStudents();
                    continue;
                }


                // exit
                if (menuChoice == 4)
                {
                    continue;
                }

                // wrong choice if not 1-4
                if (menuChoice > 5 || menuChoice < 1)
                {
                    Console.WriteLine("Please enter a number from 1 - 4 ");
                    menuChoice = 0;
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    continue;
                }

                if (menuChoice == -1)
                {
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    continue;
                }                    
            }
            
           
            //Console.ReadKey();

        }
    }
}
