using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlateLicense
{
    class ParkingData
    {
        public ObjectId ID { get; set; }
        public string PlateNumber { get; set; }
        public bool Allowed { get; set; }
        public string Reason { get; set; }
        public DateTime TimeStamp { get; set; }

        public ParkingData(Dictionary<string, dynamic> data)
        {
            this.ID = data["_id"];
            this.PlateNumber = data["plateNumber"];
            this.Allowed = data["Allowed"];
            this.Reason = data["Reason"];
            this.TimeStamp = data["timeStamp"];
        }
    }
}
