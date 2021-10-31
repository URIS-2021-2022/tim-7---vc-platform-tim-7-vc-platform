using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Moq;
using VirtoCommerce.Platform.Core;
//using VirtoCommerce.Platform.Core.Assets;
using VirtoCommerce.Platform.Core.Common;
using VirtoCommerce.Platform.Web.Licensing;
using Xunit;

namespace VirtoCommerce.Platform.Tests.Licenseing
{
    public class LicenseProviderTests
    {
        //private readonly Mock<IOptions<PlatformOptions>> _options = new Mock<IOptions<PlatformOptions>>();
        //private readonly Mock<IBlobStorageProvider> _blobStorageProvider = new Mock<IBlobStorageProvider>();
        //private readonly Mock<IBlobUrlResolver> _blobUrlResolver = new Mock<IBlobUrlResolver>();
        //private readonly PlatformOptions platformOptions = new PlatformOptions();
        //private readonly LicenseProvider _licenseProvider;

        //public LicenseProviderTests()
        //{
        //    _options.SetupGet(x => x.Value).Returns(platformOptions);
        //    _licenseProvider = new LicenseProvider(_options.Object, _blobStorageProvider.Object, _blobUrlResolver.Object);
        //}

        //[Fact]
        //public async Task GetLicenseAsync_LicenceFound_ReadMethodCalled()
        //{
        //    // Arrange
        //    _blobStorageProvider.Setup(x => x.GetBlobInfoAsync(It.IsAny<string>())).ReturnsAsync(new BlobInfo());
        //    _blobStorageProvider.Setup(x => x.OpenRead(It.IsAny<string>())).Returns(new MockStream());

        //    // Act
        //    _ = await _licenseProvider.GetLicenseAsync();

        //    // Assert
        //    _blobUrlResolver.Verify(x => x.GetAbsoluteUrl(It.Is<string>(s => s.EqualsInvariant(platformOptions.LicenseBlobPath))), Times.Once);
        //    _blobStorageProvider.Verify(x => x.OpenRead(It.IsAny<string>()), Times.Once);
        //}

        //[Fact]
        //public async Task GetLicenseAsync_LicenceNotFound_ReadMethodNotCalled()
        //{
        //    // Arrange
        //    _blobStorageProvider.Setup(x => x.OpenRead(It.IsAny<string>())).Returns(new MockStream());

        //    // Act
        //    _ = await _licenseProvider.GetLicenseAsync();

        //    // Assert
        //    _blobUrlResolver.Verify(x => x.GetAbsoluteUrl(It.Is<string>(s => s.EqualsInvariant(platformOptions.LicenseBlobPath))), Times.Once);
        //    _blobStorageProvider.Verify(x => x.OpenRead(It.IsAny<string>()), Times.Never);
        //}

        //[Fact]
        //public void SaveLicense_WriteMethodCalled()
        //{
        //    // Arrange
        //    var license = new License();

        //    var mockSteam = new Mock<MockStream>();
        //    mockSteam.SetupGet(x => x.CanWrite).Returns(true);
        //    _blobStorageProvider.Setup(x => x.OpenWrite(It.IsAny<string>())).Returns(mockSteam.Object);

        //    // Act
        //    _licenseProvider.SaveLicense(license);

        //    // Assert
        //    _blobUrlResolver.Verify(x => x.GetAbsoluteUrl(It.Is<string>(s => s.EqualsInvariant(platformOptions.LicenseBlobPath))), Times.Once);
        //    _blobStorageProvider.Verify(x => x.OpenWrite(It.IsAny<string>()), Times.Once);
        //    mockSteam.Verify(x => x.Flush(), Times.Once);
        //}

        //public class MockStream : Stream
        //{
        //    public override bool CanRead => true;
        //    public override bool CanSeek => true;
        //    public override bool CanWrite => true;
        //    public override long Length { get; }
        //    public override long Position { get; set; }

        //    public override void Flush()
        //    {
        //    }

        //    public override int Read(byte[] buffer, int offset, int count)
        //    {
        //        return 0;
        //    }

        //    public override long Seek(long offset, SeekOrigin origin)
        //    {
        //        return 0;
        //    }

        //    public override void SetLength(long value)
        //    {
        //    }

        //    public override void Write(byte[] buffer, int offset, int count)
        //    {
        //    }
        //}
    }
}
