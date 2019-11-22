using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datentypen
{
    public class ArrayList<T> : IList<T>
    //IList<T>
    {
        private T[] _backingField;

        public void Add(T item)
        {
            if (_backingField == null)
            {
                _backingField = new T[1];
                _backingField[0] = item;
            }
            else
            {
                var old = _backingField;

                _backingField = new T[_backingField.Length + 1];

                Array.Copy(old, _backingField, old.Length);

                _backingField[_backingField.Length - 1] = item;
            }
        }

        public void Clear()
        {
            _backingField = null;
        }

        public bool Contains(T item)
        {
            foreach (var current in _backingField)
            {
                if (EqualityComparer<T>.Default.Equals(current, item))
                {
                    return true;
                }
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            Array.Copy(_backingField, 0, array, arrayIndex, _backingField.Length);
            //for (int i = 0; i < _backingField.Length - 1; i++)
            //{
            //    array[i + arrayIndex] = _backingField[i];
            //    //arrayIndex++;
            //}
        }

        public bool Remove(T item)
        {
            var indexOf = IndexOf(item);
            if (indexOf == -1)
                return false;

            var oldArray = _backingField;
            _backingField = new T[_backingField.Length - 1];

            Array.Copy(oldArray, 0, _backingField, 0, indexOf);
            Array.Copy(oldArray, indexOf + 1, _backingField, indexOf, _backingField.Length - indexOf);

            return true;

            //if (Contains(item))
            //{
            //    var oldArray = _backingField;
            //    _backingField = new T[_backingField.Length - 1];
            //    bool isNotRemoved = true;
            //    int j = 0;

            //    for (int i = 0; i < oldArray.Length; i++)
            //    {
            //        if (EqualityComparer<T>.Default.Equals(oldArray[i], item) && isNotRemoved)
            //        {
            //            isNotRemoved = false;
            //            continue;
            //        }

            //        _backingField[j] = oldArray[i];
            //        j++;
            //    }

            //    return true;
            //}

            //return false;

        }

        public int Count
        {
            get => _backingField.Length;
        }

        public bool IsReadOnly => false;

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in _backingField)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


        //public int IndexOf(T item)
        //{
        //    int i = -1;
        //    foreach (var current in this)
        //    {
        //        i++;
        //        while (EqualityComparer<T>.Default.Equals(current, item))
        //        {
        //            return i;
        //        }
        //    }

        //    return i;
        //}

        public int IndexOf(T item)
        {
            int counter = 0;
            foreach (var current in _backingField)
            {
                while (EqualityComparer<T>.Default.Equals(current, item))
                {
                    return counter;
                }
                counter++;
            }
            return -1;
        }



        public void Insert(int index, T item)
        {
            if (_backingField.Length - 1 < index || index < 0)
            {
                throw new ArgumentException(nameof(index));
            }
            else
            {
                var oldArray = _backingField;
                _backingField = new T[oldArray.Length + 1];
                int j = 0;
                for (int i = 0; i < _backingField.Length; i++)
                {
                    if (index == i)
                    {
                        _backingField[i] = item;
                        continue;
                    }
                    _backingField[i] = oldArray[j];
                    j++;
                }
            }


        }


        public void RemoveAt(int index)
        {
            if (_backingField.Length - 1 < index || index < 0)
            {
                throw new ArgumentException(nameof(index));
            }

            var oldArray = _backingField;
            _backingField = new T[oldArray.Length - 1];
            int j = 0;
            for (int i = 0; i < _backingField.Length; i++)
            {
                if (index == i)
                {
                    j++;
                    _backingField[i] = oldArray[j];
                    j++;
                    continue;
                }
                _backingField[i] = oldArray[j];
                j++;
            }
        }

        public T this[int index]
        {
            get
            {
                if (_backingField == null)
                {
                    throw new NullReferenceException("Geht nicht!");
                }
                else
                {
                    return _backingField[index];

                }
            }
            set => _backingField[index] = value;
        }
    }
}
