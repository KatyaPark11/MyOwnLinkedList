namespace Lab_3
{
    /// <summary>
    /// Класс реализации элемента меню.
    /// </summary>
    public class MenuItem
    {
        /// <summary>
        /// Пространство используемого метода, соответствующего данному элементу.
        /// </summary>
        public string ItemNamespace { get; private set; }
        /// <summary>
        /// Имя класса используемого метода, соответствующего данному элементу.
        /// </summary>
        public string ItemClassName { get; private set; }
        /// <summary>
        /// Имя метода, соответствующего данному элементу.
        /// </summary>
        public string ItemMethodName { get; private set; }
        /// <summary>
        /// Надпись, информирующая о том, что происходит в методе, соответствующем данному элементу.
        /// </summary>
        public string ItemMessage { get; private set; }
        /// <summary>
        /// Флаг для определения того, выбран ли элемент в данный момент.
        /// </summary>
        public bool IsSelected { get; set; }

        public MenuItem(string itemNamespace, string itemClassName, string itemMethodName, string itemMessage)
        {
            ItemNamespace = itemNamespace;
            ItemClassName = itemClassName;
            ItemMethodName = itemMethodName;
            ItemMessage = itemMessage;
        }

    }
}
