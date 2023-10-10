using FarmaciaPerformanceGo.Model;
using FluentValidation;


namespace FarmaciaPerformanceGo.Validator
{
    public class ProdutoValidator : AbstractValidator<Produto>
    {


        public ProdutoValidator()
        {
            RuleFor(n => n.Nome)
                    .NotEmpty()
                    .MinimumLength(2)
                    .MaximumLength(50);

            RuleFor(d => d.Descricao)
                    .NotEmpty()
                    .MinimumLength(10)
                    .MaximumLength(1000);

            RuleFor(p => p.Preco)
                .NotNull()
                .GreaterThan(0)
                .PrecisionScale(7, 2, false);

            RuleFor(f => f.Foto)
                    .NotEmpty()
                    .MinimumLength(2)
                    .MaximumLength(5000);


        }

    }
}

