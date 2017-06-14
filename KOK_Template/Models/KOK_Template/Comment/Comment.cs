namespace KOK_Template.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Comment")]
    public partial class Comment
    {
        public int CommentID { get; set; }

        [StringLength(256)]
        public string UserName { get; set; }

        [StringLength(1000)]
        public string Link { get; set; }

        [StringLength(200)]
        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime? CreateDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        public int? Priority { get; set; }

        public bool? IsApproved { get; set; }

        public bool? IsAvailable { get; set; }
    }
}
