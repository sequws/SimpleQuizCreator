using SimpleQuizCreator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleQuizCreator.Services
{
    public class GlobalSettingService : IGlobalSettingService
    {
        protected ISettings _settings;

        public GlobalSettingService(ISettings settings)
        {
            _settings = settings;
        }

        public object Get(string settingName)
        {
            if(string.IsNullOrEmpty(settingName))
            {
                throw new ArgumentNullException(settingName);
            }

            return _settings[settingName];
        }

        public void Update(string settingName, object value)
        {
            if (string.IsNullOrEmpty(settingName))
            {
                throw new ArgumentNullException(settingName);
            }

            var setting = _settings[settingName];

            if(setting == null)
            {
                throw new ArgumentException($"Setting {settingName} not found!");
            }
            else if(setting.GetType() != value.GetType())
            {
                throw new InvalidCastException($"Unable to cast value to {setting.GetType()}");
            }
            else
            {
                _settings[settingName] = value;
                _settings.Save();
            }

        }
    }
}
