﻿using Ecommerce.Interface;
using Ecommerce.Models.DbModel;
using Ecommerce.Models.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ecommerce.Repository
{
    public class OrderNowRepository : IOrderRepository
    {
        private readonly ILogger<OrderNowRepository> _logger;
        private readonly ICartRepository _cartRepository;

        public OrderNowRepository(ILogger<OrderNowRepository> logger, ICartRepository cartRepository)
        {
            _logger = logger;
            _cartRepository = cartRepository;
        }

        public bool OrderNow(OrderModel model)
        {
            try
            {

                EcommerceContext db = new EcommerceContext();
                _logger.LogInformation("----------DB Connection Established----------");
                var Product = db.ProductDetails.FirstOrDefault(x => x.ProdId == model.ProdId && x.SizeId==model.SizeId && x.ColorId==model.ColorId);

                var IsOutofStock = db.InventryItems.FirstOrDefault(x => x.ProductDetailId == Product.Id);
                if (IsOutofStock.ProductCount == 0)
                {
                    _logger.LogError("-------Product is out of stock---------");
                    throw new Exception("Product Is Out Of Stock");
                }
                if (Product == null)
                {
                    _logger.LogError("-------Invalid Product Id---------");
                    throw new Exception("Invalid Product Id");
                }
                if (model.TransectionId == null)
                {
                    _logger.LogError("-------Payment is Unsuccessfull---------");
                    throw new Exception("Payment is Unsuccessful.Please Try Again");
                }
                var PaymentDetails = new PaymentDetail()
                {
                    Amount = Product.Price * model.Quantity,
                    Currency = model.Currency,
                    TransectionId=model.TransectionId,
                    CreatedOn = DateTime.Now
                };
                _logger.LogInformation("------------Payment Details Added----------");
                var OrderDetails = new OrderDetail()
                {
                    UserId = model.UserId,
                    Total = Product.Price * model.Quantity,
                    CreatedOn = DateTime.Now,
                    AddressId = model.AddressId,
                    Payment=PaymentDetails
                };
                _logger.LogInformation("------------Order Details Added----------");
                var OrderItems = new OrderItem()
                {
                    OrderId = OrderDetails.Id,
                    ProductId = model.ProdId,
                    Quantity = model.Quantity,
                    CreatedOn = DateTime.Now,
                };
                _logger.LogInformation("------------Order Items Added----------");
                var inventry = db.InventryItems.FirstOrDefault(x => x.ProductDetailId == Product.Id);
                var WarehouseOrderMapping = new WarehouseOrderDetailsMapping()
                {
                      WarehouseId=inventry.WarehouseId,
                      OrderDetailId= OrderDetails.Id,
                      OrderDetail= OrderDetails
                };
                _logger.LogInformation("------------Warehouse Order Mapping Added----------");
                db.WarehouseOrderDetailsMappings.Add(WarehouseOrderMapping);
                OrderDetails.OrderItems.Add(OrderItems);
                db.OrderDetails.Add(OrderDetails);
                inventry.ProductCount--;
                db.InventryItems.Update(inventry);
                db.SaveChanges();
                _logger.LogInformation("------------Product Order Successfully----------");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.InnerException.ToString());
                throw new Exception(ex.Message);
            }
        }

        public bool OrderNowByCart(CartOrderModel model)
        {
            try
            {
                EcommerceContext db = new EcommerceContext();
                var cartTable = db.CartTables.FirstOrDefault(x => x.UserId == model.UserId);
                var cart = db.Carts.Where(x => x.CartId == cartTable.Id).Include(x=>x.Prod).ToList();

                foreach (var product in cart)
                {
                    var IsOutofStock = db.InventryItems.FirstOrDefault(x => x.ProductDetailId == product.ProdId);
                    if (IsOutofStock.ProductCount == 0)
                    {
                        _logger.LogError("-------Product is out of stock---------");
                        throw new Exception("Product Is Out Of Stock");
                    }
                    if (model.TransectionId == null)
                    {
                        _logger.LogError("-------Payment is Unsuccessfull---------");
                        throw new Exception("Payment is Unsuccessful.Please Try Again");
                    }
                    var PaymentDetails = new PaymentDetail()
                    {
                        Amount = product.Prod.Price * product.Quantity,
                        Currency = model.Currency,
                        TransectionId = model.TransectionId,
                        CreatedOn = DateTime.Now
                    };
                    _logger.LogInformation("------------Payment Details Added----------");
                    var OrderDetails = new OrderDetail()
                    {
                        UserId = model.UserId,
                        Total = product.Prod.Price * product.Quantity,
                        CreatedOn = DateTime.Now,
                        AddressId = model.AddressId,
                        Payment = PaymentDetails
                    };
                    _logger.LogInformation("------------Order Details Added----------");
                    var OrderItems = new OrderItem()
                    {
                        OrderId = OrderDetails.Id,
                        ProductId = product.ProdId,
                        Quantity = product.Quantity,
                        CreatedOn = DateTime.Now,
                    };
                    _logger.LogInformation("------------Order Items Added----------");
                    var inventry = db.InventryItems.FirstOrDefault(x => x.ProductDetailId == product.ProdId);
                    var WarehouseOrderMapping = new WarehouseOrderDetailsMapping()
                    {
                        WarehouseId = inventry.WarehouseId,
                        OrderDetailId = OrderDetails.Id,
                        OrderDetail = OrderDetails
                    };
                    _logger.LogInformation("------------Warehouse Order Mapping Added----------");
                    db.WarehouseOrderDetailsMappings.Add(WarehouseOrderMapping);
                    OrderDetails.OrderItems.Add(OrderItems);
                    db.OrderDetails.Add(OrderDetails);
                    inventry.ProductCount--;
                    db.InventryItems.Update(inventry);
                    _logger.LogInformation("------------Product Order Successfully----------");
                }

                foreach (var product in cart)
                {
                    var Product = new DeleteCartItem
                    {
                        UserId = model.UserId,
                        ProductDetailId = product.ProdId
                    };
                    _cartRepository.RemoveFromCart(Product);
                }
                db.SaveChanges();

                return true;
            }catch(Exception ex)
            {
                throw new Exception(ex.InnerException.ToString());
            }
        }

        public List<ShowMyOrdersModel> ShowUserOrder(ShowMyOrdersModel model)
        {
            throw new NotImplementedException();
        }
    }
}
