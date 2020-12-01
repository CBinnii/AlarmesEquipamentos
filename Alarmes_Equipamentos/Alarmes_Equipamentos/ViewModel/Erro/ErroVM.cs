using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Alarmes_Equipamentos.ViewModel.Erro
{
    public class ErroVM
    {
        public int? Id { get; set; }

        public string Mensagem { get; set; }

        public int StatusCode { get; set; }
    }
}