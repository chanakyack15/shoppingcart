using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication1.Data;
using WebApplication1.Data.Entities;

namespace WebApplication1.Controllers
{
    [Route("GET/[Controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IRepo repository;
        private readonly ILogger<ProductsController> logger;

        public ProductsController(IRepo repository, ILogger<ProductsController> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }
        [HttpGet]
        public IActionResult Get() {
            return Ok(repository.GetAllProducts());
        }

        // i tried to make the api for the id but i don't know why its not executing 
        [HttpGet("int:id")]
        public IActionResult Get(int id)
        {
            return Ok(repository.GetProductId(id));
        }
    }
}
