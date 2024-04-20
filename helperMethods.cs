using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using System.Text;
namespace Bebrik1;

public class helperMethods
{
    //                                                  HelperMethods
    
    /// <summary>
    /// Метод выводит в консоль список объектов типа StoresData;
    /// </summary>
    /// <param name="storesList"></param>
    public static void PrintData(List<StoresData> storesList, FilterField filterField = FilterField.None)
    {
        foreach (var store in storesList)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine($" StoreId: {store.StoreId,-5} ");
            Console.WriteLine($" StoreName: {store.StoreName,-20} ");
            Console.WriteLine($" Location: {store.Location,-20} ");
            Console.WriteLine(" Employees:");
            foreach (var employee in store.Employees)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine($"   • {employee,-30}");
            }
            Console.WriteLine(" Products:");
            foreach (var product in store.Products)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine($"   • {product,-30}");
            }
            if (filterField != FilterField.None)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine($" ----------Filtered/Sorted by {filterField}----------");
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(new string('=', Console.WindowWidth - 1));
        }
    }
    // перечисление через enum
    public enum FilterField
    {
        StoreId = 1,
        StoreName,
        Location,
        Employees,
        Products,
        None
    }
    /// <summary>
    /// Метод делается сортировку в алфавитном порядке по выбранному значению.
    /// </summary>
    /// <param name="storesList"></param>
    /// <returns>Возвращает список объектов типа StoresData</returns>
    public static List<StoresData> Sorting(List<StoresData> storesList)
    {
        Console.ForegroundColor = ConsoleColor.White;

        Console.WriteLine("Выберите поле для сортировки:\n" +
                          "1. StoreId\n" +
                          "2. StoreName\n" +
                          "3. Location\n" +
                          "4. Employees\n" +
                          "5. Products\n");
        int choice;
        while (!(int.TryParse(Console.ReadLine(), out choice) && Enum.IsDefined(typeof(FilterField), choice) && choice > 0 && choice < 6))
        {
            Console.WriteLine("Неверные данные, введите целое число соответствующее полю!");
        }
        FilterField sortField = (FilterField)choice;

        switch (sortField)
        {
            case FilterField.StoreId:
                List<StoresData> res =  storesList.OrderBy(v => int.Parse(v.StoreId)).ToList();
                PrintData(res, sortField);
                return res;
            case FilterField.StoreName:
                List<StoresData> res1 =  storesList.OrderBy(v => v.StoreName).ToList();
                PrintData(res1, sortField);
                return res1;
            case FilterField.Location:
                List<StoresData> res2 =  storesList.OrderBy(v => v.Location).ToList();
                PrintData(res2, sortField);
                return res2;
            case FilterField.Employees:
                List<StoresData> res3 = storesList.OrderBy(v => string.Join(", ", v.Employees)).ToList();
                PrintData(res3, sortField);
                return res3;
            case FilterField.Products:
                List<StoresData> res4 =  storesList.OrderBy(v => string.Join(", ", v.Products)).ToList();
                PrintData(res4, sortField);
                return res4;
            default:
                Console.WriteLine("Такого поля не существует!");
                return storesList;
        }
    }
    /// <summary>
    /// Метод делается сортировку в порядке, обратном алфавитному по выбранному значению.
    /// </summary>
    /// <param name="storesList"></param>
    /// <returns>Возвращает список объектов типа StoresData</returns>
    public static List<StoresData> SortingByDescending(List<StoresData> storesList)
    {
        Console.ForegroundColor = ConsoleColor.White;

        Console.WriteLine("Выберите поле для сортировки:\n" +
                          "1. StoreId\n" +
                          "2. StoreName\n" +
                          "3. Location\n" +
                          "4. Employees\n" +
                          "5. Products\n");
        int choice;
        while (!(int.TryParse(Console.ReadLine(), out choice) && Enum.IsDefined(typeof(FilterField), choice) && choice > 0 && choice < 6))
        {
            Console.WriteLine("Неверные данные, введите целое число соответствующее полю!");
        }
        FilterField sortField = (FilterField)choice;

        switch (sortField)
        {
            case FilterField.StoreId:
                List<StoresData> res =  storesList.OrderByDescending(v => int.Parse(v.StoreId)).ToList();
                PrintData(res, sortField);
                return res;
            case FilterField.StoreName:
                List<StoresData> res1 =  storesList.OrderByDescending(v => v.StoreName).ToList();
                PrintData(res1, sortField);
                return res1;
            case FilterField.Location:
                List<StoresData> res2 =  storesList.OrderByDescending(v => v.Location).ToList();
                PrintData(res2, sortField);
                return res2;
            case FilterField.Employees:
                List<StoresData> res3 = storesList.OrderByDescending(v => string.Join(", ", v.Employees)).ToList();
                PrintData(res3, sortField);
                return res3;
            case FilterField.Products:
                List<StoresData> res4 =  storesList.OrderByDescending(v => string.Join(", ", v.Products)).ToList();
                PrintData(res4, sortField);
                return res4;
            default:
                Console.WriteLine("Такого поля не существует!");
                return storesList;
        }
    }
    /// <summary>
    /// Метод совершает фильтр по выбранному значению.
    /// </summary>
    /// <param name="storesList"></param>
    /// <returns>Возвращает список объектов типа StoresData</returns>
    public static List<StoresData> FilterUsingChoice(List<StoresData> storesList)
    {
        Console.ForegroundColor = ConsoleColor.White;

        Console.WriteLine("Выберите поле для фильтрации:\n" +
                          "1. StoreId\n" +
                          "2. StoreName\n" +
                          "3. Location\n" +
                          "4. Employees\n" +
                          "5. Products\n");
        int choice;
        while (!(int.TryParse(Console.ReadLine(), out choice) && Enum.IsDefined(typeof(FilterField), choice) && choice > 0 && choice < 6))
        {
            Console.WriteLine("Неверные данные, введите целое число!!");
        }
        FilterField filterField = (FilterField)choice;

        Console.WriteLine($"Введите значение для фильтрации по полю {filterField}:");
        string value = Console.ReadLine();
        switch (filterField)
        {
            case FilterField.StoreId:
                List<StoresData> res = storesList.Where(v => v.StoreId.Contains(value)).ToList();
                if (res.Count != 0 || res != null)
                {
                    PrintData(res, filterField);
                    return res;
                }
                else
                {
                    return null;
                }
            case FilterField.StoreName:
                List<StoresData> res1 = storesList.Where(v => v.StoreName.Contains(value)).ToList();
                if (res1.Count != 0 || res1 != null)
                {
                    PrintData(res1, filterField);
                    return res1;
                }
                else
                {
                    return null;
                }
            case FilterField.Location:
                List<StoresData> res2 = storesList.Where(v => v.Location.Contains(value)).ToList();
                if (res2.Count != 0 || res2 != null)
                {
                    PrintData(res2, filterField);
                    return res2;
                }
                else
                {
                    return null;
                }
            case FilterField.Employees:
                List<StoresData> res3 = storesList.Where(v => v.Employees.Any(t => t.Contains(value))).ToList();
                if (res3.Count != 0 || res3 != null)
                {
                    PrintData(res3, filterField);
                    return res3;
                }
                else
                {
                    return null;
                }
            case FilterField.Products:
                List<StoresData> res4 = storesList.Where(v => v.Products.Any(t => t.Contains(value))).ToList();
                if (res4.Count != 0 || res4 != null)
                {
                    PrintData(res4, filterField);
                    return res4;
                }
                else
                {
                    return null;
                }
            default:
                Console.WriteLine("Такого поля не существует!");
                return null;
        }
    }
    /// <summary>
    /// Метод предлагает пользователю вывести данные в консоль или сохранить данные в файл
    /// и совершает одно из действий.
    /// </summary>
    /// <param name="storesDatas"></param>
    public static void SaveOrDisp(List<StoresData> storesDatas)
    {
        string json = ConvertToJson(storesDatas);
        Console.WriteLine("1. Вывести данные в консоль.\n" +
                          "2. Сохранить данные в файл.\n");
        int choice;
        while (!(int.TryParse(Console.ReadLine(), out choice) && choice > 0 && choice < 3))
        {
            Console.WriteLine("Неккоректные данные, введите число 1 или 2!");
        }

        switch (choice)
        {
            case 1:
                helperMethods.PrintData(storesDatas);
                break;
            case 2:
                helperMethods.Finish(json);
                break;
            default:
                Console.WriteLine("Такого варианта не существует!");
                break;
        }
    }
    /// <summary>
    /// Метод предлагает пользователю внести данные в файл и записыввает их.
    /// </summary>
    /// <param name="json"></param>
    public static void Finish(string json)
    {
        Console.WriteLine("Хотите ли вы записать данные в файл?\n" +
                          "1 - Да\n" +
                          "2 - Нет\n");
        int answer;
        while (!(int.TryParse(Console.ReadLine(), out answer) & answer>0 & answer<3))
        {
            Console.WriteLine("Неверные данные, введите другое число!\n");
        }
        switch (answer)
        {
            case 1:
                while (true)
                {
                    Console.WriteLine("Выберите режим сохранения в файл:");
                    Console.WriteLine("1. Создание нового файла");
                    Console.WriteLine("2. Замена содержимого уже существующего файла");
                    int choice;
                    while (!(int.TryParse(Console.ReadLine(), out choice) && choice > 0 && choice < 3))
                    {
                        Console.WriteLine("Неверные данные, введите целое число 1 или 2!");
                    }

                    switch (choice)
                    {
                        case 1:
                        {
                            helperMethods.DialogToSaveToAnewFile(json);
                        } 
                            break;
                        case 2:
                        {
                            helperMethods.DialogToSaveToAnExistingFile(json);
                        } 
                            break;
                    }
                    break;
                }
                break;
            case 2:
                Console.WriteLine("Выполнение программы завершено\n.");
                break;
            default:
                Console.WriteLine("Такого варианта ответа нет\n");
                break;
        }
    }
    /// <summary>
    /// Метод конвертирует данные из списка типа List<StoresData> в строку для записи в формате json.
    /// </summary>
    /// <param name="storesList"></param>
    /// <returns>Строку для передачи в метод для сохранения в формате json</returns>
    public static string ConvertToJson(List<StoresData> storesList)
    {
        StringBuilder jsonBuilder = new StringBuilder();
        jsonBuilder.AppendLine("[");
        
        for (int i = 0; i < storesList.Count; i++)
        {
            jsonBuilder.AppendLine("  {");
            jsonBuilder.AppendLine($"    \"store_id\": {storesList[i].StoreId},");
            jsonBuilder.AppendLine($"    \"store_name\": \"{storesList[i].StoreName}\",");
            jsonBuilder.AppendLine($"    \"location\": \"{storesList[i].Location}\",");
            
            jsonBuilder.AppendLine("    \"employees\": [");
            for (int j = 0; j < storesList[i].Employees.Length; j++)
            {
                jsonBuilder.AppendLine($"      \"{storesList[i].Employees[j]}\"{(j < storesList[i].Employees.Length - 1 ? "," : "")}");
            }
            jsonBuilder.AppendLine("    ],");
            
            jsonBuilder.AppendLine("    \"products\": [");
            for (int j = 0; j < storesList[i].Products.Length; j++)
            {
                jsonBuilder.AppendLine($"      \"{storesList[i].Products[j]}\"{(j < storesList[i].Products.Length - 1 ? "," : "")}");
            }
            jsonBuilder.AppendLine("    ]");
            
            jsonBuilder.AppendLine($"  }}{(i < storesList.Count - 1 ? "," : "")}");
        }

        jsonBuilder.AppendLine("]");

        return jsonBuilder.ToString();
    }
    /// <summary>
    /// Метод сохраняет данные в новый файл.
    /// </summary>
    /// <param name="str"></param>
    public static void DialogToSaveToAnewFile(string str)
    {
        while (true)
        {
            Console.WriteLine("Введите имя файла в формате Название файла(не равное пустой строке).json:");
            string path = Console.ReadLine();
            JsonParser.fPath = path;
            if (path.Length < 6 || path.Substring(path.Length - 5, 5) != ".json" || File.Exists(path))
            {
                Console.WriteLine("Некорректные данные, повторите попытку!");
            }
            else
            {
                // Вызов метода для записи.
                JsonParser.WriteJson(str);
                Console.WriteLine("Данные успешно записаны");
                break;
            }
        }
    }
    /// <summary>
    /// Метод перезаписывает данные в файл.
    /// </summary>
    /// <param name="str"></param>
    public static void DialogToSaveToAnExistingFile(string str)
    {
        while (true)
        {
            Console.WriteLine("Введите имя файла в формате Название файла(не равное пустой строке).json:");
            string path = Console.ReadLine();
            JsonParser.fPath = path;
            if (path.Length < 6 || path.Substring(path.Length - 5, 5) != ".json" || !File.Exists(path))
            {
                Console.WriteLine("Некорректные данные, повторите попытку!(Неверный формат или такого файла не существует)");
            }
            else
            {
                // Вызов метода для записи.
                JsonParser.WriteJson(str);
                Console.WriteLine("Данные успешно записаны");
                break;
            }
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="list"></param>
    /// <returns>список объектов типа StoresData</returns>
    public static List<StoresData> ReadDataFromFile()
    {
        List<StoresData> list;
        while (true)
        {
            Console.WriteLine("Введите абсолютный путь до файла");
            var fPath = Console.ReadLine();
            try
            {
                
                // Присваеваем путь файлу.
                JsonParser.fPath = $"{fPath}";
                list  = JsonParser.ReadJson(2);
                if (list.Count == 0 | list is null)
                {
                    Console.WriteLine("Блин, похоже вы передали пустой файл");
                    continue;
                }
        
                // Проверка на существование файла
                if (!File.Exists(fPath))
                {
                    Console.WriteLine("Похоже такого файла не существует:(");
                    continue;
                }

                return list;
            }
            catch
            {
                continue;
            }
            break;
        }
    }
    /// <summary>
    /// Предоставляет пользователю меня для выбора действия
    /// </summary>
    /// <returns>целое число-выбор</returns>
    public static int Menu()
    {
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Выберите действие:");
        Console.WriteLine("1. Ввести данные через System.Console или предоставить путь к файлу.");
        Console.WriteLine("2. Отфильтровать данные.");
        Console.WriteLine("3. Отсортировать данные.");
        Console.WriteLine("4. Вывести данные в System.Console или сохранить в файл.");
        Console.WriteLine("5. Выход.");
        int choice;
        while (!int.TryParse(Console.ReadLine(), out choice))
        {
            Console.WriteLine("Неверные данные, введите целое число !");
        }

        return choice;
    }
    /// <summary>
    /// Дает пользователю выбор считать данные по пути или с консоли
    /// </summary>
    /// <returns>список объектов типа StoresData</returns>
    public static List<StoresData> ReadDataFromConsoleOrFile()
    {
        List<StoresData> list = new List<StoresData>();
        Console.WriteLine("Введите данные с консоли или передайте путь к файлу.\n" +
                          "1. Ввести данные с консоли.\n" +
                          "2. Передать путь к файлу.\n");
        int choiceFirst;
        while (!(int.TryParse(Console.ReadLine(), out choiceFirst) && choiceFirst > 0 && choiceFirst < 3))
        {
            Console.WriteLine("Неверные данные, введите целое число 1 или 2!");
        }
        
        switch (choiceFirst)
        {
            case 1:
                List<StoresData> stores;
                Console.WriteLine("Введите данные в формате JSON, в соответствии с форматом варианта:\n" +
                                  "Вводите данные через enter, для окончания ввода нажмите\n" +
                                  "control d (Mac OS)\n" +
                                  "ctrl z (Windows)\n");
                stores = JsonParser.ReadJson(1); // 1 - режим прочтения данных с консоли.
                if (stores.Count == 0 || stores == null)
                {
                    Console.WriteLine("Неверный формат данных!");
                }
                return stores;

                break;
            case 2:
                list = helperMethods.ReadDataFromFile();
                return list;
                break;
            default:
                Console.WriteLine("Такого варианта нет!");
                break;
        }

        return null;
    }
    /// <summary>
    /// Осуществляет вывод 1 кейса
    /// </summary>
    /// <param name="list"></param>
    /// <returns>список объектов типа StoresData</returns>
    public static List<StoresData> Case1Call(List<StoresData> list)
    {
        try
        {
            list = helperMethods.StartProgramm();
            return list;
        }
        catch 
        {
            Console.WriteLine("Ошибка!");
        }

        return null;
    }
    /// <summary>
    /// Осуществляет вывод 2 кейса
    /// </summary>
    /// <param name="list"></param>
    /// <returns>список объектов типа StoresData</returns>
    public static List<StoresData> Case2Call(List<StoresData> list)
    {
        try
        {
            List<StoresData> result = helperMethods.FilterUsingChoice(list);
            if (result != null && result.Count != 0)
            {
                Console.WriteLine("Хотите ли вы заменить предыдущие данные на новые?\n" +
                                  "1. Да\n" +
                                  "2. Нет\n");
                int vybor;
                while (!(int.TryParse(Console.ReadLine(), out vybor) && vybor > 0 && vybor < 3))
                {
                    Console.WriteLine("Неверные данные, введите целое число !");
                }
                if (vybor == 1)
                {
                    list = result;
                    return list;
                }
                else
                {
                    Console.WriteLine("Данные не были изменены.");
                    return list;
                }
            }
            else
            {
                Console.WriteLine("Данных с таким значением нет!");
                return list;
            }
                        
        }
        catch 
        {
            Console.WriteLine("Ошибка!");
        }

        return null;
    }
    /// <summary>
    /// Осуществляет вывод 3 кейса
    /// </summary>
    /// <param name="list"></param>
    /// <returns>список объектов типа StoresData</returns>
    public static List<StoresData> Case3Call(List<StoresData> list)
    {
        try
        {
            Console.WriteLine("1. Отсортировать в алфавитном порядке.\n" +
                              "2. Отсортировать в обратном алфавитному порядке.");
            int vybor;
            while (!(int.TryParse(Console.ReadLine(), out vybor) && vybor > 0 && vybor < 3))
            {
                Console.WriteLine("Неверные данные, введите целое число !");
            }
            if (vybor == 1)
            {
                List<StoresData> result = helperMethods.Sorting(list);
                if (result != null && result.Count != 0)
                {
                    Console.WriteLine("Хотите ли вы заменить предыдущие данные на новые?\n" +
                                      "1. Да\n" +
                                      "2. Нет\n");
                    int vybor1;
                    while (!(int.TryParse(Console.ReadLine(), out vybor1) && vybor1 > 0 && vybor1 < 3))
                    {
                        Console.WriteLine("Неверные данные, введите целое число !");
                    }
                    if (vybor1 == 1)
                    {
                        list = result;
                        return list;
                    }
                    else
                    {
                        Console.WriteLine("Данные не были изменены.");
                        return list;
                    }
                }
            }
            else
            {
                List<StoresData> result = helperMethods.SortingByDescending(list);
                Console.WriteLine("Хотите ли вы заменить предыдущие данные на новые?\n" +
                                  "1. Да\n" +
                                  "2. Нет\n");
                int vybor1;
                while (!(int.TryParse(Console.ReadLine(), out vybor1) && vybor1 > 0 && vybor1 < 3))
                {
                    Console.WriteLine("Неверные данные, введите целое число !");
                }
                if (vybor1 == 1)
                {
                    list = result;
                    return list;
                }
                else
                {
                    Console.WriteLine("Данные не были изменены.");
                    return list;
                }
            }
        }
        catch 
        {
            Console.WriteLine("Ошибка!");
        }

        return null;
    }
    /// <summary>
    /// Осуществляет вывод 4 кейса
    /// </summary>
    /// <param name="list"></param>
    public static void Case4Call(List<StoresData> list)
    {
        try
        {
            helperMethods.SaveOrDisp(list);
        }
        catch 
        {
            Console.WriteLine("Ошибка!");
        }
    }
    /// <summary>
    /// Осуществляет вывод 5 кейса
    /// </summary>
    /// <param name="list"></param>
    public static void Case5Call()
    {
        try
        {
            string appPath = Process.GetCurrentProcess().MainModule.FileName;
            Process.GetCurrentProcess().Kill();
        }
        catch
        {
            Console.WriteLine("Ошибка!");
            throw;
        }
    }
    /// <summary>
    /// Считывает данные и присваивает их списку объектов типа StoresData
    /// </summary>
    /// <returns>список объектов типа StoresData</returns>
    public static List<StoresData> StartProgramm()
    {
        List<StoresData> list = new List<StoresData>();
        try
        {
            while (true)
            {
                list =  helperMethods.ReadDataFromConsoleOrFile();
                if (list.Count != 0)
                {
                    Console.WriteLine("Данные успешно прочитаны!");
                    return list;
                }
            }
        }
        catch 
        {
            Console.WriteLine("Ошибка!");
        }
        return null;
    }
}