namespace KOK_Template.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDBMain : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AddressBook",
                c => new
                    {
                        AddressBookID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 20),
                        LastName = c.String(maxLength: 20),
                        Email = c.String(maxLength: 200),
                        HomePhone = c.String(maxLength: 20),
                        CellPhone = c.String(maxLength: 20),
                        Fax = c.String(maxLength: 20),
                        ReceiveEmail = c.Boolean(),
                        UserName = c.String(maxLength: 256),
                        Company = c.String(maxLength: 200),
                        Address1 = c.String(maxLength: 200),
                        Address2 = c.String(maxLength: 200),
                        ZipCode = c.String(maxLength: 20),
                        City = c.String(maxLength: 100),
                        CountryID = c.Int(),
                        ProvinceID = c.Int(),
                        DistrictID = c.Int(),
                        IsPrimary = c.Boolean(),
                        IsPrimaryBilling = c.Boolean(),
                        IsPrimaryShipping = c.Boolean(),
                        RoleName = c.String(maxLength: 256),
                        Gender = c.Boolean(),
                        Birthday = c.DateTime(),
                        ImageName = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.AddressBookID);
            
            CreateTable(
                "dbo.AdsBanner",
                c => new
                    {
                        AdsBannerID = c.Int(nullable: false, identity: true),
                        FileName = c.String(maxLength: 200),
                        AdsCategoryID = c.Int(),
                        CompanyName = c.String(maxLength: 200),
                        Website = c.String(maxLength: 200),
                        FromDate = c.DateTime(),
                        ToDate = c.DateTime(),
                        Priority = c.Int(),
                        IsAvailable = c.Boolean(),
                        Ratio = c.Double(),
                    })
                .PrimaryKey(t => t.AdsBannerID)
                .ForeignKey("dbo.AdsCategory", t => t.AdsCategoryID)
                .Index(t => t.AdsCategoryID);
            
            CreateTable(
                "dbo.AdsCategory",
                c => new
                    {
                        AdsCategoryID = c.Int(nullable: false, identity: true),
                        AdsCategoryName = c.String(maxLength: 100),
                        IsAvailable = c.Boolean(),
                    })
                .PrimaryKey(t => t.AdsCategoryID);
            
            CreateTable(
                "dbo.ArticleCategory",
                c => new
                    {
                        ArticleCategoryID = c.Int(nullable: false, identity: true),
                        ImageName = c.String(maxLength: 100),
                        ParentID = c.Int(),
                        SortOrder = c.Byte(),
                        IsShowOnMenu = c.Boolean(),
                        IsShowOnHomePage = c.Boolean(),
                        IsAvailable = c.Boolean(),
                        CreateDate = c.DateTime(),
                        UpdatedDate = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedBy = c.String(nullable: false),
                        UpdatedBy = c.String(nullable: false),
                        Note = c.String(),
                    })
                .PrimaryKey(t => t.ArticleCategoryID);
            
            CreateTable(
                "dbo.ArticleCategoryLocale",
                c => new
                    {
                        ArticleCategoryID = c.Int(nullable: false),
                        CultureID = c.Int(nullable: false),
                        MetaTitle = c.String(maxLength: 100),
                        MetaDescription = c.String(maxLength: 300),
                        CategoryName = c.String(maxLength: 100),
                        Description = c.String(maxLength: 500),
                        Content = c.String(),
                    })
                .PrimaryKey(t => new { t.ArticleCategoryID, t.CultureID })
                .ForeignKey("dbo.Culture", t => t.CultureID)
                .ForeignKey("dbo.ArticleCategory", t => t.ArticleCategoryID)
                .Index(t => t.ArticleCategoryID)
                .Index(t => t.CultureID);
            
            CreateTable(
                "dbo.Culture",
                c => new
                    {
                        CultureID = c.Int(nullable: false, identity: true),
                        CultureName = c.String(maxLength: 100),
                        DisplayName = c.String(maxLength: 100),
                        Flag = c.String(maxLength: 100),
                        IsAvailable = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CultureID);
            
            CreateTable(
                "dbo.ArticleLocale",
                c => new
                    {
                        ArticleID = c.Int(nullable: false),
                        CultureID = c.Int(nullable: false),
                        MetaTitle = c.String(maxLength: 500),
                        MetaDescription = c.String(maxLength: 1000),
                        Tag = c.String(maxLength: 200),
                        Title = c.String(maxLength: 100),
                        Description = c.String(maxLength: 1000),
                        Content = c.String(),
                    })
                .PrimaryKey(t => new { t.ArticleID, t.CultureID })
                .ForeignKey("dbo.Article", t => t.ArticleID)
                .ForeignKey("dbo.Culture", t => t.CultureID)
                .Index(t => t.ArticleID)
                .Index(t => t.CultureID);
            
            CreateTable(
                "dbo.Article",
                c => new
                    {
                        ArticleID = c.Int(nullable: false, identity: true),
                        ArticleCategoryID = c.Int(),
                        ImageName = c.String(maxLength: 100),
                        IsHot = c.Boolean(),
                        IsNew = c.Boolean(),
                        Priority = c.Int(),
                        IsShowOnHomePage = c.Boolean(nullable: false),
                        IsAvailable = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(),
                        UpdatedDate = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedBy = c.String(nullable: false),
                        UpdatedBy = c.String(nullable: false),
                        Note = c.String(),
                    })
                .PrimaryKey(t => t.ArticleID)
                .ForeignKey("dbo.ArticleCategory", t => t.ArticleCategoryID)
                .Index(t => t.ArticleCategoryID);
            
            CreateTable(
                "dbo.CareerCategory",
                c => new
                    {
                        CareerCategoryID = c.Int(nullable: false, identity: true),
                        CareerCategoryName = c.String(maxLength: 100),
                        CareerCategoryNameEn = c.String(maxLength: 100),
                        Description = c.String(maxLength: 500),
                        DescriptionEn = c.String(maxLength: 500),
                        Content = c.String(),
                        ContentEn = c.String(),
                        MetaTitle = c.String(maxLength: 100),
                        MetaTitleEn = c.String(maxLength: 100),
                        MetaDescription = c.String(maxLength: 300),
                        MetaDescriptionEn = c.String(maxLength: 300),
                        ImageName = c.String(maxLength: 100),
                        ParentID = c.Int(),
                        SortOrder = c.Byte(),
                        IsShowOnMenu = c.Boolean(),
                        IsShowOnHomePage = c.Boolean(),
                        IsAvailable = c.Boolean(),
                    })
                .PrimaryKey(t => t.CareerCategoryID);
            
            CreateTable(
                "dbo.Career",
                c => new
                    {
                        CareerID = c.Int(nullable: false, identity: true),
                        ImageName = c.String(maxLength: 100),
                        MetaTittle = c.String(maxLength: 500),
                        MetaDescription = c.String(maxLength: 1000),
                        CareerTitle = c.String(maxLength: 100),
                        Description = c.String(maxLength: 1000),
                        Content = c.String(),
                        Tag = c.String(maxLength: 200),
                        MetaTittleEn = c.String(maxLength: 500),
                        MetaDescriptionEn = c.String(maxLength: 1000),
                        CareerTitleEn = c.String(maxLength: 100),
                        DescriptionEn = c.String(maxLength: 1000),
                        ContentEn = c.String(),
                        TagEn = c.String(maxLength: 200),
                        CareerCategoryID = c.Int(),
                        CreateDate = c.DateTime(),
                        Priority = c.Int(),
                        IsShowOnHomePage = c.Boolean(),
                        IsAvailable = c.Boolean(),
                    })
                .PrimaryKey(t => t.CareerID)
                .ForeignKey("dbo.CareerCategory", t => t.CareerCategoryID)
                .Index(t => t.CareerCategoryID);
            
            CreateTable(
                "dbo.Comment",
                c => new
                    {
                        CommentID = c.Int(nullable: false, identity: true),
                        UserName = c.String(maxLength: 256),
                        Link = c.String(maxLength: 1000),
                        Title = c.String(maxLength: 200),
                        Content = c.String(),
                        CreateDate = c.DateTime(),
                        UpdateDate = c.DateTime(),
                        Priority = c.Int(),
                        IsApproved = c.Boolean(),
                        IsAvailable = c.Boolean(),
                    })
                .PrimaryKey(t => t.CommentID);
            
            CreateTable(
                "dbo.Country",
                c => new
                    {
                        CountryID = c.Int(nullable: false, identity: true),
                        CountryName = c.String(maxLength: 50),
                        Nationality = c.String(maxLength: 50),
                        ShortName = c.String(maxLength: 50),
                        Priority = c.Int(),
                        IsAvailable = c.Boolean(),
                    })
                .PrimaryKey(t => t.CountryID);
            
            CreateTable(
                "dbo.DeliveryMethods",
                c => new
                    {
                        DeliveryMethodsID = c.Int(nullable: false, identity: true),
                        DeliveryMethodsName = c.String(maxLength: 100),
                        DeliveryMethodsNameEn = c.String(maxLength: 100),
                        IsAvailable = c.Boolean(),
                    })
                .PrimaryKey(t => t.DeliveryMethodsID);
            
            CreateTable(
                "dbo.District",
                c => new
                    {
                        DistrictID = c.Int(nullable: false, identity: true),
                        DistrictName = c.String(maxLength: 100),
                        ProvinceID = c.Int(),
                        IsAvailable = c.Boolean(),
                        Priority = c.Int(),
                        ShippingPrice = c.Decimal(storeType: "money"),
                        DistrictNameEn = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.DistrictID);
            
            CreateTable(
                "dbo.DownloadCategory",
                c => new
                    {
                        DownloadCategoryID = c.Int(nullable: false, identity: true),
                        Description = c.String(maxLength: 500),
                        DescriptionEn = c.String(maxLength: 500),
                        Content = c.String(),
                        ContentEn = c.String(),
                        MetaTitle = c.String(maxLength: 100),
                        MetaTitleEn = c.String(maxLength: 100),
                        MetaDescription = c.String(maxLength: 300),
                        MetaDescriptionEn = c.String(maxLength: 300),
                        ImageName = c.String(maxLength: 200),
                        DownloadCategoryName = c.String(maxLength: 100),
                        DownloadCategoryNameEn = c.String(maxLength: 100),
                        IsShowOnMenu = c.Boolean(),
                        IsShowOnHomePage = c.Boolean(),
                        IsAvailable = c.Boolean(),
                        Priority = c.Int(),
                    })
                .PrimaryKey(t => t.DownloadCategoryID);
            
            CreateTable(
                "dbo.Download",
                c => new
                    {
                        DownloadID = c.Int(nullable: false, identity: true),
                        ImageName = c.String(maxLength: 200),
                        FilePath = c.String(maxLength: 200),
                        DownloadName = c.String(maxLength: 200),
                        DownloadNameEn = c.String(maxLength: 200),
                        DownloadCategoryID = c.Int(),
                        CreateDate = c.DateTime(),
                        IsAvailable = c.Boolean(),
                        Priority = c.Int(),
                    })
                .PrimaryKey(t => t.DownloadID)
                .ForeignKey("dbo.DownloadCategory", t => t.DownloadCategoryID)
                .Index(t => t.DownloadCategoryID);
            
            CreateTable(
                "dbo.Manufacturer",
                c => new
                    {
                        ManufacturerID = c.Int(nullable: false, identity: true),
                        ManufacturerName = c.String(maxLength: 100),
                        ManufacturerNameEn = c.String(maxLength: 100),
                        IsAvailable = c.Boolean(),
                        Priority = c.Int(),
                    })
                .PrimaryKey(t => t.ManufacturerID);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        ImageName = c.String(maxLength: 100),
                        MetaTittle = c.String(maxLength: 500),
                        MetaDescription = c.String(maxLength: 1000),
                        ProductName = c.String(maxLength: 200),
                        Description = c.String(maxLength: 1000),
                        Content = c.String(),
                        Tag = c.String(maxLength: 200),
                        MetaTittleEn = c.String(maxLength: 500),
                        MetaDescriptionEn = c.String(maxLength: 1000),
                        ProductNameEn = c.String(maxLength: 200),
                        DescriptionEn = c.String(maxLength: 1000),
                        ContentEn = c.String(),
                        TagEn = c.String(maxLength: 200),
                        Price = c.Decimal(storeType: "money"),
                        OtherPrice = c.String(maxLength: 200),
                        SavePrice = c.Decimal(storeType: "money"),
                        Discount = c.Short(),
                        CategoryID = c.Int(),
                        ManufacturerID = c.Int(),
                        OriginID = c.Int(),
                        InStock = c.Boolean(),
                        Views = c.Int(),
                        Rating = c.Double(),
                        CreateDate = c.DateTime(),
                        IsHot = c.Boolean(),
                        IsNew = c.Boolean(),
                        IsBestSeller = c.Boolean(),
                        IsSaleOff = c.Boolean(),
                        IsShowOnHomePage = c.Boolean(),
                        Priority = c.Int(),
                        IsAvailable = c.Boolean(),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.Manufacturer", t => t.ManufacturerID)
                .ForeignKey("dbo.Origin", t => t.OriginID)
                .ForeignKey("dbo.ProductCategory", t => t.CategoryID)
                .Index(t => t.CategoryID)
                .Index(t => t.ManufacturerID)
                .Index(t => t.OriginID);
            
            CreateTable(
                "dbo.Origin",
                c => new
                    {
                        OriginID = c.Int(nullable: false, identity: true),
                        OriginName = c.String(maxLength: 100),
                        OriginNameEn = c.String(maxLength: 100),
                        IsAvailable = c.Boolean(),
                        Priority = c.Int(),
                    })
                .PrimaryKey(t => t.OriginID);
            
            CreateTable(
                "dbo.ProductCategory",
                c => new
                    {
                        ProductCategoryID = c.Int(nullable: false, identity: true),
                        ProductCategoryName = c.String(maxLength: 100),
                        ProductCategoryNameEn = c.String(maxLength: 100),
                        Description = c.String(maxLength: 500),
                        DescriptionEn = c.String(maxLength: 500),
                        Content = c.String(),
                        ContentEn = c.String(),
                        MetaTitle = c.String(maxLength: 100),
                        MetaTitleEn = c.String(maxLength: 100),
                        MetaDescription = c.String(maxLength: 300),
                        MetaDescriptionEn = c.String(maxLength: 300),
                        ImageName = c.String(maxLength: 100),
                        ParentID = c.Int(),
                        SortOrder = c.Byte(),
                        IsShowOnMenu = c.Boolean(),
                        IsShowOnHomePage = c.Boolean(),
                        IsAvailable = c.Boolean(),
                    })
                .PrimaryKey(t => t.ProductCategoryID);
            
            CreateTable(
                "dbo.ProductDownload",
                c => new
                    {
                        ProductDownloadID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(),
                        FileName = c.String(maxLength: 100),
                        FileNameEn = c.String(maxLength: 100),
                        LinkDownload = c.String(maxLength: 100),
                        IsAvailable = c.Boolean(),
                        Priority = c.Int(),
                    })
                .PrimaryKey(t => t.ProductDownloadID)
                .ForeignKey("dbo.Product", t => t.ProductID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.ProductImage",
                c => new
                    {
                        ProductImageID = c.Int(nullable: false, identity: true),
                        ImageName = c.String(maxLength: 200),
                        Title = c.String(maxLength: 200),
                        Descripttion = c.String(maxLength: 500),
                        TitleEn = c.String(maxLength: 200),
                        DescripttionEn = c.String(maxLength: 500),
                        ProductID = c.Int(),
                        IsAvailable = c.Boolean(),
                        Priority = c.Int(),
                    })
                .PrimaryKey(t => t.ProductImageID)
                .ForeignKey("dbo.Product", t => t.ProductID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.ProductLength",
                c => new
                    {
                        ProductLengthID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(),
                        ProductLengthName = c.String(maxLength: 200),
                        ProductLengthNameEn = c.String(maxLength: 200),
                        IsAvailable = c.Boolean(),
                        Priority = c.Int(),
                        CreateDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.ProductLengthID)
                .ForeignKey("dbo.Product", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.ProductOfSame",
                c => new
                    {
                        ProductOfSameID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(),
                        CreateDate = c.DateTime(),
                        IsAvailable = c.Boolean(),
                        Priority = c.Int(),
                        ProductParentID = c.Int(),
                    })
                .PrimaryKey(t => t.ProductOfSameID)
                .ForeignKey("dbo.Product", t => t.ProductParentID, cascadeDelete: true)
                .Index(t => t.ProductParentID);
            
            CreateTable(
                "dbo.ProductOptionCategory",
                c => new
                    {
                        ProductOptionCategoryID = c.Int(nullable: false, identity: true),
                        ProductOptionCategoryName = c.String(maxLength: 100),
                        ProductOptionCategoryNameEn = c.String(maxLength: 100),
                        Description = c.String(maxLength: 500),
                        DescriptionEn = c.String(maxLength: 500),
                        Content = c.String(),
                        ContentEn = c.String(),
                        MetaTitle = c.String(maxLength: 100),
                        MetaTitleEn = c.String(maxLength: 100),
                        MetaDescription = c.String(maxLength: 300),
                        MetaDescriptionEn = c.String(maxLength: 300),
                        ImageName = c.String(maxLength: 100),
                        ParentID = c.Int(),
                        SortOrder = c.Int(),
                        IsShowOnMenu = c.Boolean(),
                        IsShowOnHomePage = c.Boolean(),
                        IsAvailable = c.Boolean(),
                        ProductID = c.Int(),
                    })
                .PrimaryKey(t => t.ProductOptionCategoryID)
                .ForeignKey("dbo.Product", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.ProductOption",
                c => new
                    {
                        ProductOptionID = c.Int(nullable: false, identity: true),
                        ImageName = c.String(maxLength: 100),
                        MetaTittle = c.String(maxLength: 500),
                        MetaDescription = c.String(maxLength: 1000),
                        ProductOptionTitle = c.String(maxLength: 100),
                        Description = c.String(maxLength: 1000),
                        Content = c.String(),
                        MetaTittleEn = c.String(maxLength: 500),
                        MetaDescriptionEn = c.String(maxLength: 1000),
                        ProductOptionTitleEn = c.String(maxLength: 100),
                        DescriptionEn = c.String(maxLength: 1000),
                        ContentEn = c.String(),
                        TagEn = c.String(maxLength: 200),
                        ProductOptionCategoryID = c.Int(),
                        Tag = c.String(maxLength: 200),
                        CreateDate = c.DateTime(),
                        Priority = c.Int(),
                        IsShowOnHomePage = c.Boolean(),
                        IsHot = c.Boolean(),
                        IsNew = c.Boolean(),
                        IsAvailable = c.Boolean(),
                    })
                .PrimaryKey(t => t.ProductOptionID)
                .ForeignKey("dbo.ProductOptionCategory", t => t.ProductOptionCategoryID, cascadeDelete: true)
                .Index(t => t.ProductOptionCategoryID);
            
            CreateTable(
                "dbo.Rating",
                c => new
                    {
                        ProductID = c.Int(nullable: false),
                        Rating1 = c.Int(nullable: false),
                        Rating2 = c.Int(nullable: false),
                        Rating3 = c.Int(nullable: false),
                        Rating4 = c.Int(nullable: false),
                        Rating5 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.Product", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.MenuPosition",
                c => new
                    {
                        MenuPositionID = c.Int(nullable: false, identity: true),
                        MenuPositionName = c.String(maxLength: 100),
                        IsAvailable = c.Boolean(),
                    })
                .PrimaryKey(t => t.MenuPositionID);
            
            CreateTable(
                "dbo.Menu",
                c => new
                    {
                        MenuID = c.Int(nullable: false, identity: true),
                        ImageName = c.String(maxLength: 100),
                        ImageNameEn = c.String(maxLength: 100),
                        MenuTitle = c.String(maxLength: 100),
                        MenuTitleEn = c.String(maxLength: 100),
                        Link = c.String(maxLength: 500),
                        LinkEn = c.String(maxLength: 500),
                        MenuPositionID = c.Int(),
                        ParentID = c.Int(),
                        SortOrder = c.Byte(),
                        IsAvailable = c.Boolean(),
                    })
                .PrimaryKey(t => t.MenuID)
                .ForeignKey("dbo.MenuPosition", t => t.MenuPositionID)
                .Index(t => t.MenuPositionID);
            
            CreateTable(
                "dbo.Newsletter",
                c => new
                    {
                        Email = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.Email);
            
            CreateTable(
                "dbo.OrderDetail",
                c => new
                    {
                        OrderDetailID = c.Int(nullable: false, identity: true),
                        OrderID = c.String(maxLength: 10, unicode: false),
                        ProductID = c.Int(),
                        ProductName = c.String(maxLength: 100),
                        Description = c.String(maxLength: 1000),
                        Quantity = c.Int(),
                        Price = c.Decimal(storeType: "money"),
                        Type = c.String(maxLength: 10, unicode: false),
                        CreateBy = c.String(maxLength: 256),
                        CreateDate = c.DateTime(),
                        ProductColorName = c.String(maxLength: 100),
                        ProductColorNameEn = c.String(maxLength: 100),
                        Email = c.String(maxLength: 200),
                        ProductCode = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.OrderDetailID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderID = c.String(nullable: false, maxLength: 10, unicode: false),
                        UserName = c.String(maxLength: 256),
                        OrderStatusID = c.Int(),
                        ShippingStatusID = c.Int(),
                        PaymentMethodID = c.String(maxLength: 20, unicode: false),
                        BillingAddressID = c.Int(),
                        ShippingAddressID = c.Int(),
                        Notes = c.String(maxLength: 1000),
                        CreateDate = c.DateTime(),
                        Commission = c.Decimal(storeType: "money"),
                        ServiceID = c.Int(),
                        DeliveryMethodsID = c.Int(),
                        DeliveryDate = c.DateTime(),
                        DeliveryAddress = c.String(maxLength: 200),
                        CustomerAddressID = c.Int(),
                        Email = c.String(maxLength: 200),
                        PayStatusID = c.Int(),
                    })
                .PrimaryKey(t => t.OrderID);
            
            CreateTable(
                "dbo.OrderStatus",
                c => new
                    {
                        OrderStatusID = c.Int(nullable: false, identity: true),
                        OrderStatusName = c.String(maxLength: 100),
                        OrderStatusNameEn = c.String(maxLength: 100),
                        IsAvailable = c.Boolean(),
                    })
                .PrimaryKey(t => t.OrderStatusID);
            
            CreateTable(
                "dbo.Partner",
                c => new
                    {
                        PartnerID = c.Int(nullable: false, identity: true),
                        PartnerName = c.String(maxLength: 100),
                        PartnerNameEn = c.String(maxLength: 100),
                        PartnerImage = c.String(maxLength: 100),
                        Address = c.String(maxLength: 100),
                        LinkWebsite = c.String(maxLength: 100),
                        CreateDate = c.DateTime(),
                        Priority = c.Int(),
                        IsAvailable = c.Boolean(),
                    })
                .PrimaryKey(t => t.PartnerID);
            
            CreateTable(
                "dbo.PaymentMethod",
                c => new
                    {
                        PaymentMethodID = c.String(nullable: false, maxLength: 20, unicode: false),
                        PaymentMethodName = c.String(maxLength: 50),
                        PaymentMethodNameEn = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.PaymentMethodID);
            
            CreateTable(
                "dbo.PayStatus",
                c => new
                    {
                        PayStatusID = c.Int(nullable: false, identity: true),
                        PayStatusName = c.String(maxLength: 100),
                        PayStatusNameEn = c.String(maxLength: 100),
                        IsAvailable = c.Boolean(),
                    })
                .PrimaryKey(t => t.PayStatusID);
            
            CreateTable(
                "dbo.PhotoAlbumCategory",
                c => new
                    {
                        PhotoAlbumCategoryID = c.Int(nullable: false, identity: true),
                        ImageName = c.String(maxLength: 200),
                        PhotoAlbumCategoryName = c.String(maxLength: 100),
                        PhotoAlbumCategoryNameEn = c.String(maxLength: 100),
                        IsShowOnMenu = c.Boolean(),
                        IsShowOnHomePage = c.Boolean(),
                        IsAvailable = c.Boolean(),
                        Priority = c.Int(),
                    })
                .PrimaryKey(t => t.PhotoAlbumCategoryID);
            
            CreateTable(
                "dbo.PhotoAlbum",
                c => new
                    {
                        PhotoAlbumID = c.Int(nullable: false, identity: true),
                        ImageName = c.String(maxLength: 200),
                        Title = c.String(maxLength: 200),
                        Descripttion = c.String(maxLength: 500),
                        TitleEn = c.String(maxLength: 200),
                        DescripttionEn = c.String(maxLength: 500),
                        IsAvailable = c.Boolean(),
                        Priority = c.Int(),
                        PhotoAlbumCategoryID = c.Int(),
                    })
                .PrimaryKey(t => t.PhotoAlbumID)
                .ForeignKey("dbo.PhotoAlbumCategory", t => t.PhotoAlbumCategoryID, cascadeDelete: true)
                .Index(t => t.PhotoAlbumCategoryID);
            
            CreateTable(
                "dbo.ProductOfLength",
                c => new
                    {
                        ProductOfLengthID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(),
                        ProductLengthID = c.Int(),
                        IsAvailable = c.Boolean(),
                        Priority = c.Int(),
                        CreateDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.ProductOfLengthID);
            
            CreateTable(
                "dbo.ProductSizeColor",
                c => new
                    {
                        ProductSizeColorID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(),
                        ProductOptionCategoryID = c.Int(),
                        ProductLengthID = c.Int(),
                        Quantity = c.Int(),
                        QuantitySale = c.Int(),
                        InStock = c.Boolean(),
                        IsAvailable = c.Boolean(),
                        CreateDate = c.DateTime(),
                        Priority = c.Int(),
                    })
                .PrimaryKey(t => t.ProductSizeColorID);
            
            CreateTable(
                "dbo.ProjectCategory",
                c => new
                    {
                        ProjectCategoryID = c.Int(nullable: false, identity: true),
                        ProjectCategoryName = c.String(maxLength: 100),
                        ProjectCategoryNameEn = c.String(maxLength: 100),
                        Description = c.String(maxLength: 500),
                        DescriptionEn = c.String(maxLength: 500),
                        Content = c.String(),
                        ContentEn = c.String(),
                        MetaTitle = c.String(maxLength: 100),
                        MetaTitleEn = c.String(maxLength: 100),
                        MetaDescription = c.String(maxLength: 300),
                        MetaDescriptionEn = c.String(maxLength: 300),
                        ImageName = c.String(maxLength: 100),
                        ParentID = c.Int(),
                        SortOrder = c.Byte(),
                        IsShowOnMenu = c.Boolean(),
                        IsShowOnHomePage = c.Boolean(),
                        IsAvailable = c.Boolean(),
                    })
                .PrimaryKey(t => t.ProjectCategoryID);
            
            CreateTable(
                "dbo.Project",
                c => new
                    {
                        ProjectID = c.Int(nullable: false, identity: true),
                        ImageName = c.String(maxLength: 100),
                        MetaTittle = c.String(maxLength: 500),
                        MetaDescription = c.String(maxLength: 1000),
                        ProjectTitle = c.String(maxLength: 100),
                        Description = c.String(maxLength: 1000),
                        Content = c.String(),
                        MetaTittleEn = c.String(maxLength: 500),
                        MetaDescriptionEn = c.String(maxLength: 1000),
                        ProjectTitleEn = c.String(maxLength: 100),
                        DescriptionEn = c.String(maxLength: 1000),
                        ContentEn = c.String(),
                        TagEn = c.String(maxLength: 200),
                        ProjectCategoryID = c.Int(),
                        Tag = c.String(maxLength: 200),
                        CreateDate = c.DateTime(),
                        IsHot = c.Boolean(),
                        IsNew = c.Boolean(),
                        IsShowOnHomePage = c.Boolean(),
                        IsAvailable = c.Boolean(),
                        Priority = c.Int(),
                    })
                .PrimaryKey(t => t.ProjectID)
                .ForeignKey("dbo.ProjectCategory", t => t.ProjectCategoryID)
                .Index(t => t.ProjectCategoryID);
            
            CreateTable(
                "dbo.ProjectDownload",
                c => new
                    {
                        ProjectDownloadID = c.Int(nullable: false, identity: true),
                        ProjectID = c.Int(),
                        FileName = c.String(maxLength: 100),
                        FileNameEn = c.String(maxLength: 100),
                        LinkDownload = c.String(maxLength: 100),
                        IsAvailable = c.Boolean(),
                        Priority = c.Int(),
                    })
                .PrimaryKey(t => t.ProjectDownloadID)
                .ForeignKey("dbo.Project", t => t.ProjectID)
                .Index(t => t.ProjectID);
            
            CreateTable(
                "dbo.ProjectImage",
                c => new
                    {
                        ProjectImageID = c.Int(nullable: false, identity: true),
                        ImageName = c.String(maxLength: 200),
                        Title = c.String(maxLength: 200),
                        Descripttion = c.String(maxLength: 500),
                        TitleEn = c.String(maxLength: 200),
                        DescripttionEn = c.String(maxLength: 500),
                        ProjectID = c.Int(),
                        IsAvailable = c.Boolean(),
                        Priority = c.Int(),
                    })
                .PrimaryKey(t => t.ProjectImageID)
                .ForeignKey("dbo.Project", t => t.ProjectID)
                .Index(t => t.ProjectID);
            
            CreateTable(
                "dbo.ProjectVideo",
                c => new
                    {
                        ProjectVideoID = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 100),
                        Description = c.String(maxLength: 500),
                        TitleEn = c.String(maxLength: 100),
                        DescriptionEn = c.String(maxLength: 500),
                        ImagePath = c.String(maxLength: 100),
                        ProjectVideoPath = c.String(maxLength: 100),
                        CreateDate = c.DateTime(),
                        ProjectID = c.Int(),
                        IsAvailable = c.Boolean(),
                        Priority = c.Int(),
                    })
                .PrimaryKey(t => t.ProjectVideoID)
                .ForeignKey("dbo.Project", t => t.ProjectID)
                .Index(t => t.ProjectID);
            
            CreateTable(
                "dbo.Province",
                c => new
                    {
                        ProvinceID = c.Int(nullable: false, identity: true),
                        ProvinceName = c.String(maxLength: 50),
                        IsAvailable = c.Boolean(),
                        Priority = c.Int(),
                        ShortName = c.String(maxLength: 3, unicode: false),
                        CountryID = c.Int(),
                        ShippingPrice = c.Decimal(storeType: "money"),
                    })
                .PrimaryKey(t => t.ProvinceID);
            
            CreateTable(
                "dbo.ServiceCategory",
                c => new
                    {
                        ServiceCategoryID = c.Int(nullable: false, identity: true),
                        ServiceCategoryName = c.String(maxLength: 100),
                        ServiceCategoryNameEn = c.String(maxLength: 100),
                        Description = c.String(maxLength: 500),
                        DescriptionEn = c.String(maxLength: 500),
                        Content = c.String(),
                        ContentEn = c.String(),
                        MetaTitle = c.String(maxLength: 100),
                        MetaTitleEn = c.String(maxLength: 100),
                        MetaDescription = c.String(maxLength: 300),
                        MetaDescriptionEn = c.String(maxLength: 300),
                        ImageName = c.String(maxLength: 100),
                        ParentID = c.Int(),
                        SortOrder = c.Byte(),
                        IsShowOnMenu = c.Boolean(),
                        IsShowOnHomePage = c.Boolean(),
                        IsAvailable = c.Boolean(),
                    })
                .PrimaryKey(t => t.ServiceCategoryID);
            
            CreateTable(
                "dbo.Service",
                c => new
                    {
                        ServiceID = c.Int(nullable: false, identity: true),
                        ImageName = c.String(maxLength: 100),
                        MetaTittle = c.String(maxLength: 500),
                        MetaDescription = c.String(maxLength: 1000),
                        ServiceTitle = c.String(maxLength: 100),
                        Description = c.String(maxLength: 1000),
                        Content = c.String(),
                        MetaTittleEn = c.String(maxLength: 500),
                        MetaDescriptionEn = c.String(maxLength: 1000),
                        ServiceTitleEn = c.String(maxLength: 100),
                        DescriptionEn = c.String(maxLength: 1000),
                        ContentEn = c.String(),
                        TagEn = c.String(maxLength: 200),
                        ServiceCategoryID = c.Int(),
                        Tag = c.String(maxLength: 200),
                        CreateDate = c.DateTime(),
                        Priority = c.Int(),
                        IsShowOnHomePage = c.Boolean(),
                        IsHot = c.Boolean(),
                        IsNew = c.Boolean(),
                        IsAvailable = c.Boolean(),
                    })
                .PrimaryKey(t => t.ServiceID)
                .ForeignKey("dbo.ServiceCategory", t => t.ServiceCategoryID)
                .Index(t => t.ServiceCategoryID);
            
            CreateTable(
                "dbo.ShippingStatus",
                c => new
                    {
                        ShippingStatusID = c.Int(nullable: false, identity: true),
                        ShippingStatusName = c.String(maxLength: 50),
                        ShippingStatusNameEn = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ShippingStatusID);
            
            CreateTable(
                "dbo.UserProfile",
                c => new
                    {
                        UserID = c.Guid(nullable: false),
                        CompanyName = c.String(maxLength: 200),
                        FullName = c.String(maxLength: 200),
                        Address = c.String(maxLength: 200),
                        HomePhone = c.String(maxLength: 20),
                        CellPhone = c.String(maxLength: 20),
                        Fax = c.String(maxLength: 20),
                        AvatarImage = c.String(maxLength: 200),
                        CreateDate = c.DateTime(),
                        UpdateDate = c.DateTime(),
                        IsAvailable = c.Boolean(),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateTable(
                "dbo.VideoCategory",
                c => new
                    {
                        VideoCategoryID = c.Int(nullable: false, identity: true),
                        Description = c.String(maxLength: 500),
                        DescriptionEn = c.String(maxLength: 500),
                        Content = c.String(),
                        ContentEn = c.String(),
                        MetaTitle = c.String(maxLength: 100),
                        MetaTitleEn = c.String(maxLength: 100),
                        MetaDescription = c.String(maxLength: 300),
                        MetaDescriptionEn = c.String(maxLength: 300),
                        ImageName = c.String(maxLength: 100),
                        VideoCategoryName = c.String(maxLength: 100),
                        VideoCategoryNameEn = c.String(maxLength: 100),
                        IsShowOnMenu = c.Boolean(),
                        IsShowOnHomePage = c.Boolean(),
                        IsAvailable = c.Boolean(),
                        Priority = c.Int(),
                    })
                .PrimaryKey(t => t.VideoCategoryID);
            
            CreateTable(
                "dbo.Video",
                c => new
                    {
                        VideoID = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 100),
                        Description = c.String(maxLength: 500),
                        TitleEn = c.String(maxLength: 100),
                        DescriptionEn = c.String(maxLength: 500),
                        ImagePath = c.String(maxLength: 100),
                        VideoPath = c.String(maxLength: 100),
                        GLobalEmbedScript = c.String(maxLength: 1000),
                        CreateDate = c.DateTime(),
                        VideoCategoryID = c.Int(),
                        IsAvailable = c.Boolean(),
                        Priority = c.Int(),
                    })
                .PrimaryKey(t => t.VideoID)
                .ForeignKey("dbo.VideoCategory", t => t.VideoCategoryID)
                .Index(t => t.VideoCategoryID);
            
            CreateTable(
                "dbo.Visitor",
                c => new
                    {
                        VisitorID = c.Int(nullable: false, identity: true),
                        CreateDate = c.DateTime(),
                        Visitors = c.Long(),
                    })
                .PrimaryKey(t => t.VisitorID);
            
            CreateTable(
                "dbo.WishList",
                c => new
                    {
                        ProductID = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        Quantity = c.Int(),
                        Price = c.Decimal(storeType: "money"),
                        CreateDate = c.DateTime(),
                        ImageName = c.String(maxLength: 200),
                        ProductName = c.String(maxLength: 200),
                        ProductNameEn = c.String(maxLength: 200),
                        ProductCode = c.String(maxLength: 50),
                        ProductOptionCategoryID = c.Int(),
                        ProductOptionCategoryName = c.String(maxLength: 200),
                        ProductLengthID = c.Int(),
                        ProductLengthName = c.String(maxLength: 200),
                        ProductSizeColorID = c.Int(),
                        QuantityList = c.Int(),
                    })
                .PrimaryKey(t => new { t.ProductID, t.UserName });
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Video", "VideoCategoryID", "dbo.VideoCategory");
            DropForeignKey("dbo.Service", "ServiceCategoryID", "dbo.ServiceCategory");
            DropForeignKey("dbo.ProjectVideo", "ProjectID", "dbo.Project");
            DropForeignKey("dbo.ProjectImage", "ProjectID", "dbo.Project");
            DropForeignKey("dbo.ProjectDownload", "ProjectID", "dbo.Project");
            DropForeignKey("dbo.Project", "ProjectCategoryID", "dbo.ProjectCategory");
            DropForeignKey("dbo.PhotoAlbum", "PhotoAlbumCategoryID", "dbo.PhotoAlbumCategory");
            DropForeignKey("dbo.Menu", "MenuPositionID", "dbo.MenuPosition");
            DropForeignKey("dbo.Rating", "ProductID", "dbo.Product");
            DropForeignKey("dbo.ProductOptionCategory", "ProductID", "dbo.Product");
            DropForeignKey("dbo.ProductOption", "ProductOptionCategoryID", "dbo.ProductOptionCategory");
            DropForeignKey("dbo.ProductOfSame", "ProductParentID", "dbo.Product");
            DropForeignKey("dbo.ProductLength", "ProductID", "dbo.Product");
            DropForeignKey("dbo.ProductImage", "ProductID", "dbo.Product");
            DropForeignKey("dbo.ProductDownload", "ProductID", "dbo.Product");
            DropForeignKey("dbo.Product", "CategoryID", "dbo.ProductCategory");
            DropForeignKey("dbo.Product", "OriginID", "dbo.Origin");
            DropForeignKey("dbo.Product", "ManufacturerID", "dbo.Manufacturer");
            DropForeignKey("dbo.Download", "DownloadCategoryID", "dbo.DownloadCategory");
            DropForeignKey("dbo.Career", "CareerCategoryID", "dbo.CareerCategory");
            DropForeignKey("dbo.ArticleCategoryLocale", "ArticleCategoryID", "dbo.ArticleCategory");
            DropForeignKey("dbo.ArticleLocale", "CultureID", "dbo.Culture");
            DropForeignKey("dbo.ArticleLocale", "ArticleID", "dbo.Article");
            DropForeignKey("dbo.Article", "ArticleCategoryID", "dbo.ArticleCategory");
            DropForeignKey("dbo.ArticleCategoryLocale", "CultureID", "dbo.Culture");
            DropForeignKey("dbo.AdsBanner", "AdsCategoryID", "dbo.AdsCategory");
            DropIndex("dbo.Video", new[] { "VideoCategoryID" });
            DropIndex("dbo.Service", new[] { "ServiceCategoryID" });
            DropIndex("dbo.ProjectVideo", new[] { "ProjectID" });
            DropIndex("dbo.ProjectImage", new[] { "ProjectID" });
            DropIndex("dbo.ProjectDownload", new[] { "ProjectID" });
            DropIndex("dbo.Project", new[] { "ProjectCategoryID" });
            DropIndex("dbo.PhotoAlbum", new[] { "PhotoAlbumCategoryID" });
            DropIndex("dbo.Menu", new[] { "MenuPositionID" });
            DropIndex("dbo.Rating", new[] { "ProductID" });
            DropIndex("dbo.ProductOption", new[] { "ProductOptionCategoryID" });
            DropIndex("dbo.ProductOptionCategory", new[] { "ProductID" });
            DropIndex("dbo.ProductOfSame", new[] { "ProductParentID" });
            DropIndex("dbo.ProductLength", new[] { "ProductID" });
            DropIndex("dbo.ProductImage", new[] { "ProductID" });
            DropIndex("dbo.ProductDownload", new[] { "ProductID" });
            DropIndex("dbo.Product", new[] { "OriginID" });
            DropIndex("dbo.Product", new[] { "ManufacturerID" });
            DropIndex("dbo.Product", new[] { "CategoryID" });
            DropIndex("dbo.Download", new[] { "DownloadCategoryID" });
            DropIndex("dbo.Career", new[] { "CareerCategoryID" });
            DropIndex("dbo.Article", new[] { "ArticleCategoryID" });
            DropIndex("dbo.ArticleLocale", new[] { "CultureID" });
            DropIndex("dbo.ArticleLocale", new[] { "ArticleID" });
            DropIndex("dbo.ArticleCategoryLocale", new[] { "CultureID" });
            DropIndex("dbo.ArticleCategoryLocale", new[] { "ArticleCategoryID" });
            DropIndex("dbo.AdsBanner", new[] { "AdsCategoryID" });
            DropTable("dbo.WishList");
            DropTable("dbo.Visitor");
            DropTable("dbo.Video");
            DropTable("dbo.VideoCategory");
            DropTable("dbo.UserProfile");
            DropTable("dbo.ShippingStatus");
            DropTable("dbo.Service");
            DropTable("dbo.ServiceCategory");
            DropTable("dbo.Province");
            DropTable("dbo.ProjectVideo");
            DropTable("dbo.ProjectImage");
            DropTable("dbo.ProjectDownload");
            DropTable("dbo.Project");
            DropTable("dbo.ProjectCategory");
            DropTable("dbo.ProductSizeColor");
            DropTable("dbo.ProductOfLength");
            DropTable("dbo.PhotoAlbum");
            DropTable("dbo.PhotoAlbumCategory");
            DropTable("dbo.PayStatus");
            DropTable("dbo.PaymentMethod");
            DropTable("dbo.Partner");
            DropTable("dbo.OrderStatus");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderDetail");
            DropTable("dbo.Newsletter");
            DropTable("dbo.Menu");
            DropTable("dbo.MenuPosition");
            DropTable("dbo.Rating");
            DropTable("dbo.ProductOption");
            DropTable("dbo.ProductOptionCategory");
            DropTable("dbo.ProductOfSame");
            DropTable("dbo.ProductLength");
            DropTable("dbo.ProductImage");
            DropTable("dbo.ProductDownload");
            DropTable("dbo.ProductCategory");
            DropTable("dbo.Origin");
            DropTable("dbo.Product");
            DropTable("dbo.Manufacturer");
            DropTable("dbo.Download");
            DropTable("dbo.DownloadCategory");
            DropTable("dbo.District");
            DropTable("dbo.DeliveryMethods");
            DropTable("dbo.Country");
            DropTable("dbo.Comment");
            DropTable("dbo.Career");
            DropTable("dbo.CareerCategory");
            DropTable("dbo.Article");
            DropTable("dbo.ArticleLocale");
            DropTable("dbo.Culture");
            DropTable("dbo.ArticleCategoryLocale");
            DropTable("dbo.ArticleCategory");
            DropTable("dbo.AdsCategory");
            DropTable("dbo.AdsBanner");
            DropTable("dbo.AddressBook");
        }
    }
}
