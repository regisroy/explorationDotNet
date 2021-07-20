using System;
using System.Collections.Generic;
using System.Linq;
using NFluent;
using NUnit.Framework;

namespace Linq.And.Around
{
	[TestFixture]
	public class LinqTests
	{
		[Test]
		public void Linq_1()
		{
			var c1 = new Customer {Id = 1, Name = "John"};
			var c2 = new Customer {Id = 2, Name = "Arthur"};
			var c3 = new Customer {Id = 3, Name = "Géant"};
			var c4 = new Customer {Id = 4, Name = "Titus"};

			var p1 = new Product {Id = 1, Description = "Produit 1", Price = 10.1};
			var p2 = new Product {Id = 2, Description = "Produit 2", Price = 22.2};
			var p3 = new Product {Id = 3, Description = "Produit 3", Price = 33.3};
			var p4 = new Product {Id = 4, Description = "Produit 4", Price = 44.44};
			var p5 = new Product {Id = 5, Description = "Produit 5", Price = 55.555};
			var p6 = new Product {Id = 6, Description = "Produit 6", Price = 66.6};

			var o1 = new Order {Id = Guid.NewGuid(), Customer = c1, OrderDate = new DateTime(2017, 1, 1), Products = new List<Product> {p1, p2}};
			var o2 = new Order {Id = Guid.NewGuid(), Customer = c2, OrderDate = new DateTime(2017, 2, 2), Products = new List<Product> {p3, p4, p5}};
			var o3 = new Order {Id = Guid.NewGuid(), Customer = c3, OrderDate = new DateTime(2017, 3, 3), Products = new List<Product> {p6}};
			var o4 = new Order {Id = Guid.NewGuid(), Customer = c4, OrderDate = new DateTime(2017, 4, 4), Products = new List<Product>()};
			var o5 = new Order {Id = Guid.NewGuid(), Customer = c4, OrderDate = new DateTime(2017, 5, 5), Products = new List<Product> {p1, p2, p3, p4, p5}};

			var orders = new List<Order> {o1, o2, o3, o4, o5};
			var products = new List<Product> {p1, p2, p3, p4, p5, p6};
			var customers = new List<Customer> {c1, c2, c3, c4};

			Check.That(orders).HasSize(5);
			
			Check.That(from order in orders where order.OrderDate >= new DateTime(2017, 3, 3) select order).HasSize(3);

			//TODO
			
			// Check.That(orders.AsQueryable().Where("OrderDate >= DateTime(2017, 3, 3)")).HasSize(3);
			//
			// Check.That(orders.AsQueryable().Where("OrderDate > DateTime(2017, 3, 3)")).HasSize(2);
			//
			// Check.That(orders.AsQueryable().Where("Customer.Name == \"Arthur\"")).HasSize(1);
			//
			// Check.That(orders.AsQueryable().Where("Products.Count > 1")).HasSize(3);
			//
			// Check.That(products.AsQueryable().Where("Description.Contains(@0)", "uit")).HasSize(6);
			//
			// Check.That(customers.AsQueryable().Where("Name.StartsWith(@0)", "J")).HasSize(1);
		}
	}

	// DbRef to cross references
}