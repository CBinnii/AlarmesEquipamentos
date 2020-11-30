using PagedList;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Alarmes_Equipamentos.BLL
{
    public interface IBaseBLL<TEntity> where TEntity : class
    {
        void Adicionar(TEntity entidade);
        void AdicionarAsync(TEntity entidade);
        void Atualizar(TEntity entidade);
        void AtualizarAsync(TEntity entidade);
        IList<TEntity> BuscarLista();
        Task<IList<TEntity>> BuscarListaAsync();
        TEntity BuscarPorId(params object[] id);
        TEntity BuscarPorId(object id);
        Task<TEntity> BuscarPorIdAsync(object id);
        void Deletar(TEntity entidade);
        void DeletarAsync(TEntity entidade);
        //void AdicionarOuRemoverRelacao(ICollection<TEntity> listaEntidade, IEnumerable<Guid> novos);
        IPagedList<TEntity> Selecionar(int numeroPagina, int tamanhoPagina, string ordenarPor, Expression<Func<TEntity, bool>> filtro, string incluirProperties);
    }
}
