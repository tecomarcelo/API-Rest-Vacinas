using ApiVacinas.Infra.Data.Contexts;
using ApiVacinas.Infra.Data.Entities;
using ApiVacinas.Infra.Data.Interfaces;
using ApiVacinas.Services.Requests;
using ApiVacinas.Services.Responses;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiVacinas.Services.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class VacinasController : ControllerBase
    {
        //atribuito
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        //contrutor para injeção de dependência
        public VacinasController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        [HttpPost]
        public IActionResult Post(VacinaPostRequest request)
        {
            try
            {
                //pesquisando Entidade associada pelo id
                var entidade = _unitOfWork.EntidadeRepository.ObterPorId(request.IdEntidade);
                if (entidade == null)
                    return StatusCode(422, new { message = "A Entidade informada não esta cadastrada." });

                var vacina = _mapper.Map<Vacina>(request);
                vacina.IdVacina = Guid.NewGuid();
                vacina.DataAlteracao = DateTime.Now;
                vacina.DataInclusao = DateTime.Now;

                _unitOfWork.VacinaRepository.Inserir(vacina);

                var response = _mapper.Map<VacinaResponse>(vacina);
                response.Entidade = _mapper.Map<EntidadeResponse>(entidade);
                //http 201 -> Success Created
                return StatusCode(201, response);
            }
            catch (Exception e)
            {
                //retornando status e mensagem de erro
                //http 500 -> Erro interno do sevidor
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(VacinaPutRequest request)
        {
            try
            {
                //pesquisando vacina pelo id
                var vacina = _unitOfWork.VacinaRepository.ObterPorId(request.IdVacina);

                //verificando se a vacina não foi encontrada
                if (vacina == null)
                    //http 422 -> Unprocessable Entity
                    return StatusCode(422, new { message = "Vacina não encontrada. Verifique o ID informado." });

                //pesquisando Entidade pelo id para associação
                var entidade = _unitOfWork.EntidadeRepository.ObterPorId(request.IdEntidade);
                if (entidade == null)
                    return StatusCode(422, new { message = "A Entidade informada não esta cadastrada." });

                //atualizando os dados da Vacina
                _mapper.Map(request, vacina);
                vacina.DataAlteracao = DateTime.Now;

                _unitOfWork.VacinaRepository.Alterar(vacina);

                var response = _mapper.Map<VacinaResponse>(vacina);
                response.Entidade = _mapper.Map<EntidadeResponse>(entidade);

                //http 201 -> Success Update
                return StatusCode(200, response);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{idVacina}")]
        public IActionResult Delete(Guid idVacina)
        {
            try
            {
                //pesquisando vacina atraves do id
                var vacina = _unitOfWork.VacinaRepository.ObterPorId(idVacina);

                //verificando se a vacina não foi encontrada
                if (vacina == null)
                    //http 422 -> Unprocessable Entity
                    return StatusCode(422, new { message = "Vacina não encontrada. Verifique o ID informado." });

                //excluindo a vacina
                _unitOfWork.VacinaRepository.Excluir(vacina);

                var response = _mapper.Map<VacinaResponse>(vacina);

                //http 201 -> Success deleted
                return StatusCode(200, response);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                //pesquisando as vacinas
                var vacinas = _unitOfWork.VacinaRepository.Consultar();

                var lista = _mapper.Map<List<VacinaResponse>>(vacinas);

                if (lista.Count > 0)
                    return StatusCode(200, lista);
                else
                    return StatusCode(204); //sem conteudo.
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{idVacina}")]
        public IActionResult GetById(Guid idVacina)
        {
            try
            {
                //pesquisando vacina atraves do id
                var vacina = _unitOfWork.VacinaRepository.ObterPorId(idVacina);

                //verificando se a vacina foi encontrada
                if (vacina != null)
                {
                    var response = _mapper.Map<VacinaResponse>(vacina);

                    return StatusCode(200, response);
                }
                else
                {
                    return StatusCode(204); //sem conteudo
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}

