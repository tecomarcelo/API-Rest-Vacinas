using ApiVacinas.Infra.Data.Entities;
using ApiVacinas.Infra.Data.Interfaces;
using ApiVacinas.Messages.Services;
using ApiVacinas.Services.Requests;
using ApiVacinas.Services.Utils;
using Bogus;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiVacinas.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordRecoverController : ControllerBase
    {
        //atributos
        private readonly IUnitOfWork _unitOfWork;
        private readonly MailService _mailService;

        //construtor da injeção de dependência
        public PasswordRecoverController(IUnitOfWork unitOfWork, MailService mailService)
        {
            _unitOfWork = unitOfWork;
            _mailService = mailService;
        }

        [HttpPost]
        public IActionResult Post(PasswordRecoverPostRequest request)
        {
            try
            {
                //buscar usuario no banco de dados através do email
                var usuario = _unitOfWork.UsuarioRepository.Obter(request.Email);

                //verificar se o usuario foi encontrado
                if(usuario != null)
                {
                    //Enviando email de recuperação de senha
                    var novaSenha = new Faker().Internet.Password();
                    EnviarEmailDeRecuperacaoDeSenha(usuario, novaSenha);

                    //Atualizando a senha no banco de dados
                    usuario.Senha = Criptografia.GetMD5(novaSenha);
                    _unitOfWork.UsuarioRepository.Alterar(usuario);

                    return StatusCode(200, new { message = "Recuperação de senha realizada com sucesso, por favor verifique seu email." });
                }
                else
                {
                    return StatusCode(422, new { message = "O email informado não foi encontrado, tente novamente." });
                }
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        private void EnviarEmailDeRecuperacaoDeSenha(Usuario usuario, string novaSenha)
        {
            var subject = "Recuperação de senha de usuário - Projeto Vacinas";

            var body = $@"
                     <div style='text-align: center; margin: 40px; padding: 60px; border: 2px solid #ccc; font-size: 16pt;'>
                     <img src=
                     'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQCN8YAhu_mK4wRupzBUbC7-sw9k5zo9ntROQ&usqp=CAU' width: 180px height:180px />
                     <p style='font-size: 22pt;'>Projeto Vacinas Recuperação de Senha.</p>
                     <br /><br />
                     Olá <strong>{usuario.Nome}</strong>,
                     <br /><br />
                     O sistema gerou um nova senha para que você possa acessar sua conta.<br />
                     Por favor utilize a nova senha: <strong>{novaSenha}</strong>
                     <br /><br />
                     Ao acessar o sistema, atualize a senha para outra de sua preferência. Não esqueça!
                     <br /><br />
                     att.<br />
                     Equipe Projeto Vacinas.
                     </div>
            ";

            _mailService.SendMail(usuario.Email, subject, body);
        }
    }
}
