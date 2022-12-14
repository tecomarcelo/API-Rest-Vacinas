using ApiVacinas.Infra.Data.Entities;
using ApiVacinas.Services.Responses;
using AutoMapper;

namespace ApiVacinas.Services.Mappings
{
    /// <summary>
    /// Mapeamento de objetos ENTITY para RESPONSE (OUTPUT da APÍ)
    /// </summary>
    public class EntityToResponseMap : Profile
    {
        public EntityToResponseMap()
        {
            CreateMap<Entidade, EntidadeResponse>();

            CreateMap<Vacina, VacinaResponse>();
        }
    }
}
