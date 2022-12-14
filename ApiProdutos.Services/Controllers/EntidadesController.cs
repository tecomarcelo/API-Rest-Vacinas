using ApiVacinas.Services.Requests;
using ApiVacinas.Services.Responses;
using ApiVacinas.Infra.Data.Entities;
using ApiVacinas.Infra.Data.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace ApiVacinas.Services.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EntidadesController : ControllerBase
    {
        //atribuito
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        //contrutor para injeção de dependência
        public EntidadesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        [HttpPost]
        public IActionResult Post(EntidadePostRequest request)
        {
            try
            {
                //verificar se o CPF informado já esta cadastrado
                if (_unitOfWork.EntidadeRepository.ObterPorCpf(request.Cpf) != null)
                    //http 422 -> UNPROCESSABLE ENTITY
                    return StatusCode(422, new { message = "O CPF informado já está cadastrado." });

                var entidade = _mapper.Map<Entidade>(request);
                entidade.IdEntidade = Guid.NewGuid();
                entidade.DataInclusao = DateTime.Now;
                entidade.DataAlteracao = DateTime.Now;

                //gravar no banco de dados
                _unitOfWork.EntidadeRepository.Inserir(entidade);

                var response = _mapper.Map<EntidadeResponse>(entidade);

                //http 201 -> Success Created
                return StatusCode(201, response);
            }
            catch(Exception e)
            {
                //retornando status e mensagem de erro
                //http 500 -> Erro interno do sevidor
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(EntidadePutRequest request)
        {
            try
            {
                //pesquisando entidade pelo id
                var entidade = _unitOfWork.EntidadeRepository.ObterPorId(request.IdEntidade);

                //verificando se a entidade não foi encontrada
                if (entidade == null)
                    //http 422 -> Unprocessable Entity
                    return StatusCode(422, new { message = "Entidade não encontrada. Verifique o ID informado."});

                //verificando se o CPF informado já esta cadastrado em outra criança
                var registroCpf = _unitOfWork.EntidadeRepository.ObterPorCpf(request.Cpf);
                if (registroCpf != null && registroCpf.IdEntidade != entidade.IdEntidade)
                    //http 422 -> Unprocessabel Entity
                    return StatusCode(422, new { message = "O CPF informado já esta cadastrado para outra criança." });

                //atualizando os dados da Entidade
                _mapper.Map(request, entidade);
                entidade.DataAlteracao = DateTime.Now;

                _unitOfWork.EntidadeRepository.Alterar(entidade);

                var response = _mapper.Map<EntidadeResponse>(entidade);

                //http 201 -> Success Update
                return StatusCode(200, response);
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{idEntidade}")]
        public IActionResult Delete(Guid idEntidade)
        {
            try
            {
                //pesquisando entidade atraves do id
                var entidade = _unitOfWork.EntidadeRepository.ObterPorId(idEntidade);

                //verificando se a entidade não foi encontrada
                if (entidade == null)
                    //http 422 -> Unprocessable Entity
                    return StatusCode(422, new { message = "Entidade não encontrada. Verifique o ID informado." });

                //excluindo a empresa
                _unitOfWork.EntidadeRepository.Excluir(entidade);

                var response = _mapper.Map<EntidadeResponse>(entidade);

                //http 201 -> Success deleted
                return StatusCode(200, response);
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                //pesquisando as entidades
                var entidades = _unitOfWork.EntidadeRepository.Consultar();
                
                var lista = _mapper.Map<List<EntidadeResponse>>(entidades);

                if (lista.Count > 0)
                    return StatusCode(200, lista);
                else
                    return StatusCode(204); //sem conteudo.
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{idEntidade}")]
        public IActionResult GetById(Guid idEntidade)
        {
            try
            {
                //pesquisando entidade atraves do id
                var entidade = _unitOfWork.EntidadeRepository.ObterPorId(idEntidade);

                //verificando se a entidade foi encontrada
                if (entidade != null)
                {
                    var response = _mapper.Map<EntidadeResponse>(entidade);

                    return StatusCode(200, response);
                }
                else
                {
                    return StatusCode(204); //sem conteudo
                }
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        
    }
}
