using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bull
{
    public class RandomColors
    {
        private Random m_Random = new Random();

        public List<Color> SelectRandomColors()
        {
            List<Color> colors = new List<Color>
            {
            Color.Yellow,
            Color.Blue,
            Color.Green,
            Color.Red,
            Color.Gray,
            Color.Brown,
            Color.Purple,
            Color.Pink
        };

            List<Color> selectedColors = new List<Color>();

            while (selectedColors.Count < 4 && colors.Count > 0)
            {
                int randomIndex = m_Random.Next(colors.Count);
                Color selectedColor = colors[randomIndex];
                selectedColors.Add(selectedColor);
                colors.RemoveAt(randomIndex);
            }

            return selectedColors;
        }
    }
}
