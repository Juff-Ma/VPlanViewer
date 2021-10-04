using System;
using System.Collections.Generic;
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
using System.IO;
using System.Xml.Serialization;
using Microsoft.Win32;

namespace VPLanViewer
{
    /// <summary>
    /// Interaktionslogik für Settings.xaml
    /// </summary>
    public partial class Settings : Page
    {
        bool crash;
        config settings = new config();
        public Settings()
        {
            InitializeComponent();
            crash = false;
        }
        public Settings(bool crash)
        {
            InitializeComponent();
            this.crash = crash;
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            WriteNewConfig();
            NavigationService.Navigate(new Home());
        }

        private void ManulualReloadBox_Check(object sender, RoutedEventArgs e)
        {
            settings.OnlyManualRefresh.used = Convert.ToBoolean(ManulualReloadBox.IsChecked.ToString());
            WriteNewConfig();
        }

        private void CustomFeedBox_Check(object sender, RoutedEventArgs e)
        {
            settings.customxmlfeed.used = Convert.ToBoolean(CustomFeedBox.IsChecked.ToString());
            customfeed.IsEnabled = Convert.ToBoolean(CustomFeedBox.IsChecked.ToString());
            OnlineFeed.IsEnabled = Convert.ToBoolean(CustomFeedBox.IsChecked.ToString());
            WriteNewConfig();
        }

        private void DockPanel_Loaded(object sender, RoutedEventArgs e)
        {
            if (crash == true) { back.IsEnabled = false; } else { back.IsEnabled = true; }
            var reader = new StreamReader("config.xml");
            settings = new XmlSerializer(typeof(config)).Deserialize(reader) as config;
            reader.Close();
            ManulualReloadBox.IsChecked = settings.OnlyManualRefresh.used;
            CustomFeedBox.IsChecked = settings.customxmlfeed.used;
            OnlineFeed.IsChecked = settings.customxmlfeed.feed.online;
            DurchsuchenButton.IsEnabled = !settings.customxmlfeed.feed.online;
            PathBox.Text = settings.customxmlfeed.feed.text;
            if (PathBox.Text == "")
            {
                PathBox.Text = "https://www.gymnasiummarkneukirchen.de/Intern/VPlan/2012_13/aktueller%20Vetretungsplsn.xml";
                OnlineFeed.IsChecked = true;
            }
            customfeed.IsEnabled = settings.customxmlfeed.used;
            OnlineFeed.IsEnabled = settings.customxmlfeed.used;
        }

        private void OnlineFeed_Check(object sender, RoutedEventArgs e)
        {
            settings.customxmlfeed.feed.online = Convert.ToBoolean(OnlineFeed.IsChecked.ToString());
            DurchsuchenButton.IsEnabled = !Convert.ToBoolean(OnlineFeed.IsChecked.ToString());
            WriteNewConfig();
        }

        private void WriteNewConfig()
        {
            if (PathBox.Text == "")
            {
                PathBox.Text = "https://www.gymnasiummarkneukirchen.de/Intern/VPlan/2012_13/aktueller%20Vetretungsplsn.xml";
                OnlineFeed.IsChecked = true;
            }
            if (!settings.customxmlfeed.used)
            {
                PathBox.Text = "https://www.gymnasiummarkneukirchen.de/Intern/VPlan/2012_13/aktueller%20Vetretungsplsn.xml";
                settings.customxmlfeed.feed.text = "https://www.gymnasiummarkneukirchen.de/Intern/VPlan/2012_13/aktueller%20Vetretungsplsn.xml";
                OnlineFeed.IsChecked = true;
            }
            var writer = new StreamWriter("config.xml");
            new XmlSerializer(typeof(config)).Serialize(writer, settings);
            writer.Flush();
            writer.Close();
            DockPanel_Loaded(this, new RoutedEventArgs());
        }

        private void DurchsuchenButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "XML Data Files (*.xml)|*.xml|All files (*.*)|*.*";
            dialog.Title = "suche ein markup aus";
            if (dialog.ShowDialog() == true)
            {
                PathBox.Text = dialog.FileName;
                settings.customxmlfeed.feed.text = dialog.FileName;
                WriteNewConfig();
            }
        }

        private void PathBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            settings.customxmlfeed.feed.text = PathBox.Text;
            WriteNewConfig();
        }
    }
}
