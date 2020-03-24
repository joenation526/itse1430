using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieLibrary.Business
{
    //public interface ISelectableObject
    //{
    //    void Select ();
    //}

    //public interface IResizeableObject
    //{
    //    void Resize ( int width, int height ); 
    //}

    //public class SelectableResizeable : IResizeableObject, ISelectableObject
    //{
    //    public void Resize ( int width, int height );

    //    public void Select ();
    //}

    public class ObjectValidator
    {
        public IEnumberable<ValidationResult> Validate ( object value )
        {
            var errors = new List<ValidationResult>();

            Validator.TryValidateObject(value, new ValidationContext(value), errors, true);

            return errors;
        }
    }
}
