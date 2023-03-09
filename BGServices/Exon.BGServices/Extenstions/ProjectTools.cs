using System.Globalization;

namespace Exon.BGServices.Extenstions
{
    public class ProjectTools
    {
        public static string ConvertToShamsi(DateTime dateTime)
        {
            DateTime date = Convert.ToDateTime(dateTime);
            string persianDateString = date.ToString("yyyy/MM/dd", new CultureInfo("fa-IR"));

            return persianDateString;
        }
    }
}
