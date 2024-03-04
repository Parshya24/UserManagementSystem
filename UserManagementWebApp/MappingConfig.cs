using AutoMapper;
using CommonClassLibrary.Dto;

namespace UserManagementWebApp
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps ()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<Object, LoginResponseDto> ();
            });
            return mappingConfig;
        }
    }
}
