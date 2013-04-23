using System;
using Newtonsoft.Json;
using effiPeople.Api.Client.Model.Extensions;

namespace effiPeople.Api.Client.Model
{
    /// <summary>
    ///     Historial de cambios de un contrato
    /// </summary>
    public class ContractChange
    {
        /// <summary>
        ///     Identificador del contrato
        /// </summary>
        public string ContractId { get; set; }

        [JsonProperty]
        protected long Start { get; set; }

        /// <summary>
        ///     Fecha de inicio de esta versión del contrato
        /// </summary>
        [JsonIgnore]
        public DateTime StartDate
        {
            get { return Start.ToDateTimeFromEpochInSeconds(); }
            set { Start = value.ToEpochTimeInSeconds(); }
        }

        [JsonProperty]
        protected long? End { get; set; }


        /// <summary>
        ///     Fecha final (si existe) de esta versión del contrato
        /// </summary>
        public DateTime? EndDate
        {
            get { return End.ToDateTimeFromEpochInSeconds(); }
            set { End = value.ToEpochTimeInSeconds(); }
        }

        /// <summary>
        ///     Identificador de la tarifa que se le aplica
        /// </summary>
        public string TariffId { get; set; }

        /// <summary>
        ///     Kilowatios contratados
        /// </summary>
        public double Power { get; set; }

        /// <summary>
        ///   Versión del contrato
        /// </summary>
        public string Version { get; set; }
    }

    

}