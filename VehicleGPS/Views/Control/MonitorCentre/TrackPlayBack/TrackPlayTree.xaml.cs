﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using VehicleGPS.ViewModels.MonitorCentre.TrackPlayBack;

namespace VehicleGPS.Views.Control.MonitorCentre.TrackPlayBack
{
    /// <summary>
    /// TrackPlayTree.xaml 的交互逻辑
    /// </summary>
    public partial class TrackPlayTree : Window
    {
        public TrackPlayTree(object parentVM)
        {
            InitializeComponent();
            InitButton();
            this.DataContext = new TrackPlayTreeViewModel(parentVM);
        }

        /*设置“设置按钮”“刷新按钮”样式*/
        private void InitButton()
        {
            SetButton(imgBtn_Setting);
            SetButton(imgBtn_Refresh);
        }
        private void SetButton(ImageButton imgBtn)
        {
            imgBtn.Margin = new Thickness(2, 0, 2, 0);
            imgBtn.VerticalAlignment = VerticalAlignment.Center;
            imgBtn.HorizontalAlignment = HorizontalAlignment.Center;

            imgBtn.TextFontColor = new SolidColorBrush(Colors.Black);
            imgBtn.TextMargin = new Thickness(3);

            imgBtn.MouseOverBorderBackground = new SolidColorBrush(Color.FromRgb(255, 243, 206));
            imgBtn.MouseOverBorderCorner = new CornerRadius(3);

            if (imgBtn.Name == "imgBtn_Setting")
            {
                imgBtn.AddHandler(ImageButton.MouseLeftButtonUpEvent, new MouseButtonEventHandler(opereate_Clicked), true);
            }
        }

        private void opereate_Clicked(object sender, RoutedEventArgs e)
        {
            switch (((ImageButton)sender).Name)
            {
                case "imgBtn_Setting":
                    Window win = new MonitorTreeSetting(this.DataContext);
                    win.Owner = Window.GetWindow(this);
                    win.ShowDialog();
                    break;
                default:
                    break;
            }
        }
    }
}
