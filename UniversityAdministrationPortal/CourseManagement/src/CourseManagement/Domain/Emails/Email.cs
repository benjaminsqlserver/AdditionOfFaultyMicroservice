namespace CourseManagement.Domain.Emails;

using FluentValidation;

public sealed class Email : ValueObject
{
    public string Value { get; private set; }
    
    public Email(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            Value = null;
            return;
        }
        new EmailValidator().ValidateAndThrow(value);
        Value = value;
    }
    
    public static Email Of(string value) => new Email(value);
    public static implicit operator string(Email value) => value.Value;

    private Email() { } // EF Core
    
    private sealed class EmailValidator : AbstractValidator<string> 
    {
        public EmailValidator()
        {
            RuleFor(email => email).EmailAddress();
        }
    }
}