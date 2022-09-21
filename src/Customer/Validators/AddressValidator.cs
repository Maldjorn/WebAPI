using CM.Customers.Entities;
using FluentValidation;
using System.Collections.Generic;

namespace CM.Customers.Validators 
{ 
    public class AddressValidator : AbstractValidator<Address>
    {
        ErrorMessages errorMessages = new ErrorMessages();
        public AddressValidator()
        {
            var avaibleCountries = new List<string>() { "United States", "Canada" };
            RuleFor(a => a.AddressLine).NotEmpty().WithMessage(errorMessages.FirstAddressLineNotEmpty).MaximumLength(100).WithMessage(errorMessages.FirstAddressLineLength);
            RuleFor(a => a.AddressLine2).MaximumLength(100).WithMessage(errorMessages.SecondAddressLineLength);
            RuleFor(a => a.City).NotEmpty().WithMessage(errorMessages.CityNotEmpty).MaximumLength(50).WithMessage(errorMessages.CityLength);
            RuleFor(a => a.PostalCode).NotEmpty().WithMessage(errorMessages.PostalCodeNotEmpty).MaximumLength(6).WithMessage(errorMessages.PostalCodeNotEmpty);
            RuleFor(a => a.Country).Must(a => avaibleCountries.Contains(a)).WithMessage(errorMessages.InvalidCountry);
            RuleFor(a => a.State).NotEmpty().WithMessage(errorMessages.StateNotEmpty).MaximumLength(20).WithMessage(errorMessages.StateLength);

        }
    }
}
