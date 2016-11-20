namespace Web.UnitTests.Controllers
{
	using Xunit;
	using GroupClue.Controllers;

	public class Index
    {
        private readonly HomeController _controller;
         public Index()
         {
             _controller = new HomeController();
         }

        [Fact]
        public void ReturnsOk()
        {
            var result = _controller.Index();

            Assert.NotNull(result);
        }
    }
}