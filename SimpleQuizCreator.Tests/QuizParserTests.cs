using SimpleQuizCreator.Abstractions;
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
    }
}
