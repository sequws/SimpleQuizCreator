using MahApps.Metro.Controls;
using Prism.Regions;
using System.Windows;

namespace SimpleQuizCreator.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();

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
