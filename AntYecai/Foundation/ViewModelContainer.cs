using System;
using System.Collections.Generic;

namespace AntYecai.Foundation
{
    public class ViewModelContainer
    {
        private readonly Dictionary<Type, ViewModelBase> _viewModelMap = new Dictionary<Type, ViewModelBase>();

        public T GetViewModel<T>() where T : ViewModelBase
        {
            return _viewModelMap[typeof(T)] as T;
        }

        public void AddViewModel<T>(T viewModelBase) where T : ViewModelBase
        {
            _viewModelMap.Add(typeof(T), viewModelBase);
        }
    }
}
