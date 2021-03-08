using System;
using System.Collections.Generic;
using System.Linq;

namespace Checkers_Sample
{
    #region Checker Class
    public class Checker
    {
        public string Symbol { get; private set; }
        public Position Position { get; set; }
        public Color Team { get; private set; }

        public Checker(Color player, int row, int col)
        {
            if (player == Color.Black)
            {
                int symbol = int.Parse("25CF", System.Globalization.NumberStyles.HexNumber);
                Symbol = char.ConvertFromUtf32(symbol);
                Team = Color.Black;
            }
            else
            {
                int symbol = int.Parse("25CB", System.Globalization.NumberStyles.HexNumber);
                Symbol = char.ConvertFromUtf32(symbol);
                Team = Color.White;
            }
            //Set a position for eack new checker that is instantiated.
            Position = new Position(row, col);
        }
    }
    #endregion
}