using AutoMapper;
using BookStore.EF_Core;
using BookStore.Models;

namespace BookStore.Mapper
{
    public class ApplicationMapper : Profile  // "Profile" is a interface used in AutoMapper
    {
        public ApplicationMapper()
        {
            CreateMap<Books, BookModel>();  // <Tsource , Tdestination>
          //CreateMap<shape , shapeModel>();
         }                                    // Here mapping from "Book" class to BookModel is done
    }
}
