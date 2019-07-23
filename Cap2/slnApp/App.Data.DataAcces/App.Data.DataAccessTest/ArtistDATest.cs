using System;
using App.Data.DataAcces;
using App.Entities_Base;
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

        [TestMethod]
        public void InsertArtistWithSP()
        {
            var artist = new Artist();
            artist.Name = "Artista prueba";

            var da = new ArtistDA();
            var codigoGenerado = da.InsertArtist(artist);
            Assert.IsTrue(codigoGenerado > 0);
        }
        [TestMethod]
        public void InsertArtistParamOut()
        {
            var artist = new Artist();
            artist.Name = "Artista test";

            var da = new ArtistDA();
            var codigoGenerado = da.InsertArtistParamOut(artist);
            Assert.IsTrue(codigoGenerado > 0);
        }

        [TestMethod]
        public void UpdateArtist()
        {
            var artist = new Artist();
            artist.Name = "Artista prueba nuevo";
            

            var da = new ArtistDA();
            var codigoGenerado = da.InsertArtist(artist);
            // actualizado
            artist.Name = "Artista nuevo actualizado";
            artist.ArtistId = codigoGenerado;
            var updated = da.UpdateArtist(artist);
            Assert.IsTrue(updated);

            var artistaUpdated = da.GetArtistById(codigoGenerado);
            Assert.IsTrue(artistaUpdated.Name == "Artista nuevo actualizado");
        }

        [TestMethod]
        public void DeleteArtist()
        {
            var id = 256;
            var da = new ArtistDA();
            var codigoGenerado = da.DeleteArtist(id);
            Assert.IsTrue(codigoGenerado);
        }


    }
}
