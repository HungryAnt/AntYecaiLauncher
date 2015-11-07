﻿using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media.Animation;
using AntYecai.Models;
using AntYecai.ViewModels;

namespace AntYecai.Views
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private DoubleAnimationUsingKeyFrames NotifyPanelAnimation { get; set; }
        private Style NotifySuccessStyle { get; set; }
        private Style NotifyFailedStyle { get; set; }

        private PlatformViewModel PlatformViewModel { get; set; }
        private bool ForceClosing { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            InitDataContext();
            InitViews();
            NotifyPanelAnimation = FindResource("NotifyPanelAnimation") as DoubleAnimationUsingKeyFrames;
            NotifySuccessStyle = FindResource("NotifySuccessStyle") as Style;
            NotifyFailedStyle = FindResource("NotifyFailedStyle") as Style;
            InitNotifyIcon();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (!ForceClosing)
            {
                this.Hide();
                e.Cancel = true;
                return;
            }
            base.OnClosing(e);
        }

        private void InitNotifyIcon()
        {
            NotifyIcon notifyIcon = new NotifyIcon
                {
                    BalloonTipText = "Ant版野菜部落",
                    Icon = Properties.Resources.ant
                };
            notifyIcon.MouseClick += (sender, args) =>
                {
                    if (args.Button == MouseButtons.Left)
                    {
                        this.Show();
                        this.WindowState = WindowState.Minimized;
                        this.WindowState = WindowState.Maximized;
                    }
                };

            ContextMenuStrip contextMenuStrip = new ContextMenuStrip();

//            addNewNotifyIconMenuItem(contextMenuStrip, "显示", () =>
//                {
//                    WindowState = WindowState.Minimized;
//                    WindowState = WindowState.Maximized;
//                });

            addNewNotifyIconMenuItem(contextMenuStrip, "退出", () =>
                {
                    ForceClosing = true;
                    Close();
                });

            notifyIcon.ContextMenuStrip = contextMenuStrip;
            notifyIcon.Visible = true;
        }

        private static void addNewNotifyIconMenuItem(ContextMenuStrip contextMenuStrip, String text, Action action)
        {
            ToolStripMenuItem menuItem = new ToolStripMenuItem();
            menuItem.Text = text;
            // menuItem.Image = Properties.Resources.PerfCenterCpl.ToBitmap();
            menuItem.Click += (sender, args) => action();
            contextMenuStrip.Items.Add(menuItem);
        }

        private void InitDataContext()
        {
            PlatformViewModel = new PlatformViewModel();
        }

        private void InitViews()
        {
            loginView.InitDataContext(PlatformViewModel.LoginViewModel);

            RegisterView registerView = new RegisterView();
            registerView.InitDataContext(PlatformViewModel.RegisterViewModel);

            GameEntryView gameEntryView = new GameEntryView();
            gameEntryView.InitDataContext(PlatformViewModel.GameEntryViewModel);
            loginView.Register += () =>
                {
                    registerView.StartToDisplay();
                    majorPanel.Child = registerView;
                    StartMajorPanelAnimation();
                };
            registerView.Cancel += () =>
                {
                    majorPanel.Child = loginView;
                    StartMajorPanelAnimation();
                };

            // 注册新用户
            registerView.Register += () => RunBackgroundTask(
                () => PlatformViewModel.RegisterViewModel.Register(),
                () =>
                    {
                        majorPanel.Child = loginView;
                        StartMajorPanelAnimation();
                        return "注册成功!";
                    }
                    );
            
            // 登录
            loginView.Login += () => RunBackgroundTask(
                () =>
                    {
                        UserLoginResult userLoginResult = PlatformViewModel.LoginViewModel.Login();
                        if (!userLoginResult.Success)
                        {
                            throw new ApplicationException("用户名或密码错误");
                        }
                        PlatformViewModel.GameEntryViewModel.LoginName = PlatformViewModel.LoginViewModel.LoginName;
                        PlatformViewModel.GameEntryViewModel.UserId = userLoginResult.UserId;
                    },
                () =>
                    {
                        majorPanel.Child = gameEntryView;
                        StartMajorPanelAnimation();
                        return "登录成功!";
                    }
                    );
            
            gameEntryView.Logout += () =>
                {
                    majorPanel.Child = loginView;
                    StartMajorPanelAnimation();
                };
        }

        private void StartMajorPanelAnimation()
        {
            double prevHeight = majorPanel.DesiredSize.Height;
            UpdateLayout();
            double newHeight = majorPanel.DesiredSize.Height;

            DoubleAnimation heightAnimation = new DoubleAnimation()
                {
                    From = prevHeight,
                    To = newHeight,
                    Duration = TimeSpan.FromSeconds(0.25),
                    AccelerationRatio = 1, // 前30%时间加速
                    DecelerationRatio = 0, // 后30%时间减速
                    RepeatBehavior = new RepeatBehavior(1)
                };
            heightAnimation.Completed += (sender, args) =>
                {
                    // 终于解决 2015-11-1 01:54:35
                    // http://codedmi.com/questions/3388225/wpf-animation-on-grid-height
                    majorPanel.BeginAnimation(Border.HeightProperty, null);
                };
            majorPanel.BeginAnimation(Border.HeightProperty, heightAnimation);
        }

        private void StartNotifyPanelAnimation()
        {
            notifyPanel.BeginAnimation(Grid.HeightProperty, NotifyPanelAnimation);
        }

        private void Homepage_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Process.Start(GameConfig.HomePageUrl);
        }

        private void Author_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            AuthorWindow authorWindow = new AuthorWindow();
            authorWindow.Owner = this;
            authorWindow.ShowDialog();
        }

        private void RunBackgroundTask(Action workAction, Func<String> completeAction)
        {
            waitingPanel.Visibility = Visibility.Visible;
            var backgroundWorker = new BackgroundWorker()
                {
                    WorkerReportsProgress = true,
                    WorkerSupportsCancellation = true
                };
            backgroundWorker.DoWork += (sender, args) =>
                {
                    if (workAction != null)
                    {
                        workAction();
                    }
                };
            backgroundWorker.RunWorkerCompleted += (sender, args) =>
                {
                    if (args.Error != null)
                    {
                        notifyTextBlock.Text = args.Error.Message;
                        notifyBorder.Style = NotifyFailedStyle;
                    }
                    else
                    {
                        if (completeAction != null)
                        {
                            notifyTextBlock.Text = completeAction();
                        }
                        else
                        {
                            notifyTextBlock.Text = "成功!";
                        }
                        notifyBorder.Style = NotifySuccessStyle;
                    }
                    waitingPanel.Visibility = Visibility.Hidden;
                    StartNotifyPanelAnimation();
                };
            backgroundWorker.RunWorkerAsync();
        }
    }
}
