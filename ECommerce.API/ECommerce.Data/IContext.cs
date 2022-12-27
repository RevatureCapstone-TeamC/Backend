using Microsoft.EntityFrameworkCore;

namespace ECommerce.Models
{
    public interface IContext
    {
        //public DbSet<InsuranceClaim> Claims { get; set; }
        //public DbSet<Employee> Employees { get; set; }
        //public DbSet<Patient> Patients { get; set; }
        //public void DenoteEmployeeModified(Employee emp);
        //public void DenotePatientModified(Patient pat);
        //public Task CommitChangesAsync();

        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public void DenoteProductModified(Product p);
        public void DenoteUserModified(User u);
        public Task CommitChangesAsync();
    }
}
