using System;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Configuration;
using MongoDB.Bson.IO;
using System.Collections.Generic;

namespace PlateLicense
{
    class DBService
    {
        private string URL_CONN = "mongodb+srv://{0}:{1}@cluster0.ypypl.mongodb.net/{2}.{3}?retryWrites=true&w=majority";
        private string DB_USER = ConfigurationManager.AppSettings["DB_USERNAME"];
        private string DB_PASSWORD = ConfigurationManager.AppSettings["DB_PASSWORD"];
        private static DBService dbService;
        private static MongoClient dbClient;
        private static IMongoDatabase database;
        private static IMongoCollection<BsonDocument> collection;

        public static DBService GetInstance(string dbName, string collectionName)
        {
            if (dbService == null || !database.DatabaseNamespace.DatabaseName.Equals(database) || !collection.CollectionNamespace.CollectionName.Equals(collection))
            {
                dbService = new DBService(dbName, collectionName);
            }
            return dbService;
        }
        private DBService(string dbName, string collectionName)
        {
            string URL = string.Format(URL_CONN, DB_USER, DB_PASSWORD, dbName, collectionName);
            dbClient = new MongoClient(URL);
            database = dbClient.GetDatabase(dbName);
            collection = database.GetCollection<BsonDocument>(collectionName);
        }
        public void insertPlateToDB(DateTime timeStamp, string plateNumber,bool allowed,string reason)
        {
            try
            {
                var document = new BsonDocument {
                    {"plateNumber",plateNumber },
                    {"Allowed",allowed },
                    {"Reason",reason },
                    {"TimeStamp",timeStamp }
            };
                collection.InsertOne(document);
                LoggerService.GetInstance().INFO(string.Format("DB Wirte, Status:success, Data: {0}",document.ToJson()));
            }
            catch (Exception e)
            {
                LoggerService.GetInstance().ERROR("DB ERROR: " + e.Message);
                throw (e);
            }
        }

        public ParkingData FindDataByPlateNumber(string plateNum)
        {
            try
            {
                var filter = Builders<BsonDocument>.Filter.Eq("plateNumber", plateNum);
                var result = collection.Find(filter).FirstOrDefault();
                Dictionary<string, dynamic> data = result.ToDictionary();
                ParkingData parkData = new ParkingData(data);
                return parkData;
            }
            catch(Exception e)
            {
                LoggerService.GetInstance().ERROR("DB ERROR: " + e.Message);
                throw (e);

            }

        }
    }
}
