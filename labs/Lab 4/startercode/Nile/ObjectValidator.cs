/*
 * ITSE 1430
 * Spring 2020
 * Jonathan Saysanam
 */
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Nile.Windows
{
    public static class ObjectValidator
    {
        public static IEnumerable<ValidationResult> Validate ( Product value )
        {
            var errors = new List<ValidationResult>();

            Validator.TryValidateObject(value, new ValidationContext(value), errors, true);

            return errors;
        }
    }
}