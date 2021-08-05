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
            var settings = MongoClientSettings.FromConnectionString("mongodb+srv://root:admin@cluster0.ypypl.mongodb.net/Plates.AllowedList?retryWrites=true&w=majority");
            settings.DirectConnection = false;
            settings.Credential = MongoCredential.CreateCredential("Plates", "root", "admin");
            var client = new MongoClient(settings);
            //client.StartSession();
            var database = client.GetDatabase("Plates");
            var collection = database.GetCollection<BsonDocument>("AllowedList");
            

            //    var document = new BsonDocument { { "plateNumber", plateNumber }, {
            //        "scores",
            //        new BsonArray {
            //        new BsonDocument { { "type", "allowed" }, { "isAllowed", allowed.ToString() } },
            //        new BsonDocument { { "type", "reason" }, { "reason", 74.92381029342834 } },
            //        new BsonDocument { { "type", "timeStamp" }, { "timeStamp", timeStamp } },
            //        }
            //        },
            //};
            var document = new BsonDocument { { "id", 10000 } };
            collection.InsertOne(document);
            //database.Watch();
        }
    }
}
