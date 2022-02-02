using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BancoSangre
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Donante> listDon { get; set; }
        public List<Donacion> listDonac { get; set; }

        // Listas para comprobar la compatibilidad de donaciones
        public List<String> Are = new List<String>();
        public List<String> Ado = new List<String>();
        public List<String> Bre = new List<String>();
        public List<String> Bdo = new List<String>();
        public List<String> ABre = new List<String>();
        public List<String> ABdo = new List<String>();
        public List<String> Ore = new List<String>();
        public List<String> Odo = new List<String>();
        // Elementos del tree de compatibilidad
        TreeViewItem compatibilidad = new TreeViewItem();
        TreeViewItem dona = new TreeViewItem();
        TreeViewItem recibe = new TreeViewItem();
        VentanaInterfaz bWin = new VentanaInterfaz();
        public MainWindow()
        {
            InitializeComponent();
            pueblaTablaDonantes();
            pueblaTablaDonaciones();
            iniciaListaCompatible();
            iniciaTreeCompa();
            
            
        }

        public void pueblaTablaDonantes() {
            using (bancosangreContext _context = new bancosangreContext())
            {
                listDon = _context.Donantes.ToList();

                tablaDona.ItemsSource = listDon;

            }
        }

        public void pueblaTablaDonaciones()
        {
            using (bancosangreContext _context = new bancosangreContext())
            {
                listDonac = _context.Donacions.ToList();

                tablaDonac.ItemsSource = listDonac;

            }
        }

        public void iniciaListaCompatible() {

            Are.Add("A");
            Are.Add("0");

            Ado.Add("A");
            Ado.Add("AB");

            Bre.Add("B");
            Bre.Add("0");

            Bdo.Add("B");
            Bdo.Add("AB");

            ABre.Add("AB");
            ABre.Add("A");
            ABre.Add("B");
            ABre.Add("0");

            ABdo.Add("AB");

            Ore.Add("0");


            Odo.Add("AB");
            Odo.Add("A");
            Odo.Add("B");
            Odo.Add("0");

        }
        public void iniciaTreeCompa()
        {
            
            compatibilidad.Header = "Compatibilidad";
            dona.Header = "Dona";
            recibe.Header = "Recibe";
            treeCom.Items.Add(compatibilidad);
            compatibilidad.Items.Add(dona);
            compatibilidad.Items.Add(recibe);


        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void botCompa_Click(object sender, RoutedEventArgs e)
        {
            String grup = comboGrup.Text;
            String rh = comboRh.Text;
            recibe.Items.Clear();
            dona.Items.Clear();
            if(grup.Equals("A"))
            {
                foreach (String s in Are)
                {
                    if (rh.Equals("+"))
                    {
                        recibe.Items.Add(s+"+");
                    }
                    recibe.Items.Add(s+"-");
                }
                foreach (String s in Ado)
                {
                    if (rh.Equals("-"))
                    {
                        dona.Items.Add(s + "-");
                    }
                    dona.Items.Add(s + "+");
                }


            }else if (grup.Equals("B"))
            {
                foreach (String s in Bre)
                {
                    if (rh.Equals("+"))
                    {
                        recibe.Items.Add(s + "+");
                    }
                    recibe.Items.Add(s + "-");
                }
                foreach (String s in Bdo)
                {
                    if (rh.Equals("-"))
                    {
                        dona.Items.Add(s + "-");
                    }
                    dona.Items.Add(s + "+");
                }


            } else if (grup.Equals("AB"))
            {
                foreach (String s in ABre)
                {
                    if (rh.Equals("+"))
                    {
                        recibe.Items.Add(s + "+");
                    }
                    recibe.Items.Add(s + "-");
                }
                foreach (String s in ABdo)
                {
                    if (rh.Equals("-"))
                    {
                        dona.Items.Add(s + "-");
                    }
                    dona.Items.Add(s + "+");
                }


            }
            else if (grup.Equals("0"))
            {
                foreach (String s in Ore)
                {
                    if (rh.Equals("+"))
                    {
                        recibe.Items.Add(s + "+");
                    }
                    recibe.Items.Add(s + "-");
                }
                foreach (String s in Odo)
                {
                    if (rh.Equals("-"))
                    {
                        dona.Items.Add(s + "-");
                    }
                    dona.Items.Add(s + "+");
                }


            }
            compatibilidad.IsExpanded = true;
            dona.IsExpanded = true;
            recibe.IsExpanded = true;

        }

        private void botAnadir_Click(object sender, RoutedEventArgs e)
        {
            bWin.Owner = this;
            bWin.Show();
            
        }

        private void botMod_Click(object sender, RoutedEventArgs e)
        {
            bWin.Hide();
        }
    }
}
