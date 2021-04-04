using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Validation
{
    public static class ValidationTool
    {
        /// <summary>
        /// Burada validator IValidator'daki validate' kullanacak,
        /// entity ise object olarak gelecek dto'yu kullanacak(product) gibi
        /// </summary>
        /// <param name="validator"></param>
        /// <param name="entity"></param>
        public static void Validate(IValidator validator, object entity)
        {
            var context = new ValidationContext<object>(entity);
            var result = validator.Validate(context);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
