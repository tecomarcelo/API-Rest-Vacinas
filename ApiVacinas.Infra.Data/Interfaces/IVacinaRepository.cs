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
    public interface IVacinaRepository : IBaseRepository<Vacina>
    {
        /// <summary>
        /// Metodo para retornar vacinas baseado no nome
        /// </summary>
        /// <param name="nomeVacina"></param>
        /// <returns>Um ou mais resultardos pelo nome ou parte</returns>
        List<Vacina> ObterPorNomeVacina(string nomeVacina);
        
        /// <summary>
        /// Metodo para consultar varias vacinas pelo Lote
        /// </summary>
        /// <param name="lote"></param>
        /// <returns>Obter registro pelo Lote da Vacina</returns>
        Vacina ObterPorLote(string lote);
    }
}
