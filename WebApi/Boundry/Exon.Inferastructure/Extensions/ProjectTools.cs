using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Globalization;

namespace Exon.Inferastructure.Extensions;

public static class ProjectTools
{
    public static string ConvertToShamsi(this DateTime? date)
    {
        var calendar = new PersianCalendar();
        var persianDate = new DateTime(calendar.GetYear(date.Value), calendar.GetMonth(date.Value), calendar.GetDayOfMonth(date.Value));
        var result = persianDate.ToString("yyyy/MM/dd");

        return result;
    }
}
