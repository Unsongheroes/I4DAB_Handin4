using System;

namespace ProsumerInfo.Models
{
    public class SmartMeter
    {
        private int _generatedPower;
        private int _usedPower;

        public int ProsumerId { get; set; }
        public Prosumer Prosumer { get; set; }
        
        public int Id { get; set; }
        public int GeneratedPower => _generatedPower;
        public int UsedPower => _usedPower;

        public SmartMeter(int generatedPower, int usedPower)
        {
            _generatedPower = generatedPower >= 0 ? generatedPower : throw new ArgumentOutOfRangeException(nameof(generatedPower));
            _usedPower = usedPower >= 0 ? usedPower : throw new ArgumentOutOfRangeException(nameof(usedPower));
        }

        public void AddGenerated(int amount)
        {
            if(amount < 0) throw new ArgumentOutOfRangeException(nameof(amount)); // Has to be positive
            _generatedPower += amount;
        }

        public void AddConsumption(int amount)
        {
            if (amount < 0) throw new ArgumentOutOfRangeException(nameof(amount)); // Has to be positive
            _usedPower += amount;
        }

        private SmartMeter()
        { }

    }
}