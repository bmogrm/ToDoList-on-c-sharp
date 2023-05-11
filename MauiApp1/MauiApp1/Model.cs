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

        public string TaskName { get => taskName;
            set { taskName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TaskName)));
            }
        }

        public bool Status { get => status;
            set { status = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Status)));
            } 
        }

        public Color Category { get => category;
        set { category = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Category)));}
        }
    }


}
