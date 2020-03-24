﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieLibrary.Business
{
    public class SeedDatabase
    {
        public IMovieDatabase SeedIfEmpty ( IMovieDatabase database )
        {
            if (!database.GetAll().Any())
            {
                //Collection Initializer - works with anything with an Add method
                var demo = new Movie() { Title = "Dune", RunLength = 260, ReleaseYear = 1985 };
                var items = new[] {
                   new Movie() { Title = "Jaws", RunLength = 210, ReleaseYear = 1977 },
                   new Movie() { Title = "Jaws 2", RunLength = 220, ReleaseYear = 1979 },
                   demo
                };

                
                foreach (var item in items)
                    database.Add(item);
            };

            return database;
        }
    }
}
