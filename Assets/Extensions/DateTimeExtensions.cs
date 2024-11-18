using System;

public static class DateTimeExtensions
{
    //====================================================================================================
    //====================================================================================================

    public static readonly string DateTimeFormat = "dd/MM/yyyy hh:mm tt";

    /// <summary>
    /// Returns a 12-h time string of 0-12 am - 1-12 pm
    /// </summary>
    public static string GetSGTimeString(this DateTime dt)
    {
        return (dt.Hour > 12 ? dt.Hour - 12 : dt.Hour).ToString() + dt.ToString(":mm tt");
    }

    //====================================================================================================
    //====================================================================================================

    /// <summary>
    /// Returns the date as midnight
    /// </summary>
    public static DateTime GetMidnight(this DateTime value)
    {
        return new DateTime(value.Year, value.Month, value.Day);
    }

    /// <summary>
    /// Returns the first day of the month
    /// </summary>
    public static DateTime FirstOfMonth(this DateTime value)
    {
        return new DateTime(value.Year, value.Month, 1);
    }

    /// <summary>
    /// Returns the last day of the month
    /// </summary>
    public static DateTime EndOfMonth(this DateTime value)
    {
        return new DateTime(value.Year, value.Month, 1).AddMonths(1).AddDays(-1);
    }

    //====================================================================================================
    //====================================================================================================

    /// <summary>
    /// Returns true if a date is between two days
    /// </summary>
    public static bool IsBetween(this DateTime value, DateTime from, DateTime to)
    {
        return ((from <= value) && (to >= value));
    }

    //====================================================================================================
    //====================================================================================================

    /// <summary>
    /// Returns true if both dates are the same
    /// </summary>
    public static bool IsSameDay(this DateTime dt, DateTime otherdt)
    {
        
        return dt.Date == otherdt.Date;
    }

    /// <summary>
    /// Returns true if date is today
    /// </summary>
    public static bool IsToday(this DateTime dt)
    {
        return dt.Date == DateTime.Now.Date;
    }

    //====================================================================================================
    //====================================================================================================

}