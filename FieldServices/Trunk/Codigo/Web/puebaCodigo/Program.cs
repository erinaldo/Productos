using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace puebaCodigo
{
    class Program
    {
        static void Main(string[] args)
        {
            MODMEG.MegaCableEntities mega = new MODMEG.MegaCableEntities();
            
            /*if (!mega.DatabaseExists())
                mega.CreateDatabase();*/
            /*for (int i = 0; i < 1000; i++)
            {
                MODMEG.Modulo m = MODMEG.Modulo.CreateModulo(i.ToString(), "1", true);
                mega.AddToModulo(m);
            }*/
            List<MODMEG.Modulo> mods = new List<MODMEG.Modulo>(from m in mega.Modulo where m.ClaveModulo.Contains("1") select m );

            foreach (MODMEG.Modulo m in mods)
            {
                Console.WriteLine(m.ClaveModulo);
            }
            
            //mega.SaveChanges();
            
        }
    }
}
