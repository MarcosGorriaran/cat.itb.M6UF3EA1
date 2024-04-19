
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
        const string Menu = "1. InsertData\n" +
            "2. ShowDAMvStudents\n" +
            "3. ShowPerfectStudents\n" +
            "4. StudentsBellow50\n" +
            "5. ShowInterestsFromStudent\n" +
            "6. InsertJSONFiles\n" +
            "7. Exit";
        const int InsertOption = 1;
        const int ShowDamvOption = 2;
        const int ShowPerfectStOption = 3;
        const int ShowBadStudentOption = 4;
        const int ShowInterestsOption = 5;
        const int InsertJSONFile = 6;
        const int ExitOption = 7;

        EAOneCRUD crudStudent = new EAOneCRUD();
        int option;
        do
        {
            Console.WriteLine(Menu);
            option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case InsertOption:
                    crudStudent.ACT1InsertGrades();
                    break;
                case ShowDamvOption:
                    Console.WriteLine(string.Join('\n', crudStudent.SelectBson(Builders<BsonDocument>.Filter.Eq("group", "DAMv"))));
                    break;
                case ShowPerfectStOption:
                    Console.WriteLine(string.Join('\n', crudStudent.SelectBson(Builders<BsonDocument>.Filter.Eq("scores.type", "exam") & Builders<BsonDocument>.Filter.Eq("scores.score", 100))));
                    break;
                case ShowBadStudentOption:
                    Console.WriteLine(string.Join('\n', crudStudent.SelectBson(Builders<BsonDocument>.Filter.Eq("scores.type", "exam") & Builders<BsonDocument>.Filter.Lt("scores.score", 50))));
                    break;
                case ShowInterestsOption:
                    Console.WriteLine(string.Join('\n', crudStudent.SelectBson(Builders<BsonDocument>.Filter.Eq("student_id", 111222333), Builders<BsonDocument>.Projection.Include("interests").Exclude("_id"))));
                    break;
                case InsertJSONFile:
                    crudStudent.ACT6InsertFiles();
                    break;
            }
        } while (option != ExitOption);
        
        
        
        
        
        
    }
    
}
