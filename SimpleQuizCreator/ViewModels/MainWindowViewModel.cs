using NLog;
using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using SimpleQuizCreator.Interfaces;

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
        IParser _parser;
        public DelegateCommand<string> NavigateCommand { get; set; }

        public MainWindowViewModel(IContainerExtension container, IRegionManager regionManager, IParser parser)
        {
            _parser = parser;
            _container = container;
            _regionManager = regionManager;
            NavigateCommand = new DelegateCommand<string>(Navigate);

        }

        private void Navigate(string uri)
        {
            _regionManager.RequestNavigate("ContentRegion", uri);
        }
    }
}
