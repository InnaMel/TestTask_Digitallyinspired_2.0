using System;
using System.Collections.Generic;
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
using TestTask_Junior_MelnikovaInna_2._0.ViewModels;

namespace TestTask_Junior_MelnikovaInna_2._0
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainWindowViewModel MainWindowVM = new MainWindowViewModel();
            MainWindowVM.Task3Obj = new Task3ViewModel();
            MainWindowVM.Task4Obj = new Task4ViewModel();
            MainWindowVM.Task5Obj = new Task5ViewModel();

            this.DataContext = MainWindowVM;
            if (MainWindowVM.CloseMainWindow == null)
                MainWindowVM.CloseMainWindow = new Action(this.Close);
        }
    }
}
