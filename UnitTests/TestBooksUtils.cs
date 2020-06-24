using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccess.Services;

namespace UnitTests
{
    [TestClass]
    public class TestBooksUtils
    {
        [TestMethod]
        public void TestBookStatistics()
        {
            string text = "Поражаясь красоте и многообразию окружающего мира, люди на протяжении веков гадали: как он появился?" +
                " Каким образом сформировались планеты, на одной из которых зародилась жизнь?" +
                " Почему земная жизнь основана на углероде и использует четыре типа звеньев в ДНК?" +
                " Где во Вселенной стоит искать другие формы жизни, и чем они могут отличаться от нас?" +
                " В этой книге собраны самые свежие ответы науки на эти вопросы." +
                " И хотя на переднем крае науки не всегда есть простые пути, автор честно постарался сделать все возможное," +
                " чтобы книга была понятна читателям, далеким от биологии." +
                " Он логично и четко формулирует свои идеи и с увлечением рассказывает о том," +
                " каким образом из космической пыли и метеоритов через горячие источники у подножия вулканов возникла живая клетка," +
                " чтобы заселить и преобразить всю планету.";
            Assert.AreEqual("800", TextStatisticsUtils.TextLength(text));
            Assert.AreEqual("123", TextStatisticsUtils.WordsCount(text));
            Assert.AreEqual("107", TextStatisticsUtils.UniqueWordsCount(text));
            Assert.AreEqual("5.4", TextStatisticsUtils.AverageWordLength(text));
            Assert.AreEqual("17.6", TextStatisticsUtils.AverageSentenceLength(text));
        }
    }
}
