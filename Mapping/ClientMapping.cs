using static System.Runtime.InteropServices.JavaScript.JSType;
using AutoMapper;
using Innovative.Backend.Data.Dtos;
using Innovative.Backend.Models;
namespace Innovative.Backend.Mapping
{
    public class ClientMapping: Profile
    {
        public ClientMapping()
        {
            CreateMap<AddClientDto, Client>().ReverseMap();
            CreateMap<Client, ListingClientDo>().ReverseMap();
            CreateMap<UpdateClientDto, Client>().ReverseMap();
        }
    }
}
