using DeviceDefinitions;
using System.Reflection;
using System.Windows;

namespace DeviceExchangeTemplate
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Assembly deviceLib = Assembly.LoadFrom("Devices/VirtualDevice.dll");

            AbstractDevice device = deviceLib.CreateInstance("VirtualDevice.Device") as AbstractDevice;

            if (device != null)
            {
                _Test.Text = device?.Name;
            }

        }
    }
}
