using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IMDBApplication.Model
{
    public class Movies
    {
        [Key]
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        //public List<Actor> Actors { get; set; }
        public string Actor { get; set; }
        public string Producer { get; set; }
        public string DateOfRelease { get; set; }
        public string MovieImage { get; set; }

    }
}
