using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DamaPaci2
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void Play_Click(object sender, EventArgs e)
        {
            if(OnePlayer.Checked)
            {
                var f = new LogicaAI();
                f.ShowDialog();
            }
            else if(TwoPlayers.Checked)
            {
                var f = new Logica();
                f.ShowDialog();
            }
        }

        private void TwoPlayers_CheckedChanged(object sender, EventArgs e)
        {
            OnePlayer.Checked = false;
        }

        private void OnePlayer_CheckedChanged(object sender, EventArgs e)
        {
            TwoPlayers.Checked = false;
        }
    }
}
