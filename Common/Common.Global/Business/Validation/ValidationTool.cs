using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Common.Global.Business.Validation
{
    public static class ValidationTool
    {
        public static void Validate(Type validatorType, object entity)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new ArgumentException("WrongValidationType");
            }


            var validator = (IValidator)Activator.CreateInstance(validatorType);

            var context = new ValidationContext<object>(entity);

            var result = validator.Validate(context);
            if (!result.IsValid)
            {
                throw new Common.Global.Exceptions.ValidationException(result.Errors);
            }
        }
    }
}
