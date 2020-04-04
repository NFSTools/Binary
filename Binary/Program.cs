using System;
using System.Threading;
using System.Globalization;
using System.Windows.Forms;
using System.Security.Principal;



namespace Binary
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
        [Obsolete]
        static void Main()
		{
            // Skip administator check if in the debug mode
            if (System.Diagnostics.Debugger.IsAttached)
                goto LABEL_DEBUG_SKIP;

            // Check if the program is run as administator, exit if not
            using (var identity = WindowsIdentity.GetCurrent())
            {
                var principal = new WindowsPrincipal(identity);
                if (!principal.IsInRole(WindowsBuiltInRole.Administrator))
                {
                    MessageBox.Show("Run Binary in Administrator mode!", "Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

        LABEL_DEBUG_SKIP:
            AppDomain.CurrentDomain.AppendPrivatePath("Libraries");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var culture = CultureInfo.CreateSpecificCulture("en-US");
            Thread.CurrentThread.CurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;

            // If password check was not done yet
            if (!Properties.Settings.Default.PasswordPassed)
            {
                Application.Run(new Interact.Welcome());
            }

            // Run if was done/entered
            if (Properties.Settings.Default.PasswordPassed)
            {
                Application.Run(new Main.Main());
            }
        }
    }
}
