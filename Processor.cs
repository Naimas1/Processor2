using System.Diagnostics;

namespace Processor2
{
    internal class Processor2
    {
        static void Main()
        {
            // Путь к исполняемому файлу дочернего процесса
            string childProcessPath = "Class1.cs";

            // Создание процесса для запуска дочернего процесса
            Process process = new Process();

            try
            {
                // Настройка запускаемого процесса
                process.StartInfo.FileName = childProcessPath;

                // Запуск дочернего процесса
                process.Start();

                Console.WriteLine("Дочерний процесс запущен.");

                // Запрос выбора пользователя
                Console.WriteLine("Введите '1', чтобы ожидать завершения дочернего процесса и отобразить код завершения.");
                Console.WriteLine("Введите '2', чтобы принудительно завершить работу дочернего процесса.");

                string userInput = Console.ReadLine();

                // В зависимости от выбора пользователя
                switch (userInput)
                {
                    case "1":
                        // Ожидание завершения дочернего процесса
                        process.WaitForExit();

                        // Получение кода завершения дочернего процесса
                        int exitCode = process.ExitCode;

                        // Вывод кода завершения
                        Console.WriteLine($"Код завершения дочернего процесса: {exitCode}");
                        break;
                    case "2":
                        // Принудительное завершение работы дочернего процесса
                        if (!process.HasExited)
                        {
                            process.Kill();
                            Console.WriteLine("Дочерний процесс принудительно завершен.");
                        }
                        else
                        {
                            Console.WriteLine("Дочерний процесс уже завершился.");
                        }
                        break;
                    default:
                        Console.WriteLine("Некорректный ввод.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при запуске/ожидании дочернего процесса: {ex.Message}");
            }
            finally
            {
                // Освобождение ресурсов процесса
                process.Dispose();
            }
        }
    }
}
