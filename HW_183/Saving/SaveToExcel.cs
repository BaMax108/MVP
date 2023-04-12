using LibraryInterfaces;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;

namespace HW_183.Saving
{
    class SaveToExcel
    {
        /// <summary>
        /// Сохранение данных
        /// </summary>
        /// <param name="listAnimals"></param>
        public void Save(ObservableCollection<IAnimal> listAnimals)
        {
            if (listAnimals[0] == null) return;

            Application excel = new Application();
            Workbook workbook = excel.Application.Workbooks.Add(true);
            int row = 1;
            int col = 1;

            foreach (PropertyInfo prop in listAnimals[0].GetType().GetProperties())
                excel.Cells[col++][row] = prop.Name.ToString();

            foreach (var line in listAnimals)
            {
                if (line != null)
                {
                    col = 1;
                    row++;
                    foreach (PropertyInfo prop in line.GetType().GetProperties())
                        excel.Cells[col++][row] = prop.GetValue(line, null).ToString();
                }
            }
            try
            {
                workbook.SaveAs(Directory.GetCurrentDirectory() + 
                    $"\\ListAnimals_{ DateTime.Now.ToString("yyyyMMdd-HHmmss")}.xlsx");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            excel.Visible = false;
            excel.Quit();
        }
    }
}