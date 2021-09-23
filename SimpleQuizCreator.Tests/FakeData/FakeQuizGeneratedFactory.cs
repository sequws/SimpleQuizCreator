using SimpleQuizCreator.Common;
using SimpleQuizCreator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleQuizCreator.Tests.FakeData
{
    public static class FakeQuizGeneratedFactory
    {
        public static QuizGenerated Clear_NoSelected()
        {
            QuizGenerated quiz = new QuizGenerated
            {
                Name = "QuizGeneratedClear",
                Questions = new List<Question>()
                {
                    new Question { QuestionText = "Question 1", Answers = new List<Answer> {
                        new Answer { AnswerText = "Answer 1 - good", IsCorrect = true},
                        new Answer { AnswerText = "Answer 2", IsCorrect = false },
                        new Answer { AnswerText = "Answer 3", IsCorrect = false },
                    }},
                    new Question { QuestionText = "Question 2", Answers = new List<Answer> {
                        new Answer { AnswerText = "Answer 1", IsCorrect = false },
                        new Answer { AnswerText = "Answer 2 - good", IsCorrect = true },
                        new Answer { AnswerText = "Answer 3", IsCorrect = false },
                    }},
                    new Question { QuestionText = "Question 3", Answers = new List<Answer> {
                        new Answer { AnswerText = "Answer 1", IsCorrect = false },
                        new Answer { AnswerText = "Answer 2", IsCorrect = false },
                        new Answer { AnswerText = "Answer 3 - good", IsCorrect = true },
                    }},
                }
            };
            return quiz;
        }

        public static QuizGenerated AllGoodAnswersSelected()
        {
            QuizGenerated quiz = new QuizGenerated
            {
                Name = "QuizGenerated",
                Questions = new List<Question>()
                {
                    new Question { QuestionText = "Question 1", Answers = new List<Answer> {
                        new Answer { AnswerText = "Answer 1 - good", IsCorrect = true, IsSelected = true },
                        new Answer { AnswerText = "Answer 2", IsCorrect = false },
                        new Answer { AnswerText = "Answer 3", IsCorrect = false },
                    }},
                    new Question { QuestionText = "Question 2", Answers = new List<Answer> {
                        new Answer { AnswerText = "Answer 1", IsCorrect = false },
                        new Answer { AnswerText = "Answer 2 - good", IsCorrect = true, IsSelected = true },
                        new Answer { AnswerText = "Answer 3", IsCorrect = false },
                    }},
                    new Question { QuestionText = "Question 3", Answers = new List<Answer> {
                        new Answer { AnswerText = "Answer 1", IsCorrect = false },
                        new Answer { AnswerText = "Answer 2", IsCorrect = false },
                        new Answer { AnswerText = "Answer 3 - good", IsCorrect = true, IsSelected = true },
                    }},
                }
            };
            return quiz;
        }



        public static QuizGenerated AllGoodAnswersSelected_OneBad()
        {
            QuizGenerated quiz = new QuizGenerated
            {
                Name = "QuizGenerated2",
                Questions = new List<Question>()
                {
                    new Question { QuestionText = "Question 1", Answers = new List<Answer> {
                        new Answer { AnswerText = "Answer 1 - good", IsCorrect = true, IsSelected = true },
                        new Answer { AnswerText = "Answer 2", IsCorrect = false },
                        new Answer { AnswerText = "Answer 3", IsCorrect = false, IsSelected = true },
                    }},
                    new Question { QuestionText = "Question 2", Answers = new List<Answer> {
                        new Answer { AnswerText = "Answer 1", IsCorrect = false },
                        new Answer { AnswerText = "Answer 2 - good", IsCorrect = true, IsSelected = true },
                        new Answer { AnswerText = "Answer 3", IsCorrect = false },
                    }},
                    new Question { QuestionText = "Question 3", Answers = new List<Answer> {
                        new Answer { AnswerText = "Answer 1", IsCorrect = false },
                        new Answer { AnswerText = "Answer 2", IsCorrect = false },
                        new Answer { AnswerText = "Answer 3 - good", IsCorrect = true, IsSelected = true },
                    }},
                }
            };
            return quiz;
        }

        /// <summary>
        /// Generate custom quiz
        /// </summary>
        /// <param name="question">number of question</param>
        /// <param name="answers">number of answers in each question</param>
        /// <param name="goodAnswers">first {X} answers in each question will be marked as good </param>
        /// <returns></returns>
        public static QuizGenerated GenerateClearQuiz(int questionNr =3, byte answersNr = 3, byte goodAnswersNr = 1, bool selectAllCorrect=false)
        {
            QuizGenerated genQuiz = new QuizGenerated();

            QuizSettings settings = new QuizSettings
            {
                AllowReturn = false,
                AutogenerateAnswers = answersNr,
                QuestionLimit = questionNr,
                ScoreType = ScoreType.Custom,
            };

            genQuiz.QuizSettings = settings;

            for (int x = 0; x< questionNr; x++)
            {
                var question = new Question();
                question.QuestionText = $"Question {x + 1}";

                for (int y = 0; y < answersNr; y++)
                {
                    var answer = new Answer();
                    answer.AnswerText = $"Answer {y + 1}";

                    if(y < goodAnswersNr)
                    {
                        answer.AnswerText += " - good";
                        answer.IsCorrect = true;
                        answer.IsSelected = selectAllCorrect;
                    }
                    question.Answers.Add(answer);
                }
                genQuiz.Questions.Add(question);
            }

            return genQuiz;
        }
    }
}
