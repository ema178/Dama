﻿using System;
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
            for (var r = 0; r < righe; r++)
                for (var c = 0; c < colonne; c++)
                    pannello[r, c].Click += new EventHandler(MoveTo);
        }

        protected void MoveTo(object sender, EventArgs e)
        {
            if (pedina == null)
                return;
            if ((pedina.color == ColoriPedine.red && turno == Turni.black) || (pedina.color == ColoriPedine.black && turno == Turni.red)) return;
            PanelRC destinazione = sender as PanelRC;
            PanelRC corrente = pedina.Parent as PanelRC;
            PanelRC[] percorsi = pedina.GeneraPercorsi(this);
            PanelRC temp = corrente;

            int dirY;
            int dirX;
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
                            System.Threading.Thread.Sleep(1000);
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
                    corrente.pedina = null;
                    pedina = null;

                    switch (destinazione.pedina.color)
                    {
                        case ColoriPedine.red:
                            if (destinazione.posY == righe - 1)
                            {
                                Pedina curr = destinazione.pedina;
                                destinazione.Controls.Remove(curr);
                                curr.Dispose();
                                new Damone(ColoriPedine.red, destinazione);
                            }
                            break;

                        case ColoriPedine.black:
                            if (destinazione.posY == 0)
                            {
                                Pedina curr = destinazione.pedina;
                                destinazione.Controls.Remove(curr);
                                curr.Dispose();
                                new Damone(ColoriPedine.black, destinazione);
                            }
                            break;
                    }
                    if (turno == Turni.red) turno = Turni.black;
                    else turno = Turni.red;
                }

            }
        }


    }
}