using Microsoft.AspNetCore.Http;
using MotorEnviar.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace PrimeiroProjeto.Libranes.Email
{
    public class GerenciarEmail
    {
        public static void EnviarEmail(Contato contato)
        {
            try
            {
                String line;
                StreamReader sr = new StreamReader(contato.Caminho + "\\" + contato.Email);
                line = sr.ReadLine();
                string[] emailValor;
                while (line != null)
                {
                    emailValor = line.Split(",");
                    envioMail(emailValor[0], emailValor[emailValor.Length - 1], contato);
                    line = sr.ReadLine();
                }

                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        static void envioMail(string nome, string endereco, Contato contato)
        {
            SmtpClient smtp = new SmtpClient("smtp.office365.com", 587);
            {
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(contato.Remetente, contato.Senha);
                smtp.EnableSsl = true;
            }
            MailMessage mensagem = new MailMessage();
            mensagem.From = new MailAddress(contato.Remetente);
            mensagem.To.Add(endereco);
            mensagem.Subject = (contato.Assunto);
            mensagem.Body = (contato.Descricao);
            mensagem.IsBodyHtml = true;
            try
            {
                smtp.Send(mensagem);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}

