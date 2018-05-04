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
    public partial class Logica : Grafica
    {
        public Logica()
        {
            InitializeComponent();

            for (var i = 0; i < 8; i++)
                for (var j = 0; j < 8; j++)
                    pannello[i, j].Click += new EventHandler(MoveTo);
        }

        protected void MoveTo(object sender, EventArgs e)
        {
            if (pedina == null)
                return;
            if ((pedina.color == ColoriPedine.red && !turnoRossi) || (pedina.color == ColoriPedine.black && turnoRossi)) return;

            PanelRC destination = sender as PanelRC;
            PanelRC source = pedina.Parent as PanelRC;
            PanelRC[] routes = pedina.GeneraPercorsi(this);
            PanelRC temp = source;

            int directionY;
            if (source.posY > destination.posY)
            {
                directionY = -1;
            }
            else
            {
                directionY = 1;
            }

            int directionX;
            if (source.posX > destination.posX)
            {
                directionX = -1;
            }
            else
            {
                directionX = 1;
            }

            for (int i = 0; i < routes.Length; i++)
            {
                if (routes[i] == destination)
                {
                    CancellaPercorsi(pedina);

                    do
                    {
                        temp = pannello[temp.posX + directionX, temp.posY + directionY];
                        if (temp.pedina != null)
                        {
                            Pedina occupier = temp.pedina;
                            temp.Controls.Remove(occupier);
                            temp.pedina = null;
                            occupier.Dispose();
                            if (turnoRossi) pedineNere--;
                            else pedineRosse--;
                            GameOver();
                           // RefreshPedineMancanti();
                        }
                    }
                    while (temp != destination);

                    destination.pedina = pedina;
                    destination.Controls.Add(pedina);
                    source.pedina = null;
                    pedina = null;

                    switch (destination.pedina.color)
                    {
                        case ColoriPedine.red:
                            if (destination.posY == 7)
                            {
                                Pedina occupier = destination.pedina;
                                destination.Controls.Remove(occupier);
                                occupier.Dispose();
                                new King(ColoriPedine.red, destination);
                            }
                            break;

                        case ColoriPedine.black:
                            if (destination.posY == 0)
                            {
                                Pedina occupier = destination.pedina;
                                destination.Controls.Remove(occupier);
                                occupier.Dispose();
                                new King(ColoriPedine.black, destination);
                            }
                            break;
                    }
                    turnoRossi = !turnoRossi;
                }

            }
        }


    }
}
