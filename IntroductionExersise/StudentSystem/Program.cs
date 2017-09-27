using System;

namespace StudentSystem
{
    public class Program
    {
        static void Main(string[] args)
        {
            StudentSystemContext db = new StudentSystemContext();
            db.Database.EnsureDeleted(); 
            db.Database.EnsureCreated();
        }
    }
}
