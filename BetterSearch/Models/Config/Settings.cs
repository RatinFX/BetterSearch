﻿using VegasProData.Base;

namespace BetterSearch.Models.Config
{
    public class Settings
    {
        public bool OnlyShowFavorites { get; set; } = false;

        public Settings() { }
        public Settings(bool init)
        {
            if (!init)
                return;

            var config = BaseConfig.LoadConfig(this, Parameters.MainFolder("Settings"));
            if (config != null)
            {
                OnlyShowFavorites = config.OnlyShowFavorites;
            }

            Save();
        }

        public void Save()
        {
            BaseConfig.SaveConfig(this, Parameters.MainFolder("Settings"));
        }
    }
}
