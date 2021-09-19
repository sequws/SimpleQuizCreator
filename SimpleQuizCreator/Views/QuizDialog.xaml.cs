using System.Windows;
using System.Windows.Controls;

namespace SimpleQuizCreator.Views
{
    /// <summary>
    /// Interaction logic for QuizDialog
    /// </summary>
    public partial class QuizDialog : UserControl
    {
        public QuizDialog()
        {
            InitializeComponent();

            // Hide tabs headers 
            Style s = new Style();
            s.Setters.Add(new Setter(UIElement.VisibilityProperty, Visibility.Collapsed));
            MainTabControl.ItemContainerStyle = s;
        }
    }
}
