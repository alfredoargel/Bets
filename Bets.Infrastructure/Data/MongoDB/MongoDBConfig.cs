using System;
using System.Collections.Generic;
using System.Text;

namespace Bets.Infrastructure.Data.MongoDB
{
    public class MongoDBConfig
    {
        public string Database { get; set; }
        public string Cluster { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string ConnectionString
        {
            get
            {
                return $@"mongodb+srv://{User}:{Password}@{Cluster}/{Database}?retryWrites=true&w=majority";
            }
        }
    }
}
