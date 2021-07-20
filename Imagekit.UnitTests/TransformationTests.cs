using Imagekit;
using Xunit;

namespace Imagekit.UnitTests
{
    public class TransformationTests
    {
        [Theory]
        [InlineData(30, "30")]
        [InlineData(-30, "N30")]
        public void X_WhenCalled_AddsCorrectValue(int input, string expected)
        {
            var t = new Transformation();

            t.X(input);
            
            Assert.Equal(expected, t.Params["x"]);
        }
        
        [Theory]
        [InlineData(30, "30")]
        [InlineData(-30, "N30")]
        public void Y_WhenCalled_AddsCorrectValue(int input, string expected)
        {
            var t = new Transformation();

            t.Y(input);
            
            Assert.Equal(expected, t.Params["y"]);
        }
        
        [Theory]
        [InlineData(30, "30")]
        [InlineData(-30, "N30")]
        public void OverlayX_WhenCalled_AddsCorrectValue(int input, string expected)
        {
            var t = new Transformation();

            t.OverlayX(input);
            
            Assert.Equal(expected, t.Params["ox"]);
        }
        
        [Theory]
        [InlineData(30, "30")]
        [InlineData(-30, "N30")]
        public void OverlayY_WhenCalled_AddsCorrectValue(int input, string expected)
        {
            var t = new Transformation();
            
            t.OverlayY(input);
            
            Assert.Equal(expected, t.Params["oy"]);
        }
    }
}