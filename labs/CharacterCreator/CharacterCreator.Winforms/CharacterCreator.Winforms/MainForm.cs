using System;
using System.Windows.Forms;



namespace CharacterCreator.Winforms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad ( EventArgs e )
        {
            base.OnLoad(e);

        }

        private void OnNewCharacter ( object sender, EventArgs e )
        {
            CreateNewCharacter child = new CreateNewCharacter();

            if (child.ShowDialog(this) != DialogResult.OK)
                return;

            AddCharacter(child.Character);
        }

        private void AddCharacter ( Character character )
        {
            if (character == null)
            {
                _character = character;
                return;
            };
        }
        private Character _character = new Character();

        private Character GetCharacter ()
        {
            return _character as Character;
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

        private void UpdateCharacter ( Character oldCharacter, Character newCharacter )
        {
            if (_character == oldCharacter)
            {
                _character = newCharacter;
                return;
            };
        }

        private void OnCharacterEdit ( object sender, EventArgs e )
        {
            var character = GetCharacter();
            if (character == null)
                return;

            var child = new CreateNewCharacter();
            child.Character = character;
            if (child.ShowDialog(this) != DialogResult.OK)
                return;

            UpdateCharacter(character, child.Character);
        }
    }
}
