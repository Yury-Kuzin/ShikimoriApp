using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShikimoriApp;
using ShikimoriApp.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShikimoriApp.Tests
{
    [TestClass()]
    public class ShikimoriContextTests
    {
        ShikimoriContext context = new ShikimoriContext();
        [TestMethod()]
        public void GetAnimesTest()
        {
            Assert.AreEqual(context.GetAnimes(1, "Орех").Count, 4);
        }

        [TestMethod()]
        public void GetAnimeTest()
        {
            Assert.AreEqual(context.GetAnime(199).Russian, "Унесённые призраками");
        }

        [TestMethod()]
        public void GetPersonalListTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetCalendarTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetGenresTest()
        {
            string genres = String.Join("", context.GetGenres().Select(x => x.Russian).ToArray());
            Assert.AreEqual(genres, "ДрамаИгрыПсихологическоеПриключенияМузыкаГурманЭкшенКомедияДемоныПолицияКосмосЭттиФэнтезиХентайИсторическийУжасыМагияМехаПародияСамураиРомантикаШколаЭротикаСёненВампирыЯойЮриГаремПовседневностьСёдзё-айДзёсейСверхъестественноеТриллерФантастикаСёдзёСупер силаВоенноеДетективДетскоеМашиныБоевые искусстваБезумиеСпортРаботаСэйнэнСёнен-ай");
        }

        [TestMethod()]
        [ExpectedException(typeof(AnimeIDNotFoundException))]
        public void GetAnimeNotFoundTest()
        {
            context.GetAnime(2122121212);
        }
    }
}