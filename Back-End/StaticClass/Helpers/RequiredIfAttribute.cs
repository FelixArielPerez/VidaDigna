using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StaticClass.Helpers
{ 
    [AttributeUsage(AttributeTargets.Property)]
    public class RequiredIfAttribute : ValidationAttribute
    {
        public string ToFieldName { get; set; }
        public string ToValue { get; set; }

        public RequiredIfAttribute(string toFieldName, string toValue)
        {
            ToFieldName = toFieldName;
            ToValue = toValue;
        }
        
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var requiredValue = validationContext.ObjectType.GetProperty(ToFieldName).GetValue(validationContext.ObjectInstance, null);

            if(requiredValue == null) {
                return ValidationResult.Success;
            }

            if (ToValue == requiredValue.ToString()) 
            {
                if(value == null) {
                    return new ValidationResult(ErrorMessage ?? $"El campo es requerido {validationContext.MemberName}", new[] { validationContext.MemberName });
                }
                else
                {
                    return ValidationResult.Success;
                }

                Type t = value.GetType();
   
                if (t.Equals(typeof(string)) && value.ToString() != string.Empty) 
                    return ValidationResult.Success;
                else if (t.Equals(typeof(decimal)) && (decimal)value > 0)
                    return ValidationResult.Success;
                else if (t.Equals(typeof(int)) && (int)value > 0)
                    return ValidationResult.Success;
                else if (t.Equals(typeof(long)) && (long)value > 0)
                    return ValidationResult.Success;
                else if (t.Equals(typeof(double)) && (double)value > 0)
                    return ValidationResult.Success;
                
                return new ValidationResult(ErrorMessage ?? $"El campo es requerido {validationContext.MemberName}", new[] { validationContext.MemberName });
            }

            return ValidationResult.Success;
        }
    }
}