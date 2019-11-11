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
        int WinCondition = 4096;
        bool Win = false;

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
            while (board.getBoardPosition(row, column).getValue() != 0)
            {
                column = randomGenerator.Next(4);
                row = randomGenerator.Next(4);
            }
            board.setBoardPosition(row, column, chip);
            
        }

        internal void Reset()
        {
            BoardData aux = new BoardData(4);
            board.setBoard(aux.board);
            Win = false;
        }

        internal int getBoardPosition(int i, int j)
        {
            return board.getBoardPosition(i, j).getValue();
        }

        internal void setBoardPosition(int row, int column, int value)
        {
            NumberChip chip = new NumberChip(value);
            board.setBoardPosition(row, column, chip);
        }

        internal bool MoveDown()
        {
            bool movimiento = false;
            bool[] sumado = { false, false, false, false };
            for(int column = 0; column < board.size; column++)
            {
                for(int row = board.size - 2; row > -1; row--)
                {
                    if(board.getBoardPosition(row,column).getValue() != 0)
                    {
                        for(int k=row; k < board.size-1; k++)
                        {
                            if(board.getBoardPosition(k+1, column).getValue() == 0)
                            {
                                board.getBoardPosition(k + 1, column).setValue(board.getBoardPosition(k, column).getValue());
                                board.getBoardPosition(k, column).setValue(0);
                                movimiento = true;
                            }
                            else if(board.getBoardPosition(k + 1, column).getValue() == board.getBoardPosition(k, column).getValue())
                            {
                                if (!sumado[column])
                                {
                                    board.getBoardPosition(k + 1, column).setValue(board.getBoardPosition(k, column).getValue()*2);
                                    board.getBoardPosition(k, column).setValue(0);
                                    if (board.getBoardPosition(k + 1, column).getValue() == WinCondition) Win = true; 
                                    sumado[column] = true;
                                    movimiento = true;
                                }
                            }
                        }
                        
                    }

                }
            }
            return movimiento;
        }

        internal bool MoveUp()
        {
            bool movimiento = false;
            bool[] sumado = { false, false, false, false };
            for (int column = 0; column < board.size; column++)
            {
                for (int row = 1; row < board.size; row++)
                {
                    if (board.getBoardPosition(row, column).getValue() != 0)
                    {
                        for (int k = row; k > 0; k--)
                        {
                            if (board.getBoardPosition(k - 1, column).getValue() == 0)
                            {
                                board.getBoardPosition(k - 1, column).setValue(board.getBoardPosition(k, column).getValue());
                                board.getBoardPosition(k, column).setValue(0);
                                movimiento = true;
                            }
                            else if (board.getBoardPosition(k - 1, column).getValue() == board.getBoardPosition(k, column).getValue())
                            {
                                if (!sumado[column])
                                {
                                    board.getBoardPosition(k - 1, column).setValue(board.getBoardPosition(k, column).getValue() * 2);
                                    board.getBoardPosition(k, column).setValue(0);
                                    if (board.getBoardPosition(k - 1, column).getValue() == WinCondition) Win = true;
                                    sumado[column] = true;
                                    movimiento = true;
                                }
                            }
                        }

                    }

                }
            }
            return movimiento;
        }

        internal bool MoveRight()
        {
            bool movimiento = false;
            bool[] sumado = { false, false, false, false };
            for (int row = 0; row < board.size; row++)
            {
                for (int column = board.size - 2; column > -1; column--)
                {
                    if (board.getBoardPosition(row, column).getValue() != 0)
                    {
                        for (int k = column; k < board.size - 1; k++)
                        {
                            if (board.getBoardPosition(row, k + 1).getValue() == 0)
                            {
                                board.getBoardPosition(row, k + 1).setValue(board.getBoardPosition(row, k).getValue());
                                board.getBoardPosition(row, k).setValue(0);
                                movimiento = true;
                            }
                            else if (board.getBoardPosition(row, k + 1).getValue() == board.getBoardPosition(row, k).getValue())
                            {
                                if (!sumado[row])
                                {
                                    board.getBoardPosition(row, k + 1).setValue(board.getBoardPosition(row, k).getValue() * 2);
                                    board.getBoardPosition(row, k).setValue(0);
                                    if (board.getBoardPosition(row, k + 1).getValue() == WinCondition) Win = true;
                                    sumado[row] = true;
                                    movimiento = true;
                                }
                            }
                        }

                    }

                }
            }
            return movimiento;
        }

        internal bool MoveLeft()
        {
            bool movimiento = false;
            bool[] sumado = { false, false, false, false };
            for (int row = 0; row < board.size; row++)
            {
                for (int column = 1; column < board.size; column++)
                {
                    if (board.getBoardPosition(row, column).getValue() != 0)
                    {
                        for (int k = column; k > 0; k--)
                        {
                            if (board.getBoardPosition(row, k - 1).getValue() == 0)
                            {
                                board.getBoardPosition(row, k - 1).setValue(board.getBoardPosition(row, k).getValue());
                                board.getBoardPosition(row, k).setValue(0);
                                movimiento = true;
                            }
                            else if (board.getBoardPosition(row, k - 1).getValue() == board.getBoardPosition(row, k).getValue())
                            {
                                if (!sumado[row])
                                {
                                    board.getBoardPosition(row, k - 1).setValue(board.getBoardPosition(row, k).getValue() * 2);
                                    board.getBoardPosition(row, k).setValue(0);
                                    if (board.getBoardPosition(row, k - 1).getValue() == WinCondition) Win = true;
                                    sumado[row] = true;
                                    movimiento = true;
                                }
                            }
                        }

                    }

                }
            }
            return movimiento;
        }

        internal bool IsFull()
        {
            bool full = true;
            for( int row = 0; row < board.size; row++)
            {
                for( int column = 0; column < board.size; column++)
                {
                    if (board.getBoardPosition(row, column).getValue() == 0) full = false;
                }
            }
            return full;
        }

        internal bool getWin()
        {
            return Win;
        }
    }
}
