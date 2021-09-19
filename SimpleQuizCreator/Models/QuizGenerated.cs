using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleQuizCreator.Models
{

    public class QuizGenerated
    {
        public string Name { get; set; }
        public List<Question> Questions = new List<Question>();
        public Question ActiveQuestion { get; set; }
        public int ActiveQuestionNumber { get; set; } = 0;

        public bool TestFinished { get; private set; } = false;
        public bool TestStarted { get; private set; } = false;

        private QuizSettings _quizSettings;
    }
}
