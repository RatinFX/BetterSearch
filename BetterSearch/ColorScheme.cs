using System.Drawing;

namespace BetterSearch
{
    /// <summary>
    /// Color Scheme
    /// </summary>
    public class ColorScheme
    {
        public Color PanelBG { get; set; }
        public Color BoxBG { get; set; }
        public Color Highlight { get; set; }
        public Color Text { get; set; }
        public static ColorScheme Dark { get; } = new ColorScheme
        {
            PanelBG = Color.FromArgb(45, 45, 45),
            BoxBG = Color.FromArgb(70, 70, 70),
            Highlight = Color.FromArgb(45, 45, 45),
            Text = Color.White,
        };
        public static ColorScheme Light { get; } = new ColorScheme
        {
            PanelBG = Color.WhiteSmoke,
            BoxBG = Color.White,
            Highlight = Color.WhiteSmoke,
            Text = Color.Black,
        };
    }
}
