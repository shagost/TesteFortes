using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteFortes.Application.ViewModels
{
    public class UserUpdateViewModel
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedData { get; set; }
        public bool IsActive { get; set; }
    }
}
