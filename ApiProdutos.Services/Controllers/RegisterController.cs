using ApiVacinas.Infra.Data.Entities;
using ApiVacinas.Infra.Data.Interfaces;
using ApiVacinas.Services.Requests;
using ApiVacinas.Services.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiVacinas.Services.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        //atributo
        private readonly IUnitOfWork _unitOfWork;
        
        //contrutor para injeção de dependência
        public RegisterController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public IActionResult Post(RegisterPostRequest request)
        {
            try
            {
                //verificar se o usuário existe no banco de dados
                if (_unitOfWork.UsuarioRepository.Obter(request.Email) != null)
                    return StatusCode(422, new { message = "O email informado já está cadastrado no sistema." });

                var usuario = new Usuario
                {
                    IdUsuario = Guid.NewGuid(),
                    Nome = request.Nome,
                    Email = request.Email,
                    Senha = Criptografia.GetMD5(request.Senha),
                    DataInclusao = DateTime.Now
                };

                _unitOfWork.UsuarioRepository.Inserir(usuario);

                return StatusCode(201, new { message = "Usuário {Nome} cadastrado com sucesso." });
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
