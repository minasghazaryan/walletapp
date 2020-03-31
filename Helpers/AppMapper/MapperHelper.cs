using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalletApp.Data.Entities;
using WalletApp.ViewModels;
using WalletApp.WalletAppServices.Models;

namespace WalletApp.Helpers.AppMapper
{
    public class MapperHelper : Profile
    {
        public MapperHelper()
        {
            CreateMap<ApplicationUser, ApplicationUserViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(dest => dest.TotalAmount, opt => opt.MapFrom(src => src.TotalAmount))
                .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate)).ReverseMap();

            CreateMap<ApplicationUserViewModel, ApplicationUserServiceModel>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
               .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
               .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
               .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
               .ForMember(dest => dest.TotalAmount, opt => opt.MapFrom(src => src.TotalAmount))
               .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate)).ReverseMap();

            CreateMap<Transaction, TransactionServiceModel>()
                 .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                 .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                 .ForMember(dest => dest.SentDate, opt => opt.MapFrom(src => src.SentDate))
                 .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                 .ReverseMap();

            //CreateMap<TransactionServiceModel, Transaction>()
            //    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            //    .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            //    .ForMember(dest => dest.SentDate, opt => opt.MapFrom(src => src.SentDate))
            //    .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
            //    .ReverseMap();
            CreateMap<TransactionServiceModel, TransactionViewModel>()
                 .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                 .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                 .ForMember(dest => dest.SentDate, opt => opt.MapFrom(src => src.SentDate))
                 .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                 .ForMember(dest => dest.SendToUser, opt => opt.MapFrom(src => src.SendToUser)).ReverseMap();

        }
    }
}
