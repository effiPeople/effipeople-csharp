using System;

namespace effiPeople.Api.Client.Model.Extensions
{
    /// <summary>
    /// Extensiones oara la gestión de fechas
    /// </summary>
    public static class DateTimeExtensions
    {
        public static DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        /// <summary>
        /// Convierte una fecha a segundos desde el 1 de enero de 1970
        /// </summary>
        /// <param name="dateTime">Fecha</param>
        /// <returns></returns>
        public static long AsEpochTimeInSeconds(this DateTime dateTime)
        {
            var diff = dateTime - Epoch;

            return (long)diff.TotalSeconds;
        }

        /// <summary>
        /// Convierte una fecha a segundos desde el 1 de enero de 1970
        /// </summary>
        /// <param name="dateTime">Fecha</param>
        /// <returns></returns>
        public static long? AsEpochTimeInSeconds(this DateTime? dateTime)
        {
            return dateTime == null ? (long?)null : dateTime.Value.AsEpochTimeInSeconds();
        }

        /// <summary>
        /// Convierte los segundos desde el 1 de enero de 1970 a una fecha
        /// </summary>
        /// <param name="epochTimeInSeconds">Fecha</param>
        /// <returns></returns>
        public static DateTime AsDateTimeFromEpochInSeconds(this long epochTimeInSeconds)
        {
            if (epochTimeInSeconds == 0)
                return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            return Epoch.AddSeconds(epochTimeInSeconds);
        }

     
    }
}