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
using System.Windows.Shapes;

namespace BancoSangre
{
    /// <summary>
    /// Lógica de interacción para VentanaDonacion.xaml
    /// </summary>
    public partial class VentanaDonacion : Window
    {
        CRUD c = new CRUD();
        Donacion d;
        bool estado = true;
        public VentanaDonacion()
        {
            InitializeComponent();
        }
        public void limpiaCampos()
        {

            txtDNI.Text = "";
            txtSan.Text = "";
            txtCen.Text = "";
            txtCan.Text = "";
            txtFec.Text = "";

        }
        public void pueblaCampos(string dni,string san, string cen, string can, string fec)
        {

            txtDNI.Text = dni;
            txtSan.Text = san;
            txtCen.Text = cen;
            txtCan.Text = can;
            txtFec.Text = fec;

        }
        public void cambiaEstado(bool e)
        {
            estado = e;

        }

        private void btnInsDona_Click(object sender, RoutedEventArgs e)
        {
                c.insertarDonac("Donacion", txtDNI.Text, txtSan.Text, txtCen.Text, txtFec.Text, txtCan.Text);
            this.Hide();
            limpiaCampos();
        }

        private void btnCanDona_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            limpiaCampos();
        }
    }
}
