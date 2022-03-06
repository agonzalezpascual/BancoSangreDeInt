using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BancoSangre
{
    public class Compatibilidad
    {
        public List<String> Are = new List<string>();
        public List<String> Ado = new List<String>();
        public List<String> Bre = new List<String>();
        public List<String> Bdo = new List<String>();
        public List<String> ABre = new List<String>();
        public List<String> ABdo = new List<String>();
        public List<String> Ore = new List<String>();
        public List<String> Odo = new List<String>();
        // Elementos del tree de compatibilidad
        ArrayList dona = new ArrayList();
        ArrayList recibe = new ArrayList();

        public Compatibilidad() {
            iniciaListaCompatible();
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

        public ArrayList RellenaTree(string grupoR, string rhR)
        {


            if (grupoR.Equals("A"))
            {
                foreach (String s in Ado)
                {
                    if (rhR.Equals("-"))
                    {
                        dona.Add(s + "-");
                    }
                    dona.Add(s + "+");
                }


            }
            else if (grupoR.Equals("B"))
            {
                foreach (String s in Bdo)
                {
                    if (rhR.Equals("-"))
                    {
                        dona.Add(s + "-");
                    }
                    dona.Add(s + "+");
                }


            }
            else if (grupoR.Equals("AB"))
            {
                foreach (String s in ABdo)
                {
                    if (rhR.Equals("-"))
                    {
                        dona.Add(s + "-");
                    }
                    dona.Add(s + "+");
                }


            }
            else if (grupoR.Equals("0"))
            {
                foreach (String s in Odo)
                {
                    if (rhR.Equals("-"))
                    {
                        dona.Add(s + "-");
                    }
                    dona.Add(s + "+");
                }


            }
            return dona;

        }
        public ArrayList RellenaTreeRecibe(string grupoR, string rhR)
        {


            if (grupoR.Equals("A"))
            {
                foreach (String s in Are)
                {
                    if (rhR.Equals("+"))
                    {
                        recibe.Add(s + "+");
                    }
                    recibe.Add(s + "-");
                }
                foreach (String s in Ado)
                {
                    if (rhR.Equals("-"))
                    {
                        dona.Add(s + "-");
                    }
                    dona.Add(s + "+");
                }


            }
            else if (grupoR.Equals("B"))
            {
                foreach (String s in Bre)
                {
                    if (rhR.Equals("+"))
                    {
                        recibe.Add(s + "+");
                    }
                    recibe.Add(s + "-");
                }
                foreach (String s in Bdo)
                {
                    if (rhR.Equals("-"))
                    {
                        dona.Add(s + "-");
                    }
                    dona.Add(s + "+");
                }


            }
            else if (grupoR.Equals("AB"))
            {
                foreach (String s in ABre)
                {
                    if (rhR.Equals("+"))
                    {
                        recibe.Add(s + "+");
                    }
                    recibe.Add(s + "-");
                }
                foreach (String s in ABdo)
                {
                    if (rhR.Equals("-"))
                    {
                        dona.Add(s + "-");
                    }
                    dona.Add(s + "+");
                }


            }
            else if (grupoR.Equals("0"))
            {
                foreach (String s in Ore)
                {
                    if (rhR.Equals("+"))
                    {
                        recibe.Add(s + "+");
                    }
                    recibe.Add(s + "-");
                }
                foreach (String s in Odo)
                {
                    if (rhR.Equals("-"))
                    {
                        dona.Add(s + "-");
                    }
                    dona.Add(s + "+");
                }


            }
            return recibe;

        }

    }
}
