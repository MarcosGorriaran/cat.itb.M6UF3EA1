
using System.Text.Json;
using cat.itb.M6UF3EA1.CRUD;
using cat.itb.M6UF3EA1.Helpers;
using cat.itb.M6UF3EA1.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using UF3_test.connections;

namespace cat.itb.M6UF3EA1;

public class Driver
{
    public static void Main()
    {
        CRUDMongoDB<Student> crudStudent = new CRUDMongoDB<Student>(BsonClassMap.RegisterClassMap<Student>(classMap =>
        {
            classMap.AutoMap();
        }));
        //ACT1InsertGrades(crudStudent);
        crudStudent.Select();
    }
    public static void ACT1InsertGrades(CRUDMongoDB<Student> crud)
    {

        Student[] student = 
        { 
            new Student()
            {
                student_id = 111333444,
                name = "someone",
                surname = "yeahSomeone",
                class_id = 1,
                group = "DAMv",
                scores = new List<Score>
                {
                    new Score()
                    {
                        type = "exam",
                        score = 100
                    },
                    new Score()
                    {
                        type = "teamWork",
                        score = 50
                    }
                }
            },
            new Student()
            {
                student_id = 111222333,
                name = "->H1",
                surname = "Some tekken move",
                class_id = 20,
                group = "DAWe",
                interests = new List<string>()
                {
                    "music","gym","code","electronics"
                }
            }
        };
        crud.Insert(student);
        
    }
    public static void ACT2SelectDAMv()
    {

    }
}
