using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Learn.Windows
{
    /// <summary>
    /// Логика взаимодействия для ServicesListWindow.xaml
    /// </summary>
    public partial class ServicesListWindow : Window
    {
        private Context.LearnContext _Context;
        public List<Misc.SelectorOption> sortSelectorOptions { get; set; }
        public List<Misc.SelectorOption> filterSelectorOptions { get; set; }

        public IEnumerable<Models.Service> servicesQuery { get; set; }
        public List<Models.Service> paginationElements { get; set; }

        public int servicesCount => _Context.Services.Count();
        public int servicesQueryCount => paginationElements.Count();


        const int _paginationCount = 10;
        int _paginationPage = 1;

        public ServicesListWindow()
        {
            InitializeComponent();
            DataContext = this;
            _Context = new Context.LearnContext();
            sortSelectorOptions = new List<Misc.SelectorOption>()
            {
                new Misc.SelectorOption(0, "Без сортировки")
            };
            filterSelectorOptions = new List<Misc.SelectorOption>()
            {
                new Misc.SelectorOption(0, "Без фильтрации")
            };
            reloadQuery();
        }
        public void reloadQuery()
        {
            var services = _Context.Services.AsEnumerable();
            var sortOption = sortSelector.SelectedItem as Misc.SelectorOption;
            var filterOption = filterSelector.SelectedItem as Misc.SelectorOption;

            if (sortOption == null || filterOption == null)
                return;
            if (serchQueryBox.Text.Trim() != "")
                services = services.Where(service => service.Title.ToLower().Contains(serchQueryBox.Text.Trim()));
            switch (sortOption.Id)
            {
                case 1:
                    break;
            }
            switch (filterOption.Id)
            {
                case 1:
                    break;
            }
            servicesQuery = services;
            if (servicesQuery != null)
                reloadPage();
        }
        public void reloadPage()
        {
            if (servicesQuery == null)
                return;
            paginationElements = servicesQuery
                .Skip((_paginationPage - 1) * _paginationCount)
                .Take(_paginationCount).ToList();
            servicesContainer.ItemsSource = paginationElements;
        }

        private void Selector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            reloadPage();
        }

        private void clearSerchBtn_Click(object sender, RoutedEventArgs e)
        {
            serchQueryBox.Text = "";
        }

        private void serchQueryBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            reloadQuery();
        }
    }
}
