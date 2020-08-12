using Caliburn.Micro;
using DemoLibrary;
using DemoLibrary.Models;
using System;
using System.Windows;
using System.Windows.Controls;

namespace GartenCenter.ViewModels
{
    public class MainViewModel : Conductor<object>
    {
        public void LoadHome()
        {
            ActivateItem(new HomeViewModel());
        }
        public void LoadFruit()
        {
            ActivateItem(new FruitViewModel());
        }
        public void LoadPlant()
        {
            ActivateItem(new PlantViewModel());
        }

        public void LoadFlower()
        {
            ActivateItem(new FlowerViewModel());
        }

        public void QuitApp()
        {
            Environment.Exit(0);
        }
    }

    
}
