using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Test_MA_WebForm_Datos;
using System.Diagnostics.Contracts;
using Test_MA_WebForm_Entidades;
using System.Security.Cryptography;

namespace Test_MA_WebForm_Negocio
{
    public class negocio
    {
        datos dalobj = new datos();

        public DataTable CargarListaDeClientes()
        {
            return dalobj.CargarListaDeClientes();
        }

        public DataTable CargaDatosCliente(string id)
        {
            return dalobj.CargaDatosCliente(id);
        }

        public bool EliminarCliente(string id)
        {
            return dalobj.EliminarCliente(id);
        }

        public bool ActualizarCliente(Entidades entidades)
        {
            return dalobj.ActualizarCliente(entidades);
        }

        public bool RegistrarCliente(Entidades entidades)
        {
            return dalobj.RegistrarCliente(entidades);
        }

        public DataTable CargaDatosSedes(string id)
        {
            return dalobj.CargaDatosSedes(id);
        }

        public bool EliminarSede(string id)
        {
            return dalobj.EliminarSede(id);
        }

        public bool ActualizarSede(Entidades entidades)
        {
            bool i = ValidarPaisDepartamento(entidades.CodCliente, entidades.Pais, entidades.Departamento);

            if (i)
            {
                return dalobj.ActualizarSede(entidades);
            }
            else
                return false;
        }

        public bool RegistrarSede(Entidades entidades)
        {

            bool i = ValidarPaisDepartamento(entidades.CodCliente, entidades.Pais, entidades.Departamento);

            if (i)
            {
                return dalobj.RegistrarSede(entidades);
            }
            else
                return false;
        }

        public bool ValidarPaisDepartamento(string codcliente, string pais, string departamento)
        {
            negocio balobj = new negocio();

            DataTable dtSedes = balobj.CargaDatosSedes(codcliente);

            foreach (DataRow row in dtSedes.Rows)
            {
                if (pais == row["Pais"].ToString())
                {
                    if (departamento == row["Departamento"].ToString())
                    {
                        return false;
                    }
                    else
                        return true;
                }
                else
                    return true;
            }
            return true;
        }
    }
}