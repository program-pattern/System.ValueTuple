using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace System
{
    public static class Tuple
    {
        public static Tuple<T1> Create<T1>(T1 item1)
        {
            return new Tuple<T1>(item1);
        }

        public static Tuple<T1, T2> Create<T1, T2>(T1 item1, T2 item2)
        {
            return new Tuple<T1, T2>(item1, item2);
        }

        public static Tuple<T1, T2, T3> Create<T1, T2, T3>(T1 item1, T2 item2, T3 item3)
        {
            return new Tuple<T1, T2, T3>(item1, item2, item3);
        }

        public static Tuple<T1, T2, T3, T4> Create<T1, T2, T3, T4>(T1 item1, T2 item2, T3 item3, T4 item4)
        {
            return new Tuple<T1, T2, T3, T4>(item1, item2, item3, item4);
        }

        public static Tuple<T1, T2, T3, T4, T5> Create<T1, T2, T3, T4, T5>(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5)
        {
            return new Tuple<T1, T2, T3, T4, T5>(item1, item2, item3, item4, item5);
        }

        public static Tuple<T1, T2, T3, T4, T5, T6> Create<T1, T2, T3, T4, T5, T6>(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6)
        {
            return new Tuple<T1, T2, T3, T4, T5, T6>(item1, item2, item3, item4, item5, item6);
        }

        public static Tuple<T1, T2, T3, T4, T5, T6, T7> Create<T1, T2, T3, T4, T5, T6, T7>(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7)
        {
            return new Tuple<T1, T2, T3, T4, T5, T6, T7>(item1, item2, item3, item4, item5, item6, item7);
        }

        public static Tuple<T1, T2, T3, T4, T5, T6, T7, Tuple<T8>> Create<T1, T2, T3, T4, T5, T6, T7, T8>(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, T8 item8)
        {
            return new Tuple<T1, T2, T3, T4, T5, T6, T7, Tuple<T8>>(item1, item2, item3, item4, item5, item6, item7, new Tuple<T8>(item8));
        }

        internal static int CombineHashCodes(int h1, int h2)
        {
            return ((h1 << 5) + h1) ^ h2;
        }

        internal static int CombineHashCodes(int h1, int h2, int h3)
        {
            return CombineHashCodes(CombineHashCodes(h1, h2), h3);
        }

        internal static int CombineHashCodes(int h1, int h2, int h3, int h4)
        {
            return CombineHashCodes(CombineHashCodes(h1, h2), CombineHashCodes(h3, h4));
        }

        internal static int CombineHashCodes(int h1, int h2, int h3, int h4, int h5)
        {
            return CombineHashCodes(CombineHashCodes(h1, h2, h3, h4), h5);
        }

        internal static int CombineHashCodes(int h1, int h2, int h3, int h4, int h5, int h6)
        {
            return CombineHashCodes(CombineHashCodes(h1, h2, h3, h4), CombineHashCodes(h5, h6));
        }

        internal static int CombineHashCodes(int h1, int h2, int h3, int h4, int h5, int h6, int h7)
        {
            return CombineHashCodes(CombineHashCodes(h1, h2, h3, h4), CombineHashCodes(h5, h6, h7));
        }

        internal static int CombineHashCodes(int h1, int h2, int h3, int h4, int h5, int h6, int h7, int h8)
        {
            return CombineHashCodes(CombineHashCodes(h1, h2, h3, h4), CombineHashCodes(h5, h6, h7, h8));
        }
    }

    [Serializable]
    public class Tuple<T1> : IStructuralEquatable, IStructuralComparable, IComparable, ITupleInternal, ITuple
    {
        private readonly T1 m_Item1;

        public T1 Item1
        {
            get
            {
                return m_Item1;
            }
        }

        int ITuple.Length
        {
            get
            {
                return 1;
            }
        }

        object ITuple.this[int index]
        {
            get
            {
                if (index != 0)
                {
                    throw new IndexOutOfRangeException();
                }
                return Item1;
            }
        }

        public Tuple(T1 item1)
        {
            m_Item1 = item1;
        }

        public override bool Equals(object obj)
        {
            return ((IStructuralEquatable)this).Equals(obj, (IEqualityComparer)EqualityComparer<object>.Default);
        }

        bool IStructuralEquatable.Equals(object other, IEqualityComparer comparer)
        {
            if (other == null)
            {
                return false;
            }
            Tuple<T1> tuple = other as Tuple<T1>;
            if (tuple == null)
            {
                return false;
            }
            return comparer.Equals(m_Item1, tuple.m_Item1);
        }

        int IComparable.CompareTo(object obj)
        {
            return ((IStructuralComparable)this).CompareTo(obj, (IComparer)Comparer<object>.Default);
        }

        int IStructuralComparable.CompareTo(object other, IComparer comparer)
        {
            if (other == null)
            {
                return 1;
            }
            Tuple<T1> tuple = other as Tuple<T1>;
            if (tuple == null)
            {
                throw new ArgumentException(SR.Format(SR.ArgumentException_TupleIncorrectType, GetType().ToString()), "other");
            }
            return comparer.Compare(m_Item1, tuple.m_Item1);
        }

        public override int GetHashCode()
        {
            return ((IStructuralEquatable)this).GetHashCode((IEqualityComparer)EqualityComparer<object>.Default);
        }

        int IStructuralEquatable.GetHashCode(IEqualityComparer comparer)
        {
            return comparer.GetHashCode(m_Item1);
        }

        int ITupleInternal.GetHashCode(IEqualityComparer comparer)
        {
            return ((IStructuralEquatable)this).GetHashCode(comparer);
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append('(');
            return ((ITupleInternal)this).ToString(stringBuilder);
        }

        string ITupleInternal.ToString(StringBuilder sb)
        {
            sb.Append(m_Item1);
            sb.Append(')');
            return sb.ToString();
        }
    }

    [Serializable]
    public class Tuple<T1, T2> : IStructuralEquatable, IStructuralComparable, IComparable, ITupleInternal, ITuple
    {
        private readonly T1 m_Item1;

        private readonly T2 m_Item2;

        public T1 Item1
        {
            get
            {
                return m_Item1;
            }
        }

        public T2 Item2
        {
            get
            {
                return m_Item2;
            }
        }

        int ITuple.Length
        {
            get
            {
                return 2;
            }
        }

        object ITuple.this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return Item1;
                    case 1:
                        return Item2;
                    default:
                        throw new IndexOutOfRangeException();
                }
            }
        }

        public Tuple(T1 item1, T2 item2)
        {
            m_Item1 = item1;
            m_Item2 = item2;
        }

        public override bool Equals(object obj)
        {
            return ((IStructuralEquatable)this).Equals(obj, (IEqualityComparer)EqualityComparer<object>.Default);
        }

        bool IStructuralEquatable.Equals(object other, IEqualityComparer comparer)
        {
            if (other == null)
            {
                return false;
            }
            Tuple<T1, T2> tuple = other as Tuple<T1, T2>;
            if (tuple == null)
            {
                return false;
            }
            if (comparer.Equals(m_Item1, tuple.m_Item1))
            {
                return comparer.Equals(m_Item2, tuple.m_Item2);
            }
            return false;
        }

        int IComparable.CompareTo(object obj)
        {
            return ((IStructuralComparable)this).CompareTo(obj, (IComparer)Comparer<object>.Default);
        }

        int IStructuralComparable.CompareTo(object other, IComparer comparer)
        {
            if (other == null)
            {
                return 1;
            }
            Tuple<T1, T2> tuple = other as Tuple<T1, T2>;
            if (tuple == null)
            {
                throw new ArgumentException(SR.Format(SR.ArgumentException_TupleIncorrectType, GetType().ToString()), "other");
            }
            int num = 0;
            num = comparer.Compare(m_Item1, tuple.m_Item1);
            if (num != 0)
            {
                return num;
            }
            return comparer.Compare(m_Item2, tuple.m_Item2);
        }

        public override int GetHashCode()
        {
            return ((IStructuralEquatable)this).GetHashCode((IEqualityComparer)EqualityComparer<object>.Default);
        }

        int IStructuralEquatable.GetHashCode(IEqualityComparer comparer)
        {
            return Tuple.CombineHashCodes(comparer.GetHashCode(m_Item1), comparer.GetHashCode(m_Item2));
        }

        int ITupleInternal.GetHashCode(IEqualityComparer comparer)
        {
            return ((IStructuralEquatable)this).GetHashCode(comparer);
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append('(');
            return ((ITupleInternal)this).ToString(stringBuilder);
        }

        string ITupleInternal.ToString(StringBuilder sb)
        {
            sb.Append(m_Item1);
            sb.Append(", ");
            sb.Append(m_Item2);
            sb.Append(')');
            return sb.ToString();
        }
    }

    [Serializable]
    public class Tuple<T1, T2, T3> : IStructuralEquatable, IStructuralComparable, IComparable, ITupleInternal, ITuple
    {
        private readonly T1 m_Item1;

        private readonly T2 m_Item2;

        private readonly T3 m_Item3;

        public T1 Item1
        {
            get
            {
                return m_Item1;
            }
        }

        public T2 Item2
        {
            get
            {
                return m_Item2;
            }
        }

        public T3 Item3
        {
            get
            {
                return m_Item3;
            }
        }

        int ITuple.Length
        {
            get
            {
                return 3;
            }
        }

        object ITuple.this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return Item1;
                    case 1:
                        return Item2;
                    case 2:
                        return Item3;
                    default:
                        throw new IndexOutOfRangeException();
                }
            }
        }

        public Tuple(T1 item1, T2 item2, T3 item3)
        {
            m_Item1 = item1;
            m_Item2 = item2;
            m_Item3 = item3;
        }

        public override bool Equals(object obj)
        {
            return ((IStructuralEquatable)this).Equals(obj, (IEqualityComparer)EqualityComparer<object>.Default);
        }

        bool IStructuralEquatable.Equals(object other, IEqualityComparer comparer)
        {
            if (other == null)
            {
                return false;
            }
            Tuple<T1, T2, T3> tuple = other as Tuple<T1, T2, T3>;
            if (tuple == null)
            {
                return false;
            }
            if (comparer.Equals(m_Item1, tuple.m_Item1) && comparer.Equals(m_Item2, tuple.m_Item2))
            {
                return comparer.Equals(m_Item3, tuple.m_Item3);
            }
            return false;
        }

        int IComparable.CompareTo(object obj)
        {
            return ((IStructuralComparable)this).CompareTo(obj, (IComparer)Comparer<object>.Default);
        }

        int IStructuralComparable.CompareTo(object other, IComparer comparer)
        {
            if (other == null)
            {
                return 1;
            }
            Tuple<T1, T2, T3> tuple = other as Tuple<T1, T2, T3>;
            if (tuple == null)
            {
                throw new ArgumentException(SR.Format(SR.ArgumentException_TupleIncorrectType, GetType().ToString()), "other");
            }
            int num = 0;
            num = comparer.Compare(m_Item1, tuple.m_Item1);
            if (num != 0)
            {
                return num;
            }
            num = comparer.Compare(m_Item2, tuple.m_Item2);
            if (num != 0)
            {
                return num;
            }
            return comparer.Compare(m_Item3, tuple.m_Item3);
        }

        public override int GetHashCode()
        {
            return ((IStructuralEquatable)this).GetHashCode((IEqualityComparer)EqualityComparer<object>.Default);
        }

        int IStructuralEquatable.GetHashCode(IEqualityComparer comparer)
        {
            return Tuple.CombineHashCodes(comparer.GetHashCode(m_Item1), comparer.GetHashCode(m_Item2), comparer.GetHashCode(m_Item3));
        }

        int ITupleInternal.GetHashCode(IEqualityComparer comparer)
        {
            return ((IStructuralEquatable)this).GetHashCode(comparer);
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append('(');
            return ((ITupleInternal)this).ToString(stringBuilder);
        }

        string ITupleInternal.ToString(StringBuilder sb)
        {
            sb.Append(m_Item1);
            sb.Append(", ");
            sb.Append(m_Item2);
            sb.Append(", ");
            sb.Append(m_Item3);
            sb.Append(')');
            return sb.ToString();
        }
    }

    [Serializable]
    public class Tuple<T1, T2, T3, T4> : IStructuralEquatable, IStructuralComparable, IComparable, ITupleInternal, ITuple
    {
        private readonly T1 m_Item1;

        private readonly T2 m_Item2;

        private readonly T3 m_Item3;

        private readonly T4 m_Item4;

        public T1 Item1
        {
            get
            {
                return m_Item1;
            }
        }

        public T2 Item2
        {
            get
            {
                return m_Item2;
            }
        }

        public T3 Item3
        {
            get
            {
                return m_Item3;
            }
        }

        public T4 Item4
        {
            get
            {
                return m_Item4;
            }
        }

        int ITuple.Length
        {
            get
            {
                return 4;
            }
        }

        object ITuple.this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return Item1;
                    case 1:
                        return Item2;
                    case 2:
                        return Item3;
                    case 3:
                        return Item4;
                    default:
                        throw new IndexOutOfRangeException();
                }
            }
        }

        public Tuple(T1 item1, T2 item2, T3 item3, T4 item4)
        {
            m_Item1 = item1;
            m_Item2 = item2;
            m_Item3 = item3;
            m_Item4 = item4;
        }

        public override bool Equals(object obj)
        {
            return ((IStructuralEquatable)this).Equals(obj, (IEqualityComparer)EqualityComparer<object>.Default);
        }

        bool IStructuralEquatable.Equals(object other, IEqualityComparer comparer)
        {
            if (other == null)
            {
                return false;
            }
            Tuple<T1, T2, T3, T4> tuple = other as Tuple<T1, T2, T3, T4>;
            if (tuple == null)
            {
                return false;
            }
            if (comparer.Equals(m_Item1, tuple.m_Item1) && comparer.Equals(m_Item2, tuple.m_Item2) && comparer.Equals(m_Item3, tuple.m_Item3))
            {
                return comparer.Equals(m_Item4, tuple.m_Item4);
            }
            return false;
        }

        int IComparable.CompareTo(object obj)
        {
            return ((IStructuralComparable)this).CompareTo(obj, (IComparer)Comparer<object>.Default);
        }

        int IStructuralComparable.CompareTo(object other, IComparer comparer)
        {
            if (other == null)
            {
                return 1;
            }
            Tuple<T1, T2, T3, T4> tuple = other as Tuple<T1, T2, T3, T4>;
            if (tuple == null)
            {
                throw new ArgumentException(SR.Format(SR.ArgumentException_TupleIncorrectType, GetType().ToString()), "other");
            }
            int num = 0;
            num = comparer.Compare(m_Item1, tuple.m_Item1);
            if (num != 0)
            {
                return num;
            }
            num = comparer.Compare(m_Item2, tuple.m_Item2);
            if (num != 0)
            {
                return num;
            }
            num = comparer.Compare(m_Item3, tuple.m_Item3);
            if (num != 0)
            {
                return num;
            }
            return comparer.Compare(m_Item4, tuple.m_Item4);
        }

        public override int GetHashCode()
        {
            return ((IStructuralEquatable)this).GetHashCode((IEqualityComparer)EqualityComparer<object>.Default);
        }

        int IStructuralEquatable.GetHashCode(IEqualityComparer comparer)
        {
            return Tuple.CombineHashCodes(comparer.GetHashCode(m_Item1), comparer.GetHashCode(m_Item2), comparer.GetHashCode(m_Item3), comparer.GetHashCode(m_Item4));
        }

        int ITupleInternal.GetHashCode(IEqualityComparer comparer)
        {
            return ((IStructuralEquatable)this).GetHashCode(comparer);
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append('(');
            return ((ITupleInternal)this).ToString(stringBuilder);
        }

        string ITupleInternal.ToString(StringBuilder sb)
        {
            sb.Append(m_Item1);
            sb.Append(", ");
            sb.Append(m_Item2);
            sb.Append(", ");
            sb.Append(m_Item3);
            sb.Append(", ");
            sb.Append(m_Item4);
            sb.Append(')');
            return sb.ToString();
        }
    }

    [Serializable]
    public class Tuple<T1, T2, T3, T4, T5> : IStructuralEquatable, IStructuralComparable, IComparable, ITupleInternal, ITuple
    {
        private readonly T1 m_Item1;

        private readonly T2 m_Item2;

        private readonly T3 m_Item3;

        private readonly T4 m_Item4;

        private readonly T5 m_Item5;

        public T1 Item1
        {
            get
            {
                return m_Item1;
            }
        }

        public T2 Item2
        {
            get
            {
                return m_Item2;
            }
        }

        public T3 Item3
        {
            get
            {
                return m_Item3;
            }
        }

        public T4 Item4
        {
            get
            {
                return m_Item4;
            }
        }

        public T5 Item5
        {
            get
            {
                return m_Item5;
            }
        }

        int ITuple.Length
        {
            get
            {
                return 5;
            }
        }

        object ITuple.this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return Item1;
                    case 1:
                        return Item2;
                    case 2:
                        return Item3;
                    case 3:
                        return Item4;
                    case 4:
                        return Item5;
                    default:
                        throw new IndexOutOfRangeException();
                }
            }
        }

        public Tuple(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5)
        {
            m_Item1 = item1;
            m_Item2 = item2;
            m_Item3 = item3;
            m_Item4 = item4;
            m_Item5 = item5;
        }

        public override bool Equals(object obj)
        {
            return ((IStructuralEquatable)this).Equals(obj, (IEqualityComparer)EqualityComparer<object>.Default);
        }

        bool IStructuralEquatable.Equals(object other, IEqualityComparer comparer)
        {
            if (other == null)
            {
                return false;
            }
            Tuple<T1, T2, T3, T4, T5> tuple = other as Tuple<T1, T2, T3, T4, T5>;
            if (tuple == null)
            {
                return false;
            }
            if (comparer.Equals(m_Item1, tuple.m_Item1) && comparer.Equals(m_Item2, tuple.m_Item2) && comparer.Equals(m_Item3, tuple.m_Item3) && comparer.Equals(m_Item4, tuple.m_Item4))
            {
                return comparer.Equals(m_Item5, tuple.m_Item5);
            }
            return false;
        }

        int IComparable.CompareTo(object obj)
        {
            return ((IStructuralComparable)this).CompareTo(obj, (IComparer)Comparer<object>.Default);
        }

        int IStructuralComparable.CompareTo(object other, IComparer comparer)
        {
            if (other == null)
            {
                return 1;
            }
            Tuple<T1, T2, T3, T4, T5> tuple = other as Tuple<T1, T2, T3, T4, T5>;
            if (tuple == null)
            {
                throw new ArgumentException(SR.Format(SR.ArgumentException_TupleIncorrectType, GetType().ToString()), "other");
            }
            int num = 0;
            num = comparer.Compare(m_Item1, tuple.m_Item1);
            if (num != 0)
            {
                return num;
            }
            num = comparer.Compare(m_Item2, tuple.m_Item2);
            if (num != 0)
            {
                return num;
            }
            num = comparer.Compare(m_Item3, tuple.m_Item3);
            if (num != 0)
            {
                return num;
            }
            num = comparer.Compare(m_Item4, tuple.m_Item4);
            if (num != 0)
            {
                return num;
            }
            return comparer.Compare(m_Item5, tuple.m_Item5);
        }

        public override int GetHashCode()
        {
            return ((IStructuralEquatable)this).GetHashCode((IEqualityComparer)EqualityComparer<object>.Default);
        }

        int IStructuralEquatable.GetHashCode(IEqualityComparer comparer)
        {
            return Tuple.CombineHashCodes(comparer.GetHashCode(m_Item1), comparer.GetHashCode(m_Item2), comparer.GetHashCode(m_Item3), comparer.GetHashCode(m_Item4), comparer.GetHashCode(m_Item5));
        }

        int ITupleInternal.GetHashCode(IEqualityComparer comparer)
        {
            return ((IStructuralEquatable)this).GetHashCode(comparer);
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append('(');
            return ((ITupleInternal)this).ToString(stringBuilder);
        }

        string ITupleInternal.ToString(StringBuilder sb)
        {
            sb.Append(m_Item1);
            sb.Append(", ");
            sb.Append(m_Item2);
            sb.Append(", ");
            sb.Append(m_Item3);
            sb.Append(", ");
            sb.Append(m_Item4);
            sb.Append(", ");
            sb.Append(m_Item5);
            sb.Append(')');
            return sb.ToString();
        }
    }

    [Serializable]
    public class Tuple<T1, T2, T3, T4, T5, T6> : IStructuralEquatable, IStructuralComparable, IComparable, ITupleInternal, ITuple
    {
        private readonly T1 m_Item1;

        private readonly T2 m_Item2;

        private readonly T3 m_Item3;

        private readonly T4 m_Item4;

        private readonly T5 m_Item5;

        private readonly T6 m_Item6;

        public T1 Item1
        {
            get
            {
                return m_Item1;
            }
        }

        public T2 Item2
        {
            get
            {
                return m_Item2;
            }
        }

        public T3 Item3
        {
            get
            {
                return m_Item3;
            }
        }

        public T4 Item4
        {
            get
            {
                return m_Item4;
            }
        }

        public T5 Item5
        {
            get
            {
                return m_Item5;
            }
        }

        public T6 Item6
        {
            get
            {
                return m_Item6;
            }
        }

        int ITuple.Length
        {
            get
            {
                return 6;
            }
        }

        object ITuple.this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return Item1;
                    case 1:
                        return Item2;
                    case 2:
                        return Item3;
                    case 3:
                        return Item4;
                    case 4:
                        return Item5;
                    case 5:
                        return Item6;
                    default:
                        throw new IndexOutOfRangeException();
                }
            }
        }

        public Tuple(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6)
        {
            m_Item1 = item1;
            m_Item2 = item2;
            m_Item3 = item3;
            m_Item4 = item4;
            m_Item5 = item5;
            m_Item6 = item6;
        }

        public override bool Equals(object obj)
        {
            return ((IStructuralEquatable)this).Equals(obj, (IEqualityComparer)EqualityComparer<object>.Default);
        }

        bool IStructuralEquatable.Equals(object other, IEqualityComparer comparer)
        {
            if (other == null)
            {
                return false;
            }
            Tuple<T1, T2, T3, T4, T5, T6> tuple = other as Tuple<T1, T2, T3, T4, T5, T6>;
            if (tuple == null)
            {
                return false;
            }
            if (comparer.Equals(m_Item1, tuple.m_Item1) && comparer.Equals(m_Item2, tuple.m_Item2) && comparer.Equals(m_Item3, tuple.m_Item3) && comparer.Equals(m_Item4, tuple.m_Item4) && comparer.Equals(m_Item5, tuple.m_Item5))
            {
                return comparer.Equals(m_Item6, tuple.m_Item6);
            }
            return false;
        }

        int IComparable.CompareTo(object obj)
        {
            return ((IStructuralComparable)this).CompareTo(obj, (IComparer)Comparer<object>.Default);
        }

        int IStructuralComparable.CompareTo(object other, IComparer comparer)
        {
            if (other == null)
            {
                return 1;
            }
            Tuple<T1, T2, T3, T4, T5, T6> tuple = other as Tuple<T1, T2, T3, T4, T5, T6>;
            if (tuple == null)
            {
                throw new ArgumentException(SR.Format(SR.ArgumentException_TupleIncorrectType, GetType().ToString()), "other");
            }
            int num = 0;
            num = comparer.Compare(m_Item1, tuple.m_Item1);
            if (num != 0)
            {
                return num;
            }
            num = comparer.Compare(m_Item2, tuple.m_Item2);
            if (num != 0)
            {
                return num;
            }
            num = comparer.Compare(m_Item3, tuple.m_Item3);
            if (num != 0)
            {
                return num;
            }
            num = comparer.Compare(m_Item4, tuple.m_Item4);
            if (num != 0)
            {
                return num;
            }
            num = comparer.Compare(m_Item5, tuple.m_Item5);
            if (num != 0)
            {
                return num;
            }
            return comparer.Compare(m_Item6, tuple.m_Item6);
        }

        public override int GetHashCode()
        {
            return ((IStructuralEquatable)this).GetHashCode((IEqualityComparer)EqualityComparer<object>.Default);
        }

        int IStructuralEquatable.GetHashCode(IEqualityComparer comparer)
        {
            return Tuple.CombineHashCodes(comparer.GetHashCode(m_Item1), comparer.GetHashCode(m_Item2), comparer.GetHashCode(m_Item3), comparer.GetHashCode(m_Item4), comparer.GetHashCode(m_Item5), comparer.GetHashCode(m_Item6));
        }

        int ITupleInternal.GetHashCode(IEqualityComparer comparer)
        {
            return ((IStructuralEquatable)this).GetHashCode(comparer);
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append('(');
            return ((ITupleInternal)this).ToString(stringBuilder);
        }

        string ITupleInternal.ToString(StringBuilder sb)
        {
            sb.Append(m_Item1);
            sb.Append(", ");
            sb.Append(m_Item2);
            sb.Append(", ");
            sb.Append(m_Item3);
            sb.Append(", ");
            sb.Append(m_Item4);
            sb.Append(", ");
            sb.Append(m_Item5);
            sb.Append(", ");
            sb.Append(m_Item6);
            sb.Append(')');
            return sb.ToString();
        }
    }

    [Serializable]
    public class Tuple<T1, T2, T3, T4, T5, T6, T7> : IStructuralEquatable, IStructuralComparable, IComparable, ITupleInternal, ITuple
    {
        private readonly T1 m_Item1;

        private readonly T2 m_Item2;

        private readonly T3 m_Item3;

        private readonly T4 m_Item4;

        private readonly T5 m_Item5;

        private readonly T6 m_Item6;

        private readonly T7 m_Item7;

        public T1 Item1
        {
            get
            {
                return m_Item1;
            }
        }

        public T2 Item2
        {
            get
            {
                return m_Item2;
            }
        }

        public T3 Item3
        {
            get
            {
                return m_Item3;
            }
        }

        public T4 Item4
        {
            get
            {
                return m_Item4;
            }
        }

        public T5 Item5
        {
            get
            {
                return m_Item5;
            }
        }

        public T6 Item6
        {
            get
            {
                return m_Item6;
            }
        }

        public T7 Item7
        {
            get
            {
                return m_Item7;
            }
        }

        int ITuple.Length
        {
            get
            {
                return 7;
            }
        }

        object ITuple.this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return Item1;
                    case 1:
                        return Item2;
                    case 2:
                        return Item3;
                    case 3:
                        return Item4;
                    case 4:
                        return Item5;
                    case 5:
                        return Item6;
                    case 6:
                        return Item7;
                    default:
                        throw new IndexOutOfRangeException();
                }
            }
        }

        public Tuple(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7)
        {
            m_Item1 = item1;
            m_Item2 = item2;
            m_Item3 = item3;
            m_Item4 = item4;
            m_Item5 = item5;
            m_Item6 = item6;
            m_Item7 = item7;
        }

        public override bool Equals(object obj)
        {
            return ((IStructuralEquatable)this).Equals(obj, (IEqualityComparer)EqualityComparer<object>.Default);
        }

        bool IStructuralEquatable.Equals(object other, IEqualityComparer comparer)
        {
            if (other == null)
            {
                return false;
            }
            Tuple<T1, T2, T3, T4, T5, T6, T7> tuple = other as Tuple<T1, T2, T3, T4, T5, T6, T7>;
            if (tuple == null)
            {
                return false;
            }
            if (comparer.Equals(m_Item1, tuple.m_Item1) && comparer.Equals(m_Item2, tuple.m_Item2) && comparer.Equals(m_Item3, tuple.m_Item3) && comparer.Equals(m_Item4, tuple.m_Item4) && comparer.Equals(m_Item5, tuple.m_Item5) && comparer.Equals(m_Item6, tuple.m_Item6))
            {
                return comparer.Equals(m_Item7, tuple.m_Item7);
            }
            return false;
        }

        int IComparable.CompareTo(object obj)
        {
            return ((IStructuralComparable)this).CompareTo(obj, (IComparer)Comparer<object>.Default);
        }

        int IStructuralComparable.CompareTo(object other, IComparer comparer)
        {
            if (other == null)
            {
                return 1;
            }
            Tuple<T1, T2, T3, T4, T5, T6, T7> tuple = other as Tuple<T1, T2, T3, T4, T5, T6, T7>;
            if (tuple == null)
            {
                throw new ArgumentException(SR.Format(SR.ArgumentException_TupleIncorrectType, GetType().ToString()), "other");
            }
            int num = 0;
            num = comparer.Compare(m_Item1, tuple.m_Item1);
            if (num != 0)
            {
                return num;
            }
            num = comparer.Compare(m_Item2, tuple.m_Item2);
            if (num != 0)
            {
                return num;
            }
            num = comparer.Compare(m_Item3, tuple.m_Item3);
            if (num != 0)
            {
                return num;
            }
            num = comparer.Compare(m_Item4, tuple.m_Item4);
            if (num != 0)
            {
                return num;
            }
            num = comparer.Compare(m_Item5, tuple.m_Item5);
            if (num != 0)
            {
                return num;
            }
            num = comparer.Compare(m_Item6, tuple.m_Item6);
            if (num != 0)
            {
                return num;
            }
            return comparer.Compare(m_Item7, tuple.m_Item7);
        }

        public override int GetHashCode()
        {
            return ((IStructuralEquatable)this).GetHashCode((IEqualityComparer)EqualityComparer<object>.Default);
        }

        int IStructuralEquatable.GetHashCode(IEqualityComparer comparer)
        {
            return Tuple.CombineHashCodes(comparer.GetHashCode(m_Item1), comparer.GetHashCode(m_Item2), comparer.GetHashCode(m_Item3), comparer.GetHashCode(m_Item4), comparer.GetHashCode(m_Item5), comparer.GetHashCode(m_Item6), comparer.GetHashCode(m_Item7));
        }

        int ITupleInternal.GetHashCode(IEqualityComparer comparer)
        {
            return ((IStructuralEquatable)this).GetHashCode(comparer);
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append('(');
            return ((ITupleInternal)this).ToString(stringBuilder);
        }

        string ITupleInternal.ToString(StringBuilder sb)
        {
            sb.Append(m_Item1);
            sb.Append(", ");
            sb.Append(m_Item2);
            sb.Append(", ");
            sb.Append(m_Item3);
            sb.Append(", ");
            sb.Append(m_Item4);
            sb.Append(", ");
            sb.Append(m_Item5);
            sb.Append(", ");
            sb.Append(m_Item6);
            sb.Append(", ");
            sb.Append(m_Item7);
            sb.Append(')');
            return sb.ToString();
        }
    }

    [Serializable]
    public class Tuple<T1, T2, T3, T4, T5, T6, T7, TRest> : IStructuralEquatable, IStructuralComparable, IComparable, ITupleInternal, ITuple
    {
        private readonly T1 m_Item1;

        private readonly T2 m_Item2;

        private readonly T3 m_Item3;

        private readonly T4 m_Item4;

        private readonly T5 m_Item5;

        private readonly T6 m_Item6;

        private readonly T7 m_Item7;

        private readonly TRest m_Rest;

        public T1 Item1
        {
            get
            {
                return m_Item1;
            }
        }

        public T2 Item2
        {
            get
            {
                return m_Item2;
            }
        }

        public T3 Item3
        {
            get
            {
                return m_Item3;
            }
        }

        public T4 Item4
        {
            get
            {
                return m_Item4;
            }
        }

        public T5 Item5
        {
            get
            {
                return m_Item5;
            }
        }

        public T6 Item6
        {
            get
            {
                return m_Item6;
            }
        }

        public T7 Item7
        {
            get
            {
                return m_Item7;
            }
        }

        public TRest Rest
        {
            get
            {
                return m_Rest;
            }
        }

        int ITuple.Length
        {
            get
            {
                return 7 + ((ITupleInternal)(object)Rest).Length;
            }
        }

        object ITuple.this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return Item1;
                    case 1:
                        return Item2;
                    case 2:
                        return Item3;
                    case 3:
                        return Item4;
                    case 4:
                        return Item5;
                    case 5:
                        return Item6;
                    case 6:
                        return Item7;
                    default:
                        return ((ITupleInternal)(object)Rest)[index - 7];
                }
            }
        }

        public Tuple(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, TRest rest)
        {
            if (!(((object)rest) is ITupleInternal))
            {
                throw new ArgumentException(SR.ArgumentException_TupleLastArgumentNotATuple);
            }
            m_Item1 = item1;
            m_Item2 = item2;
            m_Item3 = item3;
            m_Item4 = item4;
            m_Item5 = item5;
            m_Item6 = item6;
            m_Item7 = item7;
            m_Rest = rest;
        }

        public override bool Equals(object obj)
        {
            return ((IStructuralEquatable)this).Equals(obj, (IEqualityComparer)EqualityComparer<object>.Default);
        }

        bool IStructuralEquatable.Equals(object other, IEqualityComparer comparer)
        {
            if (other == null)
            {
                return false;
            }
            Tuple<T1, T2, T3, T4, T5, T6, T7, TRest> tuple = other as Tuple<T1, T2, T3, T4, T5, T6, T7, TRest>;
            if (tuple == null)
            {
                return false;
            }
            if (comparer.Equals(m_Item1, tuple.m_Item1) && comparer.Equals(m_Item2, tuple.m_Item2) && comparer.Equals(m_Item3, tuple.m_Item3) && comparer.Equals(m_Item4, tuple.m_Item4) && comparer.Equals(m_Item5, tuple.m_Item5) && comparer.Equals(m_Item6, tuple.m_Item6) && comparer.Equals(m_Item7, tuple.m_Item7))
            {
                return comparer.Equals(m_Rest, tuple.m_Rest);
            }
            return false;
        }

        int IComparable.CompareTo(object obj)
        {
            return ((IStructuralComparable)this).CompareTo(obj, (IComparer)Comparer<object>.Default);
        }

        int IStructuralComparable.CompareTo(object other, IComparer comparer)
        {
            if (other == null)
            {
                return 1;
            }
            Tuple<T1, T2, T3, T4, T5, T6, T7, TRest> tuple = other as Tuple<T1, T2, T3, T4, T5, T6, T7, TRest>;
            if (tuple == null)
            {
                throw new ArgumentException(SR.Format(SR.ArgumentException_TupleIncorrectType, GetType().ToString()), "other");
            }
            int num = 0;
            num = comparer.Compare(m_Item1, tuple.m_Item1);
            if (num != 0)
            {
                return num;
            }
            num = comparer.Compare(m_Item2, tuple.m_Item2);
            if (num != 0)
            {
                return num;
            }
            num = comparer.Compare(m_Item3, tuple.m_Item3);
            if (num != 0)
            {
                return num;
            }
            num = comparer.Compare(m_Item4, tuple.m_Item4);
            if (num != 0)
            {
                return num;
            }
            num = comparer.Compare(m_Item5, tuple.m_Item5);
            if (num != 0)
            {
                return num;
            }
            num = comparer.Compare(m_Item6, tuple.m_Item6);
            if (num != 0)
            {
                return num;
            }
            num = comparer.Compare(m_Item7, tuple.m_Item7);
            if (num != 0)
            {
                return num;
            }
            return comparer.Compare(m_Rest, tuple.m_Rest);
        }

        public override int GetHashCode()
        {
            return ((IStructuralEquatable)this).GetHashCode((IEqualityComparer)EqualityComparer<object>.Default);
        }

        int IStructuralEquatable.GetHashCode(IEqualityComparer comparer)
        {
            ITupleInternal tupleInternal = (ITupleInternal)(object)m_Rest;
            if (tupleInternal.Length < 8)
            {
                switch (8 - tupleInternal.Length)
                {
                    case 1:
                        return Tuple.CombineHashCodes(comparer.GetHashCode(m_Item7), tupleInternal.GetHashCode(comparer));
                    case 2:
                        return Tuple.CombineHashCodes(comparer.GetHashCode(m_Item6), comparer.GetHashCode(m_Item7), tupleInternal.GetHashCode(comparer));
                    case 3:
                        return Tuple.CombineHashCodes(comparer.GetHashCode(m_Item5), comparer.GetHashCode(m_Item6), comparer.GetHashCode(m_Item7), tupleInternal.GetHashCode(comparer));
                    case 4:
                        return Tuple.CombineHashCodes(comparer.GetHashCode(m_Item4), comparer.GetHashCode(m_Item5), comparer.GetHashCode(m_Item6), comparer.GetHashCode(m_Item7), tupleInternal.GetHashCode(comparer));
                    case 5:
                        return Tuple.CombineHashCodes(comparer.GetHashCode(m_Item3), comparer.GetHashCode(m_Item4), comparer.GetHashCode(m_Item5), comparer.GetHashCode(m_Item6), comparer.GetHashCode(m_Item7), tupleInternal.GetHashCode(comparer));
                    case 6:
                        return Tuple.CombineHashCodes(comparer.GetHashCode(m_Item2), comparer.GetHashCode(m_Item3), comparer.GetHashCode(m_Item4), comparer.GetHashCode(m_Item5), comparer.GetHashCode(m_Item6), comparer.GetHashCode(m_Item7), tupleInternal.GetHashCode(comparer));
                    case 7:
                        return Tuple.CombineHashCodes(comparer.GetHashCode(m_Item1), comparer.GetHashCode(m_Item2), comparer.GetHashCode(m_Item3), comparer.GetHashCode(m_Item4), comparer.GetHashCode(m_Item5), comparer.GetHashCode(m_Item6), comparer.GetHashCode(m_Item7), tupleInternal.GetHashCode(comparer));
                    default:
                        return -1;
                }
            }
            return tupleInternal.GetHashCode(comparer);
        }

        int ITupleInternal.GetHashCode(IEqualityComparer comparer)
        {
            return ((IStructuralEquatable)this).GetHashCode(comparer);
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append('(');
            return ((ITupleInternal)this).ToString(stringBuilder);
        }

        string ITupleInternal.ToString(StringBuilder sb)
        {
            sb.Append(m_Item1);
            sb.Append(", ");
            sb.Append(m_Item2);
            sb.Append(", ");
            sb.Append(m_Item3);
            sb.Append(", ");
            sb.Append(m_Item4);
            sb.Append(", ");
            sb.Append(m_Item5);
            sb.Append(", ");
            sb.Append(m_Item6);
            sb.Append(", ");
            sb.Append(m_Item7);
            sb.Append(", ");
            return ((ITupleInternal)(object)m_Rest).ToString(sb);
        }
    }
}
