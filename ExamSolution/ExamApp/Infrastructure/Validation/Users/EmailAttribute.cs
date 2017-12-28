using System;
using System.Collections.Generic;
using System.Text;
using SimpleMvc.Framework.Attributes.Validation;
using System.Linq;

namespace ExamApp.Infrastructure.Validation.Users
{
    public class EmailAttribute : PropertyValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var email = value as string;

            if (email == null)
            {
                return true;
            }

            return email.Contains(".") && email.Contains("@");
        }
    }
}
