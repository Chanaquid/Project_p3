using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StackExchange.Redis;

namespace Infrastructure.Factories
{
    public class RedisConnectionFactory
    {
        private static ConnectionMultiplexer _connection;
        private readonly string _connectionString;

        public RedisConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public ConnectionMultiplexer Connection()
        {
            if(_connection == null || ! _connection.IsConnected)
            {
                _connection = ConnectionMultiplexer.Connect(_connectionString);
            }
            
            return _connection;
        }
    }
}