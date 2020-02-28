using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CharacterCreator.Winforms
{
    public partial class CreateNewCharacter : Form
    {
        public CreateNewCharacter ()
        {
            InitializeComponent();
        }

        public CreateNewCharacter ( Character character ) : this(character != null ? "Edit" : "Add", character)
        {
            
        }

        public CreateNewCharacter ( string name, Character character ) : this()
        {
            Name = name;
            Character = character; 
        }

        public Character Character { get; set; }
    }
}
