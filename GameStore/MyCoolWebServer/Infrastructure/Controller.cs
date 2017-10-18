using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using MyCoolWebServer.Server.Enums;
using MyCoolWebServer.Server.Http.Contracts;
using MyCoolWebServer.Server.Http.Response;

namespace MyCoolWebServer.Infrastructure
{
    public abstract class Controller
    {
        public const string DefaultPath = @"{0}\Resources\{1}.html";
        public const string ContentPlaceholder = "{{{content}}}";

        protected Controller()
        {
            this.ViewData = new Dictionary<string, string>
            {
                ["anonymousDisplay"] = "none",
                ["authDisplay"] = "flex",
                ["showError"] = "none"
            };
        }

        protected abstract string ApplicationDirectory { get; }
        protected IDictionary<string, string> ViewData { get; private set; }

        protected IHttpResponse FileViewResponse(string fileName)
        {
            //replase if there is a data into ViewData and returns the View Response

            var result = this.ProcessFileHtml(fileName);

            if (this.ViewData.Any())
            {
                foreach (var value in this.ViewData)
                {
                    result = result.Replace($"{{{{{{{value.Key}}}}}}}", value.Value);
                }
            }

            return new ViewResponse(HttpStatusCode.Ok, new FileView(result));
        }

        protected IHttpResponse RedirectResponse(string route)
            => new RedirectResponse(route);

        protected void ShowError(string errorMessage)
        {
            //adds the found error from in the ValidateModel method if there is one.

            this.ViewData["showError"] = "block";
            this.ViewData["error"] = errorMessage;
        }

        protected bool ValidateModel(object model)
        {
            var context = new ValidationContext(model);
            var results = new List<ValidationResult>();

            //Try to validate. If NOT it foreaches all the validation results and if its NOT TRUE it calls ShowError method.

            if (Validator.TryValidateObject(model, context, results, true) == false)
            {
                foreach (var result in results)
                {
                    if (result != ValidationResult.Success)
                    {
                        this.ShowError(result.ErrorMessage);
                        return false;
                    }
                }
            }

            return true;
        }


        private string ProcessFileHtml(string path)
        {
            // Takes the layout and the content and returns the complete html

            var layoutHtml = File.ReadAllText(string.Format(DefaultPath, this.ApplicationDirectory, "layout"));

            var content = File
                .ReadAllText(string.Format(DefaultPath, this.ApplicationDirectory, path));

            var result = layoutHtml.Replace(ContentPlaceholder, content);

            return result;
        }
    }
}
