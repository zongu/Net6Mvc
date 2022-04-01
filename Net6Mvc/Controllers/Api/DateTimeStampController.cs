
namespace Net6Mvc.Controllers.Api
{
    using Microsoft.AspNetCore.Mvc;
    using Net6Mvc.Domain.Model;

    [Route("api/DateTimeStamp")]
    public class DateTimeStampController : Controller
    {
        private ILogger<DateTimeStampController> logger;

        private ITimeStampHelper timeStampHelper;

        public DateTimeStampController(ILogger<DateTimeStampController> logger, ITimeStampHelper timeStampHelper)
        {
            this.logger = logger;
            this.timeStampHelper = timeStampHelper;
        }

        [HttpGet]
        public GetResponse Get()
        {
            this.logger.LogTrace($"{this.GetType().Name} Get Received");

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
