using System;
using System.Configuration;

namespace Common
{
    public class ConfigurationHelper
    {
	    public static T Get<T>(string keyName, T defaultValue)
	    {
		    var stringValue = ConfigurationManager.AppSettings[keyName];
		    if (string.IsNullOrWhiteSpace(stringValue))
		    {
			    return defaultValue;
		    }
		    return (T) Convert.ChangeType(stringValue, typeof(T));
	    }

	    public static T Get<T>(string keyName)
	    {
		    var stringValue = ConfigurationManager.AppSettings[keyName];
		    if (string.IsNullOrWhiteSpace(stringValue))
		    {
			    throw new Exception($"Configuration Exception: unable to find key '{keyName}'");
		    }
		    return (T)Convert.ChangeType(stringValue, typeof(T));
	    }
	}
}
