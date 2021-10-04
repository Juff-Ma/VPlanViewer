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
using VPlanGetter;
using System.Xml.Serialization;
using System.IO;

namespace VPLanViewer
{
    /// <summary>
    /// Interaktionslogik für Freietage.xaml
    /// </summary>
    public partial class Freietage : Page
    {
        public Freietage()
        {
            InitializeComponent();
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Home());
        }

        private void View_Loaded(object sender, RoutedEventArgs e)
        {
            var reader = new StreamReader("config.xml");
            var settings = new XmlSerializer(typeof(config)).Deserialize(reader) as config;
            reader.Close();
            VPRaw VP;
            if (settings.OnlyManualRefresh.used)
            {
                VP = new VPRaw("omrTemp.xml", false);
            }
            else
            {
                VP = new VPRaw(settings.customxmlfeed.feed.text, settings.customxmlfeed.feed.online);
            }
            foreach (object item in VP.Items)
            {
                if (item is vpFreietage)
                {
                    foreach (uint ft in (item as vpFreietage).ft)
                    {
                        char[] temp1 = ft.ToString().ToCharArray();
                        char temp21 = temp1[0];
                        char temp22 = temp1[1];
                        string temp2 = "20" + new string(new char[] { temp21, temp22 });
                        char temp31 = temp1[2];
                        char temp32 = temp1[3];
                        string temp3 = new string(new char[] { temp31, temp32 });
                        char temp41 = temp1[4];
                        char temp42 = temp1[5];
                        string temp4 = new string(new char[] { temp41, temp42 });
                        DateTime day = new DateTime(Convert.ToInt32(temp2), Convert.ToInt32(temp3), Convert.ToInt32(temp4));
                        Label label = new Label();
                        label.Content = day.ToShortDateString();
                        label.FontSize = 15;
                        View.Children.Add(label);
                    }
                }
            }
        }
    }
}
