using AplicacionGitHub.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace AplicacionGitHub.Servicio
{
    public class PersonaServicio
    {
        //Objeto para almacenar los datos
        /* El "ObservableCollection" Representa una recopilación de 
        datos dinámica que proporciona notificaciones cuando se 
        agregan o eliminan elementos o cuando se actualiza toda la lista.*/


        public ObservableCollection<PersonaModel> Personas 
        { get; set; }

        //Constructor para que no cree un objeto cada que sea invocado.
        public PersonaServicio()
        {
            if (Personas == null) {
                Personas = new ObservableCollection<PersonaModel>();
            }
        }


        #region Metodos de edicion de lista...


        //Metodo encargado de retornar las personas.
        public  ObservableCollection<PersonaModel> Consultar(){
            return Personas;
        }

        public void Guardar(PersonaModel modelo) {
            Personas.Add(modelo);
        }

        //Recorrer el ObservableCollection donde sea el ID igual al de los datos, modificara 
        public void Modificar(PersonaModel modelo) {
            //Personas.Count es el tamanio de cuantas personas tenemos.
            for (int i = 0; i < Personas.Count; i++)
            {

                //El nombre que se ingresa debe ser igual al de la DB
                if (Personas[i].Id == modelo.Id)
                {
                    Personas[i] = modelo;
                }
            }
        
        }


        public void Eliminar(string idPersonas) {
            PersonaModel modelo = Personas.FirstOrDefault(p => p.Id == idPersonas);
            Personas.Remove(modelo);
        }

        #endregion
    }
}
