using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteFortes.Application.ViewModels
{
    public class UserViewModel
    {
        public int UserId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
