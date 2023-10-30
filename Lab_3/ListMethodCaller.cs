using System.ComponentModel;
using static Lab_3.TypeChecker;

namespace Lab_3
{
    public class ListMethodCaller<T>
    {
        private LinkedList<T>? list;

        public ListMethodCaller(LinkedList<T>? list)
        {
            this.list = list;
        }

        public new void ToString()
        {
            if (list.Count != 0)
                Console.WriteLine($"Ваш список выглядит как-то так: {list}");
            else
                Console.WriteLine("Вы не увидите здесь своего списка... Но это не мы виноваты!" +
                    " Просто он неотразим (пустой, получается).");
        }

        public void AddHead()
        {
            while (true)
            {
                ConsoleHelper.ClearScreen();
                Console.Write("Введите значение нового головастика списка: ");
                if (!EnterOneData(out T newData)) continue;

                list.AddHead(newData);
                Console.WriteLine($"Лучше и быть не может: {list}. Вам же нравится, правда?");
                break;
            }
        }

        public void AddTail()
        {
            while (true)
            {
                ConsoleHelper.ClearScreen();
                Console.Write("Введите значение нового хвостика списка: ");
                if (!EnterOneData(out T newData)) continue;

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

        public void Swap()
        {
            if (list.Count <= 1 || list.DistinctCount() == 1)
            {
                Console.WriteLine("Мы не работаем со списками, где недостаточно уникальных элементов! Ну вот что, скажите, тут можно поменять?");
                return;
            }

            while (true)
            {
                ConsoleHelper.ClearScreen();
                Console.Write("Введите два переменчивых значения через ПРОБЕЛЬЧИК.\n" +
                    "Если для значения необходимы пробелы, замените их на значок доллара $: ");
                string errorMessage = "Мы слишком глупенькие, чтобы воспринимать то, что вы написали. Пожалуйста, следуйте условиям.";
                if (!EnterTwoData(errorMessage, out T? data1, out T? data2)) continue;

                if (data1.Equals(data2))
                {
                    Console.WriteLine("Наташ, они одинаковые! Введите что-то нормальное, пожалуйста, иначе мы вас не отпустим.");
                    Console.ReadKey();
                    continue;
                }
                list.Swap(data1, data2);
                Console.WriteLine($"Обмен совершён. Надеемся, это была выгодная сделка: {list}");
                break;
            }
        }

        public void InsertBefore()
        {
            if (list.Count == 0)
            {
                Console.WriteLine("Список пустует... Как в нём можно найти хоть какой-то элемент?");
                return;
            }

            while (true)
            {
                ConsoleHelper.ClearScreen();
                Console.Write("Введите два значения через ПРОБЕЛЬЧИК. Первое - значение вставляемого элемента,\n" +
                    "второе - до которого совершается вставка.\n" +
                    "Если для значения необходимы пробелы, замените их на значок доллара $: ");
                string errorMessage = "Что-то написано не так... Перечитайте условия работы данного метода.";
                if (!EnterTwoData(errorMessage, out T? insertData, out T? requiredData)) continue;

                list.InsertBefore(insertData, requiredData);
                Console.WriteLine($"Мы сделали всё, что могли... Но не то чтобы вы ожидали от нас чего-то большего: {list}");
                break;
            }
        }

        public void InsertCopyAsTail()
        {
            if (list.Count == 0)
            {
                Console.WriteLine("Копия пустого списка, конечно, звучит заманчиво, но мы на это не поведёмся!");
                return;
            }
            else
            {
                list.InsertCopyAsTail();
                Console.WriteLine($"Поздравляем, у вас близняшки: {list}");
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

        public void Remove()
        {
            if (list.Count == 0)
            {
                Console.WriteLine("Ну допустим мы можем удалить воздух из этого списка, но элементов-то нет, удалять-то больше нечего.");
                return;
            }

            while (true)
            {
                ConsoleHelper.ClearScreen();
                Console.Write("Введите значение удаляемого элементика списка: ");
                if (!EnterOneData(out T removeData)) continue;

                list.Remove(removeData);
                Console.WriteLine($"Вы видите это страшненькое значение в списке: {list}? Вот и мы не видим. И его нет.");
                break;
            }
        }

        public void InsertCopyAfter()
        {
            if (!IsIntegerType(typeof(T)))
            {
                Console.WriteLine("Этому методу нужен новый герой! То есть, другие типы данных списка.");
                return;
            }
            else if (list.Count == 0)
            {
                Console.WriteLine("Какое бы значение вы не указали, всё будет тщетно... Вам когда-нибудь говорили про то, что пустой список пуст?");
                return;
            }

            while (true)
            {
                ConsoleHelper.ClearScreen();
                Console.Write("Введите значение-указатель (Вы же в курсе, что оно должно быть в списке?): ");
                if (!EnterOneData(out T newData)) continue;

                list.InsertCopyAfter(newData);
                Console.WriteLine($"Вот такая магия произошла: {list}.\n" +
                    $"Говорят, если не знать, что делает этот метод, можно в попытках разгадать его тайну сломать мозг.");
                break;
            }
        }

        public void InsertInSortedInAcsOrderList()
        {
            if (!IsNumericType(typeof(T)))
            {
                Console.WriteLine("Извините, мы не знаем, как это всё сравнивать... Укажите целочисленный тип данных для своего списка.");
                return;
            }
            else if (!list.IsSortedInAcsendingOrder())
            {
                Console.WriteLine("Перечитываем название метода... Ага-а... А вы уверены, что ваш список отсортирован по неубыванию?");
                return;
            }
            else if (list.Count == 0)
            {
                Console.WriteLine("Списочек пустует, а этого быть не должно! Добавьте хотя бы один элементик.");
                return;
            }

            while (true)
            {
                ConsoleHelper.ClearScreen();
                Console.Write("Введите значение для его добавления в какое-то местечко среди элементов: ");
                if (!EnterOneData(out T newData)) continue;

                list.InsertInSortedInAcsOrderList(newData);
                Console.WriteLine($"Новый элементик уже в строю: {list}. Уверены, он справится со своей службой!");
                break;
            }
        }

        public void InsertAsTail()
        {
            if (!IsIntegerType(typeof(T)))
            {
                Console.WriteLine("Капс был единственным нашим оружием... И оно не помогло...");
                return;
            }

            while (true)
            {
                ConsoleHelper.ClearScreen();
                Console.Write("Введите значения добавляемого в качестве хвостика списка через ПРОБЕЛЬЧИК.\n" +
                    "Если для значения необходимы пробелы, замените их на значок доллара $: ");
                if (!EnterListData(out LinkedList<T>? newList)) continue;

                list.InsertAsTail(newList);
                Console.WriteLine($"Новый элементик уже в строю: {list}. Уверены, он справится со своей службой!");
                break;
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

        public void Split()
        {
            if (!IsIntegerType(typeof(T)))
            {
                Console.WriteLine("ДЛЯ ЦЕЛЫХ ЧИСЕЛ! Да-да, там было написано именно так.");
                return;
            }
            else if (list.Count == 0)
            {
                Console.WriteLine("А вы знали, что в пустом списке нечего делить?");
                return;
            }

            while (true)
            {
                ConsoleHelper.ClearScreen();
                Console.Write("Введите значение элемента, который мощно разорвёт этот список на две части: ");
                if (!EnterOneData(out T splitData)) continue;

                LinkedList<T>? leftList = list;
                LinkedList<T>? rightList = list.Split(splitData);
                ChooseBetweenTwo(leftList, rightList);
                break;
            }
        }

        private static bool CheckTheType(string? data, out T? result)
        {
            if (typeof(T).FullName == "System.Single" || typeof(T).FullName == "System.Double")
                data = data.Replace('.', ',');

            TypeConverter converter = TypeDescriptor.GetConverter(typeof(T));
            try
            {
                result = (T?)converter.ConvertFrom(data);
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

        private static bool EnterOneData(out T data)
        {
            Console.CursorVisible = true;
            string? dataStr = Console.ReadLine();
            Console.CursorVisible = false;
            ConsoleHelper.ClearScreen();

            if (!ListMethodCaller<T>.CheckTheType(dataStr, out data))
            {
                data = default;
                return false;
            }
            return true;
        }

        private static bool EnterTwoData(string errorMessage, out T? firstData, out T? secondData)
        {
            Console.CursorVisible = true;
            string? dataStr = Console.ReadLine();
            Console.CursorVisible = false;
            ConsoleHelper.ClearScreen();

            string[] dataArr = dataStr.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (dataArr.Length != 2)
            {
                Console.WriteLine(errorMessage);
                Console.ReadKey();
                firstData = default;
                secondData = default;
                return false;
            }

            dataArr[0] = dataArr[0].Replace('$', ' ');
            dataArr[1] = dataArr[1].Replace('$', ' ');

            if (!ListMethodCaller<T>.CheckTheType(dataArr[0], out firstData) ||
                !ListMethodCaller<T>.CheckTheType(dataArr[1], out secondData))
            {
                firstData = default;
                secondData = default;
                return false;
            }

            return true;
        }

        private static bool EnterListData(out LinkedList<T>? list)
        {
            Console.CursorVisible = true;
            string? listStr = Console.ReadLine();
            Console.CursorVisible = false;
            ConsoleHelper.ClearScreen();

            string[] dataArr = listStr.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            list = new LinkedList<T>();

            for (int i = 0; i < dataArr.Length; i++)
            {
                dataArr[i] = dataArr[i].Replace('$', ' ');
                if (!ListMethodCaller<T>.CheckTheType(dataArr[i], out T? data))
                {
                    list = default;
                    return false;
                }
                else
                {
                    list.AddTail(data);
                }
            }

            return true;
        }

        private void ChooseBetweenTwo(LinkedList<T>? firstList, LinkedList<T>? secondList)
        {
            while (true)
            {
                ConsoleHelper.ClearScreen();
                Console.WriteLine($"Итак, теперь у нас есть два списочка. Первый би лайк: {firstList}. Второй: {secondList}\n" +
                    $"Выбирайте списочек, с которым хотите работать нажатием на циферку 1 или 2 соответственно.");
                ConsoleKeyInfo keyInfo = Console.ReadKey();

                if (keyInfo.Key == ConsoleKey.NumPad1 || keyInfo.Key == ConsoleKey.D1)
                {
                    list = firstList;
                }
                else if (keyInfo.Key == ConsoleKey.NumPad2 || keyInfo.Key == ConsoleKey.D2)
                {
                    list = secondList;
                }
                else
                {
                    Console.WriteLine("Кажется, вы нажали не ту кнопочку... Попробуйте ещё раз");
                    continue;
                }

                ConsoleHelper.ClearScreen();
                Console.WriteLine($"Вам удалось нажать верную кнопку! А потому ваш текущий список теперь выглядит вот так: {list}");
                break;
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
