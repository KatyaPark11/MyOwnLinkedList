using System.Text;
using static Lab_3.TypeChecker;

namespace Lab_3
{
    /// <summary>
    /// Класс реализации двусвязного списка.
    /// </summary>
    /// <typeparam name="T">Тип данных в списке.</typeparam>
    public class LinkedList<T>
    {
        /// <summary>
        /// Первый добавленный элемент списка.
        /// </summary>
        public Node<T>? head;
        /// <summary>
        /// Последний добавленный элемент списка.
        /// </summary>
        public Node<T>? tail;

        /// <summary>
        /// Число элементов в списке.
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Метод, возвращающий число элементов до узла с заданным значением.
        /// </summary>
        /// <param name="item">Значение ограничивающего элемента.</param>
        private int CountUntil(T? item)
        {
            int count = 0;
            Node<T>? currentNode = head;
            while (currentNode != null)
            {
                if (currentNode.Data.Equals(item))
                {
                    return count;
                }
                count++;
                currentNode = currentNode.Next;
            }
            return count;
        }

        /// <summary>
        /// Метод, возвращающий число различных элементов списка, содержащего целые числа.
        /// </summary>
        public int DistinctCount()
        {
            LinkedList<T>? distinctVarsList = new();
            Node<T>? currentNode = head;
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
        /// Метод, возвращающий список в строковом формате.
        /// </summary>
        override public string ToString()
        {
            StringBuilder listStr = new();
            
            Node<T>? currentNode = head;
            while (currentNode != null)
            {
                if (currentNode.Next == null)
                {
                    listStr.Append(currentNode.Data.ToString());
                    break;
                }
                listStr.Append(currentNode.Data.ToString() + ", ");
                currentNode = currentNode.Next;
            }
            return listStr.ToString();
        }

        /// <summary>
        /// Метод, проверяющий наличие элемента с указанным значением в списке.
        /// </summary>
        /// <param name="data">Искомое значение.</param>
        public int Contains(T? data)
        {
            if (Count == 0) return -1;

            Node<T>? currentNode = head;
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
        /// Метод, возвращающий копию списка.
        /// </summary>
        public LinkedList<T>? Copy()
        {
            LinkedList<T>? newList = new();
            Node<T>? currentNode = head;
            while (currentNode != null)
            {
                newList.AddTail(currentNode.Data);
                currentNode = currentNode.Next;
            }
            return newList;
        }

        /// <summary>
        /// Метод, проверяющий, является ли список отсортированным по неубыванию.
        /// </summary>
        public bool IsSortedInAcsendingOrder()
        {
            if (head == null || Count == 1) return true;

            Node<T>? currentNode = head.Next;
            while (currentNode != null)
            {
                double currentData = double.Parse(currentNode.Data.ToString());
                double previousData = double.Parse(currentNode.Previous.Data.ToString());
                if (currentData < previousData)
                    return false;
                currentNode = currentNode.Next;
            }
            return true;
        }

        /// <summary>
        /// Метод, добавляющий новый элемент в начало списка.
        /// </summary>
        /// <param name="data">Значение добавляемого элемента.</param>
        public void AddHead(T? data)
        {
            Node<T>? newNode = new(data);
            AddHead(newNode);
        }

        /// <summary>
        /// Метод, добавляющий элемент в начало списка.
        /// </summary>
        /// <param name="node">Добавляемый элемент.</param>
        private void AddHead(Node<T>? node)
        {
            if (Count == 0)
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
        public void AddTail(T? data)
        {
            Node<T>? newNode = new(data);
            AddTail(newNode);
        }

        /// <summary>
        /// Метод, добавляющий элемент в конец списка.
        /// </summary>
        /// <param name="node">Добавляемый элемент.</param>
        private void AddTail(Node<T>? node)
        {
            if (Count == 0)
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
        /// Метод, вставляющий заданный список после указанного узла.
        /// </summary>
        /// <param name="insertList">Вставляемый список.</param>
        /// <param name="node">Узел для обозначения места вставки.</param>
        private void Insert(LinkedList<T>? insertList, Node<T>? node)
        {
            if (head == null)
            {
                head = insertList.head;
                tail = insertList.tail;
                Count = insertList.Count;
                return;
            }

            if (tail != node)
            {
                node.Next.Previous = insertList.tail;
                insertList.tail.Next = node.Next;
            }
            else
            {
                tail = insertList.tail;
            }
            node.Next = insertList.head;
            insertList.head.Previous = node;
            Count += insertList.Count;
        }

        /// <summary>
        /// Метод, вставляющий заданное значение после указанного узла.
        /// </summary>
        /// <param name="insertData">Значение вставляемого элемента.</param>
        /// <param name="node">Узел для обозначения места вставки.</param>
        private void Insert(T? insertData, Node<T>? node)
        {
            if (node == null) node = head;

            Node<T>? insertNode = new(insertData);
            if (tail != node)
            {
                node.Next.Previous = insertNode;
                insertNode.Next = node.Next;
            }
            else
            {
                tail = insertNode;
            }
            node.Next = insertNode;
            insertNode.Previous = node;
            Count++;
        }

        /// <summary>
        /// Метод, вставляющий копию всего списка после первого вхождения указанного значения элемента.
        /// </summary>
        /// <param name="data">Значение элемента, после которого требуется вставка копии списка.</param>
        public void InsertCopyAfter(T? data)
        {
            Node<T>? currentNode = head;
            while (currentNode != null)
            {
                if (currentNode.Data.Equals(data))
                {
                    LinkedList<T>? insertList = Copy();
                    Insert(insertList, currentNode);
                    return;
                }
                currentNode = currentNode.Next;
            }
        }

        /// <summary>
        /// Метод, вставляющий в конец существующего списка другой.
        /// </summary>
        /// <param name="insertList">Вставляемый в конец список.</param>
        public void InsertAsTail(LinkedList<T>? insertList)
        {
            LinkedList<T>? copyOfInsList = insertList.Copy();
            Insert(copyOfInsList, tail);
        }

        /// <summary>
        /// Метод, вставляющий в конец списка его копию.
        /// </summary>
        public void InsertCopyAsTail()
        {
            LinkedList<T>? copyOfList = Copy();
            Insert(copyOfList, tail);
        }

        /// <summary>
        /// Метод, добавляющий в отсортированный по неубыванию список указанный элемент без нарушения сортировки.
        /// </summary>
        /// <param name="data">Значение добавляемого элемента.</param>
        public void InsertInSortedInAcsOrderList(T? data)
        {
            double insertData = double.Parse(data.ToString());
            Node<T>? currentNode = head;
            while (currentNode != null)
            {
                double currentData = double.Parse(currentNode.Data.ToString());
                if (insertData < currentData)
                {
                    Insert(data, currentNode.Previous);
                    return;
                }
                currentNode = currentNode.Next;
            }
            Insert(data, tail);
        }

        /// <summary>
        /// Метод, вставляющий элемент с указанным значением перед первым вхождения элемента с заданным значением.
        /// </summary>
        /// <param name="insertData">Значение вставляемого элемента.</param>
        /// <param name="requiredData">Значение элемента, после которого требуется вставка элемента с указанным значением.</param>
        public void InsertBefore(T? insertData, T? requiredData)
        {
            Node<T>? currentNode = head;
            while (currentNode != null)
            {
                if (currentNode.Data.Equals(requiredData))
                {
                    Insert(insertData, currentNode.Previous);
                    return;
                }
                currentNode = currentNode.Next;
            }
        }

        /// <summary>
        /// Метод, удаляющий первый элемент в списке.
        /// </summary>
        public void RemoveHead()
        {
            if (Count == 0) return;

            head = head.Next;
            head.Previous = null;
            Count--;
        }

        /// <summary>
        /// Метод, удаляющий последний элемент в списке.
        /// </summary>
        public void RemoveTail()
        {
            if (Count == 0) return;

            tail = tail.Previous;
            tail.Next = null;
            Count--;
        }

        /// <summary>
        /// Метод, удаляющий указанный узел из списка.
        /// </summary>
        /// <param name="node">Узел, который надо удалить.</param>
        private void Remove(Node<T>? node)
        {
            if (Count == 1)
            {
                head = null;
                tail = null;
                Count--;
                return;
            }

            if (node.Previous != null)
            {
                node.Previous.Next = node.Next;
            }
            else
            {
                head = node.Next;
                head.Previous = null;
            }

            if (node.Next != null)
            {
                node.Next.Previous = node.Previous;
            }
            else
            {
                tail = node.Previous;
                tail.Next = null;
            }

            Count--;
        }

        /// <summary>
        /// Метод, удаляющий элементы со значением указанного узла, начиная с него.
        /// </summary>
        /// <param name="startNode">Узел со значением для удаления.</param>
        private void RemoveWith(Node<T>? startNode)
        {
            Node<T>? current = startNode;
            T removeData = current.Data;
            while (current != null)
            {
                if (current.Data.Equals(removeData))
                {
                    Remove(current);
                }
                current = current.Next;
            }
        }

        /// <summary>
        /// Метод, удаляющий элементы со указанным значением.
        /// </summary>
        /// <param name="removeData">Значение, элементы с которым должны быть удалены.</param>
        public void Remove(T? removeData)
        {
            Node<T>? current = head;
            while (current != null)
            {
                if (current.Data.Equals(removeData))
                {
                    Remove(current);
                }
                current = current.Next;
            }
        }

        /// <summary>
        /// Метод, удаляющий дублирующиеся элементы.
        /// </summary>
        public void RemoveDuplicates()
        {
            Node<T>? current = head;
            while (current != null)
            {
                T data = current.Data;
                Node<T>? nextCurrent = current.Next;

                while (nextCurrent != null)
                {
                    if (nextCurrent.Data.Equals(data))
                    {
                        RemoveWith(current);
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
        /// Метод, переносящий первый элемент в конец.
        /// </summary>
        public void HeadToTail()
        {
            if (Count <= 1) return;
            AddTail(head);
            RemoveHead();
            tail.Next = null;
        }

        /// <summary>
        /// Метод, переносящий последний элемент в начало.
        /// </summary>
        public void TailToHead()
        {
            if (Count <= 1) return;
            AddHead(tail);
            RemoveTail();
            head.Previous = null;
        }

        /// <summary>
        /// Метод, меняющий местами два элемента.
        /// </summary>
        /// <param name="data1">Значение первого элемента.</param>
        /// <param name="data2">Значение второго элемента.</param>
        public void Swap(T? data1, T? data2)
        {
            if (data1.Equals(data2) || Count <= 1) return;
            Node<T>? node1 = null;
            Node<T>? node2 = null;

            Node<T>? currentNode = head;
            while (currentNode != null)
            {
                if (currentNode.Data.Equals(data1) && node1 == null)
                {
                    node1 = currentNode;
                    if (node2 != null) break;
                }
                else if (currentNode.Data.Equals(data2) && node2 == null)
                {
                    node2 = currentNode;
                    if (node1 != null) break;
                }
                currentNode = currentNode.Next;
            }

            if (node1 != null && node2 != null)
            {
                node1.Data = data2;
                node2.Data = data1;
            }
        }

        /// <summary>
        /// Метод, разворачивающий элементы в списке.
        /// </summary>
        public void Reverse()
        {
            Node<T>? current = head;
            Node<T>? temp;

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
        /// Метод, возвращающий отделённую, начиная с заданного узла, часть списка.
        /// </summary>
        /// <param name="node">Узел, по которому происходит разделение.</param>
        private LinkedList<T>? Substring(Node<T>? node)
        {
            LinkedList<T>? substrList = new()
            {
                head = node,
                tail = tail
            };

            if (node == head)
            {
                head = null;
                tail = null;
                substrList.Count = Count;
                Count = 0;
            }
            else
            {
                node.Previous.Next = null;
                tail = node.Previous;
                node.Previous = null;
                int prevCount = Count;
                Count = CountUntil(node.Data);
                substrList.Count = prevCount - Count;
            }
            return substrList;
        }

        /// <summary>
        /// Метод, разделяющий список на две части по указанному значению с изменением текущего списка и возвратом отрезанной части.
        /// </summary>
        /// <param name="splitData">Значение для разделения списка на две части.</param>
        public LinkedList<T>? Split(T? splitData)
        {
            Node<T>? currentNode = head;
            while (currentNode != null)
            {
                if (currentNode.Data.Equals(splitData))
                {
                    return Substring(currentNode);
                }
                currentNode = currentNode.Next;
            }
            return new LinkedList<T>();
        }
    }
}