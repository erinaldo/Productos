using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Descripción breve de UtileriaMensaje
/// </summary>
public class UtilMensaje
{
    //private static UtilMensaje utileriaMensaje;
    private static Dictionary<string, string> mensajes;

    public static string ObtenerMensaje(string clave)
    {
        lock ("MensajesCargados")
        {
            if (mensajes == null)
            {
                for (int i = 0; i < 3; i++)
                {
                    using (MODMEG.MegaCableEntities contexto = new MODMEG.MegaCableEntities())
                    {
                        mensajes = new Dictionary<string, string>();
                        var qry = from men in contexto.Mensaje select new { men.ClaveMensaje, men.Descripcion };
                        foreach (var ele in qry)
                            mensajes.Add(ele.ClaveMensaje.ToUpper(), ele.Descripcion);
                    }
                    if (mensajes.Count == 0)
                    {
                        mensajes = null;
                        System.Threading.Thread.Sleep(3000);
                    }
                    else
                        break;
                }
            }
        }

        if (clave.Trim().Length < 2)
            return clave;

        string[] contenido = clave.Split(new char[] { ',' });

        clave = contenido[0].Trim().Substring(1).ToUpper();

        if ((contenido.Length == 0) || (!mensajes.ContainsKey(clave)))
            return clave;

        clave = mensajes[clave];
        if (contenido.Length > 1)
        {
            List<object> parametros = new List<object>();
            for (int i = 1; i < contenido.Length; i++)
            {
                string tmp = contenido[i].Trim();
                bool eti = tmp.StartsWith("#");
                tmp = tmp.Substring(1).ToUpper();
                if (eti && (mensajes.ContainsKey(tmp)))
                    parametros.Add(mensajes[tmp]);
                else
                    parametros.Add(tmp);
            }
            clave = String.Format(clave, parametros.ToArray());
            return clave;
        }

        return clave;
    }


	public UtilMensaje()
	{
        
	}
}