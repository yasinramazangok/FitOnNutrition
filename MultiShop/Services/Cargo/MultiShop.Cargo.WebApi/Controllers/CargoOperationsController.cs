using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstracts;
using MultiShop.Cargo.DtoLayer.Dtos.CargoOperationDtos;
using MultiShop.Cargo.EntityLayer.Concretes;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoOperationsController : ControllerBase
    {
        private readonly ICargoOperationService _cargoOperationService;

        public CargoOperationsController(ICargoOperationService cargoOperationService)
        {
            _cargoOperationService = cargoOperationService;
        }

        [HttpGet]
        public IActionResult GetCargoOperationList()
        {
            var values = _cargoOperationService.TGetListAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateCargoOperation(CreateCargoOperationDto createCargoOperationDto)
        {
            CargoOperation cargoOperation = new CargoOperation()
            {
                Barcode = createCargoOperationDto.Barcode,
                Description = createCargoOperationDto.Description,
                OperationDate = createCargoOperationDto.OperationDate
            };
            _cargoOperationService.TInsert(cargoOperation);
            return Ok("Kargo işlemi başarıyla oluşturuldu!");
        }

        [HttpDelete]
        public IActionResult DeleteCargoOperation(int id)
        {
            _cargoOperationService.TDelete(id);
            return Ok("Kargo işlemi başarıyla silindi!");
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoOperationById(int id)
        {
            var values = _cargoOperationService.TGetById(id);
            return Ok(values);
        }

        [HttpPut]
        public IActionResult UpdateCargoOperation(UpdateCargoOperationDto updateCargoOperationDto)
        {
            CargoOperation cargoOperation = new CargoOperation()
            {
                Barcode = updateCargoOperationDto.Barcode,
                CargoOperationId = updateCargoOperationDto.CargoOperationId,
                Description = updateCargoOperationDto.Description,
                OperationDate = updateCargoOperationDto.OperationDate
            };
            _cargoOperationService.TUpdate(cargoOperation);
            return Ok("Kargo işlemi başarıyla güncellendi!");
        }
    }
}
