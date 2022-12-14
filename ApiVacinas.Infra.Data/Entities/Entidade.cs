﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiVacinas.Infra.Data.Entities
{
    public class Entidade
    {
        public Guid IdEntidade { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Cpf { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime DataAlteracao { get; set; }

        #region Relacionamentos

        public List<Vacina>? Vacinas { get; set; }

        #endregion
    }
}
