using Prism.Commands;
using Prism.Mvvm;
using SimpleQuizCreator.Interfaces;
using SimpleQuizCreator.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleQuizCreator.ViewModels
{
    public class HistoryViewModel : BindableBase
    {
        private readonly IResultService _resultService;

        private List<ScoreResult> historyResult;
        public List<ScoreResult> HistoryResult
        {
            get { return historyResult; }
            set { SetProperty(ref historyResult, value); }
        }

        public HistoryViewModel(IResultService resultService)
        {
            _resultService = resultService;
            HistoryResult = _resultService.GetAllResult().ToList();
        }


    }
}
