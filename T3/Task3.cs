using System.Text.Json;

namespace MLOOP2_L3.T3
{
    internal class Task3 : ITask
    {
        public static string Name => "Завдання 3";
        private static string defaultFileName => "task3.json";
        private const int DAYS_IN_YEAR = 365;

        private static Company company;

        public static void Start()
        {
            try
            {
                string jsonString = File.ReadAllText(defaultFileName);
                company = JsonSerializer.Deserialize<Company>(jsonString) ?? new Company();
            }
            catch
            {
                company = new Company();
            }

            DoSomeLINQ();
            WaitKey.WaitForKeyAndClear();
        }

        private static void DoSomeLINQ()
        {
            List<Employed> employee = company.Employee;

            int countOfEmployee = employee.Count;
            decimal totalMounthlyWage = employee.Sum(e => e.MounthlyWage);

            List<Employed> top10WIthHighestExperience = 
                employee.OrderBy(e => e.ExperienceInDays)
                .Reverse()
                .Take(10).ToList();

            Employed youngestWithHighEducation = 
                top10WIthHighestExperience
                .Where(e => e.DoesGraduetedHighEducation)
                .OrderBy(e => e.Age)
                .First();

            List<Employed> managers = employee.Where(e => e.jobTitle == Employed.JobTitle.Manager).ToList();
            Employed theOldestManager = managers.OrderBy(e => e.Age).Last();
            Employed theYoungestManager = managers.OrderBy(e => e.Age).First();

            Dictionary<Employed.JobTitle, List<Employed>> peopleWhoBornAtOctober = employee.Where(e => e.DateOfBirth.Month == 10).GroupBy(e => e.jobTitle).ToDictionary(group => group.Key, group => group.ToList());

            List<Employed> allVladimirs = employee.Where(e => e.fullName.name.ToLower() == "vladimir" || e.fullName.name.ToLower() == "володимир").ToList();
            Employed youngestVladimir = employee.OrderBy(e => e.Age).First();
        }
    }
}
