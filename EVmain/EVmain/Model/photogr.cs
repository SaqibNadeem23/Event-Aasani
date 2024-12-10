using SQLite;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace EVmain.Model
{
    [Table("photogr")]
    class photogr
    {
        [PrimaryKey, NotNull]
        public int PhotographerId { get; set; }

        [MaxLength(50)]
        public string PhotographerName { get; set; }

        [MaxLength(200)]
        public string PhotographerPic { get; set; }

        [MaxLength(10)]
        public int PhotographerPrice { get; set; }

        [MaxLength(20)]
        public double PhotographerRating { get; set; }

        [MaxLength(20)]
        public byte[] imgbyte { get; set; }

        [MaxLength(50)]
        public int TotalRatings { get; set; }

        [MaxLength(50)]
        public int OverallRatings { get; set; }
    }
}
