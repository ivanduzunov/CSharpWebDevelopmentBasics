using System;
using SimpleMvc.Framework;
using SimpleMvc.Framework.Routers;
using Microsoft.EntityFrameworkCore;

namespace ExamApp
{
    using Data;
    using WebServer;

    public class Launcher
    {
        static Launcher()
        {
            using (var db = new ExamAppDbContext())
            {
                db.Database.Migrate();
            }
        }

        public static void Main()
            => MvcEngine.Run(
                new WebServer(1337,
                   new ControllerRouter(),
                    new ResourceRouter()));
    }
}
