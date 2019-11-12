using AutoMapper;
using BRQ.HRTProject.Aplicacao.AutoMapper.Profiles;
using System;
using System.Collections.Generic;
using System.Text;

namespace BRQ.HRTProject.Aplicacao.AutoMapper
{
    public class AutoMapperConfiguration
    {
        public static MapperConfiguration ConfigureMappings()
        {
            var mapperConfiguration = new MapperConfiguration(cfg => {
                cfg.AddProfile(new EntityToViewModel());
            });
            return mapperConfiguration;
        }
    }
}
