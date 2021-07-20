using System;
using System.Collections.Generic;
using System.IO;
using LiteDB;
using NFluent;
using NUnit.Framework;

namespace LiteDB_NoSQL
{
	[TestFixture]
	public class Tests
	{
		[Test]
		public void SimpleCase()
		{
			var mem = new MemoryStream();

			// Re-use mapper from global instance
			var mapper = BsonMapper.Global;

			// Produts and Customer are other collections (not embedded document)
			// you can use [BsonRef("colname")] attribute
			mapper.Entity<Order>()
			      .DbRef(x => x.Products, "products")
			      .DbRef(x => x.Customer, "customers");

			using (var db = new LiteDatabase(mem))
			{
				LiteCollection<Customer> customers = db.GetCollection<Customer>("customers");
				LiteCollection<Product> products = db.GetCollection<Product>("products");
				LiteCollection<Order> orders = db.GetCollection<Order>("orders");

				// create examples
				var john = new Customer {Name = "John Doe"};
				var tv = new Product {Description = "TV Sony 44\"", Price = 799};
				var iphone = new Product {Description = "iPhone X", Price = 999};
				var order1 = new Order {OrderDate = new DateTime(2017, 1, 1), Customer = john, Products = new List<Product> {iphone, tv}};
				var order2 = new Order {OrderDate = new DateTime(2017, 10, 1), Customer = john, Products = new List<Product> {iphone}};

				// insert into collections
				customers.Insert(john);
				products.Insert(new[] {tv, iphone});
				orders.Insert(new[] {order1, order2});

				// create index in OrderDate
				orders.EnsureIndex(x => x.OrderDate);

				// When query Order, includes references
				IEnumerable<Order> query = orders
				                           .Include(x => x.Customer)
				                           .Include(x => x.Products)
				                           .Find(x => x.OrderDate == new DateTime(2017, 1, 1));

				// Each instance of Order will load Customer/Products references
				Check.That(query.Count()).IsEqualTo(1);
				foreach (var c in query)
				{
					Console.WriteLine("#{0} - {1}", c.Id, c.Customer.Name);

					foreach (var p in c.Products)
					{
						Console.WriteLine(" > {0} - {1:c}", p.Description, p.Price);
					}
				}
			}
		}

		[Test]
		[Ignore("Doit tourner dans H3C, mais je stocke le code ici pour ne pas le perdre")]
		public void LiteDB_2_withDataObjects()
		{   /*
			InitDependencies();  //Test doit étendre : BaseTest
			var mem = new MemoryStream();

			// Re-use mapper from global instance
			var mapper = BsonMapper.Global;

			// Produts and Customer are other collections (not embedded document)
			// you can use [BsonRef("colname")] attribute
			mapper.Entity<AuditorDataObject>()     //AuditorDataObject   : plein de champs à ignorer, car à chaque fois appel un DataProvider 
			      .DbRef(x => x.AuditorRegionalCompany, "crccs")
			      .Ignore(x => x.AuditorAudit)
			      .Ignore(x => x.AuditorDocumentItems)
			      .Ignore(x => x.AuditorRiskItems)
			      .Ignore(x => x.AuditorSnapshotItems)
			      .Ignore(x => x.AuditorStatusItems)
			      .Ignore(x => x.AuditorToOrganisationItems)
			      .Ignore(x => x.CommentItems)
			      .Ignore(x => x.ContactToAuditorItemsFromAuditor)
			      .Ignore(x => x.ContactToAuditorItemsFromPerson)
			      .Ignore(x => x.ContactToEntityItems)
			      .Ignore(x => x.ContactToPracticeItems)
			      .Ignore(x => x.ContradictoireCACItems)
			      .Ignore(x => x.ControlesDeprogrammesACauseDeCeCAC)
			      .Ignore(x => x.DeclarationetcotisationItems)
			      .Ignore(x => x.DemandeadministrativeItems)
			      .Ignore(x => x.EntiteItems)
			      .Ignore(x => x.EnqueteItems)
			      .Ignore(x => x.EnqueteToAuditorItems)
			      .Ignore(x => x.ExercantsToAuditorItemsFromAuditor)
			      .Ignore(x => x.ExercantsToAuditorItemsFromPerson)
			      .Ignore(x => x.ImplantationItems)
			      .Ignore(x => x.InspectionToAuditorItems)
			      .Ignore(x => x.InspectionToRecoToAuditorItems)
			      .Ignore(x => x.InteractionItems)
			      .Ignore(x => x.MandateItems)
			      .Ignore(x => x.MandateTitulaireItems)
			      .Ignore(x => x.NetworkToAuditorItems)
			      .Ignore(x => x.OrganisationsdontleCACestmembre)
			      .Ignore(x => x.Organisationsdontlapersonneestmembre)
			      .Ignore(x => x.OrganisationContacteeItems)
			      .Ignore(x => x.PersonAudit)
			      .Ignore(x => x.PersonSnapshotItems)
			      .Ignore(x => x.PilotedPractice)
			      .Ignore(x => x.PracticeToAuditorItems)
			      .Ignore(x => x.RecoursItems)
			      .Ignore(x => x.RecoursItems1)
			      .Ignore(x => x.SaisineItems)
			      .Ignore(x => x.SignalementCACItems)
			      .Ignore(x => x.SignalementsDontLaPersonneEstOrigine)
			      .Ignore(x => x.SignalementToAuditorItems)
			      .Ignore(x => x.ActionnaireToEntityItems)
			      .Ignore(x => x.ActionnaireToLegalEntityItemsFromPerson)

				//.DbRef(x => x.Customer, "customers")
				;

			using (var db = new LiteDatabase(mem))
			{
				LiteCollection<AuditorDataObject> auditors = db.GetCollection<AuditorDataObject>("auditors");
				LiteCollection<AuditorRegionalCompanyDataObject> crccs = db.GetCollection<AuditorRegionalCompanyDataObject>("crccs");
				//LiteCollection<Order> orders = db.GetCollection<Order>("orders");

				// create examples
				var agen = new AuditorRegionalCompanyDataObject {ObjectsDataSet = _objectsDataSet, Name = "Agen", Id = Guid.NewGuid()};
				var orleans = new AuditorRegionalCompanyDataObject {ObjectsDataSet = _objectsDataSet, Name = "Orléans", Id = Guid.NewGuid()};
				var john = new AuditorDataObject {ObjectsDataSet = _objectsDataSet, Name = "John Doe", AuditorRegionalCompany = agen, City = "Brest"};
				var jean = new AuditorDataObject {ObjectsDataSet = _objectsDataSet, Name = "Jean", AuditorRegionalCompany = orleans, City = "Paris"};
				//var order1 = new Order {OrderDate = new DateTime(2017, 1, 1), Customer = john, Products = new List<Product> {iphone, tv}};
				//var order2 = new Order {OrderDate = new DateTime(2017, 10, 1), Customer = john, Products = new List<Product> {iphone}};

				// insert into collections
				auditors.Insert(john);
				auditors.Insert(jean);
				crccs.Insert(new[] {agen, orleans});
				//orders.Insert(new[] {order1, order2});

				// create index in OrderDate
				//orders.EnsureIndex(x => x.OrderDate);

				// When query Order, includes references
				IEnumerable<AuditorDataObject> query = auditors
				                                       .Include(x => x.AuditorRegionalCompany)
				                                       //.Include(x => x.Products)
				                                       .Find(x => x.City == "Brets");

				// Each instance of Order will load Customer/Products references
				foreach (var c in query)
				{
					Console.WriteLine("#{0} - {1}", c.Name, c.AuditorRegionalCompany.Name);

//					foreach (var p in c.Products)
//					{
//						Console.WriteLine(" > {0} - {1:c}", p.Description, p.Price);
//					}
				}
			}
			*/
		}
	}

	// DbRef to cross references
	public class Customer
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}

	public class Product
	{
		public int Id { get; set; }
		public string Description { get; set; }
		public double Price { get; set; }
	}

	// DbRef to cross references
	public class Order
	{
		public ObjectId Id { get; set; }
		public DateTime OrderDate { get; set; }
		public Customer Customer { get; set; }
		public List<Product> Products { get; set; }
	}
}