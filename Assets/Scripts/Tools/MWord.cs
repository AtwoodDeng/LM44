using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace AtLib.Gallery
{
    [System.Serializable]
    public class MWord
    {
        public string eng;
        public string ch;

        public enum Language
        {
            Chinese,

            English,
        }

        public static Language language = Language.Chinese;

        public string value
        {
            get
            {
                switch (language)
                {
                    case Language.Chinese:
                        return ch;
                    case Language.English:
                    default:
                        return eng;
                }
            }
        }
    }

}