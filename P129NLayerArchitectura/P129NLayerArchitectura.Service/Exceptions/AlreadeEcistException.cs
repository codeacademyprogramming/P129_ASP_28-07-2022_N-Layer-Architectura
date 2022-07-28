using System;
using System.Collections.Generic;
using System.Text;

namespace P129NLayerArchitectura.Service.Exceptions
{
    public class AlreadeEcistException : Exception
    {
        public AlreadeEcistException(string msg) : base(msg)
        {

        }
    }
}
