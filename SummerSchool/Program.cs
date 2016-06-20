﻿using System;
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

            //enter the new students name in the last available position
            Students[NumOfEnrolled()] = studentsName;

            
            return;
        }

        static void UnenrollStudent()
        {
            int studentsNumber = 0;
            string[] tempStudents = new string[15];

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

            // write out confirmation
            Console.WriteLine("Student : {0}  has been unenrolled. ", Students[studentsNumber]);

            // take out students name from the enrollment list
            Students[studentsNumber] = null;

            Console.WriteLine("Number of enrolled: {0}", NumOfEnrolled());
            Console.ReadKey();

            for (int i = 0;i < NumOfEnrolled();i++)
            {
                Console.WriteLine("Student {0}, {1}", i, Students[i]);
            }
            Console.ReadKey();

            int j = 0;

            // pack the array
            for (int i = 0;i <= NumOfEnrolled();i++)     
            {
                if (Students[i] != null)
                {
                    tempStudents[j] = Students[i];
                    j++;
                }
                    
                
            }

            // copy all of the tempStudent array into the Students array
            for (int i=0;i< NumOfEnrolled();i++)
            {
                Students[i] = tempStudents[i];
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
