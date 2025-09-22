using Data;

namespace Helper
{
    public class UserInput
    {
        public static bool Parse(string userInput, User user, bool isStart)
        {
            switch (userInput)
            {
                case "add":
                    string item = "";
                    int amount = 0;

                    Console.Write("請輸入項目:");
                    item = Console.ReadLine();
                    while (item == "")
                    {
                        Console.Write("項目請不要留白，請重新輸入:");
                        item = Console.ReadLine();
                    }

                    Console.Write("請輸入金額:");
                    int.TryParse(Console.ReadLine(), out amount);
                    while (amount == 0)
                    {
                        Console.WriteLine("金額格式錯誤，請重新輸入:");
                        int.TryParse(Console.ReadLine(), out amount);
                    }

                    user.Description = item;
                    user.Amount = amount;
                    user.Date = DateTime.Now;

                    Report.Add(user);
                    break;

                case "list":
                    Report.List();
                    break;

                case "summary":
                    Report.Summary();
                    break;

                case "exit":
                    isStart = false;
                    return isStart;

                case "summarybymonth":
                    System.Console.Write("請輸入月份:");
                    int month = 0;
                    if (int.TryParse(Console.ReadLine(), out month))
                    {
                        Report.SummaryByMonth(month);
                    }
                    break;


                case "delete":
                    Console.Write("請輸入欲刪除的id:");
                    int deleteNumber = 0;
                    if (int.TryParse(Console.ReadLine(), out deleteNumber))
                    {
                        Report.Delete(deleteNumber);
                    }
                    break;

            }
            return isStart;
        }
    }
}