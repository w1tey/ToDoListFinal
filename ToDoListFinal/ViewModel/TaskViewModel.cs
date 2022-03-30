using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ToDoListFinal.Model;

namespace ToDoListFinal.ViewModel
{
    public class TaskViewModel : ViewModelBase
    {

        private List<TaskModel> taskList = new();

        public List<TaskModel> TaskList
        {
            get { return taskList; }
            set => Set(ref taskList, value);
        }

        public TaskModel? SelectedTask { get; set; }

        private string? txtBoxTask;
        public string? TxtBoxTask
        {
            get { return txtBoxTask; }
            set => Set(ref txtBoxTask, value);
        }

        private RelayCommand? _addTaskCommand;
        public RelayCommand? AddTaskCommand
        {
            get => _addTaskCommand ??= new RelayCommand(
                () =>
                {
                    if (TxtBoxTask != "")
                    {
                        taskList.Add(new TaskModel(TxtBoxTask, false));
                        TaskList = new(TaskList); 
                        TxtBoxTask = "";
                    }
                    else
                    {
                        MessageBox.Show("Task cannot be empty", "Error");
                    }
                });
        }

        private RelayCommand? _deleteTaskCommand;
        public RelayCommand? DeleteTaskCommand
        {
            get => _deleteTaskCommand ??= new RelayCommand(
                () =>
                {
                    if (SelectedTask != null)
                    {
                        TaskList.Remove(SelectedTask);
                        TaskList = new(TaskList);
                    }
                    else
                    {
                        MessageBox.Show("You didn't select a task", "Error");
                    }
                });
        }

        private RelayCommand? _completedTaskCommand;
        public RelayCommand? CompletedTaskCommand
        {
            get => _completedTaskCommand ??= new RelayCommand(
                () =>
                {
                    if (SelectedTask != null)
                    {
                        TaskList.Find(new Predicate<TaskModel>(x => x.GetHashCode() == SelectedTask.GetHashCode())).isFinished = true;
                        TaskList = new(TaskList);
                    }
                    else
                    {
                        MessageBox.Show("You didn't select a task", "Error"                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             );
                    }
                });
        }
    }
}
