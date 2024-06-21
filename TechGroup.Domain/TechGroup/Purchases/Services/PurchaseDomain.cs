using TechGroup.Domain.TechGroup.Purchases.Interfaces;
using TechGroup.Infrastructure.TechGroup.Purchases.Interfaces;
using TechGroup.Infrastructure.TechGroup.Purchases.Models;
using TechGroup.Infrastructure.TechGroup.Users.Interfaces;

namespace TechGroup.Domain.TechGroup.Purchases.Services;

public class PurchaseDomain : IPurchaseDomain
{
        private readonly IPurchaseInfrastructure _purchaseInfrastructure;
        private readonly IUserInfrastructure _userInfrastructure;

        public PurchaseDomain(IPurchaseInfrastructure purchaseInfrastructure)
        {
            _purchaseInfrastructure = purchaseInfrastructure ?? throw new ArgumentNullException(nameof(purchaseInfrastructure));
        }

        public async Task<bool> CreatePurchaseAsync(Purchase purchase)
        {
            ValidatePurchaseForCreate(purchase);

            var userExists = await _userInfrastructure.GetByIdAsync(purchase.UserId);
            if (userExists == null)
            {
                throw new ArgumentException($"User with ID {purchase.UserId} does not exist.", nameof(purchase.UserId));
            }

            return await _purchaseInfrastructure.CreateAsync(purchase);
        }

        public async Task<bool> DeletePurchaseAsync(int id)
        {
            var purchaseToDelete = await _purchaseInfrastructure.GetByIdAsync(id);
            if (purchaseToDelete == null)
            {
                throw new ArgumentException("Purchase not found", nameof(id));
            }

            return await _purchaseInfrastructure.DeleteAsync(id);
        }

        public async Task<List<Purchase>> GetAllPurchasesAsync()
        {
            var purchases = await _purchaseInfrastructure.GetAllAsync();
            if (purchases == null || purchases.Count == 0)
            {
                throw new Exception("No purchases found.");
            }

            return purchases;
        }

        public async Task<Purchase> GetPurchaseByIdAsync(int id)
        {
            var purchase = await _purchaseInfrastructure.GetByIdAsync(id);
            if (purchase == null)
            {
                throw new ArgumentException($"Purchase with ID {id} not found.", nameof(id));
            }

            return purchase;
        }

        public async Task<bool> UpdatePurchaseAsync(int id, Purchase purchase)
        {
            ValidatePurchaseForUpdate(id, purchase);

            var userExists = await _userInfrastructure.GetByIdAsync(purchase.UserId);
            if (userExists == null)
            {
                throw new ArgumentException($"User with ID {purchase.UserId} does not exist.", nameof(purchase.UserId));
            }

            var existingPurchase = await _purchaseInfrastructure.GetByIdAsync(id);
            if (existingPurchase == null)
            {
                throw new ArgumentException("Purchase not found.", nameof(id));
            }

            return await _purchaseInfrastructure.UpdateAsync(id, purchase);
        }

        public async Task<List<Purchase>> GetPurchasesByUserIdAsync(int userId)
        {
            var purchases = await _purchaseInfrastructure.GetByUserIdAsync(userId);
            if (purchases == null || purchases.Count == 0)
            {
                throw new Exception($"No purchases found for user with ID {userId}.");
            }

            return purchases;
        }

        public async Task<List<Purchase>> GetPurchasesInDateRangeAsync(DateOnly startDate, DateOnly endDate)
        {
            var purchases = await _purchaseInfrastructure.GetByDateRangeAsync(startDate, endDate);
            if (purchases == null || purchases.Count == 0)
            {
                throw new Exception($"No purchases found in the date range from {startDate} to {endDate}.");
            }

            return purchases;
        }

        public async Task<int> GetPurchaseCountAsync()
        {
            var count = await _purchaseInfrastructure.CountAsync();
            return count;
        }

        private void ValidatePurchaseForCreate(Purchase purchase)
        {
            if (purchase == null)
            {
                throw new ArgumentNullException(nameof(purchase), "The purchase cannot be null.");
            }

            if (purchase.Price <= 0)
            {
                throw new ArgumentException("The purchase price must be greater than zero.", nameof(purchase.Price));
            }
        }

        private void ValidatePurchaseForUpdate(int id, Purchase purchase)
        {
            if (purchase == null)
            {
                throw new ArgumentNullException(nameof(purchase), "The purchase cannot be null.");
            }

            if (id != purchase.Id)
            {
                throw new ArgumentException("The ID of the purchase does not match the ID parameter.", nameof(purchase.Id));
            }

            if (purchase.Price <= 0)
            {
                throw new ArgumentException("The purchase price must be greater than zero.", nameof(purchase.Price));
            }
        }
}