
namespace Net6Mvc.Controllers.Api
{
    using Microsoft.AspNetCore.Mvc;
    using Net6Mvc.Domain.Model;

    [Route("api/DateTimeStamp")]
    public class DateTimeStampController : Controller
    {
        private ITimeStampHelper timeStampHelper;

        public DateTimeStampController(ITimeStampHelper timeStampHelper)
        {
            this.timeStampHelper = timeStampHelper;
        }

        [HttpGet]
        public GetResponse Get()
        {
            return new GetResponse()
            {
                DateTimeStamp = this.timeStampHelper.ToUtcTimeStamp(DateTime.Now),
                DateTimeFormat = DateTime.Now.ToString()
            };
        }

        public class GetResponse
        {
            public long DateTimeStamp { get; set; }

            public string DateTimeFormat { get; set; }
        }
    }
}
