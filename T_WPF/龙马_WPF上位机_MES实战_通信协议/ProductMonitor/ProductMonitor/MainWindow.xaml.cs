﻿using ProductMonitor.OpCommand;
using ProductMonitor.UserControls;
using ProductMonitor.ViewModels;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProductMonitor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// 视图模型
        /// </summary>
        MainWindowVM mainWindowVM = new MainWindowVM();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = mainWindowVM;
        }

        /// <summary>
        /// 显示车间详情页
        /// </summary>
        private void ShowWorkShopDetailUC()
        {
            WorkShopDetailUC workShopDetailUC = new WorkShopDetailUC();
            mainWindowVM.MonitorUC = workShopDetailUC;

            // 这段代码的目的是通过动画效果来显示WorkShopDetailUC控件，可能会使控件从下往上移动，并逐渐变得透明。这样可以为用户提供一种动态和吸引人的界面展示效果😃

            // 动画效果（由下而上）
            // 位移 移动时间  ThicknessAnimation用于改变控件的边缘厚度
            ThicknessAnimation thicknessAnimation = new ThicknessAnimation(new Thickness(0, 50, 0, -50), new Thickness(0, 0, 0, 0), new TimeSpan(0, 0, 0, 0, 400));

            // 透明度  DoubleAnimation用于改变控件的透明度
            DoubleAnimation doubleAnimation = new DoubleAnimation(0, 1, new TimeSpan(0, 0, 0, 0, 400));

            // Storyboard.SetTarget方法用于将动画与目标对象进行关联，这里将thicknessAnimation动画的目标对象设置为workShopDetailUC，将doubleAnimation动画的目标对象也设置为workShopDetailUC。
            // 这样，当动画执行时，workShopDetailUC对象的Margin和Opacity属性将发生变化，从而实现特定的动画效果。
            Storyboard.SetTarget(thicknessAnimation, workShopDetailUC);
            Storyboard.SetTarget(doubleAnimation, workShopDetailUC);

            // 这行代码将thicknessAnimation动画的目标属性设置为Margin。Margin是 WPF 中控件的一个属性，用于定义控件与周围元素的间距。通过将动画与Margin属性关联，当动画执行时，控件的边缘厚度将发生变化。
            Storyboard.SetTargetProperty(thicknessAnimation, new PropertyPath("Margin"));
            // 这行代码将doubleAnimation动画的目标属性设置为Opacity。Opacity表示控件的透明度，值为 0 时完全透明，值为 1 时完全不透明。通过将动画与Opacity属性关联，当动画执行时，控件的透明度将逐渐变化。
            Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath("Opacity"));

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(thicknessAnimation);
            storyboard.Children.Add(doubleAnimation);
            storyboard.Begin();


        }

        /// <summary>
        /// 展示详情命令
        /// </summary>
        /// <returns></returns>
        public Command ShowWorkShopDetailCmd
        {
            get
            {
                return new Command(ShowWorkShopDetailUC);
            }
        }
    }
}