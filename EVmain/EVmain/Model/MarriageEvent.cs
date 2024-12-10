using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace EVmain.Model
{
    [Table("MarriageEvent")]
    class MarriageEvent
    {
        [PrimaryKey, AutoIncrement]
        public int EventId { get; set; }

        [NotNull]
        public int UserId { get; set; }

        [MaxLength(50)]
        public string  Date { get; set; }

        [MaxLength(10)]
        public int Guests { get; set; }

        [MaxLength(50)]
        public string Timing { get; set; }

        [MaxLength(50)]
        public string EventType { get; set; }

        [MaxLength(50)]
        public string CakeName { get; set; }

        [MaxLength(50)]
        public double CakeQuantity { get; set; }

        [MaxLength(50)]
        public double CakeRate { get; set; }

        [MaxLength(200)]
        public string Location { get; set; }

        [MaxLength(50)]
        public double TotalBill { get; set; }


    }
}
