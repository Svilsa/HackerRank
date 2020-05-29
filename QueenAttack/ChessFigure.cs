using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace QueenAttack_2
{
    abstract class ChessFigure
    {

        private int _colPos;
        private int _rowPos;
        private static int _sizeBoard;

        public int ColPos
        {
            set
            {
                if (value >= 0 && value <= BoardSize + 1)
                {
                    _colPos = value;

                }
            }
            get => _colPos;
        }

        public int RowPos
        {
            set
            {
                if (value >= 0 && value <= BoardSize + 1)
                {
                    _rowPos = value;
                }
            }
            get => _rowPos;
        }

        public static int BoardSize
        {
            set
            {
                if (value > 0 && value <= 100000)
                {
                    _sizeBoard = value;
                }
            }
            get => _sizeBoard;
        }

        public ChessFigure(int rowPos, int colPos)
        {
            RowPos = rowPos;
            ColPos = colPos;
        }

        protected ChessFigure() { }

    }

    class Queen : ChessFigure
    {
        public Queen(int rowPos, int colPos) : base(rowPos, colPos)
        {
            
        }

        protected Queen() { }

        public int PossibleRightWays(Obstacle[] obstacles)
        { 
            Obstacle nearestObstacle = new Obstacle(ChessFigure.BoardSize + 1, ChessFigure.BoardSize + 1);

            foreach (var obstacle in obstacles)
            {
                int localMinPos = ChessFigure.BoardSize;
                

                if(obstacle.RowPos == RowPos && obstacle.ColPos > ColPos && obstacle.ColPos < localMinPos)
                {
                    nearestObstacle = obstacle;
                    localMinPos = obstacle.ColPos;
                }
            }

            return nearestObstacle.ColPos - ColPos - 1;
        }

        public int PossibleLeftWays(Obstacle[] obstacles)
        {
            Obstacle nearestObstacle = new Obstacle(0, 0);
            int localMinPos = 0;

            foreach (var obstacle in obstacles)
            {
                


                if (obstacle.RowPos == RowPos && obstacle.ColPos < ColPos && obstacle.ColPos > localMinPos)
                {
                    nearestObstacle = obstacle;
                    localMinPos = obstacle.ColPos;
                }
            }

            return ColPos - nearestObstacle.ColPos - 1;
        }

        public int PossibleUpWays(Obstacle[] obstacles)
        {
            Obstacle nearestObstacle = new Obstacle(ChessFigure.BoardSize + 1, ChessFigure.BoardSize + 1);
            int localMinPos = ChessFigure.BoardSize;

            foreach (var obstacle in obstacles)
            {
                


                if (obstacle.ColPos == ColPos && obstacle.RowPos > RowPos && obstacle.RowPos < localMinPos)
                {
                    nearestObstacle = obstacle;
                    localMinPos = obstacle.RowPos;
                }
            }

            return nearestObstacle.RowPos - RowPos - 1;
        }

        public int PossibleDownWays(Obstacle[] obstacles)
        {
            Obstacle nearestObstacle = new Obstacle(0, 0);
            int localMinPos = 0;

            foreach (var obstacle in obstacles)
            {
               


                if (obstacle.ColPos == ColPos && obstacle.RowPos < RowPos && obstacle.RowPos > localMinPos)
                {
                    nearestObstacle = obstacle;
                    localMinPos = obstacle.RowPos;
                }
            }

            return RowPos - nearestObstacle.RowPos - 1;
        }

        public int PossibleUpRightWays(Obstacle[] obstacles)
        {
            Obstacle nearestObstacle = new Obstacle(BoardSize + 1, BoardSize + 1);
            
            int localMinRow = ChessFigure.BoardSize + 1;
            int localMinCol = ChessFigure.BoardSize + 1;

            foreach (var obstacle in obstacles)
            {

                if ((obstacle.ColPos > ColPos && obstacle.RowPos > RowPos) &&
                    (obstacle.ColPos < localMinCol && obstacle.RowPos < localMinRow) &&
                    (obstacle.ColPos - ColPos == obstacle.RowPos - RowPos))
                {
                    nearestObstacle = obstacle;
                    localMinRow = obstacle.RowPos;
                    localMinCol = obstacle.ColPos;
                }
            }

            if (nearestObstacle.ColPos == BoardSize + 1 && nearestObstacle.RowPos == BoardSize + 1)
                if (RowPos > ColPos || RowPos == ColPos) return BoardSize - RowPos;
                else if (RowPos < ColPos) return BoardSize - ColPos;
            
            return nearestObstacle.RowPos - RowPos - 1;
        }

        public int PossibleDownLeftWays(Obstacle[] obstacles)
        {
            Obstacle nearestObstacle = new Obstacle(0, 0);
            int localMinRow = 0;
            int localMinCol = 0;

            foreach (var obstacle in obstacles)
            {
    
                if ((obstacle.ColPos < ColPos && obstacle.RowPos < RowPos) &&
                    (obstacle.ColPos > localMinCol && obstacle.RowPos > localMinRow) &&
                    (obstacle.ColPos - ColPos == obstacle.RowPos - RowPos))
                {
                    nearestObstacle = obstacle;
                    localMinRow = obstacle.RowPos;
                    localMinCol = obstacle.ColPos;
                }
            }

            if (nearestObstacle.ColPos == 0 && nearestObstacle.RowPos == 0)
            {
                if (RowPos > ColPos || RowPos == ColPos) return ColPos - 1;
                else if (RowPos < ColPos) return RowPos - 1; 
            }

            return RowPos - nearestObstacle.RowPos - 1;
        }

        public int PossibleDownRightWays(Obstacle[] obstacles)
        {
            Obstacle nearestObstacle = new Obstacle(0, ChessFigure.BoardSize + 1);
            int localMinRow = 0;
            int localMinCol = ChessFigure.BoardSize + 1;

            foreach (var obstacle in obstacles)
            {

                if ((obstacle.ColPos > ColPos && obstacle.RowPos < RowPos) &&
                    (obstacle.ColPos < localMinCol && obstacle.RowPos > localMinRow) &&
                    (obstacle.ColPos - ColPos == Math.Abs(obstacle.RowPos - RowPos)))
                {
                    nearestObstacle = obstacle;
                    localMinRow = obstacle.RowPos;
                    localMinCol = obstacle.ColPos;
                }

            }

            if (nearestObstacle.RowPos == 0 && nearestObstacle.ColPos == BoardSize + 1)
                if (Math.Abs(RowPos + ColPos) <= BoardSize + 1)
                    return RowPos - 1;
                else if (Math.Abs(RowPos + ColPos) > BoardSize) return BoardSize - ColPos;

            return RowPos - nearestObstacle.RowPos - 1;
        }

        public int PossibleUpLefttWays(Obstacle[] obstacles)
        {
            Obstacle nearestObstacle = new Obstacle(ChessFigure.BoardSize + 1, 0);
            int localMinRow = ChessFigure.BoardSize + 1;
            int localMinCol = 0;


            foreach (var obstacle in obstacles)
            {
                


                if ((obstacle.ColPos < ColPos && obstacle.RowPos > RowPos) &&
                    (obstacle.ColPos > localMinCol && obstacle.RowPos < localMinRow) &&
                    (Math.Abs(obstacle.ColPos - ColPos) == obstacle.RowPos - RowPos))
                {
                    nearestObstacle = obstacle;
                    localMinRow = obstacle.RowPos;
                    localMinCol = obstacle.ColPos;
                }
            }

            if (nearestObstacle.RowPos == BoardSize + 1 && nearestObstacle.ColPos == 0)
                if (Math.Abs(RowPos + ColPos) <= BoardSize + 1)
                    return ColPos - 1;
                else if (Math.Abs(RowPos + ColPos) > BoardSize) return BoardSize - RowPos;

            return nearestObstacle.RowPos - RowPos - 1;
        }

        public int PossibleWays(Obstacle[] obstacles)
        {
            return PossibleUpWays(obstacles) + PossibleDownWays(obstacles) + PossibleLeftWays(obstacles)
                + PossibleRightWays(obstacles) + PossibleUpRightWays(obstacles) + PossibleUpLefttWays(obstacles) +
                PossibleDownRightWays(obstacles) + PossibleDownLeftWays(obstacles);
        }



    }

    class Obstacle : ChessFigure
    {
        public Obstacle(int rowPos, int colPos) : base(rowPos, colPos)
        {

        }

    }
}
