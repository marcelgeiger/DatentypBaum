using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace Datentypen
{
    public class Baum : IEnumerable
    {
        #region Node
        //test
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

            var nextNode = RootNode;

            do
            {
                if (GibMirPassendenNode(item, nextNode)== null)
                {
                   nextNode = GibMirPassendenNode(item,nextNode);

                }

                
                //test
            } while ();

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
