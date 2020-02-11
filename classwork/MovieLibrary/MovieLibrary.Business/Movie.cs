using System;

namespace MovieLibrary.Business
{
    /// <summary>Represents a movie.</summary>
    /// <remarks>
    /// Lots of info.
    /// </remarks>
    public class Movie
    {
        /// <summary>Gets or sets the title.</summary>
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        private string _title;

        /// <summary>Gets or sets the run length in minutes.</summary>
        public int runLength;

        /// <summary>Gets or sets the description.</summary>
        public string description;

        /// <summary>Gets or sets the release year.</summary>
        /// <value>Default is 1900.</value>
        public int releaseYear = 1900;

        /// <summary>Determines if this is a classic movie.</summary>
        public bool isClassic;
    }
}

