/*
 * ITSE 1430
 * Spring 2020
 * Jonathan Saysanam
 */


namespace CharacterCreator
{
    public class Race
    {
        public Race ( string description )
        {
            Description = description ?? "";
        }

        public string Description { get; }

        public override string ToString ()
        {
            return Description;
        }

        public class Races
        {
            public static Race[] GetAll ()
            {
                var items = new Race[5];
                items[0] = new Race("Dwarf");
                items[1] = new Race("Elf");
                items[2] = new Race("Gnome");
                items[3] = new Race("Half Elf");
                items[4] = new Race("Human");

                return items;
            }
        }
    }
}
