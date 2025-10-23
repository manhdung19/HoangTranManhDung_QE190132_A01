﻿using System;
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
using System.Windows.Shapes;
using BusinessObjects;
using HoangTranManhDungWPF.ViewModels.Customer;

namespace HoangTranManhDungWPF.Views
{
    /// <summary>
    /// Interaction logic for CustomerWindow.xaml
    /// </summary>
    public partial class CustomerWindow : Window
    {
        public CustomerWindow(BusinessObjects.Customer customer)
        {
            InitializeComponent();
            this.DataContext = new CustomerWindowViewModel(customer);
        }
    }
}
