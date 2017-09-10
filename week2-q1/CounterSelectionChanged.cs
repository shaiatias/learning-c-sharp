using System;

namespace week2_q1
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