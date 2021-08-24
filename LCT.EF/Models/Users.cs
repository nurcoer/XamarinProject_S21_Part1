using System;
using System.Collections.Generic;
using System.Text;

namespace LCT.EF.Models
{
   public class Users
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public IList<Makbuz>  makbuzs { get; set; }
    }
    
}
