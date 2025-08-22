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

        public bool InsertarRegistroComplejo(Deportista deportista, Tecnico tecnico, string nombreDisciplina, Especialidad especialidad, Competencia competencia, Desempeno desempeno)
        {
            try
            {
                // 1. Insertar Deportista y Tecnico (si no existen)
                int idDeportista = _dbService.InsertarDeportista(deportista);
                int idTecnico = _dbService.InsertarTecnico(tecnico);

                // 2. Lógica para Disciplina y Especialidad
                int idDisciplina = _dbService.ObtenerIdDisciplinaPorNombre(nombreDisciplina);
                if (idDisciplina == 0) // La disciplina no existe, es nueva
                {
                    // Insertar la nueva disciplina
                    Disciplina nuevaDisciplina = new Disciplina { nombre_disciplina = nombreDisciplina };
                    idDisciplina = _dbService.InsertarDisciplina(nuevaDisciplina);

                    // Insertar la nueva especialidad asociada a la nueva disciplina
                    especialidad.id_disciplina = idDisciplina;
                    int idEspecialidad = _dbService.InsertarEspecialidad(especialidad);
                    competencia.id_especialidad = idEspecialidad;
                }
                else // La disciplina ya existe
                {
                    // Verificar si la especialidad ya existe para esta disciplina
                    int idEspecialidad = _dbService.ObtenerIdEspecialidadPorNombre(especialidad.nombre_especialidad, idDisciplina);
                    if (idEspecialidad == 0) // La especialidad es nueva para esta disciplina
                    {
                        // Insertar la nueva especialidad asociada a la disciplina existente
                        especialidad.id_disciplina = idDisciplina;
                        idEspecialidad = _dbService.InsertarEspecialidad(especialidad);
                    }
                    competencia.id_especialidad = idEspecialidad;
                }

                // 3. Insertar Competencia
                int idCompetencia = _dbService.InsertarCompetencia(competencia);

                // 4. Insertar Desempeño
                desempeno.id_deportista = idDeportista;
                desempeno.id_competencia = idCompetencia;
                desempeno.id_tecnico = idTecnico;
                _dbService.InsertarDesempeno(desempeno);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        

    }
}
