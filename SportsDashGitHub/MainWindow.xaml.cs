﻿using System.Windows;

namespace SportsDash
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

        private void CloseButton_Click(object sender, RoutedEventArgs e ) 
        {
            Application.Current.Shutdown();
        }
    }
}
