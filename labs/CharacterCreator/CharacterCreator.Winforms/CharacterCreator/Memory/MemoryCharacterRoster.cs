/*
 * ITSE 1430
 * Spring 2020
 * Jonathan Saysanam
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CharacterCreator.Winforms;

namespace CharacterCreator.Memory
{
    public class MemoryCharacterRoster : CharacterRoster
    {
        //TODO: change methods from public to protected override
        protected override Character AddCore ( Character character )
        {

            var errors = ObjectValidator.Validate(character);
            var error = errors.FirstOrDefault();
            if (errors.Any())
            {
                var errorMessage = error?.ErrorMessage;
                DisplayError(errorMessage);
                return null;
            }

            var item = CloneCharacter(character);
            item.Id = _id++;
            _characters.Add(item);

            return CloneCharacter(item); 
        }


        protected override void DeleteCore ( int id )
        {

            var character = FindById(id);
            if (character != null)
                _characters.Remove(character);
        }

        protected override Character GetCore ( int id )
        {

            var character = FindById(id);
            if (character == null)
            {
                return null;
            }

            return CloneCharacter(character); 
        }

        protected override IEnumerable<Character> GetAllCore ()
        {
            foreach (var character in _characters)
            {
                yield return character; 
            };

        }

        protected override void UpdateCore ( int id, Character character )
        {
            var existing = FindById(id);


            var errors = ObjectValidator.Validate(character);
            var error = errors.FirstOrDefault();
            if (errors.Any())
            {
                var errorMessage = error?.ErrorMessage;
                DisplayError(errorMessage);
                return;
            }

            //Update
            CopyCharacter(existing, character, false);
        }


        protected override Character FindByName ( string name )
        {
            foreach (var character in _characters)
            {
                if (String.Compare(character?.Name, name, true) == 0)
                    return character; 
            };

            return null;
        }

        protected override Character FindById ( int id )
        {
            foreach (var character in _characters)
            {
                if (character.Id == id)
                    return character; 
            };

            return null; 
        }

        private Character CloneCharacter ( Character character )
        {
            var item = new Character();
            CopyCharacter(item, character, true);

            return item; 
        }

        private void CopyCharacter ( Character target, Character source, bool includeId )
        {
            if (includeId)
                target.Id = source.Id;

            target.Name = source.Name;
            target.Description = source.Description;

            if (source.Profession != null)
                target.Profession = new Profession(source.Profession.Description);
            else
                target.Profession = null;


            if (source.Race != null)
                target.Race = new Race(source.Race.Description);
            else
                target.Race = null;

            target.Strength = source.Strength;
            target.Intelligence = source.Intelligence;
            target.Agility = source.Agility;
            target.Constitution = source.Constitution;
            target.Charisma = source.Charisma;
        }

        private void DisplayError ( string errors )
        {
            MessageBox.Show(errors, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private readonly List<Character> _characters = new List<Character>();
        private int _id = 1;
    }
}
