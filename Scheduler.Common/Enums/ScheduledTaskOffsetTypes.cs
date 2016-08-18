namespace Scheduler.Common.Enums
{
    /// <summary>
    /// Scheduled task offset types
    /// </summary>
    public enum ScheduledTaskOffsetTypes
    {
        None = 0,
        AfterMinutes = 1,
        AfterHours = 2,
        AfterDays = 3,
        AfterWeeks = 4,
        AfterMouths = 5,
        SelectedDayOfWeek = 101,
        OnBeginningOfSelectedMonth = 102,
    }
}
