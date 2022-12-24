using ShikimoriApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShikimoriApp.Exceptions;

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
            Assert.AreEqual(context.GetPersonalList(ShikimoriContext.ListStatus.Completed).Count, 95);
            Assert.AreEqual(context.GetPersonalList(ShikimoriContext.ListStatus.Dropped).Count, 10);
            Assert.AreEqual(context.GetPersonalList(ShikimoriContext.ListStatus.Planned).Count, 109);
            Assert.AreEqual(context.GetPersonalList(ShikimoriContext.ListStatus.Watching).Count, 1);
        }

        [TestMethod()]
        public void GetCalendarTest()
        {
            context.GetCalendar();
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

        [TestMethod()]
        public void GetAnimesProhibitedTest()
        {
            Assert.AreNotEqual(context.GetAnimes(1, "", false, new int[] { 27 }).Count, 0);
            Assert.AreEqual(context.GetAnimes(1, "", false, new int[] { 539, 12 }).Count, 0);
            Assert.AreEqual(context.GetAnimes(1, "", false, new int[] { 12 }).Count, 0);
            Assert.AreEqual(context.GetAnimes(1, "", false, new int[] { 539 }).Count, 0);
        }
    }
}