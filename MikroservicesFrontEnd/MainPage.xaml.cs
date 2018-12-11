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
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            //DASConnection.TestDataWeek();
            EntryManager.FetchAllData();
            Task.Delay(5000).Wait();
            LoadData();
        }

        public void LoadData()
        {
            //Entry entry = DASConnection.TestDataCurrent();
            //tbxTemperatureT.Text = "Zeit: " + entry.Time.TimeOfDay.ToString() + " \n Wert: " + entry.Value + " °C";

            ((LineSeries)lineChartToday.Series[0]).ItemsSource = EntryManager.GetDataOfToday();
            //((LineSeries)lineChartYesterday.Series[0]).ItemsSource = DASConnection.TestDataDay();
            //((LineSeries)lineChartLastWeek.Series[0]).ItemsSource = DASConnection.TestDataWeek();
            //((LineSeries)lineChartLastWeek.Series[0]).
        }
    }
}
