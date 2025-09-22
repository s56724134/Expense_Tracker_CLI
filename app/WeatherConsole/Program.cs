// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using Helper;
using Data;

bool isStart = true;

while (isStart)
{
    Console.Write("請輸入(add、list、summary、summarybymonth、delete、exit):");

    string userInput = "";
    while (userInput == "")
    {
        userInput = Console.ReadLine();
        if (userInput == "")
        {
            Console.Write("請勿輸入空白內容");
        }
    }

    User user = new User();

    isStart = UserInput.Parse(userInput, user, isStart);

    // Console.ReadKey();
}


