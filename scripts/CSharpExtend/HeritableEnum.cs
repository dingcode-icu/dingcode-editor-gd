using System;
using System.Collections;
using System.Collections.Generic;

namespace HeritableEnum
{
    public class HEnum : IComparable<HEnum>, IEquatable<HEnum>
    {
        private static int counter = -1; //默认数值计数器
        private static readonly Hashtable hashTable = new Hashtable(); //不重复数值集合
        protected static List<HEnum> members = new List<HEnum>(); //所有实例集合

        /// <summary>
        ///     不指定数值构造实例
        /// </summary>
        protected HEnum(string name)
        {
            Name = name;
            Value = ++counter;
            members.Add(this);
            if (!hashTable.ContainsKey(Value)) hashTable.Add(Value, this);
        }

        /// <summary>
        ///     指定数值构造实例
        /// </summary>
        protected HEnum(string name, int value)
            : this(name)
        {
            Value = value;
            counter = value;
        }

        private string Name { get; }
        private int Value { get; }

        public int CompareTo(HEnum other)
        {
            return Value.CompareTo(other.Value);
        }

        public bool Equals(HEnum other)
        {
            return Value.Equals(other.Value);
        }

        /// <summary>
        ///     向string转换
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Name;
        }

        /// <summary>
        ///     显式强制从int转换
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public static explicit operator HEnum(int i)
        {
            if (hashTable.ContainsKey(i)) return members[i];
            return new HEnum(i.ToString(), i);
        }

        /// <summary>
        ///     显式强制向int转换
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public static explicit operator int(HEnum e)
        {
            return e.Value;
        }

        public static void ForEach(Action<HEnum> action)
        {
            foreach (var item in members) action(item);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is HEnum))
                return false;
            return Value == ((HEnum)obj).Value;
        }

        public override int GetHashCode()
        {
            var std = (HEnum)hashTable[Value];
            if (std.Name == Name)
                return base.GetHashCode();
            return std.GetHashCode();
        }

        public static bool operator !=(HEnum e1, HEnum e2)
        {
            return e1.Value != e2.Value;
        }

        public static bool operator <(HEnum e1, HEnum e2)
        {
            return e1.Value < e2.Value;
        }

        public static bool operator <=(HEnum e1, HEnum e2)
        {
            return e1.Value <= e2.Value;
        }

        public static bool operator ==(HEnum e1, HEnum e2)
        {
            return e1.Value == e2.Value;
        }

        public static bool operator >(HEnum e1, HEnum e2)
        {
            return e1.Value > e2.Value;
        }

        public static bool operator >=(HEnum e1, HEnum e2)
        {
            return e1.Value >= e2.Value;
        }
    }
}