using Microsoft.AspNetCore.Mvc;
using Phone.Data.Repositories;
using Phone.Models;
using System.Net;

namespace PhoneShopnet.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductCtl : Controller
    {
        private IUnit _unit;
        public ProductCtl(IUnit unit)
        {
            _unit = unit;
        }

    }
}
