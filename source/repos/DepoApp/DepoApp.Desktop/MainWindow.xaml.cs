using DemoApp.Domain.Models;
using DemoApp.Service.Common.Util;
using DemoApp.Service.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;

namespace DepoApp.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly CarService _service;

        public MainWindow()
        {
            InitializeComponent();
            _service = new CarService();
        }

        private async void DataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            await LoadDataAsync();
            // Malumot qo'shish uchun

            //List<Car> cars = new List<Car>()
            //{
            //    new Car()
            //    {
            //        Name = "Cobalt", Color = "Black", Number = "01 A 353 AA", Model = "chevralet", MadeYear = DateOnly.FromDateTime(DateTime.Now)
            //    },
            //     new Car()
            //    {
            //        Name = "Lacety", Color = "White", Number = "01 M 353 AA", Model = "chevralet", MadeYear = DateOnly.FromDateTime(DateTime.Now)
            //    }
            //};
            //foreach (var car in cars)
            //{
            //    await _service.CreateAsync(car);
            //}
        }
        private async Task LoadDataAsync()
        {
            PaginationParams paginationParams = new PaginationParams()
            {
                PageNumber = 1,
                PageSize = 20,
            };
            var data = await _service.WhereAsync(paginationParams);
            dgCars.ItemsSource = data;
        }
    }
    
}
