using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace EVmain.Model
{
    [Table("FoodIt")]
    class FoodIt
    {
        [PrimaryKey, AutoIncrement]
        public int FoodId { get; set; }

        [MaxLength(50), Unique]
        public string FoodName { get; set; }

        [MaxLength(100)]
        public string FoodPic { get; set; }

        [MaxLength(10)]
        public int FoodPrice { get; set; }

        [MaxLength(20)]
        public byte[] imgbyte { get; set; }
    }
}
