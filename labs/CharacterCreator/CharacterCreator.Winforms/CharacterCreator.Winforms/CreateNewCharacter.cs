using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static CharacterCreator.Profession;
using static CharacterCreator.Race;

namespace CharacterCreator.Winforms
{
    public partial class CreateNewCharacter : Form
    {
        public CreateNewCharacter ()
        {
            InitializeComponent();
        }

        public Character Character { get; set; }

        private void OnCancel ( object sender, EventArgs e )
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void OnSave ( object sender, EventArgs e )
        {
            if (!ValidateChildren())
                return;

            var character = GetCharacter();
            if (!character.Validate(out var error))
            {
                DisplayError(error);
                return;
            }

            Character = character;
            DialogResult = DialogResult.OK;
            Close();
        }

        protected override void OnLoad ( EventArgs e )
        {
            base.OnLoad(e);

            // Filling Combo box from Profession.cs
            var profession = Professions.GetAll();
            ddlProfession.Items.AddRange(profession);

            // Filling Combo box from Race.cs
            var race = Races.GetAll();
            ddlRace.Items.AddRange(race);

            if (Character != null)
            {
                txtName.Text = Character.Name;
                txtDescription.Text = Character.Description;
                numericAgility.Value = Character.Agility;
                numericCharisma.Value = Character.Charisma;
                numericConstitution.Value = Character.Constitution;
                numericIntelligience.Value = Character.Intelligence;
                numericStrength.Value = Character.Strength; 

                if (Character.Profession != null)
                    ddlProfession.SelectedText = Character.Profession.Description;

                if (Character.Race != null)
                    ddlRace.SelectedText = Character.Race.Description;

                ValidateChildren();
            }
        }

        private Character GetCharacter ()
        {
            var character = new Character();

            character.Name = txtName.Text?.Trim();
            character.Description = txtDescription.Text.Trim();
            character.Agility = GetAsInt32(numericAgility);
            character.Charisma = GetAsInt32(numericCharisma);
            character.Constitution = GetAsInt32(numericConstitution);
            character.Intelligence = GetAsInt32(numericIntelligience);
            character.Strength = GetAsInt32(numericStrength);
            
            if (ddlProfession.SelectedItem is Profession profession)
                character.Profession = profession;

            if (ddlRace.SelectedItem is Race race)
                character.Race = race;

            return character; 
        }

        private void DisplayError ( string message )
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private int GetAsInt32 ( Control control )
        {
            return GetAsInt32(control, 0);
        }

        private int GetAsInt32 ( Control control, int emptyValue )
        {
            if (String.IsNullOrEmpty(control.Text))
                return emptyValue;

            if (Int32.TryParse(control.Text, out var result))
                return result;

            return -1;
        }

        private void OnValidateName ( object sender, CancelEventArgs e )
        {
            var control = sender as TextBox;

            if (String.IsNullOrEmpty(control.Text))
            {
                // DisplayError("Title is required");
                _errorName.SetError(control, "Name is required");
                e.Cancel = true;

            } 
            else
            {
                _errorName.SetError(control, "");
            }
        }

        private void OnValidateAttribute ( object sender, System.ComponentModel.CancelEventArgs e )
        {
            var control = sender as Control;
            var value = GetAsInt32(control, 0);
            if (value == 0)
            {
                _errorAttribute.SetError(control, "Attribute must be greater than 0.");
                e.Cancel = true;
            } 
            else
            {
                _errorAttribute.SetError(control, "");
            }
        }

        private void OnValidateProfession ( object sender, EventArgs e )
        {
            var control = sender as ComboBox;

            if (String.IsNullOrEmpty(control.Text))
            {
                _errorComboBox.SetError(control, "Please select profession");
                return;
            } 
            else 
            {
                _errorComboBox.SetError(control, "");
            }
        }
        private void OnValidateRace ( object sender, EventArgs e )
        {
            var control = sender as ComboBox;

            if (String.IsNullOrEmpty(control.Text))
            {
                _errorComboBox.SetError(control, "Please select Race");
                return;
            } else
            {
                _errorComboBox.SetError(control, "");
            }
        }
    }
}

