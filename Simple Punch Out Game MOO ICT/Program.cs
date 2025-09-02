namespace Simple_Punch_Out_Game_MOO_ICT
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            MessageBox.Show("Fighting Game!\nPress A and D to move\nPress left, right and down key to attack and block", "Instructions");
            Application.Run(new Form1());
        }
    }
}