using System;
using System.Collections.Generic;
using System.IO;

namespace macron {
    class ControlAirport() {

        static string[] getCrontab() {
       string crontab = RUN.RunCommand("crontab", "-l");
       crontab = crontab.TrimEnd();
       string[] lines = crontab.Split(Environment.NewLine);
        return lines;
      }

        public static bool TurnAirportOff() {
           return TurnAirport("off");
	}

        public static bool TurnAirportOn() {
           return TurnAirport("on");
	}

        public static bool TurnAirport(string onOrOff) {
		//System.Console.WriteLine(onOrOff);
		//string[] newCrontabs = new string[] { };
		List<string> newCrontabs = new List<string>(); 
foreach ( var ct in getCrontab()) {
   //if (String.IsNullOrWhiteSpace(ct)) 
   //    continue;
   if (!(ct.Contains("networksetup") && ct.Contains("-setairportpower"))) {
      //Array.Resize(ref newCrontabs, newCrontabs.Length + 1);
      //newCrontabs[^1] = ct; 
      newCrontabs.Add(ct.TrimEnd()); 
   }
};
      //if (newCrontabs[-1].Trim()){
      // //  newCrontabs.RemoveAt(newCrontabs.Count - 1);
     // }

      if (onOrOff == "on") {
        Console.WriteLine("Turning airport on");
	RUN.RunCommand( "networksetup", "-setairportpower airport on");
	newCrontabs.Add( "@reboot networksetup -setairportpower airport on");
      } else if (onOrOff == "off") {
        Console.WriteLine("Turning airport off");
	RUN.RunCommand( "networksetup", "-setairportpower airport off");
	newCrontabs.Add( "@reboot networksetup -setairportpower airport off");
      } 
       
    string newCron = String.Join(Environment.NewLine, newCrontabs);
    string tempfilepath = System.IO.Path.GetTempFileName();  // todo cleanup
    //Console.WriteLine(tempfilepath);

    Console.WriteLine("Installing new cron");
    Console.WriteLine(newCron);
    using (StreamWriter outputFile = new StreamWriter(tempfilepath)) 
    { 
	foreach (string line in newCrontabs)
	    outputFile.WriteLine(line.TrimEnd('\n'));
    }
    RUN.RunCommand("crontab", tempfilepath);
    //System.Console.WriteLine(String.Join(Environment.NewLine, newCrontabs));
    return true;
    } 
  }

}
