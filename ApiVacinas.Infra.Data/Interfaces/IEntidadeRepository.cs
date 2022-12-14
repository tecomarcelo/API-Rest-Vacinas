using ApiVacinas.Infra.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiVacinas.Infra.Data.Interfaces
{
    /// <summary>
    /// Interface de repositorio para operações de empresa
    /// </summary>
    public interface IEntidadeRepository : IBaseRepository<Entidade>
    {
        /// <summary>
        /// Metodo para consultar uma criança atraves do CPF
        /// </summary>
        /// <param name="cpf"></param>
        /// <returns>Um unico CPF</returns>
        Entidade ObterPorCpf(string cpf);

        /// <summary>
        /// Metodo para retornar Entidade (criança) baseado no nome
        /// </summary>
        /// <param name="nome"></param>
        /// <returns>Uma ou mais entidades</returns>
        List<Entidade> ObterPorNome(string nome);
    }
}
