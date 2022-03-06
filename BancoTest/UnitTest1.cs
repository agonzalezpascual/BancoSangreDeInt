using BancoSangre;
using Microsoft.Data.SqlClient;
using System.Collections;
using System.Data;
using Xunit;

namespace BancoTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            CRUD c = new CRUD();
            int v = c.AbreConexion();
            Assert.Equal((decimal)ConnectionState.Open,v);
        }
        [Fact]
        public void Test2()
        {
            ArrayList dona = new ArrayList();
            dona.Add("A+");
            dona.Add("AB+");
            Compatibilidad c = new Compatibilidad();
            Assert.Equal(dona, c.RellenaTree("A","+"));
        }
        [Fact]
        public void Test3()
        {
            ArrayList recibe = new ArrayList();
            recibe.Add("0+");
            recibe.Add("0-");
            Compatibilidad c = new Compatibilidad();
            Assert.Equal(recibe, c.RellenaTreeRecibe("0", "+"));
        }


    }
}