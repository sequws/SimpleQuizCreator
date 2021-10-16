using SimpleQuizCreator.Interfaces;
using SimpleQuizCreator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleQuizCreator.Common
{
    public class QuizPreviewGenerator : IQuizPreviewGenerator
    {
        public string GeneratePreview(Quiz quiz)
        {
            StringBuilder sb = new StringBuilder();

            int i = 0;
            foreach (var question in quiz.Questions)
            {
                sb.Append($"**Question {i}: ");
                sb.Append(question.QuestionText);
                sb.AppendLine("**  ");

                foreach (var answer in question.Answers)
                {
                    if(answer.IsCorrect)
                    {
                        sb.Append("- %{color:green} ");
                    } 
                    else
                    {
                        sb.Append("- %{color:red} ");
                        //sb.Append("- ");
                    }
                    sb.Append(answer.AnswerText);
                    sb.AppendLine("\n");
                }

                i++;
            }

            return sb.ToString();
        }
    }
}
