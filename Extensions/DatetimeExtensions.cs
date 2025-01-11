using System;
using System.Linq.Expressions;

namespace SmartCards.Extensions
{
    public static class DatetimeExtensions
    {
        public static string ToRelativeTime(this DateTime createdAt)
        {
            var now = DateTime.UtcNow;
            var timespan = now - createdAt;

            // Switch expression
            return timespan.TotalDays switch
            {
                >= 365 => $"{(int)(timespan.TotalDays / 365)} năm trước",
                >= 30 => $"{(int)(timespan.TotalDays / 30)} tháng trước",
                >= 7 => $"{(int)(timespan.TotalDays / 7)} tuần trước",
                >= 1 => $"{(int)(timespan.TotalDays)} ngày trước",
                _ => timespan.TotalHours switch
                {
                    >= 1 => $"{(int)(timespan.TotalHours)} giờ trước",
                    >= 1 / 60.0 => $"{(int)(timespan.TotalMinutes)} phút trước",
                    _ => "Vừa xong"
                }
            };
        }
    }
}
