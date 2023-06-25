using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Extensions.Logging;
using NHCH.ULT;

namespace NHCH.API.Formats
{
    public class BaseApiController : ControllerBase
    {
        private string _Message;
        protected string Message { get { return string.IsNullOrEmpty(_Message) ? Constant.GetUserMessage(Status) : _Message; } set { _Message = value; } }
        protected object Data { get; set; }
        protected int Status { get; set; }
        protected int TotalRow { get; set; }
        protected int CanBoID { get; }
        protected int NguoidungID { get; }
        protected int CoQuanID { get; }
        private readonly ILogger _BugLogger;
        public BaseApiController()
        {
        }
        protected IActionResult GetActionResult()
        {
            return Ok(new
            {
                Status = Status,
                Message = Message,
                Data = Data,
                TotalRow = TotalRow,
            });
        }
        protected IActionResult GetActionResult(int status, string message, object data = null, int totalRow = 0)
        {
            if (data == null)
                return Ok(new
                {
                    Status = status,
                    Message = message,
                });
            else
                return Ok(new
                {
                    Status = status,
                    Message = message,
                    Data = data,
                    TotalRow = totalRow,
                });
        }
        protected IActionResult CreateActionResult(string LogString, Func<IActionResult> funct)
        {
            try
            {
                return funct.Invoke();
            }
            catch (Exception ex)
            {
                if (_BugLogger != null)
                    _BugLogger.LogInformation(ex.Message, LogString);
                Status = -1;
                return Ok(new
                {
                    Status = -1,
                    Message = Constant.API_Error_System,
                });
            }
        }

        protected IActionResult CreateActionResultAsync(string LogString, Func<IActionResult> funct)
        {
            try
            {
                return funct.Invoke();
            }
            catch (Exception ex)
            {
                if (_BugLogger != null)
                    _BugLogger.LogInformation(ex.Message, LogString);
                Status = -1;
                return Ok(new
                {
                    Status = -1,
                    Message = Constant.API_Error_System,
                });
            }
        }

        protected IActionResult CreateActionResultNew(int Status, string LogString, Func<IActionResult> funct)
        {
            try
            {
                return funct.Invoke();
            }
            catch (Exception ex)
            {
                Status = -1;
                return Ok(new
                {
                    Status = -1,
                    Message = Constant.API_Error_System,
                });
            }
        }



        protected IActionResult GetActionResultErrorAPI()
        {
            return Ok(new
            {
                Status = -1,
                Message = Constant.API_Error_System,
                Data = Data,
                TotalRow = 0,
            });
        }
    }
}
