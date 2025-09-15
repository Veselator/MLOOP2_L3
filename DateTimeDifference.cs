namespace MLOOP2_L3
{
    internal class DateTimeDifference
    {
        public static int GetDifferenceInDays(DateTime firstDate, DateTime secondDate)
        {
            TimeSpan difference = firstDate - secondDate;
            return (int)difference.TotalDays;
        }
        public static int GetDifferenceInHours(DateTime firstDate, DateTime secondDate)
        {
            TimeSpan difference = firstDate - secondDate;
            return (int)difference.TotalHours;
        }
    }
}
