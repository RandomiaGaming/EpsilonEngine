namespace TestProject
{
    public static class Program
    {
        [System.STAThread()]
        public static int Main()
        {
            DMCCR dmccr = new DMCCR();
            dmccr.Run();
            return 0;
        }
    }
}