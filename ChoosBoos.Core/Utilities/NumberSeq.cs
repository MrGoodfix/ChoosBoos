using System;
using System.Collections.Generic;
using System.Text;

namespace ChoosBoos.Core.Utilities
{
    public class NumberSeq
    {
        private int _nextNum;
        private int _step;

        public NumberSeq(int start) : this(start, 1) { }

        public NumberSeq(int start, int step)
        {
            _nextNum = start;
            _step = step;
        }

        public int GetNext()
        {
            int retval = _nextNum;
            _nextNum = _nextNum + _step;
            return retval;
        }
    }
}
