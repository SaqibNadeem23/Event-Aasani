using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace EVmain.Model
{
    [Table("mHallBook")]
    class mHallBook
    {
        [MaxLength(50), NotNull]
        public int EventId { get; set; }

        [MaxLength(50)]
        public int HallId { get; set; }

        [MaxLength(50)]
        public string Hallname { get; set; }

        [MaxLength(50)]
        public int Hallrate { get; set; }


        
    }

}
