using Xunit;
using AspNetCoreWebService.Controllers;

namespace AspNetCoreWebServiceTest.Controllers
{
    public class HelloControllerTest
    {
        [Fact]
        public void NoInputParamGetResponseTest()
        {
            HelloController controller = new HelloController();
            var response = controller.Get().Value as Response;
            Assert.Equal("Hello World!", response.output);
        }

        [Theory]
        [InlineData(null, "Hello !")]
        [InlineData("", "Hello !")]
        [InlineData("AWS CodeStar", "Hello AWS CodeStar!")]
        public void InputParamGetResponseTest(string inputValue, string expectedOutput)
        {
            HelloController controller = new HelloController();
            var response = controller.Get(inputValue).Value as Response;
            Assert.Equal(expectedOutput, response.output);
        }

        [Fact]
        public void NoInputParamPostResponseTest()
        {
            HelloController controller = new HelloController();
            var response = controller.Post().Value as Response;
            Assert.Equal("Hello World!", response.output);
        }

        [Theory]
        [InlineData(null, "Hello !")]
        [InlineData("", "Hello !")]
        [InlineData("AWS CodeStar", "Hello AWS CodeStar!")]
        public void InputParamPostResponseTest(string inputValue, string expectedOutput)
        {
            HelloController controller = new HelloController();
            var response = controller.Post(inputValue).Value as Response;
            Assert.Equal(expectedOutput, response.output);
        }
    }
}
