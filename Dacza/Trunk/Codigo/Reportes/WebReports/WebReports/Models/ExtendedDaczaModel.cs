using System;
using System.ComponentModel;
using System.Data.EntityClient;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace WebReports.Models
{
       
        public partial class Usuario : EntityObject
        {
            public List<LoginValidate> ErrorStates;

            private String Encripta(String texto)
            {
                System.Text.StringBuilder encripta = new System.Text.StringBuilder();
                for (int i = 0; i < texto.Length; i++)
                {
                    char c = texto.ToCharArray()[i];
                    if (c < 128) c = (char)(c + 128);
                    else c = (char)(c - 128);
                    encripta.Append(c);

                }
                return encripta.ToString();
            }

            public bool IsValid(DACZAEntities _db)
            {
                bool bValido = true;
                ErrorStates = new List<LoginValidate>();

                if (string.IsNullOrEmpty(this.Clave))
                {
                    ErrorStates.Add(new LoginValidate(LoginValidateStatus.UserRequired));
                    bValido = false;                   
                }
                if (string.IsNullOrEmpty(this.ClaveAcceso))
                {
                    ErrorStates.Add(new LoginValidate(LoginValidateStatus.PasswordRequired));
                    bValido = false;
                }
                if (!string.IsNullOrEmpty(this.Clave) && !string.IsNullOrEmpty(this.ClaveAcceso))
                {
                    string pwdEnc = Encripta(this.ClaveAcceso);
                    bool exist = _db.Usuario.Any(x => x.Clave == this.Clave && x.ClaveAcceso == pwdEnc);
                    if (!exist)
                    {
                        ErrorStates.Add(new LoginValidate(LoginValidateStatus.UserNotValid));
                        bValido = false;
                    }
                    else {
                        exist = _db.Usuario.Any(x => x.Clave == this.Clave && x.ClaveAcceso == pwdEnc && x.Tipo == 1);
                        if (!exist)
                        {
                            ErrorStates.Add(new LoginValidate(LoginValidateStatus.NoAccessAllowed));
                            bValido = false;
                        }
                    }
                }

                return bValido;
            }
        }
        public enum LoginValidateStatus
        {
            Success = 0,
            UserRequired = 1,
            PasswordRequired = 2,
            UserNotValid = 3,
            NoAccessAllowed = 4
        }
        public class LoginValidate
        {
            LoginValidateStatus _status;
            string[] _parameters;

            public LoginValidate(LoginValidateStatus _status)
            {
                this._status = _status;
            }

            public LoginValidate(LoginValidateStatus _status, string[] _parameters)
            {
                this._status = _status;
                this._parameters = _parameters;
            }

            public LoginValidateStatus status
            {
                get { return _status; }
            }

            public string[] parameters
            {
                get { return _parameters; }
            }
        }
        public class ValidateLogin
        {
            public static string ErrorCodeToString(LoginValidate errorStatus)
            {
                switch (errorStatus.status)
                {
                    case LoginValidateStatus.UserRequired:
                        return "El usuario es requerido.";
                    case LoginValidateStatus.PasswordRequired:
                        return "La contraseña es requerida.";
                    case LoginValidateStatus.UserNotValid:
                        return "Usuario o contraseña incorrecta.";
                    case LoginValidateStatus.NoAccessAllowed:
                        return "El usuario no tiene permiso para acceder a la aplicación.";
                    default:
                        return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
                }
            }
        }

        public partial class Taller : EntityObject
        {
            public string TmpUsuarioId { get; set; }

            List<UsuarioTaller> _lstUsuarios;

            public List<UsuarioTaller> Usuarios {
                get {
                    if (_lstUsuarios == null)
                        _lstUsuarios = new List<UsuarioTaller>();
                    return _lstUsuarios;
                }
                set { _lstUsuarios = value; }
            }

            List<string> _lstUsuariosElim;

            public List<string> UsuariosEliminados
            {
                get
                {
                    if (_lstUsuariosElim == null)
                        _lstUsuariosElim = new List<string>();
                    return _lstUsuariosElim;
                }
                set { _lstUsuariosElim = value; }
            }

            public List<TallerValidate> ErrorStates;

            public bool IsValid(DACZAEntities _db)
            {
                bool bValido = true;
                ErrorStates = new List<TallerValidate>();
                                
                if (!string.IsNullOrEmpty(this.Clave))
                {                    
                    bool exist = _db.Taller.Any(x => x.Clave == this.Clave && x.TallerId != this.TallerId);
                    if (exist)
                    {
                        ErrorStates.Add(new TallerValidate(TallerValidateStatus.Duplicated));
                        bValido = false;
                    }                    
                }
                if (this.Usuarios.Count == 0)
                {
                    ErrorStates.Add(new TallerValidate(TallerValidateStatus.UserRequired));
                    bValido = false;
                }

                return bValido;
            }

            public void Update(Taller taller, DACZAEntities _db)
            {                
                foreach (UsuarioTaller oUT in taller.Usuarios)
                {
                    _db.Usuario.First(x => x.UsuarioId == oUT.UsuarioId).TallerId = taller.TallerId;
                    _db.Usuario.First(x => x.UsuarioId == oUT.UsuarioId).MFechaHora = DateTime.Now;
                }
                foreach (string sUsuario in taller.UsuariosEliminados) {
                    _db.Usuario.First(x => x.UsuarioId == sUsuario).TallerId = null;
                    _db.Usuario.First(x => x.UsuarioId == sUsuario).MFechaHora = DateTime.Now;
                }

                this.Activo = taller.Activo;
                this.Descripcion = taller.Descripcion;
                this.MFechaHora = taller.MFechaHora;
                this.MUsuarioId = taller.MUsuarioId;               
            }
        }

        public enum TallerValidateStatus
        {
            Success = 0,
            Duplicated = 1,
            UserRequired = 2
        }
        public class TallerValidate
        {
            TallerValidateStatus _status;
            string[] _parameters;

            public TallerValidate(TallerValidateStatus _status)
            {
                this._status = _status;
            }

            public TallerValidate(TallerValidateStatus _status, string[] _parameters)
            {
                this._status = _status;
                this._parameters = _parameters;
            }

            public TallerValidateStatus status
            {
                get { return _status; }
            }

            public string[] parameters
            {
                get { return _parameters; }
            }
        }
        public class ValidateTaller
        {
            public static string ErrorCodeToString(TallerValidate errorStatus)
            {
                switch (errorStatus.status)
                {
                    case TallerValidateStatus.Duplicated:
                        return "La Clave ya existe en otro Taller. Intente con una clave distinta.";
                    case TallerValidateStatus.UserRequired:
                        return "Al menos un agente es requerido.";
                    default:
                        return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
                }
            }
        }

        public class UsuarioTaller {

            public UsuarioTaller() { }

            public UsuarioTaller(string sUsuarioId, string sClave, string sNombre) {
                this.UsuarioId = sUsuarioId;
                this.Clave = sClave;
                this.Nombre = sNombre;
            }

            public string UsuarioId { get; set; }

            public string Clave { get; set; }

            public string Nombre { get; set; }
        }
}