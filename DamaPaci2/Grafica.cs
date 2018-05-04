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
        public Grafica() //costruttore classe grafica
        {
            InitializeComponent();
            CreaScacchiera();
            PopolaScacchiera();
        }
        public Image red = Image.FromFile(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + @"..\..\Desktop\Dama\Resources\red60p.png");
        public Image black = Image.FromFile(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + @"..\..\Desktop\Dama\Resources\black60p.png");
        public Image redKing = Image.FromFile(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + @"..\..\Desktop\Dama\Resources\red60p_king.png");
        public Image blackKing = Image.FromFile(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + @"..\..\Desktop\Dama\Resources\black60p_king.png");
        public enum Pedine { red, black };

        protected PanelRC[,] pannello = new PanelRC[8, 8];
        protected Pedina pedina = null;
        protected bool turnoRossi = true;
        protected int righe = 8;
        protected int colonne = 8;
        protected int pedineRosse = 12;
        protected int pedineNere = 12;
        protected void CreaScacchiera() //ok
        {
            for (int r = 0; r < righe; r++)
                for (int c = 0; c < colonne; c++)
                {
                    pannello[r, c] = new PanelRC
                    {
                        riga = c,
                        colonna = r
                    };
                    if ((r + c) % 2 == 0) pannello[r, c].BackColor = Color.DimGray;
                    else pannello[r, c].BackColor = Color.White;
                    back.Controls.Add(pannello[r, c]);
                }
            //RefreshPedineMancanti();
            ResizeScacchiera(null, null);
        }
        protected void GameOver()
        {
            if (pedineNere == 0 || pedineRosse == 0) Application.Exit();
        }
        protected void ResizeScacchiera(object sender, EventArgs e) //ok
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

        protected void PopolaScacchiera() //ok
        {
            for (int r = 0; r < righe; r++)
                for (int c = 0; c < colonne; c++)
                {
                    if ((r + c) % 2 == 0)
                    {
                        Pedina temp;
                        if (c < 3)
                        {
                            temp = new Pedina(Pedine.red, pannello[r, c]);
                            temp.Click += new EventHandler(PercorsiDisponibili);
                        }
                        else if (c > 4)
                        {
                            temp = new Pedina(Pedine.black, pannello[r, c]);
                            temp.Click += new EventHandler(PercorsiDisponibili);
                        }
                    }
                }
        }

        protected void PercorsiDisponibili(object sender, EventArgs e)
        {
            PanelRC[] percorsi = ((sender as Control).Parent as PanelRC).pedina.GeneraPercorsi(this);
            CancellaPercorsi(pedina);
            pedina = sender as Pedina;
            for (int i = 0; i < percorsi.Length; i++)
                if (percorsi[i] != null && percorsi[i].pedina == null) percorsi[i].BackColor = Color.Yellow;
        }

        protected void CancellaPercorsi(Pedina man) //ok
        {
            if (man == null) return;
            PanelRC[] percorsi = man.GeneraPercorsi(this);
            for (int i = 0; i < percorsi.Length; i++)
                if (percorsi[i] != null) percorsi[i].BackColor = Color.DimGray;
        }

        public class PanelRC : Panel  //classe PanelRC
        {
            public Pedina pedina = null;
            public int riga;
            public int colonna;
        }

        public class Pedina : PictureBox //classe Pedina
        {
            public Pedine color;
            public Pedina(Pedine colore, PanelRC cell) //costruttore Pedina
            {
                color = colore;
                if (colore == Pedine.red) Image = Image.FromFile(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + @"..\..\Desktop\Dama\Resources\red60p.png");
                else Image = Image.FromFile(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + @"..\..\Desktop\Dama\Resources\black60p.png");
                SizeMode = PictureBoxSizeMode.StretchImage;
                cell.Controls.Add(this);
                cell.pedina = this;
                Location = new Point(0, 0);
                Size = cell.Size;
                Anchor = (AnchorStyles)15;
            }

            virtual public PanelRC[] GeneraPercorsi(Grafica scacchiera)
            {
                PanelRC cell = Parent as PanelRC;
                PanelRC[,] cells = scacchiera.pannello;
                PanelRC[] routes = new PanelRC[2];
                int directionY;
                int directionX;
                int maxY;
                int maxX;
                if ((color == Pedine.red && !scacchiera.turnoRossi) || (color == Pedine.black && scacchiera.turnoRossi)) return null;
                if (color == Pedine.red)
                {
                    directionY = 1;
                    maxY = 7;
                }
                else
                {
                    directionY = -1;
                    maxY = 0;
                }
                routes[0] = cells[cell.riga + 1, cell.colonna + 1];
                return routes;
            }
        }

        public class King : Pedina
        {
            public King(Pedine colore, PanelRC cell) : base(colore, cell)  //costruttore King
            {
                if (colore == Pedine.red) Image = Image.FromFile(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + @"..\..\Desktop\Dama\Resources\red60p_king.png");
                else Image = Image.FromFile(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + @"..\..\Desktop\Dama\Resources\black60p_king.png");
                SizeMode = PictureBoxSizeMode.StretchImage;
                cell.Controls.Add(this);
                cell.pedina = this;
                Location = new Point(0, 0);
                Size = cell.Size;
                Anchor = (AnchorStyles)15;
            }

            override public PanelRC[] GeneraPercorsi(Grafica chessboard)
            {
                PanelRC cell = Parent as PanelRC;
                PanelRC[,] cells = chessboard.pannello;
                PanelRC[] routes = new PanelRC[2];
                int directionY = -1;
                int directionX = -1;
                int maxY = 0;
                int maxX = 0;
                bool found = false;
                PanelRC temp = cell;
                PanelRC prev = null;
                PanelRC next = null;
                int distance = 0;

                return routes;
            }
        }

    }
}
