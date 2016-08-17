using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
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
using System.Xml.Serialization;
using Microsoft.Win32;


namespace XmlScoreBug
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        XmlHandler xmlHandler = new XmlHandler();

        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void MenuItem_Click_Open(object sender, RoutedEventArgs e)
        {
            this.Title = xmlHandler.OpenXmlFile() + " - " +
                         System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
            DataContext = xmlHandler.match;
        }

        private void MenuItem_Click_New(object sender, RoutedEventArgs e)
        {
            this.Title = xmlHandler.NewXml() + " - " +
                         System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
            DataContext = xmlHandler.match;
        }
       
        private void MenuItem_Click_Save(object sender, RoutedEventArgs e)
        {
            xmlHandler.WriteXml();
        }

        // speichern unter
        private void MenuItem_Click_Save_As(object sender, RoutedEventArgs e)
        {
            xmlHandler.SaveXml();
        }

        private void BtnScore_Click(object sender, RoutedEventArgs e)
        {
            xmlHandler.ScoreChange(sender);
            DataContext = xmlHandler.match;
            BtnScoreUndo.IsEnabled = true;
        }

        private void BtnScoreUndo_Click(object sender, RoutedEventArgs e)
        {
            xmlHandler.UndoScore();
            DataContext = xmlHandler.match;
            BtnScoreUndo.IsEnabled = false;
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            xmlHandler.ClearScore();
            DataContext = xmlHandler.match;
            BtnScoreUndo.IsEnabled = false;
        }
    }
}
