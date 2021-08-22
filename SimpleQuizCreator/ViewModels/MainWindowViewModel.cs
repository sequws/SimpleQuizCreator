using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;

namespace SimpleQuizCreator.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "SimpleQuizCreator v0.01b";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        IContainerExtension _container;
        IRegionManager _regionManager;
        public DelegateCommand<string> NavigateCommand { get; set; }

        public MainWindowViewModel(IContainerExtension container, IRegionManager regionManager)
        {
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
