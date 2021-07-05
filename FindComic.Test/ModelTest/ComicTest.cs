using FindComic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FindComic.Test.ModelTest
{
    public class ComicTest
    {
        [Fact]
        public void ConvertFromFileTest1()
        {
            var c = Comic.ConvertFromFileName("[Ark Performance] 蒼き鋼のアルペジオ 第01巻.rar");
            Assert.Equal("Ark Performance", c.Writer);
            Assert.Equal("蒼き鋼のアルペジオ", c.Name);
            Assert.Equal(1, c.Number);
        }

        [Fact]
        public void ConvertFromFileTest2()
        {
            var c = Comic.ConvertFromFileName("[CHuN & iimAn] 可愛ければ変態でも好きになってくれますか？ 01s.zip");
            Assert.Equal("CHuN & iimAn", c.Writer);
            Assert.Equal("可愛ければ変態でも好きになってくれますか？", c.Name);
            Assert.Equal(1, c.Number);
        }

        [Fact]
        public void ConvertFromFileTest3()
        {
            var c = Comic.ConvertFromFileName("[CLAMP] xxxHOLiC ～ホリック～ 第01-12巻.zip");
            Assert.Equal("CLAMP", c.Writer);
            Assert.Equal("xxxHOLiC ～ホリック～", c.Name);
            Assert.Equal(1, c.RangeNumber.Value.Start);
            Assert.Equal(12, c.RangeNumber.Value.End);
        }

        [Fact]
        public void ConvertFromFileTest4()
        {
            var c = Comic.ConvertFromFileName("[COMTA×樋辻臥命] 異世界魔法は遅れてる！ 01-02.rar");
            Assert.Equal("COMTA×樋辻臥命", c.Writer);
            Assert.Equal("異世界魔法は遅れてる！", c.Name);
            Assert.Equal(1, c.RangeNumber.Value.Start);
            Assert.Equal(2, c.RangeNumber.Value.End);
        }

        [Fact]
        public void ConvertFromFileTest5()
        {
            var c = Comic.ConvertFromFileName("[Cuvie] 絢爛たるグランドセーヌ 01-03b.rar");
            Assert.Equal("Cuvie", c.Writer);
            Assert.Equal("絢爛たるグランドセーヌ", c.Name);
            Assert.Equal(1, c.RangeNumber.Value.Start);
            Assert.Equal(3, c.RangeNumber.Value.End);
        }

        [Fact]
        public void ConvertFromFileTest6()
        {
            var c = Comic.ConvertFromFileName("[あざの耕平×COMTA] 東京レイヴンズ 東京フォックス.rar");
            Assert.Equal("あざの耕平×COMTA", c.Writer);
            Assert.Equal("東京レイヴンズ 東京フォックス", c.Name);
            Assert.Null(c.Number);
        }

        [Fact]
        public void ConvertFromFileTest7()
        {
            var c = Comic.ConvertFromFileName("[おりもとみまな] ばくおん!! 第04-05巻 .rar");
            Assert.Equal("おりもとみまな", c.Writer);
            Assert.Equal("ばくおん!!", c.Name);
            Assert.Equal(4, c.RangeNumber.Value.Start);
            Assert.Equal(5, c.RangeNumber.Value.End);
        }

        [Fact]
        public void ConvertFromFileTest8()
        {
            var c = Comic.ConvertFromFileName("[あずまきよひこ] あずまんが大王 第01巻～第04巻.zip");
            Assert.Equal("あずまきよひこ", c.Writer);
            Assert.Equal("あずまんが大王", c.Name);
            Assert.Equal(1, c.RangeNumber.Value.Start);
            Assert.Equal(4, c.RangeNumber.Value.End);
        }

        [Fact]
        public void ConvertFromFileTest9()
        {
            var c = Comic.ConvertFromFileName("[伊藤明弘] ジオブリーダーズ 第01～12巻.zip");
            Assert.Equal("伊藤明弘", c.Writer);
            Assert.Equal("ジオブリーダーズ", c.Name);
            Assert.Equal(1, c.RangeNumber.Value.Start);
            Assert.Equal(12, c.RangeNumber.Value.End);
        }

        [Fact]
        public void ConvertFromFileTest10()
        {
            var c = Comic.ConvertFromFileName("[伊藤明弘] ジオブリーダーズ 第12～16巻.rar");
            Assert.Equal("伊藤明弘", c.Writer);
            Assert.Equal("ジオブリーダーズ", c.Name);
            Assert.Equal(12, c.RangeNumber.Value.Start);
            Assert.Equal(16, c.RangeNumber.Value.End);
        }

        [Fact]
        public void ConvertFromFileTest11()
        {
            var c = Comic.ConvertFromFileName("[佐々木倫子] チャンネルはそのまま！ 01-06e.rar");
            Assert.Equal("佐々木倫子", c.Writer);
            Assert.Equal("チャンネルはそのまま！", c.Name);
            Assert.Equal(1, c.RangeNumber.Value.Start);
            Assert.Equal(6, c.RangeNumber.Value.End);
        }

        [Fact]
        public void ConvertFromFileTest12()
        {
            var c = Comic.ConvertFromFileName("[佐々木倫子] Heaven 01-06e.rar");
            Assert.Equal("佐々木倫子", c.Writer);
            Assert.Equal("Heaven", c.Name);
            Assert.Equal(1, c.RangeNumber.Value.Start);
            Assert.Equal(6, c.RangeNumber.Value.End);
        }

        [Fact]
        public void ConvertFromFileTest13()
        {
            var c = Comic.ConvertFromFileName("[山田貴敏] Dr.コトー診療所 第01～第18巻.zip");
            Assert.Equal("山田貴敏", c.Writer);
            Assert.Equal("Dr.コトー診療所", c.Name);
            Assert.Equal(1, c.RangeNumber.Value.Start);
            Assert.Equal(18, c.RangeNumber.Value.End);
        }

        [Fact]
        public void ConvertFromFileTest14()
        {
            var c = Comic.ConvertFromFileName("[川原正敏×飛永宏之] 修羅の門異伝ふでかげ 01-08e.rar");
            Assert.Equal("川原正敏×飛永宏之", c.Writer);
            Assert.Equal("修羅の門異伝ふでかげ", c.Name);
            Assert.Equal(1, c.RangeNumber.Value.Start);
            Assert.Equal(8, c.RangeNumber.Value.End);
        }

        [Fact]
        public void ConvertFromFileTest15()
        {
            var c = Comic.ConvertFromFileName("[曽田正人] capeta カペタ 第01～08巻.rar");
            Assert.Equal("曽田正人", c.Writer);
            Assert.Equal("capeta カペタ", c.Name);
            Assert.Equal(1, c.RangeNumber.Value.Start);
            Assert.Equal(8, c.RangeNumber.Value.End);
        }

        [Fact]
        public void ConvertFromFileTest16()
        {
            var c = Comic.ConvertFromFileName("[矢吹健太朗×長谷見沙貴] To LOVEる －とらぶる－ ダークネス カラー版 第01卷.zip");
            Assert.Equal("矢吹健太朗×長谷見沙貴", c.Writer);
            Assert.Equal("To LOVEる －とらぶる－ ダークネス カラー版", c.Name);
            Assert.Equal(1, c.Number);
        }
    }
}
