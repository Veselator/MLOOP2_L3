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
            Employed youngestVladimir = allVladimirs.OrderBy(e => e.Age).First();

            Console.WriteLine("\n === СТАТИСТИКА ПІДПРИЄМСТВА ===");
            Console.WriteLine($" Назва компанії: {company.Name}");
            Console.WriteLine($" Кількість робітників: {countOfEmployee}");
            Console.WriteLine($" Загальний фонд оплати праці: {totalMounthlyWage:F2} USD/місяць");

            Console.WriteLine("\n === ТОП-10 ЗА ДОСВІДОМ ===");

            List<string> top10WIthHighestExperienceString = [];
            foreach (var e in top10WIthHighestExperience)
            {
                top10WIthHighestExperienceString.Add(e.ToString());
            }

            FinePrint<string>.PrintList(top10WIthHighestExperienceString, "10 найдосвідченіших працівників");

            Console.WriteLine($"\n === НАЙМОЛОДШИЙ З ВИЩОЮ ОСВІТОЮ (серед топ-10) ===");
            Console.WriteLine($" {youngestWithHighEducation}");
            Console.WriteLine($" Вік: {youngestWithHighEducation.Age} років");
            Console.WriteLine($" Досвід: {youngestWithHighEducation.ExperienceInYears} років");

            Console.WriteLine("\n === МЕНЕДЖЕРИ ===");
            Console.WriteLine($" Найстарший менеджер: {theOldestManager} (вік: {theOldestManager.Age})");
            Console.WriteLine($" Наймолодший менеджер: {theYoungestManager} (вік: {theYoungestManager.Age})");

            Console.WriteLine("\n === НАРОДЖЕНІ В ЖОВТНІ (за посадами) ===");
            foreach (var jobGroup in peopleWhoBornAtOctober)
            {
                Console.WriteLine($" {jobGroup.Key}:");
                foreach (var person in jobGroup.Value)
                {
                    Console.WriteLine($"  - {person.fullName.name} {person.fullName.surname} (народився: {person.DateOfBirth:dd.MM.yyyy})");
                }
            }

            Console.WriteLine("\n === ВОЛОДИМИРИ ===");
            FinePrint<Employed>.PrintList(allVladimirs, "Усі Володимири на підприємстві");

            if (allVladimirs.Count > 0)
            {
                decimal bonus = youngestVladimir.MounthlyWage / 3;
                Console.WriteLine($"\n === ПРЕМІЯ ===");
                Console.WriteLine($" Наймолодший Володимир: {youngestVladimir.fullName.name} {youngestVladimir.fullName.surname}");
                Console.WriteLine($" Вік: {youngestVladimir.Age} років");
                Console.WriteLine($" Оклад: {youngestVladimir.MounthlyWage:F2} USD");
                Console.WriteLine($" ВІТАЄМО! Премія складає: {bonus:F2} USD (1/3 окладу)");
            }
        }
    }
}
