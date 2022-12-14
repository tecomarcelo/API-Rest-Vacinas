using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiVacinas.Infra.Data.Entities
{
    public class Vacina
    {
        public Guid IdVacina { get; set; }
        public string? NomeVacina { get; set; }
        public string? Lote { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime DataAlteracao { get; set; }

        public Guid IdEntidade { get; set; }



        #region Relacionamentos

        public Entidade Entidade { get; set; }

        #endregion
    }
}
