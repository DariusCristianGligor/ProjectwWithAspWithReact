﻿using Application;
using AutoMapper;
using Domain;
using Domain.NormalDomain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ReviewNow.ExportDtoClases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewNow.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlacesController : ControllerBase
    {
        private readonly ILogger<PlacesController> _logger;
        private readonly IPlaceRepository _placeRepository;
        private readonly IMapper _mapper;

        public PlacesController(ILogger<PlacesController> logger, IPlaceRepository placeRepository, IMapper mapper)
        {
            _logger = logger;
            _placeRepository = placeRepository;
            _mapper = mapper;
        }
        
        [HttpGet("all")]
        public IActionResult Get()
        {
            return Ok(_placeRepository.GetAllOrderedByRating());
        }

        [HttpGet]
        public IActionResult GetAllPlacesByCityId([FromQuery] Guid cityId)
        {
        return Ok(_placeRepository.GetAllByCityId(cityId));
        }

        [HttpGet("all/categories/{cityId}")]
        public IActionResult GetAllPlacesByCityIdAndCategoryId([FromRoute]Guid cityId, [FromQuery] ICollection<Guid> categoryIds)
        {
            return Ok(_placeRepository.GetAllByCityIdAndCategoryId(cityId, categoryIds));
        }

        [HttpGet("all/categories")]
        public IActionResult GetAllPlacesByCategory([FromQuery] ICollection<Guid> categoryIds)
        {
            return Ok(_placeRepository.GetAllByCategoryId(categoryIds));
        }

        [HttpGet("all/{countryId}")]
        public IActionResult GetAllPlacesByCategoryIdAndCountryId([FromRoute] Guid countryId, [FromQuery] ICollection<Guid> categories)
        {
            return Ok(_placeRepository.GetAllByCategoryIdAndCountryId(categories, countryId));
        }

        [HttpPost]
        public async Task<IActionResult> Post(PlaceDto placeDto)
        {
            Place placeToAdd = _mapper.Map<Place>(placeDto);
            Place place=await _placeRepository.AddAsync(placeToAdd);
            PlaceExpDto placeExpDto = _mapper.Map<PlaceExpDto>(place);
            return Created("~", placeExpDto);
  
        }

        [HttpDelete("{placeId}")]
        public IActionResult Delete(Guid placeId)
        {
            if (_placeRepository.Find(placeId) == false)
                return NotFound();
            _placeRepository.Delete(placeId);
            return NoContent();
        }


    }
}