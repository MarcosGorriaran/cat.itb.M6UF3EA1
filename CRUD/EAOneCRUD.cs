using cat.itb.M6UF3EA1.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace cat.itb.M6UF3EA1.CRUD
{
    public class EAOneCRUD : CRUDMongoDB<Student>
    {
        public void ACT1InsertGrades()
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
            },
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
                        score = 20
                    },
                    new Score()
                    {
                        type = "teamWork",
                        score = 50
                    }
                }
            }
        };
            Insert(student);

        }
       
    }
}
