﻿using System;

namespace SocketIO.Client.Transport
{
    public class TransportException : Exception
    {
        public TransportException() : base() { }
        public TransportException(string message) : base(message) { }
        public TransportException(string message, Exception innerException) : base(message, innerException) { }
    }
}
