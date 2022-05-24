namespace apicompanies.Db.Models
{
    public class Employe
    {
        public Guid Id { get; set; }
        public short Age { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string Surname { get; set; }
        public virtual ICollection<Department_Employe> DepartmentsEmployees { get; set; }
    }
}
