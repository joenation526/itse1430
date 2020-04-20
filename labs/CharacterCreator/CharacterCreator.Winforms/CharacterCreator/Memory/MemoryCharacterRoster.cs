/*
 * ITSE 1430
 * Spring 2020
 * Jonathan Saysanam
 */
using System;
using System.Collections.Generic;

namespace CharacterCreator
{

    public class MemoryCharacterRoster : ICharacterRoster
    {
        //TODO: change methods from public to protected override
        public Character Add ( Character character )
        {

            var errors = new ObjectValidator().TryValidate(character);
            if (errors.Any())
                return null;

            //Character names must be unique
            var existing = FindByName(character.Name);
            if (existing != null)
            {
                return null;
            }

            var item = CloneCharacter(character);
            item.Id = _id++;
            _characters.Add(item);

            return CloneCharacter(item); 
        }


        public void Delete ( int id )
        {
            if (id <= 0)
            {
                return; 
            }

            var character = FindById(id);
            if (character != null)
                _characters.Remove(character);
        }

        public Character Get ( int id )
        {
            if (id <= 0)
            {
                return null;
            }

            var character = FindById(id);
            if (character == null)
            {
                return null;
            }

            return CloneCharacter(character); 
        }

        public IEnumerable<Character> GetAll ()
        {
            foreach (var character in _characters)
            {
                yield return character; 
            };

        }

        public string Update ( int id , Character character )
        {
            //TODO: Validate
            if (character == null)
                return "character is null";
            var errors = new ObjectValidator().TryValidate(character);
            if (errors.Any())
                //if (!movie.Validate(out var error))
                return "Error";
            if (id <= 0)
                return "Id is invalid";

            var existing = FindById(id);
            if (existing == null)
                return "Character not found";

            //Movie names must be unique
            var sameName = FindByName(character.Name);
            if (sameName != null && sameName.Id != id)
                return "Character must be unique";

            //Update
            CopyCharacter(existing, character, false);

            return null;
        }


        private Character FindByName ( string name )
        {
            foreach (var character in _characters)
            {
                if (String.Compare(character?.Name, name, true) == 0)
                    return character; 
            };

            return null;
        }

        private Character FindById ( int id )
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

        private readonly List<Character> _characters = new List<Character>();
        private int _id = 1;
    }
}
