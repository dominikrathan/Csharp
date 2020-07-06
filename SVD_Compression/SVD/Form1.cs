using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.IO;
using System.Windows.Forms;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;


namespace SVD
{

    public partial class Form1 : Form
    {

        Komprimovany puvodni;                         // uchovava puvodni obrazek       
        Zkomprimovany zkomprimovany;                  // uchovava zkomprimovany obrazek
        Editovany editovany;                          // uchovava editovany obrazek, nastane-li stav editace
        static Verze[] Seznam_verzi = new Verze[200]; // uchovava seznam verzi v ramci jedne instance programu

        bool prvni_komprimace = true;                 // informace o tom, zda uz probehla nejaka komprese zrovna nahraneho obrazku
        bool probehlo_znovunacteni = false;           // informace o tom, zda uzivatel obnovil nejakou puvodni verzi
        bool editace_puvodni;                         // informace, zda uzivatel chce editovat puvodni/zkomprimovanou verzi obrazku    

        enum Stav { Zacatek, NahranyObr, Nacitani1, Nacitani2, Zkomprimovano, Editace }  // enum stavu 

        void NastavStav(Stav stav) {

            switch (stav)
            {
                case Stav.Zacatek:
                    l_SVD.Visible = true;
                    l_Zmena.Visible = false;
                    b_Nacti.Visible = true;
                    b_Zkomprimuj.Visible = false;
                    b_Konec.Visible = true;
                    b_Editace0.Visible = false;
                    b_Editace.Visible = false;
                    b_UlozitEd.Visible = false;
                    b_Ulozit.Visible = false;
                    b_Invertovat.Visible = false;
                    b_StupneSedi.Visible = false;
                    b_Navrat.Visible = false;
                    b_KomprimovatEd.Visible = false;
                    b_PredchoziVerze.Visible = false;
                    tB_jas.Visible = false;
                    trackBar1.Visible = false;
                    l_jas.Visible = false;
                    l_Kontrast.Visible = false;
                    pB_puvodni.Visible = false;
                    pb_komprese.Visible = false;
                    pB_nacitani.Visible = false;
                    pB_Editace.Visible = false;
                    l_KvalitaKomprese.Visible = false;
                    l_Popis.Visible = true;
                    pB_Editace.Visible = false;
                    lB_zpusobKomprese.Visible = false;
                    tB_uzivatelUroven.Visible = false;
                    b_novyObrazek.Visible = false;
                    l_ENTER.Visible = false;
                    l_Porovnani.Visible = false;
                    l_Zmena.Visible = false;
                    break;
                case Stav.NahranyObr:
                    l_SVD.Visible = true;
                    l_Zmena.Visible = false;
                    var l_SVDX = l_SVD.Location.X;
                    var l_SVDY = l_SVD.Location.Y;
                    l_SVDX = 26;
                    l_SVDY = 38;
                    b_Nacti.Visible = false;
                    b_Konec.Visible = true;
                    b_Editace0.Visible = true;
                    b_Editace.Visible = false;
                    b_UlozitEd.Visible = false;
                    b_Ulozit.Visible = false;
                    b_novyObrazek.Visible = true;
                    b_Invertovat.Visible = false;
                    b_StupneSedi.Visible = false;
                    b_PredchoziVerze.Visible = false;
                    b_Navrat.Visible = false;
                    b_KomprimovatEd.Visible = false;
                    tB_jas.Visible = false;
                    trackBar1.Visible = false;
                    l_jas.Visible = false;
                    l_Kontrast.Visible = false;
                    pB_puvodni.Visible = true;
                    pB_nacitani.Visible = false;
                    pB_Editace.Visible = false;
                    b_Zkomprimuj.Visible = true;
                    b_Zkomprimuj.Text = "Komprimovat";
                    pb_komprese.Visible = false;
                    l_KvalitaKomprese.Visible = true;
                    l_KvalitaKomprese.Text = "Obrázek je úspěšně nahrán! Pokračujte stiskem tlačítka KOMPRIMOVAT." +
                                             System.Environment.NewLine +
                                             "Popřípadě stiskněte EDITOVAT a před komprimací si obrázek upravte." +
                                             System.Environment.NewLine +
                                             "Základní úroveň komprese je nastavena na 20 %." +
                                             System.Environment.NewLine +
                                             "Následně budete mít možnost úroveň měnit.";
                    l_Popis.Visible = false;
                    lB_zpusobKomprese.Visible = false;
                    tB_uzivatelUroven.Visible = false;
                    l_ENTER.Visible = false;
                    l_Porovnani.Visible = false;
                    pB_puvodni.Image = puvodni.bitmapa;
                    l_Zmena.Visible = false;

                    break;
                case Stav.Nacitani1:
                    l_SVD.Visible = true;
                    l_Zmena.Visible = false;
                    b_Nacti.Visible = false;
                    b_Konec.Visible = true;
                    b_novyObrazek.Visible = true;
                    b_Editace0.Visible = true;
                    b_Editace.Visible = false;
                    b_UlozitEd.Visible = false;
                    b_Ulozit.Visible = false;
                    b_PredchoziVerze.Visible = false;
                    b_Invertovat.Visible = false;
                    b_StupneSedi.Visible = false;
                    b_Navrat.Visible = false;
                    b_KomprimovatEd.Visible = false;
                    tB_jas.Visible = false;
                    trackBar1.Visible = false;
                    pB_puvodni.Visible = true;
                    l_jas.Visible = false;
                    l_Kontrast.Visible = false;
                    pB_nacitani.Image = Properties.Resources.ajax_loader;
                    pB_nacitani.Visible = true;
                    pB_nacitani.Size = Properties.Resources.ajax_loader.Size;
                    b_Zkomprimuj.Visible = true;
                    pb_komprese.Visible = false;
                    pB_Editace.Visible = false;
                    l_KvalitaKomprese.Visible = true;
                    l_Popis.Visible = false;
                    lB_zpusobKomprese.Visible = false;
                    tB_uzivatelUroven.Visible = false;
                    l_ENTER.Visible = false;
                    l_Porovnani.Visible = false;
                    l_Zmena.Visible = false;
                    l_KvalitaKomprese.Visible = false;
                    break;
                case Stav.Zkomprimovano:
                    l_SVD.Visible = true;
                    l_Zmena.Visible = true;
                    l_SVDX = l_SVD.Location.X;
                    l_SVDY = l_SVD.Location.Y;
                    l_SVDX = 26;
                    l_SVDY = 38;
                    b_Nacti.Visible = false;
                    b_Konec.Visible = true;
                    b_novyObrazek.Visible = true;
                    b_Editace0.Visible = false;
                    b_Editace.Visible = true;
                    b_UlozitEd.Visible = false;
                    b_Ulozit.Visible = true;
                    b_Invertovat.Visible = false;
                    b_StupneSedi.Visible = false;
                    b_Navrat.Visible = false;
                    b_KomprimovatEd.Visible = false;
                    b_PredchoziVerze.Visible = true;
                    tB_jas.Visible = false;
                    trackBar1.Visible = false;
                    l_jas.Visible = false;
                    l_Kontrast.Visible = false;
                    l_Popis.Visible = false;
                    b_Zkomprimuj.Visible = true;
                    pB_puvodni.Visible = true;
                    pb_komprese.Visible = true;
                    pB_nacitani.Visible = false;
                    pB_Editace.Visible = false;
                    pB_puvodni.Image = puvodni.bitmapa;
                    pb_komprese.Image = zkomprimovany.bitmapa;
                    l_KvalitaKomprese.Visible = true;
                    l_KvalitaKomprese.Text = "Počet singulárních čísel původního obrázku je " +
                                              zkomprimovany.puvodni_pocet_SC.ToString() + "." +
                                              System.Environment.NewLine +
                                              "Počet singulárních čísel ve zkomprimované verzi je " +
                                              zkomprimovany.pouzity_pocet_SC.ToString() + "." +
                                              System.Environment.NewLine +
                                              "Změňte počet singulárních čísel užitých v kompresi (<" +
                                              zkomprimovany.puvodni_pocet_SC + "):";
                    lB_zpusobKomprese.Visible = true;
                    tB_uzivatelUroven.Visible = true;
                    b_Zkomprimuj.Text = "Změnit kompresi";
                    l_ENTER.Visible = false;
                    lB_zpusobKomprese.Items[0] = "Počet singulárních čísel [0 < int < " + zkomprimovany.puvodni_pocet_SC.ToString() + "]";
                    lB_zpusobKomprese.Items[1] = "Úroveň komprese [0 < % < 100]";
                    if (prvni_komprimace)
                    {
                        for (int index = 0; index < lB_zpusobKomprese.Items.Count; ++index)
                        {
                            lB_zpusobKomprese.SetItemChecked(index, false);
                        }
                        lB_zpusobKomprese.ClearSelected();
                        tB_uzivatelUroven.Text = "";
                    }
                    l_Porovnani.Visible = true;
                    l_Zmena.Visible = true;
                    l_Porovnani.Text = "Velikost původního obrázku je: " + puvodni.Velikost().ToString() + " KB" +
                                        System.Environment.NewLine +
                                        "Velikost zkomprimovaného obrázku je: " + zkomprimovany.Velikost().ToString() + " KB";


                    if (!probehlo_znovunacteni)
                    {
                        Verze verze = new Verze(puvodni, zkomprimovany.pouzity_pocet_SC, zkomprimovany.puvodni_pocet_SC);
                        verze.Uloz();
                        if (Verze.pocet_verzi > 1)
                             contextMenuStrip1.Items.Add(Seznam_verzi[Verze.pocet_verzi-2].identifikator);
                    }

                    probehlo_znovunacteni = false;

                    break;
                case Stav.Nacitani2: //TODO: behaci kolecko
                    l_SVD.Visible = true;
                    l_Zmena.Visible = true;
                    b_Nacti.Visible = false;
                    b_Konec.Visible = true;
                    b_novyObrazek.Visible = true;
                    b_Editace0.Visible = false;
                    b_Editace.Visible = true;
                    b_UlozitEd.Visible = false;
                    b_Ulozit.Visible = true;
                    b_Invertovat.Visible = false;
                    b_PredchoziVerze.Visible = true;
                    b_StupneSedi.Visible = false;
                    b_Navrat.Visible = false;
                    b_KomprimovatEd.Visible = false;
                    tB_jas.Visible = false;
                    trackBar1.Visible = false;
                    l_jas.Visible = false;
                    l_Kontrast.Visible = false;
                    pB_puvodni.Visible = true;
                    pB_nacitani.Visible = true;
                    pB_Editace.Visible = false;
                    b_Zkomprimuj.Visible = true;
                    pb_komprese.Visible = true;
                    l_KvalitaKomprese.Visible = true;
                    l_Popis.Visible = false;
                    lB_zpusobKomprese.Visible = true;
                    tB_uzivatelUroven.Visible = true;
                    l_ENTER.Visible = true;
                    l_Porovnani.Visible = true;
                    l_Zmena.Visible = true;
                    break;
                case Stav.Editace:
                    l_SVD.Visible = true;
                    b_Nacti.Visible = false;
                    b_Zkomprimuj.Visible = false;
                    b_Konec.Visible = true;
                    b_Editace0.Visible = false;
                    b_Editace.Visible = false;
                    b_UlozitEd.Visible = true;
                    b_Ulozit.Visible = false;
                    b_Invertovat.Visible = true;
                    b_StupneSedi.Visible = true;
                    b_Navrat.Visible = true;
                    b_PredchoziVerze.Visible = true;
                    b_KomprimovatEd.Visible = true;
                    tB_jas.Visible = true;
                    trackBar1.Visible = true;
                    l_jas.Visible = true;
                    l_Kontrast.Visible = true;
                    pB_puvodni.Visible = false;
                    pb_komprese.Visible = false;
                    pB_Editace.Visible = true;
                    l_KvalitaKomprese.Visible = false;
                    l_Popis.Visible = false;
                    pB_Editace.Visible = true;
                    lB_zpusobKomprese.Visible = false;
                    tB_uzivatelUroven.Visible = false;
                    l_ENTER.Visible = false;
                    l_Porovnani.Visible = false;
                    pictureBox1.Visible = false;
                    pB_Editace.Image = editovany.bitmapa;
                    l_Zmena.Visible = false;
                    tB_jas.Value = 0;
                    trackBar1.Value = 25;
                    break;

  


            }
        }                // metoda nastavujici jednotlive stavy 

        public Form1()
        {           
            InitializeComponent();
            this.Location = new Point(0, 0);           
            var path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);    // vytvoreni slozky "Verze" na plose, kam bude program automaticky ukladat jednotlive upravy obrazku
            var folder = Path.Combine(path, "Verze");
            Directory.CreateDirectory(folder);
            contextMenuStrip1.ItemClicked += new ToolStripItemClickedEventHandler(contextMenuStrip1_ItemClicked);  
            NastavStav(Stav.Zacatek);      // zaciname stavem zacatek                                             
             
        }

        public class Verze                     // trida verze, instancemi jsou jednotlive upravy obrazku
        {

            public Komprimovany original;      // puvodni obrazek
            public string source;              // zdroj puvodniho obrazku
            public string nazev;               // nazev, pod kterym budu ukladat /format YYYY-dd-mm_hhmmss.txt
            public string identifikator;       // interni nazev, Verze_x, kde x znaci, o kolikatou verzi jde
            public int puvodni_pocet_SC;       // puvodni pocet SC v originalnim obrazku
            public int pouzity_pocet_SC;       // pouzity pocet singularnich cisel v dane komprimaci
            public static int pocet_verzi = 0; // pocet jiz vytvorenych verzi

            public Verze(Komprimovany obrazek, int SC, int pSC)  // konstruktor verze, jako parametry bere puvodni obrazek, pocet puvodnich a pouzitych singularnich cisel
            {

                this.original = obrazek;
                this.source = obrazek.source;
                this.puvodni_pocet_SC = pSC;
                this.pouzity_pocet_SC = SC;
                this.nazev = DateTime.Now.ToString("yyyy-dd-MM_hhmmss") + ".txt";
                this.identifikator = "Verze " + pocet_verzi.ToString();
                Seznam_verzi[pocet_verzi] = this;
                pocet_verzi++;
            }

            public void Uloz() // metoda na ulozeni dane verze do slozky "Verze" na plose, na prvnim radku zdroj puvodniho obrazku, na druhem pocet uzitych singularnich cisel
            {
             
                string filePath = Path.Combine(
                                    Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                                    "Verze",
                                    this.nazev);               
                string[] radky = { this.source, this.pouzity_pocet_SC.ToString() };
                System.IO.File.WriteAllLines(filePath, radky);


            }

            public Zkomprimovany Nacti(string filePath) // argumentem je cesta k danemu .txt souboru, vraci prislusny zkomprimovany obrazek dle poctu singularnich cisel
            {

                string[] radky = System.IO.File.ReadAllLines(filePath);
                this.nazev = filePath;
                this.original = new Komprimovany(radky[0]);
                this.pouzity_pocet_SC = Convert.ToInt32(radky[1]);

                Zkomprimovany temp = new Zkomprimovany(this.original, 1);
                temp = temp.Zmena_komprimace(this.pouzity_pocet_SC);

                return temp;

            }
        }

        public struct Matice                   // pomocna trida na uchovani matic
        {
            public double[,] prvky;            // prvky matice
            public int m;                      // pocet radku
            public int n;                      // pocet sloupcu

            public static Matice SoucinMatic(Matice M1, Matice M2)      // vraci soucin matic M1, M2; pokud neni soucin definovan vraci vyjimku
            {

                Matice Soucin = new Matice();
                Soucin.m = M1.m;
                Soucin.n = M2.n;
                Soucin.prvky = new double[Soucin.m, Soucin.n];
                if (M1.n == M2.m)
                {
                    for (int i = 0; i < M1.m; i++)
                    {
                        for (int j = 0; j < M2.n; j++)
                        {
                            double s = 0;
                            for (int k = 0; k < M1.n; k++)
                            {
                                s += M1.prvky[i, k] * M2.prvky[k, j];
                            }

                            Soucin.prvky[i, j] = s;
                        }
                    }

                    return Soucin;
                }
                else throw new Exception("nasobeni matic neni definovano");

            }

            public static Matice Vytvor(Matrix<double> X, int m, int n) // vraci moji Matici vytvorenou z instance "Matrix" pouzivanych v MathNet
            {
                Matice nova = new Matice();
                nova.m = m;
                nova.n = n;
                nova.prvky = new double[nova.m, nova.n];

                for (int i = 0; i < m; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        double prvek = X.Storage[i, j];
                        nova.prvky[i, j] = prvek;
                    }
                }

                return nova;
            }
        }

        public class SVD                       // trida na uchovani SVD rozkladu
        {
            public Matice U;                   // matice levych singularnich vektoru
            public Matice SIGMA;               // (obecne obdelnikova) diagonalni matice se SC puvodni matice na diagonale
            public Matice V;                   // matice pravych singularnich vektoru

            public SVD(double[,] matice)       // konsturktor jako parametr bere dvourozmerne pole prestavujici matici, pomoci balicku MathNet vytvori matice U, D, V
            {

                var M = DenseMatrix.OfArray(matice);
                var svd = M.Svd(true);

                this.U = Matice.Vytvor(svd.U, M.RowCount, M.RowCount);
                this.SIGMA = Matice.Vytvor(svd.W, M.RowCount, M.ColumnCount);
                this.V = Matice.Vytvor(svd.VT, M.ColumnCount, M.ColumnCount);

            }

            public void ZmenPocetSinglarnichCisel(int d) // jako parametr bere pozadovany pocet singularnich cisel a na jeho zaklade prislusne upravi matice U, D, V
            {

                // z UDV (m*m)(m*n)(n*n) udela U´D´V´ (m*d)(d*d)(d*n)
                this.U.n = d;
                this.SIGMA.m = d;
                this.SIGMA.n = d;
                this.V.m = d;

            }
        }

        public class Vektor                    // pomocna trida na ukladani trislozkoveho vektoru
        {
            public byte[] prvky;               // prvky vektoru

            public Vektor(byte x1, byte x2, byte x3)  // konstruktor, argumentem jsou 3 slozky vektoru
            {
                prvky = new byte[3];
                this.prvky[0] = x1;
                this.prvky[1] = x2;
                this.prvky[2] = x3;
            }

            public static double Rozdil_vektoru(Vektor V1, Vektor V2) // vraci eukleidovskou normu rozdilu dvou trislozkovych vektoru
            {
                Vektor rozdil = new Vektor(
                    (byte)(Math.Max(V1.prvky[0], V2.prvky[0]) - Math.Min(V1.prvky[0], V2.prvky[0])),
                    (byte)(Math.Max(V1.prvky[1], V2.prvky[1]) - Math.Min(V1.prvky[1], V2.prvky[1])),
                    (byte)(Math.Max(V1.prvky[2], V2.prvky[2]) - Math.Min(V1.prvky[2], V2.prvky[2]))
                    );

                double s = Math.Sqrt(rozdil.prvky[0] * rozdil.prvky[0] + rozdil.prvky[1] * rozdil.prvky[1] + rozdil.prvky[2] * rozdil.prvky[2]);

                return s;
            }

        }

        public class RGB            // trida na ukladani RGB matic obrazku
        {
            public int x;           // sirka obrazku
            public int y;           // vyska obrazku
            public double[,] R;     // matice R
            public double[,] G;     // matice G
            public double[,] B;     // matice B

            public RGB(double[,] R, double[,] G, double[,] B, int x, int y) // konstruktor
            {
                this.x = x;
                this.y = y;
                this.R = R;
                this.G = G;
                this.B = B;
            }

            public static RGB VytvorRGB(Bitmap bmp)  // z bitmapy vytvori instanci RGB
            {

                RGB vystup = new RGB(
                    new double[bmp.Width, bmp.Height],
                    new double[bmp.Width, bmp.Height],
                    new double[bmp.Width, bmp.Height],
                    bmp.Width,
                    bmp.Height
                    );


                for (int j = 0; j < vystup.y; j++)
                {
                    for (int i = 0; i < vystup.x; i++)
                    {
                        Color c = bmp.GetPixel(i, j);
                        vystup.R[i, j] = c.R;
                        vystup.G[i, j] = c.G;
                        vystup.B[i, j] = c.B;
                    }
                }

                return vystup;


            }

            public static Bitmap VytvorObrazek(RGB rgb) // z RGB vytvori prislusny obrazek v podobe bitmapy
            {

                Bitmap vystup = new Bitmap(rgb.x, rgb.y);

                for (int j = 0; j < rgb.y; j++)
                {
                    for (int i = 0; i < rgb.x; i++)
                    {
                        if (i != 0 && j != 0)
                        {
                            Vektor V1 = new Vektor((byte)rgb.R[i, j], (byte)rgb.G[i, j], (byte)rgb.B[i, j]);
                            Vektor V2 = new Vektor((byte)rgb.R[i - 1, j - 1], (byte)rgb.G[i - 1, j - 1], (byte)rgb.B[i - 1, j - 1]);

                            if (Vektor.Rozdil_vektoru(V1, V2) > 200)
                            {
                                rgb.R[i, j] = rgb.R[i - 1, j];
                                rgb.G[i, j] = rgb.G[i - 1, j];
                                rgb.B[i, j] = rgb.B[i - 1, j];
                            }
                        }

                        if (rgb.G[i, j] == 260 && rgb.R[i, j] == 0 && rgb.B[i, j] == 0) rgb.G[i, j] = rgb.G[i - 2, j - 2];
                        if (rgb.B[i, j] == 260 && rgb.G[i, j] == 0 && rgb.R[i, j] == 0) rgb.B[i, j] = rgb.B[i - 2, j - 2];

                        Color c = Color.FromArgb((byte)rgb.R[i, j], (byte)rgb.G[i, j], (byte)rgb.B[i, j]);
                        vystup.SetPixel(i, j, c);

                    }
                }

                return vystup;



            }
        }

        public abstract class Obrazek  // abstraktni trida obrazek
        {
            public int x;              // sirka obr.
            public int y;              // vyska obr.
            public string source;      // zdroj obrazku v pocitaci   
            public Bitmap bitmapa;     // bitmapa obrazku
            public RGB rgb;            // instance RGB tj. jednotlive barevne slozky obrazku

            public abstract double Velikost();  // abstraktni trida velikosti obrazku

        }

        public class Komprimovany : Obrazek  // komprimovany tj. puvodni obrazek
        {

            public Komprimovany(string source) // konstruktor komprimovaneho obrazku, argumentem je zdroj obr.
            {
                {

                    Image img = Image.FromFile(source);
                    this.source = source;
                    int obrX = img.Size.Width;
                    int obrY = img.Size.Height;

                    if (obrX >= 900)          // pokud je obrazek velky, prislusne ho zmensi (kvuli narocnosti operaci)
                    {
                        while (obrX >= 900)
                        {
                            obrX = (int)(obrX * 0.9);
                            obrY = (int)(obrY * 0.9);
                        }
                    }

                    if (obrY >= 900)
                    {
                        while (obrY >= 900)
                        {
                            obrX = (int)(obrX * 0.9);
                            obrY = (int)(obrY * 0.9);
                        }
                    }

                    bitmapa = new Bitmap(img, obrX, obrY);
                    this.x = obrX;
                    this.y = obrY;
                    this.rgb = RGB.VytvorRGB(bitmapa);

                }
            }

            public override double Velikost()  
            {
                return 3 * x * y / 1000;
            }
        }

        public class Zkomprimovany : Obrazek   // zkomprimovany obrazek
        {
            public int puvodni_pocet_SC;       // puvodni pocet singularnich cisel obrazku
            public int pouzity_pocet_SC;       // pouzity pocet SC ve zkomprimovane verzi
            public SVD[] svd;                  // pole (3-rozmerne) pro ulozeni SVD rozkladu matic RGB

            public Zkomprimovany(Komprimovany puvodni, double uroven_komprese) // konstuktor, parametr je puvodni komprimovany obrazek a uroven komprese (pokud je mensi nez 1, uvazujeme jako percentualni zmenu, pokud je vetsi tak jako pocet singularnich cisel, ktera chceme pouzit
            {

                this.svd = new SVD[3];

                svd[0] = new SVD(puvodni.rgb.R); //R
                svd[1] = new SVD(puvodni.rgb.G); //G
                svd[2] = new SVD(puvodni.rgb.B); //B

                this.puvodni_pocet_SC = svd[0].SIGMA.n;

                if (uroven_komprese < 1)
                {
                        int[] hodnoty = {        
                            svd[0].SIGMA.n,
                            svd[1].SIGMA.n,
                            svd[2].SIGMA.n,
                            (int)(uroven_komprese * puvodni_pocet_SC) };
                        this.pouzity_pocet_SC = hodnoty.Min();
                }
                else
                {
                    int[] hodnoty = {
                        svd[0].SIGMA.n,
                        svd[1].SIGMA.n,
                        svd[2].SIGMA.n,
                        (int)(uroven_komprese) };
                    this.pouzity_pocet_SC = hodnoty.Min();
                }
                

                svd[0].ZmenPocetSinglarnichCisel(pouzity_pocet_SC);
                svd[1].ZmenPocetSinglarnichCisel(pouzity_pocet_SC);
                svd[2].ZmenPocetSinglarnichCisel(pouzity_pocet_SC);

                this.rgb = new RGB(
                    Matice.SoucinMatic(Matice.SoucinMatic(svd[0].U, svd[0].SIGMA), svd[0].V).prvky,
                    Matice.SoucinMatic(Matice.SoucinMatic(svd[1].U, svd[1].SIGMA), svd[1].V).prvky,
                    Matice.SoucinMatic(Matice.SoucinMatic(svd[2].U, svd[2].SIGMA), svd[2].V).prvky,
                    puvodni.x,
                    puvodni.y);

                this.x = puvodni.x;
                this.y = puvodni.y;
                this.bitmapa = RGB.VytvorObrazek(this.rgb);

            }

            public Zkomprimovany Zmena_komprimace(int nova_SC) // prislusny jiz zkomprimovany obrazek zmenime dle zvoleneho poctu singularnich cisel
            {

                this.svd[0].ZmenPocetSinglarnichCisel(nova_SC);
                this.svd[1].ZmenPocetSinglarnichCisel(nova_SC);
                this.svd[2].ZmenPocetSinglarnichCisel(nova_SC);
                this.pouzity_pocet_SC = nova_SC;
                this.rgb = new RGB(
                    Matice.SoucinMatic(Matice.SoucinMatic(svd[0].U, svd[0].SIGMA), svd[0].V).prvky,
                    Matice.SoucinMatic(Matice.SoucinMatic(svd[1].U, svd[1].SIGMA), svd[1].V).prvky,
                    Matice.SoucinMatic(Matice.SoucinMatic(svd[2].U, svd[2].SIGMA), svd[2].V).prvky,
                    this.x,
                    this.y);
                this.bitmapa = RGB.VytvorObrazek(this.rgb);

                return this;

            }

            public override double Velikost()
            {
                return 3 * (svd[0].U.m * svd[0].U.n + svd[0].SIGMA.m * svd[0].SIGMA.n + svd[0].V.m * svd[0].V.n) / 1000;
            }
        }

        public class Editovany : Obrazek  // editovany obrazek
        {
            Obrazek original;          // puvodni obrazek, ktery editujeme
            public float kontrast;     // kontrast upraveneho obrazku
            public float jas;          // jas upraveneho obr.
            public bool stupne_sedi;   // je ve stupnich sedi?
            public bool invertovany;   // je invertovany?

            public Editovany(Obrazek original)  // kosturktor
            {
                this.original = original;
                this.x = original.x;
                this.y = original.y;
                this.bitmapa = original.bitmapa;
                this.rgb = original.rgb;
                this.jas = 0.001f;
                this.kontrast = 1;
                this.stupne_sedi = false;
                this.invertovany = false;
            }
         
            public override double Velikost()   // vzhledem k dedeni nutno naimplementovat, nikdy vsak nepouzito
            {
                return 0;
            }
   
        }

        private void b_Nacti_Click(object sender, EventArgs e) // nacteni noveho obrazku pomoci open file dialogu
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = ".bmp, .jpg, .gif, .png|*.BMP;*.JPG;*.GIF;*.PNG";
            if (opf.ShowDialog() == DialogResult.OK)
            {

                puvodni = new Komprimovany(opf.FileName);
                pB_puvodni.Image = puvodni.bitmapa;        
                NastavStav(Stav.NahranyObr);

            }
        }

        private void b_Zkomprimuj_Click(object sender, EventArgs e) // komprimace obrazku
        {

            if (prvni_komprimace)  // jestlize komprimujeme poprve
            {
                NastavStav(Stav.Nacitani1);

                BackgroundWorker bgW = new BackgroundWorker();  // pro zachovani responsivity GUI

                bgW.WorkerReportsProgress = true;

                bgW.DoWork += new DoWorkEventHandler(delegate (object o, DoWorkEventArgs args)
                {

                    zkomprimovany = new Zkomprimovany(puvodni, 0.2);  // zakladni uroven komprese je nastavena na 20%

                });

                bgW.RunWorkerCompleted += new RunWorkerCompletedEventHandler(
                    delegate (object o, RunWorkerCompletedEventArgs args)
                    {
                        pb_komprese.Image = zkomprimovany.bitmapa;
                        NastavStav(Stav.Zkomprimovano);
                        prvni_komprimace = false;
                    });

                bgW.RunWorkerAsync();

            }
            else   // jestlize komprimujeme jiz jednou zkomprimovany obrazekl
            {
                int nova_SC;

                if ((tB_uzivatelUroven.Text != "") && (lB_zpusobKomprese.CheckedItems.Count > 0)) // jestlize uzivatel vyplnil vse co potrebujeme ke kompresi
                {
                    int tb = Convert.ToInt32(tB_uzivatelUroven.Text.ToString());

                    if (lB_zpusobKomprese.GetSelected(0)) // zvolen pocet singularnich cisel
                    {
                        nova_SC = tb;

                        if ((tb > zkomprimovany.puvodni_pocet_SC) || (tb == 0))  // pokud cislo neni pripustne
                        {
                            MessageBox.Show("Je nutné zadat celočíselnou hodnotu 0 < ... < " + zkomprimovany.puvodni_pocet_SC.ToString());
                            return;
                        }
                    }
                    else  // zvolena percentualni uroven komprese
                    {
                        nova_SC = (int)((double)tb / 100 * zkomprimovany.puvodni_pocet_SC);

                        if ((tb == 0) || (tb > 100))  // pokud cislo neni pripustne
                        {
                            MessageBox.Show("Je nutné zadat percentuální hodnotu 0 < ... < 100");
                            return;
                        }
                    }

                    NastavStav(Stav.Nacitani2);

                    BackgroundWorker bgW = new BackgroundWorker();

                    bgW.DoWork += new DoWorkEventHandler(delegate (object o, DoWorkEventArgs args)
                    {
                        zkomprimovany = zkomprimovany.Zmena_komprimace(nova_SC);
                    });

                    bgW.RunWorkerCompleted += new RunWorkerCompletedEventHandler(
                        delegate (object o, RunWorkerCompletedEventArgs args)
                        {
                            pb_komprese.Image = zkomprimovany.bitmapa;
                            NastavStav(Stav.Zkomprimovano);
                            l_ENTER.Visible = true;
                        });

                    bgW.RunWorkerAsync();

                }
                else
                {
                    MessageBox.Show("Je nutné zadat parametry komprese");
                }
            }



        }

        private void b_Konec_Click(object sender, EventArgs e)  // konec programu
        {
            this.Close();
        }

        private void lB_zpusobKomprese_ItemCheck(object sender, ItemCheckEventArgs e) // je mozne zvolit pouze jeden zpusob komprese, pri kliku na druhy z nich se prvni automaticky odcheckne
        {


            if (e.NewValue == CheckState.Checked && lB_zpusobKomprese.CheckedItems.Count > 0)
            {
                lB_zpusobKomprese.ItemCheck -= lB_zpusobKomprese_ItemCheck;
                lB_zpusobKomprese.SetItemChecked(lB_zpusobKomprese.CheckedIndices[0], false);
                lB_zpusobKomprese.ItemCheck += lB_zpusobKomprese_ItemCheck;

            }

        }

        private void b_novyObrazek_Click(object sender, EventArgs e)  // vybereme uplne novy obrazek 
        {

            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = ".bmp, .jpg, .gif, .png|*.BMP;*.JPG;*.GIF;*.PNG";

            if (opf.ShowDialog() == DialogResult.OK)
            {

                puvodni = new Komprimovany(opf.FileName);
                pB_puvodni.Image = puvodni.bitmapa;
                prvni_komprimace = true;
                NastavStav(Stav.NahranyObr);

            }

        }

        private void tB_uzivatelUroven_KeyPress(object sender, KeyPressEventArgs e) // do textboxu urovne komprese je mozne psat pouze cisla
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void tB_uzivatelUroven_KeyDown(object sender, KeyEventArgs e) // pri stisknu ENTER v textboxu se automaticky zkomprimuje
        {
            l_ENTER.Visible = true;
            if (e.KeyCode == Keys.Enter)
            {
                b_Zkomprimuj_Click(sender, e);
            }

        }

        public static bool MessageSucceded { get; set; } // pomocny pro showdialog

        public static string MessageContent { private get; set; } // pomocny pro showdialog

        private void b_Editace_Click_1(object sender, EventArgs e) // zepta se, jestli chceme editovat puvodni nebo jiz zkomprimovany obrazek
        {
            using (Form2 form2 = new Form2())
            {
              
                if (MessageSucceded = form2.ShowDialog(this) == DialogResult.OK)
                {
                    if (MessageContent == "Původní")
                    {
                        editace_puvodni = true;
                        editovany = new Editovany(puvodni);
                        NastavStav(Stav.Editace);
                    }
                    else if (MessageContent == "Zkomprimovanou")
                    {
                        editace_puvodni = false;
                        editovany = new Editovany(zkomprimovany);
                        NastavStav(Stav.Editace);
                        
                    }
                }
            }


        }

        private void b_Editace0_Click(object sender, EventArgs e)  // tlacitko na editaci jeste pred prvni kompresi
        {
            editovany = new Editovany(puvodni);
            NastavStav(Stav.Editace);
        }

        private void b_Ulozit_Click(object sender, EventArgs e)  // ulozeni editovaneho obrazku
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = sfd.Filter = ".bmp, .jpg, .gif, .png|*.BMP;*.JPG;*.GIF;*.PNG";
            ImageFormat format = ImageFormat.Jpeg;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string s = Path.GetExtension(sfd.FileName);
                switch (s)
                {
                    case ".png":
                        format = ImageFormat.Png;
                        break;
                    case ".bmp":
                        format = ImageFormat.Bmp;
                        break;
                    case ".gif":
                        format = ImageFormat.Gif;
                        break;
                }

                pB_Editace.Image.Save(sfd.FileName, format);

            }
        }

        public static Bitmap UpravJasKontrast(Editovany editovany, int hodnota, string co) // vraci bitmapu s upravenym jasem/kontrastem/obojim podle hodnoty "co"
        {
            Bitmap upraveny = new Bitmap(editovany.x, editovany.y);
            ColorMatrix cm;

            if (co == "jas")
            {
                float novy_jas = (float)(hodnota) / 255.0f;
                float[][] X ={
                  new float[] { editovany.kontrast, 0, 0, 0, 0 },
                  new float[] { 0, editovany.kontrast, 0, 0, 0 },
                  new float[] { 0, 0, editovany.kontrast, 0, 0 },
                  new float[] { 0, 0, 0, 1, 0 },
                  new float[] { novy_jas, novy_jas, novy_jas, 1, 1 }};
                editovany.jas = novy_jas;          
                  cm = new ColorMatrix(X);
            }
            else if (co == "kontrast")
            {
                float novy_kontrast = (float)(hodnota) * 0.04f;
                float[][] X ={
                  new float[] { novy_kontrast, 0, 0, 0, 0 },
                  new float[] { 0, novy_kontrast, 0, 0, 0 },
                  new float[] { 0, 0, novy_kontrast, 0, 0 },
                  new float[] { 0, 0, 0, 1, 0 },
                  new float[] { editovany.jas, editovany.jas, editovany.jas, 0, 1 }};
                editovany.kontrast = novy_kontrast;
                  cm = new ColorMatrix(X);

            }
            else
            {
                float[][] X ={
                  new float[] { editovany.kontrast, 0, 0, 0, 0 },
                  new float[] { 0, editovany.kontrast, 0, 0, 0 },
                  new float[] { 0, 0, editovany.kontrast, 0, 0 },
                  new float[] { 0, 0, 0, 1, 0 },
                  new float[] { editovany.jas, editovany.jas, editovany.jas, 0, 1 }};
                 cm = new ColorMatrix(X);
            }


            using (Graphics g = Graphics.FromImage(upraveny))
            {
                ImageAttributes ia = new ImageAttributes();
                ia.ClearColorMatrix();
                ia.SetColorMatrix(cm, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
                g.DrawImage(editovany.bitmapa, new Rectangle(0, 0, upraveny.Width, upraveny.Height)
                    , 0, 0, editovany.x, editovany.y,
                    GraphicsUnit.Pixel, ia);
               
            }

            if (editovany.stupne_sedi)
            {
                for (int i = 0; i < upraveny.Width; i++)
                {
                    for (int j = 0; j < upraveny.Height; j++)
                    {
                        Color c = upraveny.GetPixel(i, j);
                        int seda = (int)(c.R * 0.3f + c.G * 0.59f + c.B * 0.11f);
                        Color nova = Color.FromArgb(seda, seda, seda);
                        upraveny.SetPixel(i, j, nova);
                    }
                }
            }

            if (editovany.invertovany)
            {
                for (int i = 0; i < upraveny.Width; i++)
                {
                    for (int j = 0; j < upraveny.Height; j++)
                    {
                        Color c = upraveny.GetPixel(i, j);
                        Color nova = Color.FromArgb(255 - c.R, 255 - c.G, 255 - c.B);
                        upraveny.SetPixel(i, j, nova);
                    }
                }
            }

            return upraveny;
        }

        public static Bitmap StupneSedi(Editovany editovany)  // vraci bitmapu ve stupnich sedi
        {

            Bitmap upraveny = new Bitmap(editovany.x, editovany.y);
            upraveny = UpravJasKontrast(editovany, 0, "");

            for (int i = 0; i < editovany.x; i++)
            {
                for (int j = 0; j < editovany.y; j++)
                {
                    Color c = upraveny.GetPixel(i, j);
                    int seda = (int)(c.R * 0.3f + c.G * 0.59f + c.B * 0.11f);
                    Color nova = Color.FromArgb(seda, seda, seda);
                    upraveny.SetPixel(i, j, nova);
                }
            }

            editovany.stupne_sedi = true;

            return upraveny;
        }

        public static Bitmap Invertovat(Editovany editovany)  // vraci invertovanou bitmapu
        {
            Bitmap upraveny = new Bitmap(editovany.x, editovany.y);
            upraveny = UpravJasKontrast(editovany, 0, "");

            for (int i = 0; i < editovany.x; i++)
            {
                for (int j = 0; j < editovany.y; j++)
                {
                    Color c = upraveny.GetPixel(i, j);                
                    Color nova = Color.FromArgb(255-c.R, 255-c.G, 255-c.B);
                    upraveny.SetPixel(i, j, nova);
                }
            }

            editovany.invertovany = true;
            return upraveny;
        }

        private void tB_jas_Scroll(object sender, EventArgs e) // zobrazuje upraveny jas dle hondoty na trackbaru
        {

            pB_Editace.Image = UpravJasKontrast(editovany, tB_jas.Value, "jas");
  
        }

        private void trackBar1_Scroll(object sender, EventArgs e) // zobrazuje upraveny kontrast dle hondoty na trackbaru
        {

            pB_Editace.Image = UpravJasKontrast(editovany, trackBar1.Value, "kontrast");

        }

        private void b_StupneSedi_Click(object sender, EventArgs e) // po kliknuti zobrazi ve stupnich sedi
        {

            pB_Editace.Image = StupneSedi(editovany);

        }

        private void b_Invertovat_Click(object sender, EventArgs e) // po kliknuti zobrazi invertovanou
        {

            pB_Editace.Image = Invertovat(editovany);

        }

        private void b_Navrat_Click(object sender, EventArgs e)  // navrat k puvodni verzi obrazku v ramci editace
        {
            editovany = new Editovany(puvodni);
            tB_jas.Value = 0;
            trackBar1.Value = 25;
            pB_Editace.Image = editovany.bitmapa;
        }

        private void b_KomprimovatEd_Click(object sender, EventArgs e) // komprimace editovaneho obrazku
        {
            prvni_komprimace = true;
            puvodni.bitmapa = (Bitmap)pB_Editace.Image;
            puvodni.rgb = RGB.VytvorRGB(puvodni.bitmapa);
            NastavStav(Stav.NahranyObr);
            b_Zkomprimuj_Click(sender, e);
        }

        private void b_Ulozit_Click_1(object sender, EventArgs e)  // ulozeni komprimovaneho obrazku
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = sfd.Filter = ".bmp, .jpg, .gif, .png|*.BMP;*.JPG;*.GIF;*.PNG";
            ImageFormat format = ImageFormat.Jpeg;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string s = Path.GetExtension(sfd.FileName);
                switch (s)
                {
                    case ".png":
                        format = ImageFormat.Png;
                        break;
                    case ".bmp":
                        format = ImageFormat.Bmp;
                        break;
                    case ".gif":
                        format = ImageFormat.Gif;
                        break;
                }

                pb_komprese.Image.Save(sfd.FileName, format);

            }
        }

        private void b_PredchoziVerze_Click(object sender, EventArgs e) // zobrazi menu s vyctem prechozich verzi, ke kterym se muzeme navracet
        {
            contextMenuStrip1.Show(b_PredchoziVerze, new Point(0, b_PredchoziVerze.Height));
        }

        private void contextMenuStrip1_Click(object sender, EventArgs e)
        {

        }

        void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e) // nacteni jedne z puvodnich verzi
        {

            ToolStripItem item = e.ClickedItem;

            NastavStav(Stav.Nacitani2);
            pB_puvodni.Visible = false;
            pb_komprese.Visible = false;

            BackgroundWorker bgW = new BackgroundWorker();

            bgW.WorkerReportsProgress = true;

            bgW.DoWork += new DoWorkEventHandler(delegate (object o, DoWorkEventArgs args)
            {

                Verze vybrana = Seznam_verzi[(int)(Char.GetNumericValue(item.Text[item.Text.Length - 1]))];
                puvodni = new Komprimovany(vybrana.source);
                zkomprimovany = new Zkomprimovany(puvodni, (double)vybrana.pouzity_pocet_SC);

            });

            bgW.RunWorkerCompleted += new RunWorkerCompletedEventHandler(
                delegate (object o, RunWorkerCompletedEventArgs args)
                {
                    probehlo_znovunacteni = true;
                    NastavStav(Stav.Zkomprimovano);
                });

            bgW.RunWorkerAsync();

        }

        private void b_NacistVerzi_Click(object sender, EventArgs e) // nacteni jedne z puvodnicgh verzi uchovanou v PC ve slozce "Verze" ve formatu .txt
        {
 
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = ".txt|*.txt";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(opf.FileName))
                {

                    using (StreamReader sr = new StreamReader(opf.FileName))
                    {

                        string source = sr.ReadLine();
                        string pocet = sr.ReadLine();
                      
                        NastavStav(Stav.Nacitani1);
                        pB_puvodni.Visible = false;

                        BackgroundWorker bgW = new BackgroundWorker();

                        bgW.WorkerReportsProgress = true;

                        bgW.DoWork += new DoWorkEventHandler(delegate (object o, DoWorkEventArgs args)
                        {

                            puvodni = new Komprimovany(source);
                            zkomprimovany = new Zkomprimovany(puvodni, Convert.ToDouble(pocet));

                        });

                        bgW.RunWorkerCompleted += new RunWorkerCompletedEventHandler(
                            delegate (object o, RunWorkerCompletedEventArgs args)
                            {
                                NastavStav(Stav.Zkomprimovano);
                            });

                        bgW.RunWorkerAsync();                     

                    }
                }


            }
        }

        private void Form1_Resize_1(object sender, EventArgs e)
        {
            pB_puvodni.Size = new Size(pictureBox1.Size.Width / 2 - 15, pictureBox1.Height - 10);
            pB_puvodni.Location = new Point(pictureBox1.Location.X + 10, pictureBox1.Location.Y + 5);

            pb_komprese.Size = new Size(pictureBox1.Size.Width / 2 - 15, pictureBox1.Height - 10);
            pb_komprese.Location = new Point(pB_puvodni.Location.X + pB_puvodni.Size.Width + 10, pictureBox1.Location.Y + 5);

            pB_Editace.Location = new Point(pB_Editace.Location.X, b_NacistVerzi.Location.Y + b_NacistVerzi.Size.Height + 10);
        }
    }
}

