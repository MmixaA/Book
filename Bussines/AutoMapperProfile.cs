using AutoMapper;
using Bussines.Model;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Book, BookCreateModel>()
                .ForMember(bm => bm.Title, r => r.MapFrom(x => x.Title))
                .ForMember(bm => bm.Description, r => r.MapFrom(x => x.Description))
                .ForMember(bm => bm.Image, r => r.MapFrom(x => x.Image))
                .ForMember(bm => bm.PublishedDate, r => r.MapFrom(x => x.PublishedDate))
                .ForMember(bm => bm.IsTaken, r => r.MapFrom(x => x.IsTaken))
                .ForMember(bm => bm.Rating, r => r.MapFrom(x => x.Rating))
                .ForMember(bm => bm.Authors, r => r.MapFrom(x => x.Authors))
                .ReverseMap();
            CreateMap<Book, BookDTO>()
                .ForMember(bm => bm.ID, r => r.MapFrom(x => x.Id))
                .ForMember(bm => bm.Title, r => r.MapFrom(x => x.Title))
                .ForMember(bm => bm.Description, r => r.MapFrom(x => x.Description))
                .ForMember(bm => bm.Image, r => r.MapFrom(x => x.Image))
                .ForMember(bm => bm.PublishedDate, r => r.MapFrom(x => x.PublishedDate))
                .ForMember(bm => bm.IsTaken, r => r.MapFrom(x => x.IsTaken))
                .ForMember(bm => bm.Rating, r => r.MapFrom(x => x.Rating))
                .ForMember(bm => bm.Authors, r => r.MapFrom(x => x.Authors))
                .ReverseMap();
            CreateMap<Author, AuthorDTO>()
                .ForMember(bm => bm.Name, r => r.MapFrom(x => x.Name))
                .ForMember(Am => Am.Surname, r => r.MapFrom(x => x.Surname))
                .ForMember(bm => bm.BirthDate, r => r.MapFrom(x => x.BirthDate))
                .ForMember(bm => bm.BookId, r => r.MapFrom(x => x.BookId))
                .ReverseMap();
            CreateMap<Author, AuthorCreateModel>()
            .ForMember(bm => bm.Name, r => r.MapFrom(x => x.Name))
                .ForMember(Am => Am.Surname, r => r.MapFrom(x => x.Surname))
                .ForMember(bm => bm.BirthDate, r => r.MapFrom(x => x.BirthDate))
                .ReverseMap();
        }
    }
}
