using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstracts;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCompanyDtos;
using MultiShop.Cargo.EntityLayer.Concretes;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCompaniesController : ControllerBase
    {
        private readonly ICargoCompanyService _cargoCompanyService;

        public CargoCompaniesController(ICargoCompanyService cargoCompanyService)
        {
            _cargoCompanyService = cargoCompanyService;
        }

        [HttpGet]
        public IActionResult GetCargoCompanyList()
        {
            var values = _cargoCompanyService.TGetListAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateCargoCompany(CreateCargoCompanyDto createCargoCompanyDto)
        {
            CargoCompany cargoCompany = new CargoCompany()
            {
                CargoCompanyName = createCargoCompanyDto.CargoCompanyName
            };
            _cargoCompanyService.TInsert(cargoCompany);
            return Ok("Kargo şirketi başarıyla oluşturuldu!");
        }

        [HttpDelete]
        public IActionResult DeleteCargoCompany(int id)
        {
            _cargoCompanyService.TDelete(id);
            return Ok("Kargo şirketi başarıyla silindi!");
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoCompanyById(int id)
        {
            var values = _cargoCompanyService.TGetById(id);
            return Ok(values);
        }

        [HttpPut]
        public IActionResult UpdateCargoCompany(UpdateCargoCompanyDto updateCargoCompanyDto)
        {
            CargoCompany cargoCompany = new CargoCompany()
            {
                CargoCompanyId = updateCargoCompanyDto.CargoCompanyId,
                CargoCompanyName = updateCargoCompanyDto.CargoCompanyName
            };
            _cargoCompanyService.TUpdate(cargoCompany);
            return Ok("Kargo şirketi başarıyla güncellendi!");
        }
    }
}
