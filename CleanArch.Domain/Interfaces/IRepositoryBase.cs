using CleanArch.Domain.Entidades;

namespace CleanArch.Domain.Interfaces
{
    public interface IRepositoryBase<T> where T : Entity
    {
        public Task<T> Adicione(T entidade);
        public void Remova(T entidade);
        public void Atualize(T entidade);
        public Task<T> Obtenha(int? id);
        public Task<ICollection<T>> ObtenhaTodos();
    }
}
