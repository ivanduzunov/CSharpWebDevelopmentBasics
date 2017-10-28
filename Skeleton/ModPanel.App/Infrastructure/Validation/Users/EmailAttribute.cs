using System;
using System.Collections.Generic;
using System.Text;

namespace ModPanel.App.Infrastructure.Validation.Users
{
    using SimpleMvc.Framework.Attributes.Validation;
    using System.Linq;

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
