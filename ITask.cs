namespace MLOOP2_L3
{
    internal interface ITask
    {
        public static string Name { get; }
        public static string defaultFileName { get; }
        public static abstract void Start();
    }
}
