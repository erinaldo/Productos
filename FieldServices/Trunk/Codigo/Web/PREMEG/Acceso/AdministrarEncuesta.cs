using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MODMEG;
using System.Data.Objects.DataClasses;
using System.Data.Objects;

namespace PREMEG.Acceso
{
    public class AdministrarEncuesta
    {
        private INavegacionEncuesta vista;
        private static MegaCableEntities contexto;
        

       

        public AdministrarEncuesta()
        {
        }

        public AdministrarEncuesta(INavegacionEncuesta Vista)
        {
            vista = Vista;
        }

        public void ObtenerEncuestas()
        {
            using (MegaCableEntities contexto = new MegaCableEntities())
            {
                var lista = from enc in contexto.Encuesta.Include("ValorReferencia") select enc;
                vista.PresentarEncuestas(lista.ToList());
            }
        }


        public List<ValorReferencia> ObtenerTiposEncuestas()
        {
            using (MegaCableEntities contexto = new MegaCableEntities())
            {
                var lista = from val in contexto.ValorReferencia where val.Clave == "TIPOENC" && val.Estado select val;
                return lista.ToList();
            }
        }

        public List<Pregunta> ObtenerPreguntas(Encuesta encuesta)
        {
            using (MegaCableEntities contexto = new MegaCableEntities())
            {
                var preguntas = from p in contexto.Pregunta.Include("ValorReferencia") where p.ClaveEncuesta == encuesta.ClaveEncuesta select p ;
                return preguntas.ToList();
                
            }
        }
        public List<PreguntaOpcion> ObtenerOpcionesPreguntas(Encuesta encuesta)
        {
            using (MegaCableEntities contexto = new MegaCableEntities())
            {
                var opciones = from o in contexto.PreguntaOpcion where o.Pregunta.Encuesta.ClaveEncuesta == encuesta.ClaveEncuesta select o;
                return opciones.ToList();
            }
        }

        public List<ValorReferencia> ObtenerTiposPregunta()
        {
            using (MegaCableEntities contexto = new MegaCableEntities())
            {
                var lista = from val in contexto.ValorReferencia where val.Clave == "TIPOPRE" && val.Estado select val;
                return lista.ToList();
            }
        }

        public void ActualizarEncuesta(Encuesta EncuestaEditada, List<Pregunta> Preguntas, List<PreguntaOpcion> OpcionesPregunta)
        {
            using (MegaCableEntities contexto = new MegaCableEntities())
            {
                contexto.Encuesta.Attach(EncuestaEditada);
                
                EncuestaEditada.SetAllModified(contexto);
                EncuestaEditada.Pregunta.Attach(EncuestaEditada.Pregunta.CreateSourceQuery().Include("PreguntaOpcion"));
                EncuestaEditada.Pregunta.Load();
                foreach (Pregunta p in Preguntas)
                {
                     Pregunta preguntaEditar = EncuestaEditada.Pregunta.FirstOrDefault(pregu => pregu.IdPregunta == p.IdPregunta);
                    if (preguntaEditar== null)
                    {
                        p.ValorReferencia = null;
                        contexto.Pregunta.AddObject(p);
                        EncuestaEditada.Pregunta.Add(p);
                        List<PreguntaOpcion> opciones = (from op in OpcionesPregunta where op.IdPregunta == p.IdPregunta select op).ToList();
                        foreach (PreguntaOpcion o in opciones)
                        {
                            contexto.PreguntaOpcion.AddObject(o);
                            p.PreguntaOpcion.Add(o);
                        }
                    }
                    else
                    {
                        if (p.EntityState == System.Data.EntityState.Modified)
                        {
                            preguntaEditar.Descripcion = p.Descripcion;
                            preguntaEditar.TipoPregunta = p.TipoPregunta;
                            preguntaEditar.Orden = p.Orden;
                        }


                        List<PreguntaOpcion> opciones = (from op in OpcionesPregunta where op.IdPregunta == p.IdPregunta select op).ToList();
                        foreach (PreguntaOpcion o in opciones)
                        {
                            PreguntaOpcion opcion = contexto.PreguntaOpcion.FirstOrDefault(opc => opc.IdPreguntaOpcion == o.IdPreguntaOpcion);
                            if (opcion == null)
                            {
                                contexto.PreguntaOpcion.AddObject(o);
                                preguntaEditar.PreguntaOpcion.Add(o);
                            }
                            else if (o.EntityState == System.Data.EntityState.Modified)
                                opcion.Descripcion = o.Descripcion;
                        }

                        List<PreguntaOpcion> listaOriginal = preguntaEditar.PreguntaOpcion.ToList();
                        foreach (PreguntaOpcion o in listaOriginal)
                        {
                            if (!OpcionesPregunta.Exists(pre=> pre.IdPreguntaOpcion == o.IdPreguntaOpcion ))
                            {
                                //PreguntaOpcion opcion = p.PreguntaOpcion.FirstOrDefault(opc => opc.IdPreguntaOpcion == o.IdPreguntaOpcion);

                                preguntaEditar.PreguntaOpcion.Remove(o);
                                contexto.DeleteObject(o);
                            }
                        }
                    }
                }
                foreach (Pregunta p in EncuestaEditada.Pregunta)
                {

                    if (!Preguntas.Exists(pre => pre.IdPregunta == p.IdPregunta))
                    {
                        Pregunta preguntaEditar = EncuestaEditada.Pregunta.FirstOrDefault(pregu => pregu.IdPregunta == p.IdPregunta);

                        foreach (PreguntaOpcion o in preguntaEditar.PreguntaOpcion)
                        {
                            p.PreguntaOpcion.Remove(o);
                            contexto.PreguntaOpcion.DeleteObject(o);
                        }
                        EncuestaEditada.Pregunta.Remove(preguntaEditar);
                        contexto.Pregunta.DeleteObject(preguntaEditar);
                    }
                }
                contexto.SaveChanges();
            }
        }
        private void AgregarPreguntaOpcion(Pregunta pregunta, MegaCableEntities contexto){
            
        }

        public void RegistrarEncuesta(Encuesta encActual, List<Pregunta> pregEncuesta, List<PreguntaOpcion> opcionesPregunta)
        {
            using (MegaCableEntities contexto = new MegaCableEntities())
            {
                contexto.Encuesta.AddObject(encActual);
                foreach (Pregunta p in pregEncuesta)
                {

                    p.ValorReferencia = null;
                    p.ClaveEncuesta = encActual.ClaveEncuesta;
                    contexto.Pregunta.AddObject(p);
                    encActual.Pregunta.Add(p);
                    List<PreguntaOpcion> opciones = (from op in opcionesPregunta where op.IdPregunta == p.IdPregunta select op).ToList();
                    foreach (PreguntaOpcion o in opciones)
                    {
                        contexto.PreguntaOpcion.AddObject(o);
                        p.PreguntaOpcion.Add(o);
                    }
                }
                contexto.SaveChanges();
            }
        }
    }
}
