using System.Text.Json;

namespace MLOOP2_L3.T1
{
    internal class Task1 : ITask
    {
        public static string Name => "Завдання 1";
        private static string defaultFileName => "companies.json";
        private const int DAYS_IN_YEAR = 365;

        private static List<Company> companies;

        public static void Start()
        {
            try
            {
                string jsonString = File.ReadAllText(defaultFileName);
                companies = JsonSerializer.Deserialize<List<Company>>(jsonString) ?? [];
            }
            catch
            {
                companies = [];
            }

            DoSomeLINQ();
            WaitKey.WaitForKeyAndClear();
        }

        private static void DoSomeLINQ()
        {
            List<Company> companiesCalledFood = companies.Where(c => c.Name != null && c.Name == "Food").ToList();
            List<Company> companiesInMarketing = companies.Where(c => c.Area == Company.AreaOfBusiness.Marketing).ToList();
            List<Company> companiesInMarketingOrIT = companies.Where(c => c.Area == Company.AreaOfBusiness.IT || c.Area == Company.AreaOfBusiness.Marketing).ToList();
            List<Company> companiesOver100Employees = companies.Where(c => c.NumOfEmployees > 100).ToList();
            List<Company> companiesOver100AndLess300Employees = companies.Where(c => c.NumOfEmployees > 100 && c.NumOfEmployees < 300).ToList();
            List<Company> companiesFromLondon = companies.Where(c => c.Address != null && c.Address.Contains("London")).ToList();
            List<Company> companiesWhite = companies.Where(c => c.CEO.surname != null && c.CEO.surname.Equals("White")).ToList();
            List<Company> companiesOver2years = companies.Where(c => DateTimeDifference.GetDifferenceInDays(DateTime.Now, c.DateOfFoundation) > DAYS_IN_YEAR * 2).ToList();
            List<Company> companiesOver150days = companies.Where(c => DateTimeDifference.GetDifferenceInDays(DateTime.Now, c.DateOfFoundation) > 150).ToList();
            List<Company> companiesBreakingBad = companies.Where(c => c.CEO.surname != null && c.CEO.surname.ToLower().Equals("black") && c.Name != null && c.Name.Contains("White")).ToList();

            FinePrint<Company>.PrintList(companies, "Всі компанії");
            FinePrint<Company>.PrintList(companiesCalledFood, "Компанії із назвою \"Food\"");
            FinePrint<Company>.PrintList(companiesInMarketing, "Компанії із області маркетингу");
            FinePrint<Company>.PrintList(companiesInMarketingOrIT, "Компанії із області маркетингу або IT");
            FinePrint<Company>.PrintList(companiesOver100Employees, "Компанії, де працює більше 100 працівників");
            FinePrint<Company>.PrintList(companiesOver100AndLess300Employees, "Компанії, де працює більше 100 але менше 300 працівників");
            FinePrint<Company>.PrintList(companiesFromLondon, "Компанії із Лондона");
            FinePrint<Company>.PrintList(companiesWhite, "Компанії, де у гендиректорая прізвище White");
            FinePrint<Company>.PrintList(companiesOver2years, "Компанії, які працюють більше двох років");
            FinePrint<Company>.PrintList(companiesOver150days, "Компанії, які працюють більше 150 днів");
            FinePrint<Company>.PrintList(companiesBreakingBad, "Компанії, де прізвище гендиректора Black та назва компанії \"White\"");
        }
    }
}
