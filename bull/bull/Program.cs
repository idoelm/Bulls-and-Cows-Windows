using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bull
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            ChanceNumbers chance = new ChanceNumbers();
            chance.ShowDialog();
            int x = chance.CounterChances;
            //GameBoard2 gameBoard = new GameBoard2(x);
            //gameBoard.ShowDialog();
            GameBoard gameBoard = new GameBoard(x);
            gameBoard.ShowDialog();

        }
    }
}
