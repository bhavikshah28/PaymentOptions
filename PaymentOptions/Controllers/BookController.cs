using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaymentOptions.Models;
using PaymentOptions.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PaymentOptions.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : Controller
    {
        private readonly IBraintreeService _braintreeservice;
        private readonly PaymentDetailContext _paymentdetailcontext;

        public BookController(IBraintreeService braintreeservice, PaymentDetailContext paymentdetailcontext)
        {
            _braintreeservice = braintreeservice;
            _paymentdetailcontext = paymentdetailcontext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBook()
        {
            return await _paymentdetailcontext.Books.ToListAsync();
        }

        [HttpGet("Token")]
        public string GetBookToken()
        {
            var gateway = _braintreeservice.GetGateway();
            var token =  gateway.ClientToken.Generate();
            return token;
        }



        public IActionResult Index()
        {
            return View();
        }
    }
}
