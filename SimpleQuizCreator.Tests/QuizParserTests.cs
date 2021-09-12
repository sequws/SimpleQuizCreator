﻿using SimpleQuizCreator.Abstractions;
using SimpleQuizCreator.DataAccess;
using SimpleQuizCreator.Interfaces;
using SimpleQuizCreator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SimpleQuizCreator.Tests
{

    public class QuizParserTests
    {
        [Fact]
        public void TryParse_ParseEmptyQuiz()
        {
            // Arrange
            IParser<Quiz> _quizParser = new QuizParser();
            List<string> fakeFile = new List<string>();

            // Act
            var res = _quizParser.TryParse(fakeFile);

            // Assert
            Assert.False( res);
            Assert.Equal(1, ((ErrorCollector)_quizParser).ErrorCounter);
        }

        [Fact]
        public void TryParse_QuizWithoutQuestion()
        {
            IParser<Quiz> _quizParser = new QuizParser();
            List<string> fakeFile = new List<string>
            {
                "Only answers in the quiz",
                "-answer 1",
                "-answer 2"
            };

            var res = _quizParser.TryParse(fakeFile);

            Assert.False(res);
            Assert.Equal(1, ((ErrorCollector)_quizParser).ErrorCounter);
            Assert.Equal("No questions in the quiz!", ((ErrorCollector)_quizParser).Errors[0]);
        }

        [Fact]
        public void TryParse_QuestionWithoutAnswers()
        {
            IParser<Quiz> _quizParser = new QuizParser();
            List<string> fakeFile = new List<string>
            {
                "[Q]Test question, without answers:",
                "",
                ""
            };

            var res = _quizParser.TryParse(fakeFile);

            Assert.False(res);
            Assert.Equal(1, ((ErrorCollector)_quizParser).ErrorCounter);
        }

        [Fact]
        public void TryParse_ManyQuestionOneWithoutAnswers()
        {
            IParser<Quiz> _quizParser = new QuizParser(); 
            var question3 = "Question 3 without answers:";
            List<string> fakeFile = new List<string>
            {
                "[Q]Correct question with answers:",
                "-ans1",
                "[*]-ans2",
                "[Q]Correct question2 with answers:",
                "-ans1",
                "[*]-ans2",
                $"[Q]{question3}"
            };

            var res = _quizParser.TryParse(fakeFile);

            Assert.False(res);
            Assert.Equal(1, ((ErrorCollector)_quizParser).ErrorCounter);
            Assert.Equal($"Question: {question3} - has no answers!", ((ErrorCollector)_quizParser).Errors[0]);
        }

        [Fact]
        public void TryParse_QuestionWithoutCorrectAnswer()
        {
            IParser<Quiz> _quizParser = new QuizParser();
            var question = "No question in quiz";
            List<string> fakeFile = new List<string>
            {
                $"[Q]{question}",
                "-answer 1",
                "-answer 2",
                "-answer 3",
                "-answer 4"
            };

            var res = _quizParser.TryParse(fakeFile);

            Assert.False(res);
            Assert.Equal(1, ((ErrorCollector)_quizParser).ErrorCounter);
            Assert.Equal($"Question: {question} - has no correct answer!", ((ErrorCollector)_quizParser).Errors[0]);
        }

        [Fact]
        public void TryParse_QuestionWithMoraThan9Answers()
        {
            IParser<Quiz> _quizParser = new QuizParser();
            var question = "No question in quiz";
            List<string> fakeFile = new List<string>
            {
                $"[Q]{question}",
                "-answer 1",
                "-answer 2",
                "[*]-answer 3",
                "-answer 4",
                "-answer 5",
                "-answer 6",
                "-answer 7",
                "-answer 8",
                "-answer 9",
                "-answer 10",
                "-answer 11",
            };

            var res = _quizParser.TryParse(fakeFile);

            Assert.False(res);
            Assert.Equal(1, ((ErrorCollector)_quizParser).ErrorCounter);
            Assert.Equal($"Question: {question} - has more than 9 answers!", ((ErrorCollector)_quizParser).Errors[0]);
        }
    }
}
