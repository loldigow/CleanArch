using CleanArch.Domain.Validacoes;

namespace CleanArch.Domain.Entidades
{
    public sealed class Categoria : Entity
    {
        public string Name { get; private set; }
        public ICollection<Produto> Produtos { get; private set; }

        public Categoria(int id = 0, string name = "")
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "invalid name. Name Is required");

            DomainExceptionValidation.When(name.Length < 3,
                "invalid name. Nome tem que ter mais que 3 caracters");

            DomainExceptionValidation.When(id < 0,
                "invalid ID, não pode ser menor que 0");

            ID = id;
            Name = name;
            Produtos = new List<Produto>();
        }

        public void Update(string nome)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(nome),
    "invalid name. Name Is required");

            DomainExceptionValidation.When(nome.Length < 3,
                "invalid name. Nome tem que ter mais que 3 caracters");

            Name = nome;
        }
    }
}
