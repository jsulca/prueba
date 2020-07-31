using Prueba.Entidades;
using Prueba.Contextos;
using Prueba.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.Logicas
{
    public class CursoLogica
    {
        private PruebaContexto _contexto;
        private CursoRepositorio _repositorio;

        public Curso BuscarPorId(int id)
        {
            using (_contexto = new PruebaContexto())
            {
                try
                {
                    _repositorio = new CursoRepositorio(_contexto.Connection);
                    return _repositorio.BuscarPorId(id);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public List<Curso> Listar()
        {
            using (_contexto = new PruebaContexto())
            {
                try
                {
                    _repositorio = new CursoRepositorio(_contexto.Connection);
                    return _repositorio.Listar();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public bool Guardar(Curso entidad)
        {
            using (_contexto = new PruebaContexto(true))
            {
                try
                {
                    _repositorio = new CursoRepositorio(_contexto.Connection, _contexto.Transaction);
                    bool respuesta = _repositorio.Guardar(entidad);
                    _contexto.Transaction.Commit();
                    return respuesta;
                }
                catch (Exception ex)
                {
                    _contexto?.Transaction.Rollback();
                    throw ex;
                }
            }
        }

        public bool Actualizar(Curso entidad)
        {
            using (_contexto = new PruebaContexto(true))
            {
                try
                {
                    _repositorio = new CursoRepositorio(_contexto.Connection, _contexto.Transaction);
                    bool respuesta = _repositorio.Actualizar(entidad);
                    _contexto.Transaction.Commit();
                    return respuesta;
                }
                catch (Exception ex)
                {
                    _contexto?.Transaction.Rollback();
                    throw ex;
                }
            }
        }

        public bool Eliminar(int id)
        {
            using (_contexto = new PruebaContexto(true))
            {
                try
                {
                    _repositorio = new CursoRepositorio(_contexto.Connection, _contexto.Transaction);
                    bool respuesta = _repositorio.Eliminar(id);
                    _contexto.Transaction.Commit();
                    return respuesta;
                }
                catch (Exception ex)
                {
                    _contexto?.Transaction.Rollback();
                    throw ex;
                }
            }
        }
    }
}
