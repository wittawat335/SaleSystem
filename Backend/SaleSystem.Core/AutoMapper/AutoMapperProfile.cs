using AutoMapper;
using Microsoft.VisualBasic;
using SaleSystem.Core.Domain;
using SaleSystem.Core.DTO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleSystem.Core.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Role, RoleDTO>().ReverseMap();
            CreateMap<Menu, MenuDTO>().ReverseMap();
            CreateMap<Category, CategoryDTO>().ReverseMap();

            #region Product

            CreateMap<Product, ProductDTO>()
             .ForMember(x =>
               x.CategoryName,
               opt => opt.MapFrom(origin => origin.Category.Name)
               )
             .ForMember(x =>
               x.Price,
               opt => opt.MapFrom(origin => Convert.ToString(origin.Price.Value, new CultureInfo("en-US")))
               )
             .ForMember(x =>
               x.IsActive,
               opt => opt.MapFrom(origin => origin.IsActive == true ? 1 : 0)
               );

            CreateMap<ProductDTO, Product>()
             .ForMember(x =>
               x.Category,
               opt => opt.Ignore()
               )
             .ForMember(x =>
               x.Price,
                opt => opt.MapFrom(origin => Convert.ToDecimal(origin.Price, new CultureInfo("en-US")))
               )
             .ForMember(x =>
               x.IsActive,
                  opt => opt.MapFrom(origin => origin.IsActive == 1 ? true : false)
               );
            #endregion

            #region User
            // ขาออก
            CreateMap<User, UserDTO>()
               .ForMember(x =>
               x.UserId,
               opt => opt.MapFrom(origin => origin.UserId.ToString())
               )
               .ForMember(x =>
               x.RoleName,
               opt => opt.MapFrom(origin => origin.Role.Name)
               )
               .ForMember(x =>
               x.IsActive,
               opt => opt.MapFrom(origin => origin.IsActive == true ? 1 : 0)
               );

            CreateMap<User, SessionDTO>()
                .ForMember(x =>
                x.RoleName,
                opt => opt.MapFrom(origin => origin.Role.Name)
                );
            //ขาเข้า
            CreateMap<UserDTO, User>()
                .ForMember(x =>
                x.UserId,
                opt => opt.MapFrom(origin => new Guid(origin.UserId))
                )
                .ForMember(x =>
                x.Role,
                opt => opt.Ignore()
                )
               .ForMember(x =>
               x.IsActive,
               opt => opt.MapFrom(origin => origin.IsActive == 1 ? true : false)
               );

            #endregion

            #region Sales

            CreateMap<Sale, SaleDTO>()
                .ForMember(x =>
                x.TotalText,
                 opt => opt.MapFrom(origin => Convert.ToString(origin.Total.Value, new CultureInfo("en-US")))
                )
                 .ForMember(x =>
                x.CreateDate,
                 opt => opt.MapFrom(origin => origin.CreateDate.Value.ToString("dd/MM/yyyy"))
                );

            CreateMap<SaleDTO, Sale>()
                .ForMember(x =>
                x.Total,
                  opt => opt.MapFrom(origin => Convert.ToDecimal(origin.TotalText, new CultureInfo("en-US")))
                );

            #endregion

            #region SalesDetail

            CreateMap<SaleDetail, SaleDetailDTO>()
                .ForMember(x =>
                x.ProductName,
               opt => opt.MapFrom(origin => origin.Product.Name)
               )
               .ForMember(x =>
                x.PriceText,
                  opt => opt.MapFrom(origin => Convert.ToString(origin.Price.Value, new CultureInfo("en-US")))
                )
            .ForMember(x =>
                x.TotalText,
                  opt => opt.MapFrom(origin => Convert.ToString(origin.Total.Value, new CultureInfo("en-US")))
                );

            CreateMap<SaleDetailDTO, SaleDetail>()
                 .ForMember(x =>
                x.Price,
                  opt => opt.MapFrom(origin => Convert.ToDecimal(origin.PriceText, new CultureInfo("en-US")))
                )
                .ForMember(x =>
                x.Total,
                  opt => opt.MapFrom(origin => Convert.ToDecimal(origin.TotalText, new CultureInfo("en-US")))
                );

            #endregion

            #region Report

            CreateMap<SaleDetail, ReportDTO>()
                .ForMember(x =>
                  x.CreateDate,
                 opt => opt.MapFrom(origin => origin.Sale.CreateDate.Value.ToString("dd/MM/yyyy"))
                  )
                .ForMember(x =>
                  x.DocumentNumber,
                 opt => opt.MapFrom(origin => origin.Sale.DocumentNumber)
                  )
                .ForMember(x =>
                  x.PaymentMethod,
                 opt => opt.MapFrom(origin => origin.Sale.PaymentType)
                  )
                .ForMember(x =>
                  x.Product,
                 opt => opt.MapFrom(origin => origin.Product.Name)
                  )
                .ForMember(x =>
                x.SalesTotal,
                 opt => opt.MapFrom(origin => Convert.ToString(origin.Sale.Total.Value, new CultureInfo("en-US")))
                )
                .ForMember(x =>
                x.Price,
                 opt => opt.MapFrom(origin => Convert.ToString(origin.Price.Value, new CultureInfo("en-US")))
                )
                .ForMember(x =>
                x.Total,
                 opt => opt.MapFrom(origin => Convert.ToString(origin.Total.Value, new CultureInfo("en-US")))
                );

            #endregion
        }
    }
}
