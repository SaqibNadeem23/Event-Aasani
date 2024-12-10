using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace EVmain.Model
{
    [Table("Catering")]
    class Catering
    {
        [PrimaryKey, NotNull]
        public int CatId { get; set; }

        [MaxLength(50)]
        public string CatName { get; set; }

        [MaxLength(200)]
        public string CatPic { get; set; }

        [MaxLength(10)]
        public int CatPrice { get; set; }

        [MaxLength(20)]
        public double CatRating { get; set; }

        [MaxLength(20)]
        public byte[] imgbyte { get; set; }

        [MaxLength(50)]
        public int TotalRatings { get; set; }

        [MaxLength(50)]
        public int OverallRatings { get; set; }
    }
}
