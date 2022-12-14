using ApiVacinas.Infra.Data.Interfaces;
using ApiVacinas.Services.Authorization;
using ApiVacinas.Services.Requests;
using ApiVacinas.Services.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiVacinas.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        //atributo
        private readonly JwtService _jwtService;
        private readonly IUnitOfWork _unitOfWork;

        public LoginController(JwtService jwtService, IUnitOfWork unitOfWork)
        {
            _jwtService = jwtService;
            _unitOfWork = unitOfWork;
        }


        [HttpPost]
        public IActionResult Post(LoginPostRequest request)
        {
            try
            {
                //obter o usuário no banco de dados
                var usuario = _unitOfWork.UsuarioRepository.Obter(request.Email, Criptografia.GetMD5(request.Senha));

                //verificar se o usuário foi encontrado
                if(usuario != null)
                {
                    return StatusCode(200, new
                    {
                        message = "Autenticação realizada com sucesso.",
                        usuario = usuario.Email,
                        token = _jwtService.GenerateToken(usuario.Email)
                    });
                }
                else
                {
                    return StatusCode(401, new { message = "Acesso negado. Usuário inválido." });
                }
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
