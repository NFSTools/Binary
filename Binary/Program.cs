/********************************************************************************
 * MIT License
 * 
 * Copyright (c) 2020 MaxHwoy & NFS Tools
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE. 
********************************************************************************/



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
