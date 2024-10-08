﻿using System;
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
using MahApps.Metro.Controls;
using ControlzEx.Theming;
using MahApps.Metro.Controls.Dialogs;
using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.Defaults;
using LiveCharts.Definitions.Charts;
using LiveCharts.Definitions.Series;
using LiveCharts.Dtos;
using LiveCharts.Helpers;
using LiveCharts.Defaults;


namespace BancoSangre
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public List<Donante> listDon { get; set; }
        public List<Donante> listDonaAux { get; set; }
        public List<Donacion> listDonac { get; set; }
        public List<Donacion> listDonacAux { get; set; }
        public string PlaceholderText { get; set; }


        Donante d;
        Donacion donacion;
        CRUD c = new CRUD();

        // Listas para comprobar la compatibilidad de donaciones
        public List<String> Are = new List<string>();
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
        VentanaDonacion VentanaDonacion = new VentanaDonacion();


      
        public MainWindow()
        {
            InitializeComponent();
            pueblaTablaDonantes();
            pueblaTablaDonaciones();
            iniciaListaCompatible();
            iniciaTreeCompa();



        }
        
        public void pueblaTablaDonantes()
        {
            
            headerDonantestext.Content = c.cantidadDonantes();

            using (bancosangreContext _context = new bancosangreContext())
            {
                listDon = _context.Donantes.ToList();
                
                tablaDona.ItemsSource = listDon;

            }
        }

        public void pueblaTablaDonaciones()
        {
            headerDonacionestext.Content = c.cantidadDonaciones()+"";
            using (bancosangreContext _context = new bancosangreContext())
            {
                listDonac = _context.Donacions.ToList();

                tablaDonac.ItemsSource = listDonac;

            }
        }

        public void iniciaListaCompatible()
        {

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


        public void RellenaTree(string grupoR, string rhR) {
            
            
            if (grupoR.Equals("A"))
            {
                foreach (String s in Are)
                {
                    if (rhR.Equals("+"))
                    {
                        recibe.Items.Add(s + "+");
                    }
                    recibe.Items.Add(s + "-");
                }
                foreach (String s in Ado)
                {
                    if (rhR.Equals("-"))
                    {
                        dona.Items.Add(s + "-");
                    }
                    dona.Items.Add(s + "+");
                }


            }
            else if (grupoR.Equals("B"))
            {
                foreach (String s in Bre)
                {
                    if (rhR.Equals("+"))
                    {
                        recibe.Items.Add(s + "+");
                    }
                    recibe.Items.Add(s + "-");
                }
                foreach (String s in Bdo)
                {
                    if (rhR.Equals("-"))
                    {
                        dona.Items.Add(s + "-");
                    }
                    dona.Items.Add(s + "+");
                }


            }
            else if (grupoR.Equals("AB"))
            {
                foreach (String s in ABre)
                {
                    if (rhR.Equals("+"))
                    {
                        recibe.Items.Add(s + "+");
                    }
                    recibe.Items.Add(s + "-");
                }
                foreach (String s in ABdo)
                {
                    if (rhR.Equals("-"))
                    {
                        dona.Items.Add(s + "-");
                    }
                    dona.Items.Add(s + "+");
                }


            }
            else if (grupoR.Equals("0"))
            {
                foreach (String s in Ore)
                {
                    if (rhR.Equals("+"))
                    {
                        recibe.Items.Add(s + "+");
                    }
                    recibe.Items.Add(s + "-");
                }
                foreach (String s in Odo)
                {
                    if (rhR.Equals("-"))
                    {
                        dona.Items.Add(s + "-");
                    }
                    dona.Items.Add(s + "+");
                }


            }
           
        }

        private void botCompa_Click(object sender, RoutedEventArgs e)
        {
            recibe.Items.Clear();
            dona.Items.Clear();


            String grup = comboGrup.Text;
            String rh = comboRh.Text;
            //RellenaTree(grup,rh);
            Compatibilidad c = new Compatibilidad();
            foreach(string s in c.RellenaTree(grup, rh))
            {
                dona.Items.Add(s);

            }
            foreach (string r in c.RellenaTreeRecibe(grup, rh))
            {
                recibe.Items.Add(r);
            }



            compatibilidad.IsExpanded = true;
            dona.IsExpanded = true;
            recibe.IsExpanded = true;
        }

        private void botAnadir_Click(object sender, RoutedEventArgs e)
        {
            bWin.Owner = this;
            bWin.cambiaEstado(true);
            bWin.Show();
            //rectangulo.Visibility = Visibility.Visible;
            pueblaTablaDonantes();
        }

        private void botMod_Click(object sender, RoutedEventArgs e)
        {
            bWin.Owner = this;

            bWin.pueblaCampos(d.Dni, d.Nombre, d.Apellido, d.Direccion, d.Nacimiento, d.Telefono, d.Email, d.Grupo, d.Rh);
            bWin.cambiaEstado(false);
            bWin.Show();

            //rectangulo.Visibility = Visibility.Hidden;
        }
        private void tablaDona_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            d = (Donante)tablaDona.SelectedItem;
        }

        private void botEli_Click(object sender, RoutedEventArgs e)
        {
            c.borrar(d.Dni);
        }

        private void txtFil_TextInput(object sender, TextCompositionEventArgs e)
        {

        }

        private void txtFil_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void ventana_Activated(object sender, EventArgs e)
        {
            dibujaRosco();

            pueblaTablaDonantes();
            pueblaTablaDonaciones();
            dibujarcolumnas();
        }
    


        private void txtFil_KeyUp(object sender, KeyEventArgs e)
        {
            using (bancosangreContext _context = new bancosangreContext())
            {
                listDon = _context.Donantes.ToList();
                listDonaAux = _context.Donantes.ToList();

                foreach (Donante d in listDon)
                {
                    if (d.Dni.Contains(txtFil.Text)) { }
                    else
                    {
                        listDonaAux.Remove(d);
                    }
                }

                tablaDona.ItemsSource = listDonaAux;

            }
        }

        private void txtFilDonacion_KeyUp(object sender, KeyEventArgs e)
        {
            using (bancosangreContext _context = new bancosangreContext())
            {
                listDonac = _context.Donacions.ToList();
                listDonacAux = _context.Donacions.ToList();

                foreach (Donacion d in listDonac)
                {
                    if (d.Dni.Contains(txtFilDonacion.Text)) { }
                    else
                    {
                        listDonacAux.Remove(d);
                    }
                }

                tablaDonac.ItemsSource = listDonacAux;

            }
        }

        public SeriesCollection SeriesCollection
        {
            get; set;

        }
        public SeriesCollection SeriesCollectionsos { get; set; }

        public string[] Labelso { get; set; }
        public Func<double, string> Formattero { get; set; }
        public void dibujarcolumnas() {

            CRUD two = new CRUD();
            double apos = two.RellenarPalitos("a" , "+");
            double aneg = two.RellenarPalitos("a" , "-");
            double bpos = two.RellenarPalitos("b", "+");
            double bneg = two.RellenarPalitos("b", "-");
            double abpos = two.RellenarPalitos("ab", "+");
            double abneg = two.RellenarPalitos("ab", "-");
            double zeropos = two.RellenarPalitos("0", "+");
            double zeroneg = two.RellenarPalitos("0", "-");


            SeriesCollectionsos = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "+",
                    Values = new ChartValues<double> { apos, bpos, abpos, zeropos },
                    Fill = Brushes.Crimson

                }
            };

            //adding series will update and animate the chart automatically
            SeriesCollectionsos.Add(new ColumnSeries
            {
                Title = "-",
                Values = new ChartValues<double> { aneg, bneg, abneg, zeroneg },
                Fill = Brushes.Firebrick

            });

            //also adding values updates and animates the chart automatically
           

            Labelso = new[] { "A", "B", "AB", "O" };
            Formattero = value => value.ToString("N");

            DataContext = this;

           
        }
    
        public void dibujaRosco() {
            CRUD one = new CRUD();
            double a = one.RellenarRosco("a");
            double b = one.RellenarRosco("b");
            double ab = one.RellenarRosco("ab");
            double zero = one.RellenarRosco("0");



            try
            {

                SeriesCollection = new SeriesCollection {

                new PieSeries{
                     Title ="A",


                     Values = new ChartValues<ObservableValue>{ new ObservableValue(a) },
                     DataLabels = true,
                     Fill = Brushes.Tan


                },
                new PieSeries{
                     Title ="B",

                     Values = new ChartValues<ObservableValue>{ new ObservableValue(b)},
                      DataLabels = true,
                      Fill = Brushes.Firebrick

                },
                new PieSeries{
                     Title ="AB",

                     Values = new ChartValues<ObservableValue>{ new ObservableValue(ab)},

                      DataLabels = true,
                      Fill = Brushes.Crimson
                },
                new PieSeries{
                     Title ="0",

                     Values = new ChartValues<ObservableValue>{ new ObservableValue(zero)},

                      DataLabels = true,
                      Fill = Brushes.BurlyWood
                },
            };
                DataContext = this;
            }
            catch (Exception exp)
            {

                MessageBox.Show("hay un error");

            }
        }

        
        private void PieChart_Loaded(object sender, RoutedEventArgs e)
        {
            dibujaRosco();


        }

        private void positivosnegativos_Loaded(object sender, DataTransferEventArgs e)
        {
            SeriesCollection s = new SeriesCollection
                {
                new ColumnSeries
                {
                    Title = "2015",
                    Values = new ChartValues<double> { 10, 50, 39, 50 }
                }
            };
            //adding series will update and animate the chart automatically
           s.Add(new ColumnSeries
            {
                Title = "2016",
                Values = new ChartValues<double> { 11, 56, 42 }
            });
            s[1].Values.Add(48d);

            Labels = new[] { "Maria", "Susan", "Charles", "Frida" };
            Formatter = value => value.ToString("N");

            DataContext = this;
        }
        public SeriesCollection s{ get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }

        private void botAnadirSan_Click(object sender, RoutedEventArgs e)
        {
            VentanaDonacion.Owner = this;
            VentanaDonacion.cambiaEstado(true);
            VentanaDonacion.Show();
            //rectangulo.Visibility = Visibility.Visible;
            pueblaTablaDonaciones();
        }

        private void botEliDonac_Click(object sender, RoutedEventArgs e)
        {
            c.borrarDonac(donacion.Dni);
        }

        private void tablaDonac_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            donacion = (Donacion)tablaDonac.SelectedItem;
        }

        private void CartesianChart_Loaded(object sender, RoutedEventArgs e)
        {
            dibujarcolumnas();
        }
    }
    }
