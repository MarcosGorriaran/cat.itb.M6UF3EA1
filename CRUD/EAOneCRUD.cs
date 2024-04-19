using cat.itb.M6UF3EA1.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace cat.itb.M6UF3EA1.CRUD
{
    public class EAOneCRUD : CRUDMongoDB<Grade>
    {
        public void ACT1InsertGrades()
        {

            Grade[] student =
            {
            new Grade()
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
            new Grade()
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
            new Grade()
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
        public void ACT6InsertFiles()
        {
            const string DB = "itb";
            CRUDMongoDB<Book> bookCRUD = new CRUDMongoDB<Book>(DB,"book");
            CRUDMongoDB<People> peopleCRUD = new CRUDMongoDB<People>(DB, "people");
            CRUDMongoDB<Product> productCRUD = new CRUDMongoDB<Product>(DB, "product");
            CRUDMongoDB<Restaurant> restaurantCRUD = new CRUDMongoDB<Restaurant>(DB, "restaurant");
            CRUDMongoDB<Student> studentCRUD = new CRUDMongoDB<Student>(DB, "student");
            bookCRUD.Insert(Book.ReadJSONArrayFile("../../../FitxersJSON/books.json"));
            peopleCRUD.Insert(People.ReadJSONArrayFile("../../../FitxersJSON/people.json"));
            productCRUD.Insert(Product.ReadJSONArray(File.ReadAllText("../../../FitxersJSON/products.json").Split('\n')));

        }
    }
}
