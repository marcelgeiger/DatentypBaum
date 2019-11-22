using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace Datentypen
{
    public class Baum : IEnumerable
    {
        #region Node

        public class Node
        {
            public Node Größer { get; set; }
            public Node Kleiner { get; set; }
            public int Inhalt { get; set; }
        }

        #endregion

        public Node RootNode;


        public void Add(int item)
        {
            if (RootNode == null)
            {
                RootNode = new Node();
                RootNode.Inhalt = item;
                return;
            }
            //else if (item < RootNode.Inhalt)
            //{
            //    var node = RootNode.Kleiner;
            //    while (node != null)
            //    {
            //        var NächsterNode = node;
            //        if (item < node.Inhalt)
            //        {
            //            node.Inhalt
            //        }

            //    }
            //}

            var nextNode = RootNode;

            do
            {
                if (CheckObKleiner(item, nextNode) == true && nextNode.Kleiner == null)
                {
                    nextNode.Kleiner = new Node() { Inhalt = item };
                }
                else if (nextNode.Größer == null)
                {
                    nextNode.Kleiner = new Node() { Inhalt = item };
                }

                if (nextNode.Größer.Inhalt < item)
                {
                    nextNode = nextNode.Größer;
                }
                else if (nextNode.Größer.Inhalt > item)
                {
                    nextNode = nextNode.Größer.Kleiner;
                }


                if (nextNode.Kleiner.Inhalt > item)
                {
                    nextNode = nextNode.Kleiner;
                }
                else
                {
                    nextNode = nextNode.Kleiner.Größer;
                }
                //test
            } while (b);

        }

        private Node GibMirPassendenNode(int item, Node node)
        {

            if (item == node.Inhalt)
            {
                return node;
            }
            else if (item < node.Inhalt)
            {
                return node.Kleiner;
            }
            else
            {
                return node.Größer;
            }
        }

        bool CheckObKleiner(int item, Node node)
        {
            var testNode = node;

            bool kleiner = false;
            if (item < testNode.Inhalt)
            {
                return kleiner = true;
            }

            return kleiner;
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }



    }
}
