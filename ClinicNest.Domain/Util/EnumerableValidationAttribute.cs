using ClinicNest.Domain.DTOs;
using ClinicNest.Domain.Entities;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace ClinicNest.Domain.Util
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class EnumerableValidationAttribute : ValidationAttribute
    {
        public bool AllowNullElements { get; set; }
        public bool AllowInvalidElements { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
                return ValidationResult.Success;

            if (validationContext == null)
                throw new ArgumentNullException(nameof(validationContext));

            IEnumerable enumeration = value as IEnumerable;

            if (enumeration == null)
                throw new ArgumentException("Apenas tipos que implementam IEnumerable podem ser utilizados.");

            bool isValid = true;

            foreach(object element in enumeration)
            {
                if (!AllowNullElements && element == null)
                {
                    isValid = false;
                    break;
                }

                if (!AllowInvalidElements && IsInvalidElement(element)) 
                {
                    isValid = false;
                    break;
                }
            }

            if (!isValid)
            {
                var memberNames = new string[] { validationContext.MemberName };
                return new ValidationResult(ErrorMessage, memberNames);
            }

            return ValidationResult.Success;
        }

        private bool IsInvalidElement(object element)
        {
            if (element == null)
                return false;

            if(element is BaseEntity)
            {
                BaseEntity parsedEntity = element as BaseEntity;
                return parsedEntity.IsValid() == false;
            }

            if(element is ValidatedDTO)
            {
                ValidatedDTO parsedDTO = element as ValidatedDTO;
                return parsedDTO.IsValid() == false;
            }

            return false;
        }
    }
}
