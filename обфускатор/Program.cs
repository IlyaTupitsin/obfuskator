using System;
using System.IO;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        // Чтение кода из файла
        string path = "C:\\Users\\Пользователь\\Desktop\\кликер и таймер.txt";
        string inputCode = File.ReadAllText(path);
        // Удаляем комментарии
        string codenotcoment = Regex.Replace(inputCode, @"(//.*?$)|(/\*.*?\*/)", string.Empty, RegexOptions.Multiline);
        // Удаляем лишние пробелы и символы перехода на новую строку
        inputCode = Regex.Replace(codenotcoment, @"\s+", " ");
        // Удаляем комментарии
      
       
        inputCode = inputCode.Replace("Program", "новое_имя_класса");

        // Заменяем имя файла
        inputCode = inputCode.Replace("кликер и таймер", "новое_имя_файла");

        // Заменяем имя конструктора
        inputCode = inputCode.Replace("старое_имя_конструктора", "новое_имя_конструктора");
        // Находим все идентификаторы в коде
        var identifiers = Regex.Matches(inputCode, @"\b\w+\b")
                               .OfType<Match>()
                               .Select(m => m.Value)
                               .Distinct()
                               .ToArray();

        // Заменяем идентификаторы на односимвольные или двухсимвольные имена 
        for (int i = 0; i < identifiers.Length; i++)
        {
            string replacement = i < 26 ? ((char)('a' + i)).ToString() : "var" + (i - 26 + 1);
            inputCode = Regex.Replace(inputCode, $@"\b{identifiers[i]}\b", replacement);
        }
        // Вывод измененного кода
        Console.WriteLine("Измененный код:");
        Console.WriteLine(inputCode);
       

    }
}
