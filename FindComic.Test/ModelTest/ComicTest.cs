using FindComic.Model;

namespace FindComic.Test.ModelTest
{
    public class ComicTest
    {
        [Fact]
        public void ConvertFromFileTest1()
        {
            var c = Comic.ConvertFromFileName("[Wri ter] Title 第01巻.rar");
            Assert.Equal("Wri ter", c.Writer);
            Assert.Equal("Title", c.Name);
            Assert.Equal(1, c.Number);
        }

        [Fact]
        public void ConvertFromFileTest2()
        {
            var c = Comic.ConvertFromFileName("[Writer & Writer] Title？ 01s.zip");
            Assert.Equal("Writer & Writer", c.Writer);
            Assert.Equal("Title？", c.Name);
            Assert.Equal(1, c.Number);
        }

        [Fact]
        public void ConvertFromFileTest3()
        {
            var c = Comic.ConvertFromFileName("[Writer] Title ～Title～ 第01-12巻.zip");
            Assert.Equal("Writer", c.Writer);
            Assert.Equal("Title ～Title～", c.Name);
            Assert.Equal(1, c.RangeNumber.Value.Start);
            Assert.Equal(12, c.RangeNumber.Value.End);
        }

        [Fact]
        public void ConvertFromFileTest4()
        {
            var c = Comic.ConvertFromFileName("[Writer×Writer] Title！ 01-02.rar");
            Assert.Equal("Writer×Writer", c.Writer);
            Assert.Equal("Title！", c.Name);
            Assert.Equal(1, c.RangeNumber.Value.Start);
            Assert.Equal(2, c.RangeNumber.Value.End);
        }

        [Fact]
        public void ConvertFromFileTest5()
        {
            var c = Comic.ConvertFromFileName("[Writer] Title 01-03b.rar");
            Assert.Equal("Writer", c.Writer);
            Assert.Equal("Title", c.Name);
            Assert.Equal(1, c.RangeNumber.Value.Start);
            Assert.Equal(3, c.RangeNumber.Value.End);
        }

        [Fact]
        public void ConvertFromFileTest6()
        {
            var c = Comic.ConvertFromFileName("[Writer×Writer] Title Title.rar");
            Assert.Equal("Writer×Writer", c.Writer);
            Assert.Equal("Title Title", c.Name);
            Assert.Null(c.Number);
        }

        [Fact]
        public void ConvertFromFileTest7()
        {
            var c = Comic.ConvertFromFileName("[Writer] Title!! 第04-05巻.rar");
            Assert.Equal("Writer", c.Writer);
            Assert.Equal("Title!!", c.Name);
            Assert.Equal(4, c.RangeNumber.Value.Start);
            Assert.Equal(5, c.RangeNumber.Value.End);
        }

        [Fact]
        public void ConvertFromFileTest8()
        {
            var c = Comic.ConvertFromFileName("[Writer] Title 第01巻～第04巻.zip");
            Assert.Equal("Writer", c.Writer);
            Assert.Equal("Title", c.Name);
            Assert.Equal(1, c.RangeNumber.Value.Start);
            Assert.Equal(4, c.RangeNumber.Value.End);
        }

        [Fact]
        public void ConvertFromFileTest9()
        {
            var c = Comic.ConvertFromFileName("[Writer] Title 第01～12巻.zip");
            Assert.Equal("Writer", c.Writer);
            Assert.Equal("Title", c.Name);
            Assert.Equal(1, c.RangeNumber.Value.Start);
            Assert.Equal(12, c.RangeNumber.Value.End);
        }

        [Fact]
        public void ConvertFromFileTest10()
        {
            var c = Comic.ConvertFromFileName("[Writer] Title 第12～16巻.rar");
            Assert.Equal("Writer", c.Writer);
            Assert.Equal("Title", c.Name);
            Assert.Equal(12, c.RangeNumber.Value.Start);
            Assert.Equal(16, c.RangeNumber.Value.End);
        }

        [Fact]
        public void ConvertFromFileTest11()
        {
            var c = Comic.ConvertFromFileName("[Writer] Title！ 01-06e.rar");
            Assert.Equal("Writer", c.Writer);
            Assert.Equal("Title！", c.Name);
            Assert.Equal(1, c.RangeNumber.Value.Start);
            Assert.Equal(6, c.RangeNumber.Value.End);
        }

        [Fact]
        public void ConvertFromFileTest12()
        {
            var c = Comic.ConvertFromFileName("[Writer] Title 01-06e.rar");
            Assert.Equal("Writer", c.Writer);
            Assert.Equal("Title", c.Name);
            Assert.Equal(1, c.RangeNumber.Value.Start);
            Assert.Equal(6, c.RangeNumber.Value.End);
        }

        [Fact]
        public void ConvertFromFileTest13()
        {
            var c = Comic.ConvertFromFileName("[Writer] T.Title 第01～第18巻.zip");
            Assert.Equal("Writer", c.Writer);
            Assert.Equal("T.Title", c.Name);
            Assert.Equal(1, c.RangeNumber.Value.Start);
            Assert.Equal(18, c.RangeNumber.Value.End);
        }

        [Fact]
        public void ConvertFromFileTest14()
        {
            var c = Comic.ConvertFromFileName("[Writer×Writer] Title 01-08e.rar");
            Assert.Equal("Writer×Writer", c.Writer);
            Assert.Equal("Title", c.Name);
            Assert.Equal(1, c.RangeNumber.Value.Start);
            Assert.Equal(8, c.RangeNumber.Value.End);
        }

        [Fact]
        public void ConvertFromFileTest15()
        {
            var c = Comic.ConvertFromFileName("[Writer] Title Title 第01～08巻.rar");
            Assert.Equal("Writer", c.Writer);
            Assert.Equal("Title Title", c.Name);
            Assert.Equal(1, c.RangeNumber.Value.Start);
            Assert.Equal(8, c.RangeNumber.Value.End);
        }
        
        [Fact]
        public void ConvertFromFileTest16()
        {
            var c = Comic.ConvertFromFileName("[Writer×Writer] Title Title －Title－ Title カラー版 第01卷.zip");
            Assert.Equal("Writer×Writer", c.Writer);
            Assert.Equal("Title Title －Title－ Title カラー版", c.Name);
            Assert.Equal(1, c.Number);
        }

        [Fact]
        public void ConvertFromFileTest17()
        {
            var c = Comic.ConvertFromFileName("[Writer] Title 07-12se.zip");
            Assert.Equal("Writer", c.Writer);
            Assert.Equal("Title", c.Name);
            Assert.Equal(7, c.RangeNumber.Value.Start);
            Assert.Equal(12, c.RangeNumber.Value.End);
        }
    }
}
