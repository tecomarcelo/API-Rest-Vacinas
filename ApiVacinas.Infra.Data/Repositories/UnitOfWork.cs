using ApiVacinas.Infra.Data.Contexts;
using ApiVacinas.Infra.Data.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiVacinas.Infra.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        //atributo
        private readonly SqlServerContext _context;
        private IDbContextTransaction _transaction;

        //construtor da injeção de dependência
        public UnitOfWork(SqlServerContext context)
        {
            _context = context;
        }


        public void BeginTransaction()
        {
            _transaction = _context.Database.BeginTransaction();
        }

        public void Commit()
        {
            _transaction.Commit();
        }

        public void Rollback()
        {
            _transaction.Rollback();
        }

        #region Métodos para acesso aos repositórios
        
        public IEntidadeRepository EntidadeRepository => new EntidadeRepository(_context);

        public IVacinaRepository VacinaRepository => new VacinaRepository(_context);

        public IUsuarioRepository UsuarioRepository => new UsuarioRepository(_context);
        
        #endregion
    }
}
