using CleanArch.Domain.Entidades;
using CleanArch.Domain.Validacoes;
using FluentAssertions;

namespace CleanArch.Domain.Teste
{
    public class ProductUnitTeste
    {
        [Fact(DisplayName = "Criando produto valido")]
        public void CreateProduct_WithValidParameter_ResultValidState()
        {
            Action action = () => new Produto(2, "Produto Teste", "Descricao do produto", (decimal)25, (float)10);
            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Criando produto com id negativo")]
        public void CreateProduct_WithIdNegative_ResultInvalidState()
        {
            Action action = () => new Produto(-1, "Produto Teste", "Descricao do produto", (decimal)25, (float)10);
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Codigo do produto nao pode ser 0");
        }

        [Fact(DisplayName = "Criando produto com nome menor que 5")]
        public void CreateProduct_WithNameLess5_ResultInvalidState()
        {
            Action action = () => new Produto(-1, "Pro", "Descricao do produto", (decimal)25, (float)10);
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Nome produto não pode ser menor que 5");
        }

        [Fact(DisplayName = "Criando produto com nome vazio")]
        public void CreateProduct_WithNameLess_ResultInvalidState()
        {
            Action action = () => new Produto(-1, "", "Descricao do produto", (decimal)25, (float)10);
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Nome produto não pode ser vazio");
        }

        [Fact(DisplayName = "Criando produto com preço negativo")]
        public void CreateProduct_WithPriceNegative_ResultInvalidState()
        {
            Action action = () => new Produto(2, "Produto de teste", "Descricao do produto", (decimal)-25, (float)10);
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("valor do produto não pode ser negativo");
        }

        [Fact(DisplayName = "Criando produto com Estoque negativo")]
        public void CreateProduct_WithNegativeStock_ResultInvalidState()
        {
            Action action = () => new Produto(2, "Produto de teste", "Descricao do produto", (decimal)-25, (float)10);
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("quantidade em estoque inválida");
        }
    }
}
