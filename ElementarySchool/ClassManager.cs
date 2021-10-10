using System.Collections.Generic;
using ElementarySchool.Entities;

namespace ElementarySchool
{
    public class ClassManager
    {
        private List<Child> _children;

        public ClassManager(List<Child> children)
        {
            _children = GenerateKids();
        }

        private List<Child> GenerateKids()
        {
            return new List<Child>();
        }
    }
}