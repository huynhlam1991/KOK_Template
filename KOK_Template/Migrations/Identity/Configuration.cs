namespace KOK_Template.Migrations.Identity
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<DBContext.IdentityDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\Identity";
        }

        protected override void Seed(DBContext.IdentityDbContext context)
        {
            new DBContext.Identity.SeedData(context).MigrateData();
        }
    }
}
