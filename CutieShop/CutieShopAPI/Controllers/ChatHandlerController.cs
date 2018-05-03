﻿using CutieShop.API.Models.ChatHandlers;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;
using CutieShop.API.Models.JSONEntities.Settings;
using Microsoft.Extensions.Options;

namespace CutieShop.API.Controllers
{
    [Route("api/[controller]")]
    public class ChatHandlerController : Controller
    {
        private readonly MailContent _mailContent;

        public ChatHandlerController(IOptions<MailContent> mailContent)
        {
            _mailContent = mailContent.Value;
        }

        [HttpPost]
        public async Task<IActionResult> Index()
        {
            #region ReadJSON
            //var jsonData = await new StreamReader(Request.Body).ReadToEndAsync();
            //return Json(new {speech = jsonData});
            #endregion

            try
            {

                dynamic request = JsonConvert.DeserializeObject(await new StreamReader(Request.Body).ReadToEndAsync());

                try
                {
                    if (request.result.contexts[0].name == "buystep")
                    {
                        return await new BuyReqHandler(this, request, _mailContent).Result();
                    }
                }
                catch (Exception e)
                {
                    // ReSharper disable once PossibleIntendedRethrow
                    return Json(new { speech = e.Message + e.StackTrace });
                }
                return Json(new
                {
                    speech = "CutieBot chưa hiểu câu hỏi của bạn. Xin hãy đợi nhân viên chúng mình tiếp nhận để trả lời bạn sớm nhất"
                });
            }
            catch (Exception e)
            {
                return Json(new { speech = e.Message + e.StackTrace });
            }
        }
    }
}