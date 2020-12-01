using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alarmes_Equipamentos.BLL
{
    public class BusinessException : Exception
    {
        public BusinessException(string mensagem, params object[] args) : base(string.Format(mensagem, args))
        {

        }
    }
}
