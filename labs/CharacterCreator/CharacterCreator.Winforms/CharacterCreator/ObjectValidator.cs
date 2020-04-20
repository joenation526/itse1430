/*
 * ITSE 1430
 * Spring 2020
 * Jonathan Saysanam
 */
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CharacterCreator
{
    public class ObjectValidator
    {
        public IEnumerable<ValidationResult> TryValidate ( object value )
        {
            var errors = new List<ValidationResult>();

            Validator.TryValidateObject(value, new ValidationContext(value), errors, true);

            return errors;
        }
    }
}
