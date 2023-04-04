using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ecommerce.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category_Level1",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category_L1 = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category_Level1", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Color",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Color = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Color", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryPartners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Delivery_Partner_Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryPartners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Currency = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: false),
                    TransectionId = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Size",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Size = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Size", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserGender",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gender = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGender", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Role = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Warehouse",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Warehouse_Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouse", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Brand_Category_Mapping",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand_Id = table.Column<int>(type: "int", nullable: false),
                    Category_L1_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand_Category_Mapping", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Brand_Category_Mapping_Brand",
                        column: x => x.Brand_Id,
                        principalTable: "Brand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Brand_Category_Mapping_Category_Level1",
                        column: x => x.Category_L1_Id,
                        principalTable: "Category_Level1",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Category_Level2",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category_L2 = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    Category_L1_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category_Level2", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Category_Level2_Category_Level1",
                        column: x => x.Category_L1_Id,
                        principalTable: "Category_Level1",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DP_Hubs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hub_Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    DP_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DP_Hubs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DP_Hubs_DeliveryPartners",
                        column: x => x.DP_Id,
                        principalTable: "DeliveryPartners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Gender_Id = table.Column<int>(type: "int", nullable: false),
                    CountryCode = table.Column<int>(type: "int", nullable: false),
                    Phone = table.Column<string>(type: "varchar(12)", unicode: false, maxLength: 12, nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    IsVerified = table.Column<bool>(type: "bit", nullable: false),
                    Isactive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_UserGender",
                        column: x => x.Gender_Id,
                        principalTable: "UserGender",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Category_Level3",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category_L2_Id = table.Column<int>(type: "int", nullable: false),
                    Category_L3 = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category_Level3", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Category_Level3_Category_Level21",
                        column: x => x.Category_L2_Id,
                        principalTable: "Category_Level2",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DP_Hub_Address",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DP_Hub_Id = table.Column<int>(type: "int", nullable: false),
                    Address_Line1 = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Address_Line2 = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    City = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    State = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Country = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    PostalCode = table.Column<int>(type: "int", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DP_Hub_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DP_Hub_Address_DP_Hubs",
                        column: x => x.DP_Hub_Id,
                        principalTable: "DP_Hubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    AddressLine1 = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    AddressLine2 = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    City = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    State = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    Postalcode = table.Column<int>(type: "int", nullable: false),
                    Country = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_User",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CartTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartTable_User",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User_Role_Mapping",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_Id = table.Column<int>(type: "int", nullable: false),
                    Role_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Role_Mapping", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Role_Mapping_User",
                        column: x => x.User_Id,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_Role_Mapping_UserRole",
                        column: x => x.Role_Id,
                        principalTable: "UserRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Wishlist",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wishlist", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wishlist_User",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Prod_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Prod_Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Prod_Description = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false),
                    CategoryL1Id = table.Column<int>(type: "int", nullable: false),
                    CategoryL2Id = table.Column<int>(type: "int", nullable: false),
                    CategoryL3Id = table.Column<int>(type: "int", nullable: false),
                    Brand_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Prod_Id);
                    table.ForeignKey(
                        name: "FK_Products_Brand",
                        column: x => x.Brand_Id,
                        principalTable: "Brand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Category_Level1",
                        column: x => x.CategoryL1Id,
                        principalTable: "Category_Level1",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Category_Level2",
                        column: x => x.CategoryL2Id,
                        principalTable: "Category_Level2",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Category_Level3",
                        column: x => x.CategoryL3Id,
                        principalTable: "Category_Level3",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<int>(type: "int", nullable: false),
                    PaymentId = table.Column<int>(type: "int", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Address",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderDetails_PaymentDetails",
                        column: x => x.PaymentId,
                        principalTable: "PaymentDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderDetails_User",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryBoy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_Role_Mapping_Id = table.Column<int>(type: "int", nullable: false),
                    Assigned_Hub_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryBoy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeliveryBoy_DP_Hubs",
                        column: x => x.Assigned_Hub_Id,
                        principalTable: "DP_Hubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeliveryBoy_User_Role_Mapping",
                        column: x => x.User_Role_Mapping_Id,
                        principalTable: "User_Role_Mapping",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Prod_Id = table.Column<int>(type: "int", nullable: false),
                    User_Id = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Products",
                        column: x => x.Prod_Id,
                        principalTable: "Products",
                        principalColumn: "Prod_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_User",
                        column: x => x.User_Id,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Product_Detail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<int>(type: "int", nullable: false),
                    SizeId = table.Column<int>(type: "int", nullable: false),
                    ColorId = table.Column<int>(type: "int", nullable: false),
                    Prod_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_Detail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Detail_Color",
                        column: x => x.ColorId,
                        principalTable: "Color",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Product_Detail_Products",
                        column: x => x.Prod_Id,
                        principalTable: "Products",
                        principalColumn: "Prod_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Product_Detail_Size",
                        column: x => x.SizeId,
                        principalTable: "Size",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Product_Image",
                columns: table => new
                {
                    Img_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Prod_Id = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<byte[]>(type: "image", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_Image", x => x.Img_Id);
                    table.ForeignKey(
                        name: "FK_Product_Image_Products",
                        column: x => x.Prod_Id,
                        principalTable: "Products",
                        principalColumn: "Prod_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User_Product_mapping",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_ID = table.Column<int>(type: "int", nullable: false),
                    Prod_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Product_mapping", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Product_mapping_Products",
                        column: x => x.Prod_Id,
                        principalTable: "Products",
                        principalColumn: "Prod_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_Product_mapping_User",
                        column: x => x.User_ID,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Order_Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Items_OrderDetails",
                        column: x => x.OrderId,
                        principalTable: "OrderDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Warehouse_OrderDetails_Mapping",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Warehouse_Id = table.Column<int>(type: "int", nullable: false),
                    Order_Detail_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouse_OrderDetails_Mapping", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Warehouse_OrderDetails_Mapping_OrderDetails",
                        column: x => x.Order_Detail_Id,
                        principalTable: "OrderDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_Warehouse_OrderDetails_Mapping_Warehouse",
                        column: x => x.Warehouse_Id,
                        principalTable: "Warehouse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CartId = table.Column<int>(type: "int", nullable: false),
                    ProdId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cart_Cart",
                        column: x => x.CartId,
                        principalTable: "CartTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cart_Product_Detail",
                        column: x => x.ProdId,
                        principalTable: "Product_Detail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Inventry_Item",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Product_Detail_Id = table.Column<int>(type: "int", nullable: false),
                    Warehouse_Id = table.Column<int>(type: "int", nullable: false),
                    Product_Count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventry_Item", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inventry_Item_Product_Detail",
                        column: x => x.Product_Detail_Id,
                        principalTable: "Product_Detail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Inventry_Item_Warehouse",
                        column: x => x.Warehouse_Id,
                        principalTable: "Warehouse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Wishlist_Item",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Wishlist_Id = table.Column<int>(type: "int", nullable: false),
                    Prod_Detail_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wishlist_Item", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wishlist_Item_Product_Detail",
                        column: x => x.Prod_Detail_Id,
                        principalTable: "Product_Detail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Wishlist_Item_Wishlist",
                        column: x => x.Wishlist_Id,
                        principalTable: "Wishlist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_UserId",
                table: "Address",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Brand_Category_Mapping_Brand_Id",
                table: "Brand_Category_Mapping",
                column: "Brand_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Brand_Category_Mapping_Category_L1_Id",
                table: "Brand_Category_Mapping",
                column: "Category_L1_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_CartId",
                table: "Cart",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_ProdId",
                table: "Cart",
                column: "ProdId");

            migrationBuilder.CreateIndex(
                name: "UserId_CartTable_UK",
                table: "CartTable",
                column: "UserID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Category_Level2_Category_L1_Id",
                table: "Category_Level2",
                column: "Category_L1_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Category_Level3_Category_L2_Id",
                table: "Category_Level3",
                column: "Category_L2_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_Prod_Id",
                table: "Comments",
                column: "Prod_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_User_Id",
                table: "Comments",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "Hub_UK",
                table: "DeliveryBoy",
                column: "Assigned_Hub_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryBoy_User_Role_Mapping_Id",
                table: "DeliveryBoy",
                column: "User_Role_Mapping_Id");

            migrationBuilder.CreateIndex(
                name: "UniqueKey",
                table: "DeliveryBoy",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "DP_Hub_Address_UK",
                table: "DP_Hub_Address",
                column: "DP_Hub_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DP_Hubs_DP_Id",
                table: "DP_Hubs",
                column: "DP_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Inventry_Item_Product_Detail_Id",
                table: "Inventry_Item",
                column: "Product_Detail_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Inventry_Item_Warehouse_Id",
                table: "Inventry_Item",
                column: "Warehouse_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Items_OrderId",
                table: "Order_Items",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_AddressId",
                table: "OrderDetails",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_UserId",
                table: "OrderDetails",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "UK",
                table: "OrderDetails",
                column: "PaymentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_Detail_ColorId",
                table: "Product_Detail",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Detail_Prod_Id",
                table: "Product_Detail",
                column: "Prod_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Detail_SizeId",
                table: "Product_Detail",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Image_Prod_Id",
                table: "Product_Image",
                column: "Prod_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Brand_Id",
                table: "Products",
                column: "Brand_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryL1Id",
                table: "Products",
                column: "CategoryL1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryL2Id",
                table: "Products",
                column: "CategoryL2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryL3Id",
                table: "Products",
                column: "CategoryL3Id");

            migrationBuilder.CreateIndex(
                name: "IX_User_Gender_Id",
                table: "User",
                column: "Gender_Id");

            migrationBuilder.CreateIndex(
                name: "IX_User_Product_mapping_Prod_Id",
                table: "User_Product_mapping",
                column: "Prod_Id");

            migrationBuilder.CreateIndex(
                name: "IX_User_Product_mapping_User_ID",
                table: "User_Product_mapping",
                column: "User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_User_Role_Mapping_Role_Id",
                table: "User_Role_Mapping",
                column: "Role_Id");

            migrationBuilder.CreateIndex(
                name: "IX_User_Role_Mapping_User_Id",
                table: "User_Role_Mapping",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Warehouse_OrderDetails_Mapping_Order_Detail_Id",
                table: "Warehouse_OrderDetails_Mapping",
                column: "Order_Detail_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Warehouse_OrderDetails_Mapping_Warehouse_Id",
                table: "Warehouse_OrderDetails_Mapping",
                column: "Warehouse_Id");

            migrationBuilder.CreateIndex(
                name: "Wishlist_UserId_UK",
                table: "Wishlist",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Wishlist_Item_Prod_Detail_Id",
                table: "Wishlist_Item",
                column: "Prod_Detail_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Wishlist_Item_Wishlist_Id",
                table: "Wishlist_Item",
                column: "Wishlist_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Brand_Category_Mapping");

            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "DeliveryBoy");

            migrationBuilder.DropTable(
                name: "DP_Hub_Address");

            migrationBuilder.DropTable(
                name: "Inventry_Item");

            migrationBuilder.DropTable(
                name: "Order_Items");

            migrationBuilder.DropTable(
                name: "Product_Image");

            migrationBuilder.DropTable(
                name: "User_Product_mapping");

            migrationBuilder.DropTable(
                name: "Warehouse_OrderDetails_Mapping");

            migrationBuilder.DropTable(
                name: "Wishlist_Item");

            migrationBuilder.DropTable(
                name: "CartTable");

            migrationBuilder.DropTable(
                name: "User_Role_Mapping");

            migrationBuilder.DropTable(
                name: "DP_Hubs");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Warehouse");

            migrationBuilder.DropTable(
                name: "Product_Detail");

            migrationBuilder.DropTable(
                name: "Wishlist");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "DeliveryPartners");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "PaymentDetails");

            migrationBuilder.DropTable(
                name: "Color");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Size");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropTable(
                name: "Category_Level3");

            migrationBuilder.DropTable(
                name: "UserGender");

            migrationBuilder.DropTable(
                name: "Category_Level2");

            migrationBuilder.DropTable(
                name: "Category_Level1");
        }
    }
}
