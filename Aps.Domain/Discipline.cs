namespace Aps.Domain
{
    public class Discipline
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? TeacherID { get; set; }
        public Teacher Teacher { get; set; }
    }
}