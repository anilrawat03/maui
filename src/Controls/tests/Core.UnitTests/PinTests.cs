using Microsoft.Maui.Controls.Maps;
using Xunit;

namespace Microsoft.Maui.Controls.Core.UnitTests
{

	public class PinTests : BaseTestFixture
	{
		[Fact]
		public void Constructor()
		{
			Pin pin = new Pin
			{
				Type = PinType.SavedPin,
				Position = new Position(-92, 178),
				Label = "My Desktop",
				Address = "123 Hello World Street"
			};

			Assert.Equal(PinType.SavedPin, pin.Type);
			Assert.Equal(pin.Position.Latitude, -90);
			Assert.Equal("My Desktop", pin.Label);
			Assert.Equal("123 Hello World Street", pin.Address);
		}

		[Fact]
		public void EqualsTest()
		{
			Pin pin1 = new Pin();
			Pin pin2 = new Pin();
			Pin pin3 = new Pin
			{
				Type = PinType.Place,
				Position = new Position(12, -24),
				Label = "Test",
				Address = "123 Test street"
			};

			Pin pin4 = new Pin
			{
				Type = PinType.Place,
				Position = new Position(12, -24),
				Label = "Test",
				Address = "123 Test street"
			};

			Assert.True(pin1.Equals(pin2));
			Assert.True(pin3.Equals(pin4));
			Assert.False(pin1.Equals(pin3));
		}

		[Fact]
		public void EqualsOp()
		{
			var pin1 = new Pin
			{
				Type = PinType.Place,
				Position = new Position(12, -24),
				Label = "Test",
				Address = "123 Test street"
			};

			var pin2 = new Pin
			{
				Type = PinType.Place,
				Position = new Position(12, -24),
				Label = "Test",
				Address = "123 Test street"
			};

			Assert.True(pin1 == pin2);
		}

		[Fact]
		public void InEqualsOp()
		{
			var pin1 = new Pin
			{
				Type = PinType.Place,
				Position = new Position(11.9, -24),
				Label = "Test",
				Address = "123 Test street"
			};

			var pin2 = new Pin
			{
				Type = PinType.Place,
				Position = new Position(12, -24),
				Label = "Test",
				Address = "123 Test street"
			};

			Assert.True(pin1 != pin2);
		}

		[Fact]
		public void Label()
		{
			var pin = new Pin
			{
				Label = "OriginalLabel"
			};

			bool signaled = false;
			pin.PropertyChanged += (sender, args) =>
			{
				if (args.PropertyName == "Label")
					signaled = true;
			};

			pin.Label = "Should Signal";

			Assert.True(signaled);
		}
	}
}
