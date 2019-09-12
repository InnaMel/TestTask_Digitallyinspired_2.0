﻿using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace TestTask_Junior_MelnikovaInna_2._0
{
    public class BindingItems : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void SetField<T>(ref T field, T value, [CallerMemberName] string propName = "")
        {
            if (!EqualityComparer<T>.Default.Equals(field, value))
            {
                field = value;
                RaisePropertyChanged(propName);
            }
        }
    }
}
