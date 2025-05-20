using Microsoft.AspNetCore.Mvc;
using NotifyX.Data;
using System.Net.Mail;
using System.Net;

namespace NotifyX.Controllers
{
    public class EmailsController : Controller
    {
        private readonly AppDbContext _context;

        public EmailsController(AppDbContext context) 
        {
            _context = context;
        }

        public IActionResult Send() 
        {
            var clientes = _context.Usuarios.ToList();
            return View(clientes);
        }

        [HttpPost]
        public IActionResult SendEmail(List<string> clientesSelecionados, string mensagem)
        {

           
            if (clientesSelecionados == null || !clientesSelecionados.Any())
            {
                ModelState.AddModelError("clientesSelecionados", "Selecione pelo menos um destinatário.");
            }

            
            if (string.IsNullOrWhiteSpace(mensagem))
            {
                ModelState.AddModelError("mensagem", "A mensagem não pode estar vazia.");
            }

            
            if (!ModelState.IsValid)
            {
                return View("Send", _context.Usuarios.ToList());
            }

            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("fabricio.batista.r@gmail.com", "yyxo mtop papu obzx\r\n"),
                EnableSsl = true,
            };

            foreach (var destinatario in clientesSelecionados)
            {
                var mailMessage = new MailMessage
                {
                    From = new MailAddress("fabricio.batista.r@gmail.com"),
                    Subject = "Notificação NotifyX",
                    Body = mensagem,
                    IsBodyHtml = true,
                };
                mailMessage.To.Add(destinatario);

                smtpClient.Send(mailMessage);
            }

            TempData["MensagemSucesso"] = "E-mail enviado com sucesso!";
            

            return RedirectToAction("Send");
        }
    }
}
