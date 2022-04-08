using System;
using System.Collections.Generic;
using System.Text;

namespace Number_Line_Jumps
{
    class Kangaroo
    {
        private int currentPosition;
        private int jumpRange;


        public int CurrentPosition
        {
            set
            {
                if (value < 0)
                {
                    currentPosition = 0;
                }
                else if (value > 10000)
                {
                    currentPosition = 10000;
                }
                else
                {
                    currentPosition = value;
                }
            }

            get
            {
                return currentPosition;
            }
        }

        public int JumpRange
        {
            set
            {
                if (value < 1)
                {
                    jumpRange = 1;
                }
                else if (value > 10000)
                {
                    jumpRange = 10000;
                }
                else
                {
                    jumpRange = value;
                }
            }

            get
            {
                return jumpRange;
            }
        }

        public Kangaroo(int startPosition, int jumpRange)
        {
            CurrentPosition = startPosition;
            JumpRange = jumpRange; 
        }

        public void DoJump()
        {
            currentPosition += jumpRange;
        }
    }
}