using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary.Business
{
    /// <summary>
    /// Represents a movie
    /// </summary>
    /// <remarks>
    /// Lots of info.
    /// </remarks>
    public class Movie
    {
        public string title;

        public int runLength;

        /// <summary>
        /// Run length in minutes 
        /// </summary>
        public string description;

        public int releaseYear = 2014;

        public bool isClassic;
    }
}
