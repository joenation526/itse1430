﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieLibrary.Business
{
    //Only contain static class
    //Cannot Create an instance
    // Rule - 1 Never create a type called ?Helper or ?Utility or ?Common
    // Rule - 2 No data
    // Rule - 3 Don't treat as global functions/variables
    public static class ObjectValidator
    {
        //Global function
        public static IEnumerable<ValidationResult> Validate ( object value )
        {
            //this.InstanceFoo()
            StaticFoo();

            var errors = new List<ValidationResult>();

            Validator.TryValidateObject(value, new ValidationContext(value), errors, true);

            return errors;
        }

       // private void InstanceFoo (/*Object validator*/) {  }

        private static void StaticFoo () { }

        //Global variables
        //private static ObjectValidator Instance = new ObjectValidator();

    }
}
