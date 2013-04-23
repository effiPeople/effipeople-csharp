using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace effiPeople.Api.Client.Model.Common
{
    /// <summary>
    /// Tipo de energía
    /// </summary>
    public enum MeasureType
    {
        /// <summary>
        /// Energía activa
        /// </summary>
        [EnumMember(Value = "Active")]
        Active = 'A', 

        /// <summary>
        /// Energía reactiva
        /// </summary>
        [EnumMember(Value = "Reactive")]
        Reactive = 'R',

        /// <summary>
        /// Potencia
        /// </summary>
        [EnumMember(Value = "Power")]
        Power = 'P'
    }
}