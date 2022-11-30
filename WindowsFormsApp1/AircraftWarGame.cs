using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WindowsFormsApp1.Aircraft;

namespace WindowsFormsApp1
{
    internal class AircraftWarGame
    {   
        public enum CellType
        {
            Unknown = 0, Miss, Hit, Kill
        }
        int boardSize;
        int[,] selfBoard;
        CellType[,] rivalView;

        public AircraftWarGame(int boardSize = 10)
        {
            this.boardSize = boardSize;
            this.selfBoard = new int[boardSize, boardSize];
            this.rivalView = new CellType[boardSize, boardSize];
        }

        public void SetRivalCell(CellType type, int column, int row)
        {
            rivalView[row, column] = type;
        }
        public CellType GetRivalCell(int column, int row)
        {
            return rivalView[row, column];
        }
        public int GetSelfCell(int column, int row)
        {
            return selfBoard[row, column];
        }
        public CellType GetSelfCellType(int column, int row)
        {
            int code = GetSelfCell(column, row);
            if (code == 0) return CellType.Miss;
            else if (code < 10) return CellType.Kill;
            else return CellType.Hit;
        }
        public bool IsLegalAirCraft(int column, int row, Direction direction)
        {

            switch (direction)
            {
                case Direction.Up:
                    if (column < 2 || column > 7 || row < 3 || row > 9) return false;
                    break;
                case Direction.Down:
                    if (column < 2 || column > 7 || row < 0 || row > 6) return false;
                    break;
                case Direction.Left:
                    if (column < 3 || column > 9 || row < 2 || row > 7) return false;
                    break;
                case Direction.Right:
                    if (column < 0 || column > 6 || row < 2 || row > 7) return false;
                    break;
            }
            var shape = Shape[direction];
            for (int i = 0; i < 10; ++i)
            {
                if (selfBoard[row + shape[0][i], column + shape[1][i]] != 0) return false;
            }
            return true;
        }
        public void AddAirCraft(int id, int column, int row, Direction direction)
        {

            var shape = Shape[direction];
            for (int i = 0; i < 10; ++i)
            {
                selfBoard[row + shape[0][i], column + shape[1][i]] = id + 10;
            }
            selfBoard[row, column] = id;
        }
        public int RemoveAirCraft(int column, int row)
        {
            int headId = selfBoard[row, column], bodyId = headId + 10;
            if (headId >= 10)
            {
                bodyId = headId;
                headId -= 10;
            }
            for (int i = 0; i < 10; ++i)
                for (int j = 0; j < 10; ++j)
                    if (selfBoard[i, j] == bodyId || selfBoard[i, j] == headId)
                    {
                        selfBoard[i, j] = 0;
                    }
            return headId;
        }
    }
}
