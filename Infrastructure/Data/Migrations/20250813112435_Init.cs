using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AttributeGroups",
                columns: table => new
                {
                    kAttributeGroupId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    sGroupName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttributeGroups", x => x.kAttributeGroupId);
                });

            migrationBuilder.CreateTable(
                name: "Attributes",
                columns: table => new
                {
                    kAttributeId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    kAttributeGroupId = table.Column<int>(type: "integer", nullable: true),
                    sName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attributes", x => x.kAttributeId);
                });

            migrationBuilder.CreateTable(
                name: "Conditions",
                columns: table => new
                {
                    kConditionId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    sConditionName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conditions", x => x.kConditionId);
                });

            migrationBuilder.CreateTable(
                name: "CustomerGroups",
                columns: table => new
                {
                    kCustomerGroupId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    sName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerGroups", x => x.kCustomerGroupId);
                });

            migrationBuilder.CreateTable(
                name: "CustomUserIdentity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DisplayName = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "text", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomUserIdentity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    kLanguageId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    sName = table.Column<string>(type: "text", nullable: true),
                    sIsoCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.kLanguageId);
                });

            migrationBuilder.CreateTable(
                name: "LogLevels",
                columns: table => new
                {
                    kLogLevelId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    sName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogLevels", x => x.kLogLevelId);
                });

            migrationBuilder.CreateTable(
                name: "LogTypes",
                columns: table => new
                {
                    kLogTypeId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    sName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogTypes", x => x.kLogTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Manufacturers",
                columns: table => new
                {
                    kManufacturerId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    sName = table.Column<string>(type: "text", nullable: true),
                    sAddress = table.Column<string>(type: "text", nullable: true),
                    sContactPerson = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturers", x => x.kManufacturerId);
                });

            migrationBuilder.CreateTable(
                name: "MarketplaceTypes",
                columns: table => new
                {
                    kMarketplaceType = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    sName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarketplaceTypes", x => x.kMarketplaceType);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethods",
                columns: table => new
                {
                    kPaymentMethodId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    sName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethods", x => x.kPaymentMethodId);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    kProductCategoryId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    sName = table.Column<string>(type: "text", nullable: true),
                    kUpperCategoryId = table.Column<int>(type: "integer", nullable: true),
                    kOdooReference = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.kProductCategoryId);
                    table.ForeignKey(
                        name: "FK_ProductCategories_ProductCategories_kUpperCategoryId",
                        column: x => x.kUpperCategoryId,
                        principalTable: "ProductCategories",
                        principalColumn: "kProductCategoryId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    kProductImageId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    sImage = table.Column<string>(type: "text", nullable: true),
                    iNumber = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.kProductImageId);
                });

            migrationBuilder.CreateTable(
                name: "ResponsiblePersonGPSRs",
                columns: table => new
                {
                    kResponsiblePersonGPSRId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    sCompanyName = table.Column<string>(type: "text", nullable: true),
                    sCompanyNameAddition = table.Column<string>(type: "text", nullable: true),
                    sSalutation = table.Column<string>(type: "text", nullable: true),
                    sTitle = table.Column<string>(type: "text", nullable: true),
                    sForename = table.Column<string>(type: "text", nullable: true),
                    sSurename = table.Column<string>(type: "text", nullable: true),
                    sStreet = table.Column<string>(type: "text", nullable: true),
                    sHousenumber = table.Column<string>(type: "text", nullable: true),
                    sAdressAddition = table.Column<string>(type: "text", nullable: true),
                    sZipCode = table.Column<string>(type: "text", nullable: true),
                    sCity = table.Column<string>(type: "text", nullable: true),
                    sCountry = table.Column<string>(type: "text", nullable: true),
                    sState = table.Column<string>(type: "text", nullable: true),
                    sPhonenumber = table.Column<string>(type: "text", nullable: true),
                    sMobilephonenumber = table.Column<string>(type: "text", nullable: true),
                    sFaxnumber = table.Column<string>(type: "text", nullable: true),
                    sEmailAddress = table.Column<string>(type: "text", nullable: true),
                    sWebsite = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResponsiblePersonGPSRs", x => x.kResponsiblePersonGPSRId);
                });

            migrationBuilder.CreateTable(
                name: "SalesChannelProductMappings",
                columns: table => new
                {
                    kSalesChannelProductMappingId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    kMarketplaceId = table.Column<int>(type: "integer", nullable: true),
                    bEnabled = table.Column<bool>(type: "boolean", nullable: true),
                    iSurchargeType = table.Column<int>(type: "integer", nullable: true),
                    dSurchargeAmount = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesChannelProductMappings", x => x.kSalesChannelProductMappingId);
                });

            migrationBuilder.CreateTable(
                name: "ShippingMethods",
                columns: table => new
                {
                    kShippingMethodId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    sName = table.Column<string>(type: "text", nullable: true),
                    dPrice = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingMethods", x => x.kShippingMethodId);
                });

            migrationBuilder.CreateTable(
                name: "tSuppliers",
                columns: table => new
                {
                    kSupplierId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    sName = table.Column<string>(type: "text", nullable: true),
                    iSupplierStock = table.Column<int>(type: "integer", nullable: true),
                    dSupplierPrice = table.Column<double>(type: "double precision", nullable: true),
                    iMinPurchaseQuantity = table.Column<int>(type: "integer", nullable: true),
                    kOdooReference = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tSuppliers", x => x.kSupplierId);
                });

            migrationBuilder.CreateTable(
                name: "tVatTypes",
                columns: table => new
                {
                    kVatType = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    sVatName = table.Column<string>(type: "text", nullable: true),
                    dAmount = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tVatTypes", x => x.kVatType);
                });

            migrationBuilder.CreateTable(
                name: "AttributeValues",
                columns: table => new
                {
                    kAttributeValueId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    kAttribueId = table.Column<int>(type: "integer", nullable: false),
                    iValue = table.Column<int>(type: "integer", nullable: true),
                    sValue = table.Column<string>(type: "text", nullable: true),
                    dValue = table.Column<double>(type: "double precision", nullable: true),
                    bValue = table.Column<bool>(type: "boolean", nullable: true),
                    sValueList = table.Column<string>(type: "text", nullable: true),
                    tAttributekAttributeId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttributeValues", x => x.kAttributeValueId);
                    table.ForeignKey(
                        name: "FK_AttributeValues_Attributes_kAttribueId",
                        column: x => x.kAttribueId,
                        principalTable: "Attributes",
                        principalColumn: "kAttributeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AttributeValues_Attributes_tAttributekAttributeId",
                        column: x => x.tAttributekAttributeId,
                        principalTable: "Attributes",
                        principalColumn: "kAttributeId");
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    kCustomerId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CustomerName = table.Column<string>(type: "text", nullable: true),
                    sCustomerNumber = table.Column<string>(type: "text", nullable: true),
                    OdooId = table.Column<int>(type: "integer", nullable: true),
                    kMarketplaceAccountId = table.Column<int>(type: "integer", nullable: true),
                    kCustomerGroupId = table.Column<int>(type: "integer", nullable: true),
                    sMarketplaceAccountName = table.Column<string>(type: "text", nullable: true),
                    dBirthDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    kOdooReference = table.Column<int>(type: "integer", nullable: true),
                    kMarketplaceId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.kCustomerId);
                    table.ForeignKey(
                        name: "FK_Customers_CustomerGroups_kCustomerGroupId",
                        column: x => x.kCustomerGroupId,
                        principalTable: "CustomerGroups",
                        principalColumn: "kCustomerGroupId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "TenantInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ConnectionString = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TenantInfo_CustomUserIdentity_UserId",
                        column: x => x.UserId,
                        principalTable: "CustomUserIdentity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductDescriptions",
                columns: table => new
                {
                    kProductDescriptionId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    kLanguageId = table.Column<int>(type: "integer", nullable: true),
                    kProductId = table.Column<int>(type: "integer", nullable: true),
                    sShortDescription = table.Column<string>(type: "text", nullable: true),
                    sDescription = table.Column<string>(type: "text", nullable: true),
                    tLanguagekLanguageId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDescriptions", x => x.kProductDescriptionId);
                    table.ForeignKey(
                        name: "FK_ProductDescriptions_Languages_kLanguageId",
                        column: x => x.kLanguageId,
                        principalTable: "Languages",
                        principalColumn: "kLanguageId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_ProductDescriptions_Languages_tLanguagekLanguageId",
                        column: x => x.tLanguagekLanguageId,
                        principalTable: "Languages",
                        principalColumn: "kLanguageId");
                });

            migrationBuilder.CreateTable(
                name: "LogEntries",
                columns: table => new
                {
                    kLogLevelId = table.Column<int>(type: "integer", nullable: false),
                    kLogTypeId = table.Column<int>(type: "integer", nullable: false),
                    dTimestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    sMessage = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogEntries", x => new { x.kLogLevelId, x.kLogTypeId });
                    table.ForeignKey(
                        name: "FK_LogEntries_LogLevels_kLogLevelId",
                        column: x => x.kLogLevelId,
                        principalTable: "LogLevels",
                        principalColumn: "kLogLevelId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_LogEntries_LogTypes_kLogTypeId",
                        column: x => x.kLogTypeId,
                        principalTable: "LogTypes",
                        principalColumn: "kLogTypeId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "AmazonAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AccountName = table.Column<string>(type: "text", nullable: true),
                    SellerId = table.Column<string>(type: "text", nullable: true),
                    ClientId = table.Column<string>(type: "text", nullable: true),
                    ClientSecret = table.Column<string>(type: "text", nullable: true),
                    RoleArn = table.Column<string>(type: "text", nullable: true),
                    MarketPlaceTypeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AmazonAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AmazonAccounts_MarketplaceTypes_MarketPlaceTypeId",
                        column: x => x.MarketPlaceTypeId,
                        principalTable: "MarketplaceTypes",
                        principalColumn: "kMarketplaceType",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EbayAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AccessToken = table.Column<string>(type: "text", nullable: true),
                    RefreshToken = table.Column<string>(type: "text", nullable: true),
                    TokenExpiry = table.Column<TimeOnly>(type: "time without time zone", nullable: true),
                    LastSyncProducts = table.Column<TimeOnly>(type: "time without time zone", nullable: true),
                    LastSyncOrders = table.Column<TimeOnly>(type: "time without time zone", nullable: true),
                    LastSyncShipments = table.Column<TimeOnly>(type: "time without time zone", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    MarketplaceTypeId = table.Column<int>(type: "integer", nullable: false),
                    AccountName = table.Column<string>(type: "text", nullable: true),
                    ClientId = table.Column<string>(type: "text", nullable: true),
                    ClientSecret = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: true),
                    Environment = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    RefreshTokenExpiresAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    AccessTokenExpiresAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EbayAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EbayAccounts_MarketplaceTypes_MarketplaceTypeId",
                        column: x => x.MarketplaceTypeId,
                        principalTable: "MarketplaceTypes",
                        principalColumn: "kMarketplaceType",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KauflandAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    MarketPlaceTypeId = table.Column<int>(type: "integer", nullable: false),
                    AccountName = table.Column<string>(type: "text", nullable: true),
                    ClientId = table.Column<string>(type: "text", nullable: true),
                    ClientSecret = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KauflandAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KauflandAccounts_MarketplaceTypes_MarketPlaceTypeId",
                        column: x => x.MarketPlaceTypeId,
                        principalTable: "MarketplaceTypes",
                        principalColumn: "kMarketplaceType",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OdooAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    URL = table.Column<string>(type: "text", nullable: true),
                    DataBaseName = table.Column<string>(type: "text", nullable: true),
                    UserName = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true),
                    kMarketplaceTypeId = table.Column<int>(type: "integer", nullable: false),
                    AccountName = table.Column<string>(type: "text", nullable: true),
                    SyncProducts = table.Column<bool>(type: "boolean", nullable: true),
                    SyncCustomers = table.Column<bool>(type: "boolean", nullable: true),
                    SyncSuppliers = table.Column<bool>(type: "boolean", nullable: true),
                    SyncOrders = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OdooAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OdooAccounts_MarketplaceTypes_kMarketplaceTypeId",
                        column: x => x.kMarketplaceTypeId,
                        principalTable: "MarketplaceTypes",
                        principalColumn: "kMarketplaceType",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OttoAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AccessToken = table.Column<string>(type: "text", nullable: true),
                    RefreshToken = table.Column<string>(type: "text", nullable: true),
                    TokenExpiry = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ClientEmail = table.Column<string>(type: "text", nullable: true),
                    LastSyncProducts = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastSyncOrders = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastSyncShipments = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ClientId = table.Column<string>(type: "text", nullable: true),
                    ClientSecret = table.Column<string>(type: "text", nullable: true),
                    kMarketplaceId = table.Column<int>(type: "integer", nullable: false),
                    AccountName = table.Column<string>(type: "text", nullable: true),
                    tMarketplaceTypekMarketplaceType = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OttoAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OttoAccounts_MarketplaceTypes_kMarketplaceId",
                        column: x => x.kMarketplaceId,
                        principalTable: "MarketplaceTypes",
                        principalColumn: "kMarketplaceType",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OttoAccounts_MarketplaceTypes_tMarketplaceTypekMarketplaceT~",
                        column: x => x.tMarketplaceTypekMarketplaceType,
                        principalTable: "MarketplaceTypes",
                        principalColumn: "kMarketplaceType");
                });

            migrationBuilder.CreateTable(
                name: "ShopAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AccountName = table.Column<string>(type: "text", nullable: true),
                    ApiToken = table.Column<string>(type: "text", nullable: true),
                    StoreName = table.Column<string>(type: "text", nullable: true),
                    MarketplaceTypeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShopAccounts_MarketplaceTypes_MarketplaceTypeId",
                        column: x => x.MarketplaceTypeId,
                        principalTable: "MarketplaceTypes",
                        principalColumn: "kMarketplaceType",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    kProductId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    bAvailableInOdoo = table.Column<bool>(type: "boolean", nullable: true),
                    kOdooReference = table.Column<int>(type: "integer", nullable: true),
                    sSku = table.Column<string>(type: "text", nullable: true),
                    sName = table.Column<string>(type: "text", nullable: true),
                    dNetprice = table.Column<double>(type: "double precision", nullable: true),
                    kVatTypeId = table.Column<int>(type: "integer", nullable: true),
                    bEnabled = table.Column<bool>(type: "boolean", nullable: true),
                    bStockEnabled = table.Column<bool>(type: "boolean", nullable: true),
                    dPackedWeight = table.Column<double>(type: "double precision", nullable: true),
                    dLength = table.Column<double>(type: "double precision", nullable: true),
                    dWidth = table.Column<double>(type: "double precision", nullable: true),
                    dWeight = table.Column<double>(type: "double precision", nullable: true),
                    iHandlingTime = table.Column<int>(type: "integer", nullable: true),
                    kConditionId = table.Column<int>(type: "integer", nullable: true),
                    sGTIN = table.Column<string>(type: "text", nullable: true),
                    sMPN = table.Column<string>(type: "text", nullable: true),
                    sASIN = table.Column<string>(type: "text", nullable: true),
                    sISBN = table.Column<string>(type: "text", nullable: true),
                    sUPC = table.Column<string>(type: "text", nullable: true),
                    sOriginCountry = table.Column<string>(type: "text", nullable: true),
                    sTaricCode = table.Column<string>(type: "text", nullable: true),
                    kManufacturerId = table.Column<int>(type: "integer", nullable: true),
                    kSupplierId = table.Column<int>(type: "integer", nullable: true),
                    kResponsiblePersonGPSRId = table.Column<int>(type: "integer", nullable: true),
                    kSalesChannelProductMappingId = table.Column<int>(type: "integer", nullable: true),
                    CategoryId = table.Column<int>(type: "integer", nullable: true),
                    kMarketplaceAccountId = table.Column<int>(type: "integer", nullable: false),
                    kProductCode = table.Column<string>(type: "text", nullable: true),
                    kMarketplaceId = table.Column<int>(type: "integer", nullable: false),
                    tConditionkConditionId = table.Column<int>(type: "integer", nullable: true),
                    tManufacturerkManufacturerId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.kProductId);
                    table.ForeignKey(
                        name: "FK_Products_Conditions_kConditionId",
                        column: x => x.kConditionId,
                        principalTable: "Conditions",
                        principalColumn: "kConditionId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Products_Conditions_tConditionkConditionId",
                        column: x => x.tConditionkConditionId,
                        principalTable: "Conditions",
                        principalColumn: "kConditionId");
                    table.ForeignKey(
                        name: "FK_Products_Manufacturers_kManufacturerId",
                        column: x => x.kManufacturerId,
                        principalTable: "Manufacturers",
                        principalColumn: "kManufacturerId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Products_Manufacturers_tManufacturerkManufacturerId",
                        column: x => x.tManufacturerkManufacturerId,
                        principalTable: "Manufacturers",
                        principalColumn: "kManufacturerId");
                    table.ForeignKey(
                        name: "FK_Products_ProductCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "ProductCategories",
                        principalColumn: "kProductCategoryId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Products_ResponsiblePersonGPSRs_kResponsiblePersonGPSRId",
                        column: x => x.kResponsiblePersonGPSRId,
                        principalTable: "ResponsiblePersonGPSRs",
                        principalColumn: "kResponsiblePersonGPSRId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Products_SalesChannelProductMappings_kSalesChannelProductMa~",
                        column: x => x.kSalesChannelProductMappingId,
                        principalTable: "SalesChannelProductMappings",
                        principalColumn: "kSalesChannelProductMappingId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Products_tSuppliers_kSupplierId",
                        column: x => x.kSupplierId,
                        principalTable: "tSuppliers",
                        principalColumn: "kSupplierId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Products_tVatTypes_kVatTypeId",
                        column: x => x.kVatTypeId,
                        principalTable: "tVatTypes",
                        principalColumn: "kVatType",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "CustomerAddresses",
                columns: table => new
                {
                    kCustomerAddressId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    kCustomerId = table.Column<int>(type: "integer", nullable: true),
                    iAddressType = table.Column<int>(type: "integer", nullable: true),
                    sCompanyName = table.Column<string>(type: "text", nullable: true),
                    sCompanyAddition = table.Column<string>(type: "text", nullable: true),
                    sSalutation = table.Column<string>(type: "text", nullable: true),
                    sTitle = table.Column<string>(type: "text", nullable: true),
                    sForename = table.Column<string>(type: "text", nullable: true),
                    sSurname = table.Column<string>(type: "text", nullable: true),
                    sStreetAndHousenumber = table.Column<string>(type: "text", nullable: true),
                    sAddressAddition = table.Column<string>(type: "text", nullable: true),
                    sZipCode = table.Column<string>(type: "text", nullable: true),
                    sCity = table.Column<string>(type: "text", nullable: true),
                    sCountry = table.Column<string>(type: "text", nullable: true),
                    sState = table.Column<string>(type: "text", nullable: true),
                    sEmailAddress = table.Column<string>(type: "text", nullable: true),
                    sPhoneNumber = table.Column<string>(type: "text", nullable: true),
                    sMobilePhoneNumber = table.Column<string>(type: "text", nullable: true),
                    sFaxNumber = table.Column<string>(type: "text", nullable: true),
                    sWebsite = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerAddresses", x => x.kCustomerAddressId);
                    table.ForeignKey(
                        name: "FK_CustomerAddresses_Customers_kCustomerId",
                        column: x => x.kCustomerId,
                        principalTable: "Customers",
                        principalColumn: "kCustomerId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "ProductAttributeMappings",
                columns: table => new
                {
                    kProductAttributeMappingId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    kAttributeValueId = table.Column<int>(type: "integer", nullable: true),
                    kProductId = table.Column<int>(type: "integer", nullable: true),
                    iValuteType = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductAttributeMappings", x => x.kProductAttributeMappingId);
                    table.ForeignKey(
                        name: "FK_ProductAttributeMappings_AttributeValues_kAttributeValueId",
                        column: x => x.kAttributeValueId,
                        principalTable: "AttributeValues",
                        principalColumn: "kAttributeValueId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_ProductAttributeMappings_Products_kAttributeValueId",
                        column: x => x.kAttributeValueId,
                        principalTable: "Products",
                        principalColumn: "kProductId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "ProductImageMappings",
                columns: table => new
                {
                    kProductImageMappingId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    kProductImageId = table.Column<int>(type: "integer", nullable: true),
                    kProductId = table.Column<int>(type: "integer", nullable: true),
                    TProductkProductId = table.Column<int>(type: "integer", nullable: true),
                    tProductImagekProductImageId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImageMappings", x => x.kProductImageMappingId);
                    table.ForeignKey(
                        name: "FK_ProductImageMappings_ProductImages_kProductId",
                        column: x => x.kProductId,
                        principalTable: "ProductImages",
                        principalColumn: "kProductImageId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_ProductImageMappings_ProductImages_tProductImagekProductIma~",
                        column: x => x.tProductImagekProductImageId,
                        principalTable: "ProductImages",
                        principalColumn: "kProductImageId");
                    table.ForeignKey(
                        name: "FK_ProductImageMappings_Products_TProductkProductId",
                        column: x => x.TProductkProductId,
                        principalTable: "Products",
                        principalColumn: "kProductId");
                });

            migrationBuilder.CreateTable(
                name: "ProductVariants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    SKU = table.Column<string>(type: "text", nullable: true),
                    Barcode = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    Image = table.Column<string>(type: "text", nullable: true),
                    Product_Id = table.Column<int>(type: "integer", nullable: false),
                    OdooId = table.Column<int>(type: "integer", nullable: true),
                    Weight = table.Column<double>(type: "double precision", nullable: true),
                    Width = table.Column<double>(type: "double precision", nullable: true),
                    Length = table.Column<double>(type: "double precision", nullable: true),
                    PackedWeight = table.Column<double>(type: "double precision", nullable: true),
                    PackedLength = table.Column<double>(type: "double precision", nullable: true),
                    PackedWidth = table.Column<double>(type: "double precision", nullable: true),
                    tProductkProductId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductVariants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductVariants_Products_Product_Id",
                        column: x => x.Product_Id,
                        principalTable: "Products",
                        principalColumn: "kProductId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductVariants_Products_tProductkProductId",
                        column: x => x.tProductkProductId,
                        principalTable: "Products",
                        principalColumn: "kProductId");
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    kOrderId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    sOrderNumber = table.Column<string>(type: "text", nullable: true),
                    iOrderStatus = table.Column<int>(type: "integer", nullable: true),
                    kMarketplaceAccountId = table.Column<int>(type: "integer", nullable: true),
                    kCustomerId = table.Column<int>(type: "integer", nullable: false),
                    sCustomerHint = table.Column<string>(type: "text", nullable: true),
                    sInternalHint = table.Column<string>(type: "text", nullable: true),
                    kPaymentMethodId = table.Column<int>(type: "integer", nullable: true),
                    dCreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    dShippingTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    kOdooReference = table.Column<int>(type: "integer", nullable: true),
                    kMarketplaceId = table.Column<int>(type: "integer", nullable: true),
                    kOrderAddressId = table.Column<int>(type: "integer", nullable: true),
                    OrderResponseStatus = table.Column<int>(type: "integer", nullable: true),
                    OrdersEdiMessage = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.kOrderId);
                    table.ForeignKey(
                        name: "FK_Orders_CustomerAddresses_kOrderAddressId",
                        column: x => x.kOrderAddressId,
                        principalTable: "CustomerAddresses",
                        principalColumn: "kCustomerAddressId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_kCustomerId",
                        column: x => x.kCustomerId,
                        principalTable: "Customers",
                        principalColumn: "kCustomerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_PaymentMethods_kPaymentMethodId",
                        column: x => x.kPaymentMethodId,
                        principalTable: "PaymentMethods",
                        principalColumn: "kPaymentMethodId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "ProductStocks",
                columns: table => new
                {
                    kProductStockId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    iStockAvailable = table.Column<int>(type: "integer", nullable: true),
                    iStockInOrders = table.Column<int>(type: "integer", nullable: true),
                    iStockInDelivery = table.Column<int>(type: "integer", nullable: true),
                    kWarehouseId = table.Column<int>(type: "integer", nullable: true),
                    kOdooReference = table.Column<int>(type: "integer", nullable: true),
                    kProductVariantId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductStocks", x => x.kProductStockId);
                    table.ForeignKey(
                        name: "FK_ProductStocks_ProductVariants_kProductVariantId",
                        column: x => x.kProductVariantId,
                        principalTable: "ProductVariants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tVariantAttributes",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    variant_id = table.Column<int>(type: "integer", nullable: false),
                    AttributeValueId = table.Column<int>(type: "integer", nullable: false),
                    tAttributeValuekAttributeValueId = table.Column<int>(type: "integer", nullable: true),
                    tProductVariantId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tVariantAttributes", x => x.id);
                    table.ForeignKey(
                        name: "FK_tVariantAttributes_AttributeValues_AttributeValueId",
                        column: x => x.AttributeValueId,
                        principalTable: "AttributeValues",
                        principalColumn: "kAttributeValueId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tVariantAttributes_AttributeValues_tAttributeValuekAttribut~",
                        column: x => x.tAttributeValuekAttributeValueId,
                        principalTable: "AttributeValues",
                        principalColumn: "kAttributeValueId");
                    table.ForeignKey(
                        name: "FK_tVariantAttributes_ProductVariants_tProductVariantId",
                        column: x => x.tProductVariantId,
                        principalTable: "ProductVariants",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tVariantAttributes_ProductVariants_variant_id",
                        column: x => x.variant_id,
                        principalTable: "ProductVariants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tVariantMarketplaces",
                columns: table => new
                {
                    ProductVariantId = table.Column<int>(type: "integer", nullable: false),
                    MarketplaceTypeId = table.Column<int>(type: "integer", nullable: false),
                    MarketPlaceNumber = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tVariantMarketplaces", x => new { x.ProductVariantId, x.MarketplaceTypeId });
                    table.ForeignKey(
                        name: "FK_tVariantMarketplaces_MarketplaceTypes_MarketplaceTypeId",
                        column: x => x.MarketplaceTypeId,
                        principalTable: "MarketplaceTypes",
                        principalColumn: "kMarketplaceType",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tVariantMarketplaces_ProductVariants_ProductVariantId",
                        column: x => x.ProductVariantId,
                        principalTable: "ProductVariants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderPositions",
                columns: table => new
                {
                    kOrderPositionId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    kOrderId = table.Column<int>(type: "integer", nullable: false),
                    iOrderPositionType = table.Column<int>(type: "integer", nullable: true),
                    sName = table.Column<string>(type: "text", nullable: true),
                    kVariantId = table.Column<int>(type: "integer", nullable: false),
                    dNetPrice = table.Column<double>(type: "double precision", nullable: true),
                    dVat = table.Column<double>(type: "double precision", nullable: true),
                    iQuantity = table.Column<int>(type: "integer", nullable: true),
                    iQuantityShipped = table.Column<int>(type: "integer", nullable: true),
                    sPositionHint = table.Column<string>(type: "text", nullable: true),
                    tOrderkOrderId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderPositions", x => x.kOrderPositionId);
                    table.ForeignKey(
                        name: "FK_OrderPositions_Orders_kOrderId",
                        column: x => x.kOrderId,
                        principalTable: "Orders",
                        principalColumn: "kOrderId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderPositions_Orders_tOrderkOrderId",
                        column: x => x.tOrderkOrderId,
                        principalTable: "Orders",
                        principalColumn: "kOrderId");
                    table.ForeignKey(
                        name: "FK_OrderPositions_ProductVariants_kVariantId",
                        column: x => x.kVariantId,
                        principalTable: "ProductVariants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShippingPackages",
                columns: table => new
                {
                    kShippingPackageId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    kShippingMethodId = table.Column<int>(type: "integer", nullable: true),
                    kOrderId = table.Column<int>(type: "integer", nullable: true),
                    sTrackingNumber = table.Column<string>(type: "text", nullable: true),
                    dPackageWeight = table.Column<double>(type: "double precision", nullable: true),
                    dCreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    tOrderkOrderId = table.Column<int>(type: "integer", nullable: true),
                    tShippingMethodkShippingMethodId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingPackages", x => x.kShippingPackageId);
                    table.ForeignKey(
                        name: "FK_ShippingPackages_Orders_kOrderId",
                        column: x => x.kOrderId,
                        principalTable: "Orders",
                        principalColumn: "kOrderId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_ShippingPackages_Orders_tOrderkOrderId",
                        column: x => x.tOrderkOrderId,
                        principalTable: "Orders",
                        principalColumn: "kOrderId");
                    table.ForeignKey(
                        name: "FK_ShippingPackages_ShippingMethods_kShippingMethodId",
                        column: x => x.kShippingMethodId,
                        principalTable: "ShippingMethods",
                        principalColumn: "kShippingMethodId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_ShippingPackages_ShippingMethods_tShippingMethodkShippingMe~",
                        column: x => x.tShippingMethodkShippingMethodId,
                        principalTable: "ShippingMethods",
                        principalColumn: "kShippingMethodId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AmazonAccounts_MarketPlaceTypeId",
                table: "AmazonAccounts",
                column: "MarketPlaceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AttributeValues_kAttribueId",
                table: "AttributeValues",
                column: "kAttribueId");

            migrationBuilder.CreateIndex(
                name: "IX_AttributeValues_tAttributekAttributeId",
                table: "AttributeValues",
                column: "tAttributekAttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAddresses_kCustomerId",
                table: "CustomerAddresses",
                column: "kCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_kCustomerGroupId",
                table: "Customers",
                column: "kCustomerGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_EbayAccounts_MarketplaceTypeId",
                table: "EbayAccounts",
                column: "MarketplaceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_KauflandAccounts_MarketPlaceTypeId",
                table: "KauflandAccounts",
                column: "MarketPlaceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LogEntries_kLogLevelId",
                table: "LogEntries",
                column: "kLogLevelId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LogEntries_kLogTypeId",
                table: "LogEntries",
                column: "kLogTypeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OdooAccounts_kMarketplaceTypeId",
                table: "OdooAccounts",
                column: "kMarketplaceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderPositions_kOrderId",
                table: "OrderPositions",
                column: "kOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderPositions_kVariantId",
                table: "OrderPositions",
                column: "kVariantId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderPositions_tOrderkOrderId",
                table: "OrderPositions",
                column: "tOrderkOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_kCustomerId",
                table: "Orders",
                column: "kCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_kOrderAddressId",
                table: "Orders",
                column: "kOrderAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_kPaymentMethodId",
                table: "Orders",
                column: "kPaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_OttoAccounts_kMarketplaceId",
                table: "OttoAccounts",
                column: "kMarketplaceId");

            migrationBuilder.CreateIndex(
                name: "IX_OttoAccounts_tMarketplaceTypekMarketplaceType",
                table: "OttoAccounts",
                column: "tMarketplaceTypekMarketplaceType");

            migrationBuilder.CreateIndex(
                name: "IX_ProductAttributeMappings_kAttributeValueId",
                table: "ProductAttributeMappings",
                column: "kAttributeValueId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_kUpperCategoryId",
                table: "ProductCategories",
                column: "kUpperCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDescriptions_kLanguageId",
                table: "ProductDescriptions",
                column: "kLanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDescriptions_tLanguagekLanguageId",
                table: "ProductDescriptions",
                column: "tLanguagekLanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImageMappings_kProductId",
                table: "ProductImageMappings",
                column: "kProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImageMappings_tProductImagekProductImageId",
                table: "ProductImageMappings",
                column: "tProductImagekProductImageId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImageMappings_TProductkProductId",
                table: "ProductImageMappings",
                column: "TProductkProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_kConditionId",
                table: "Products",
                column: "kConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_kManufacturerId",
                table: "Products",
                column: "kManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_kResponsiblePersonGPSRId",
                table: "Products",
                column: "kResponsiblePersonGPSRId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_kSalesChannelProductMappingId",
                table: "Products",
                column: "kSalesChannelProductMappingId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_kSupplierId",
                table: "Products",
                column: "kSupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_kVatTypeId",
                table: "Products",
                column: "kVatTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_tConditionkConditionId",
                table: "Products",
                column: "tConditionkConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_tManufacturerkManufacturerId",
                table: "Products",
                column: "tManufacturerkManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductStocks_kProductVariantId",
                table: "ProductStocks",
                column: "kProductVariantId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariants_Product_Id",
                table: "ProductVariants",
                column: "Product_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariants_tProductkProductId",
                table: "ProductVariants",
                column: "tProductkProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ShippingPackages_kOrderId",
                table: "ShippingPackages",
                column: "kOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ShippingPackages_kShippingMethodId",
                table: "ShippingPackages",
                column: "kShippingMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_ShippingPackages_tOrderkOrderId",
                table: "ShippingPackages",
                column: "tOrderkOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ShippingPackages_tShippingMethodkShippingMethodId",
                table: "ShippingPackages",
                column: "tShippingMethodkShippingMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopAccounts_MarketplaceTypeId",
                table: "ShopAccounts",
                column: "MarketplaceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TenantInfo_UserId",
                table: "TenantInfo",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tVariantAttributes_AttributeValueId",
                table: "tVariantAttributes",
                column: "AttributeValueId");

            migrationBuilder.CreateIndex(
                name: "IX_tVariantAttributes_tAttributeValuekAttributeValueId",
                table: "tVariantAttributes",
                column: "tAttributeValuekAttributeValueId");

            migrationBuilder.CreateIndex(
                name: "IX_tVariantAttributes_tProductVariantId",
                table: "tVariantAttributes",
                column: "tProductVariantId");

            migrationBuilder.CreateIndex(
                name: "IX_tVariantAttributes_variant_id",
                table: "tVariantAttributes",
                column: "variant_id");

            migrationBuilder.CreateIndex(
                name: "IX_tVariantMarketplaces_MarketplaceTypeId",
                table: "tVariantMarketplaces",
                column: "MarketplaceTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AmazonAccounts");

            migrationBuilder.DropTable(
                name: "AttributeGroups");

            migrationBuilder.DropTable(
                name: "EbayAccounts");

            migrationBuilder.DropTable(
                name: "KauflandAccounts");

            migrationBuilder.DropTable(
                name: "LogEntries");

            migrationBuilder.DropTable(
                name: "OdooAccounts");

            migrationBuilder.DropTable(
                name: "OrderPositions");

            migrationBuilder.DropTable(
                name: "OttoAccounts");

            migrationBuilder.DropTable(
                name: "ProductAttributeMappings");

            migrationBuilder.DropTable(
                name: "ProductDescriptions");

            migrationBuilder.DropTable(
                name: "ProductImageMappings");

            migrationBuilder.DropTable(
                name: "ProductStocks");

            migrationBuilder.DropTable(
                name: "ShippingPackages");

            migrationBuilder.DropTable(
                name: "ShopAccounts");

            migrationBuilder.DropTable(
                name: "TenantInfo");

            migrationBuilder.DropTable(
                name: "tVariantAttributes");

            migrationBuilder.DropTable(
                name: "tVariantMarketplaces");

            migrationBuilder.DropTable(
                name: "LogLevels");

            migrationBuilder.DropTable(
                name: "LogTypes");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "ShippingMethods");

            migrationBuilder.DropTable(
                name: "CustomUserIdentity");

            migrationBuilder.DropTable(
                name: "AttributeValues");

            migrationBuilder.DropTable(
                name: "MarketplaceTypes");

            migrationBuilder.DropTable(
                name: "ProductVariants");

            migrationBuilder.DropTable(
                name: "CustomerAddresses");

            migrationBuilder.DropTable(
                name: "PaymentMethods");

            migrationBuilder.DropTable(
                name: "Attributes");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Conditions");

            migrationBuilder.DropTable(
                name: "Manufacturers");

            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DropTable(
                name: "ResponsiblePersonGPSRs");

            migrationBuilder.DropTable(
                name: "SalesChannelProductMappings");

            migrationBuilder.DropTable(
                name: "tSuppliers");

            migrationBuilder.DropTable(
                name: "tVatTypes");

            migrationBuilder.DropTable(
                name: "CustomerGroups");
        }
    }
}
