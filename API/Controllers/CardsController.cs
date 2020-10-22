using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Services;
using Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        private ICardsService _cardsService;

        public CardsController(ICardsService service)
        {
            _cardsService = service;
        }

        [HttpGet("")]
        public IEnumerable<Card> GetAll()
        {
            return _cardsService.FetchCards(); 
        }

    }
}
