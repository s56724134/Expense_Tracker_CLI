using Data;
using System.Text.Json;
using System.Globalization;

namespace Helper
{
    public class Report
    {
        private static readonly string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "Json");
        private static readonly string filePath = Path.Combine(folderPath, "user.json");

        private static List<User> LoadUsers()
        {
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            if (!File.Exists(filePath))
            {
                return new List<User>();
            }

            string json = File.ReadAllText(filePath);
            return string.IsNullOrWhiteSpace(json)
                ? new List<User>()
                : JsonSerializer.Deserialize<List<User>>(json);
        }

        private static void SaveUsers(List<User> users)
        {
            string jsonString = JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, jsonString);
        }

        public static void Add(User user)
        {
            var users = LoadUsers();

            user.Id = users.Any() ? users.Max(u => u.Id) + 1 : 1;

            users.Add(user);
            SaveUsers(users);

            Console.WriteLine($"Expense added successfully (ID: {user.Id})");
        }

        public static void List()
        {
            var users = LoadUsers();

            if (users.Any())
            {
                Console.WriteLine("# ID  Date       Description  Amount");
                foreach (var u in users)
                {
                    Console.WriteLine($"{u.Id}   {u.Date:yyyy/MM/dd}  {u.Description}        ${u.Amount}");
                }
            }
            else
            {
                Console.WriteLine("目前清單中沒有項目");
            }
        }

        public static void Summary()
        {
            var users = LoadUsers();

            if (users.Any())
            {
                int total = users.Sum(u => u.Amount);
                Console.WriteLine($"Total expenses: ${total}");
            }
            else
            {
                Console.WriteLine("目前尚無任何資料");
            }
        }

        public static void Delete(int userInput)
        {
            var users = LoadUsers();

            var foundNumber = users.FirstOrDefault(u => u.Id == userInput);
            if (foundNumber == null)
            {
                Console.WriteLine("沒有此id");
                return;
            }

            users.Remove(foundNumber);
            SaveUsers(users);
            Console.WriteLine("Expense deleted successfully");
        }

        public static void SummaryByMonth(int userInput)
        {
            var users = LoadUsers();

            var usersQueryByMonth = users.Where(u => u.Date.Month == userInput).ToList();

            if (usersQueryByMonth.Any())
            {
                int totalSummary = usersQueryByMonth.Sum(u => u.Amount);
                Console.WriteLine($"Total expenses for {usersQueryByMonth[0].Date.ToString("MMMM", CultureInfo.InvariantCulture)}: ${totalSummary}");
            }
            else
            {
                Console.WriteLine("不存在此月份的資料");
            }
        }
    }
}
