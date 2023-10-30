using System.Reflection;

namespace Lab_3
{
    public class Program
    {
        public static void Main()
        {
            Console.CursorVisible = false;

            List<MenuItem> items = new()
            {
                new MenuItem("Lab_3", "ListMethodsCaller", "ToString", "Текущее состояние списка"),
                new MenuItem("Lab_3", "ListMethodsCaller", "AddHead", "Добавить элемент в начало списка"),
                new MenuItem("Lab_3", "ListMethodsCaller", "AddTail", "Добавить элемент в конец списка"),
                new MenuItem("Lab_3", "ListMethodsCaller", "Reverse", "Перевернуть список"),
                new MenuItem("Lab_3", "ListMethodsCaller", "HeadToTail", "Перенести первый элемент списка в конец"),
                new MenuItem("Lab_3", "ListMethodsCaller", "TailToHead", "Перенести последний элемент списка в начало"),
                new MenuItem("Lab_3", "ListMethodsCaller", "Swap", "Поменять местами два заданных элемента"),
                new MenuItem("Lab_3", "ListMethodsCaller", "InsertBefore", "Вставить заданный элемент перед другим указанным элементом"),
                new MenuItem("Lab_3", "ListMethodsCaller", "InsertCopyAsTail", "Удвоить список"),
                new MenuItem("Lab_3", "ListMethodsCaller", "RemoveDuplicates", "Удалить все дубликаты"),
                new MenuItem("Lab_3", "ListMethodsCaller", "Remove", "Удалить все элементы с заданным значением"),
                new MenuItem("Lab_3", "ListMethodsCaller", "InsertCopyAfter", "ДЛЯ ЧИСЕЛ: Вставить копию списка после заданного числа"),
                new MenuItem("Lab_3", "ListMethodsCaller", "InsertInSortedInAcsOrderList", "ДЛЯ ЧИСЕЛ: Вставить элемент в отсортированный по неубыванию список"),
                new MenuItem("Lab_3", "ListMethodsCaller", "InsertAsTail", "ДЛЯ ЦЕЛЫХ ЧИСЕЛ: Добавить заданный список элементов к текущему"),
                new MenuItem("Lab_3", "ListMethodsCaller", "DistinctCount", "ДЛЯ ЦЕЛЫХ ЧИСЕЛ: Число различных элементов целочисленного списка"),
                new MenuItem("Lab_3", "ListMethodsCaller", "Split", "ДЛЯ ЦЕЛЫХ ЧИСЕЛ: Разбить список на два по заданному элементу " +
                                                                       "(Какой для дальнейшей работы - выбирать вам)"),
                new MenuItem("Lab_3", "ListMethodsCaller", "Exit", "ВЫХОД")
            };
            Menu menu = new(items)
            {
                Instance = new ListMethodCaller<int>(new LinkedList<int>())
            };
            menu.MoveThrough();
        }
    }
}