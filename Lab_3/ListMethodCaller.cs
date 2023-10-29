using System.ComponentModel;
using static Lab_3.TypeChecker;

namespace Lab_3
{
    public class ListMethodCaller<T>
    {
        private readonly LinkedList<T> list;

        public ListMethodCaller(LinkedList<T> list)
        {
            this.list = list;
        }

        public void ToString()
        {
            if (list.Count != 0)
                Console.WriteLine($"Ваш список выглядит как-то так: {list}");
            else
                Console.WriteLine("Вы не увидите здесь своего списка... Но это не мы виноваты!" +
                    " Просто он неотразим (пустой, получается).");
        }

        public void AddHead()
        {
            bool isCorrectVal = false;
            while (isCorrectVal != true)
            {
                Console.Write("Введите значение нового головастика списка: ");
                Console.CursorVisible = true;
                string newDataStr = Console.ReadLine();
                Console.CursorVisible = false;
                ConsoleHelper.ClearScreen();

                if (!ListMethodCaller<T>.CheckTheType(newDataStr, out T newData))
                {
                    ConsoleHelper.ClearScreen();
                    continue;
                }
                list.AddHead(newData);
                Console.WriteLine($"Лучше и быть не может: {list}. Вам же нравится, правда?");
                break;
            }
        }

        public void AddTail()
        {
            bool isCorrectVal = false;
            while (isCorrectVal != true)
            {
                Console.Write("Введите значение нового хвостика списка: ");
                Console.CursorVisible = true;
                string newDataStr = Console.ReadLine();
                Console.CursorVisible = false;
                ConsoleHelper.ClearScreen();

                if (!ListMethodCaller<T>.CheckTheType(newDataStr, out T newData))
                {
                    ConsoleHelper.ClearScreen();
                    continue;
                }
                list.AddTail(newData);
                Console.WriteLine($"А у нас пополнение! Только взгляните на эту счастливую семью: {list}");
                break;
            }
        }

        public void Reverse()
        {
            if (list.Count <= 1)
            {
                Console.WriteLine("Извините, а что тут, собственно, переворачивать? Мы жаждем больше элементов!");
            }
            else
            {
                list.Reverse();
                Console.WriteLine($"Красивое, не правда ли: {list}");
            }
        }

        public void HeadToTail()
        {
            if (list.Count <= 1)
            {
                Console.WriteLine("А переносить-то и нечего! Добавьте элементиков - получите результат.");
            }
            else
            {
                list.HeadToTail();
                Console.WriteLine($"Не знаем, зачем вам это, но держите: {list}");
            }
        }

        public void TailToHead()
        {
            if (list.Count <= 1)
            {
                Console.WriteLine("Сейчас-сейчас... А, ой! Вот то что вы пытаетесь сделать, вот это и невозможно... Мало элементов помоту что!");
            }
            else
            {
                list.TailToHead();
                Console.WriteLine($"Вот ваш заказ, держите и радуйтесь: {list}");
            }
        }

        public void DistinctCount()
        {
            if (!IsIntegerType(typeof(T)))
            {
                Console.WriteLine("Принимаем только целочисленные списки для этого метода!\n" +
                    "Поменяйте списочек на тот, что с другим типом, если хотите увидеть что-то интересненькое.");
            }
            else if (list.Count == 0)
            {
                Console.WriteLine("Этот список был слишком пустым внутри... Может, сам по себе он и уникален, но только не его элементы.");
            }
            else
            {
                Console.WriteLine($"Интересный факт, который вам нужно знать: уникального в вашем списке ровно {list.DistinctCount()}");
            }
        }

        public void RemoveDuplicates()
        {
            if (list.Count <= 1)
            {
                Console.WriteLine("Прочитайте запрос внимательно. Там же прямо написано: \"Удалить все дубликаты\".\n" +
                    "Ну какие дубликаты могут быть в вашем масеньком списке?");
            }
            else
            {
                list.RemoveDuplicates();
                Console.WriteLine($"Того, чего вы так боялись, больше нет. Взгляните: {list}");
            }
        }

        private static bool CheckTheType(string data, out T result)
        {
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(T));
            try
            {
                result = (T)converter.ConvertFrom(data);
                return true;
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Упс... Введённое значение не соответствует типу элементов списка.\n" +
                    "Попробуйте снова, на этот раз грехом будет ошибиться!");
                Console.ReadKey();
                result = default;
                return false;
            }
        }

        /// <summary>
        /// Метод выхода из программы.
        /// </summary>
        public void Exit()
        {
            Environment.Exit(0);
        }
    }
}
