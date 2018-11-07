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
            
        }

        public void TestData()
        {
            Task<string> testt = DASConnection.GetData();
            Debug.WriteLine("ANSWER:");
            testt.Wait();
            Debug.WriteLine(testt.Result);
            Debug.WriteLine("END");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Task<string> testt = DASConnection.GetData();
            Debug.WriteLine("ANSWER:");
            testt.Wait();
            Debug.WriteLine(testt.Result);
            Debug.WriteLine("END");
        }
    }
}
