/*
 * ITSE 1430
 * Spring 2020
 * Jonathan Saysanam
 */

namespace CharacterCreator
{
    public class Profession
    {
        public Profession ( string description )
        {
            Description = description ?? "";
        }

        public string Description { get; }

        public override string ToString ()
        {
            return Description;
        }

        public class Professions
        {
            public static Profession[] GetAll ()
            {
                var items = new Profession[5];
                items[0] = new Profession("Fighter");
                items[1] = new Profession("Hunter");
                items[2] = new Profession("Priest");
                items[3] = new Profession("Rogue");
                items[4] = new Profession("Wizard");

                return items;
            }
        }
    }
}
