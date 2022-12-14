using ApiVacinas.Infra.Data.Entities;
using ApiVacinas.Services.Requests;
using AutoMapper;

namespace ApiVacinas.Services.Mappings
{
    /// <summary>
    /// Mapeamento de objetos REQUEST para ENTITY (INPUT da API)
    /// </summary>
    public class RequestToEntityMap : Profile
    {
        public RequestToEntityMap()
        {
            CreateMap<EntidadePostRequest, Entidade>();
            CreateMap<EntidadePutRequest, Entidade>();

            CreateMap<VacinaPostRequest, Vacina>();
            CreateMap<VacinaPutRequest, Vacina>();
        }
    }
}
