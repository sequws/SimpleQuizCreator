using SimpleQuizCreator.Views;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;
using SimpleQuizCreator.Interfaces;
using SimpleQuizCreator.DataAccess;
using SimpleQuizCreator.Models;
using SimpleQuizCreator.Services;
using SimpleQuizCreator.ViewModels;
using SimpleQuizCreator.Common;

namespace SimpleQuizCreator
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IParser<Quiz>, QuizParser>();
            containerRegistry.RegisterSingleton<ILoader<QuizFile>, QuizLoader>();
            containerRegistry.RegisterSingleton<IQuizService, QuizService>();
            containerRegistry.RegisterSingleton<IQuizGenerator, QuizGenerator>();
            containerRegistry.RegisterSingleton<IWindowView, QuizWindow>();
            containerRegistry.RegisterSingleton<IScoreCalculator, ScoreCalculator>();

            containerRegistry.RegisterSingleton<IResultRepository, ResultRepository>();

            containerRegistry.RegisterDialog<QuizDialog, QuizDialogViewModel>();
        }
    }
}
