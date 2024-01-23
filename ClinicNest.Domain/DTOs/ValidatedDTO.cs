using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ClinicNest.Domain.DTOs
{
    public abstract class ValidatedDTO
    {
        public virtual bool IsValid()
        {
            ValidationContext validationContext = new ValidationContext(instance: this, serviceProvider: null, items: null);

            return Validator.TryValidateObject(instance: this, 
                                               validationContext: validationContext, 
                                               validationResults: new List<ValidationResult>(),
                                               validateAllProperties: true);
        }

        public virtual bool IsValid(out Dictionary<string, string[]> validationErrors)
        {
            validationErrors = new Dictionary<string, string[]>();

            ValidationContext validationContext = new ValidationContext(instance: this, serviceProvider: null, items: null);
            List<ValidationResult> validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(instance: this,
                                                       validationContext: validationContext,
                                                       validationResults: validationResults,
                                                       validateAllProperties: true);

            if (!isValid)
            {
                var resultsGroupedByMemberName = from result in validationResults
                                                 group result by result.MemberNames.First() into groupedResults
                                                 select groupedResults;

                foreach(var group in resultsGroupedByMemberName)
                {
                    string memberName = group.Key;
                    ValidationResult[] result = group.ToArray();
                    
                    string[] errorMessages = result.Select(selectedResult => selectedResult.ErrorMessage).ToArray();

                    validationErrors.Add(memberName, errorMessages);
                }
            }

            return isValid;
        }
    }
}
