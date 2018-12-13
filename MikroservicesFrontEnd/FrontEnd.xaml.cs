using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Threading.Tasks;
using WinRTXamlToolkit.Controls.DataVisualization.Charting;

// Die Elementvorlage "Leere Seite" wird unter https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x407 dokumentiert.

namespace MikroservicesFrontEnd
{
    /// <summary>
    /// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
    public sealed partial class FrontEnd : Page
    {
        public FrontEnd()
        {
            this.InitializeComponent();
            EntryManager.FetchAllData();
            //Task.Delay(7000).Wait();
            LoadData();
        }

        public void LoadData()
        {
            try
            {
                Entry entry = EntryManager.GetCurrentTemperature();
                tbxTemperatureT.Text = "Aktuelle Temperatur: " + entry.Value + " °C \n\nLetztes Update: " + entry.Time.ToString("MM/dd/yyyy HH:mm");
                entry = EntryManager.GetCurrentPressure();
                tbxPressureT.Text = "Aktueller Luftdruck: " + entry.Value + " bar \n\nLetztes Update: " + entry.Time.ToString("MM/dd/yyyy HH:mm");

                entry = EntryManager.GetTemperatureMidYesterday();
                tbxTemperatureY.Text = "Mittlere Temperatur: " + entry.Value + " °C";
                entry = EntryManager.GetPressureMidYesterday();
                tbxPressureY.Text = "Mittlerer Luftdruck: " + entry.Value + " bar";

                entry = EntryManager.GetTemperatureMidLastweek();
                tbxTemperatureW.Text = "Mittlere Temperatur: " + entry.Value + " °C";
                entry = EntryManager.GetCurrentPressure();
                tbxPressureW.Text = "Mittlerer Luftdruck: " + entry.Value + " bar";

                ((LineSeries)lineChartToday.Series[0]).ItemsSource = EntryManager.GetTemperatureDataOfToday();
                ((LineSeries)lineChartYesterday.Series[0]).ItemsSource = EntryManager.GetTemperatureDataOfYesterday();
                ((LineSeries)lineChartLastWeek.Series[0]).ItemsSource = EntryManager.GetTemperatureDataOfLastWeek();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
        }
    }
}
