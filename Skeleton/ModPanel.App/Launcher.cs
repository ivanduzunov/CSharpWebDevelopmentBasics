namespace ModPanel.App
{
    using SimpleMvc.Framework;
    using SimpleMvc.Framework.Routers;
    using WebServer;
    using Data;
    using Microsoft.EntityFrameworkCore;

    public class Launcher
    {
        static Launcher()
        {
            using (var db = new ModPanelDbContext())
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
