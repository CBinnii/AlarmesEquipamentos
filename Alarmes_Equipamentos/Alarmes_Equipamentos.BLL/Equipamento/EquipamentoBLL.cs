using Alarmes_Equipamentos.DAL;
using Alarmes_Equipamentos.DAL.Model;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alarmes_Equipamentos.BLL
{
    public class EquipamentoBLL : BaseBLL<Equipamento>, IEquipamentoBLL
    {
        public EquipamentoBLL(AlarmeEquipamentoContext _contexto) : base(_contexto)
        {
            this._contexto = _contexto;
        }

        public override void Adicionar(Equipamento equipamento)
        {
            equipamento.DataCadastro = DateTime.Now;

            base.Adicionar(equipamento);
        }

        public override void Atualizar(Equipamento equipamento)
        {
            base.Atualizar(equipamento);
        }

        public override void Deletar(Equipamento equipamento)
        {
            base.Deletar(equipamento);
        }

        public IList<Equipamento> Listar()
        {
            return _contexto.Equipamento.OrderBy(c => c.Nome).ToList();
        }
        
        public IList<Equipamento> BuscarPorIds(int[] ids)
        {
            return _contexto.Equipamento.Where(w => ids.Contains(w.Id)).ToList();
        }
    }
}
