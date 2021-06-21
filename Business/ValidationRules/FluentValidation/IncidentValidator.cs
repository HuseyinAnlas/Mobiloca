using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class IncidentValidator : AbstractValidator<Incident>
    {
        public IncidentValidator()
        {
            RuleFor(p => p.ID).NotEmpty();

            RuleFor(p => p.dc_Zaman).NotEmpty();

            RuleFor(p => p.dc_Kategori).NotEmpty();
            RuleFor(p => p.dc_Kategori).MinimumLength(2);

            RuleFor(p => p.dc_Olay).NotEmpty();


        }
    }
}
