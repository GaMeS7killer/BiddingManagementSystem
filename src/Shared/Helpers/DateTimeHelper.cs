// Shared/Helpers/DateTimeHelper.cs
using System;

namespace BiddingManagementSystem.Shared.Helpers
{
    public static class DateTimeHelper
    {
        public static bool IsExpired(DateTime deadline)
        {
            return DateTime.UtcNow > deadline;
        }
    }
}
