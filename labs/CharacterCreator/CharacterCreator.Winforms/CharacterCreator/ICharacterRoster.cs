using System.Collections.Generic;

namespace CharacterCreator
{
    public interface ICharacterRoster
    {
        Character Add ( Character character );

        void Delete ( int id );

        Character Get ( int id );

        IEnumerable<Character> GetAll ();

        string Update ( int id, Character character );
    }
}
