using System;
using System.Media;
using System.Windows.Forms;

namespace Street_Fighter_Demo_MOO_ICT
{
    public partial class MainMenu : Form
    {
        private SoundPlayer backgroundMusic;

        public MainMenu()
        {
            InitializeComponent();
            SetUpMenu();
        }

        private void SetUpMenu()
        {
            // Carregar e tocar música de fundo
            backgroundMusic = new SoundPlayer("C:\\DevC\\!Projeto-01\\Street-Fighter-Demo-MOO-ICT-master\\Street Fighter Demo MOO ICT\\Properties\\Som\\01-Title-Screen.wav");
            backgroundMusic.PlayLooping();

            // Configurar o botão de jogar
            Button btnPlay = new Button
            {
                Text = "Jogar",
                Width = 200,
                Height = 50,
                Top = this.ClientSize.Height - 100,
                Left = (this.ClientSize.Width - 200) / 2
            };

            btnPlay.Click += BtnPlay_Click;
            this.Controls.Add(btnPlay);
        }

        private void BtnPlay_Click(object sender, EventArgs e)
        {
            // Parar a música ao mudar de tela
            backgroundMusic.Stop();

            // Navegar para a tela de seleção de personagens
            CharacterSelection characterSelection = new CharacterSelection();
            characterSelection.Show();
            this.Hide();
        }
    }
}
