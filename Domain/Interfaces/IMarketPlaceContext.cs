using CoreSystem.DAL.Context.Models;
using Domain.Entities.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IMarketPlaceContext
    {
        DbSet<tAmazonAccount> AmazonAccounts { get; set; }
        DbSet<tAttribute> Attributes { get; set; }
        DbSet<tAttributeGroup> AttributeGroups { get; set; }
        DbSet<tAttributeValue> AttributeValues { get; set; }
        DbSet<tCondition> Conditions { get; set; }
        DbSet<tCustomer> Customers { get; set; }
        DbSet<tCustomerAddress> CustomerAddresses { get; set; }
        DbSet<tCustomerGroup> CustomerGroups { get; set; }
        DbSet<tEbayAccount> EbayAccounts { get; set; }
        DbSet<tKauflandAccount> KauflandAccounts { get; set; }
        DbSet<tLanguage> Languages { get; set; }
        DbSet<tLogEntry> LogEntries { get; set; }
        DbSet<tLogLevel> LogLevels { get; set; }
        DbSet<tLogType> LogTypes { get; set; }
        DbSet<tManufacturer> Manufacturers { get; set; }
        DbSet<tMarketplaceType> MarketplaceTypes { get; set; }
        DbSet<tOdooAccount> OdooAccounts { get; set; }
        DbSet<tOrder> Orders { get; set; }
        DbSet<tOrderPosition> OrderPositions { get; set; }
        DbSet<tOttoAccount> OttoAccounts { get; set; }
        DbSet<tPaymentMethod> PaymentMethods { get; set; }
        DbSet<tProduct> Products { get; set; }
        DbSet<tProductAttributeMapping> ProductAttributeMappings { get; set; }
        DbSet<tProductCategory> ProductCategories { get; set; }
        DbSet<tProductDescription> ProductDescriptions { get; set; }
        DbSet<tProductImage> ProductImages { get; set; }
        DbSet<tProductImageMapping> ProductImageMappings { get; set; }
        DbSet<tProductStock> ProductStocks { get; set; }
        DbSet<tProductVariant> ProductVariants { get; set; }
        DbSet<tResponsiblePersonGPSR> ResponsiblePersonGPSRs { get; set; }
        DbSet<tSalesChannelProductMapping> SalesChannelProductMappings { get; set; }
        DbSet<tShippingMethod> ShippingMethods { get; set; }
        DbSet<tShippingPackage> ShippingPackages { get; set; }
        DbSet<tShopifyAccount> ShopAccounts { get; set; }
        DbSet<tSupplier> tSuppliers { get; set; }
        DbSet<tVariant_Attribute> tVariantAttributes { get; set; }
        DbSet<tVatType> tVatTypes { get; set; }
        DbSet<tProductMarketplace> tVariantMarketplaces { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
