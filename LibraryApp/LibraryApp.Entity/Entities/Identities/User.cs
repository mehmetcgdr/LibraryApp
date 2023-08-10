using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Entity.Entities.Identities
{
    public class User :IdentityUser //Identity package'sinden gelecek olan property'ler için implementasyon.
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; } = ""; 
    }
}
