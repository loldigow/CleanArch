namespace CleanArch.Domain.Validacoes
{
    public class DomainExceptionValidation : Exception
    {
        public DomainExceptionValidation(string mensagem) : base(mensagem)
        {

        }

        public static void When(bool hasError, string erro)
        {
            if (hasError)
            {
                throw new DomainExceptionValidation(erro);
            }
        }
    }
}
