using SimpleQuizCreator.Interfaces;
using System;
using System.ComponentModel;
using System.Windows;

namespace SimpleQuizCreator.Views
{
    /// <summary>
    /// Interaction logic for QuizWindow.xaml
    /// </summary>
    public partial class QuizWindow : Window, IWindowView
    {
        public QuizWindow()
        {
            InitializeComponent();
        }

        public bool? Open()
        {
            return this.ShowDialog();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
            e.Cancel = true;
        }
    }
}
