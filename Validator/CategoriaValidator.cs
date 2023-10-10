using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FarmaciaPerformanceGo.Model;
using FluentValidation;


namespace FarmaciaPerformanceGo.Validator
{
    public class CategoriaValidator : AbstractValidator<Categoria>
    {
        public CategoriaValidator()
        {
            RuleFor(t => t.Descricao)
                .NotEmpty();
        }
    }
}