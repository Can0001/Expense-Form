using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class EmployeeOperationClaimsEvolved
    {
        public string Id { get; set; }
        public string OperationClaim { get; set; }
        public string OperationClaimId { get; set; }
        public string Employee { get; set; }
        public string EmployeeId { get; set; }
    }
}
