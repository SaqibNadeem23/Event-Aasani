using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace EVmain.Model
{
    [Table("Gallery")]
    class Gallery
    {
        [MaxLength(50)]
        public int Id { get; set; }

        [MaxLength(50)]
        public int PicNum { get; set; }

        [MaxLength(200)]
        public byte[] imgbyte { get; set; }

        [MaxLength(50)]
        public string imgsource { get; set; }
    }
}
