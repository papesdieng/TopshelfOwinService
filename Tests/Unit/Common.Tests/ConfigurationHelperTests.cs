using System;
using NFluent;
using Xunit;

namespace Common.Tests
{
    public class ConfigurationHelperTests
    {
	    [Fact]
	    public void Should_Get_IntValue()
	    {
		    var result = ConfigurationHelper.Get<int>("IntValue", 456);
		    Check.That(result).Equals(123);
	    }

	    [Fact]
	    public void Should_Get_DateValue()
	    {
			var expectedDate  = new DateTime(2020, 10, 5);
		    var result = ConfigurationHelper.Get<DateTime>("DateValue");
		    Check.That(result).Equals(expectedDate);
	    }

	    [Fact]
	    public void Should_Get_Default_Value()
	    {
		    var result = ConfigurationHelper.Get("UndefinedKey", 123);
		    Check.That(result).Equals(123);
	    }

	    [Fact]
	    public void Should_Throw_Exception_When_Undefined_Key_And_No_Default_Value_Set()
	    {
		    Check.ThatCode(() => ConfigurationHelper.Get<string>("UndefinedKey"))
			    .Throws<Exception>()
			    .WithMessage("Configuration Exception: unable to find key 'UndefinedKey'");
	    }
	}
}
