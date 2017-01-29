using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PushR.Push
{
    public class GroupMapper
    {
        private Dictionary<string, Group> _mappings;

        public GroupMapper()
        {
            _mappings = new Dictionary<string, Group>();
        }

        public void MapDataTypeToGroup(string dataType, Group group)
        {
            _mappings.Add(dataType, group);
        }

        public Group GetGroupForDataType(string dataType)
        {
            return _mappings[dataType];
        } 
    }
}