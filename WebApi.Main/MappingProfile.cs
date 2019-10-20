namespace WebApi.Main
{
    using AutoMapper;
    using Database;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using WebApi.Main.Models;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<UserModel, User>()
                .ForMember("Id", options => options.ResolveUsing((src, ctx) =>
                {
                    return src.Id.ToString();
                }))
                .ForMember("DateJoined", options => options.ResolveUsing((src, ctx) =>
                {
                    return src.DateJoined.ToString();
                }));
        }
    }
}
