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
            regionManager.RegisterViewWithRegion("ContentRegion", typeof(HistoryView));

            Width = Properties.Settings.Default.AppWidth;
            Height = Properties.Settings.Default.AppHeight;
            //Left = Properties.Settings.Default.AppLeft;
            //Top = Properties.Settings.Default.AppTop;
        }

        private void Window_Closed(object sender, System.EventArgs e)
        {
            App.Current.Shutdown();
        }
    }
}
