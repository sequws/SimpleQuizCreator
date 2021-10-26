using AutoMapper;
using SimpleQuizCreator.Common;
using SimpleQuizCreator.Interfaces;
using SimpleQuizCreator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleQuizCreator.Services
{
    public class ResultService : IResultService
    {
        IResultRepository _resultRepository;
        private readonly IMapper _mapper;

        public ResultService(IResultRepository resultRepository, IMapper mapper)
        {
            _resultRepository = resultRepository;
            _mapper = mapper;
        }

        public IEnumerable<ScoreResult> GetAllResult()
        {
            var res = _resultRepository.GetAllResult();
            return _mapper.Map<IEnumerable<ScoreResult>>(res);
        }

        public IEnumerable<ScoreResult> GetResultByQuizName(string name)
        {
            var res = _resultRepository.GetResultByQuizName(name);
            return _mapper.Map<IEnumerable<ScoreResult>>(res);
        }

        public bool SaveResult(ScoreResult result)
        {
            return _resultRepository.CreateResult(
                _mapper.Map<ScoreResultEntity>(result));
        }
    }
}
