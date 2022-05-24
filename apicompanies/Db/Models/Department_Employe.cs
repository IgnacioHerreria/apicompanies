namespace apicompanies.Db.Models
{
    public class Department_Employe
    {
        public Guid Id { get; set; }
        public Guid DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        public Guid EmproyeId { get; set; }
        public virtual Employe Employe { get; set; }
    }
}