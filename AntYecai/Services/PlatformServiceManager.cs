using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AntYecai.Services
{
    public class PlatformServiceManager
    {
        private static readonly PlatformServiceManager _instance = new PlatformServiceManager();

        public static PlatformServiceManager Instance
        {
            get { return _instance; }
        }

        private readonly Dictionary<Type, Object> _servicesDict = new Dictionary<Type, object>();

        public T GetService<T>() where T:class, new()
        {
            Type type = typeof (T);
            if (!_servicesDict.ContainsKey(type))
            {
                _servicesDict[type] = new T();
            }
            return _servicesDict[type] as T;
        }
    }
}
