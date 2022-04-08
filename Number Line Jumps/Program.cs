using System;

namespace Number_Line_Jumps
{
    class Program
    {
        static void Main(string[] args)
        {
            if (CanBeInOnePosition())
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }

          


        }

        static bool CanBeInOnePosition()
        {
            Kangaroo Kanga = new Kangaroo(21, 6);
            Kangaroo Roo = new Kangaroo(47, 3);

            int jumpCounrer = 0;

            if (Kanga.CurrentPosition < Roo.CurrentPosition && Kanga.JumpRange < Roo.JumpRange ||
                Roo.CurrentPosition < Kanga.CurrentPosition && Roo.JumpRange < Kanga.JumpRange)
            {
                return false;
            }
            else
            {
                while(jumpCounrer < 10000)
                {
                    Kanga.DoJump();
                    Roo.DoJump();

                    if(Kanga.CurrentPosition == Roo.CurrentPosition)
                    {
                        return true;
                    }
                    else
                    {
                        jumpCounrer++;
                    }
                }
                return false;
            }
        }
    }
}
