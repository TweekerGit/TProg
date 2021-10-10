using System;
using System.Collections.Generic;
using System.Linq;

namespace ElementarySchool.Entities
{
    public class School
    {
        public School()
        {
            Classes = new List<Class>
            {
                new() {Name = ClassNames.First},
                new() {Name = ClassNames.Second},
                new() {Name = ClassNames.Third},
                new() {Name = ClassNames.Fourth},
            };
        }

        private List<Class> Classes { get; }

        public void AddToClass(ClassNames className, Child child) =>
            Classes.FirstOrDefault(c => c.Name == className)?.Children.Add(child);

        public void ShowStatistic()
        {
            foreach (var @class in Classes)
            {
                Console.WriteLine();
                Console.WriteLine("==============================");
                Console.WriteLine($"Class Name: {@class.Name}");
                Console.WriteLine("==============================");
                Console.WriteLine("~~Statistics:~~");
                Console.WriteLine($"Children Count: {@class.Children.Count}");
                Console.WriteLine($"Boys: {@class.Children.Count(c => c.Sex)}");
                Console.WriteLine($"Girls: {@class.Children.Count(c => !c.Sex)}");
                Console.WriteLine("~~Children:~~");
                foreach (var child in @class.Children)
                    Console.WriteLine(child.ToString());
                Console.WriteLine();
            }
            Console.WriteLine($"Too young or adults for elementary school: {ClassManager.Children.Count}");
            if (ClassManager.Children.Count > 0)
            {
                Console.WriteLine("~~Children who did not pass:~~");
                foreach (var child in ClassManager.Children)
                    Console.WriteLine(child.ToString());
            }
        }
    }
}