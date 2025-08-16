
using CoreSystem.DAL.Context.Models;
using Domain.Entities.Data;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class MarketPlaceContext : DbContext, IMarketPlaceContext
    {
        public MarketPlaceContext(DbContextOptions<MarketPlaceContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MarketPlaceContext).Assembly);
        }

        public DbSet<tAmazonAccount> AmazonAccounts { get; set; }
        public DbSet<tAttribute> Attributes { get; set; }
        public DbSet<tAttributeGroup> AttributeGroups { get; set; }
        public DbSet<tAttributeValue> AttributeValues { get; set; }
        public DbSet<tCondition> Conditions { get; set; }
        public DbSet<tCustomer> Customers { get; set; }
        public DbSet<tCustomerAddress> CustomerAddresses { get; set; }
        public DbSet<tCustomerGroup> CustomerGroups { get; set; }
        public DbSet<tEbayAccount> EbayAccounts { get; set; }
        public DbSet<tKauflandAccount> KauflandAccounts { get; set; }
        public DbSet<tLanguage> Languages { get; set; }
        public DbSet<tLogEntry> LogEntries { get; set; }
        public DbSet<tLogLevel> LogLevels { get; set; }
        public DbSet<tLogType> LogTypes { get; set; }
        public DbSet<tManufacturer> Manufacturers { get; set; }

        public DbSet<tMarketplaceType> MarketplaceTypes { get; set; }
        public DbSet<tOdooAccount> OdooAccounts { get; set; }
        public DbSet<tOrder> Orders { get; set; }
        public DbSet<tOrderPosition> OrderPositions { get; set; }
        public DbSet<tOttoAccount> OttoAccounts { get; set; }
        public DbSet<tPaymentMethod> PaymentMethods { get; set; }
        public DbSet<tProduct> Products { get; set; }
        public DbSet<tProductAttributeMapping> ProductAttributeMappings { get; set; }
        public DbSet<tProductCategory> ProductCategories { get; set; }

        public DbSet<tProductDescription> ProductDescriptions { get; set; }
        public DbSet<tProductImage> ProductImages { get; set; }
        public DbSet<tProductImageMapping> ProductImageMappings { get; set; }
        public DbSet<tProductStock> ProductStocks { get; set; }
        public DbSet<tProductVariant> ProductVariants { get; set; }
        public DbSet<tResponsiblePersonGPSR> ResponsiblePersonGPSRs { get; set; }
        public DbSet<tSalesChannelProductMapping> SalesChannelProductMappings { get; set; }
        public DbSet<tShippingMethod> ShippingMethods { get; set; }
        public DbSet<tShippingPackage> ShippingPackages { get; set; }
        public DbSet<tShopifyAccount> ShopAccounts { get; set; }
        public DbSet<tSupplier> tSuppliers { get; set; }
        public DbSet<tVariant_Attribute> tVariantAttributes { get; set; }
        public DbSet<tVatType> tVatTypes { get; set; }
        public DbSet<tProductMarketplace> tVariantMarketplaces { get; set; }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }

 
    }
}
