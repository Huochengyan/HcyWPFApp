using HcyWpfApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.Pkcs;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HcyWpfApp.Views
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<UserInfo> users = new List<UserInfo>();
            for (int i = 0; i < 99; i++)
            {
                UserInfo userInfo = new UserInfo();
                userInfo.Id = i + 1;
                userInfo.Address = "sd"+ new Random().Next().ToString();
                userInfo.Email=new Random().Next().ToString()+"@qq.com";
                userInfo.Name = "name_" +i.ToString();
                users.Add(userInfo);
            }
            this.datagrid_main.ItemsSource = users;
        }

        private void DataGrid_CurrentCellChanged(object sender, EventArgs e)
        {
            Console.WriteLine(sender);
        }

        private void datagrid_main_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            Console.WriteLine(sender);
        }

        private void datagrid_main_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            try
            {
                if (this.datagrid_main.SelectedItem != null)
                {
                    int selectCount = this.datagrid_main.SelectedItems.Count;
                    if (selectCount == 1)
                    {
                        UserInfo userInfo = (UserInfo)this.datagrid_main.SelectedItem;

                        if (userInfo != null)
                        {
                            //不是复选框就是数据列
                            if ((e.EditingElement as CheckBox).IsChecked == true)
                            {

                            }
                            else
                            {
                                ConvertInfo(userInfo, e.Column.Header.ToString(), (e.EditingElement as TextBox).Text.ToString());
                            }
                        }

                    }
                }
            }catch (Exception ex) {
               // MessageBox.Show(ex.ToString());
            }
        }

        private UserInfo ConvertInfo(UserInfo userinfo, string header, string editValue) {
            PropertyInfo[] props = userinfo.GetType().GetProperties();
            foreach (PropertyInfo prop in props)
            {
                string propName = prop.Name;
                if (propName.ToUpper() == header.ToUpper())
                {

                    if (prop.PropertyType == typeof(string))
                    {
                        prop.SetValue(userinfo, editValue, null);
                    }
                    if (prop.PropertyType == typeof(int))
                    {
                        prop.SetValue(userinfo, int.Parse(editValue), null);
                    }
                    Console.WriteLine(propName +"["+header+"]->"+editValue);
                }
            }
            return userinfo;
        }
    }
}
