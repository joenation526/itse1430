/*
 * ITSE 1430
 * Spring 2020
 * Jonathan Saysanam
 */

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CharacterCreator
{
    public class Character : IValidatableObject
    {
        public string Name
        {
            get { return _name ?? ""; }
            set { _name = value?.Trim(); }
        }
        private string _name;

        /// <summary>
        /// Profession and Race will be used in a combo box
        /// They are sepereated into different cs files
        /// </summary>
        public Profession Profession { get; set; }

        public Race Race { get; set; }

        /// <summary>
        /// Attributes for the increment/decrement boxes
        /// </summary>
        /// <value>
        /// Default by 50 
        /// </value>
        public int Strength { get; set; } 
        public int Intelligence { get; set; } 
        public int Agility { get; set; } 
        public int Constitution { get; set; } 
        public int Charisma { get; set; } 

        public int Id { get; set; }

        public string Description
        {
            get { return _description ?? ""; }
            set { _description = value?.Trim(); }
        }
        private string _description;

        public override string ToString ()
        {
            return Name;
        }

        public IEnumerable<ValidationResult> Validate ( ValidationContext validationContext )
        {
            if (String.IsNullOrEmpty(Name))
            {
                yield return new ValidationResult("Name is required", new[] { nameof(Name) });
            };

            if (Profession?.Description is null)
            {
                yield return new ValidationResult("Profession is required", new[] { nameof(Profession) });
            }

            if (Race?.Description is null)
            {
                yield return new ValidationResult("Race is required", new[] { nameof(Race) });
            }

            if (Strength == 0)
            {
                yield return new ValidationResult("Cannot have 0 strength.", new[] { nameof(Strength) });
            };

            if (Strength > 100)
            {
                yield return new ValidationResult("Cannot have >100 strength.", new[] { nameof(Strength) });
            }; 

            if (Intelligence == 0)
            {
                yield return new ValidationResult("Cannot have 0 intelligence.", new[] { nameof(Intelligence) });
            };

            if (Intelligence > 100)
            {
                yield return new ValidationResult("Cannot have >100 intelligence.", new[] { nameof(Intelligence) });
            };

            if (Agility == 0)
            {
                yield return new ValidationResult("Cannot have 0 agility.", new[] { nameof(Agility) });
            };

            if (Agility > 100)
            {
                yield return new ValidationResult("Cannot have >100 agility.", new[] { nameof(Agility) });
            };

            if (Constitution == 0)
            {
                yield return new ValidationResult("Cannot have 0 constitution.", new[] { nameof(Constitution) });
            };

            if (Constitution > 100)
            {
                yield return new ValidationResult("Cannot have >100 constitution.", new[] { nameof(Constitution) });
            };

            if (Charisma == 0)
            {
                yield return new ValidationResult("Cannot have 0 charisma.", new[] { nameof(Charisma) });
            };

            if (Charisma > 100)
            {
                yield return new ValidationResult("Cannot have >100 Charisma.", new[] { nameof(Charisma) });
            };
        }
    }
}
