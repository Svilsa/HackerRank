﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AppleAndOrange
{
    class Tree
    {
        public int position = 0;

        public Tree(int position)
        {
            this.position = position;
        }


        public int Drop(int dropRange)
        {
            return position + dropRange;
        }

    }
}
