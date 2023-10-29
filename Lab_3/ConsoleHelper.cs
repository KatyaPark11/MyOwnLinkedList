namespace Lab_3
{
    /// <summary>
    /// Класс для выполнения операций с консолью.
    /// </summary>
    public class ConsoleHelper
    {
        /// <summary>
        /// Метод очистки экрана.
        /// </summary>
        public static void ClearScreen()
        {
            for (int i = 0; i < Console.WindowHeight; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write(new string(' ', Console.WindowWidth));
            }

            Console.SetCursorPosition(0, 0);
        }
    }
}
