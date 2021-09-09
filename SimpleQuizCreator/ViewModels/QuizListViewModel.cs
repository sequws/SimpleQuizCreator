using Prism.Commands;
using Prism.Mvvm;
using SimpleQuizCreator.Interfaces;
using SimpleQuizCreator.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleQuizCreator.ViewModels
{
    public class QuizListViewModel : BindableBase
    {
        IQuizService _quizService;

        public List<Quiz> ListOfQuizzes { get; set; }

        public QuizListViewModel(IQuizService quizService)
        {
            _quizService = quizService;
            ListOfQuizzes = new List<Quiz>(_quizService.GetAllQuizzes());
        }
    }
}
