using System.Collections.Generic;
using System.Linq;
using ElementarySchool.Entities;

namespace ElementarySchool
{
    public class ClassManager
    {
        private static List<Child> _children;
        public School School { get;}

        public ClassManager()
        {
            School = new School();
        }

        public void AddKids(List<Child> children)
        {
            _children = children;
            DistributeChildren();
        }

        public void AddKidsRandom()
        {
            var childrenFactory = new ChildrenFactory();
            _children = childrenFactory.RandomMany(20).ToList();
            DistributeChildren();
        }
        public static IReadOnlyList<Child> Children => _children;
        private void DistributeChildren()
        {
            foreach (var child in _children.ToList())
            {
                switch (child.Age)
                {
                    case > 6 and <= 8:
                        ManageChild(ClassNames.First, child);
                        break;
                    case 9:
                        ManageChild(ClassNames.Second, child);
                        break;
                    case 10:
                        ManageChild(ClassNames.Third, child);
                        break;
                    case 11:
                        ManageChild(ClassNames.Fourth, child);
                        break;
                    default:
                        break;
                }
            }
        }

        private void ManageChild(ClassNames className, Child child)
        {
            if (_children.Contains(child))
                _children.Remove(child);
            School.AddToClass(className, child);
        }
    }
}