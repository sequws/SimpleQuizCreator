using MdXaml;
using SimpleQuizCreator.Interfaces;
using SimpleQuizCreator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
                sb.Append($"**Error {i}: **");
                sb.Append("%{color:red}");
                sb.Append(EscapeStringForMarkdown(error));
                sb.AppendLine("%  \n");
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
                sb.Append( EscapeStringForMarkdown(question.QuestionText));
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
                    sb.Append(EscapeStringForMarkdown( answer.AnswerText));
                    sb.Append("%  \n");
                }
                sb.AppendLine("  \n");
            }

            return sb.ToString();
        }

        private string EscapeStringForMarkdown(string input)
        {
            //result = Regex.Replace(input, "\\*", "\\\\*");
            var result = input.Replace("*", "\\*");
            return result;
        }

        public string GenerateResultPreview(QuizGenerated quizGenerated, ScoreResult scoreResult)
        {
            StringBuilder sb = new StringBuilder();

            int i = 0;
            foreach (var question in quizGenerated.Questions)
            {
                sb.Append($"**Question {i}: ");
                sb.Append(EscapeStringForMarkdown(question.QuestionText));
                sb.Append(GetQuestionPoints(scoreResult, i));
                sb.AppendLine("**  ");

                foreach (var answer in question.Answers)
                {
                    if(answer.IsSelected)
                    {
                        sb.Append(" **[x]**  ");
                    }
                    if (answer.IsCorrect)
                    {                        
                        sb.Append(" %{color:green} ");
                    }
                    else
                    {
                        sb.Append(" %{color:red} ");
                    }
                    sb.Append(EscapeStringForMarkdown(answer.AnswerText));
                    sb.Append("%  \n");
                }
                sb.AppendLine("  \n");
                i++;
            }

            return sb.ToString();
        }


        private string GetQuestionPoints(ScoreResult scoreResult, int questionNr)
        {
            var sb = new StringBuilder();

            if(scoreResult.QuestionScore.Count > 0 &&
                scoreResult.QuestionScore.Count >= questionNr)
            {
                var pts = scoreResult.QuestionScore[questionNr];

                sb.Append(" %{color:blue} ");
                sb.Append(pts);
                sb.AppendLine("%  ");
            }
            return sb.ToString();
        }
    }
}
