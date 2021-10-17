using SimpleQuizCreator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleQuizCreator.Interfaces
{
    public interface IQuizPreviewGenerator
    {
        string GeneratePreview(Quiz quiz);
        string GenerateResultPreview(QuizGenerated quizGenerated);
    }
}
