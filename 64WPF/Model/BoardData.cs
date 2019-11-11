using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _64WPF.Model
{
    public class BoardData
    {
        public NumberChip[][] board;
        public int size;

        public BoardData(int size)
        {
            this.size = size;
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

        public NumberChip getBoardPosition( int row, int column)
        {
            return board[row][column];
        }

        public void setBoard(NumberChip[][] b)
        {
            board = b;
        }

        public void setBoardPosition( int row, int column, NumberChip chip)
        {
            board[row][column] = chip;
        }

    }
}
