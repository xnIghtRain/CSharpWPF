using Caliburn.Micro;
using DemoLibrary.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GartenCenter.ViewModels
{
    public class FruitViewModel : Screen
    {

        private BindableCollection<FruitModel> _fruit = new BindableCollection<FruitModel>();
        private FruitModel _selectedFruit;

        public BindableCollection<FruitModel> Fruit
        {
            get { return _fruit; }
            set { _fruit = value; }
        }

        public FruitModel SelectedFruit
        {
            get { return _selectedFruit; }
            set
            {
                _selectedFruit = value;
                NotifyOfPropertyChange(() => SelectedFruit);
            }
        }

        public void AddFruit(string treeName, int treeheight, bool sour, bool sweet)
        {
            Fruit.Add(new FruitModel { TreeName = treeName, TreeHeight = treeheight.ToString(), Sour = sour.ToString(), Sweet = sweet.ToString() });
        }
        public void RemoveFruit()
        {
            Fruit.Remove(SelectedFruit);
        }

        public void LoadFruit()
        {
            var fileName = "Obst.txt";
            if (fileName != null)
            {
                List<string> lines = File.ReadAllLines(fileName).ToList();

                foreach (var line in lines)
                {
                    string[] entries = line.Split(',');
                    FruitModel newFruit = new FruitModel();
                    newFruit.TreeName = entries[0];
                    newFruit.TreeHeight = entries[1];
                    newFruit.Sour = entries[2];
                    newFruit.Sweet = entries[3];

                    Fruit.Add(newFruit);
                }
            }
        }

        public void SaveFruit()
        {
            var fileName = "Obst.txt";
            List<string> output = new List<string>();
            foreach (var item in Fruit)
            {
                output.Add($"{ item.TreeName }, { item.TreeHeight }, { item.Sour }, { item.Sweet }");
            }

            File.WriteAllLines(fileName, output);
        }


    }
}
