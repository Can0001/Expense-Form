using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class UserOperationClaimDto:IDto
    {
        public string UserId { get; set; }
        public string OperationClaimId { get; set; }
    }
}
