namespace Lab_3
{
    /// <summary>
    /// Элемент двусвязного списка.
    /// </summary>
    /// <typeparam name="T">Любой желаемый тип данных элемента.</typeparam>
    public class Node<T>
    {
        /// <summary>
        /// Значение элемента.
        /// </summary>
        public T Data { get; set; }
        /// <summary>
        /// Ссылка на следующий за текущим элементом узел.
        /// </summary>
        public Node<T>? Next { get; set; }
        /// <summary>
        /// Ссылка на предыдущий узел.
        /// </summary>
        public Node<T>? Previous { get; set; }

        public Node(T data)
        {
            Data = data;
        }
    }
}
