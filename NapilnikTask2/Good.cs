using System;
using System.Collections.Generic;
using System.Text;

namespace NapilnikTask2
{
    public class Good
    {
        public Good(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException();
            }

            Name = name;
        }

        public string Name { get; private set; }
    }
}
