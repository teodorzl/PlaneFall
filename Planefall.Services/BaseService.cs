namespace Planefall.Services
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Data;

    public abstract class BaseService
    {
        protected readonly PlanefallDbContext Context;

        protected BaseService(PlanefallDbContext context)
        {
            this.Context = context;
        }

        // Validate model properties
        protected bool IsEntityStateValid(object model)
        {
            var validationContext = new ValidationContext(model);
            var validationResults = new List<ValidationResult>();

            return Validator.TryValidateObject(model, validationContext, validationResults,
                validateAllProperties: true);
        }
    }
}