using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using static CarMarket.Areas.Admin.Constants.AdminConstants;

namespace CarMarket.Areas.Admin.Controllers
{
    [Area(AreaName)]
    [Authorize(Roles = AdminRoleName)]
    public class AdminController : Controller
    {
        
    }
}
