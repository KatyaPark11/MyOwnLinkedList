using static Lab_3.TypeChecker;

namespace Lab_3
{
    public class LinkedList<T>
    {
        /// <summary>
        /// Первый добавленный элемент списка.
        /// </summary>
        private Node<T> head;
        /// <summary>
        /// Последний добавленный элемент списка.
        /// </summary>
        private Node<T> tail;

        /// <summary>
        /// Число элементов в списке.
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Метод, проверяющий наличие элемента с указанным значением в списке.
        /// </summary>
        /// <param name="data">Искомое значение.</param>
        /// <returns></returns>
        public int Contains(T data)
        {
            if (head == null) return -1;
            Node<T> currentNode = head;
            for (int i = 0; i < Count; i++)
            {
                if (currentNode.Data == null) continue;
                if (currentNode.Data.Equals(data))
                    return i;
                currentNode = currentNode.Next;
            }
            return -1;
        }

        /// <summary>
        /// Метод, добавляющий новый элемент в начало списка.
        /// </summary>
        /// <param name="data">Значение добавляемого элемента.</param>
        public void AddHead(T data)
        {
            Node<T> newNode = new(data);
            AddHead(newNode);
        }

        /// <summary>
        /// Метод, добавляющий элемент в начало списка.
        /// </summary>
        /// <param name="node">Добавляемый элемент.</param>
        private void AddHead(Node<T> node)
        {
            if (head == null)
            {
                head = node;
                tail = node;
            }
            else
            {
                node.Next = head;
                head.Previous = node;
                head = node;
            }

            Count++;
        }

        /// <summary>
        /// Метод, добавляющий новый элемент в конец списка.
        /// </summary>
        /// <param name="data">Значение добавляемого элемента.</param>
        public void AddTail(T data)
        {
            Node<T> newNode = new(data);
            AddTail(newNode);
        }

        /// <summary>
        /// Метод, добавляющий элемент в конец списка.
        /// </summary>
        /// <param name="node">Добавляемый элемент.</param>
        private void AddTail(Node<T> node)
        {
            if (tail == null)
            {
                head = node;
                tail = node;
            }
            else
            {
                node.Previous = tail;
                tail.Next = node;
                tail = node;
            }

            Count++;
        }

        /// <summary>
        /// Метод, удаляющий первый элемент в списке.
        /// </summary>
        private void RemoveHead()
        {
            if (head == null) return;

            head = head.Next;
            head.Previous = null;
            Count--;
        }

        /// <summary>
        /// Метод, удаляющий последний элемент в списке.
        /// </summary>
        private void RemoveTail()
        {
            if (tail == null) return;

            tail = tail.Previous;
            tail.Next = null;
            Count--;
        }

        /// <summary>
        /// Метод, удаляющий элементы со значением указанного узла, начиная с него.
        /// </summary>
        /// <param name="startNode">Узел со значением для удаления.</param>
        public void RemoveNodes(Node<T> startNode)
        {
            Node<T> current = startNode;
            T removeData = current.Data;
            while (current != null)
            {
                if (current.Data.Equals(removeData))
                {
                    if (current.Previous != null)
                    {
                        current.Previous.Next = current.Next;
                    }
                    else
                    {
                        head = current.Next;
                        head.Previous = null;
                    }

                    if (current.Next != null)
                    {
                        current.Next.Previous = current.Previous;
                    }
                    else
                    {
                        tail = current.Previous;
                        tail.Next = null;
                    }

                    Count--;
                }
                current = current.Next;
            }
        }

        /// <summary>
        /// Метод, разворачивающий элементы в списке.
        /// </summary>
        public void Reverse()
        {
            Node<T> current = head;
            Node<T> temp = null;

            while (current != null)
            {
                temp = current.Previous;
                current.Previous = current.Next;
                current.Next = temp;

                current = current.Previous;
            }

            temp = head;
            head = tail;
            tail = temp;
        }

        /// <summary>
        /// Метод, переносящий первый элемент в конец.
        /// </summary>
        public void HeadToTail()
        {
            if (head == null || Count == 1) return;

            AddTail(head);
            RemoveHead();
            tail.Next = null;
        }

        /// <summary>
        /// Метод, переносящий последний элемент в начало.
        /// </summary>
        public void TailToHead()
        {
            if (tail == null || Count == 1) return;

            AddHead(tail);
            RemoveTail();
            head.Previous = null;
        }

        /// <summary>
        /// Метод, возвращающий число различных элементов списка, содержащего целые числа.
        /// </summary>
        public int DistinctCount()
        {
            if (!IsIntegerType(typeof(T)))
            {
                Console.WriteLine("Этот метод используется только для целочисленного списка.");
                return 0;
            }
            if (head == null) return 0;

            LinkedList<T> distinctVarsList = new();
            Node<T> currentNode = head;
            while (currentNode != null)
            {
                if (distinctVarsList.Contains(currentNode.Data) != -1)
                {
                    currentNode = currentNode.Next;
                    continue;
                }
                distinctVarsList.AddTail(currentNode.Data);
            }
            return distinctVarsList.Count;
        }

        /// <summary>
        /// Метод, удаляющий дублирующиеся элементы.
        /// </summary>
        public void RemoveDuplicates()
        {
            if (head == null || Count == 1) return;

            Node<T> current = head;
            while (current != null)
            {
                T data = current.Data;
                Node<T> nextCurrent = current.Next;

                while (nextCurrent != null)
                {
                    if (nextCurrent.Data.Equals(data))
                    {
                        RemoveNodes(current);
                        if (nextCurrent == current.Next)
                            current = current.Next;
                        break;
                    }
                    nextCurrent = nextCurrent.Next;
                }

                current = current.Next;
            }
        }

        /// <summary>
        /// Метод, возвращающий копию списка.
        /// </summary>
        public LinkedList<T> Copy()
        {
            LinkedList<T> newList = new LinkedList<T>();
            Node<T> currentNode = head;
            while (currentNode != null)
            {
                newList.AddTail(currentNode.Data);
                currentNode = currentNode.Next;
            }
            return newList;
        }

        /// <summary>
        /// Метод, вставляющий копию всего списка после первого вхождения указанного значения элемента.
        /// </summary>
        /// <param name="x">Значение элемента, после которого требуется вставка копии списка.</param>
        public void InsertAfter(T x)
        {
            if (!IsNumericType(typeof(T)))
            {
                Console.WriteLine("Этот метод используется только для списка с числовыми значениями.");
                return;
            }
            if (head == null) return;

            Node<T> currentNode = head;
            while (currentNode != null)
            {
                if (currentNode.Data.Equals(x))
                {
                    LinkedList<T> insertList = Copy();
                    if (tail != currentNode)
                    {
                        currentNode.Next.Previous = insertList.tail;
                        insertList.tail.Next = currentNode.Next;
                    }
                    else
                    {
                        tail = insertList.tail;
                    }
                    currentNode.Next = insertList.head;
                    insertList.head.Previous = currentNode;
                    Count *= 2;
                    return;
                }
                currentNode = currentNode.Next;
            }
        }
    }
}