namespace DataAccess.Concrete.Databases.MongoDB.Collections
{
    public class MongoDB_UsersCollection : ICollection
    {
        public string CollectionName { get; set; }

        public MongoDB_UsersCollection()
        {
            CollectionName = "Users";
        }
    }
}
