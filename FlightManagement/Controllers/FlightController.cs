using AutoMapper;
using FlightManagement.DTO;
using FlightManagement.Entitys;
using FlightManagement.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace FlightManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        private readonly IFlightInterface flightService;
        private readonly IMapper _mapper;
        private readonly ILogger<FlightController> _logger;

        public FlightController(IFlightInterface flightService, IMapper mapper, ILogger<FlightController> logger)
        {
            this.flightService = flightService;
            _mapper = mapper;
            this._logger = logger;
        }

        [HttpGet("GetAllFlights")]
        [Authorize]
        public IActionResult GetAllFlights()
        {
            try
            {
                List<Flight> flights = flightService.GetFlights();
                List<FlightDTO> flightsDTO = _mapper.Map<List<FlightDTO>>(flights);
                return Ok(flightsDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, "An error occurred while retrieving flights.");
            }
        }

        [HttpPost("AddFlight")]
        [Authorize]
        public IActionResult AddFlight(FlightDTO flightDTO)
        {
            try
            {
                Flight flight = _mapper.Map<Flight>(flightDTO);
                flightService.AddFlight(flight);
                return StatusCode(201, "Flight added successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, "An error occurred while adding the flight.");
            }
        }

        [HttpGet("GetFlightById/{flightNumber}")]
        [Authorize]
        public IActionResult GetFlightById(string flightNumber)
        {
            try
            {
                Flight flight = flightService.GetFlightById(flightNumber);
                if (flight != null)
                {
                    FlightDTO flightDTO = _mapper.Map<FlightDTO>(flight);
                    return Ok(flightDTO);
                }
                else
                {
                    return NotFound("Flight not found.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, "An error occurred while retrieving the flight.");
            }
        }

        [HttpPut("UpdateFlight")]
        [Authorize(Roles = "Admin")]
        public IActionResult UpdateFlight(FlightDTO flightDTO)
        {
            try
            {
                Flight flight = _mapper.Map<Flight>(flightDTO);
                flightService.UpdateFlight(flight);
                return Ok("Flight updated successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, "An error occurred while updating the flight.");
            }
        }

        [HttpDelete("DeleteFlight/{flightNumber}")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteFlight(string flightNumber)
        {
            try
            {
                flightService.DeleteFlight(flightNumber);
                return Ok($"Flight with number {flightNumber} deleted successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, "An error occurred while deleting the flight.");
            }
        }
    }
}
