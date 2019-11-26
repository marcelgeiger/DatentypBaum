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
                if (item == nextNode.Inhalt)
                {
                    break;
                }
                else if (item < nextNode.Inhalt)
                {
                    if (CheckIfFrei(nextNode.Kleiner))
                    {
                        nextNode.Kleiner = new Node(){Inhalt = item};
                        break;
                    }

                    nextNode = nextNode.Kleiner;
                }
                else
                {

                    if (CheckIfFrei(nextNode.Größer))
                    {
                        nextNode.Größer = new Node() { Inhalt = item };
                        break;
                    }

                    nextNode = nextNode.Größer;
                }

            } while (true);
        }


        bool CheckIfFrei(Node kleiner)
        {
            if (kleiner == null)
            {
                return true;
            }
            return false;
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
