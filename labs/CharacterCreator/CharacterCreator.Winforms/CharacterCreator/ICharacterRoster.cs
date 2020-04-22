/*
 * ITSE 1430
 * Spring 2020
 * Jonathan Saysanam
 */

using System.Collections.Generic;

namespace CharacterCreator
{
    public interface ICharacterRoster
    {
        //TODO: Properly document these types
        Character Add ( Character character );
        void Delete ( int id );
        Character Get ( int id );
        IEnumerable<Character> GetAll ();
        string Update ( int id, Character character );
    }
}
