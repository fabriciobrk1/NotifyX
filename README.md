# NotifyX 📩

## 📖 Sobre o Projeto
NotifyX é um sistema de gestão de usuários e envio de notificações via e-mail, desenvolvido em ASP.NET Core com Entity Framework e autenticação via Identity.

## 🚀 Funcionalidades
✅ Autenticação de usuários (Login, Registro, Logout)  
✅ CRUD de usuários (Criar, Editar, Deletar)  
✅ Envio de e-mails personalizados para clientes  

## 🛠️ Tecnologias Utilizadas
- ASP.NET Core 8
- Entity Framework Core
- MySQL
- Identity para autenticação
- SMTP para envio de e-mails

## 📦 Instalação
1️⃣ Clone o repositório:
   ```bash
   git clone https://github.com/fabriciobrk1/NotifyX.git
   cd NotifyX

## 📦 Configuração do Banco de Dados  
Antes de rodar o projeto, configure o **banco de dados** no arquivo `appsettings.json`:  

```json
"ConnectionStrings": {
    "DefaultConnection": "server=SEU_SERVIDOR;database=NotifyXDB;user=SEU_USUARIO;password=SUA_SENHA"
}
✅ Substitua os valores conforme seu banco de dados. ✅ Após configurar, execute as migrations para preparar a estrutura do banco:
dotnet ef database update

## 📧 Configuração do Envio de E-mail
Para enviar e-mails, edite diretamente no código (EmailsController.cs):

var smtpClient = new SmtpClient("smtp.gmail.com")
{
    Port = 587,
    Credentials = new NetworkCredential("SEU_EMAIL@gmail.com", "SENHA_DE_APLICATIVO"),
    EnableSsl = true,
};
