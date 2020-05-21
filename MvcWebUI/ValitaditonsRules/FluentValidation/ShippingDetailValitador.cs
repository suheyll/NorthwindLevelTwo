using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using MvcWebUI.Models;

namespace MvcWebUI.ValitaditonsRules.FluentValidation
{
    public class ShippingDetailValitador:AbstractValidator<ShippingDetail>
    {
        public ShippingDetailValitador()
        {
            RuleFor(s => s.FirtName).NotEmpty().WithMessage("adı gereklidir");
            RuleFor(s => s.FirtName).MinimumLength(2);
            RuleFor(s=>s.LastName).NotEmpty();
            RuleFor(s => s.Address).NotEmpty();
            RuleFor(s => s.City).NotEmpty().When(s => s.Age < 18);
            RuleFor(s => s.FirtName).Must(StartWithA);

        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
