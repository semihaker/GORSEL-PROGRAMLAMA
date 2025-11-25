using System.Net.Http;
using System.Text.Json;

public class HolidayService
{
    private HttpClient client = new HttpClient();
    private List<Holiday> allHolidays = new List<Holiday>();
    private bool dataLoaded = false;

    public async Task LoadData()
    {
        if (dataLoaded) return;

        int[] years = { 2023, 2024, 2025 };

        foreach (int year in years)
        {
            string url = $"https://date.nager.at/api/v3/PublicHolidays/{year}/TR";
            string json = await client.GetStringAsync(url);

            var list = JsonSerializer.Deserialize<List<Holiday>>(json);
            if (list != null)
                allHolidays.AddRange(list);
        }

        dataLoaded = true;
    }

    public List<Holiday> GetByYear(int year)
    {
        return allHolidays
            .Where(h => h.date.StartsWith(year.ToString()))
            .ToList();
    }

  public List<Holiday> SearchByDate(string dayMonth, int? year = null)
{
    var query = allHolidays
        .Where(h => h.date.Substring(5) == dayMonth);

    if (year.HasValue)
    {
        string y = year.Value.ToString();
        query = query.Where(h => h.date.StartsWith(y));
    }

    return query.ToList();
}


    public List<Holiday> SearchByName(string name)
    {
        string lower = name.ToLower();
        return allHolidays
            .Where(h =>
                h.localName.ToLower().Contains(lower) ||
                h.name.ToLower().Contains(lower))
            .ToList();
    }

    public List<Holiday> GetAll()
    {
        return allHolidays;
    }
}
