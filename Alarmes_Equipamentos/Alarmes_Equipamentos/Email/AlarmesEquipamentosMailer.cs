using RazorMailer.Core;
using RazorMailer.Core.Dispatchers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;

namespace Alarmes_Equipamentos.Email
{
    public class AlarmesEquipamentosMailer
    {
        public enum Templates
        {
            AlarmeAlto
        }

        private readonly RazorMailerEngine _mailerEngine;

        /// <summary>
        /// The default constructor that initialises RazorMailer with it's built in SmtpDispatcher
        /// </summary>
        public AlarmesEquipamentosMailer() : this(new SmtpDispatcher())
        {
        }

        /// <summary>
        /// This overload allows us to pass in a mock dispatcher for testing purposes
        /// </summary>
        public AlarmesEquipamentosMailer(IEmailDispatcher dispatcher)
        {
            // Default to the built in Smtp engine
            _mailerEngine = new RazorMailerEngine(@"email\templates", "noreplay@abc.com.br", "Alarmes e Equipamentos", dispatcher);
        }

        /// <summary>
        /// A simple method that asynchronously send a email based on a Razor layout and partial 
        /// </summary>
        public async Task Enviar<T>(Templates template, string assunto, ICollection<string> para, T model) where T : class
        {
            foreach (string p in para)
            {
                MailMessage email = _mailerEngine.Create(template.ToString(), model, p, assunto);
                await _mailerEngine.SendAsync(email);
            }
        }
    }
}