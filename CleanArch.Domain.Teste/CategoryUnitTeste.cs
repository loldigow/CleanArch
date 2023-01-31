using CleanArch.Domain.Entidades;
using CleanArch.Domain.Validacoes;
using FluentAssertions;

namespace CleanArch.Domain.Teste
{
    public class CategoryUnitTeste
    {
        [Fact(DisplayName = "Criando categoria com estado valido")]
        public void CreateCategory_WithValidParameter_ResultValidState()
        {
            Action action = () => new Categoria(1, "Categoria teste");
            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Criando categoria com estado Id negativo")]
        public void CreateCategory_WithIdNegative_ResultInValidState()
        {
            Action action = () => new Categoria(-1, "Categoria teste");
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("invalid ID, não pode ser menor que 0");
        }

        [Fact(DisplayName = "Criando categoria com nome vazio")]
        public void CreateCategory_WithNameEmpty_ResultInValidState()
        {
            Action action = () => new Categoria(1, "");
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("invalid name. Name Is required");
        }

        [Fact(DisplayName = "Criando categoria com nome menor que 3")]
        public void CreateCategory_Withnameless3_ResultInValidState()
        {
            Action action = () => new Categoria(1, "Ca");
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("invalid name. Nome tem que ter mais que 3 caracters");
        }

        [Fact(DisplayName = "Criando categoria passando somente codigo por parametro")]
        public void CreateCategory_WithOnlyIdParameter_ResultInValidState()
        {
            Action action = () => new Categoria(1);
            action.Should().Throw<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Criando categoria passando nenhum parametro")]
        public void CreateCategory_WithoutParameter_ResultInValidState()
        {
            Action action = () => new Categoria(1);
            action.Should().Throw<DomainExceptionValidation>();
        }
    }
}