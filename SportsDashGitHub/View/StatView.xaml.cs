﻿using SportsDash.ViewModel;
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

namespace SportsDash.View
{
    /// <summary>
    /// Interaction logic for StatView.xaml
    /// </summary>
    public partial class StatView : UserControl
    {
        public StatView()
        {
            InitializeComponent();
            this.DataContext = new StatsVM();
        }
    }
}
