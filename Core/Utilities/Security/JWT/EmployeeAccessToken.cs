﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.JWT
{
    public class EmployeeAccessToken
    {
        public string EmployeeId { get; set; }
        public string Token { get; set; }
        public string Expiration { get; set; }
    }
}
