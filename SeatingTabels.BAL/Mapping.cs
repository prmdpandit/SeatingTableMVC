using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SeatingTabels.Models;
using Seating.Data;

namespace SeatingTabels.BAL
{
    public class DomainToViewModelMap : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Person, PersonVM>();
            Mapper.CreateMap<AssignTableToPerson, AssignTabletoPersonVM>();
            Mapper.CreateMap<Table, TableVM>();
            
        }
    }

    public class ViewModelToDomainMap : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<PersonVM, Person>();
            Mapper.CreateMap<AssignTabletoPersonVM, AssignTableToPerson>();
            Mapper.CreateMap<TableVM, Table>();
        }
    }

    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<DomainToViewModelMap>();
                x.AddProfile<ViewModelToDomainMap>();
            });
        }
    }


}
