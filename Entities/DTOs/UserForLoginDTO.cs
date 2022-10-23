using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class UserForLoginDTO:IDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
