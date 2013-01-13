using System;
using System.Collections.Generic;

namespace Netbasics.Tests
{
    public class RandomHelper
    {
        private readonly Random _rnd;

        public RandomHelper()
        {
            _rnd = new Random();
        }

        public string RandomString(bool allowEmpty = false)
        {
            if (allowEmpty && _rnd.Next(2) == 2) return "";
            return "s" + _rnd.Next().ToString();
        }

        public bool RandomBool()
        {
            return _rnd.Next(2) == 1;
        }

        public T RandomEnum<T>(params object[] restricted)
        {
            int max = Enum.GetNames(typeof (T)).Length;
            while (true)
            {
                var sv = (T) ((object) _rnd.Next(max));
                bool isRestricted = false;
                foreach (object r in restricted)
                {
                    if (r.Equals(sv))
                    {
                        isRestricted = true;
                        break;
                    }
                }
                if (isRestricted) continue;
                return sv;
            }
        }

        public List<T> RandomArray<T>(int minItems, int maxItems, Func<T> valf)
        {
            int n = _rnd.Next(minItems, maxItems);
            var result = new List<T>(n);
            for (int i = 0; i < n; i++)
            {
                result.Add(valf());
            }
            return result;
        }
    }
}