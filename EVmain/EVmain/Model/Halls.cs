using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace EVmain.Model
{
    [Table("Halls")]
    class Halls
    {
        [PrimaryKey, NotNull]
        public int HallId { get; set; }

        [MaxLength(50)]
        public string HallName { get; set; }

        [MaxLength(200)]
        public string HallPic { get; set; }

        [MaxLength(200)]
        public string Address { get; set; }

        [MaxLength(10)]
        public int HallPrice { get; set; }

        [MaxLength(20)]
        public double HallRating { get; set; }

        [MaxLength(20)]
        public double HallLong { get; set; }

        [MaxLength(20)]
        public double HallLang { get; set; }

        [MaxLength(20)]
        public byte[] imgbyte { get; set; }

        [MaxLength(50)]
        public int TotalRatings { get; set; }

        [MaxLength(50)]
        public int OverallRatings { get; set; }
    }
}
