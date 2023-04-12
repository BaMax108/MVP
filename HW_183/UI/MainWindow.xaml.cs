using HW_183.Presenters;
using LibraryInterfaces;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace HW_183.UI
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IView
    {
        Presenter presenter;
        public ObservableCollection<IAnimal> AnimalsList
        {
            get => (ObservableCollection<IAnimal>)this.dgAnimals.ItemsSource.Cast<IAnimal>();
        }

        int AnimalCount = 5000;

        public MainWindow()
        {
            InitializeComponent();
            presenter = new Presenter(this);
            dgAnimals.ItemsSource = presenter.CreateList(true, AnimalCount);
        }

        /// <summary>
        /// Действия при нажатии на кнопку MenuSaveToTxt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuSaveToTxt_Click(object sender, RoutedEventArgs e)
        {
            presenter.SavingToTxt();
        }

        /// <summary>
        /// Действия при нажатии на кнопку MenuSaveToExcel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuSaveToExcel_Click(object sender, RoutedEventArgs e)
        {
            presenter.SavingToExcel();
        }

        /// <summary>
        /// Действия при нажатии на кнопку MenuSaveToCSV
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuSaveToCSV_Click(object sender, RoutedEventArgs e)
        {
            presenter.SavingToCsv();
        }

        /// <summary>
        /// Выход из программы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Действия при нажатии на кнопку BtnCreate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {
            Dictionary<object[], string> refDictionary = new Dictionary<object[], string>();
            new CreateEditWindow(ref refDictionary, presenter.GetTypes()).ShowDialog();

            if (refDictionary.Count == 0) return;
            presenter.CreateAnimal(refDictionary.ElementAt(0).Value, refDictionary.ElementAt(0).Key);
        }

        /// <summary>
        /// Действия при нажатии на кнопку BtnEdit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (dgAnimals.SelectedItem == null) return;

            Dictionary<object[], string> refDictionary = new Dictionary<object[], string>();
            new CreateEditWindow(ref refDictionary, presenter.GetTypes(), dgAnimals.SelectedItem as IAnimal).ShowDialog();

            if (refDictionary.Count == 0) return;
            presenter.Edit(refDictionary.ElementAt(0).Value, refDictionary.ElementAt(0).Key, dgAnimals.SelectedIndex);
        }

        /// <summary>
        /// Действия при нажатии на кнопку BtnDelete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dgAnimals.SelectedItem == null) return;
            presenter.Remove(dgAnimals.SelectedIndex);
        }
    }
}