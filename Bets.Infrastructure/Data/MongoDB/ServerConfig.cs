using System;
using System.Collections.Generic;
using System.Text;

namespace Bets.Infrastructure.Data.MongoDB
{
    public class ServerConfig
    {
        public MongoDBConfig MongoDB { get; set; } = new MongoDBConfig();
    }
}
