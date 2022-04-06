using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utility
{
    [Serializable]
    public class BatchProcessException : Exception
    {
        public string StudentName { get; }

        public BatchProcessException() { }

        public BatchProcessException(string message)
            : base(message) { }

        public BatchProcessException(string message, Exception inner)
            : base(message, inner) { }

        public BatchProcessException(string message, string studentName)
            : this(message)
        {
            StudentName = studentName;
        }
    }
}
