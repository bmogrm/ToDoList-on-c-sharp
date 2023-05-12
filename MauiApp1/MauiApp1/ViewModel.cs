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
        public ICommand createTask { get; }
        public ICommand deleteTask { get; set; }
        public ICommand changeCategory { get; set; }

        public ObservableCollection<Model.Model> ListTasks { get; set; } =
        new ObservableCollection<Model.Model>();

        public Model.Model task;
        public Color colCategory;

        private void Create(string entry)
        {
            ListTasks.Add(new Model.Model() {TaskName = entry, Status = false, Category = colCategory});
            colCategory = null;
        }

        private void Delete(Model.Model selTask) => ListTasks.Remove(selTask);

        private void ChangeCategory(string text)
        {
            ColButton = text switch
            {
                "red" => Color.FromHex("#b81111"),
                "green" => Color.FromHex("#8cb42f"),
                "blue" => Color.FromHex("#499fdf"),
                _ => ColButton
            };
        }

        public Color ColButton
        {
            get => colCategory;
            set
            {
                colCategory = value;
                OnPropertyChanged(nameof(ColButton));
            }
        }

        public async void EditTask()
        {
            string switchCat = await Application.Current.MainPage.DisplayActionSheet("Выберите действие", "Отмена", "", "Сменить название", "Красная категория", "Зеленая категория", "Голубая категория))0)");
            switch(switchCat)
            {
                case "Сменить название":
                    string text = await Application.Current.MainPage.DisplayPromptAsync("Редактирование", "Введите новое название задачи", initialValue: selectedTask.TaskName);
                    selectedTask.TaskName = text;
                    break;
                case "Красная категория":
                    selectedTask.Category = Color.FromHex("#b81111");
                    break;
                case "Зеленая категория":
                    selectedTask.Category = Color.FromHex("#8cb42f");
                    break;
                case "Голубая категория))0)":
                    selectedTask.Category = Color.FromHex("#499fdf");
                    break;
                default:
                    selectedTask = null;
                    break;
            }
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
            changeCategory = new Command<string>(ChangeCategory);
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}