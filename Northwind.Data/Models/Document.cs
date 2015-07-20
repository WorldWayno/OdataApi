namespace Northwind.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Document
    {
        [Key]
        public int FileID { get; set; }

        [StringLength(255)]
        public string FileName { get; set; }

        public bool IsFolder { get; set; }

        public int? ParentID { get; set; }
    }
}
