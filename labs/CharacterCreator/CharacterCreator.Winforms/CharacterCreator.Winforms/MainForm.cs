/*
 * ITSE 1430
 * Spring 2020
 * Jonathan Saysanam
 */

using System;
using System.Windows.Forms;

namespace CharacterCreator.Winforms
{
    public partial class MainForm : Form
    {
        public MainForm ()
        {
            InitializeComponent();
        }

        private bool DisplayConfirmation ( string message, string title )
        {
            //Display a confirmation dialog
            var result = MessageBox.Show(message, title, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            //Return true if user selected OK
            return result == DialogResult.OK;
        }

        private void OnNewCharacter ( object sender, EventArgs e )
        {
            CharacterForm child = new CharacterForm();

            if (child.ShowDialog(this) != DialogResult.OK)
                return;

            AddCharacter(child.Character);
        }

        private void AddCharacter ( Character character )
        {
            if (_character == null)
            {
                _character = character;
            };
        }

        private Character GetCharacter ()
        {
            return _character;
        }
        
        private void OnAboutButton ( object sender, EventArgs e )
        {
            var about = new AboutBox();

            about.ShowDialog(this);
        }

        private void OnExitButton ( object sender, EventArgs e )
        {
            Close();
        }


        private void OnCharacterEdit ( object sender, EventArgs e )
        {
            var character = _character;
            if (character == null)
                return;

            var child = new CharacterForm();
            child.Character = character;
            if (child.ShowDialog(this) != DialogResult.OK)
                return;

            _character = child.Character;
        }

        private void DeleteCharacter ( Character character )
        {
            if (_character == character)
            {
                _character = null;
            };
        }

        private void OnCharacterDelete ( object sender, EventArgs e )
        {
            var character = GetCharacter();
            if (character == null)
                return;

            //Confirm
            if (!DisplayConfirmation($"Are you sure you want to delete {character.Name}?", "Delete"))
                return;

            DeleteCharacter(character);
        }

        private Character _character;
    }
}
