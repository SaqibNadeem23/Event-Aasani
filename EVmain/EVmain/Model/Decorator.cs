using System;
using System.Collections.Generic;
using System.Text;
using SQLite;


namespace EVmain.Model
{
    [Table("Decorator")]
    class Decorator
    {

        [PrimaryKey, NotNull]
        public int DecoratorId { get; set; }

        [MaxLength(50)]
        public string DecoratorName { get; set; }

        [MaxLength(200)]
        public string DecoratorPic { get; set; }

        [MaxLength(10)]
        public int DecoratorPrice { get; set; }

        [MaxLength(20)]
        public double DecoratorRating { get; set; }

        [MaxLength(20)]
        public byte[] imgbyte { get; set; }

        [MaxLength(50)]
        public int TotalRatings { get; set; }

        [MaxLength(50)]
        public int OverallRatings { get; set; }
    }
}
