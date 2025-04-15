using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace TaskManagerApp
{
    public partial class HomePage : ContentPage
    {
        private readonly int _userId;
        private readonly UserService _userService;
        private readonly CommentService _commentService;
        private readonly TaskService _taskService;
        private readonly SubTaskService _subTaskService;

        public HomePage(UserService userService, TaskService taskService, CommentService commentService, SubTaskService subTaskService, int userId )
        {
            InitializeComponent();
            _userId = userId;
            _userService = userService;
            _taskService = taskService;
            _commentService = commentService;
            _subTaskService = subTaskService;

            // Load tasks for the user
            LoadTasksAsync();
        }

        private async Task LoadTasksAsync()
        {
            try
            {
                // Fetch tasks created by the user
                var tasks = await _taskService.GetTasksByUserIdAsync(_userId);

                // Bind the tasks to the CollectionView
                TasksCollectionView.ItemsSource = tasks;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Failed to load tasks: {ex.Message}", "OK");
            }
        }
    }
}