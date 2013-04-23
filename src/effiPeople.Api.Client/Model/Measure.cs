﻿using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using effiPeople.Api.Client.Model.Common;
using effiPeople.Api.Client.Model.Extensions;

namespace effiPeople.Api.Client.Model
{
    /// <summary>
    ///     Medida de lectura y consumo.
    /// </summary>
    public class Measure
    {
        public Measure(string id, string usagePointId, MeasureType measureType, DateTime dateTime, byte period, long reading)
            : this(id, usagePointId, null, measureType, dateTime, period, reading)
        {

        }

        public Measure(string id, string usagePointId, string meterId, MeasureType measureType, DateTime dateTime, byte period, long reading)
        {
            Id = id;
            UsagePointId = usagePointId;
            MeterId = meterId;
            MeasureType = measureType;
            DateTime = dateTime;
            Period = period;
            Reading = reading;
        }

        public Measure(string id, string usagePointId, MeasureType measureType, DateTime startDate, DateTime endDate, byte period, long consumption)
            : this(id, usagePointId, null, measureType, startDate, endDate, period, consumption)
        {

        }

        public Measure(string id, string usagePointId, string meterId, MeasureType measureType, DateTime startDate, DateTime endDate, byte period, long consumption)
        {
            Id = id;
            UsagePointId = usagePointId;
            MeterId = meterId;
            MeasureType = measureType;
            DateTime = startDate;
            Duration = (long?)(endDate - startDate).TotalSeconds;
            Period = period;
            Consumption = consumption;
        }

        public Measure()
        {
            Period = 1;
        }

        /// <summary>
        /// Identificador único de la medida.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        ///     Identificador del punto de suministro. Opcional si se especifica un contador.
        /// </summary>
        public string UsagePointId { get; set; }

        /// <summary>
        ///     Identificador del contador. Opcional si se especifica el punto de suministro
        /// </summary>
        public string MeterId { get; set; }

        /// <summary>
        ///     Franja horaria entre 1 y 7
        /// </summary>
        public byte Period { get; set; }

        /// <summary>
        ///     Fecha de la medida en segundos desde el 1 de enero de 1970.
        /// </summary>
        [JsonProperty]
        protected long Date { get; set; }

        /// <summary>
        ///     Lectura del contador
        /// </summary>
        public long? Reading { get; set; }

        /// <summary>
        ///     Consumo desde la última lectura. Opcional.
        /// </summary>
        public long? Consumption { get; set; }

        /// <summary>
        ///     Número de segundos pasados desde la última medida.
        /// </summary>
        public long? Duration { get; set; }

        /// <summary>
        ///     Identificador de la tarifa aplicada. Opcional.
        /// </summary>
        public string TariffId { get; set; }

        /// <summary>
        ///     Coste del consumo desde la última factura. Opcional.
        /// </summary>
        public double? Cost { get; set; }

        /// <summary>
        ///     Tipo de medida. Si no se especifica se considerará activa.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public MeasureType MeasureType { get; set; }

        /// <summary>
        ///     Fecha de la lectura
        /// </summary>
        [JsonIgnore]
        public DateTime DateTime
        {
            get { return Date.ToDateTimeFromEpochInSeconds(); }
            set { Date = value.ToEpochTimeInSeconds(); }
        }

        /// <summary>
        ///  Origen de la medida (Telemedida, etc...)
        /// </summary>
        public string Source { get; set; }
    }
}