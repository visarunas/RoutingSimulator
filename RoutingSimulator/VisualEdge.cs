﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoutingSimulator
{
    public class VisualEdge<T>
    {
        public T Start { get; set; }
        public T End { get; set; }

        public VisualEdge(T start, T end)
        {
            this.Start = start;
            this.End = end;
        
        }

        public T[] getConnected()
        {
            return new T[] {Start, End};
        }


    }
}
