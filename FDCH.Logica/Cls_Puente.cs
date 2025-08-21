using FDCH.Datos;
using FDCH.Entidades;
using System;
using System.Collections.Generic;

namespace FDCH.Logica
{
    public class Cls_Puente
    {
        DbService _dbService = new DbService();
        DriveService _driveService = new DriveService();
        //LockManager _lockManager = new LockManager();

        public Cls_Puente()
        {
            // Si se necesita lógica adicional en el constructor
        }

        // Usuario
        public Usuario AutenticarUsuario(string usuario, string contrasena)
        {
            return _dbService.AutenticarUsuario(usuario, contrasena);
        }

        public int InsertarUsuario(Usuario usuario)
        {
            return _dbService.InsertarUsuario(usuario);
        }

        public List<Usuario> ObtenerUsuarios()
        {
            return _dbService.ObtenerUsuarios();
        }

        // Deportista
        public int InsertarDeportista(Deportista deportista)
        {
            return _dbService.InsertarDeportista(deportista);
        }

        public List<Deportista> ObtenerDeportistas()
        {
            return _dbService.ObtenerDeportistas();
        }

        // Técnico
        public int InsertarTecnico(Tecnico tecnico)
        {
            return _dbService.InsertarTecnico(tecnico);
        }

        public List<Tecnico> ObtenerTecnicos()
        {
            return _dbService.ObtenerTecnicos();
        }

        // Evento
        public int InsertarEvento(Evento evento)
        {
            return _dbService.InsertarEvento(evento);
        }

        public List<Evento> ObtenerEventos()
        {
            return _dbService.ObtenerEventos();
        }

        // Disciplina
        public int InsertarDisciplina(Disciplina disciplina)
        {
            return _dbService.InsertarDisciplina(disciplina);
        }

        public List<Disciplina> ObtenerDisciplinas()
        {
            return _dbService.ObtenerDisciplinas();
        }

        // Especialidad
        public int InsertarEspecialidad(Especialidad especialidad)
        {
            return _dbService.InsertarEspecialidad(especialidad);
        }

        public List<Especialidad> ObtenerEspecialidades()
        {
            return _dbService.ObtenerEspecialidades();
        }

        // Competencia
        public int InsertarCompetencia(Competencia competencia)
        {
            return _dbService.InsertarCompetencia(competencia);
        }

        public List<Competencia> ObtenerCompetencias()
        {
            return _dbService.ObtenerCompetencias();
        }

        // Desempeño
        public int InsertarDesempeno(Desempeno desempeno)
        {
            return _dbService.InsertarDesempeno(desempeno);
        }

        public List<Desempeno> ObtenerDesempenos()
        {
            return _dbService.ObtenerDesempenos();
        }

        // Historial de Cambios
        public int InsertarHistorialCambio(HistorialCambio cambio)
        {
            return _dbService.InsertarHistorialCambio(cambio);
        }

        public List<HistorialCambio> ObtenerHistorialCambios()
        {
            return _dbService.ObtenerHistorialCambios();
        }


        public List<RegistroTotal> ObtenerRegistrosCompletos()
        {
            // Supongamos que tienes un método en DbService que trae los datos completos
            List<RegistroTotal> listaRegistros = _dbService.ObtenerRegistrosCompletosDB();

            // Recorremos la lista para calcular los campos extras
            foreach (var registro in listaRegistros)
            {
                // Usa la propiedad de fecha de inicio del evento para calcular el mes y el año
                registro.MesInicioEvento = registro.FechaInicio.ToString("MMMM"); // 'MMMM' para el nombre completo del mes
                registro.AnioInicioEvento = registro.FechaInicio.Year;
            }

            return listaRegistros;
        }


        //public bool AdquirirBloqueo(string usuario)
        //{
        //    // Intenta adquirir el bloqueo para el usuario
        //    return _lockManager.AdquirirBloqueo(usuario);
        //}

        // Métodos de sincronización (Drive)
        //public void LiberarBloqueo()
        //{
        //    // Libera el bloqueo actual
        //    _lockManager.LiberarBloqueo();
        //}

        public void SincronizarInicio()
        {
            // Descarga la base de datos y los archivos de log y lock del drive
            _driveService.DescargarArchivoDB();
            _driveService.DescargarLogYLock();
        }

        public void SubirCambios(string usuario)
        {
            // Sube la base de datos y los archivos de log y lock al drive
            _driveService.SubirArchivoDB(usuario);
            _driveService.SubirLogYLock(usuario);
        }
    }
}
