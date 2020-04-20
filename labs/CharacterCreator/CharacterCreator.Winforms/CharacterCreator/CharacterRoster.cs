/*
 * ITSE 1430
 * Spring 2020
 * Jonathan Saysanam
 */
using System;
using System.Collections.Generic;

namespace CharacterCreator
{
    public abstract class CharacterRoster : ICharacterRoster
    {
        //TODO: implement interface in this class file
        public Character Add ( Character character )
        {
            //TODO: validate
            if (character == null)
            {
                return null;
            };

            var errors = new ObjectValidator().TryValidate(character);

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
                yield return CloneCharacter(character);
            }
        }

        public string Update ( int id , Character newCharacter )
        {
            for (var index = 0; index < _characters.Count; ++index) // .Length substitude
            {
                if (_characters[index]?.Id == id)
                {
                    _characters[index] = newCharacter;
                    break;
                };
            };

            return null;
        }

        private object FindByName ( string name )
        {
            foreach (var character in _characters)
            {
                if (String.Compare(character?.Name, name, true) == 0)
                    return character; 
            };

            return null;
        }

        private object FindById ( int id )
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
            return new Character() {
                Name = character.Name,
                Description = character.Description,
                Profession = new Profession(character.Profession.Description),
                Race = new Race(character.Race.Description),
                Strength = character.Strength,
                Intelligence = character.Intelligence,
                Agility = character.Agility,
                Constitution = character.Constitution,
                Charisma = character.Charisma,
            };
        }


        //private void CopyCharacter ( Character target, Character source, bool includeId )
        //{
        //    if (includeId)
        //        target.Id = source.Id;

        //    target.Name = source.Name;
        //    target.Description = source.Description;

        //    if (source.Profession != null)
        //        target.Profession = new Profession(source.Profession.Description);
        //    else
        //        target.Profession = null;


        //    if (source.Race != null)
        //        target.Race = new Race(source.Race.Description);
        //    else
        //        target.Race = null;

        //    target.Strength = source.Strength;
        //    target.Intelligence = source.Intelligence;
        //    target.Agility = source.Agility;
        //    target.Constitution = source.Constitution;
        //    target.Charisma = source.Charisma;
        //}

        private readonly List<Character> _characters = new List<Character>();
        private int _id = 1;
    }
}
