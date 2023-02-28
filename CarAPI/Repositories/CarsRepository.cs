using CarLibrary;

namespace CarAPI.Repositories
{
	public class CarsRepository
	{
		private int _nextId = 1;
		private readonly List<Car> _garage;

		public CarsRepository()
		{
			_garage = new List<Car>
			{
				new Car {Id = _nextId++, Model = "Citroën C3", Price = 125000, LicensePlate = "CU72289"},
				new Car {Id = _nextId++, Model = "VW ID Buzz", Price = 484995, LicensePlate = "AB78451"}
            };
		}

		/// <summary>
		/// A copy constructor. Callers should not get a reference to the Garage List, but rather get a copy.
		/// </summary>
		/// <returns></returns>
		public List<Car> GetAll()
		{
			return new List<Car>(_garage);
		}

		/// <summary>
		/// Takes id as a parameter, finds obj.Id in the Garage, and returns obj. 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public Car? GetById(int id)
		{
			return _garage.Find(car => car.Id == id);
		}

		/// <summary>
		/// Takes a Car obj as a parameter. Increments _nextId so that the *next* Car to be added, will get _nextId + 1. Adds the Car obj to the Garage and returns the newly added obj.  
		/// </summary>
		/// <param name="newCar"></param>
		/// <returns></returns>
		public Car Add(Car newCar)
		{
			newCar.ValidateAll();
			newCar.Id = _nextId++;
			_garage.Add(newCar);
			return newCar;
		}

		/// <summary>
		/// Takes id as a parameter. Uses the GetById(id) to find obj.Id in the Garage. If null the method will return null. Otherwise it will remove said obj from Garage and return the deleted obj. 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public Car? Delete(int id)
		{
			Car? car = GetById(id);
			if (car == null)
			{
				return null;
			}
			_garage.Remove(car);
			return car;
		}

		/// <summary>
		/// Takes id and obj updates as parameters. Uses the GetById(id) to find obj.Id in the Garage. If null the method will return null. Otherwise it will update *all* parameters with the parameters from the obj updates and return the car obj. 
		/// </summary>
		/// <param name="id"></param>
		/// <param name="updates"></param>
		/// <returns></returns>
		public Car? Update(int id, Car updates)
		{
			updates.ValidateAll();
			Car? car = GetById(id);
			if (car == null)
			{
				return null;
			}
			car.Model = updates.Model;
			car.Price = updates.Price;
			car.LicensePlate = updates.LicensePlate;
			return car;
		}
	}
}
