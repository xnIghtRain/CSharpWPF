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
    public class PlantViewModel : Screen
    {
        private BindableCollection<PlantModel> _plant = new BindableCollection<PlantModel>();
        private PlantModel _selectedPlant;

        public BindableCollection<PlantModel> Plant
        {
            get { return _plant; }
            set { _plant = value; }
        }

        public PlantModel SelectedPlant
        {
            get { return _selectedPlant; }
            set
            {
                _selectedPlant = value;
                NotifyOfPropertyChange(() => SelectedPlant);
            }
        }

        public void AddPlant(string plantName, string location)
        {
            Plant.Add(new PlantModel { PlantName = plantName, Location = location });
        }
        public void RemovePlant()
        {
            Plant.Remove(SelectedPlant);
        }

        // Save + Load

        public void LoadPlant()
        {
            var fileName = "Zimmerpflanzen.txt";
            if (fileName != null)
            {
                List<string> lines = File.ReadAllLines(fileName).ToList();

                foreach (var line in lines)
                {
                    string[] entries = line.Split(',');
                    PlantModel newPlant = new PlantModel();
                    newPlant.PlantName = entries[0];
                    newPlant.Location = entries[1];
                    Plant.Add(newPlant);
                }
            }
        }

        public void SavePlant()
        {
            var fileName = "Zimmerpflanzen.txt";
            List<string> output = new List<string>();
            foreach (var item in Plant)
            {
                output.Add($"{ item.PlantName }, { item.Location }");
            }

            File.WriteAllLines(fileName, output);
        }

    }
}
