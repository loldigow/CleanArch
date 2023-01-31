using CleanArch.Domain.Validacoes;

namespace CleanArch.Domain.Entidades
{
    public sealed class Produto : Entity
    {
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public decimal Preco { get; private set; }
        public float Estoque { get; private set; }
        public string Image { get; private set; }

        public Produto(int id = 0, string nome = "", string descricao = "", decimal preco = 0, float quantidadeEstoque = 0, string image = "")
        {
            DomainExceptionValidation.When(id < 0, "Codigo do produto nao pode ser 0");
            ValidePropriedadesComum(nome, preco);

            ID = id;
            Nome = nome;
            Descricao = descricao;
            Preco = preco;
            Estoque = quantidadeEstoque;
            Image = image;
        }

        private static void ValidePropriedadesComum(string nome, decimal preco)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(nome), "Nome produto não pode ser vazio");
            DomainExceptionValidation.When(nome.Length < 5, "Nome produto não pode ser menor que 5");
            DomainExceptionValidation.When(preco < 0, "valor do produto não pode ser negativo");
            DomainExceptionValidation.When(preco < 0, "quantidade em estoque inválida");
        }

        public void Update(string nome = "", string descricao = "", decimal preco = 0, float quantidadeEstoque = 0, string image = "", int categoriaID = 0)
        {
            DomainExceptionValidation.When(categoriaID < 0, "Categoria inválida");
            ValidePropriedadesComum(nome, preco);
            Nome = nome;
            Descricao = descricao;
            Preco = preco;
            Estoque = quantidadeEstoque;
            Image = image;
            CategoriaId = categoriaID;
        }

        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
    }

}
