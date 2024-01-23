using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ClinicNestWebApi.Entities
{
    public abstract class BaseEntity
    {
        [SuppressMessage("Design", "CA1051:Não declarar campos de instância visíveis", Justification = "Classe abstrata, pode ser necessário fazer uma validação manual na classe")]
        protected ValidationContext _validation;

        [SuppressMessage("Design", "CA1051:Não declarar campos de instância visíveis", Justification = "Classe abstrata, pode ser necessário fazer uma validação manual na classe")]
        protected List<ValidationResult> _results;

        public virtual bool IsValid()
        {
            _validation = new ValidationContext(this, serviceProvider: null, items: null);
            _results = new List<ValidationResult>();

            return Validator.TryValidateObject(this, _validation, _results, true);
        }

        public virtual List<string> ValidationResults()
        {
            _validation = new ValidationContext(this, serviceProvider: null, items: null);
            _results = new List<ValidationResult>();

            Validator.TryValidateObject(this, _validation, _results, true);

            return _results?.Select(r => r.ErrorMessage).ToList() ?? new List<string>();
        }
    }
}
