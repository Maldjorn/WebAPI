using CM.Customers;
using FluentValidation;

namespace CM.Customers.Validators
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        ErrorMessages errorMessages = new ErrorMessages();
        public CustomerValidator()
        {
            RuleFor(c => c.FirstName).MaximumLength(50).WithMessage(errorMessages.FirsNameLenght);
            RuleFor(c => c.LastName).NotEmpty().WithMessage(errorMessages.SecondNameLenght).MaximumLength(50).WithMessage(errorMessages.SecondNameNotEmpty);
            RuleFor(c => c.AddressList).NotEmpty().WithMessage(errorMessages.AddressesNotEmpty);
            RuleFor(c => c.PhoneNumber).MaximumLength(50).MinimumLength(7).WithMessage(errorMessages.InvaildPhoneFormat);
            RuleFor(c => c.Email)
               .Matches(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").WithMessage(errorMessages.InvalidEmailFormat);
            RuleFor(c => c.Notes)
               .NotEmpty().WithMessage(errorMessages.NotesNotEmpty);
        }
    }
}
