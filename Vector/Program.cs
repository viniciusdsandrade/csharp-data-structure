using System.Reflection;
using System.Text;

namespace Vector
{
    class Vector<X> : ICloneable
    {
        public X[] array;
        private bool isLimited;
        private int size;

        public Vector()
        {
            array = Array.Empty<X>();
            isLimited = false;
            size = 0;
        }

        public Vector(int size)
        {
            array = new X[size];
            isLimited = true;
            this.size = size;
        }

        public Vector(int size, bool isLimited)
        {
            array = new X[size];
            this.isLimited = isLimited;
            this.size = size;
        }

        public int GetSize()
        {
            return size;
        }

        public X Get(int index)
        {
            return array[index];
        }

        public void Set(int index, X value)
        {
            array[index] = value;
        }

        public void Add(X value)
        {
            if (isLimited)
            {
                throw new InvalidOperationException("O vetor é limitado");
            }

            X[] newArray = new X[size + 1];

            for (int i = 0; i < size; i++)
            {
                newArray[i] = array[i];
            }

            newArray[size] = value;
            array = newArray;
            size++;
        }

        public void AddFirst(X value)
        {
            if (isLimited)
            {
                throw new InvalidOperationException("O vetor é limitado");
            }

            X[] newArray = new X[size + 1];

            newArray[0] = value;

            for (int i = 0; i < size; i++)
            {
                newArray[i + 1] = array[i];
            }

            array = newArray;
            size++;
        }

        public void AddLast(X value)
        {
            Add(value);
        }

        public void Remove(int index)
        {
            if (isLimited)
            {
                throw new InvalidOperationException("O vetor é limitado");
            }

            X[] newArray = new X[size - 1];

            for (int i = 0; i < index; i++)
            {
                newArray[i] = array[i];
            }

            for (int i = index + 1; i < size; i++)
            {
                newArray[i - 1] = array[i];
            }

            array = newArray;
            size--;
        }

        public void RemoveFirst()
        {
            if (isLimited)
            {
                throw new InvalidOperationException("O vetor é limitado");
            }

            X[] newArray = new X[size - 1];

            for (int i = 1; i < size; i++)
            {
                newArray[i - 1] = array[i];
            }

            array = newArray;
            size--;
        }

        public void RemoveLast()
        {
            if (isLimited)
            {
                throw new InvalidOperationException("O vetor é limitado");
            }

            X[] newArray = new X[size - 1];

            for (int i = 0; i < size - 1; i++)
            {
                newArray[i] = array[i];
            }

            array = newArray;
            size--;
        }

        public void RemoveAll(X value)
        {
            if (isLimited)
            {
                throw new InvalidOperationException("O vetor é limitado");
            }

            int count = 0;

            for (int i = 0; i < size; i++)
            {
                if (array[i].Equals(value))
                {
                    count++;
                }
            }

            X[] newArray = new X[size - count];

            int j = 0;

            for (int i = 0; i < size; i++)
            {
                if (!array[i].Equals(value))
                {
                    newArray[j] = array[i];
                    j++;
                }
            }

            array = newArray;
            size -= count;
        }


        public X GetFirst()
        {
            return array[0];
        }

        public X GetLast()
        {
            return array[size - 1];
        }


        public void Clear()
        {
            if (isLimited)
            {
                throw new InvalidOperationException("O vetor é limitado");
            }

            array = new X[size];
        }

        public void Resize(int newSize)
        {
            if (isLimited)
            {
                throw new InvalidOperationException("O vetor é limitado");
            }

            X[] newArray = new X[newSize];

            for (int i = 0; i < newSize && i < size; i++)
            {
                newArray[i] = array[i];
            }

            array = newArray;
            size = newSize;
        }


        public Vector(Vector<X> vector)
        {
            if (vector == null)
            {
                throw new ArgumentNullException("O vetor não pode ser nulo");
            }

            size = vector.size;
            array = new X[size];
            isLimited = vector.isLimited;

            for (int i = 0; i < size; i++)
            {
                if (vector.array[i] is ICloneable)
                {
                    array[i] = (X)((ICloneable)vector.array[i]).Clone();
                }
                else
                {
                    Type type = typeof(X);
                    if (!type.IsValueType && type != typeof(string))
                    {
                        array[i] = (X)Activator.CreateInstance(type);
                        foreach (var field in type.GetFields(BindingFlags.Public | BindingFlags.NonPublic |
                                                             BindingFlags.Instance))
                        {
                            object fieldValue = field.GetValue(vector.array[i]);
                            if (fieldValue is ICloneable cloneableFieldValue)
                            {
                                field.SetValue(array[i], cloneableFieldValue.Clone());
                            }
                            else
                            {
                                field.SetValue(array[i], fieldValue);
                            }
                        }
                    }
                    else
                    {
                        array[i] = vector.array[i];
                    }
                }
            }
        }

        public object Clone()
        {
            Vector<X> clone = null;

            try
            {
                clone = new Vector<X>(this);
            }
            catch (Exception)
            {
                // ignored
            }

            return clone;
        }


        public override bool Equals(object obj)
        {
            if (this == obj)
            {
                return true;
            }

            if (obj == null)
            {
                return false;
            }

            if (GetType() != obj.GetType())
            {
                return false;
            }

            Vector<X> other = (Vector<X>)obj;

            if (this.GetSize() != other.GetSize())
            {
                return false;
            }

            for (int i = 0; i < array.Length; i++)
            {
                if (!array[i].Equals(other.array[i]))
                {
                    return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            const int prime = 31;
            int hash = 1;

            foreach (X x in array)
            {
                hash *= prime + (x == null ? 0 : x.GetHashCode());
            }

            if (hash < 0)
            {
                hash = -hash;
            }

            return hash;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[");

            for (int i = 0; i < array.Length; i++)
            {
                sb.Append(array[i]);

                if (i < array.Length - 1)
                {
                    sb.Append(", ");
                }
            }

            sb.Append("]");
            return sb.ToString();
        }
    }
}