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

            //validação para a opção titulo da postagem
            RuleFor(c => c.Tipo)
                .NotEmpty()   //nao pode estar vazio
                .MaximumLength(255);  // maximo de caracteres
        }
    }
}