using Microsoft.AspNetCore.Mvc;
using CarAPI.Repositories;
using CarLibrary;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarAPI.Controllers
{
	[Route("Garage")]
	[ApiController]
	public class CarsController : ControllerBase
	{
		private readonly CarsRepository _garage;

		public CarsController(CarsRepository repository)
		{
			_garage = repository;
		}

		// GET: api/<CarsController>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[HttpGet]
		public ActionResult<IEnumerable<Car>> Get()
		{
			List<Car> allCars = _garage.GetAll();
			if (allCars.Count < 1)
				return NoContent();
			else
				return Ok(allCars);
		}

		// GET api/<CarsController>/5
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[HttpGet("{id}")]
		public ActionResult<Car?> Get(int id)
		{
			Car? getCar = _garage.GetById(id);
			if (getCar == null)
				return NotFound();
			else
				return Ok(getCar);
		}

		// POST api/<CarsController>
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[HttpPost]
		public ActionResult<Car> Post([FromBody] Car newCar)
		{
			try
			{
				Car addNewCar = _garage.Add(newCar);
				return Created($"api/car/{addNewCar.Id}", newCar);
			}

			catch (ArgumentNullException ex)
			{
				return BadRequest(ex.Message);
			}

			catch (ArgumentOutOfRangeException ex)
			{
				return BadRequest(ex.Message);

			}
			catch (ArgumentException ex)
			{
				return BadRequest(ex.Message);
			}
		}

		// PUT api/<CarsController>/5
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[HttpPut("{id}")]
		public ActionResult<Car?> Put(int id, [FromBody] Car updatedCar)
		{
			try
			{
				Car? carUpdate = _garage.Update(id, updatedCar);
				if (carUpdate == null)
					return NotFound();
				return Ok(carUpdate);
			}

			catch (ArgumentOutOfRangeException ex)
			{
				return BadRequest(ex.Message);

			}
			catch (ArgumentException ex) 

			{
				return NotFound(ex.Message);
			}
		}

		// DELETE api/<CarsController>/5
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[HttpDelete("{id}")]
		public ActionResult<Car?> Delete(int id)
		{
			Car? deletedCar = _garage.Delete(id);

			if (deletedCar == null)
				return NotFound();
			else
				return Ok(deletedCar);
		}
	}
}
