using Core.Entities;

namespace Entities.Concrete
{
    public class Employee : IEntity
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Department { get; set; }
    }
}
