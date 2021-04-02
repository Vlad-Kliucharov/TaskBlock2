﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;

namespace TaskBlock2
{
    class Program
    {

        static List<PersonAttribute> PersonsList = new List<PersonAttribute>();

        static void Main(string[] args)
        {

            while (true)
            {
                Console.WriteLine("Select the action (the value):");
                Console.WriteLine("1 - Add new employee");
                Console.WriteLine("2 - Select all employees");
                Console.WriteLine("3 - Select parametrs from list (Max and Min salary, avarage age of employees )");
                Console.WriteLine("4 - Select user by department");
                Console.WriteLine("5 - Select user by name");
                string SelectAction = Console.ReadLine();
                switch (SelectAction)
                {
                    case "1":
                        Console.WriteLine("Add new employee");
                        PersonsList.Add(PersonAttribute.AddEmployees());
                        break;
                    case "2":
                        Console.WriteLine($"Select all employees");
                                                           //Select "PersonsList" for itemize
                        PersonAttribute.SelectAllEmployees(PersonsList); //Use "PersonAttribute" for itemize
                        break;
                    case "3":
                        Console.WriteLine("Select one parametr from list: ");
                        Console.WriteLine("Parametr 1 is max salary");
                        Console.WriteLine("Parametr 2 is min salary");
                        Console.WriteLine("Parametr 3 is average age of employees");
                        PersonAttribute.OptionList(PersonsList);
                        break;
                    case "4":
                        Console.WriteLine("Select user by department");
                        PersonAttribute.SelectDepartment(PersonsList);
                        break;
                    case "5":
                        Console.WriteLine("Select user by name");
                        PersonAttribute.SelectUserByName(PersonsList);
                        break;
                }
                Console.WriteLine("For ending the program enter the 'end', for continuing press 'enter'");
                string EndAction = Console.ReadLine();
                if (EndAction == "end")
                {
                    break;
                }
            }
            Console.WriteLine("The program is ended");
        }
    }

    class PersonAttribute
    {
        public string Name;
        public double Age;
        public double Salary;
        public string Department;


        public static PersonAttribute AddEmployees()
        {

            PersonAttribute Employee = new PersonAttribute(); //Creation of new object "Employee"

            Console.WriteLine($"Enter Employees name: ");
            Employee.Name = Console.ReadLine();
            Console.WriteLine($"Enter Employees Age: ");
            Employee.Age = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine($"Enter Employees Salary: ");
            Employee.Salary = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine($"Enter Employees Department: ");
            Employee.Department = Console.ReadLine();

            return Employee;
        }

                                                //List                List Name
        public static void SelectAllEmployees(List<PersonAttribute> PersonsList) //Transfer method from up 
        {
            foreach (var items in PersonsList)
            {
                Console.WriteLine($"Name : {items.Name}, Department : {items.Department}, Age : {items.Age}, Salary : {items.Salary}"); //Use string for itemize "items" in list
            }
        }
        public static void OptionList(List<PersonAttribute> PersonsList)
        {
            string selection = Console.ReadLine();
            switch (selection)
            {
                case "1":
                    double MaxSalary = PersonsList.Max(s => s.Salary);
                    Console.WriteLine($"Max salary is {MaxSalary}");
                    break;
                case "2":
                    double MinSalary = PersonsList.Min(s => s.Salary);
                    Console.WriteLine($"Mix salary is {MinSalary}");
                    break;
                case "3":
                    double AvarageAge = PersonsList.Average(a => a.Age);
                    Console.WriteLine($"An average age of employees is {AvarageAge}");
                    break;
                default:
                    Console.WriteLine("You enter incorrect value");
                    break;
            }
        }
        public static void SelectDepartment(List<PersonAttribute> PersonsList)
        {
            //List name  OrderBy(LINQ)           convert to list 
            PersonsList.OrderBy(i => i.Department).ToList().ForEach(y => Console.WriteLine($"Departmnet : {y.Department}"));

        }

        public static void SelectUserByName(List<PersonAttribute> PersonsList)
        {
            //List name  OrderBy(LINQ)           convert to list 
            PersonsList.OrderBy(i => i.Name).ToList().ForEach(y => Console.WriteLine($"Name : {y.Name}"));

        }
    }
}
