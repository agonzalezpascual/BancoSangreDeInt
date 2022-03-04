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
using MahApps.Metro.Controls;
using ControlzEx.Theming;
using MahApps.Metro.Controls.Dialogs;

namespace BancoSangre
{
    /// <summary>
    /// Lógica de interacción para VentanaInterfaz.xaml
    /// </summary>
    public partial class VentanaInterfaz : MetroWindow
    {
        //PRUEBA UNITARIA A LA CONEXION Y AL COMPATIBILIDAD
        CRUD c = new CRUD();
        Donante d;
        bool estado = true;
        
        public VentanaInterfaz()
        {
            InitializeComponent();
        }
        public void limpiaCampos()
        {
            txtApe.Text = "";
            txtDir.Text = "";
            txtDNI.Text = "";
            txtEma.Text = "";
            txtTel.Text = "";
            txtNom.Text = "";
            comboGrup.SelectedIndex = -1;
            comboRh.SelectedIndex = -1;

        }
        public void cambiaEstado(bool e)
        {
            estado = e;

        }

        public void pueblaCampos(string DNI, string nom, string ape, string dir, string fec, string tel, string ema, string indexGrup, string indexRh) {
            txtApe.Text = ape;
            txtDir.Text = dir;
            txtDNI.Text = DNI;
            txtEma.Text = ema;
            txtFec.Text = fec;
            txtTel.Text = tel;
            txtNom.Text = nom;
            comboGrup.Text = indexGrup;
            comboRh.Text = indexRh;


        }

        private void btnIns_Click(object sender, RoutedEventArgs e)
        {
            string grupo = comboGrup.Text;
            string rh = comboRh.Text;
            if (estado)
            {
                c.insertar("Donante",txtNom.Text, txtApe.Text, txtDNI.Text, txtDir.Text, txtTel.Text, txtFec.Text, txtEma.Text, grupo, rh);
            }
            else c.actualizar("Donante",txtNom.Text, txtApe.Text, txtDNI.Text, txtDir.Text, txtTel.Text, txtFec.Text, txtEma.Text, grupo, rh);
            this.Hide();
            limpiaCampos();
        }

        private void btnCan_Click(object sender, RoutedEventArgs e)
        {

            this.Hide();
            limpiaCampos();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
            
        }
    }
}
