using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concrete
{
    public interface ITokenEntity
    {
         string Id { get; set; }
         string FirstName { get; set; }
         string LastName { get; set; }
         string Email { get; set; }
         byte[] PasswordSalt { get; set; }
         byte[] PasswordHash { get; set; }
         bool Status { get; set; }
    }
}
