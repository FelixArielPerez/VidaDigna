using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticClass
{
    public static class Constants
    {

        public const string UsuarioProceso = "129CA9E1-FD71-4E63-996C-B0364DB3B984";
        public const string DatagridNoRecords = "No se encontraron registros.";
        public const int SinEspecificar = -1;

        public static class MessageNotifactionsDefault
        {
            public const string Title = "Aviso";

            public const string ErroresValidacion = "Hay errores de validacion, por favor verifique la informacion ingresada.";

            public const string AltaExitosa = "Alta exitosa";
            public const string ModificacionExitosa = "Modificación exitosa";
            public const string EliminacionExitosa = "Baja exitosa";
            public const string ActivacionExitosa = "Cambio de estado exitoso";

            public const string AltaFallida = "No se pudo dar de alta el registro. Verifique";
            public const string ModificacionFallida = "No se pudo modificar el registro. Verifique.";
            public const string EliminacionFallida = "No se pudo dar de baja el registro. Verifique.";
            public const string ActivacionFallida = "No se pudo realizar el cambio de estado. Verifique";
            public const string EliminacionPorFallida_ProductosVinculados = "No se pudo dar de Baja por tener Productos Activos vinculados";

            public const string ConfirmacionOperacion = "¿Desea confirmar la operación?";
            public const string ConfirmacionCancelOperacion = "¿Desea confirmar la operación?";
            public const string ConfirmacionBtnOk = "Aceptar";
            public const string ConfirmacionBtnCancel = "Cancelar";

            public const string SinModificacion = "La operación no se ejecutará porque no hay modificaciones";
            public const string ErrorWithDetails = "Se produjo el siguiente error: {0}";
        }

        public struct NotifDuration
        {
            public const int Fast = 3_000;
            public const int Normal = 6_000;
            public const int Slow = 9_000;
            public const int VerySlow = 12_000;
            public const int Endless = 300_000;
        }
        public enum EmailsEstados
        {
            Pendiente = 1,
            Enviado = 2,
            NoEnviado = 3,
            Cancelado = 4,
        }

        public enum EmailsTipo
        {
            Generico = 1,
            CreacionDeUsuario = 2,
            RecuperoContrasena = 3,
        }

        public enum EstadosABMS
        {
            ACTIVO = 18,
            BAJA = 25,
            INACTIVO = 24
        }

        public enum EstadosPROVCLI
        {
            INHABILITADO = 1,
            HABILITADO = 2,
            INACTIVO = 3
        }

        public class TipoEstado
        {
            public static string ABMS = "ABMS";
            public static string PROVCLI = "PROVCLI";
            public static string PRODUCTOS = "PRODUCTOS";
        }

        public enum EstadosPRODUCTOS
        {
            ALTADEPOSITO = 26,
            PENDIENTEPRECIO = 27,
            ENAPROBACION = 28,
            ACTIVO = 29,
            INACTIVO = 30,
            CANCELADO = 31
        }

        public enum TipoProducto
        {
            MEDICAMENTOS = 1,
            ACCESORIOS = 2,
            VARIOS = 3,
            PERFUMERIA = 4
        }

        // Estados de Lista de precios
        public enum EstadosListaPrecios
        {
            ACTIVA = 1026,
            APLICADA = 1027,
            INACTIVA = 1028
        }

        public enum TipoOperacion
        {
            Detalle = 0,
            Creacion = 1,
            Edicion = 2,
            Eliminacion = 3
        }
        public enum TiposDeCliente
        {
            Drogueria = 1,
            EstablecimientoAsistencial = 2,
            Farmacia = 3,
            EstablecimientoEstatal = 4
        }
        public enum PuntosDeVentaCategorias
        {
            A = 1,
            B = 2,
            SinCategorizar = 3
        }

        public enum RepartosAlternativosDiasDeLaSemana
        {
            LunesAViernes = 1,
            Sabados = 2
        }

        public enum FormasEnvio
        {
            CADETERIA = 1,
            ENCOMIENDA = 2,
            MOSTRADOR = 3,
            REPARTO = 4
        }

        public enum CuentasCorrientes
        {
            Nueva = 1,
            Existente = 2
        }
        public enum CuentasResumen
        {
            NoPosee = 1,
            Nueva = 2,
            Existente
        }
        public enum TiposDeArchivo
        {
            dat = 1,
            txt = 2,
            xlsx = 3
        }

        public enum AccionTerapeuticaCodigo
        {
            SIN_TROQUEL = 571
        }

        public enum ProductosOrigenesPrecios
        {
            Lista_Oficial = 1,
            Alfabeta = 2
        }

        public enum IdLaboratorios
        {
            Alfabeta = 2178
        }

        public static class Parametros
        {
            public const string PrecioSalidaLaboratorio = "PrecioSalidaLaboratorio";
            public const string TasaIVA = "TasaIVA";
            
        }
        public enum VentasEspecialesTipos
        {
            Lista = 1,
            Combo = 2,
        }
        public enum VentasEspecialesTiposDeDescuento
        {
            Habitual_Mas_Descuento = 1,
            Sin_Descuento = 2,
        }
        public enum VentasEspecialesTiposDeUnidades
        {
            Fija = 1,
            Minima = 2,
            Multiplo = 3
        }
        public enum VentasEspecialesTiposDeRenglones
        {
            Fija = 1,
            Minima = 2,
            Multiplo = 3
        }
        public enum VentasEspecialesTiposDePrecios
        {
            Habitual = 1,
            Fijo = 2,
            Descuento_sPSL = 3,
            Descuento_sPP = 4,
            Descuento_sPF = 5
        }

        public enum TurnoOrdenEntrega
        {
            Mañana = 1,
            Tarde = 2
        }

        public enum eEstadosCategoriasComerciales
        {
            ACTIVO = 18,
            INACTIVO = 24,
            BAJA = 25
        }
    }
}
