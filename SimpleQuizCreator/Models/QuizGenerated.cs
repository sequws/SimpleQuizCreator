using Prism.Mvvm;
using System.Collections.Generic;

namespace SimpleQuizCreator.Models
{

    public class QuizGenerated : BindableBase
    {
        public string Name { get; set; }
        public List<Question> Questions = new List<Question>();

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

        private Question _activeQuestion;
        public Question ActiveQuestion { 
            get {
                if(ActiveQuestionNumber < QuestionsNumber)
                {
                    return Questions[ActiveQuestionNumber];
                } 
                else
                {
                    TestFinished = true;
                    // todo: repair this hack!
                    return Questions[QuestionsNumber - 1];
                }              
            }
            set {
                 SetProperty(ref _activeQuestion, value); 
            }            
        }
    }
}

