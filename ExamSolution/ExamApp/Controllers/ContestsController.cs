﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ExamApp.Controllers
{
    using Services;
    using Services.Contracts;
    using SimpleMvc.Framework.Attributes.Methods;
    using SimpleMvc.Framework.Contracts;
    using Models.User;
    using Models.Contest;
    using Data;
    using System.Linq;

    public class ContestsController : BaseController
    {
        private readonly IContestsService contests;

        public ContestsController()
        {
            this.contests = new ContestsService();
        }

        public IActionResult Index()
        {
            var contestsList = new StringBuilder();


            var allContests = contests.All(this.Profile.Id);

            if (IsAdmin)
            {
                foreach (var contest in allContests)
                {

                    contestsList.AppendLine($"<tr>");
                    contestsList.AppendLine($@"<td scope=""row"">{contest.Name}t</td>");
                    contestsList.AppendLine($@"<td>{contest.SubmitionsCount}</td>");
                    contestsList.Append($@" <td>
                            <a href=""/contests/edit/{contest.Id}"" class=""btn btn-sm btn-warning"" >Edit</a>
                             <a href=""/contests/delete/{contest.Id}"" class=""btn btn-sm btn-danger"">Delete</a>
                        </td>  </tr>");
                }


            }
            else
            {
                foreach (var contest in allContests)
                {

                    contestsList.AppendLine($"<tr>");
                    contestsList.AppendLine($@"<td scope=""row"">{contest.Name}t</td>");
                    contestsList.AppendLine($@"<td>{contest.SubmitionsCount}</td>");

                    if (contest.CurrentUserIsCreator)
                    {
                        contestsList.Append($@" <td>
                            <a href=""/contests/edit/{contest.Id}"" class=""btn btn-sm btn-warning"" >Edit</a>
                             <a href=""/contests/delete/{contest.Id}"" class=""btn btn-sm btn-danger"">Delete</a>
                        </td> </tr>");
                    }
                    else
                    {
                        contestsList.Append($@" <td> </td> </tr>");
                    }

                }
            }

            if (User.IsAuthenticated)
            {
                this.ViewModel["createButton"] = $@" <div><a href = ""/contests/create"" class=""btn  btn-dark btn-sm"">Create</a></div>";
            }

            this.ViewModel["completeList"] = contestsList.ToString();

            return this.View();
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(CreateContestModel model)
        {
            var userId = this.Profile.Id;

            var success = contests.Create(model.Name, userId);

            return this.Redirect("/contests/index");
        }

    }
}