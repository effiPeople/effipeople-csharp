using System;

namespace effiPeople.Api.Client.Model.Extensions
{
    /// <summary>
    /// Extensiones oara la gesti�n de fechas
    /// </summary>
    public static class DateTimeExtensions
    {
        public static DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0);

        /// <summary>
        /// Convierte una fecha a segundos desde el 1 de enero de 1970
        /// </summary>
        /// <param name="dateTime">Fecha</param>
        /// <returns></returns>
        public static long ToEpochTimeInSeconds(this DateTime dateTime)
        {
            var diff = dateTime - Epoch;

            return (long)diff.TotalSeconds;
        }

        /// <summary>
        /// Convierte una fecha a segundos desde el 1 de enero de 1970
        /// </summary>
        /// <param name="dateTime">Fecha</param>
        /// <returns></returns>
        public static long? ToEpochTimeInSeconds(this DateTime? dateTime)
        {
            return dateTime == null ? (long?)null : dateTime.Value.ToEpochTimeInSeconds();
        }

        /// <summary>
        /// Convierte los segundos desde el 1 de enero de 1970 a una fecha
        /// </summary>
        /// <param name="epochTimeInSeconds">Fecha</param>
        /// <returns></returns>
        public static DateTime ToDateTimeFromEpochInSeconds(this long epochTimeInSeconds, DateTimeKind dateTimeKind = DateTimeKind.Unspecified)
        {
            if (epochTimeInSeconds == 0)
                return new DateTime(1970, 1, 1, 0, 0, 0);

            var date = Epoch.AddSeconds(epochTimeInSeconds);

            if (dateTimeKind == DateTimeKind.Utc)
                return new DateTime(date.Ticks, dateTimeKind);

            return new DateTime(date.ToLocalTime().Ticks, dateTimeKind);
        }

        /// <summary>
        /// Convierte los segundos desde el 1 de enero de 1970 a una fecha
        /// </summary>
        /// <param name="epochTimeInSeconds">Fecha</param>
        /// <returns></returns>
        public static DateTime? ToDateTimeFromEpochInSeconds(this long? epochTimeInSeconds)
        {
            if (epochTimeInSeconds == null)
                return null;

            return epochTimeInSeconds.Value.ToDateTimeFromEpochInSeconds();
        }
    }
}