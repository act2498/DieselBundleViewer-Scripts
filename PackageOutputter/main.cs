using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DieselBundleViewer;
using DieselBundleViewer.Services;
using DieselEngineFormats;
using DieselEngineFormats.Bundle;
using DieselEngineFormats.ScriptData;
using DieselEngineFormats.Bundle;
using System.Xml;

public class main
{
    public void register()
    {
        Console.WriteLine("Register");
        ScriptActions.RegisterScript(new PackageHashlistOutputter());
    }
}

public class PackageHashlistOutputter
{
    public string key = "package_hashlist_outputter";
    public string title = "Package Hashlist Outputter";

    public void execute()
    {
        var browser = Utils.CurrentWindow;
        using (StreamWriter file = new StreamWriter("packages.txt"))
        {
            foreach (var pair in browser.PackageHeaders)
            {
                PackageHeader package = pair.Value;
                if(package.Name.HasUnHashed)
                {
                    file.WriteLine("@"+package.Name);
                    Console.WriteLine("Current pacakge " + package.Name.UnHashed);
                }
                else
                {
                    Console.WriteLine("Current pacakge " + package.Name.Hashed);
                    Console.WriteLine("[Warning] no unhashed name, cannot add this pacakge to the list.");
                }
                foreach(PackageFileEntry entry in package.Entries)
                {
                    Idstring path = browser.DB.EntryFromID(entry.ID).Path;
                    Idstring ext = browser.DB.EntryFromID(entry.ID).Extension;
                    if(path.HasUnHashed)
                        if(package.Name.HasUnHashed)
                            file.WriteLine(path.UnHashed + "." + ext.UnHashed);
                    else
                        Console.WriteLine("File " + path.Hashed + " has no unhashed name, cannot add to the list.");
                }
            }

            file.WriteLine("@other");
            foreach(var pair in HashIndex.Hashes) 
            {
                if (pair.Value.HasUnHashed) {
                    string unhashed = pair.Value.UnHashed;
                    if (!unhashed.Contains("/") && !unhashed.Contains("PassThroughGP") && !unhashed.Contains("pln_") && !unhashed.Contains("achievement_")) {
                        file.WriteLine(unhashed);
                    }
                }
            }
        };
    }
}