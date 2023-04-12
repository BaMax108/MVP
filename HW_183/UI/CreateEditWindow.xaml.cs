using LibraryInterfaces;
using System.Collections.Generic;
using System.Windows;

namespace HW_183.UI
{
    /// <summary>
    /// Логика взаимодействия для CreateEditWindow.xaml
    /// </summary>
    public partial class CreateEditWindow : Window
    {
        Dictionary<object[], string> RefDictionary;

        /// <summary>
        /// Загрузка окна для создания или изменения существующего элемента коллекции
        /// </summary>
        /// <param name="refDictionary">Словарь с возвращаемыми данными</param>
        /// <param name="array">Массив, содержащий коллекцию наименований типов</param>
        /// <param name="obj">Существующий элемент коллекции</param>
        public CreateEditWindow(ref  Dictionary<object[], string> refDictionary, string[] array)
        {
            InitializeComponent();
            Settings(refDictionary, array, null);
        }
        public CreateEditWindow(ref Dictionary<object[], string> refDictionary, string[] array, IAnimal animal)
        {
            InitializeComponent();
            Settings(refDictionary, array, animal);
        }

        /// <summary>
        /// Настройки окна
        /// </summary>
        /// <param name="refDictionary"></param>
        /// <param name="types"></param>
        /// <param name="obj"></param>
        void Settings(Dictionary<object[], string> refDictionary, string[] types, IAnimal animal)
        {
            RefDictionary = refDictionary;
            cbTypes.ItemsSource = types;

            if (animal == null) return;
            cbTypes.Text = animal.GetType().Name;
            tbxOrder.Text = animal.Order;
            tbxFamily.Text = animal.Family;
            tbxGenus.Text = animal.Genus;
            tbxSpecies.Text = animal.Species;
            this.Title = "Изменить...";
            btnCreateEdit.Content = "Изменить";
        }

        /// <summary>
        /// Передача данных в словарь RefDictionary и закрытие текущего окна
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCreateEdit_Click(object sender, RoutedEventArgs e)
        {
            RefDictionary.Add(new object[] { tbxOrder.Text, tbxFamily.Text, tbxGenus.Text, tbxSpecies.Text }, cbTypes.Text);

            this.Close();
        }
    }
}
