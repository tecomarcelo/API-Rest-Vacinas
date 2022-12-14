using ApiVacinas.Infra.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiVacinas.Infra.Data.Interfaces
{
    /// <summary>
    /// Interface de reposirio para operações de usuário
    /// </summary>
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
        //Consultar 1 usuário através do email
        Usuario Obter(string email);
        
        //Consultar 1 usuário através do email e senha
        Usuario Obter(string email, string senha);
    }
}
