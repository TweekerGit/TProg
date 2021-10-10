using System.Collections.Generic;

namespace ElementarySchool.Entities
{
    public class Class
    {
        public Class()
        {
            Children = new List<Child>();
        }

        public ClassNames Name { get; set; }
        public List<Child> Children { get; set; }
    }
}