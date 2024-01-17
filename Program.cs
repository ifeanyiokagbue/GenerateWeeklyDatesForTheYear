using System.Globalization;

namespace GenerateWeeklyDatesForTheYear
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> weeklyDates = getDates();
            foreach(string weeklyDate in weeklyDates)
            {
                Console.WriteLine(weeklyDate);
            }
        }

        static List<string> getDates()
        {
            List<string> dates = new List<string>();
            int theYear = DateTime.Now.Year;
            //Get Number of Weeks in the Year
            int numberOfWeeks = GetWeeksInYear(theYear);

            for (int i = 1; i <= numberOfWeeks; i++)
            {
                string weeklyDates = $"{GetMondayDate(theYear, i).Date} - {GetMondayDate(theYear, i).AddDays(4).Date}";
                dates.Add(weeklyDates);
            }

            return dates;
        }

        static int GetWeeksInYear(int year)
        {
            // Specify the culture for which you want to get the calendar information
            CultureInfo cultureInfo = CultureInfo.CurrentCulture;

            // Get the calendar for the specified culture
            Calendar calendar = cultureInfo.Calendar;

            // Get the number of weeks in the specified year
            int weeksInYear = calendar.GetWeekOfYear(new DateTime(year, 12, 31), cultureInfo.DateTimeFormat.CalendarWeekRule, cultureInfo.DateTimeFormat.FirstDayOfWeek);

            return weeksInYear;
        }

        static DateTime GetMondayDate(int year, int weekNumber)
        {
            DateTime jan1 = new DateTime(year, 1, 1);
            DateTime firstDayOfYear = jan1.AddDays((int)jan1.DayOfWeek == 0 ? -6 : -((int)jan1.DayOfWeek - 1));

            DateTime mondayDate = firstDayOfYear.AddDays((weekNumber - 1) * 7);

            return mondayDate;
        }
    }
}