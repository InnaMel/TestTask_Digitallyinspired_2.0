using System;
using System.Windows;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask_Junior_MelnikovaInna_2._0.ViewModels;

namespace TestTask_Junior_MelnikovaInna_2._0
{
    public class MainWindowViewModel : BindingItems
    {
        public MainWindowViewModel()
        {
            ButtonMinimazing = new RelayCommand(()=> CurrentWindowState = WindowState.Minimized);
            ButtonMaximazing = new RelayCommand(() => CurrentWindowState = WindowState.Maximized);
            ButtonClosing = new RelayCommand(() => CloseMainWindow());

            Task3ToGo = new RelayCommand((()=>
            {
                Task3Obj.IsVisibleState = Visibility.Visible;

                if (Task4Obj.IsVisibleState == Visibility.Visible)
                    Task4Obj.IsVisibleState = Visibility.Collapsed;

                if (Task5Obj.IsVisibleState == Visibility.Visible)
                    Task5Obj.IsVisibleState = Visibility.Collapsed;
            }), "Task3" );

            Task4ToGo = new RelayCommand((() =>
            {
                Task4Obj.IsVisibleState = Visibility.Visible;

                if (Task3Obj.IsVisibleState == Visibility.Visible)
                    Task3Obj.IsVisibleState = Visibility.Collapsed;

                if (Task5Obj.IsVisibleState == Visibility.Visible)
                    Task5Obj.IsVisibleState = Visibility.Collapsed;
            }), "Task4");

            Task5ToGo = new RelayCommand((() =>
            {
                Task5Obj.IsVisibleState = Visibility.Visible;

                if (Task3Obj.IsVisibleState == Visibility.Visible)
                    Task3Obj.IsVisibleState = Visibility.Collapsed;

                if (Task4Obj.IsVisibleState == Visibility.Visible)
                    Task4Obj.IsVisibleState = Visibility.Collapsed;
            }), "Task5");
        }

        public RelayCommand ButtonMinimazing { get; set; }
        public RelayCommand ButtonMaximazing { get; set; }
        public RelayCommand ButtonClosing { get; set; }
        public Action CloseMainWindow { get; set; }

        WindowState currentWindowState;
        public WindowState CurrentWindowState
        {
            get {return currentWindowState; }
            set {SetField(ref currentWindowState, value); }
        }

        public RelayCommand Task3ToGo { get; set; }
        public RelayCommand Task4ToGo { get; set; }
        public RelayCommand Task5ToGo { get; set; }

        public Task3ViewModel Task3Obj { get; set; }
        public Task4ViewModel Task4Obj { get; set; }
        public Task5ViewModel Task5Obj { get; set; }
    }
}
