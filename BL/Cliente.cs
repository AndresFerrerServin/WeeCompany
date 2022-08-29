using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Cliente
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.WeeCompanyEntities context = new DL.WeeCompanyEntities())
                {
                    var query = context.ClienteGetAll().ToList();
                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var obj in query)
                        {
                            ML.Cliente cliente = new ML.Cliente();

                            cliente.IdCliente = obj.IdCliente;
                            cliente.Nombre = obj.Nombre;
                            cliente.ApellidoPaterno = obj.ApellidoPaterno;
                            cliente.ApellidoMaterno = obj.ApellidoMaterno;
                            cliente.EstadoCivil = obj.EstadoCivil;
                            cliente.Género = obj.Género;
                            cliente.FechaDeNacimiento = obj.FechaDeNacimiento.ToString();
                            cliente.CURP = obj.CURP;
                            cliente.RFC = obj.RFC;
                            cliente.Telefono = obj.Telefono;
                            cliente.Email = obj.Email;

                            result.Objects.Add(cliente);
                        
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontro el registro";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;

            }
            return result;
        } 

        public static ML.Result Add(ML.Cliente cliente)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.WeeCompanyEntities context = new DL.WeeCompanyEntities())
                {
                    var query = context.ClienteAdd(cliente.Nombre, cliente.ApellidoPaterno, cliente.ApellidoMaterno, cliente.EstadoCivil, cliente.Género, cliente.FechaDeNacimiento, cliente.CURP, cliente.RFC, cliente.Telefono, cliente.Email);

                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct=false;
                        result.ErrorMessage = "No se inserto el registro";
                    }
                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public static ML.Result Update(ML.Cliente cliente)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.WeeCompanyEntities context = new DL.WeeCompanyEntities())
                {
                    var query = context.ClienteUpdate(cliente.IdCliente,cliente.Nombre, cliente.ApellidoPaterno, cliente.ApellidoMaterno, cliente.EstadoCivil, cliente.Género, cliente.FechaDeNacimiento, cliente.CURP, cliente.RFC, cliente.Telefono, cliente.Email);


                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se actualizo";
                    }
                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public static ML.Result Delete(ML.Cliente cliente)
        {

            ML.Result result = new ML.Result();
            try
            {
                using (DL.WeeCompanyEntities context = new DL.WeeCompanyEntities())
                {
                    var query = context.ClienteDelete(cliente.IdCliente);
                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se elimino";
                    }
                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public static ML.Result GetById(int IdCliente)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.WeeCompanyEntities context = new DL.WeeCompanyEntities())
                {
                    var query = context.ClienteGetById(IdCliente).FirstOrDefault();
                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        ML.Cliente cliente = new ML.Cliente();

                        cliente.IdCliente = query.IdCliente;
                        cliente.Nombre = query.Nombre;
                        cliente.ApellidoPaterno = query.ApellidoPaterno;
                        cliente.ApellidoMaterno = query.ApellidoMaterno;
                        cliente.EstadoCivil = query.EstadoCivil;
                        cliente.Género = query.Género;
                        cliente.FechaDeNacimiento = query.FechaDeNacimiento.ToString();
                        cliente.CURP = query.CURP;
                        cliente.RFC = query.RFC;
                        cliente.Telefono = query.Telefono;
                        cliente.Email = query.Email;

                        result.Object = cliente;
                        result.Correct = true;

                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontro el registro";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;

            }
            return result;
        }
    }
}
