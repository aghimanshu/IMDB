using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IMDBApplication.Model
{
    public class Producer
    {
        [Key]
        public int ProducerId { get; set; }
        public string ProducerName { get; set; }
        public string Bio { get; set; }
        public string DOB { get; set; }
        public string CompanyName { get; set; }
        public string Gender { get; set; }
    }
}
