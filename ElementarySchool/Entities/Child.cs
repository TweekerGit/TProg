using System;

namespace ElementarySchool.Entities
{
    public class Child
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Sex { get; set; }
        public byte Age { get; set; }

        private string SexToString() => Sex ? "Boy" : "Girl";
        public override string ToString() => $"<Name: {Name}, Sex: {SexToString()}, Age: {Age}>";
    }
}