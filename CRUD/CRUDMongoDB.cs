using System.Collections.Immutable;
using System.Text.Json;
using cat.itb.M6UF3EA1.Helpers;
using cat.itb.M6UF3EA1.Models;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using UF3_test.connections;

namespace cat.itb.M6UF3EA1.CRUD
{
    public class CRUDMongoDB<T>
    {
        private IMongoCollection<BsonDocument> Collection;
        private BsonClassMap<T> ClassMap;

        private CRUDMongoDB(BsonClassMap<T> classMap,string database, string collection)
        {
            Collection = MongoLocalConnection.GetDatabase(database).GetCollection<BsonDocument>(collection);
            ClassMap = classMap;
        }
        public CRUDMongoDB(BsonClassMap<T> classMap):this(classMap,ConfigurationHelper.GetDB(),ConfigurationHelper.GetDBUrl()) { }

        public void Insert(T element)
        {
            string json = JsonSerializer.Serialize(element);
            BsonDocument bson = BsonDocument.Parse(json);
            Collection.InsertOne(bson);
        }
        public void Insert(params T[] elements)
        {
            Insert(elements.ToImmutableArray());
        }
        public void Insert(IEnumerable<T> elements)
        {
            foreach(T element in elements) 
            {
                Insert(element);
            }
        }
        public List<T> Select()
        {

            List <BsonDocument> elements = Collection.Find(new BsonDocument()).ToList();
            List<T> result = new List<T>();
            
            foreach(BsonDocument element in elements)
            {
                var dotNetObj = BsonTypeMapper.MapToDotNetValue(element,new BsonTypeMapperOptions() { MapBsonDocumentTo = typeof(Student)});
                result.Add(JsonSerializer.Deserialize<T>(JsonSerializer.Serialize(dotNetObj)));
            }
            return result;
        }
    }
}
