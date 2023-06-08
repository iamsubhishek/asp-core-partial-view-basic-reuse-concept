using AutoMapper;
using EmpCrudApp.EfCore.Models;
using EmpCrudApp.View_Model;

namespace EmpCrudApp.Profile
{
    public class MapperConfig
    {

        public static Mapper InitializeAutomapper()
        {
            //Provide all the Mapping Configuration
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EmployeeTable, EmployeeVieweModel>().ReverseMap();
            });
            //Create an Instance of Mapper and return that Instance
            var mapper = new Mapper(config);
            return mapper;
        }
    }
}
