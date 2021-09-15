using Prism.Regions;
using System.Windows;

namespace SimpleQuizCreator.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(IRegionManager regionManager)
        {
            InitializeComponent();

            regionManager.RegisterViewWithRegion("ContentRegion", typeof(HelloView));
            regionManager.RegisterViewWithRegion("ContentRegion", typeof(QuizListView));
            regionManager.RegisterViewWithRegion("ContentRegion", typeof(StartQuizView));
        }

        private void Window_Closed(object sender, System.EventArgs e)
        {
            App.Current.Shutdown();
        }
    }
}
