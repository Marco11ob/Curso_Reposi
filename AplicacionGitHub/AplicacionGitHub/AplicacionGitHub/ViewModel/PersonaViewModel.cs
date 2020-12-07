using AplicacionGitHub.Model;
using AplicacionGitHub.Servicio;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AplicacionGitHub.ViewModel
{
    public class PersonaViewModel : PersonaModel
    {

        //listado de personas

        public ObservableCollection<PersonaModel> PERSONAS {get; set;}
        //Objeto
        PersonaServicio servicio = new PersonaServicio();

        //Objeto de modelo
        PersonaModel modelo;

        public PersonaViewModel()
        {
            PERSONAS = servicio.Consultar();
            GuardarCommand = new Command(async () => await Guardar(), () => !Cargando);
            ModificarCommand = new Command(async() => await Modificar(), () => !Cargando);
            EliminarCommand = new Command(async () => await Eliminar(), () => !Cargando);
            LimpiarCommand = new Command(Limpiar, () => !Cargando);
        }

        #region Comandos...
        //Comandos. Un command debe ejecutar un metodo.

        public Command GuardarCommand { get; set; }

        public Command ModificarCommand { get; set; }

        public Command EliminarCommand { get; set; }

        public Command LimpiarCommand { get; set; }

        #endregion


        #region Metodos...

        private async Task Guardar() {
            Guid IdPersona = Guid.NewGuid(); //Genera una cadena de caracteres unica
            Cargando = true;
            modelo = new PersonaModel();
            {
                Nombre = Nombre;
                Apellido = Apellido;
                Edad = Edad;
                Id = IdPersona.ToString()
            };
            servicio.Guardar(modelo);
            await Task.Delay(2000);
            Cargando = false;
        }


        private async Task Modificar()
        {
            Cargando = true;
            modelo = new PersonaModel();
            {
                Nombre = Nombre;
                Apellido = Apellido;
                Edad = Edad;
                Id = Id;
            };
            servicio.Modificar(modelo);
            await Task.Delay(2000);
            Cargando = false;
        }


        private async Task Eliminar()
        {
            Cargando = true;
            modelo = new PersonaModel();
            {
                Id = Id;
            };
            servicio.Eliminar(Id);
            await Task.Delay(2000);
            Cargando = false;
        }


        private void Limpiar() {

            Nombre = "";
            Apellido = "";
            Edad = 0;
            Id = "";
        }

        #endregion

       }
    }
