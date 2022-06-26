using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NewGenerationBlog.WebAPI.Helpers
{
    public class BaseController : ControllerBase
    {
        public int UserId {
            get {
                return int.Parse(User.Claims.FirstOrDefault(p => p.Type == "Id").Value);
            }
        }
    }
}

