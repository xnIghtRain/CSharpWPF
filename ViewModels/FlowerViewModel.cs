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
    public class FlowerViewModel : Screen
    {

        private BindableCollection<FlowerModel> _flower = new BindableCollection<FlowerModel>();
        private FlowerModel _selectedFlower;

        public BindableCollection<FlowerModel> Flower
        {
            get { return _flower; }
            set { _flower = value; }
        }



        public FlowerModel SelectedFlower
        {
            get { return _selectedFlower; }
            set
            {
                _selectedFlower = value;
                NotifyOfPropertyChange(() => SelectedFlower);
            }
        }

        public void AddFlower(string flowerName, bool bloom, bool hardy)
        {
            Flower.Add(new FlowerModel { FlowerName = flowerName, Bloom = bloom.ToString(), Hardy = hardy.ToString() });
        }

        public void RemoveFlower()
        {
            Flower.Remove(SelectedFlower);
        }


        // Save + Load

        public void LoadFlower()
        {
            var fileName = "Blumen.txt";
            if (fileName != null)
            {
                List<string> lines = File.ReadAllLines(fileName).ToList();

                foreach (var line in lines)
                {
                    string[] entries = line.Split(',');
                    FlowerModel newFlower = new FlowerModel();
                    newFlower.FlowerName = entries[0];
                    newFlower.Bloom = entries[1];
                    newFlower.Hardy = entries[2];
                    Flower.Add(newFlower);
                }
            }
        }
        public void SaveFlower()
        {
            var fileName = "Blumen.txt";
            List<string> output = new List<string>();
            foreach (var item in Flower)
            {
                output.Add($"{ item.FlowerName }, { item.Bloom }, { item.Hardy }");
            }

            File.WriteAllLines(fileName, output);
        }
    }
}
