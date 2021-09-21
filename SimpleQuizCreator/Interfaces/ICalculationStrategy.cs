using SimpleQuizCreator.Models;
using System.Collections.Generic;

namespace SimpleQuizCreator.Interfaces
{
    public interface ICalculationStrategy
    {
        ScoreResult Calculate(List<Question> questions);
    }
}