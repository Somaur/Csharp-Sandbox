using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class Aircraft
    {
        public enum Direction
        {
            Up = 0, Right, Down, Left
        }
        public static Dictionary<Direction, int[][]> Shape = new Dictionary<Direction, int[][]>
        {
            { Direction.Up, new int[][] {
                new int[] {0, -1, -1, -1, -1, -1, -2, -3, -3, -3},
                new int[] {0, -2, -1,  0,  1,  2,  0, -1,  0,  1},
            }},
            { Direction.Down, new int[][] {
                new int[] {0,  1,  1,  1,  1,  1,  2,  3,  3,  3},
                new int[] {0, -2, -1,  0,  1,  2,  0, -1,  0,  1},
            }},
            { Direction.Left, new int[][] {
                new int[] {0, -2, -1,  0,  1,  2,  0, -1,  0,  1},
                new int[] {0, -1, -1, -1, -1, -1, -2, -3, -3, -3},
            }},
            { Direction.Right, new int[][] {
                new int[] {0, -2, -1,  0,  1,  2,  0, -1,  0,  1},
                new int[] {0,  1,  1,  1,  1,  1,  2,  3,  3,  3},
            }},
        };
        public static int[][] getShape(int column, int row, Direction direction)
        {
            var shape = Shape[direction];
            int[][] ret = new int[10][];
            for (int i = 0; i < 10; ++i)
            {
                ret[i] = new int[2] { column + shape[1][i], row + shape[0][i] };
            }
            return ret;
        }

        public Direction direction;
        public bool placed;
    }
}
