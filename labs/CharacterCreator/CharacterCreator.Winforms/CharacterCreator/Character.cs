using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreator
{
    public class Character
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

        public bool Validate ( out string error )
        {
            if (String.IsNullOrEmpty(Name))
            {
                error = "Name is required";
                return false; 
            };

            if (Profession == null)
            {
                error = "Select a profession";
                return false; 
            };

            if (Race == null)
            {
                error = "Select a race";
                return false;
            };

            if (Strength == 0)
            {
                error = "Cannot have 0 strength.";
                return false;
            };

            if (Intelligence == 0)
            {
                error = "Cannot have 0 intelligence.";
                return false;
            };

            if (Agility == 0)
            {
                error = "Cannot have 0 agility.";
                return false;
            };

            if (Constitution == 0)
            {
                error = "Cannot have 0 constitution.";
                return false;
            };

            if (Charisma == 0)
            {
                error = "Cannot have 0 charisma.";
                return false;
            };

            error = null;
            return true;
        }
    }
}
