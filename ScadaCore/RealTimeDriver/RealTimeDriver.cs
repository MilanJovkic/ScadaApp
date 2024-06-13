using System.Collections.Generic;

namespace RealTimeDriver
{
    public static class RealTimeDriver
    {
        // Simulated data store
        private static readonly Dictionary<string, double> _dataStore = new Dictionary<string, double>();

        public static void WriteValue(string address, double value)
        {
            // Simulate writing a value to a given address
            _dataStore[address] = value;
        }

        public static double ReadValue(string address)
        {
            // Simulate reading a value from a given address
            if (_dataStore.TryGetValue(address, out double value))   
            {
                return value;
            }
            else
            {
                // Consider how to handle the case where the address does not exist.
                // For now, returning 0 or throwing an exception could be options.
                return double.NaN; // Placeholder for non-existent address
            }
        }
    }
}