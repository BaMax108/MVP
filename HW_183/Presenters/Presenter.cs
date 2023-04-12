using HW_183.Models;
using HW_183.UI;
using LibraryInterfaces;
using System.Collections.ObjectModel;

namespace HW_183.Presenters
{
    class Presenter
    {
        IView view;
        IModel model;

        public Presenter(IView _view)
        {
            view = _view;
            model = new Model();
        }

        #region Saving
        /// <summary>
        /// Сохранение в формат txt
        /// </summary>
        public void SavingToTxt()
        {
            model.SaveToTxt();
        }

        /// <summary>
        /// Сохранение в формат xlsx
        /// </summary>
        public void SavingToExcel()
        {
            model.SaveToExcel();
        }

        /// <summary>
        /// Сохранение в формат csv
        /// </summary>
        public void SavingToCsv()
        {
            model.SaveToCSV();
        }
        #endregion

        /// <summary>
        /// Получение всех доступных типов животных
        /// </summary>
        public string[] GetTypes()
        {
            return model.AnimalTypes;
        }

        /// <summary>
        /// Получение списка животных
        /// </summary>
        public ObservableCollection<IAnimal> GetList()
        {
            return model.AnimalsList;
        }

        #region Create/Edit/Remove
        /// <summary>
        /// Добавление в коллекцию одного элемента IAnimal
        /// </summary>
        /// <param name="type">Тип нового элемента</param>
        /// <param name="args">Набор параметров</param>
        public void CreateAnimal(string type, object[] args)
        {

            model.CreateAnimal(type, args);
        }

        /// <summary>
        /// Изменение элемента с указанным индексом
        /// </summary>
        /// <param name="type">Тип элемента</param>
        /// <param name="args">Набор параметров</param>
        /// <param name="index">Индекс выбранного элемента</param>
        public void Edit(string type, object[] args, int index)
        {
            model.Edit(type, args, index);
        }

        /// <summary>
        /// Удаление элемента коллекции с указанным индексом
        /// </summary>
        /// <param name="index"></param>
        public void Remove(int index)
        {
            model.Remove(index);
        }

        /// <summary>
        /// Генерация списка животных
        /// </summary>
        /// <param name="createMore">Требуется ли создать дополнительные элементы коллекции</param>
        /// <param name="count">Количество доп. элементов коллекции</param>
        /// <returns></returns>
        public ObservableCollection<IAnimal> CreateList(bool createMore, int count)
        {
            model.CreateAnimals();
            if (createMore)
            {
                if (count < 1) count = 1;
                model.GenerateMoreAnimals(count);
            }
            return model.AnimalsList;
        }
        #endregion
    }
}
