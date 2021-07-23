using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotorEnviar.Models
{
    public class Contato
    {
        public string Remetente { get; set; }

        public string Senha { get; set; }

        public string Caminho { get; set; }
        public string Email { get; set; }

        public string Assunto { get; set; }

        public string Descricao { get; set; }

    }
}
