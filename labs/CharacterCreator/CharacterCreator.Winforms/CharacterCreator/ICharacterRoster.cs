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
        /// <summary>Adds a character to the roster</summary>
        /// <param name="character">The character to add.</param>
        /// <returns>The new character with unique identifier.</returns>
        /// Error: Character is invalid.
        /// Error: Character with the same name already exists.
        Character Add ( Character character );

        /// <summary>Deletes a character.</summary>
        /// <param name="id">The character to remove.</param>
        /// Error: Id is less than or equal zero.
        void Delete ( int id );

        /// <summary>Gets a specific character from the roster.</summary>
        /// <param name="id">Character to get.</param>
        /// <returns>Immutable character or null.</returns>
        /// Error: Id is less than or equal to zero.
        Character Get ( int id );

        /// <summary>Gets all the characters in the roster.</summary>
        /// <returns>The immutable list of characters. Changes to the returned list of characters should not impact the original roster.</returns>
        IEnumerable<Character> GetAll ();

        /// <summary>Updates an existing character in the roster</summary>
        /// <param name="id">Identifier of the character to update</param>
        /// <param name="character">New character information</param>
        /// <returns>Updated character, if any changes were made.</returns>
        /// Error: Updated character is invalid.
        /// Error: Existing character cannot be found or is invalid.
        /// Error: If character's name change and matches with another in the roster.
        string Update ( int id, Character character );
    }
}
