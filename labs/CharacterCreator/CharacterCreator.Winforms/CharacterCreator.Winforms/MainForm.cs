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

        private void OnExitButton ( object sender, EventArgs e )
        {
            Close();
        }

        private void OnAboutButton ( object sender, EventArgs e )
        {
            var about = new AboutBox();

            about.ShowDialog(this);
        }

        private void OnNewButton ( object sender, EventArgs e )
        {
            CreateNewCharacter child = new CreateNewCharacter();

            if (child.ShowDialog(this) != DialogResult.OK)
                return;
        }
    }
}
