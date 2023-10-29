using System.Reflection;

namespace Lab_3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.CursorVisible = false;

            List<MenuItem> items = new()
            {
                new MenuItem("Lab_3", "LinkedList", "ToString", "Текущее состояние списка"),
                new MenuItem("Lab_3", "LinkedList", "ToString", "Перевернуть список"),
                new MenuItem("Lab_3", "LinkedList", "ToString", "Перенести первый элемент списка в начало"),
                new MenuItem("Lab_3", "LinkedList", "ToString", "Перенести последний элемент списка в конец"),
                new MenuItem("Lab_3", "LinkedList", "ToString", "Число различных элементов целочисленного списка"),
                new MenuItem("Lab_3", "LinkedList", "ToString", "Удалить все дубликаты"),
                new MenuItem("Lab_3", "LinkedList", "ToString", "Вставить копию списка после заданного числа"),
                new MenuItem("Lab_3", "LinkedList", "ToString", "Вставить элемент в отсортированный по неубыванию список"),
                new MenuItem("Lab_3", "LinkedList", "ToString", ""),
                new MenuItem("Lab_3", "LinkedList", "ToString", ""),
                new MenuItem("Lab_3", "LinkedList", "ToString", ""),
                new MenuItem("Lab_3", "LinkedList", "ToString", ""),
                new MenuItem("Lab_3", "LinkedList", "ToString", ""),
            };
            Menu menu = new Menu(items);

            menu.Instance = new LinkedList<int>();
            menu.MoveThrough();
        }
    }
}