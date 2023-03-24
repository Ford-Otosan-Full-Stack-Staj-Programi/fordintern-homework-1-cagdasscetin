using FluentValidation;
using System;

namespace StaffApi.Data;

public class StaffValidator : AbstractValidator<Staff>
{
    public StaffValidator()
    {
        RuleFor(x => x.Id).NotNull();
        RuleFor(x => x.FirstName).Length(2, 20);
        RuleFor(x => x.LastName).Length(2, 20);
        RuleFor(x => x.Email).EmailAddress();
        RuleFor(x => x.Phone).NotNull();
    }
}
