using System.Text.Json;

namespace MLOOP2_L3.T2
{
    internal class Task2 : ITask
    {
        public static string Name => "Завдання 2";
        private static string defaultFileName => "phones.json";

        private static List<Phone> phones;

        public static void Start()
        {
            try
            {
                string jsonString = File.ReadAllText(defaultFileName);
                phones = JsonSerializer.Deserialize<List<Phone>>(jsonString) ?? [];
            }
            catch
            {
                phones = [];
            }

            DoSomeLINQ();
            WaitKey.WaitForKeyAndClear();
        }

        private static void DoSomeLINQ()
        {
            int NumOfPhones = phones.Count();
            int NumOfPhonesIfPriceIsMore100 = phones.Where(p => p.Price > 100).Count();
            int NumOfPhonesIfPriceIsMore400AndLessThan700 = phones.Where(p => p.Price > 400 && p.Price < 700).Count();

            Dictionary<string, int> NumOfPhonesByEachManufacturer = phones.GroupBy(p => p.Manufacturer).ToDictionary(group => group.Key, group => group.Count());
            Dictionary<string, int> NumOfPhonesByEachModel = phones.GroupBy(p => p.Name).OrderBy(group => group.Count()).Reverse().ToDictionary(group => group.Key, group => group.Count());
            Dictionary<int, int> NumOfPhonesByEachYear = phones.GroupBy(p => p.DateOfRelease.Year).OrderBy(group => group.Key).Reverse().ToDictionary(group => group.Key, group => group.Count());

            Phone minPricePhone = phones.OrderBy(p => p.Price).First();
            Phone maxPricePhone = phones.OrderBy(p => p.Price).Last();

            Phone oldestPhone = phones.OrderBy(p => p.DateOfRelease).First();
            Phone newestPhone = phones.OrderBy(p => p.DateOfRelease).Last();

            float averagePrice = phones.Average(p => p.Price);

            List<Phone> fiveMostExpensivePhones = phones.OrderBy(p => p.Price).Reverse().Take(5).ToList();
            List<Phone> fiveCheapestPhones = phones.OrderBy(p => p.Price).Take(5).ToList();

            List<Phone> threeOldestPhones = phones.OrderBy(p => p.DateOfRelease).Take(3).ToList();
            List<Phone> threeNewestPhones = phones.OrderBy(p => p.DateOfRelease).Reverse().Take(3).ToList();

            Console.WriteLine("\n === СТАТИСТИКА ТЕЛЕФОНІВ ===");
            Console.WriteLine($" Загальна кількість телефонів: {NumOfPhones}");
            Console.WriteLine($" Телефонів дорожче 100: {NumOfPhonesIfPriceIsMore100}");
            Console.WriteLine($" Телефонів від 400 до 700: {NumOfPhonesIfPriceIsMore400AndLessThan700}");
            Console.WriteLine($" Середня ціна: {averagePrice:F2}");

            Console.WriteLine("\n === КІЛЬКІСТЬ ПО ВИРОБНИКАХ ===");
            foreach (var manufacturer in NumOfPhonesByEachManufacturer)
                Console.WriteLine($" {manufacturer.Key}: {manufacturer.Value}");

            Console.WriteLine("\n === КІЛЬКІСТЬ ПО МОДЕЛЯХ ===");
            foreach (var model in NumOfPhonesByEachModel)
                Console.WriteLine($" {model.Key}: {model.Value}");

            Console.WriteLine("\n === КІЛЬКІСТЬ ПО РОКАХ ===");
            foreach (var year in NumOfPhonesByEachYear)
                Console.WriteLine($" {year.Key}: {year.Value}");

            Console.WriteLine("\n === ЕКСТРЕМАЛЬНІ ЗНАЧЕННЯ ===");
            Console.WriteLine($" Найдешевший: {minPricePhone}");
            Console.WriteLine($" Найдорожчий: {maxPricePhone}");
            Console.WriteLine($" Найстарший: {oldestPhone}");
            Console.WriteLine($" Найновіший: {newestPhone}");

            Console.WriteLine("\n === ТОП СПИСКИ ===");
            FinePrint<Phone>.PrintList(fiveMostExpensivePhones, "5 найдорожчих телефонів");
            FinePrint<Phone>.PrintList(fiveCheapestPhones, "5 найдешевших телефонів");
            FinePrint<Phone>.PrintList(threeOldestPhones, "3 найстарших телефони");
            FinePrint<Phone>.PrintList(threeNewestPhones, "3 найновіших телефони");
        }
    }
}
