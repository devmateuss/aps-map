using System.Collections.Generic;

namespace Aps.Domain
{
    public class Student
    {
        public int Id { get; set; }
        public string Registration { get; set; }
        public string Name { get; set; }
        public int Term { get; set; }
        public string Class { get; set; }
        public List<Discipline> Disciplines { get; set; }
    }
}