using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace EVmain.Model
{
    [Table("mPhotographerBook")]
    class mPhotographerBook
    {
        [MaxLength(50), NotNull]
        public int EventId { get; set; }

        [MaxLength(50)]
        public int PId { get; set; }

        [NotNull, MaxLength(50)]
        public string PhotographerName { get; set; }

        [NotNull, MaxLength(50)]
        public int PhotographerPrice { get; set; }
    }
}
