namespace apicompanies.Db.Models
{
    public class Enterprise
    {

        public Guid Id { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public virtual ICollection<Department> Departments { get; set; }
    }
}
