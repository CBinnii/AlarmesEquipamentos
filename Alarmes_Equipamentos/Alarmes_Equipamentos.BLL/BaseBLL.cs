using Alarmes_Equipamentos.DAL;
using Alarmes_Equipamentos.DAL.Model.Base;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Alarmes_Equipamentos.BLL
{

    public abstract class BaseBLL<TEntity> : IBaseBLL<TEntity> where TEntity : BaseModel
    {
        public const int TamanhoPagina = 50;

        protected AlarmeEquipamentoContext _contexto;
        protected DbSet<TEntity> _set;

        public BaseBLL(AlarmeEquipamentoContext contexto)
        {
            _contexto = contexto ?? throw new ArgumentNullException("AlarmeEquipamentoContext");
            _set = _contexto.Set<TEntity>();
        }

        public virtual void Adicionar(TEntity entidade)
        {
            _set.Add(entidade);
            _contexto.SaveChanges();
        }

        public async virtual void AdicionarAsync(TEntity entidade)
        {
            _set.Add(entidade);
            await _contexto.SaveChangesAsync();
        }

        public virtual void Atualizar(TEntity entidade)
        {
            _contexto.Entry(entidade).State = EntityState.Modified;
            _contexto.SaveChanges();
        }

        public async virtual void AtualizarAsync(TEntity entidade)
        {
            _contexto.Entry(entidade).State = EntityState.Modified;
            await _contexto.SaveChangesAsync();
        }

        public virtual IList<TEntity> BuscarLista()
        {
            return _set.ToList();
        }

        public async virtual Task<IList<TEntity>> BuscarListaAsync()
        {
            return await _set.ToListAsync();
        }

        public virtual TEntity BuscarPorId(params object[] id)
        {
            return _set.Find(id);
        }

        public virtual TEntity BuscarPorId(object id)
        {
            return _set.Find(id);
        }

        public async virtual Task<TEntity> BuscarPorIdAsync(object id)
        {
            return await _set.FindAsync(id);
        }

        public virtual void Deletar(TEntity entity)
        {
            _set.Remove(entity);
            _contexto.SaveChanges();
        }

        public async virtual void DeletarAsync(TEntity entity)
        {
            _set.Remove(entity);
            await _contexto.SaveChangesAsync();
        }

        public virtual void AdicionarOuRemoverRelacao(ICollection<TEntity> listaEntidade, IEnumerable<int> novos)
        {
            novos = novos ?? new List<int>();
            var atuais = listaEntidade.Select(s => s.Id);
            var removidos = atuais.Except(novos).ToList();
            var adicionados = novos.Except(atuais).ToList();
            removidos.ForEach(guid => { var entity = listaEntidade.Where(w => w.Id == guid).FirstOrDefault(); listaEntidade.Remove(entity); });
            adicionados.ForEach(guid => { listaEntidade.Add(BuscarPorId(guid)); });
        }

        public virtual IPagedList<TEntity> Selecionar(int numeroPagina = 1, int tamanhoPagina = TamanhoPagina, string ordenarPor = "", Expression<Func<TEntity, bool>> filtro = null, string incluirProperties = "")
        {
            IQueryable<TEntity> query = _set;

            foreach (var includeProperty in incluirProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (filtro != null)
            {
                query = query.Where(filtro);
            }

            if (!string.IsNullOrEmpty(ordenarPor))
            {
                string[] colunas = ordenarPor.Split(',');

                foreach (string coluna in colunas)
                {
                    string[] colunaComOrder = coluna.Split(' ');
                    bool ascending = true;
                    string columnName = colunaComOrder[0];

                    if (colunaComOrder.Length > 1 && colunaComOrder[1].ToLower().Contains("desc"))
                    {
                        ascending = false;
                    }

                    query = query.OrderByField(columnName, ascending);
                }
            }

            //if (numeroPagina == null || tamanhoPagina == null || string.IsNullOrEmpty(ordenarPor))
            //    return query.ToList();

            return query.ToPagedList(numeroPagina, tamanhoPagina);
        }
    }

    #region Extension Methods

    public static class ExtensionMethods
    {
        public static IQueryable<TEntity> OrderByField<TEntity>(this IQueryable<TEntity> q, string sortField, bool ascending)
        {
            var param = Expression.Parameter(typeof(TEntity), "p");

            MemberExpression prop = null;

            string[] propertiesName = sortField.Split('.');
            prop = Expression.Property(param, propertiesName[0]);

            for (int index = 1; index < propertiesName.Length; index++)
            {
                prop = Expression.Property(prop, propertiesName[index]);
            }

            var exp = Expression.Lambda(prop, param);
            string method = ascending ? "OrderBy" : "OrderByDescending";
            Type[] types = new Type[] { q.ElementType, exp.Body.Type };
            var mce = Expression.Call(typeof(Queryable), method, types, q.Expression, exp);
            return q.Provider.CreateQuery<TEntity>(mce);
        }
    }

    #endregion
}
