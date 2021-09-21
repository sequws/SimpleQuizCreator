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
        public static QuizGenerated GenerateClearWithAllGoodNoSelected()
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

        public static QuizGenerated GenerateAllGoodAnswersSelected()
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



        public static QuizGenerated GenerateAllGoodAnswersSelectedWithOneBad()
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
    }
}
