﻿using System.Collections.Immutable;
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
        protected IMongoCollection<BsonDocument> Collection;


        public IMongoDatabase GetDatabase()
        {
            return Collection.Database;
        }
        public CRUDMongoDB(string database, string collection)
        {
            Collection = MongoLocalConnection.GetDatabase(database).GetCollection<BsonDocument>(collection);
        }
        public CRUDMongoDB():this(ConfigurationHelper.GetDB(),ConfigurationHelper.GetDBUrl()) { }

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
            List<T> list = elements.ToList();
            for (int i = 0; i<list.Count(); i++) 
            {
                Insert(list[i]);
            }
        }
        /*public List<T> Select()
        {

            List <BsonDocument> elements = Collection.Find(new BsonDocument()).ToList();
            List<T> result = new List<T>();
            
            foreach(BsonDocument element in elements)
            {
                var dotNetObj = BsonTypeMapper.MapToDotNetValue(element,new BsonTypeMapperOptions() { MapBsonDocumentTo = typeof(Student)});
                result.Add(JsonSerializer.Deserialize<T>(JsonSerializer.Serialize(dotNetObj)));
            }
            return result;
        }*/
        public List<BsonDocument> SelectBson(FilterDefinition<BsonDocument> condition)
        {
            return Collection.Find(condition).ToList();
        }
        public List<BsonDocument> SelectBson(FilterDefinition<BsonDocument> filter, ProjectionDefinition<BsonDocument> projection)
        {
            return Collection.Find(filter).Project(projection).ToList();
        }
        public void ImportJSONElements(params string[] json)
        {
            foreach(string element in json)
            {
                Collection.InsertOne(BsonDocument.Parse(element));
            }
        }
    }
}
