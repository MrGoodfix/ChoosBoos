﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ChoosBoos.Core.Utilities
{
    /// <summary>
    /// Utility for generating number sequences similar to SQL identity.
    /// Intended primarily for limited scope numbers like page ID's within 
    /// a book since it is likely that ID's generated by the storage layer
    /// will be provided by the specific technology / concrete implementation.
    /// </summary>
    public class NumberSeq
    {
        private int _nextNum;
        private int _step;

        /// <summary>
        /// Returns a newly setup number sequence with a step of 1.
        /// </summary>
        /// <param name="start">The first number that will be returned when GetNext() is called.</param>
        public NumberSeq(int start) : this(start, 1) { }

        /// <summary>
        /// Returns a newly setup number sequence.
        /// </summary>
        /// <param name="start">The first number that will be returned when GetNext() is called.</param>
        /// <param name="step">The offset added to the next number after each time GetNext is called.</param>
        public NumberSeq(int start, int step)
        {
            _nextNum = start;
            _step = step;
        }

        /// <summary>
        /// Returns the next number in the sequence.
        /// </summary>
        public int GetNext()
        {
            int retval = _nextNum;
            _nextNum = _nextNum + _step;
            return retval;
        }
    }
}
