using NLog;
using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using SimpleQuizCreator.Interfaces;
using SimpleQuizCreator.Models;
using System.Windows;

namespace SimpleQuizCreator.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();


        private string _title = "SimpleQuizCreator v0.01b";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public int AppWidth { get; set; }
        public int AppHeight { get; set; }

        IContainerExtension _container;
        IRegionManager _regionManager;
        IQuizService _quizService;
        IGlobalSettingService _settingService;

        public DelegateCommand<string> NavigateCommand { get; set; }

        public MainWindowViewModel(IContainerExtension container,
            IRegionManager regionManager,
            IQuizService quizService,
            IGlobalSettingService settingService
            )
        {
            _container = container;
            _regionManager = regionManager;
            _quizService = quizService;
            _settingService = settingService;

            var quizzes = _quizService.GetAllQuizzes();

            NavigateCommand = new DelegateCommand<string>(Navigate);
        }

        private void Navigate(string uri)
        {
            _regionManager.RequestNavigate("ContentRegion", uri);
        }

        #region Commands

        private DelegateCommand _saveSettingsCommand;
        public DelegateCommand SaveSettingsCommand =>
            _saveSettingsCommand ?? (_saveSettingsCommand = new DelegateCommand(ExecuteSaveSettingsCommand, CanExecuteSaveSettingsCommand));

        void ExecuteSaveSettingsCommand()
        {      
            _settingService.Update("AppWidth", (double)AppWidth);
            _settingService.Update("AppHeight", (double)AppHeight);
        }

        bool CanExecuteSaveSettingsCommand()
        {
            return true;
        }

        #endregion
    }
}
