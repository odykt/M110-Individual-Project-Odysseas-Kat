namespace SECRIOUS.Effects
{
    public static class TypeWriterEffectMap
    {
        public static int charsPerSecond = 15;
        public static int fastCharsPerSecond
        {
            get { return charsPerSecond * 3; }
            set { fastCharsPerSecond = value; }
        }

    }
}
