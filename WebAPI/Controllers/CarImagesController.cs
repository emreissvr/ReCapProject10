﻿using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        
            private ICarImageService _carImageService;

            public CarImagesController(ICarImageService carImageService)
            {
                _carImageService = carImageService;
            }


            [HttpGet("getall")]
            public IActionResult GetAll()
            {
                var result = _carImageService.GetAll();
                if (result.Success)
                {
                    return Ok(result.Data);
                }
                return BadRequest(result.Message);
            }


            //ICarService carService1 = new CarManager(new EfCarDal());

            [HttpPost("add")]
            public IActionResult Add([FromForm(Name = ("Image"))] IFormFile formFile, [FromForm] CarImage carImage)
            {
                var result = _carImageService.Add(formFile,carImage);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }

            [HttpPost("update")]
            public IActionResult Update([FromForm(Name = ("Image"))] IFormFile formFile, [FromForm] CarImage carImage)
            {
                var result = _carImageService.Update(formFile, carImage);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }

            [HttpPost("delete")]
            public IActionResult Delete([FromForm] CarImage carImage)
            {
                var result = _carImageService.Delete(carImage);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }




            [HttpGet("getimagebyid")]
            public IActionResult GetImageById(int carImageId)
            {
                var result = _carImageService.GetImageById(carImageId);
                if (result.Success)
                {
                    return Ok(result.Data);

                }
                return BadRequest(result.Message);
            }


            [HttpGet("getimageslistbycarid")]
            public IActionResult GetImagesByCarId(int carId)
            {
                var result = _carImageService.GetImagesByCarId(carId);
                if (result.Success)
                {
                    return Ok(result);
                }

                return BadRequest(result);
            }
        
    }
}
