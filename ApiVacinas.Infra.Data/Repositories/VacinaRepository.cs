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
    public class VacinaRepository : IVacinaRepository
    {
        //atributo
        private readonly SqlServerContext _context;

        public VacinaRepository(SqlServerContext context)
        {
            _context = context;
        }



        public void Inserir(Vacina entity)
        {
            _context.Entry(entity).State = EntityState.Added;
            _context.SaveChanges();
        }

        public void Alterar(Vacina entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Excluir(Vacina entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public List<Vacina> Consultar()
        {
            return _context.Vacina
                .Include(v => v.Entidade) //Inner join (Junção pela chave)
                .OrderBy(v => v.NomeVacina)
                .ToList();
        }

        public Vacina ObterPorId(Guid id)
        {
            return _context.Vacina
                .Include(v => v.Entidade) //Inner join (Junção pela chave)
                .FirstOrDefault(v => v.IdVacina.Equals(id));
        }

        public List<Vacina> ObterPorNomeVacina(string nomeVacina)
        {
            return _context.Vacina
                .Include(v => v.Entidade) //Inner join (Junção pela chave)
                .Where(v => v.NomeVacina.Contains(nomeVacina))
                .OrderBy(v => v.NomeVacina)
                .ToList();
        }

        public Vacina ObterPorLote(string lote)
        {
            return _context.Vacina
                .Include(v => v.Entidade) //Inner join (Junção pela chave)
                .FirstOrDefault(v => v.Lote.Equals(lote));
        }
    }
}
