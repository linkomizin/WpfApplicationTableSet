using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApplicationTableSet.StaticResource
{
    internal static class StaticResource  
    {
        private static Dictionary<string, object> staticResourceDictionary = new Dictionary<string, object>();

        public static Dictionary<string, object> StaticResourceDictionary
        {
            get { return staticResourceDictionary; }
            set { staticResourceDictionary = value; }
        }
    }
}
