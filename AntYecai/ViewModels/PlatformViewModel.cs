using AntYecai.Foundation;

namespace AntYecai.ViewModels
{
    class PlatformViewModel : NotificationObject
    {
        public PlatformViewModel()
        {
            RegisterViewModel = new RegisterViewModel();
            LoginViewModel = new LoginViewModel();
            GameEntryViewModel = new GameEntryViewModel();
        }

        public RegisterViewModel RegisterViewModel { get; private set; }

        public LoginViewModel LoginViewModel { get; private set; }

        public GameEntryViewModel GameEntryViewModel { get; private set; }
    }
}
