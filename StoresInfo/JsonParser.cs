using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
namespace Bebrik1;
public class JsonParser
{
    public static string fPath;
    public static List<StoresData> ReadJson(int mode)
    {
        try
        {
            List<StoresData> storesList = new List<StoresData>();
            // ┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓
            // ┃ Используем StreamReader для чтения данных    ┃
            // ┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛
            string jsonData = mode == 1 ? GetStdInput() : GetInput();
            // Используем регулярное выражение для считывания данных
            string pattern = "\"store_id\":\\s*(\\d+),\\s*\"store_name\":\\s*\"([^\"]+)\",\\s*\"location" +
                             "\":\\s*\"([^\"]+)\",\\s*\"employees\":\\s*\\[\\s*((?:\"[^\"]+\",\\s*)*\"[^\"]+\")?\\s*\\],\\s*\"" +
                             "products\":\\s*\\[\\s*((?:\"[^\"]+\",\\s*)*\"[^\"]+\")?\\s*\\]";

            MatchCollection matches = Regex.Matches(jsonData, pattern);
            foreach (Match match in matches)
            {
                string storeId = match.Groups[1].Value;
                string storeName = match.Groups[2].Value;
                string location = match.Groups[3].Value;
                
                string employeesMatch = match.Groups[4].Value;
                string[] employees = ReadArrayValues(employeesMatch);
                
                string productsMatch = match.Groups[5].Value;
                string[] products = ReadArrayValues(productsMatch);
                StoresData store = new StoresData(storeId, storeName, location, employees, products);
                
                storesList.Add(store);
            }
            return storesList;
        }
        catch (ArgumentNullException)
        {
            Console.WriteLine("Обманщик!Это не мой файл!");
            Console.WriteLine("Повторите попытку");
            throw;
        }
        //отлов ошибок
        catch (ArgumentException e)
        {
            Console.WriteLine("Введено некорректное название");
            Console.WriteLine("Повторите попытку");
            throw;
        }
        catch (IOException e)
        {
            Console.WriteLine("Ошибка при открытии файла");
            Console.WriteLine("Повторите попытку");
            throw;
        }
        catch (Exception e)
        {
            Console.WriteLine("Ошибка");
            Console.WriteLine("Повторите попытку");
            throw;
        }
        return null;
    }
    private static string[] ReadArrayValues(string arrayString)
    {
        return Regex.Matches(arrayString, "\"([^\"]+)\"")
            .Cast<Match>()
            .Select(match => match.Groups[1].Value)
            .ToArray();
    }
    public static void WriteJson(string jsonData)
    {
        File.WriteAllText(fPath, string.Empty);
        var standardOutput = Console.Out;
        using (StreamWriter sw = new StreamWriter(fPath))
        {
            Console.SetOut(sw);
            Console.WriteLine(jsonData);
            Console.SetOut(standardOutput);
        }
    }
    public static string GetInput()
    {
        string data = "", line = "";
        var standardInput = Console.In; // Здесь стандартным потоком является базовая консоль, поэтому сохраняем, чтобы потом вернуть именно его.
        using (StreamReader fileReader = new StreamReader(fPath))
        {
            Console.SetIn(fileReader);
            do
            {
                line = fileReader.ReadLine();
                data += line + "\n";
            } while (line != null);
            Console.SetIn(standardInput);
        }
        return data;
    }
    public static string GetStdInput()
    {
        string data = "", line = "";
        var inputStream = Console.OpenStandardInput();
        using (StreamReader fileReader = new StreamReader(inputStream))
        {
            while (line != null)
            {
                line = fileReader.ReadLine();
                data += line + "\n";
            }
        }
        return data;
    }
}
