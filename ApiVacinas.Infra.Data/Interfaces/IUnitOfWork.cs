using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiVacinas.Infra.Data.Interfaces
{
    /// <summary>
    /// Interface de unidade de trabalho do EntityFramework
    /// </summary>
    public interface IUnitOfWork
    {
        #region Métodos para controle de transição

        void BeginTransaction();
        void Commit();
        void Rollback();

        #endregion

        #region Metodos para acesso aos repositorios

        public IEntidadeRepository EntidadeRepository { get; }
        public IVacinaRepository VacinaRepository { get; }
        public IUsuarioRepository UsuarioRepository { get; }

        #endregion
    }
}
