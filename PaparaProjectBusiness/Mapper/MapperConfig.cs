using AutoMapper;
using PaparaFinalData.Entity;
using PaparaProjectSchema.Requests;
using PaparaProjectSchema.Responses;

namespace PaparaProjectBusiness.Mapper
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<UserRequest, User>();
            CreateMap<User, UserResponse>();

            CreateMap<BasketRequest, Basket>();
            CreateMap<Basket, BasketResponse>();

            CreateMap<BasketItemRequest, BasketItem>();
            CreateMap<BasketItem, BasketItemResponse>();

            CreateMap<CategoryRequest, Category>();
            CreateMap<Category, CategoryResponse>();

            CreateMap<CouponRequest, Coupon>();
            CreateMap<Coupon, CouponResponse>();

            CreateMap<InvoiceRequest, Invoice>();
            CreateMap<Invoice, InvoiceResponse>();

            CreateMap<OrderRequest, Order>();
            CreateMap<Order, OrderResponse>();

            CreateMap<OrderDetailRequest, OrderDetail>();
            CreateMap<OrderDetail, OrderDetailResponse>();

            CreateMap<ProductRequest, Product>();
            CreateMap<Product, ProductResponse>();

            CreateMap<WalletRequest, Wallet>();
            CreateMap<Wallet, WalletResponse>();

            CreateMap<ProductCategoryMapRequest, ProductCategoryMap>();
        }
    }
}