using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace AplicacionGitHub.Model
{
    public class PersonaModel : INotifyPropertyChanged
    {

        #region Eventos...

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string nombre = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombre));

        }

        #endregion



        #region Propiedades...

        //Propiedad privada
        private String id;

        public String Id
        {
            get { return id; }
            set { id = value;
                OnPropertyChanged();
            }
        }


        private String nombre;

        public String Nombre
        {
            get { return nombre; }
            set { nombre = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(NombreCompleto));
            }
        }


        private String apellido;

        public String Apellido
        {
            get { return apellido; }
            set { apellido = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(NombreCompleto));
            }
        }


        private int edad;

        public int Edad
        {
            get { return edad; }
            set { edad = value;
                OnPropertyChanged();
            }
        }

        private String nombreCompleto;

        public String NombreCompleto
        {
            get { 
                return $"{Nombre} {Apellido}";

            }
            set {nombreCompleto = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Mensaje));
            }
        }


        private String mensaje;

        public String Mensaje
        {
            get { return $"Tu nombre es: {NombreCompleto}"; }
            
        }

        private bool cargando=false;

        public bool Cargando
        {
            get { return cargando=false; }
            set { cargando = value;
                OnPropertyChanged();
            }
        }


        #endregion

    }
}
