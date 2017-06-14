namespace KOK_Template.Models.Article
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using KOK_Template;

    [Table("ArticleCategoryLocale")]
    public partial class ArticleCategoryLocale : BaseEntityCategoryContent
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ArticleCategoryID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CultureID { get; set; }

        public virtual ArticleCategory ArticleCategory { get; set; }

        public virtual Culture Culture { get; set; }
    }
}
