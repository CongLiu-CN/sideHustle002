using AngularJS_Proj.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Net.Http;
using AngularJS_Proj.Services;
using Microsoft.AspNetCore.Cors;
using System;

namespace AngularJS_Proj.Controllers
{
    public class AppController : Controller
    {
        private readonly IConfiguration _config;

        public AppController(IConfiguration config)
        {
            _config = config;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("contact")]
        public IActionResult UserSubmit([FromBody] ContactModel content)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return NotFound();
                }
                //ViewData["ReCaptchaKey"] = _config.GetSection("GoogleReCaptcha:key").Value;

                if (!ReCaptchaPassed(content.captchaKey, _config.GetSection("GoogleReCaptcha:secret").Value))
                {
                    return NotFound();
                }
                ContactModel user = new ContactModel
                {
                    Name = content.Name,
                    Email = content.Email,
                    Message = content.Message,
                    Session = content.Session
                };
                MailSender mailSender = new MailSender();
                mailSender.SendMail(user);
                return StatusCode(200);
            }
            catch(Exception e)
            {
                return Content(e.ToString());
            }
          
        }

        public static bool ReCaptchaPassed(string gRecaptchaResponse, string secret)
        {
            HttpClient httpClient = new HttpClient();
            var res = httpClient.GetAsync($"https://www.google.com/recaptcha/api/siteverify?secret={secret}&response={gRecaptchaResponse}").Result;
            if (res.StatusCode != HttpStatusCode.OK)
            {
                return false;
            }

            //string JSONres = res.Content.ReadAsStringAsync().Result;
            //dynamic JSONdata = JObject.Parse(JSONres);
            //if (JSONdata.success != "true")
            //{
            //    return false;
            //}

            return true;
        }
    }
}
