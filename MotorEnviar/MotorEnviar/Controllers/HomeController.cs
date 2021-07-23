using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MotorEnviar.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MotorEnviar;
using PrimeiroProjeto.Libranes.Email;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace MotorEnviar.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contato(IFormFile file)
        {

            Contato contato = new Contato();


            contato.Remetente = HttpContext.Request.Form["remetente"];
            contato.Senha = HttpContext.Request.Form["senha"];
            contato.Caminho = HttpContext.Request.Form["caminho"];
            contato.Email = HttpContext.Request.Form["email"];
            contato.Assunto = HttpContext.Request.Form["assunto"];
            contato.Descricao = HttpContext.Request.Form["descricao"];

            GerenciarEmail.EnviarEmail(contato);
            

            return new ContentResult() { Content = "Dados recebidos com sucesso!" };
        }
    }
}
