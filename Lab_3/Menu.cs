using System.Reflection;
using System.Xml.Linq;

namespace Lab_3
{
    /// <summary>
    /// Класс реализации меню.
    /// </summary>
    public class Menu
    {
        /// <summary>
        /// Индекс выбранного элемента.
        /// </summary>
        public int SelectedItemIndex { get; set; }

        /// <summary>
        /// Элементы, содержащиеся в меню.
        /// </summary>
        public List<MenuItem> Items { get; private set; }

        /// <summary>
        /// Экземпляр необходимого класса для работы с ним.
        /// </summary>
        public object Instance { get; set; }

        public Menu(List<MenuItem> items)
        {
            Items = items;
            SelectedItemIndex = 0;
        }

        /// <summary>
        /// Метод, отслеживающий нажатие клавиши для передвижения по меню.
        /// </summary>
        public void MoveThrough()
        {
            while (true)
            {
                ConsoleHelper.ClearScreen();
                Show();
                ConsoleKeyInfo pressedKey = Console.ReadKey();
                switch (pressedKey.Key)
                {
                    case ConsoleKey.DownArrow:
                        if (SelectedItemIndex == Items.Count - 1)
                            SelectedItemIndex = 0;
                        else
                            SelectedItemIndex++;
                        break;
                    case ConsoleKey.UpArrow:
                        if (SelectedItemIndex == 0)
                            SelectedItemIndex = Items.Count - 1;
                        else
                            SelectedItemIndex--;
                        break;
                    case ConsoleKey.Enter:
                        ConsoleHelper.ClearScreen();
                        Execute();
                        ConsoleHelper.ClearScreen();
                        break;
                }
            }
        }

        /// <summary>
        /// Метод, выполняющий операцию с заданным объектом.
        /// </summary>
        private void Execute()
        {
            MenuItem selectedItem = Items[SelectedItemIndex];
            string methodName = selectedItem.ItemMethodName;
            MethodInfo methodInfo = Instance.GetType().GetMethod(methodName);
            methodInfo.Invoke(Instance, null);
            Console.ReadKey();
        }

        /// <summary>
        /// Метод, отображающий меню в консоли.
        /// </summary>
        private void Show()
        {
            if (Items.Count > 0)
            {
                for (int i = 0; i < Items.Count; i++)
                {
                    if (i == SelectedItemIndex)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine(Items[i].ItemMessage);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.WriteLine(Items[i].ItemMessage);
                    }
                }
            }
        }
    }
}
