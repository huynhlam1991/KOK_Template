namespace KOK_Template.DBContext
{
    using Models;
    using Models.Article;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public partial class KOK_TemplateDBContext : DbContext
    {
        public KOK_TemplateDBContext()
            : base("name=MainDBConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<KOK_TemplateDBContext, Migrations.Configuration>());
            Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<AddressBook> AddressBooks { get; set; }
        public virtual DbSet<AdsBanner> AdsBanners { get; set; }
        public virtual DbSet<AdsCategory> AdsCategories { get; set; }
        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<ArticleCategory> ArticleCategories { get; set; }
        public virtual DbSet<Career> Careers { get; set; }
        public virtual DbSet<CareerCategory> CareerCategories { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<DeliveryMethod> DeliveryMethods { get; set; }
        public virtual DbSet<District> Districts { get; set; }
        public virtual DbSet<Download> Downloads { get; set; }
        public virtual DbSet<DownloadCategory> DownloadCategories { get; set; }
        public virtual DbSet<Manufacturer> Manufacturers { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<MenuPosition> MenuPositions { get; set; }
        public virtual DbSet<Newsletter> Newsletters { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderStatus> OrderStatus { get; set; }
        public virtual DbSet<Origin> Origins { get; set; }
        public virtual DbSet<Partner> Partners { get; set; }
        public virtual DbSet<PaymentMethod> PaymentMethods { get; set; }
        public virtual DbSet<PayStatus> PayStatus { get; set; }
        public virtual DbSet<PhotoAlbum> PhotoAlbums { get; set; }
        public virtual DbSet<PhotoAlbumCategory> PhotoAlbumCategories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        public virtual DbSet<ProductDownload> ProductDownloads { get; set; }
        public virtual DbSet<ProductImage> ProductImages { get; set; }
        public virtual DbSet<ProductLength> ProductLengths { get; set; }
        public virtual DbSet<ProductOfLength> ProductOfLengths { get; set; }
        public virtual DbSet<ProductOfSame> ProductOfSames { get; set; }
        public virtual DbSet<ProductOption> ProductOptions { get; set; }
        public virtual DbSet<ProductOptionCategory> ProductOptionCategories { get; set; }
        public virtual DbSet<ProductSizeColor> ProductSizeColors { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<ProjectCategory> ProjectCategories { get; set; }
        public virtual DbSet<ProjectDownload> ProjectDownloads { get; set; }
        public virtual DbSet<ProjectImage> ProjectImages { get; set; }
        public virtual DbSet<ProjectVideo> ProjectVideos { get; set; }
        public virtual DbSet<Province> Provinces { get; set; }
        public virtual DbSet<Rating> Ratings { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<ServiceCategory> ServiceCategories { get; set; }
        public virtual DbSet<ShippingStatus> ShippingStatus { get; set; }
        public virtual DbSet<UserProfile> UserProfiles { get; set; }
        public virtual DbSet<Video> Videos { get; set; }
        public virtual DbSet<VideoCategory> VideoCategories { get; set; }
        public virtual DbSet<Visitor> Visitors { get; set; }
        public virtual DbSet<WishList> WishLists { get; set; }
        public virtual DbSet<ArticleCategoryLocale> ArticleCategoryLocales { get; set; }
        public virtual DbSet<ArticleLocale> ArticleLocales { get; set; }
        public virtual DbSet<Culture> Cultures { get; set; }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(x => x.Entity.GetType().GetProperty("CreateDate") != null))
            {
                if (entry.State == EntityState.Modified)
                {
                    // Ignore the CreatedTime updates on Modified entities. 
                    entry.Property("CreateDate").IsModified = false;
                }
            }

            foreach (var entry in ChangeTracker.Entries()
                .Where(
                    e =>  e.Entity.GetType().GetProperty("UpdatedDate") != null &&
                    (e.State == EntityState.Modified || e.State == EntityState.Added)
                )
            )
            {
                entry.Property("UpdatedDate").CurrentValue = DateTime.Now;
            }

            return base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>()
                .HasMany(e => e.ArticleLocales)
                .WithRequired(e => e.Article)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ArticleCategory>()
                .HasMany(e => e.ArticleCategoryLocales)
                .WithRequired(e => e.ArticleCategory)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Culture>()
                .HasMany(e => e.ArticleCategoryLocales)
                .WithRequired(e => e.Culture)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Culture>()
                .HasMany(e => e.ArticleLocales)
                .WithRequired(e => e.Culture)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<District>()
                .Property(e => e.ShippingPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<OrderDetail>()
                .Property(e => e.OrderID)
                .IsUnicode(false);

            modelBuilder.Entity<OrderDetail>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<OrderDetail>()
                .Property(e => e.Type)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.OrderID)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.PaymentMethodID)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.Commission)
                .HasPrecision(19, 4);

            modelBuilder.Entity<PaymentMethod>()
                .Property(e => e.PaymentMethodID)
                .IsUnicode(false);

            modelBuilder.Entity<PhotoAlbumCategory>()
                .HasMany(e => e.PhotoAlbums)
                .WithOptional(e => e.PhotoAlbumCategory)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Product>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Product>()
                .Property(e => e.SavePrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.ProductLengths)
                .WithOptional(e => e.Product)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Product>()
                .HasMany(e => e.ProductOfSames)
                .WithOptional(e => e.Product)
                .HasForeignKey(e => e.ProductParentID)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Product>()
                .HasMany(e => e.ProductOptionCategories)
                .WithOptional(e => e.Product)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Product>()
                .HasOptional(e => e.Rating1)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete();

            modelBuilder.Entity<ProductCategory>()
                .HasMany(e => e.Products)
                .WithOptional(e => e.ProductCategory)
                .HasForeignKey(e => e.CategoryID);

            modelBuilder.Entity<ProductOptionCategory>()
                .HasMany(e => e.ProductOptions)
                .WithOptional(e => e.ProductOptionCategory)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Province>()
                .Property(e => e.ShortName)
                .IsUnicode(false);

            modelBuilder.Entity<Province>()
                .Property(e => e.ShippingPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<WishList>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);
        }
    }
}
