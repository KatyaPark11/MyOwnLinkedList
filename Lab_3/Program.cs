namespace Lab_3
{
    public class Program
    {
        /// <summary>
        /// Основное меню для управления двусвязным списком.
        /// </summary>
        public static Menu? ListMethodsMenu { get; private set; }

        /// <summary>
        /// Метод входа в программу.
        /// </summary>
        public static void Main()
        {
            Type dataType = ShowTheListTypeMenu();
            ShowTheListMethodsMenu(dataType);
        }

        /// <summary>
        /// Метод, отображающий меню выбора типа данных для списка.
        /// </summary>
        public static Type ShowTheListTypeMenu()
        {
            Console.CursorVisible = false;
            string header = "Выберите тип данных для своего списка:";
            List<MenuItem> listTypeMenuItems = new()
            {
                new MenuItem("Число с плавающей запятой"),
                new MenuItem("Число с плавающей запятой одинарной точности"),
                new MenuItem("Целое число"),
                new MenuItem("Целое длинное число"),
                new MenuItem("Строка")
            };
            Menu listTypeMenu = new(listTypeMenuItems);
            listTypeMenu.MoveThroughForSelect(header);

            MenuItem selectedItem = listTypeMenuItems[listTypeMenu.SelectedItemIndex];
            string typeName = TypeChecker.RusTypeSystemTypePairs[selectedItem.ItemMessage];
            Type dataType = Type.GetType(typeName);
            return dataType;
        }

        /// <summary>
        /// Метод, отображающий меню для управления двусвязным списком.
        /// </summary>
        /// <param name="dataType"></param>
        private static void ShowTheListMethodsMenu(Type dataType)
        {
            Console.CursorVisible = false;
            List<MenuItem> listMethodsMenuItems = new()
            {
                new MenuItem("Текущее состояние списка"),
                new MenuItem("Добавить элемент в начало списка"),
                new MenuItem("Добавить элемент в конец списка"),
                new MenuItem("Перевернуть список"),
                new MenuItem("Перенести первый элемент списка в конец"),
                new MenuItem("Перенести последний элемент списка в начало"),
                new MenuItem("Поменять местами два заданных элемента"),
                new MenuItem("Вставить заданный элемент перед другим указанным элементом"),
                new MenuItem("Удвоить список"),
                new MenuItem("Удалить все дубликаты"),
                new MenuItem("Удалить все элементы с заданным значением"),
                new MenuItem("ДЛЯ ЧИСЕЛ: Вставить копию списка после заданного числа"),
                new MenuItem("ДЛЯ ЧИСЕЛ: Вставить элемент в отсортированный по неубыванию список"),
                new MenuItem("ДЛЯ ЦЕЛЫХ ЧИСЕЛ: Добавить заданный список элементов к текущему"),
                new MenuItem("ДЛЯ ЦЕЛЫХ ЧИСЕЛ: Число различных элементов целочисленного списка"),
                new MenuItem("ДЛЯ ЦЕЛЫХ ЧИСЕЛ: Разбить список на два по заданному элементу (Какой для дальнейшей работы - выбирать вам)"),
                new MenuItem("СБРОСИТЬ ТЕКУЩИЙ СПИСОК"),
                new MenuItem("ВЫХОД")
            };

            List<string> methodNames = new()
            {
                "ToString", "AddHead", "AddTail", "Reverse", "HeadToTail", "TailToHead", "Swap", "InsertBefore",
                "InsertCopyAsTail", "RemoveDuplicates", "Remove", "InsertCopyAfter", "InsertInSortedInAcsOrderList",
                "InsertAsTail", "DistinctCount", "Split", "ResetTheList", "Exit"
            };

            for (int i = 0; i < listMethodsMenuItems.Count; i++)
            {
                listMethodsMenuItems[i].SetMethodInfo("Lab_3", "ListMethodsCaller", methodNames[i]);
            }

            object? list = Activator.CreateInstance(typeof(LinkedList<>).MakeGenericType(dataType));
            ListMethodsMenu = new(listMethodsMenuItems)
            {
                Instance = Activator.CreateInstance(typeof(ListMethodCaller<>).MakeGenericType(dataType), list)
            };
            ListMethodsMenu.InfiniteMoveThrough();
        }
    }
}