using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using TicketSystem.Models;
using TicketSystem.Service;
using WebApplication1.Models;


namespace WebApplication1.Controllers
{
    [Authorize]
    public class ListController : Controller
    {
        private readonly ILogger<ListController> _logger;
        TrickService trickService = new TrickService();
        RoleService roleService = new RoleService();

        public ListController(ILogger<ListController> logger, IMemoryCache memoryCache)
        {
             _logger = logger;
            trickService.Reset(memoryCache);
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("[action]")]
        public IActionResult Query()
        {
            return Ok(trickService.TrickList);
        }

        [HttpGet("[action]")]
        public IActionResult Role()
        {
            return Ok(roleService.GetRole(User.Identity.Name));
        }

        [HttpPost("[action]")]
        public IActionResult Update([FromBody]TicketModel data)
        {
            var result = trickService.TrickList;

            // Update
            if (data!=null && !string.IsNullOrWhiteSpace(data.Id))
            {
                var index = result.FindIndex(x => x.Id == data.Id);
                if (index != -1)
                {
                    result[index].Summary = data.Summary;
                    result[index].Description = data.Description;
                    result[index].UpdateTime = DateTime.Now;
                }
                else
                {
                    return Error();
                }
            }
            //Create
            else
            {
                data.Id  = Guid.NewGuid().ToString();
                data.CreateTime = DateTime.Now;
                data.UpdateTime = DateTime.Now;
                result.Add(data);
            }
            trickService.SaveChange(result);

            return Ok(result);
        }


        [HttpPost("[action]")]
        public IActionResult UpdateResolve([FromBody]TicketModel data)
        {
            var result = trickService.TrickList;

            var index = result.FindIndex(x => x.Id == data.Id);
            if (index != -1)
            {
                result[index].Resolve = data.Resolve;
                trickService.SaveChange(result);
                return Ok(result);
            }
            return Error();
        }

        [HttpPost("[action]")]
        public IActionResult Delete([FromBody]TicketModel data)
        {
            var result = trickService.TrickList;

            var obj = result.Where(x => x.Id == data.Id).FirstOrDefault();
            result.Remove(obj);

            trickService.SaveChange(result);

            return Ok(result);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



    }
}
