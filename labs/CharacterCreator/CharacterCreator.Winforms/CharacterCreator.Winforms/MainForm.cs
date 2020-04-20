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

            _characters = new MemoryCharacterRoster();
        }

        protected override void OnLoad ( EventArgs e )
        {
            base.OnLoad(e);

            UpdateUI(); 
        }

        void DisplayCharacter ( Character character )
        {
            if (character == null)
            {
                return;
            }

            var name = character.Name;
            character.Description = "Test";

            character = new Character(); 
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

        private Character GetSelectedCharacter ()
        {
            return listCharacters.SelectedItem as Character;
        }

        private void UpdateUI ()
        {
            listCharacters.Items.Clear();

            var characters = _characters.GetAll();
            foreach (var character in characters)
            {
                listCharacters.Items.Add(character);  
            };
        }

        #region Event handlers

        private void OnNewCharacter ( object sender, EventArgs e )
        {
            CharacterForm child = new CharacterForm();

            if (child.ShowDialog(this) != DialogResult.OK)
                return;

            _characters.Add(child.Character);
            UpdateUI(); 
        }


        private void OnCharacterEdit ( object sender, EventArgs e )
        {
            var character = GetSelectedCharacter();
            if (character == null)
                return; 

            var child = new CharacterForm();
            child.Character = character;

            do
            {
                if (child.ShowDialog(this) != DialogResult.OK)
                    return;

                // Save the movie
                var error = _characters.Update(character.Id, child.Character);
                if (String.IsNullOrEmpty(error))
                {
                    UpdateUI();
                    return;
                };

                DisplayError(error);
            } while (true);
        }


        private void OnCharacterDelete ( object sender, EventArgs e )
        {
            var character = GetSelectedCharacter();
            if (character == null)
                return;

            //Confirm
            if (!DisplayConfirmation($"Are you sure you want to delete {character.Name}?", "Delete"))
                return;

            _characters.Delete(character.Id);
            UpdateUI();
        }
        #endregion

        #region Private Members

        private readonly ICharacterRoster _characters;
  

        private bool DisplayConfirmation ( string message, string title )
        {
            //Display a confirmation dialog
            var result = MessageBox.Show(message, title, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            //Return true if user selected OK
            return result == DialogResult.OK;
        }

        private void DisplayError ( string message )
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        #endregion

        
    }
}
