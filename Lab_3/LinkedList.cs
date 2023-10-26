﻿using static Lab_3.TypeChecker;

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
        /// Метод, возвращающий копию списка.
        /// </summary>
        public LinkedList<T> Copy()
        {
            LinkedList<T> newList = new();
            Node<T> currentNode = head;
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
            if (!IsNumericType(typeof(T)))
            {
                Console.WriteLine("Этот метод используется только для списка с числовыми значениями.");
                return false;
            }
            if (head == null || Count == 1) return true;

            Node<T> currentNode = head.Next;
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
        /// Метод, вставляющий заданный список после указанного узла.
        /// </summary>
        /// <param name="insertList">Вставляемый список.</param>
        /// <param name="node">Узел для обозначения места вставки.</param>
        public void Insert(LinkedList<T> insertList, Node<T> node)
        {
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
        public void Insert(T insertData, Node<T> node)
        {
            Node<T> insertNode = new(insertData);
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
        public void InsertAfter(T data)
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
                if (currentNode.Data.Equals(data))
                {
                    LinkedList<T> insertList = Copy();
                    Insert(insertList, currentNode);
                    return;
                }
                currentNode = currentNode.Next;
            }
        }

        /// <summary>
        /// Метод, добавляющий в отсортированный по неубыванию список указанный элемент без нарушения сортировки.
        /// </summary>
        /// <param name="data">Значение добавляемого элемента.</param>
        public void InsertInSortedInAcsOrderList(T data)
        {
            if (!IsSortedInAcsendingOrder())
            {
                Console.WriteLine("Этот метод используется только для отсортированного по неубыванию списка.");
                return;
            }
            if (head == null)
            {
                Console.WriteLine("Для выполнения данного действия список должен содержать хотя бы один элемент.");
                return;
            }

            double insertData = double.Parse(data.ToString());
            Node<T> currentNode = head;
            while (currentNode != null)
            {
                double currentData = double.Parse(currentNode.Data.ToString());
                if (insertData < currentData)
                {
                    if (currentNode.Previous == null)
                        AddHead(data);
                    else
                        Insert(data, currentNode.Previous);
                    return;
                }
                currentNode = currentNode.Next;
            }
            Insert(data, tail);
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

        public void RemoveNode(Node<T> node)
        {
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
        public void RemoveNodes(Node<T> startNode)
        {
            Node<T> current = startNode;
            T removeData = current.Data;
            while (current != null)
            {
                if (current.Data.Equals(removeData))
                {
                    RemoveNode(current);
                }
                current = current.Next;
            }
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
        /// Метод, разворачивающий элементы в списке.
        /// </summary>
        public void Reverse()
        {
            Node<T> current = head;
            Node<T> temp;

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
    }
}