using AutomobileProject.Data.Models;
using AutomobileProject.ViewModels.Offer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutomobileProject.Controllers
{
    public class OfferController : Controller
    {
        private readonly ILogger<OfferController> _logger;
        private readonly AutomobileDbContext dbContext;

        public OfferController(ILogger<OfferController> logger, AutomobileDbContext dbContext)
        {
            _logger = logger;
            this.dbContext = dbContext;
        }

        [Authorize]
        public IActionResult Add()
        {
            return View(new AddOfferViewModel(dbContext));
        }

        [Authorize]
        [HttpPost]
        public IActionResult Add(AddOfferViewModel offer)
        {
            return View(new AddOfferViewModel(dbContext));
        }
    }
}
