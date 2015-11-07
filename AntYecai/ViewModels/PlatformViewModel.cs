using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AntYecai.Foundation;

namespace AntYecai.ViewModels
{
    class PlatformViewModel : NotificationObject
    {
        public PlatformViewModel()
        {
            RegisterViewModel = new RegisterViewModel();
            LoginViewModel = new LoginViewModel();
        }

        public RegisterViewModel RegisterViewModel { get; private set; }

        public LoginViewModel LoginViewModel { get; private set; }
    }
}
