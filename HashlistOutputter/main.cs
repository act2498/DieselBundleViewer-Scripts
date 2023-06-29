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
using System.Xml;

public class main
{
    public void register()
    {
        Console.WriteLine("Register");
        ScriptActions.RegisterScript(new HashlistOutputter());
    }
}

public class HashlistOutputter
{
    public class main
{
    public void register()
    {
        Console.WriteLine("Register");
        ScriptActions.RegisterScript(new HashlistOutputter());
    }
}

    public string key = "hashlist_outputter";
    public string title = "Hashlist Outputter";

    public void execute()
    {
        HashIndex.GenerateHashList("./FullHashlist");
    }
}

