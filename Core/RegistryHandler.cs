using Microsoft.Win32;
using System;

namespace StockWatcher.Core
{
    public class RegistryHandler
    {
        public void EnsureValueExists(RootKey rootKey, string keys, string valueName, string value)
        {
            var key = EnsureKeyExists(rootKey, keys);
            var existingValue = key.GetValue(valueName);
            if (existingValue == null || !existingValue.Equals(value))
            {
                key.SetValue(valueName, value);
            }
        }

        public RegistryKey EnsureKeyExists(RootKey rootKey, string keys, string defaultValue = null)
        {
            var currentKey = GetRootKey(rootKey);

            foreach (var key in keys.Split('/'))
            {
                currentKey = currentKey.OpenSubKey(key, RegistryKeyPermissionCheck.ReadWriteSubTree)
                             ?? currentKey.CreateSubKey(key, RegistryKeyPermissionCheck.ReadWriteSubTree);

                if (currentKey == null)
                {
                    throw new Exception("Could not get or create key");
                }
            }

            if (defaultValue != null)
            {
                currentKey.SetValue(string.Empty, defaultValue);
            }

            return currentKey;

        }

        private RegistryKey GetRootKey(RootKey keyEnum)
        {
            switch (keyEnum)
            {
                case RootKey.ClassesRoot:
                    return Registry.ClassesRoot;
                case RootKey.CurrentConfig:
                    return Registry.CurrentConfig;
                case RootKey.CurrentUser:
                    return Registry.CurrentUser;
                case RootKey.LocalMachine:
                    return Registry.LocalMachine;
                case RootKey.PerformanceData:
                    return Registry.PerformanceData;
                case RootKey.Users:
                    return Registry.Users;
                default:
                    throw new Exception("Invalid Root Key");
            }
        }
    }

    public enum RootKey
    {
        ClassesRoot,
        CurrentUser,
        LocalMachine,
        Users,
        CurrentConfig,
        PerformanceData
    }
}
