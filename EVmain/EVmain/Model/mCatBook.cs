using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace EVmain.Model
{
    [Table("mCatBook")]
    class mCatBook
    {
        [MaxLength(50), NotNull]
        public int EventId { get; set; }

        [MaxLength(50)]
        public int CatId { get; set; }

        [MaxLength(50)]
        public string Catname { get; set; }

        [MaxLength(50)]
        public int Catrate { get; set; }
    }
}
