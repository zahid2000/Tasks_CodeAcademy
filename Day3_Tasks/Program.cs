using System.Reflection;
using Day3_Tasks.Models;

void GetFeatures(Instrument instrument)
{
    Console.WriteLine($"<-- {instrument.GetType().Name} -->\n\n");

    Console.WriteLine($"{instrument.GetType().BaseType.Name}   :   {instrument.GetType().Name}");
    Console.WriteLine("------------------------------------------------");
    Console.WriteLine("Özellikler   : ");
    foreach (PropertyInfo p in instrument.GetType().GetProperties())
    {
        Console.Write("                 ");
        System.Console.WriteLine(p.Name + " : " + p.GetValue(instrument));
    }
    Console.WriteLine("------------------------------------------------");
    Console.WriteLine("Metodlar     : ");
    
        var methods = instrument.GetType().GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
            .Where(m => !m.IsSpecialName&&m.Name.ToString().StartsWith("S"));
        foreach (MethodInfo mi in methods)
        {
            Console.Write("                 ");
            Console.WriteLine($"Method Name : {mi.Name} , Return Type : {mi.ReturnType.Name} , Return value : {mi.Invoke(instrument, null)}");
        }

    
    Console.WriteLine("\n\n\n\n");

}

Instrument piano=new Piano("Yamaha","96x",23000, new DateTime(2000,01,03),12,9);

Instrument guitar=new Guitar("xxx","yyy",12000,new DateTime(1978, 07, 03),"zzz",true);
Instrument flute = new Flute("aaa","bbb",12112, new DateTime(2012, 09, 04),23);

GetFeatures(piano);
GetFeatures(guitar);
GetFeatures(flute);