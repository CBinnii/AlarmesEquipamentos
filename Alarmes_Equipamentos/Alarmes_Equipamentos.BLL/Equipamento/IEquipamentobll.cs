using System;
using System.Collections.Generic;
using Alarmes_Equipamentos.DAL.Model;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;

namespace Alarmes_Equipamentos.BLL
{
    public interface IEquipamentoBLL
    {
        void Adicionar(Equipamento equipamento);
        void Atualizar(Equipamento equipamento);
        void Deletar(Equipamento equipamento);
        IList<Equipamento> Listar();
        Equipamento BuscarPorId(object id);
        IList<Equipamento> BuscarPorIds(int[] ids);
    }
}
