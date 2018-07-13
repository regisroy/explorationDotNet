using System;
using System.Collections.Generic;
using System.Linq;
using NFluent;
using NUnit.Framework;

namespace Linq.And.Around
{
	[TestFixture]
	public class LinqDistinctTests
	{
		[Test]
		public void distinct_test()
		{
			Product[] products =
			{
				new Product {Name = "apple", Code = 9},
				new Product {Name = "orange", Code = 4},
				new Product {Name = "apple", Code = 9},
				new Product {Name = "lemon", Code = 12}
			};

			//Exclude duplicates.
			IEnumerable<Product> noduplicates = products.Distinct(new ProductComparer());

			foreach (var product in noduplicates)
				Console.WriteLine(product.Name + " " + product.Code);
		}

		class ProductComparer : IEqualityComparer<Product>
		{
			// Products are equal if their names and product numbers are equal.
			public bool Equals(Product x, Product y)
			{
				//Check whether the compared objects reference the same data.
				if (Object.ReferenceEquals(x, y)) return true;

				//Check whether any of the compared objects is null.
				if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
					return false;

				//Check whether the products' properties are equal.
				return x.Code == y.Code && x.Name == y.Name;
			}

			// If Equals() returns true for a pair of objects 
			// then GetHashCode() must return the same value for these objects.
			public int GetHashCode(Product product)
			{
				//Check whether the object is null
				if (Object.ReferenceEquals(product, null)) return 0;

				//Get hash code for the Name field if it is not null.
				int hashProductName = product.Name == null ? 0 : product.Name.GetHashCode();

				//Get hash code for the Code field.
				int hashProductCode = product.Code.GetHashCode();

				//Calculate the hash code for the product.
				return hashProductName ^ hashProductCode;
			}
		}
	}
}