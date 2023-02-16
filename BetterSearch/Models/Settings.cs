using VegasProData.Base;

namespace BetterSearch.Models
{
    public class Settings
    {
        public bool OnlyShowFavorites { get; set; } = false;

        public Settings() { }
        public Settings(bool init)
        {
            if (!init)
                return;

            var config = BaseConfig.LoadConfig(this, @"BetterSearch\VegasFlow-Settings");
            if (config != null)
            {
                OnlyShowFavorites = config.OnlyShowFavorites;
            }

            Save();
        }

        public void Save()
        {
            BaseConfig.SaveConfig(this, @"BetterSearch\VegasFlow-Settings");
        }
    }
}
