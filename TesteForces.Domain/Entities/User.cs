using System;
using System.Collections.Generic;
using System.Text;
using TesteFortes.Domain.Models;

namespace TesteFortes.Domain.Entities
{
    public class User : Entity
    {
        public int UserId { get; set; }
        public string Name { get; set; }
    }
}
