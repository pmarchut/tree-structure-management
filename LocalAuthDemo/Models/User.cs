using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LocalAuthDemo.Models
{
    public class User : IdentityUser<Guid>
    {
        [ForeignKey("NodeId")]
        public Node Node { get; set; }

        [Required]
        [Display(Name = "Node")]
        public int NodeId { get; set; }
    }
}
