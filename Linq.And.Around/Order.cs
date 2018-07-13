using System;
using System.Collections.Generic;

namespace Linq.And.Around
{
	public class Order
	{
		public Guid Id { get; set; }
		public DateTime OrderDate { get; set; }
		public Customer Customer { get; set; }
		public List<Product> Products { get; set; }
	}
}