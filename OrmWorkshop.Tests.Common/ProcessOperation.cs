#region licence
// <copyright file="ProcessOperation.cs" company="nerobianchi">
// </copyright>
// <summary>
// 	Project Name:	OrmWorkshop.Tests.Common
// 	Created By: 	erdem.ozdemir
// 	Create Date:	07.06.2016 09:33
// 	Last Changed By:	erdem.ozdemir
// 	Last Change Date:	07.06.2016 09:33
// </summary>
#endregion

using System.Diagnostics;
using System.Threading;

namespace OrmWorkshop.Tests.Common
{
	public class ProcessOperation
	{
		public static void StartNH()
		{
			StartIISExpress("OrmWorkshop.Web.Application.NH");
		}

		public static void StartEF()
		{
			StartIISExpress("OrmWorkshop.Web.Application.EF");
		}


		public static void StartIISExpress(string siteName)
		{
			Process process = new Process();
			ProcessStartInfo startInfo = new ProcessStartInfo();
			startInfo.WindowStyle = ProcessWindowStyle.Hidden;
			startInfo.FileName = @"c:\Program Files (x86)\IIS Express\iisexpress";
			startInfo.Arguments = string.Format("/site:{0}", siteName);
			process.StartInfo = startInfo;
			process.Start();
		}

		public static void Cleanup()
		{
			Process process = new Process();
			ProcessStartInfo startInfo = new ProcessStartInfo();
			startInfo.WindowStyle = ProcessWindowStyle.Hidden;
			startInfo.FileName = "taskkill";
			startInfo.Arguments = "/F /FI \"IMAGENAME eq iisexpress.exe\"";
			process.StartInfo = startInfo;
			process.Start();

			Thread.Sleep(1000);
		}
	}
}