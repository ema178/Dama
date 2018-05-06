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
    public partial class Grafica : Form
    {
        public Grafica() //costruttore classe Grafica
        {
            InitializeComponent();
            CreaScacchiera();
            PopolaScacchiera();
        }
        public enum ColoriPedine { red, black }; //colori pedine
        protected PanelRC[,] pannello = new PanelRC[8, 8];
        protected Pedina pedina = null;
        public enum Turni { red, black }; //turni
        protected Turni turno = Turni.red; //iniziano i rossi
        protected int righe = 8;
        protected int colonne = 8;
        protected int pedineRosse = 12;
        protected int pedineNere = 12;
        protected bool devoMangiare = false;
        protected void CreaScacchiera() //Crea scacchiera con i PanelRC
        {
            for (int r = 0; r < righe; r++)
                for (int c = 0; c < colonne; c++)
                {
                    pannello[r, c] = new PanelRC
                    {
                        posY = c,
                        posX = r
                    };
                    if ((r + c) % 2 == 0) pannello[r, c].BackColor = Color.DimGray;
                    else pannello[r, c].BackColor = Color.White;
                    back.Controls.Add(pannello[r, c]);
                }
            Suggerimenti.Text = "Benvenuto! Iniziano i " + turno;
            RefreshPedineMancanti();
            ResizeScacchiera(null, null); //resize iniziale
        }
        protected void GameOver() //controlla se entrambi i giocatori hanno ancora pedine
        {
            if (pedineNere == 0 || pedineRosse == 0) Application.Exit();
        }
        protected void ResizeScacchiera(object sender, EventArgs e) //resize 
        {
            if (pannello[0, 0] == null) return;
            int offset;
            if (back.Width > back.Height) offset = (int)Math.Round((float)back.Height / 8);
            else offset = (int)Math.Round((float)back.Width / 8);
            for (int r = 0; r < righe; r++)
                for (int c = 0; c < colonne; c++)
                {
                    pannello[r, c].Location = new Point(r * offset, c * offset);
                    pannello[r, c].Width = offset;
                    pannello[r, c].Height = offset;
                }
        }
        protected void RefreshPedineMancanti() //refresh label pedineMancanti
        {
            Stato.Text = "Rosse: " + pedineRosse + "\nNere: " + pedineNere;
        }
        protected void PopolaScacchiera() //riempe la scacchiera con le pedine
        {
            for (int r = 0; r < righe; r++)
                for (int c = 0; c < colonne; c++)
                    if ((r + c) % 2 == 0)
                    {
                        Pedina temp;
                        if (c < 3)
                        {
                            temp = new Pedina(ColoriPedine.red, pannello[r, c]);
                            temp.Click += new EventHandler(PercorsiDisponibili);
                        }
                        if (c > 4)
                        {
                            temp = new Pedina(ColoriPedine.black, pannello[r, c]);
                            temp.Click += new EventHandler(PercorsiDisponibili);
                        }
                    }
        }

        protected void PercorsiDisponibili(object sender, EventArgs e) //stampa i percorsi disponibili, colorando le celle
        {
            ColoriPedine currColor = (ColoriPedine)turno;
            for (int y = 0; y < righe; y++)
                for (int x = 0; x < colonne; x++)
                {
                    CancellaPercorsi(pedina);
                    if ((y + x) % 2 == 0 && pannello[y, x].pedina != null)
                        if(pannello[y, x].pedina.color != currColor)
                        {
                            pedina = pannello[y, x].pedina;
                            ((sender as Control).Parent as PanelRC).pedina.GeneraPercorsi(this);
                        }
                }

            for (int y = 0; y < righe; y++)
                for (int x = 0; x < colonne; x++)
                    if ((y + x) % 2 == 0)
                    {
                        if(pannello[y, x].pedina != null)
                        {
                            if (pannello[y, x].pedina.color == currColor)
                            {
                                if (pannello[y, x].pedina.percorsiEat[0] != null) 
                                {
                                    devoMangiare = true;
                                    break;
                                }
                            }
                        }
                    }
            pedina = sender as Pedina;
            if ((pedina.color == ColoriPedine.red && turno == Turni.black) || (pedina.color == ColoriPedine.black && turno == Turni.red)) return;
            if (devoMangiare && pedina.percorsiEat[0] != null)
            {
                for (int i = 0; i < pedina.percorsiEat.Length; i++)
                    if (pedina.percorsiEat[i] != null && pedina.percorsiEat[i].pedina == null) pedina.percorsiEat[i].BackColor = Color.Green;
            }
            if(!devoMangiare)
                for (int i = 0; i < pedina.percorsiMove.Length; i++)
                if (pedina.percorsiMove[i] != null && pedina.percorsiMove[i].pedina == null) pedina.percorsiMove[i].BackColor = Color.Yellow;
        }

        protected void CancellaPercorsi(Pedina curr) //cancella le celle gialle
        {
            if (curr == null) return;
            curr.GeneraPercorsi(this);
            if ((pedina.color == ColoriPedine.red && turno == Turni.black) || (pedina.color == ColoriPedine.black && turno == Turni.red)) return;
            for (int i = 0; i < pedina.percorsiEat.Length; i++)
                if (pedina.percorsiEat[i] != null && pedina.percorsiEat[i].pedina == null)
                {
                    pedina.percorsiEat[i].BackColor = Color.DimGray;
                    pedina.percorsiEat[i].mangio = false;
                }
            for (int i = 0; i < pedina.percorsiMove.Length; i++)
                if (pedina.percorsiMove[i] != null && pedina.percorsiMove[i].pedina == null)
                {
                    pedina.percorsiMove[i].BackColor = Color.DimGray;
                    pedina.percorsiMove[i].mangio = false;
                }

        }

        public class PanelRC : Panel  //classe PanelRC
        {
            public Pedina pedina = null; //ogni pannello può contenere una pedina
            public int posY;
            public int posX;
            public bool mangio = false;
        }

        public class Pedina : PictureBox //classe Pedina
        {
            public ColoriPedine color;
            public bool isDamone = false;
            public PanelRC[] percorsiMove = new PanelRC[4];
            public PanelRC[] percorsiEat = new PanelRC[4];
            public Pedina(ColoriPedine colore, PanelRC cell) //costruttore classe Pedina
            {
                color = colore;
                if (colore == ColoriPedine.red) Image = Properties.Resources.red60p;
                else Image = Properties.Resources.black60p;
                SizeMode = PictureBoxSizeMode.StretchImage;
                cell.Controls.Add(this);
                cell.pedina = this;
                Location = new Point(0, 0);
                Size = cell.Size;
                Anchor = (AnchorStyles)15;
            }

            virtual public void GeneraPercorsi(Grafica scacchiera) //genera percorsi disponibili in base alla pedina selezionata
            {
                PanelRC corrente = Parent as PanelRC;
                PanelRC[,] pannelli = scacchiera.pannello;
                int dirY, posMove = 0, posEat = 0, bordiY;
                ColoriPedine coloreMangiabile;
                bool possoMangiare = false;
                if ((color == ColoriPedine.red && scacchiera.turno == Turni.black) || (color == ColoriPedine.black && scacchiera.turno == Turni.red)) return;
                if (color == ColoriPedine.red)
                {
                    dirY = 1;
                    bordiY = scacchiera.righe;
                    coloreMangiabile = ColoriPedine.black;
                }
                else
                {
                    dirY = -1;
                    bordiY = -1;
                    coloreMangiabile = ColoriPedine.red;
                }
                if (corrente.posX + 2 <= scacchiera.righe - 1 && corrente.posY + (2 * dirY) != bordiY)  //mangiabile destra
                {

                    if (pannelli[corrente.posX + 2, corrente.posY + (2 * dirY)].pedina == null && pannelli[corrente.posX + 1, corrente.posY + (1 * dirY)].pedina != null && pannelli[corrente.posX + 1, corrente.posY + (1 * dirY)].pedina.color == coloreMangiabile && pannelli[corrente.posX + 1, corrente.posY + (1 * dirY)].pedina.isDamone == false)
                    {
                        percorsiEat[posEat] = pannelli[corrente.posX + 2, corrente.posY + (2 * dirY)];
                        percorsiEat[posEat].mangio = true;
                        posEat++;
                        possoMangiare = true;
                    }
                }
                if (corrente.posX - 2 >= 0 && corrente.posY + (2 * dirY) != bordiY)  //mangiabile sinistra
                {
                    if (pannelli[corrente.posX - 2, corrente.posY + (2 * dirY)].pedina == null && pannelli[corrente.posX - 1, corrente.posY + (1 * dirY)].pedina != null && pannelli[corrente.posX - 1, corrente.posY + (1 * dirY)].pedina.color == coloreMangiabile && pannelli[corrente.posX - 1, corrente.posY + (1 * dirY)].pedina.isDamone == false)
                    {
                        percorsiEat[posEat] = pannelli[corrente.posX - 2, corrente.posY + (2 * dirY)];
                        percorsiEat[posEat].mangio = true;
                        posMove++;
                        possoMangiare = true;
                    }
                }

                if (corrente.posX + 1 <= scacchiera.righe - 1 && corrente.posY + (1 * dirY) != bordiY) //movibile destra
                {
                    if (!possoMangiare && pannelli[corrente.posX + 1, corrente.posY + (1 * dirY)].pedina == null)
                    {
                        percorsiMove[posMove] = pannelli[corrente.posX + 1, corrente.posY + (1 * dirY)];
                        posMove++;
                    }
                }
                if (corrente.posX - 1 >= 0 && corrente.posY + (1 * dirY) != bordiY)   //movibile sinistra
                    if (corrente.posX - 1 >= 0 && corrente.posY + (1 * dirY) >= 0)
                        if (pannelli[corrente.posX - 1, corrente.posY + (1 * dirY)].pedina == null)
                            if (!possoMangiare)
                            {
                                percorsiMove[posMove] = pannelli[corrente.posX - 1, corrente.posY + (1 * dirY)];
                                posMove++;
                            }
            }
        }

        public class Damone : Pedina
        {
            public Damone(ColoriPedine colore, PanelRC cell) : base(colore, cell)  //costruttore classe Damone
            {
                isDamone = true;
                if (colore == ColoriPedine.red) Image = Properties.Resources.red60p_king;
                else Image = Properties.Resources.black60p_king;
                SizeMode = PictureBoxSizeMode.StretchImage;
                cell.Controls.Add(this);
                cell.pedina = this;
                Location = new Point(0, 0);
                Size = cell.Size;
                Anchor = (AnchorStyles)15;
            }

            override public void GeneraPercorsi(Grafica scacchiera) //genera percorsi disponibili in base al damone selezionato
            {
                PanelRC corrente = Parent as PanelRC;
                PanelRC[,] pannelli = scacchiera.pannello;
                int dirY;
                int posEat = 0, posMove = 0;
                ColoriPedine coloreMangiabile;
                bool possoMangiare = false;
                if ((color == ColoriPedine.red && scacchiera.turno == Turni.black) || (color == ColoriPedine.black && scacchiera.turno == Turni.red)) return;
                if (color == ColoriPedine.red) coloreMangiabile = ColoriPedine.black;
                else coloreMangiabile = ColoriPedine.red;
                dirY = 1;
                for (int j = 0; j < 2; j++) //controlla prima sotto e poi sopra
                {
                    if (corrente.posX + 2 <= 7 && corrente.posY + (2 * dirY) >= 0 && corrente.posY + (2 * dirY) <= scacchiera.righe - 1)  //mangiabile destra
                    {

                        if (pannelli[corrente.posX + 2, corrente.posY + (2 * dirY)].pedina == null && pannelli[corrente.posX + 1, corrente.posY + (1 * dirY)].pedina != null && pannelli[corrente.posX + 1, corrente.posY + (1 * dirY)].pedina.color == coloreMangiabile)
                        {
                            percorsiEat[posEat] = pannelli[corrente.posX + 2, corrente.posY + (2 * dirY)];
                            percorsiEat[posEat].mangio = true;
                            posEat++;
                            possoMangiare = true;
                        }
                    }
                    if (corrente.posX - 2 >= 0 && corrente.posY + (2 * dirY) >= 0 && corrente.posY + (2 * dirY) <= scacchiera.righe - 1)  //mangiabile sinistra
                    {
                        if (pannelli[corrente.posX - 2, corrente.posY + (2 * dirY)].pedina == null && pannelli[corrente.posX - 1, corrente.posY + (1 * dirY)].pedina != null && pannelli[corrente.posX - 1, corrente.posY + (1 * dirY)].pedina.color == coloreMangiabile)  // eatable left
                        {
                            percorsiEat[posEat] = pannelli[corrente.posX - 2, corrente.posY + (2 * dirY)];
                            percorsiEat[posEat].mangio = true;
                            posEat++;
                            possoMangiare = true;
                        }
                    }

                    if (corrente.posX + 1 <= 7 && corrente.posY + (1 * dirY) >= 0 && corrente.posY + (1 * dirY) <= scacchiera.righe - 1) //movibile destra
                    {
                        if (!possoMangiare && pannelli[corrente.posX + 1, corrente.posY + (1 * dirY)].pedina == null)
                        {
                            percorsiMove[posMove] = pannelli[corrente.posX + 1, corrente.posY + (1 * dirY)];
                            posMove++;
                        }
                    }
                    if (corrente.posX - 1 >= 0 && corrente.posY + (1 * dirY) >= 0 && corrente.posY + (1 * dirY) <= scacchiera.righe - 1)   //movibile sinistra
                        if (corrente.posX - 1 >= 0 && corrente.posY + (1 * dirY) >= 0)
                            if (pannelli[corrente.posX - 1, corrente.posY + (1 * dirY)].pedina == null)
                                if (!possoMangiare)
                                {
                                    percorsiMove[posMove] = pannelli[corrente.posX - 1, corrente.posY + (1 * dirY)];
                                    posMove++;
                                }
                    dirY = -1; //cambio direzione
                }
            }
        }

        private void Stato_Click(object sender, EventArgs e)
        {

        }

        private void Suggerimenti_Click(object sender, EventArgs e)
        {

        }

        private void Istruzioni_Click(object sender, EventArgs e)
        {
            var f = new Regole();
            f.ShowDialog();
        }
    }
}