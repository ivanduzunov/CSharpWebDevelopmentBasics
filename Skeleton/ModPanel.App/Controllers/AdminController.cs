using System;
using System.Collections.Generic;
using System.Text;

namespace ModPanel.App.Controllers
{
    using Services;
    using Services.Contracts;
    using System.Linq;
    using SimpleMvc.Framework.Contracts;

    public class AdminController : BaseController
    {      
        private readonly IUserService users;

        public AdminController()
        {
            this.users = new UserService();
        }

        public IActionResult Users()
        {
            if (!this.IsAdmin)
            {
                return this.RedirectToLogin();
            }

            var rows = this.users
                .All()
                .Select(u => $@"
                    <tr>
                        <td>{u.Id}</td>
                        <td>{u.Email}</td>
                        <td>{u.Position}</td>
                        <td>
                            {(u.IsApproved ? string.Empty : $@"<a class=""btn btn-primary btn-sm"" href=""/admin/approve?id={u.Id}"">Approve</a>")}
                        </td>
                    </tr>");

            this.ViewModel["users"] = string.Join(string.Empty, rows);

            return this.View();
        }

        public IActionResult Approve(int id)
        {
            if (!this.IsAdmin)
            {
                return this.RedirectToLogin();
            }

            var userEmail = this.users.Approve(id);

            return this.Redirect("/admin/users");
        }
    }
}
