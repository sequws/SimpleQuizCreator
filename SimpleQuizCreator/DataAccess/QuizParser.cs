using SimpleQuizCreator.Abstractions;
using SimpleQuizCreator.Interfaces;
using SimpleQuizCreator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleQuizCreator.DataAccess
{
    public class QuizParser : Parser, IParser<Quiz>
    {
        Quiz parsedQuiz = new Quiz();

        public QuizParser()
        {
            
        }

        public override bool TryParse(string input)
        {
            return true;
        }

        public override bool TryParse(List<string> input)
        {
            ClearData();

            Question lastQuestion = null;
            int questionNumber = 0;
            int answerCounter = 0;
            int goodAnswer = 0;
            bool res = true;

            foreach (var line in input)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }
                var trimmedLine = line.Trim();
                if (trimmedLine.StartsWith("#"))
                {
                    continue;
                }

                if (trimmedLine.StartsWith("[q]") || trimmedLine.StartsWith("[Q]"))
                {
                    questionNumber++;
                    answerCounter = 0;
                    goodAnswer = 0;
                    Question question = new Question();
                    question.QuestionText = trimmedLine.Substring(3).Trim();
                    lastQuestion = question;
                    parsedQuiz.Questions.Add(question);
                }
                else if (trimmedLine.StartsWith("[*]"))
                {
                    goodAnswer++;
                    Answer answer = new Answer
                    {
                        AnswerText = trimmedLine.Substring(3).Trim(),
                        IsCorrect = true
                    };

                    if (lastQuestion != null)
                    {
                        lastQuestion.Answers.Add(answer);
                    }
                }
                else
                {
                    answerCounter++;
                    Answer answer = new Answer
                    {
                        AnswerText = trimmedLine,
                        IsCorrect = false
                    };
                    if (lastQuestion != null)
                    {
                        lastQuestion.Answers.Add(answer);
                    }
                    else
                    {

                    }
                }              
            }
            if (parsedQuiz.QuestionAmount == 0)
            {
                AddError("No questions in the quiz!");
            }

            foreach (var question in parsedQuiz.Questions)
            {
                if (question.AnswersCount == 0)
                {
                    AddError($"Question: {question.QuestionText} - has no answers!");
                }
                else if (question.GoodAnswersCount == 0)
                {
                    AddError($"Question: {question.QuestionText} - has no correct answer!");
                }
                else if (question.AnswersCount > 9)
                {
                    AddError($"Question: {question.QuestionText} - has more than 9 answers!");
                }
            }
            if (ErrorCounter == 0)
            {
                parsedQuiz.CorrectlyLoaded = true;
            }
            else
            {
                parsedQuiz.CorrectlyLoaded = false;
                parsedQuiz.Errors = Errors;
                res = false;
            }
            return res;
        }

        public Quiz GetData()
        {
            return parsedQuiz;
        }
    }
}
