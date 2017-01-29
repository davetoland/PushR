using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace PushR.Push
{
    public class GroupManager
    {
        #region Singleton
        private static object _mutex = new object();
        private static GroupManager _instance = null;
        public static GroupManager Instance
        {
            get
            {
                if (_instance == null)
                    lock (_mutex)
                        if (_instance == null)
                            _instance = new GroupManager();

                return _instance;
            }
        }
        #endregion Singleton

        private List<Group> _groups;
        private GroupMapper _mapper;

        private GroupManager()
        {
            _groups = new List<Group>();
            _mapper = new GroupMapper();
            Initialise();
        }

        public void Initialise()
        {
            MapGroupsAndTypes();
        }

        /// <summary>
        /// Read the Groups from the App Setting
        /// For each Group, lookup the associated Data Types
        /// Map each Data Type to its Group
        /// </summary>
        private void MapGroupsAndTypes()
        {
            _groups.Clear();

            string groups = ConfigurationManager.AppSettings["Groups"];
            if (!string.IsNullOrEmpty(groups))
            {
                string[] groupArray = groups.Split(',');
                foreach (string g in groupArray)
                {
                    string groupName = g.Trim();
                    var group = new Group(groupName);
                    _groups.Add(group);
                    string mappings = ConfigurationManager.AppSettings[groupName];
                    if (!string.IsNullOrEmpty(mappings))
                    {
                        string[] mapArray = mappings.Split(',');
                        foreach (string mapping in mapArray)
                        {
                            _mapper.MapDataTypeToGroup(mapping.Trim(), group);
                        }
                    }
                }
            }
            else
                throw new Exception("No Group definitions in config");
        }

        public Group GetGroup(string name)
        {
            return _groups.FirstOrDefault(g => g.Name == name);
        }

        public Group GetGroupForDataType(string dataType)
        {
            return _mapper.GetGroupForDataType(dataType);
        }
    }
}