using SimpleQuizCreator.Interfaces;
using SimpleQuizCreator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleQuizCreator.Services
{
    public class QuizService : IQuizService
    {
        ILoader<QuizFile> _quizLoader;
        IParser<Quiz> _quizParser;
        private readonly List<Quiz> _listOfQuizzes = new List<Quiz>();

        public QuizService()
        {

        }

        public QuizService( ILoader<QuizFile> quizLoader, IParser<Quiz> quizParser)
        {
            _quizLoader = quizLoader;
            _quizParser = quizParser;

            LoadQuizzes();
        }

        private void LoadQuizzes()
        {
            foreach (var quizFile in _quizLoader.LoadData())
            {
                if (_quizParser.TryParse(quizFile.Lines))
                {
                    var quiz = _quizParser.GetData();
                    quiz.Name = quizFile.Name;

                    _listOfQuizzes.Add(quiz);
                }
            }
        }

        public IEnumerable<Quiz> GetAllQuizzes()
        {
            return new List<Quiz>( _listOfQuizzes);
        }

        public Quiz GetQuizByName(string name)
        {
            return _listOfQuizzes.FirstOrDefault(x => string.Equals(name, x.Name));
        }
    }
}
