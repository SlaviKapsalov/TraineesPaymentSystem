using Microsoft.AspNetCore.Authorization;

namespace TraineesPaymentSystem.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public abstract class BaseController : Controller
    {
    }
}