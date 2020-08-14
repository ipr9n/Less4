using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using AutoMapper;
using AutoMapper.Internal;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using X_Comm.EF;
using X_Comm.EF.Repositories;
using X_Comm.Models;
using X_Comm.Services.Interfaces;

namespace X_Comm.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private IUserService _userService;

        public HomeController(IUserService userService)
        {
            _userService = userService;
        }

        private AppUserManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
            }
        }
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        [HttpPost]
        public ActionResult BlockForm(string[] checks)
        {
            if (checks != null)
                _userService.BlockUsers(checks);

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult UnBlockForm(string[] checks)
        {
            if (checks != null)
                _userService.UnBlockUsers(checks);

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult UserDeleteForm(string[] checks)
        {
            if (checks != null)
                _userService.DeleteUsers(checks);

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Error()
        {
            AuthenticationManager.SignOut();

            return View("BlockView");
        }

        public ActionResult Index()
        {
            if (_userService.IsDeleted(User.Identity.GetUserId()) 
            || _userService.IsBlocked(User.Identity.GetUserId()))
                return RedirectToAction("Error", "Home");

            _userService.UpdateOnline(User.Identity.GetUserId());

            var config = new MapperConfiguration(cfg => cfg.CreateMap<User, UserViewModel>()
                .ForMember(x=>x.Username,x=>x.MapFrom(m=>m.Name)));

            Mapper viewModelMapper = new Mapper(config);

            var viewModels = viewModelMapper.Map<List<UserViewModel>>(_userService.GetAllUsers());
            viewModels.ForAll(x=>x.Status=_userService.IsBlocked(x.Id)?"Blocked":"Unblocked");

            return View(viewModels);
        }
    }
}