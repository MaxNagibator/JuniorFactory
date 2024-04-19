using Moq;
using NUnit.Framework;

namespace JuniorFactory.Lesson5.NunitTests
{
    public class UserManagerTests
    {
        [Test()]
        public void RegistrationTest()
        {
            var senderMock = new Mock<ISender>();
            senderMock.Setup(x => x.SendMail(It.IsAny<string>(), It.IsAny<string>())).Returns(3);
            var manager = new UserManager(senderMock.Object);
            var result = manager.Registration("email@email");
            Assert.That(result, Is.EqualTo(true));
            senderMock.Verify(v => v.SendMail(It.IsAny<string>(), It.IsAny<string>()));
        }
    }
}