using Prism.Commands;
using Prism.Mvvm;
using SimpleQuizCreator.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace SimpleQuizCreator.ViewModels
{
    public class LanguageComboData
    {
        public string Code { get; set; }
        public string Abbrevation { get; set; }
        public string Name { get; set; }
    }

    public class SettingsViewModel : BindableBase
    {
        #region Properties
        ObservableCollection<LanguageComboData> languages = new ObservableCollection<LanguageComboData>();
        public ObservableCollection<LanguageComboData> Languages
        {
            get
            {
                return languages;
            }
        }

        private LanguageComboData selectedLanguage;
        public LanguageComboData SelectedLanguage
        {
            get { return selectedLanguage; }
            set
            {
                SetProperty(ref selectedLanguage, value);
                if( value != null)
                {
                    Console.WriteLine($"Selected language: {value.Code}");
                }                
            }
        }

        private int historyMinQuestion;
        public int HistoryMinQuestion
        {
            get { return historyMinQuestion; }
            set { SetProperty(ref historyMinQuestion, value); }
        }
        #endregion

        IGlobalSettingService _settingService;

        public SettingsViewModel(IGlobalSettingService settingService)
        {
            _settingService = settingService;

            languages.Add(new LanguageComboData
            {
                Code = "pl-PL",
                Abbrevation = "POL",
                Name = "Polish"
            });
            languages.Add(new LanguageComboData
            {
                Code = "en-EN",
                Abbrevation = "ENG",
                Name = "English"
            });
            languages.Add(new LanguageComboData
            {
                Code = "uk-UA",
                Abbrevation = "UKR",
                Name = "Ukrainian"
            });

            var lang = (string)_settingService.Get("AppLanguage");
            SelectedLanguage = languages.FirstOrDefault(x => x.Code == lang);

            HistoryMinQuestion = (int)_settingService.Get("HistoryMinQuestion");
        }

        private DelegateCommand _saveSettingsCommand;
        public DelegateCommand SaveSettingsCommand =>
            _saveSettingsCommand ?? (_saveSettingsCommand = new DelegateCommand(ExecuteSaveSettingsCommand, CanExecuteSaveSettingsCommand));

        void ExecuteSaveSettingsCommand()
        {
            if(SelectedLanguage != null)
            {
                _settingService.Update("AppLanguage", (string)SelectedLanguage.Code);
            }
            int val;
            //if( int.TryParse(HistoryMinQuestion,out val)
            {
                if(HistoryMinQuestion >= 0)
                {
                    _settingService.Update("HistoryMinQuestion", HistoryMinQuestion);
                }
            }
        }

        bool CanExecuteSaveSettingsCommand()
        {
            return true;
        }
    }
}
