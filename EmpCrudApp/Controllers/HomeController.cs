using AutoMapper;
using EmpCrudApp.EfCore.Data;
using EmpCrudApp.EfCore.Models;
using EmpCrudApp.Models;
using EmpCrudApp.Profile;
using EmpCrudApp.View_Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace EmpCrudApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DemoContext _demoContext;
        public HomeController(ILogger<HomeController> logger, DemoContext demoContext)
        {
            _logger = logger;
            _demoContext = demoContext;
        }

        public IActionResult Index()
        {
            var result = _demoContext.EmployeeTable.ToList();
            //Initializing AutoMapper
            var mapper = MapperConfig.InitializeAutomapper();
            var emp = mapper.Map<List<EmployeeTable>, List<EmployeeVieweModel>>(result);
            return View(emp.AsQueryable());
        }

        public IActionResult Add()
        {
            EmployeeVieweModel employee = new EmployeeVieweModel();
            employee.Id = 5;
            employee.Name = "Test";
            employee.EmailId = "jaiho@gmail.com";
            employee.MobileNo = "654674646764";
            return PartialView("~/views/Home/_ListEmployeePartialView.cshtml", employee);
        }
        //[HttpPost]
        public IActionResult Update(int id=1)
        {
            var getDetails= _demoContext.EmployeeTable.FirstOrDefault(x => x.Id == id);
            //Initializing AutoMapper
            var mapper = MapperConfig.InitializeAutomapper();
            var emp = mapper.Map<EmployeeTable, EmployeeVieweModel>(getDetails);
            emp.Name = "Uday";
            return PartialView("~/views/Home/_ListEmployeePartialView.cshtml",emp);
        }

        //[HttpPost]
        public IActionResult MyList()
        {
            List<EmployeeVieweModel> model = new List<EmployeeVieweModel> { 
                new EmployeeVieweModel() { Id=1,Name="Navved",EmailId="naveed@gmaul.com"}, 
                new EmployeeVieweModel() { Id=1,Name="Navved",EmailId="naveed@gmaul.com"}, 
                new EmployeeVieweModel() { Id=1,Name="Navved",EmailId="naveed@gmaul.com"} ,
                new EmployeeVieweModel() { Id=1,Name="Navved",EmailId="naveed@gmaul.com"},
                new EmployeeVieweModel() { Id=1,Name="Navved",EmailId="naveed@gmaul.com"} 
            };
            return PartialView("~/views/Home/_ListMulEmpl.cshtml", model.AsQueryable());

        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}