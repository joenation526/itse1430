/*
 * ITSE 1430
 * Spring 2020
 * Jonathan Saysanam
 */

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CharacterCreator.Winforms
{
    public static class ObjectValidator 
    {
        public static IEnumerable<ValidationResult> Validate ( Character value )
        {
            var errors = new List<ValidationResult>();

            Validator.TryValidateObject(value, new ValidationContext(value), errors, true);

            return errors;
        }
    }


}

