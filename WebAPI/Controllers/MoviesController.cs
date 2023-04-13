using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        //Loosely coupled
        //naming convention
        //jsde ctora erişim vardır
        //IoC Container -- Inversion of Control
        IMovieService _movieService;
        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            //Swagger hazır documentation
            //Dependency chain --

            Thread.Sleep(1000);

            var result=_movieService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int movieId)
        {
            var result = _movieService.GetById(movieId);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result);
        }
        [HttpGet("getallbygenreid")]
        public IActionResult GetAllByGenreId(int Id)
        {
            var result = _movieService.GetAllByGenreId(Id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getallbymoviemypoint")]
        public IActionResult GetAllByMovieMyPoint(double min, double max)
        {
            var result = _movieService.GetAllByMovieMyPoint(min, max);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getmoviedetails")]
        public IActionResult GetMovieDetails()
        {
            var result = _movieService.GetMovieDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add(Movie movie)
        {
            var result = _movieService.Add(movie);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
