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
using System.Net;
using System.Xml.Serialization;
using VPlanGetter;

namespace VPLanViewer
{
    /// <summary>
    /// Interaktionslogik für Page1.xaml
    /// </summary>
    public partial class Home : Page
    {
        config Settings;
        
        public Home()
        {
            InitializeComponent();
        }

        private void infos_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Freietage());
        }

        private void refresh_Click(object sender, RoutedEventArgs e)
        {
            if (Settings.OnlyManualRefresh.used)
            {
                VPRaw temp1 = new VPRaw(Settings.customxmlfeed.feed.text, Settings.customxmlfeed.feed.online);
                vp temp2 = new vp();
                temp2.Items = temp1.Items;
                var writer = new StreamWriter("omrTemp.xml");
                new XmlSerializer(typeof(vp)).Serialize(writer, temp2);
                writer.Flush();
                writer.Close();
                LoadVP();
            }
            else
            {
                LoadVP();
            }
        }

        private void settings_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Settings());
        }

        private void tage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!tage.Items.IsEmpty)
            {
                VPRaw VP;
                if (Settings.OnlyManualRefresh.used)
                {
                    VP = new VPRaw("omrTemp.xml", false);
                }
                else
                {
                    VP = new VPRaw(Settings.customxmlfeed.feed.text, Settings.customxmlfeed.feed.online);
                }
                string currentHeader = "null";
                foreach (object item in VP.Items)
                {
                    if (item is vpKopf)
                    {
                        currentHeader = (item as vpKopf).GetHeader();
                    }


                    if ((tage.SelectedItem as ComboBoxItem).Name == currentHeader)
                    {
                        if (item is vpKopf)
                        {
                            vpKopf Item = item as vpKopf;
                            AddInfos(Item.datum, Item.kopfinfo.abwesendl, Item.kopfinfo.aenderungl, Item.kopfinfo.aenderungk);
                        }
                        if (item is vpAufsichten)
                        {
                            vpAufsichten Item = item as vpAufsichten;
                            List<Label> labels = new List<Label>();
                            foreach (vpAufsichtenAufsichtzeile zeile in Item.aufsichtzeile)
                            {
                                labels.Add(new Label() { Content = zeile.aufsichtinfo });
                            }
                            AddInfos(labels.ToArray(), true);
                        }
                        if (item is vpFuss)
                        {
                            vpFuss Item = item as vpFuss;
                            List<Label> labels = new List<Label>();
                            foreach (vpFussFusszeile zeile in Item.fusszeile)
                            {
                                labels.Add(new Label() { Content = zeile.fussinfo });
                            }
                            AddInfos(labels.ToArray(), false);
                        }
                        if (item is vpHaupt)
                        {
                            Klasse.Children.Clear();
                            Stunde.Children.Clear();
                            Fach.Children.Clear();
                            Lehrer.Children.Clear();
                            Raum.Children.Clear();
                            Info.Children.Clear();
                            vpHaupt Item = item as vpHaupt;
                            foreach (vpHauptAktion aktion in Item.aktion)
                            {
                                Klasse.Children.Add(GetFromTemplate(aktion.klasse, false));
                                Stunde.Children.Add(GetFromTemplate(aktion.stunde, false));
                                Fach.Children.Add(GetFromTemplate(aktion.fach.Value, aktion.fach.fageaendert == "ae"));
                                Lehrer.Children.Add(GetFromTemplate(aktion.lehrer.Value, aktion.lehrer.legeaendert == "ae"));
                                Raum.Children.Add(GetFromTemplate(aktion.raum.Value, aktion.raum.rageaendert == "ae"));
                                Info.Children.Add(GetFromTemplate(aktion.info, false));
                            }
                        }
                    }
                }
            }
        }

        private void tage_Loaded(object sender, RoutedEventArgs e)
        {
            Retry:
            try
            {
                var reader = new StreamReader("config.xml");
                Settings = new XmlSerializer(typeof(config)).Deserialize(reader) as config;
                reader.Close();
                LoadVP();
            }
            catch
            {
                MessageBox.Show("Fehler beim laden bitte überprüfe deine Einstellungen und Internetverbidung", "Ladefehler");
                new Crash().ShowDialog();
                goto Retry;
            }
        }

        private void LoadVP()
        {
            VPRaw VP;
            if (Settings.OnlyManualRefresh.used)
            {
                VP = new VPRaw("omrTemp.xml", false);
            }
            else
            {
                VP = new VPRaw(Settings.customxmlfeed.feed.text, Settings.customxmlfeed.feed.online);
            }
            tage.Items.Clear();
            bool first = true;
            foreach (object item in VP.Items)
            {
                if (item is vpKopf)
                {
                    var tagItem = new ComboBoxItem() { Content = (item as vpKopf).titel, Name = (item as vpKopf).GetHeader() };
                    tage.Items.Add(tagItem);
                    if (first)
                    {
                        (tage.Items[0] as ComboBoxItem).IsSelected = true;
                        first = false;
                    }
                }

            }
        }



        public void AddInfos(string datum, string abwelae, string lehrmae, string klamitae)
        {
            Datum.Content = datum;
            ALehrer.Content = abwelae;
            LmitAe.Content = lehrmae;
            KmitAe.Content = klamitae;
            
        }

        public void AddInfos(Label[] geAuf, bool geauf)
        {
            
            if (geauf)
            {
                GeAufs.Children.Clear();
                foreach (Label label in geAuf)
                {
                    GeAufs.Children.Add(label);
                }
            }
            else
            {
                AddInfos(geAuf);
            }
        }

        public void AddInfos(Label[] zuInfos)
        {
            ZuInfos.Children.Clear();
            foreach (Label label in zuInfos)
            {
                ZuInfos.Children.Add(label);
            }
        }

        public Label GetFromTemplate(string content, bool colored)
        {
            Label Template = new Label();
            Template.BorderBrush = Brushes.Black;
            if (content == null)
            {
                Template.BorderThickness = new Thickness(1);
                Template.Content = "　";
            }
            else if (content == "")
            {
                Template.BorderThickness = new Thickness(1);
                Template.Content = "　";
            }
            else if (content == " ")
            {
                Template.BorderThickness = new Thickness(1);
                Template.Content = "　";
            }
            else
            {
                Template.BorderThickness = new Thickness(1);
                Template.Content = content;
                if (colored)
                {
                    Template.Foreground = Brushes.Red;
                }
            }
            return Template;
        }
    }

    public static class MyExtensions
    {
        public static string GetHeader(this vpKopf kopf)
        {
            string str = kopf.titel;
            string[] charsToRemove = new string[] { "0", "1", "2", "3", "4", "5", "6,","7","8","9", ",", " ", ".", "(", ")", "-", ","};
            foreach (var c in charsToRemove)
            {
                str = str.Replace(c, string.Empty);
            }
            return str;
        }
    }
}
