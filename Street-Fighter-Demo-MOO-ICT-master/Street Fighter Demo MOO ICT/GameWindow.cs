using System.Windows.Forms;

namespace Street_Fighter_Demo_MOO_ICT
{
    public partial class GameWindow : Form
    {
        private string selectedCharacter;

        public GameWindow(string characterName)
        {
            InitializeComponent();
            selectedCharacter = characterName;
            SetUpGame();
        }

        private void SetUpGame()
        {
            // Configurar o background e o personagem com base na escolha
            // Substituir com lógica para carregar os sprites e iniciar o jogo com o personagem selecionado
        }
    }
}
