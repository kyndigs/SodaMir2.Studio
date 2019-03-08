using MongoDB.Driver;
// using SodaMir2.Common.Models.Merchant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMir2.Studio.Component
{
    public static class ResourceDatabase
    {
        private static IMongoClient _client { get; set; }
        private static IMongoDatabase _db { get; set; }

        public static void Initialize()
        {
            _client = new MongoClient("mongodb://localhost:27017");
            _db = _client.GetDatabase("Mir2Resource");
        }

        //public static List<NpcRecord> LoadNpcs()
        //{
        //    return _db.GetCollection<NpcRecord>("Npc").Find(_ => true).ToList();
        //}
    }
}
