using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarAPI.Repositories;
using CarLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace CarAPI.Repositories.Tests
{
	[TestClass()]
	public class CarsRepositoryTests
	{
		private CarsRepository _garage;
		
		[TestInitialize] public void Init() 
		{
			_garage = new CarsRepository();
		}

		[TestMethod()]
		public void GetAllTest()
		{
			List<Car> getAllCars = _garage.GetAll();									

			//GetAll()-return value is not null
			Assert.IsNotNull(getAllCars);															

			//GetAll()-return value is type of List<Car>
			Assert.IsInstanceOfType(getAllCars, typeof(List<Car>));						

			//GetAll()-return value contains correct amount of objects		
			Assert.AreEqual(2, getAllCars.Count);										

		}

		[TestMethod()]
		public void GetByIdTest()
		{
			Car? getCar = _garage.GetById(1);											

			//GetById()-return value is not null
			Assert.IsNotNull(getCar);													

			//GetById()-return value is a type of Car
			Assert.IsInstanceOfType(getCar, typeof(Car));								

			//GetById()-return value's properties are correct
			Assert.AreEqual(getCar.ToString(), "1 Citroën C3 125000 CU72289");			
		}

		[TestMethod()]
		public void AddTest()
		{
			Car newCar = new Car() { Id = 3, Model = "Model", LicensePlate = "AB12345", Price = 2 };
			_garage.Add(newCar);														
			string str = newCar.ToString();                                    

			//Add()-return value is correct, including pre-defined unique Id 
			Assert.AreEqual("3 Model 2 AB12345", str);							

			//Add()-return value is a type of Car
			Assert.IsInstanceOfType(newCar, typeof(Car));								
		}

		[TestMethod()]
		public void DeleteTest()
		{
			int id = 1;
			int count = _garage.GetAll().Count;
			_garage.Delete(id);	

			//Delete()-return value contains correct amount of objects		
			Assert.AreNotEqual(count, _garage.GetAll().Count);

			//Delete()-return value is not null
			Assert.IsNull(_garage.GetById(id));

			Car? deletedCar = _garage.Delete(id);
			Assert.IsNull(deletedCar);	
		}

		[TestMethod()]
		public void UpdateTest()
		{
			Car updates = new Car() { Id = 100, Model = "Updated Model", LicensePlate = "AB12345", Price = 2};
			Car? updatedCar = _garage.Update(1, updates);

			//UpdateTest()-return value is not null
			Assert.IsNotNull(updatedCar);

			//Update()-return value is correct, including pre-defined unique Id 
			Assert.AreEqual("1 Updated Model 2 AB12345", updatedCar.ToString());
			
			Car? nullCar = _garage.Update(3, updates);
			Assert.IsNull(nullCar);
		}
	}
}