using ECommerce.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace ECommerce.Models
{
    public class Context : DbContext, IContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }
        //public DbSet<InsuranceClaim> Claims { get; set; } = null!;

        //public DbSet<Employee> Employees { get; set; } = null!;
        //public DbSet<Patient> Patients { get; set; } = null!;
        //public void DenoteEmployeeModified(Employee emp) { Entry(emp).State = EntityState.Modified; }
        //public void DenotePatientModified(Patient pat) { Entry(pat).State = EntityState.Modified; }
        //public Task CommitChangesAsync() { return SaveChangesAsync(); }

        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<User> Users { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        //public Task<IEnumerable<Product>> GetAllProductsAsync();
        //public Task<Product> GetProductByIdAsync(int id);
        //public Task ReduceInventoryByIdAsync(int id, int purchased);
        //public Task<User> GetUserLoginAsync(string password, string email);
        //public Task<int> CreateNewUserAndReturnUserIdAsync(User newUser);

        public void DenoteProductModified(Product p)
        {
            throw new NotImplementedException();
        }

        public void DenoteUserModified(User u)
        {
            throw new NotImplementedException();
        }

        public Task CommitChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
