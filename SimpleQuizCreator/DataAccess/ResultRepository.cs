using SimpleQuizCreator.Interfaces;
using SimpleQuizCreator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleQuizCreator.DataAccess
{
    public class ResultRepository : IResultRepository
    {
        public bool CreateResult(ScoreResultEntity scoreResult)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ScoreResultEntity> GetAllResult()
        {
            throw new NotImplementedException();
        }
    }
}
