using System;
using CleanArchMVC.Domain.Validation;

namespace CleanArchMVC.Domain.Entities
{
    public class Product : Entity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string ImageUrl { get; private set; }
        public ICollection<Category> Categories { get; set; }

        public Product(string name, string description, decimal price, int stock, string imageUrl)
        {
            ValidateDomain(name, description, price, stock, imageUrl);
        }

        public Product(int id, string name, string description, decimal price, int stock, string imageUrl)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id value");
            ValidateDomain(name, description, price, stock, imageUrl);
            Id = id;
        }
        public void Update(string name, string description, decimal price, int stock, string imageUrl)
        {
            ValidateDomain(name, description, price, stock, imageUrl);
        }

        private void ValidateDomain(string name, string description, decimal price, int stock, string imageUrl)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Invalid name. Name is required");

            DomainExceptionValidation.When(name.Length < 3,
                "Invalid name, too short, minimum 3 characters");

            DomainExceptionValidation.When(string.IsNullOrEmpty(description),
            "Invalid description. Description is required");

            DomainExceptionValidation.When(description.Length < 5,
                "Invalid description, too short, minimum 5 characters");

            DomainExceptionValidation.When(price < 0, "Invalid price value");

            DomainExceptionValidation.When(stock < 0, "Invalid price value");

            DomainExceptionValidation.When(imageUrl?.Length > 250,
                "Invalid image name, too long, maximum 250 characters ");

            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            ImageUrl = imageUrl;

        }
    }
}