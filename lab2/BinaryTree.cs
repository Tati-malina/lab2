using System;
using System.Collections;
using System.Collections.Generic;

//CompareTo для строкових значень
//Даний метод порівнює даний екземпляр із зазначеним об'єктом String і вказує, чи передує цей екземпляр,
//слід за ним або з'являється в тій же позиції в порядку сортування, що і зазначена строка

namespace lab2
{
    public class BinaryTree<T> : ICollection<T> where T : IComparable<T>
    {
        public enum TreeSide { Left, Right }
        //Внутренний класс ноды дерева
        private class BinaryTreeNode : IComparable<BinaryTreeNode>
        {
            public T data { get; set; }

            public TreeSide parentSide;

            public BinaryTreeNode parentNode;
            public BinaryTreeNode rightNode;
            public BinaryTreeNode leftNode;

            public BinaryTreeNode(T value)
            {
                data = value;
                parentNode = null;
                rightNode = null;
                leftNode = null;
            }
            public int CompareTo(BinaryTreeNode node)
            {
                return data.CompareTo(node.data);
            }
        }


        private BinaryTreeNode root;
        public BinaryTree()
        {
            root = null;
            Count = 0;
        }

        public void Add(T data)
        {
            var addNode = new BinaryTreeNode(data);

            if (root == null) { root = addNode; Count++; return; }
            else
            {
                var currentNode = root;
                var prevNode = root;

                bool status = true;
                while (status)
                {
                    status = false;

                    int index = currentNode.CompareTo(addNode);

                    //Правая ветка
                    if (index < 0)
                    {
                        if (currentNode.rightNode == null)
                        {
                            //Определение родителя
                            addNode.parentNode = prevNode;
                            addNode.parentSide = TreeSide.Right;

                            //Добавление узла
                            currentNode.rightNode = addNode;

                            Count++;
                            return;
                        }
                        else
                        {
                            //Сдвиг узла
                            currentNode = currentNode.rightNode;
                            prevNode = currentNode;

                            status = true;
                        }
                    }
                    //Левая ветка
                    else if (index > 0)
                    {
                        if (currentNode.leftNode == null)
                        {
                            addNode.parentNode = prevNode;
                            addNode.parentSide = TreeSide.Left;

                            currentNode.leftNode = addNode;

                            Count++;
                            return;
                        }
                        else
                        {
                            currentNode = currentNode.leftNode;
                            prevNode = currentNode;

                            status = true;
                        }
                    }
                    else { throw new ArgumentException("Заданий об'єкт вже присутній в дереві!"); }
                }
            }
        }


        public bool NodeExists(T value)
        {
            var currentNode = root;
            while (true)
            {
                if (currentNode == null) { return false; }

                int index = currentNode.data.CompareTo(value);   

                if (index == 0) { return true; }
                else if (index < 0) { currentNode = currentNode.rightNode; }
                else { currentNode = currentNode.leftNode; }
            }
        }

        private BinaryTreeNode GetNode(T value)
        {
            var currentNode = root;
            while (true)
            {
                if (currentNode == null) { return null; }

                int index = currentNode.data.CompareTo(value);

                if (index == 0) { return currentNode; }
                else if (index < 0) { currentNode = currentNode.rightNode; }
                else { currentNode = currentNode.leftNode; }
            }
        }


        public void Clear()
        {
            root = null;
            Count = 0;
        }
        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }
        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }
        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public int Count { get; private set; }
        public bool IsReadOnly { get { return false; } }


        //Итераторы 
        public IEnumerator<T> GetEnumerator() { return new PostOrderTraversal(root); }
        IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }

        //Обход дерева
        private class PostOrderTraversal : IEnumerator<T>
        {
            private BinaryTreeNode mainNode;
            private BinaryTreeNode currentNode;
            public List<BinaryTreeNode> visitedNode;

            private bool goLeft;
            private bool goRight;
            private bool isFirst;

            public T Current => currentNode.data;
            object IEnumerator.Current => Current;


            public PostOrderTraversal(BinaryTreeNode root)
            {
                mainNode = root;
                currentNode = mainNode;
                visitedNode = new List<BinaryTreeNode>();

                goLeft = true;
                goRight = true;
                isFirst = true;
            }


            private bool WasNotHereBefore(BinaryTreeNode node)
            {
                foreach (var item in visitedNode)
                {
                    if (item.CompareTo(node) == 0) { return false; }
                }
                return true;
            }
            //Прохождение по левому краю дерева до конца
            private BinaryTreeNode GoMaxLeft(BinaryTreeNode node)
            {
                var tempNode = node;
                while (tempNode.leftNode != null)
                {
                    tempNode = tempNode.leftNode;
                }
                return tempNode;
            }

            //Функция обхода
            private bool GoForNodes()
            {
                //Прохождение к корню дерева
                while (currentNode != mainNode)
                {
                    if (currentNode.leftNode != null && WasNotHereBefore(currentNode.leftNode))
                    {
                        currentNode = GoMaxLeft(currentNode.leftNode);

                        if (WasNotHereBefore(currentNode))
                        {
                            visitedNode.Add(currentNode);
                            return true;
                        }
                    }

                    if (currentNode.rightNode != null && WasNotHereBefore(currentNode.rightNode))
                    {
                        currentNode = GoMaxLeft(currentNode.rightNode);

                        if (WasNotHereBefore(currentNode))
                        {
                            visitedNode.Add(currentNode);
                            return true;
                        }
                    }

                    //Возврщаемся на один узел назад
                    currentNode = currentNode.parentNode;


                    if (currentNode.leftNode != null && WasNotHereBefore(currentNode.leftNode))
                    {
                        currentNode = GoMaxLeft(currentNode.leftNode);

                        if (WasNotHereBefore(currentNode))
                        {
                            visitedNode.Add(currentNode);
                            return true;
                        }
                    }
                    if (currentNode.rightNode != null && WasNotHereBefore(currentNode.rightNode))
                    {
                        currentNode = GoMaxLeft(currentNode.rightNode);

                        if (WasNotHereBefore(currentNode))
                        {
                            visitedNode.Add(currentNode);
                            return true;
                        }
                    }

                    //Все дети записаны - записываем родителя
                    if (WasNotHereBefore(currentNode))
                    {
                        visitedNode.Add(currentNode);
                        return true;
                    }
                }

                return false;
            }


            //PostOrder
            public bool MoveNext()
            {
                if (mainNode == null) { return false; }

                //Только корень
                if (!isFirst) { return false; }
                if (mainNode.leftNode == null && mainNode.rightNode == null && isFirst)
                {
                    isFirst = false;
                    currentNode = mainNode;
                    visitedNode.Add(currentNode);

                    return true;
                }

                //Прохождение к самому левому значению в левой ветке
                if (mainNode.leftNode != null && goLeft)
                {
                    goLeft = false;
                    currentNode = GoMaxLeft(mainNode.leftNode);
                    visitedNode.Add(currentNode);

                    return true;
                }

                //Отсутсвие левой ветки у бинарного дерева
                if (mainNode.leftNode == null && mainNode.rightNode != null && goRight)
                {
                    goRight = false;
                    currentNode = GoMaxLeft(mainNode.rightNode);
                    visitedNode.Add(currentNode);

                    return true;
                }

                //Идем в функцию обхода
                return GoForNodes();
            }
            public void Reset() { currentNode = mainNode; }
            public void Dispose() { }
        }
    }
}
