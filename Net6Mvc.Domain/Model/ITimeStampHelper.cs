
namespace Net6Mvc.Domain.Model
{
    using System;

    /// <summary>
    /// 時間格式小幫手
    /// </summary>
    public interface ITimeStampHelper
    {
        /// <summary>
        /// 現在UtcTimeStamp
        /// </summary>
        long UtcNow { get; }

        /// <summary>
        /// GTM時間
        /// </summary>
        /// <returns></returns>
        DateTime GTM();

        /// <summary>
        /// Cron5表達式
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        string ToCron5(DateTime dateTime);

        /// <summary>
        /// Cron7表達式
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        string ToCron7(DateTime dateTime);

        /// <summary>
        /// utcTimeStamp轉地區時間
        /// </summary>
        /// <param name="utcTimeStamp"></param>
        /// <returns></returns>
        DateTime ToLocalDateTime(long utcTimeStamp);

        /// <summary>
        /// 時間字串格式轉地區時間
        /// </summary>
        /// <param name="datetimeString"></param>
        /// <returns></returns>
        DateTime ToLocalDateTime(string datetimeString);

        /// <summary>
        /// utcTimeStamp轉UTC時間
        /// </summary>
        /// <param name="utcTimeStamp"></param>
        /// <returns></returns>
        DateTime ToUtcDateTime(long utcTimeStamp);

        /// <summary>
        /// 地區時間轉utcTimeStamp
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        long ToUtcTimeStamp(DateTime datetime);

        /// <summary>
        /// 時間字串轉utcTimeStamp
        /// </summary>
        /// <param name="datetimeString"></param>
        /// <returns></returns>
        long ToUtcTimeStamp(string datetimeString);

        /// <summary>
        /// 時間Truncate
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="timeSpan"></param>
        /// <returns></returns>
        DateTime Truncate(DateTime dateTime, TimeSpan timeSpan);

        /// <summary>
        /// unix轉地區時間
        /// </summary>
        /// <param name="unixTimeStamp"></param>
        /// <returns></returns>
        DateTime UnixTimeStampToLocalDateTime(long unixTimeStamp);

        /// <summary>
        /// UTC時間轉utcTimeStamp
        /// </summary>
        /// <param name="utcDatetime"></param>
        /// <returns></returns>
        long UtcDateTimeToUtcTimeStamp(DateTime utcDatetime);
    }
}
