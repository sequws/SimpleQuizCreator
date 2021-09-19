using Prism.Mvvm;
using System.Collections.Generic;

namespace SimpleQuizCreator.Models
{

    public class QuizGenerated : BindableBase
    {
        public string Name { get; set; }
        public List<Question> Questions = new List<Question>();
        public Question ActiveQuestion { get; set; }
        //public int ActiveQuestionNumber { get; set; } = 0;

        private int _activeQuestionNumber = 0;
        public int ActiveQuestionNumber
        {
            get { return _activeQuestionNumber; }
            set { SetProperty(ref _activeQuestionNumber, value); }
        }

        public bool TestFinished { get; private set; } = false;
        public bool TestStarted { get; private set; } = false;

        public QuizSettings QuizSettings {get; set; }
        public int QuestionsNumber => Questions.Count;
    }
}
