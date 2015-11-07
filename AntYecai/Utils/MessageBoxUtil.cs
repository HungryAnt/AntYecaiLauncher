using System.Windows;
using MessageBox = Xceed.Wpf.Toolkit.MessageBox;

namespace AntYecai.Tools
{
    public static class MessageBoxUtil
    {
        public static bool AskForConfirmation(string question)
        {
            return MessageBox.Show(question,
                                   "提示",
                                   MessageBoxButton.YesNo,
                                   MessageBoxImage.Question) == MessageBoxResult.Yes;
        }

        public static void ShowError(Window owner, string message)
        {
            MessageBox.Show(owner,
                            message,
                            "错误",
                            MessageBoxButton.OK,
                            MessageBoxImage.Question);
        }

        public static void ShowError(string message)
        {
            MessageBox.Show(message,
                            "错误",
                            MessageBoxButton.OK,
                            MessageBoxImage.Question);
        }

        public static void ShowInfo(Window owner, string message)
        {
            MessageBox.Show(owner,
                            message,
                            "信息",
                            MessageBoxButton.OK,
                            MessageBoxImage.Information);
        }

        public static void ShowInfo(string message)
        {
            MessageBox.Show(message,
                            "信息",
                            MessageBoxButton.OK,
                            MessageBoxImage.Information);
        }

        public static void ShowWarning(Window owner, string message)
        {
            MessageBox.Show(owner,
                            message,
                            "警告",
                            MessageBoxButton.OK,
                            MessageBoxImage.Warning);
        }
    }
}
