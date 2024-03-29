﻿#region Using
using Bank.Application.SystemActors.TransectionFeature.Command;
using FluentValidation;

#endregion
namespace Bank.Application.Validators
{

    public class TransferCommandValidator : AbstractValidator<TransferCommand>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public TransferCommandValidator()
        {
            RuleFor(c => c.SourceAccountId).NotEmpty().NotEqual(0);
            RuleFor(c => c.DestinationAccountId).NotEmpty().NotEqual(0);
            RuleFor(c => c.Amount).NotEmpty().GreaterThanOrEqualTo(1);
        }
    }
}
