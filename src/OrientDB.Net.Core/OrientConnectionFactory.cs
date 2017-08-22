﻿using OrientDB.Net.Core.Abstractions;
using System;
using Microsoft.Extensions.Logging;

namespace OrientDB.Net.Core
{
    internal class OrientConnectionFactory<TDataType> : IOrientConnectionFactory
    {
        private readonly IOrientDBConnectionProtocol<TDataType> _connectionProtocol;
        private readonly IOrientDBRecordSerializer<TDataType> _serializer;
        private readonly ILogger _logger;

        internal OrientConnectionFactory(
            IOrientDBConnectionProtocol<TDataType> connectionProtocol,
            IOrientDBRecordSerializer<TDataType> serializer, 
            ILogger logger)
        {
            _connectionProtocol = connectionProtocol ?? throw new ArgumentNullException($"{nameof(connectionProtocol)} cannot be null.");
            _serializer = serializer ?? throw new ArgumentNullException($"{nameof(serializer)} cannot be null");
            _logger = logger ?? throw new ArgumentNullException($"{nameof(logger)} cannot be null");
        }        
        
        public IOrientServerConnection CreateConnection()
        {
            return _connectionProtocol.CreateServerConnection(_serializer, _logger);
        }
    }
}
