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

        public ResultService(IResultRepository resultRepository)
        {
            _resultRepository = resultRepository;
        }

        public IEnumerable<ScoreResult> GetAllResult()
        {
            var res = _resultRepository.GetAllResult();
            List<ScoreResult> scoreResults = new List<ScoreResult>();

            foreach (var result in res)
            {
                Enum.TryParse(result.Type, out ScoreType scoreType);

                scoreResults.Add( new ScoreResult { 
                    QuizName = result.QuizName,
                    Type = scoreType,
                    Date = result.Date,
                    QuestionAmount = result.QuestionAmount,
                    AllPosiblePoints = result.AllPosiblePoints,
                    AllGoodAnswers = result.AllGoodAnswers,
                    PointScore = result.PointScore,
                    PercentScore = result.PercentScore
                });
            }

            return scoreResults;
        }

        public IEnumerable<ScoreResult> GetResultByQuizName(string name)
        {
            var res = _resultRepository.GetResultByQuizName(name);
            List<ScoreResult> scoreResults = new List<ScoreResult>();

            foreach (var result in res)
            {
                Enum.TryParse(result.Type, out ScoreType scoreType);

                scoreResults.Add(new ScoreResult
                {
                    QuizName = result.QuizName,
                    Type = scoreType,
                    Date = result.Date,
                    QuestionAmount = result.QuestionAmount,
                    AllPosiblePoints = result.AllPosiblePoints,
                    AllGoodAnswers = result.AllGoodAnswers,
                    PointScore = result.PointScore,
                    PercentScore = result.PercentScore
                });
            }

            return scoreResults;
        }

        public bool SaveResult(ScoreResult result)
        {
            return _resultRepository.CreateResult(new ScoreResultEntity
            {
                QuizName = result.QuizName,
                Type = result.Type.ToString(),
                Date = result.Date,
                QuestionAmount = result.QuestionAmount,
                AllPosiblePoints = result.AllPosiblePoints,
                AllGoodAnswers = result.AllGoodAnswers,
                PointScore = result.PointScore,
                PercentScore = result.PercentScore
            });

        }
    }
}
