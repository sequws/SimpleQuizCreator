using SimpleQuizCreator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleQuizCreator.Interfaces
{
    public interface IResultService
    {
        IEnumerable<ScoreResult> GetAllResult();
        IEnumerable<ScoreResult> GetResultByQuizName(string name);
        bool SaveResult(ScoreResult result);
    }
}
