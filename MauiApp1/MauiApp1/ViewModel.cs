using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MauiApp1.Model;

namespace MauiApp1.ViewModel
{
    class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand createTask { get;  }
        public ICommand deleteTask { get; set; }
        //public ICommand changeCategory { get; set; }

        public ObservableCollection<Model.Model> ListTasks { get; set; } =
        new ObservableCollection<Model.Model>();
        public Model.Model task;

        private void Create(string entry)
        {
            var color = Color.FromRgb(1,2,3);
            ListTasks.Add(new Model.Model() {TaskName = entry, Status = false, /*Category = color*/});
        }

        private void Delete(Model.Model selTask) => ListTasks.Remove(selTask);

        private void ChangeCategory()
        {

        }

        public async void EditTask()
        {
            string text = await Application.Current.MainPage.DisplayPromptAsync("Edditing", "Current task", initialValue: selectedTask.TaskName);
            selectedTask.TaskName = text;
            selectedTask = null;
        }

        public Model.Model selectedTask
        {
            get => task;
            set
            {
                if (task != value)
                {
                    task = value;
                    if (task != null)
                        EditTask();
                }
            OnPropertyChanged(nameof(selectedTask));
            }
        }

        public ViewModel()
        {
            task = new Model.Model();
            createTask = new Command<string>(Create);
            deleteTask = new Command<Model.Model>(Delete);
            //changeCategory = new Command<Model.Model>(ChangeCategory);
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
