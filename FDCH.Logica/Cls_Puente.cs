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

        public Deportista ObtenerDeportistaPorId(int id)
        {
            return _dbService.ObtieneDeportista(id);
        }

        public Evento ObtenerEventoPorId(int id)
        {
            return _dbService.ObtieneTorneo(id);
        }


        public List<Deportista> ObtenerTodosDeportistas()
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

        public List<Especialidad> ObtenerTodasEspecialidades()
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
            List<RegistroTotal> listaRegistros = _dbService.ObtenerRegistrosCompletosDB();

            // Recorremos la lista para calcular los campos extras
            foreach (var registro in listaRegistros)
            {
                // Variable para almacenar la fecha parseada
                DateTime fechaInicio;

                // Intenta convertir el string a DateTime de forma segura
                // El formato "dd/MM/yyyy" es crucial para que la conversión funcione
                if (DateTime.TryParseExact(registro.FechaInicio, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out fechaInicio))
                {
                    // Si la conversión es exitosa, ahora puedes usar el objeto DateTime
                    registro.MesInicioEvento = fechaInicio.ToString("MMMM");
                    registro.AnioInicioEvento = fechaInicio.Year.ToString();
                }
                else
                {
                    // Manejar el caso de que el formato de fecha sea inválido
                    // Asignar un valor por defecto o mostrar un error
                    registro.MesInicioEvento = "Desconocido";
                    registro.AnioInicioEvento = "Desconocido";
                }
            }
            return listaRegistros;
        }

        public List<RegistroTotal> ObtenerRegistrosCompletosIdDeportista(int idDeportista)
        {
            List<RegistroTotal> listaRegistros = _dbService.ObtenerRegistrosCompletosDBPersonal(idDeportista);

            // Recorremos la lista para calcular los campos extras
            foreach (var registro in listaRegistros)
            {
                // Variable para almacenar la fecha parseada
                DateTime fechaInicio;

                // Intenta convertir el string a DateTime de forma segura
                // El formato "dd/MM/yyyy" es crucial para que la conversión funcione
                if (DateTime.TryParseExact(registro.FechaInicio, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out fechaInicio))
                {
                    // Si la conversión es exitosa, ahora puedes usar el objeto DateTime
                    registro.MesInicioEvento = fechaInicio.ToString("MMMM");
                    registro.AnioInicioEvento = fechaInicio.Year.ToString();
                }
                else
                {
                    // Manejar el caso de que el formato de fecha sea inválido
                    // Asignar un valor por defecto o mostrar un error
                    registro.MesInicioEvento = "Desconocido";
                    registro.AnioInicioEvento = "Desconocido";
                }
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

        public bool InsertarRegistroDeportistaCompleto(
            Deportista deportista,
            Tecnico tecnico,
            Disciplina disciplina,
            Especialidad especialidad,
            Competencia competencia,
            Desempeno desempeno)
        {
            return _dbService.InsertarRegistroDeportistaCompleto(
                deportista, tecnico, disciplina, especialidad, competencia, desempeno);
        }

        // Método para obtener todas las disciplinas
        public List<Disciplina> ObtenerTodasDisciplinas()
        {
            return _dbService.ObtenerDisciplinas();
        }

        // Método para obtener especialidades por disciplina
        public List<Especialidad> ObtenerEspecialidadesPorDisciplina(int idDisciplina)
        {
            return _dbService.ObtenerEspecialidadesPorDisciplina(idDisciplina);
        }

        public Especialidad ObtenerEspecialidadPorId(int idEspecialidad)
        {
            // Este método actúa como puente, llamando al servicio de la base de datos para obtener una especialidad por su ID.
            return _dbService.ObtenerEspecialidadPorId(idEspecialidad);
        }

        

        public bool ActualizarDeportista(Deportista deportista)
        {
            return _dbService.ActualizarDeportista(deportista);
        }

        

        public List<Deportista> ObtenerDeportistasPorFiltro(string filtro, string campo)
        {
            // Llama a la capa de datos para obtener deportistas filtrados
            return _dbService.ObtenerDeportistasPorFiltro(filtro, campo);
        }


        public List<string> ObtenerCedulas()
        {
            return _dbService.ObtenerCedulas();
        }

        public List<string> ObtenerApellidosUnicos()
        {
            return _dbService.ObtenerApellidosUnicos();
        }

        public List<string> ObtenerNombresPorApellido(string apellido)
        {
            return _dbService.ObtenerNombresPorApellido(apellido);
        }
        public Deportista BuscarDeportistaPorCedula(string cedula)
        {
            return _dbService.BuscarDeportistaPorCedula(cedula);
        }

        public Deportista BuscarDeportistaPorNombreCompleto(string nombres, string apellidos)
        {
            return _dbService.BuscarDeportistaPorNombreCompleto(nombres, apellidos);
        }


        public int ObtenerIdDisciplinaPorNombre(string nombreDisciplina)
        {
            return _dbService.ObtenerIdDisciplinaPorNombre(nombreDisciplina);
        }

        public int ObtenerIdEspecialidadPorNombre(string nombreEspecialidad, int disciplinaId)
        {
            return _dbService.ObtenerIdEspecialidadPorNombre(nombreEspecialidad, disciplinaId);
        }

        public int ObtenerIdTecnicoPorNombre(string nombreTecnico)
        {
            return _dbService.ObtenerIdTecnicoPorNombre(nombreTecnico);
        }


        public List<RegistroTotal> BuscarParticipacionesDeportista(string clausula, List<System.Data.SQLite.SQLiteParameter> parametros)
        {
            return _dbService.BuscarRegistrosDeportista(clausula, parametros);
        }

        public List<RegistroTotal> BuscarParticipacionesDeportistaFiltrado(string clausula, List<System.Data.SQLite.SQLiteParameter> parametros, string clausulaOrder)
        {
            return _dbService.BuscarRegistrosDeportistaFiltrado(clausula, parametros, clausulaOrder);
        }

    }
}
