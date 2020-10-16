using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WSB.EmployeeSelfService.Domain.Entities;

namespace WSB.EmployeeSelfService.DAL.DataContexts
{
    public class WSBEmployeeSelfServiceDataContext : DbContext
    {
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<LeaveApplication> LeaveApplications { get; set; }
        public virtual DbSet<Payslip> Payslips { get; set; }
        public WSBEmployeeSelfServiceDataContext(DbContextOptions<WSBEmployeeSelfServiceDataContext> options) : base(options)
        {

        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var added = ChangeTracker.Entries().Where(t => t.State == EntityState.Added)?.ToList();
            added.ForEach(x =>
            {
                x.Property("CreatedDate").CurrentValue = DateTime.Now;
                x.Property("CreatedUser").CurrentValue = "System";
            });

            var updated = ChangeTracker.Entries().Where(t => t.State == EntityState.Modified)?.ToList();
            updated.ForEach(y =>
            {
                y.Property("CreatedDate").IsModified = false;
                y.Property("CreatedUser").IsModified = false;
                y.Property("UpdatedDate").CurrentValue = DateTime.Now;
                y.Property("UpdatedUser").CurrentValue = "System";
            });
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
