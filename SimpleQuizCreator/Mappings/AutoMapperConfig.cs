using AutoMapper;
using SimpleQuizCreator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleQuizCreator.Mappings
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
            => new MapperConfiguration(cfg =>
           {
               cfg.CreateMap<ScoreResult, ScoreResultEntity>();
               cfg.CreateMap<ScoreResultEntity, ScoreResult>();
           }).CreateMapper();
    }
}
