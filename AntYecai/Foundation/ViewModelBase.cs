namespace AntYecai.Foundation
{
    public class ViewModelBase : NotificationObject
    {
        private ViewModelContainer _viewModelContainer;

        public ViewModelBase()
        {
            
        }

        public void SetContainer(ViewModelContainer container)
        {
            _viewModelContainer = container;
        }

        public ViewModelContainer GetContainer()
        {
            return _viewModelContainer;
        }

        public T GetViewModel<T>() where T : ViewModelBase
        {
            return _viewModelContainer.GetViewModel<T>();
        }

    }
}
