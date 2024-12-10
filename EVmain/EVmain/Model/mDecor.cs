using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace EVmain.Model
{
    [Table("mDecor")]
    class mDecor
    {
        [MaxLength(50), NotNull]
        public int EventId { get; set; }

        [MaxLength(50)]
        public int DId { get; set; }

        [NotNull, MaxLength(50)]
        public string DecoratorName { get; set; }

        [NotNull, MaxLength(50)]
        public int DecoratorPrice { get; set; }

        
    }
}
