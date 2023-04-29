using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace TurismoSV_client.UitlsClass.AppConfig
{
public class Settings
    {
        public Dictionary<string, string> UserSettings { get; set; }
    }

    public static class AppConfig
    {
        private static Settings _settings;

        public static void initSharedPreferences() {
            var settingsFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "settings.json");
            if (File.Exists(settingsFile))
            {
                var json = File.ReadAllText(settingsFile);
                _settings = new Settings();
                _settings = JsonConvert.DeserializeObject<Settings>(json);
                System.Diagnostics.Debug.WriteLine("Path Config : " + settingsFile);
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("No se inicio el sharedpreferences");
            }
        }

        public static void SetUserSetting(string key, string value)
        {
            if (_settings.UserSettings == null)
            {
                _settings.UserSettings = new Dictionary<string, string>();
            }
            _settings.UserSettings[key] = value;
            SaveSettings();
        }

        public static string GetUserSetting(string key)
        {
            if (_settings.UserSettings == null)
            {
                _settings.UserSettings = new Dictionary<string, string>();
            }
            if (_settings.UserSettings.ContainsKey(key))
            {
                return _settings.UserSettings[key];
            }
            else {
                return null;
            }
            
        }

        private static void SaveSettings()
        {
            var settingsFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "settings.json");
            var json = JsonConvert.SerializeObject(_settings);
            File.WriteAllText(settingsFile, json);
        }
    }
}
