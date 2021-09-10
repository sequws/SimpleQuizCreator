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
        Quiz parsedQuiz = null;

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


            return true;
        }

        public Quiz GetData()
        {
            return parsedQuiz;
        }
    }
}
