namespace UserVoiceSystem.Services.Web.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class EmailHiderServiceTests
    {
        [Test]
        public void NormalEmailShouldBeHidden()
        {
            string email = "aaaaa@aaaaa.aaa";
            IEMailHiderService provider = new EmailHiderService();
            var encoded = provider.HideEmail(email);
            var actual = "aaa**@aaa**.aaa";
            Assert.AreEqual(encoded, actual);
        }

        [Test]
        public void ShortEmailShouldNotBeHidden()
        {
            string email = "aaa@aaa.aaa";
            IEMailHiderService provider = new EmailHiderService();
            var encoded = provider.HideEmail(email);
            var actual = "aaa@aaa.aaa";
            Assert.AreEqual(encoded, actual);
        }

        [Test]
        public void ShortStartEmailShouldBeHiddenOnlyOnlyAtTheEnd()
        {
            string email = "aaa@aaaaa.aaa";
            IEMailHiderService provider = new EmailHiderService();
            var encoded = provider.HideEmail(email);
            var actual = "aaa@aaa**.aaa";
            Assert.AreEqual(encoded, actual);
        }

        [Test]
        public void ShortEndEmailShouldBeHiddenOnlyOnlyAtTheStart()
        {
            string email = "aaaaa@aaaaa.aaa";
            IEMailHiderService provider = new EmailHiderService();
            var encoded = provider.HideEmail(email);
            var actual = "aaa**@aaa**.aaa";
            Assert.AreEqual(encoded, actual);
        }
    }
}
