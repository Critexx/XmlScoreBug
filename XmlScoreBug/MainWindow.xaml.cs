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

        private void BtnFoul_Click(object sender, RoutedEventArgs e)
        {
            xmlHandler.FoulChange(sender);
            DataContext = xmlHandler.match;
        }

        private void btnFoulClear_Click(object sender, RoutedEventArgs e)
        {
            xmlHandler.ClearFoul();
            DataContext = xmlHandler.match;
        }

        private void BtnChangeTime_Click(object sender, RoutedEventArgs e)
        {
            xmlHandler.ChangeTime(sender);
            DataContext = xmlHandler.match;

        }

        private void btnTimePlayStop_Click(object sender, RoutedEventArgs e)
        {
            if (BtnTimePlayStop.Content.ToString() == "Play")
            {
                xmlHandler.match.Play();
                BtnTimePlayStop.Content = "Stop";
                BtnTimePlusMin.IsEnabled = false;
                BtnTimeMinusMin.IsEnabled = false;
                BtnTimePlusSec.IsEnabled = false;
                BtnTimeMinusSec.IsEnabled = false;
                BtnTimePlus10Min.IsEnabled = false;
                BtnTimeReset.IsEnabled = false;
            }
            else
            {
                xmlHandler.match.Stop();
                BtnTimePlayStop.Content = "Play";
                BtnTimePlusMin.IsEnabled = true;
                BtnTimeMinusMin.IsEnabled = true;
                BtnTimePlusSec.IsEnabled = true;
                BtnTimeMinusSec.IsEnabled = true;
                BtnTimePlus10Min.IsEnabled = true;
                BtnTimeReset.IsEnabled = true;
            }
        }
    }
}
