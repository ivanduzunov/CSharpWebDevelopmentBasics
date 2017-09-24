using System;

namespace ManyToMany
{
    public class Program
    {
        public static void Main(string[] args)
        {
            AppContext context = new AppContext();
            ClearDatabase(context);
        }

        public static void ClearDatabase(AppContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }
    }
}
