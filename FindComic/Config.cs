using System.Configuration;

namespace FindComic
{
    /// <summary>
    /// App.config管理クラス
    /// </summary>
    static class Config
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        static Config()
        {
            // App.config内の全てのSettings
            var settings = ConfigurationManager.AppSettings;

            // Configクラスのプロパティを読み出し
            foreach (var pi in typeof(Config).GetProperties())
            {
                // App.configのvalueを取得
                var value = settings.Get(pi.Name);
                if (value == null) continue;

                // stringの場合そのまま取得
                if (pi.PropertyType == typeof(string))
                {
                    pi.SetValue(null, value);
                }
            }
        }

        static public string RootPath { get; private set; }

    }
}
