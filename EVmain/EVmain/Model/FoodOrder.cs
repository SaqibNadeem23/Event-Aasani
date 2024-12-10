using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace EVmain.Model
{
    [Table("FoodOrder")]
    class FoodOrder
    {
        [NotNull]
        public int EventId { get; set; }

        [MaxLength(50), NotNull]
        public string ItemName { get; set; }

        [MaxLength(50), NotNull]
        public int ItemQuantity { get; set; }

        [MaxLength(50), NotNull]
        public int ItemPrice { get; set; }
    }
}
