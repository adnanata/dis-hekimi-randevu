using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Randevu.Data;
using Randevu.Models;
using Randevu.Models.AccountViewModels;

namespace Randevu.Controllers
{
    [Route("/manage/employee")]
    public class EmployeeController : Controller
    {
        public readonly ApplicationDbContext _appDbContext;
        private readonly UserManager<ApplicationUser> _userManager;

        public EmployeeController(ApplicationDbContext appDbContext, UserManager<ApplicationUser> userManager)
        {
            _appDbContext = appDbContext;
            _userManager = userManager;
        }


        [Route("")]
        public IActionResult Index()
        {  
            var model = this._appDbContext.Employees.ToList(); 
            return View(model);
        }
        
        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> Create(RegisterViewModel model, string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    /*
                    var employee = new Employee
                    {
                        Name = model.Name,
                        Surname = model.Surname,
                        PhoneNumber = model.Phone,
                        User = user
                    };
                    
                    this._appDbContext.Employees.Add(employee);
                    this._appDbContext.SaveChanges();*/
                }
                AddErrors(result);
            }

            return View(model);
        }
        
        [HttpGet]
        [Route("create")]
        public IActionResult Create(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }
        
        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }
    }
}