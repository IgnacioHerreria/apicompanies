namespace apicompanies.Db.Models
{
    public class Department
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public Guid IdEnterprise { get; set; }
        public virtual Enterprise Enterprise { get; set; }
        public virtual ICollection<Department_Employe> DepartmentsEmployees { get; set; }
    }
}