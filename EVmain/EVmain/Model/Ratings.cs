using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace EVmain.Model
{
    [Table("Ratings")]
    class Ratings
    {
        [MaxLength(50)]
        public int UserId { get; set; }

        [MaxLength(50)]
        public int EventId { get; set; }

        [MaxLength(50)]
        public int PartnerId { get; set; }

        [MaxLength(50)]
        public int Rating { get; set; }
    }
}
