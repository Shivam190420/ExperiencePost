using Microsoft.AspNetCore.Mvc;
using ExperiencePost.Models;
using ExperiencePost.Repo;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ExperiencePost.Controllers
{
    public class ExperiencePostController : Controller
    {
        private readonly IEmployeeRepo _employeerepo;
        
        public ExperiencePostController(IEmployeeRepo employeerepo)
        {
            _employeerepo = employeerepo;
        }
        public IActionResult Index()
        {
            //Here html page would have sign up and login form
            return View();
        }

        //Register's get method is same as Index's view

        [HttpPost]
        public IActionResult Register(Employee obj)
        {
            _employeerepo.AddEmp(obj);

            //Put registraion success in  Viewbag or Viewdata

            return RedirectToAction("Index");
        }

        [HttpPost]

        public IActionResult Login(LoginModel obj)
        {
            //For Later

            //Put registraion success in  Viewbag or Viewdata

            Employee emp = _employeerepo.GetEmpByEmail(obj.Email);

            if(emp == null)
            {
                return RedirectToAction("Index");  //Basically incorrect Email
            }

            if (emp.Password != obj.Password)
            {
                return RedirectToAction("Index");  //Basically incorrect Password
            }

            //We are passing Empid . If changes are made , subsequent changes needs to be made in all function which redirects to Index
            return RedirectToAction("Details", new { id = emp.EmpID });
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var Employee = _employeerepo.GetEmployeeByID(id);

            if (Employee == null)
            {
                return NotFound();
            }

            var Skills = _employeerepo.GetAllSkill(id);

            List<Employee> lst = new List<Employee>();
            lst.Add(Employee);
            ViewBag.Employee = lst;
            ViewBag.Skills = Skills;

            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Employee emp = _employeerepo.GetEmployeeByID(id);
            return View(emp);
        }

        [HttpPost]
        public IActionResult Edit(Employee obj)
        {
            _employeerepo.UpdateEmp(obj);
            return RedirectToAction("Details", new { id = obj.EmpID });
        }

        [HttpPost]
        public IActionResult DeleteSkill(int Skillid)
        {

            int id = _employeerepo.GetEmpBySkillId(Skillid);
            _employeerepo.Delete_Skill(Skillid);
            return RedirectToAction("Details", new { id = id });
        }

        [HttpGet]
        public IActionResult AddSkill(int id)
        {
            Skill skill = new Skill();
            skill.EmpID = id;
            return View(skill);
        }

        [HttpPost]
        public IActionResult AddSkill(Skill obj)
        {
            _employeerepo.AddSkill(obj);
            int id = _employeerepo.GetEmpBySkillId(obj.SkillId);
            return RedirectToAction("Details", new { id = obj.EmpID });
        }

    }
}
