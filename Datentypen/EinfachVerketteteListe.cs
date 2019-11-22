using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace Datentypen
{
    public class EinfachVerketteteListe<T> : IList<T>
    {
        private Node<T> ErsterNode;

        private class Node<TN>
        {
            public Node(TN wert)
            {
                Wert = wert;
            }

            public TN Wert { get; set; }

            public Node<TN> Nachfolger { get; set; }
        }

        public void Add(T wert)
        {
            if (ErsterNode == null)
            {
                ErsterNode = new Node<T>(wert);
                return;
            }

            Add(wert, ErsterNode);
        }

        private void Add(T wert, Node<T> aktuellerNode)
        {
            if (aktuellerNode.Nachfolger == null)
            {
                aktuellerNode.Nachfolger = new Node<T>(wert);
            }
            else
            {
                Add(wert, aktuellerNode.Nachfolger);
            }
        }

        public void Clear()
        {
            this.ErsterNode = null;
        }

        public bool Contains(T item)
        {
            foreach (var currentItem in this)
            {
                if (EqualityComparer<T>.Default.Equals(item, currentItem))
                {
                    return true;
                }
            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            return Remove(item, ErsterNode, null);
        }

        private bool Remove(T item, Node<T> betrachteterNode, Node<T> vorgaenger)
        {
            if (betrachteterNode == null)
            {
                return false;
            }

            if (EqualityComparer<T>.Default.Equals(item, betrachteterNode.Wert))
            {
                if (vorgaenger == null)
                {
                    ErsterNode = ErsterNode.Nachfolger;
                }
                else
                {
                    vorgaenger.Nachfolger = betrachteterNode.Nachfolger;
                }

                return true;
            }

            return Remove(item, betrachteterNode.Nachfolger, betrachteterNode);
        }

        public int Count
        {
            get => GetCount(ErsterNode);
        }

        private int GetCount(Node<T> node)
        {
            if (node == null)
            {
                return 0;
            }

            return 1 + GetCount(node.Nachfolger);
        }

        public bool IsReadOnly { get; } = false;

        public IEnumerator<T> GetEnumerator()
        {
            var node = ErsterNode;
            while (node != null)
            {
                yield return node.Wert;
                node = node.Nachfolger;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int IndexOf(T item)
        {
            if (!this.Contains(item))
                return -1;

            return IndexOf(item, ErsterNode);
        }

        private int IndexOf(T item, Node<T> node)
        {
            if (item == null)
                return 0;

            if (EqualityComparer<T>.Default.Equals(item, node.Wert))
            {
                return 0;
            }

            return 1 + IndexOf(item, node.Nachfolger);
        }

        public void Insert(int index, T item)
        {
            Insert(index, item, ErsterNode, null);
        }

        private void Insert(int index, T item, Node<T> node, Node<T> vorgaenger)
        {
            if (index == 0)
            {
                vorgaenger.Nachfolger = new Node<T>(item);
                vorgaenger.Nachfolger.Nachfolger = node;
                return;
            }

            Insert(index - 1, item, node.Nachfolger, node);
        }

        public void RemoveAt(int index)
        {
            RemoveAt(index, this.ErsterNode, null);
        }

        private void RemoveAt(int index, Node<T> node, Node<T> vorgaenger)
        {
            if (index == 0)
            {
                vorgaenger.Nachfolger = node.Nachfolger;
                return;
            }

            RemoveAt(index - 1, node.Nachfolger, node);
        }

        public T this[int index]
        {
            get => GetNode(index, ErsterNode).Wert;
            set => GetNode(index, ErsterNode).Wert = value;
        }

        private Node<T> GetNode(int index, Node<T> node)
        {
            if (index == 0)
                return node;

            return GetNode(index - 1, node.Nachfolger);
        }
    }
}
