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
            if (quiz.CorrectlyLoaded)
            {
                return GenerateCorrectQuizPreview(quiz);
            }
            else
            {
                return GenerateErrorsPreview(quiz);
            }
        }

        private string GenerateErrorsPreview(Quiz quiz)
        {
            StringBuilder sb = new StringBuilder();

            int i = 0;
            foreach (var error in quiz.Errors)
            {
                i++;
                sb.Append($"**Error {i}: ");
                sb.Append("%{color:red}");
                sb.Append(error);
                sb.AppendLine("%**  \n");
            }

            return sb.ToString();
        }

        private string GenerateCorrectQuizPreview(Quiz quiz)
        {
            StringBuilder sb = new StringBuilder();

            int i = 0;
            foreach (var question in quiz.Questions)
            {
                i++;
                sb.Append($"**Question {i}: ");
                sb.Append(question.QuestionText);
                sb.AppendLine("**  ");

                foreach (var answer in question.Answers)
                {
                    if (answer.IsCorrect)
                    {
                        sb.Append(" %{color:green} ");
                    }
                    else
                    {
                        sb.Append(" %{color:red} ");
                    }
                    sb.Append(answer.AnswerText);
                    sb.Append("%  \n");
                }
                sb.AppendLine("  \n");
            }

            return sb.ToString();
        }
    }
}
