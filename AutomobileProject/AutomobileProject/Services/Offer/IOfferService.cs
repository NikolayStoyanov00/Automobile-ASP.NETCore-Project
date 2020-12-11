using AutomobileProject.ViewModels.Offer;

namespace AutomobileProject.Services.Offer
{
    public interface IOfferService
    {
        void AddCar(AddCarViewModel addOfferViewModel, string userId);

        void AddMotorcycle(AddMotorcycleViewModel addOfferViewModel, string userId);

        void AddElectricScooter(AddElectricScooterViewModel addOfferViewModel, string userId);
    }
}
