using System;

namespace week3_q1
{ 
    public class CounterSelectionArgs : EventArgs
    {
        public int Counter { get; set; }

        public CounterSelectionArgs(int counter)
        {
            Counter = counter;
        }
    }
}