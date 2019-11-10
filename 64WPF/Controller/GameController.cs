using _64WPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _64WPF.Controller
{
    class GameController
    {
        public BoardData board;

        public GameController()
        {
            board = new BoardData(4);
        }

        public void newChip(ref int row, ref int column, ref int value)
        {
            Random randomGenerator;
            randomGenerator = new Random();
            if(randomGenerator.Next(2) == 0)
            {
                value = 2;
            }
            else
            {
                value = 4;
            }
            NumberChip chip = new NumberChip(value);
            column = randomGenerator.Next(4);
            row = randomGenerator.Next(4);
            board.setBoardPosition(row, column, chip);
            
        }

        internal void Reset()
        {
            BoardData aux = new BoardData(4);
            board.setBoard(aux.board);
        }
    }
}
