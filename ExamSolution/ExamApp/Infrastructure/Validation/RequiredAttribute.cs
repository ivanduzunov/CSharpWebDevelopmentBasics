using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using SimpleMvc.Framework.Attributes.Validation;

namespace ExamApp.Infrastructure.Validation
{
    public class RequiredAttribute : PropertyValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return new System
                 .ComponentModel
                 .DataAnnotations
                 .RequiredAttribute()
                 .IsValid(value);
        }
    }
}
