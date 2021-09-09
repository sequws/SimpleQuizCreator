using NLog;
using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using SimpleQuizCreator.Interfaces;
using SimpleQuizCreator.Models;

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

        IContainerExtension _container;
        IRegionManager _regionManager;
        IQuizService _quizService;

        public DelegateCommand<string> NavigateCommand { get; set; }

        public MainWindowViewModel(IContainerExtension container,
            IRegionManager regionManager,
            IQuizService quizService
            )
        {
            _container = container;

            //_container.RegisterForNavigation(typeof(HelloView),)

            _regionManager = regionManager;
            _quizService = quizService;

            var quizzes = _quizService.GetAllQuizzes();

            NavigateCommand = new DelegateCommand<string>(Navigate);
        }

        private void Navigate(string uri)
        {
            _regionManager.RequestNavigate("ContentRegion", uri);
        }
    }
}
