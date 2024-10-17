using System;
using System.Windows.Forms;

namespace Street_Fighter_Demo_MOO_ICT
{
    public partial class CharacterSelection : Form
    {
        public CharacterSelection()
        {
            InitializeComponent();
            SetUpCharacterSelection();
        }

        private void SetUpCharacterSelection()
        {
            Label label = new Label
            {
                Text = "Escolha seu personagem:",
                Width = 300,
                Height = 30,
                Top = 20,
                Left = (this.ClientSize.Width - 300) / 2
            };
            this.Controls.Add(label);

            // Botões dos personagens
            Button btnCharacter1 = new Button
            {
                Text = "Personagem 1",
                Width = 150,
                Height = 200,
                Top = 100,
                Left = (this.ClientSize.Width / 2) - 200
            };

            Button btnCharacter2 = new Button
            {
                Text = "Personagem 2",
                Width = 150,
                Height = 200,
                Top = 100,
                Left = (this.ClientSize.Width / 2) + 50
            };

            btnCharacter1.Click += BtnCharacter_Click;
            btnCharacter2.Click += BtnCharacter_Click;

            this.Controls.Add(btnCharacter1);
            this.Controls.Add(btnCharacter2);
        }

        private void BtnCharacter_Click(object sender, EventArgs e)
        {
            Button selectedButton = sender as Button;
            string characterName = selectedButton.Text;

            // Criar e passar o nome do personagem para Form1
            Form1 gameWindow = new Form1(characterName);
            gameWindow.Show();
            this.Hide();
        }
    }
}
