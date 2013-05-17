namespace effiPeople.Api.Client.Model
{
    public class PeriodPrices
    {
        public PeriodPrices()
        {
        }

        public PeriodPrices(double activeEnergyPrice, double powerPrice)
        {
            ActiveEnergyPrice = activeEnergyPrice;
            PowerPrice = powerPrice;
        }

        public double ActiveEnergyPrice { get; set; }

        public double? PowerPrice { get; set; }

        public override bool Equals(object obj)
        {
            //       
            // See the full list of guidelines at
            //   http://go.microsoft.com/fwlink/?LinkID=85237  
            // and also the guidance for operator== at
            //   http://go.microsoft.com/fwlink/?LinkId=85238
            //

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return obj.GetHashCode() == this.GetHashCode();
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ActiveEnergyPrice.GetHashCode() ^ PowerPrice.GetHashCode();
            }
        }
    }
}
