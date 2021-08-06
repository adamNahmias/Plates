using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core.Clusters;

namespace PlateLicense
{
    class DBService
    {
        public static void insertPlateToDB(string timeStamp, string plateNumber,bool allowed,string reason)
        {
            MongoClient dbClient = new MongoClient("mongodb+srv://root:admin@cluster0.ypypl.mongodb.net/Plates.AllowedList?retryWrites=true&w=majority");

            var dbList = dbClient.ListDatabases().ToList();
            var database = dbClient.GetDatabase("Plates");
            var collection = database.GetCollection<BsonDocument>("AllowedList");
            var document = new BsonDocument { { "plateNumber", plateNumber }, {"Details",
                    new BsonArray {
                    new BsonDocument { { "type", "bool" }, { "isAllowed", allowed } },
                    new BsonDocument { { "type", "string" }, { "reason", reason } },
                    new BsonDocument { { "type", "timestamp" }, { "timeStamp", timeStamp } },
                    }
                    },
            };
            collection.InsertOne(document);
        }
    }
}
