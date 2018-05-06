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
    public partial class LogicaAI : Grafica
    {
        public LogicaAI()
        {
            InitializeComponent();
            for (int r = 0; r < righe; r++)
                for (int c = 0; c < colonne; c++)
                    if ((r + c) % 2 == 0) pannello[r, c].Click += new EventHandler(MoveTo);
        }

        protected void MoveTo(object sender, EventArgs e)
        {
            if (pedina == null) return;
            if ((pedina.color == ColoriPedine.red && turno == Turni.black) || (pedina.color == ColoriPedine.black && turno == Turni.red)) return;
            PanelRC[] percorsi = pedina.percorsiMove;
            PanelRC[] percorsi2 = pedina.percorsiEat;
            PanelRC destinazione = sender as PanelRC;
            PanelRC corrente = pedina.Parent as PanelRC;
            PanelRC temp = corrente;
            int dirY, dirX;

            for (int j = 0; j < 2; j++) //cicla sui due array
            {
                if (corrente.posY > destinazione.posY) dirY = -1;
                else dirY = 1;
                if (corrente.posX > destinazione.posX) dirX = -1;
                else dirX = 1;
                for (int i = 0; i < percorsi.Length; i++)
                {
                    if (percorsi[i] == destinazione)
                    {
                        CancellaPercorsi(pedina);
                        do
                        {
                            temp = pannello[temp.posX + dirX, temp.posY + dirY];
                            if (temp.pedina != null)
                            {
                                Pedina curr = temp.pedina;
                                temp.Controls.Remove(curr);
                                temp.pedina = null;
                                curr.Dispose();
                                if (turno == Turni.red) pedineNere--;
                                else pedineRosse--;
                                GameOver();
                                RefreshPedineMancanti();
                            }
                        }
                        while (temp != destinazione);

                        destinazione.pedina = pedina;
                        destinazione.Controls.Add(pedina);

                        switch (destinazione.pedina.color)
                        {
                            case ColoriPedine.red:
                                if (destinazione.posY == righe - 1)
                                {
                                    Pedina curr = destinazione.pedina;
                                    destinazione.Controls.Remove(curr);
                                    curr.Dispose();
                                    Damone dam;
                                    dam = new Damone(ColoriPedine.red, destinazione);
                                    dam.Click += new EventHandler(PercorsiDisponibili);
                                }
                                break;

                            case ColoriPedine.black:
                                if (destinazione.posY == 0)
                                {
                                    Pedina curr = destinazione.pedina;
                                    destinazione.Controls.Remove(curr);
                                    curr.Dispose();
                                    Damone dam;
                                    dam = new Damone(ColoriPedine.black, destinazione);
                                    dam.Click += new EventHandler(PercorsiDisponibili);
                                }
                                break;
                        }
                        for (int y = 0; y < righe; y++)
                            for (int x = 0; x < colonne; x++)
                            {
                                if ((y + x) % 2 == 0)
                                {
                                    if (pannello[y, x].pedina != null)
                                    {
                                        pedina = pannello[y, x].pedina;
                                        Array.Clear(pedina.percorsiMove, 0, 4);
                                        Array.Clear(pedina.percorsiEat, 0, 4);
                                    }

                                }
                            }
                        PercorsiDisponibili(pannello[1, 5], null);
                        Suggerimenti.Text = "Turno dei " + turno;
                        corrente.pedina = null;
                        pedina = null;
                        devoMangiare = false;

                    }

                }
                percorsi = percorsi2;
            }
        }
    }
}
