using System;
using System.Collections.Generic;
using ElementarySchool.Entities;

namespace ElementarySchool
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            ClassManager manager = new();
            Start:
            Console.WriteLine("Menu:");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("Test School Manager -> 1\nTest School Manager With Random Kids -> 2");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~");
            var selected = Console.ReadKey().KeyChar;
            Console.WriteLine();
            if (selected != '1' && selected != '2')
            {
                Console.WriteLine("Here we go again!");
                goto Start;
            }
            switch (selected)
            {
                case '1':
                    List<Child> tempChildren = new()
                    {
                        new Child {Id = 1, Name = "Vasya", Age = 7, Sex = true},
                        new Child {Id = 2, Name = "Alina", Age = 8, Sex = false},
                        new Child {Id = 3, Name = "Ivan", Age = 9, Sex = true},
                        new Child {Id = 4, Name = "Kostya", Age = 10, Sex = true},
                        new Child {Id = 5, Name = "Sofia", Age = 11, Sex = false},
                        new Child {Id = 6, Name = "Illya", Age = 11, Sex = true},
                        new Child {Id = 7, Name = "Yurii", Age = 7, Sex = true},
                        new Child {Id = 8, Name = "Inna", Age = 8, Sex = false},
                        new Child {Id = 9, Name = "Vlad", Age = 7, Sex = true},
                        new Child {Id = 10, Name = "Dima", Age = 9, Sex = true},
                        new Child {Id = 11, Name = "Yulia", Age = 10, Sex = false},
                        new Child {Id = 12, Name = "Misha", Age = 11, Sex = true},
                        new Child {Id = 13, Name = "Bogdana", Age = 8, Sex = false},
                        new Child {Id = 14, Name = "Dania", Age = 11, Sex = true},
                        new Child {Id = 15, Name = "Mira", Age = 18, Sex = false},
                        new Child {Id = 16, Name = "Oleg", Age = 15, Sex = true}
                    };
                    manager.AddKids(tempChildren);
                    break;
                case '2':
                    manager.AddKidsRandom();
                    break;
            }
            manager.School.ShowStatistic();
        }
    }
}