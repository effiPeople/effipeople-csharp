namespace effiPeople.Api.Client.Model
{
    /// <summary>
    ///     Contador
    /// </summary>
    public class Meter
    {
        /// <summary>
        /// Código único del contador
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// CUPS al que está asociado
        /// </summary>
        public string UsagePointId { get; set; }
        
    }
}