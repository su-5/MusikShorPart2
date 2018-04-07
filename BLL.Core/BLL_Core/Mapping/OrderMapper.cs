﻿using System;
using AutoMapper;
using DAL.Core;
using DAL.Core.ModelDTO;

namespace BLL.Core.BLL_Core.Mapping
{
    public class OrderMapper : Profile
    {
        public OrderMapper()
        {
            CreateMap<Order, OrderDto>()
                .ForMember(d => d.Id, opts => opts.MapFrom(src => src.Id))
                .ForMember(d => d.UserId, opts => opts.MapFrom(src => src.UserId))
                .ForMember(d => d.Amount, opts => opts.MapFrom(src => src.Amount))
                .ForMember(d => d.AddressDeliveryId, opts => opts.MapFrom(src => src.AddressDeliveryId))
                .ForMember(d => d.OrderSum, opts => opts.MapFrom(src => src.OrderSum))
                .ForMember(d => d.PaymentRequisitesId, opts => opts.MapFrom(src => src.PaymentRequisitesId))
                .ForMember(d => d.TypeOrdersId, opts => opts.MapFrom(src => src.TypeOrdersId))
                .ForMember(d => d.DateShapingOrders, opts => opts.MapFrom(src => DateTime.Now))
                .ForMember(d => d.DateCancel, opts => opts.MapFrom(src => src.DateCancel))
                .ForMember(d => d.DatePurchase, opts => opts.MapFrom(src => src.DatePurchase));
        }

    }
}