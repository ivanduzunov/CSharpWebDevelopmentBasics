using System;

namespace OneToMany
{
    public class Program
    {
        public static void Main(string[] args)
        {
            AppContext cxt = new AppContext();
            cxt.Database.EnsureDeleted();
            cxt.Database.EnsureCreated();

            using (cxt)
            {
                Department department = new Department{Name = "Finance"};
                department.Employees.Add(new Employee { Name = "Stamat" });
                cxt.Departments.Add(department);
                cxt.SaveChanges();
            }

           
        }
    }
}