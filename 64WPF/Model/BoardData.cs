using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _64WPF.Model
{
    class BoardData
    {
        public NumberChip[][] board;

        public BoardData(int size)
        {
            board = new NumberChip[size][];
            for(int i = 0; i < size; i++)
            {
                board[i] = new NumberChip[size];
                for(int j = 0; j < size; j++)
                {
                    board[i][j] = new NumberChip(0);
                }
            }
        }

        public NumberChip[][] getBoard()
        {
            return board;
        }

        public void setBoard(NumberChip[][] b)
        {
            board = b;
        }

    }
}
