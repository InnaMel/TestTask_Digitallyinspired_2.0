using HelixToolkit.Wpf;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Media3D;

namespace TestTask_Junior_MelnikovaInna_2._0.ViewModels
{
    public class Task4ViewModel : BindingItems
    {
        public Task4ViewModel()
        {
            Load = new RelayCommand((() => Load_Async()), "Load");
            Clear = new RelayCommand((() => NewModel = null), "Clear");
        }


        public RelayCommand Load { get; set; }
        public RelayCommand Clear { get; set; }

        Model3DGroup newModel = null;
        public Model3DGroup NewModel
        {
            get { return newModel; }
            set { SetField(ref newModel, value); }
        }
        private async void Load_Async()
        {
            // *** Opening dialog for choosing the object
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Obj files (*.obj)| *.obj";
            openFileDialog.InitialDirectory = Environment.CurrentDirectory;

            // *** Disable the buttons
            Load.IsEnabledModificate = false;
            Clear.IsEnabledModificate = false;

            // *** Getting full path of the object
            string fullPath = "Empty";
            try
            {
                if (openFileDialog.ShowDialog() == true)
                    fullPath = openFileDialog.FileName;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Oops, something went wrong ->" + ex.Message);
            }

            await Task.Run(() =>
            {
                // *** Getting directly the object
                ObjReader CurrentHelixObjReader = new ObjReader();

                try
                {
                    NewModel = CurrentHelixObjReader.Read(fullPath);
                    NewModel.Freeze();
                }
                catch (Exception)
                {
                    NewModel = null;
                }
            });

            // *** Enable the buttons
            Load.IsEnabledModificate = true;
            Clear.IsEnabledModificate = true;
        }

        Visibility isVisibleState = Visibility.Collapsed;
        public Visibility IsVisibleState
        {
            get { return isVisibleState; }
            set { SetField(ref isVisibleState, value); }
        }

    }
}
