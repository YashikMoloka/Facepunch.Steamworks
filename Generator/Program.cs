using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Generator
{
	class Program
	{
		public static SteamApiDefinition Definitions;

		static void Main( string[] args )
		{
			// Console.WriteLine(System.AppContext.BaseDirectory);
			// Console.WriteLine(Directory.GetCurrentDirectory());
			// Console.WriteLine(AppDomain.CurrentDomain.BaseDirectory);
			// Console.WriteLine(typeof(Program).Assembly.Location);
			// Console.WriteLine(Application.ExecutablePath);

			var fixInputPath = "../../../steam_sdk/steam_api.json";
			var fixOutputPath = "../../../../Facepunch.Steamworks/Generated/";
			var content = System.IO.File.ReadAllText( fixInputPath );
			var def = Newtonsoft.Json.JsonConvert.DeserializeObject<SteamApiDefinition>( content );

			Definitions = def;

			var generator = new CodeWriter( def );

			generator.ToFolder( fixOutputPath );
		}
	}
}
