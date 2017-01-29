using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PushR.Push
{
    public class Group
    {
        public Guid Key { get; private set; }
        public string Name { get; set; }

        public Group(string name)
        {
            Key = Guid.NewGuid();
            Name = name;
        }
    }
}