using System;

namespace StudentSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentSystemContext db = new StudentSystemContext();

            db.Database.EnsureCreated();
        }
    }
}
