using System;
using App.Data.DataAcces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Data.DataAccessTest
{
    [TestClass]
    public class ArtistDATest    // TDD  Test Driven Development
    {
        [TestMethod]
        public void Count()
        {
            var da = new ArtistDA();
            var cantidad = da.GetCount();
            Assert.IsTrue(cantidad >= 0);
        }

        [TestMethod]
        public void GetArtist()
        {
            var da = new ArtistDA();
            var listado = da.GetArtist();
            Assert.IsTrue(listado.Count > 0);
        }
        [TestMethod]
        public void GetArtistWithSP()
        {
            var da = new ArtistDA();
            var listado = da.GetArtist("Aero%");
            Assert.IsTrue(listado.Count > 0);
        }

        
    }
}
