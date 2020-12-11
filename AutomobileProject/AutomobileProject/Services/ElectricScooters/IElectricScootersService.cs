using AutomobileProject.ViewModels.ElectricScooters;
using System.Collections.Generic;

namespace AutomobileProject.Services.ElectricScooters
{
    public interface IElectricScootersService
    {
        ICollection<VisualizeScooterViewModel> ScootersForVisualization();
        ICollection<VisualizeScooterViewModel> ScootersForVisualization(string sortingType);
    }
}
