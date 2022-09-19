using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteFortes.Domain.Models
{
    public class Entity
    {
        public int Id { get; set; }
        public int CreatedUser { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int UpdatedUser { get; set; }
        public DateTime? UpdatedData { get; set; }
        public bool IsActive { get; set; }
    }
}
