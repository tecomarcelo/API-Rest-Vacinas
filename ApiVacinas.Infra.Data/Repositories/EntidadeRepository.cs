using ApiVacinas.Infra.Data.Contexts;
using ApiVacinas.Infra.Data.Entities;
using ApiVacinas.Infra.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiVacinas.Infra.Data.Repositories
{
    public class EntidadeRepository : IEntidadeRepository
    {
        //atributo
        private readonly SqlServerContext _context;

        //construtor para injeção de dependência
        public EntidadeRepository(SqlServerContext context)
        {
            _context = context;
        }


        public void Inserir(Entidade entity)
        {
            _context.Entry(entity).State = EntityState.Added;
            _context.SaveChanges();
        }

        public void Alterar(Entidade entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Excluir(Entidade entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public List<Entidade> Consultar()
        {
            return _context.Entidade
                .OrderBy(e => e.Nome)
                .ToList();
        }

        public Entidade ObterPorId(Guid id)
        {
            return _context.Entidade
                .FirstOrDefault(e => e.IdEntidade.Equals(id));

        }

        public Entidade ObterPorCpf(string cpf)
        {
            return _context.Entidade
                .FirstOrDefault(e => e.Cpf.Equals(cpf));
        }

        public List<Entidade> ObterPorNome(string nome)
        {
            return _context.Entidade
                .Where(e => e.Nome.Contains(nome))
                .OrderBy(e => e.Nome)
                .ToList();
        }
    }
}
