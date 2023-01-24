using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class MovieValidator:AbstractValidator<Movie>
    {
        public MovieValidator()
        {
            RuleFor(m => m.MovieName).NotEmpty();
            RuleFor(m => m.MovieName).MinimumLength(2);
            RuleFor(m => m.MovieImdbPoint).NotEmpty();
            RuleFor(m => m.MovieImdbPoint).GreaterThan(0);
            RuleFor(m => m.MovieImdbPoint).GreaterThanOrEqualTo(7).When(m => m.MovieListedOn >= 5);
            RuleFor(m => m.MovieName).Must(StartWithA).WithMessage("Film isimleri A harfi ile başlamalı.");
        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
