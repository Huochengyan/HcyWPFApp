using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HcyWpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// 工具定义
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItem_Tools_Click(object sender, RoutedEventArgs e)
        {
            string headerText= ((System.Windows.Controls.HeaderedItemsControl)sender).Header.ToString();
            switch (headerText)
            {
                case "工具1":
                    main_demo.Page1 page1 = new main_demo.Page1();
                    AddTablePage(headerText, page1);
                    break;
                case "工具2":
                    main_demo.Page2 page2 = new main_demo.Page2();
                    AddTablePage(headerText, page2);
                    break;
                default:
                    break;
            }
        }

        private void AddTablePage(string title,Page page) {
            TabItem tab = new TabItem();
            tab.Header = title;
            tab.Name = title;
            tab.Content = page.Content;
            foreach (TabItem item in this.tableControl_main.Items)
            {
                if (item.Name == tab.Name) {
                    this.tableControl_main.SelectedItem = item;
                    return;
                }
            }

            this.tableControl_main.Items.Add(tab);
            this.tableControl_main.SelectedItem = tab;
        }
    }
}
