using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Model
{
    public class Model : INotifyPropertyChanged
    {
        private string taskName;
        private bool status;
        private Color category;
        public event PropertyChangedEventHandler PropertyChanged;

        public string TaskName
        {
            get => taskName;
            set 
            { 
                taskName = value;
                OnPropertyChanged(nameof(TaskName));
            }
        }

        public bool Status
        {
            get => status;
            set 
            { 
                status = value;
                OnPropertyChanged(nameof(Status));
            } 
        }

        public Color Category
        {
            get => category;
            set
            {
                category = value;
                OnPropertyChanged(nameof(Category));
            }
        }
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }


}
