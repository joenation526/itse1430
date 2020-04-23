/*
 * ITSE 1430
 * Spring 2020
 * Jonathan Saysanam
 */

using System.Collections.Generic;
using System.Linq;

namespace CharacterCreator
{
    public abstract class CharacterRoster : ICharacterRoster
    {
        public Character Add ( Character character )
        {
            //TODO: validate
            if (character == null)
            {
                return null;
            };

            //Character names must be unique
            var existing = FindByName(character.Name);
            if (existing != null)
            {
                return null;
            };

            return AddCore(character); 
        }

        protected abstract Character AddCore ( Character character );

        public void Delete ( int id )
        {
            if (id <= 0)
            {
                return; 
            }

            DeleteCore(id);
        }

        protected abstract void DeleteCore ( int id );

        public Character Get ( int id )
        {
            if (id <= 0)
            {
                return null;
            }

            return GetCore(id); 
        }

        protected abstract Character GetCore ( int id );

        public IEnumerable<Character> GetAll () => GetAllCore() ?? Enumerable.Empty<Character>();

        protected abstract IEnumerable<Character> GetAllCore ();

        public string Update ( int id , Character character )
        {
            
            if (character == null)
                return "Character is null";

            if (id <= 0)
                return "Id is invalid";

            var existing = FindById(id);
            if (existing == null)
                return "Character not found";

            //Character names must be unique
            var sameName = FindByName(character.Name);
            if (sameName != null && sameName.Id != id)
                return "Characters must be unique";

            UpdateCore(id, character);

            return null;
        }

        protected abstract void UpdateCore ( int id, Character character );

        protected abstract Character FindById ( int id );

        protected abstract Character FindByName ( string name );

    }
}
