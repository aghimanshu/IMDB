using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IMDBApplication.Model
{
    
    public class Actor
    {
        [Key]
        public int ActorId { get; set; }
        public string ActorName { get; set; }
        public string DOB { get; set; }
        public string Gender { get; set; }
    }
}
