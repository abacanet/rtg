using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ReverseQuest.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ReverseQuest.Web.Controllers.Tests
{
    [TestClass()]
    public class LoanBoardingControllerTests
    {
        FileStream _stream;
        LoanBoardingController _controller = new LoanBoardingController();
        [TestInitialize]
        public void SetUp()
        {
            _stream = new FileStream(string.Format(
                            ConfigurationManager.AppSettings["LoanFilePath"],
                            AppDomain.CurrentDomain.BaseDirectory),
                         FileMode.Open);

            // Other stuff
        }


        [TestMethod]
        public void TestUpload()
        {
            //LoanBoardingController c = new LoanBoardingController();
            //Mock<ControllerContext> cc = new Mock<ControllerContext>();
            //UTF8Encoding enc = new UTF8Encoding();

            //Mock<HttpPostedFileBase> file1 = new Mock<HttpPostedFileBase>();
            //file1.Setup(d => d.FileName).Returns("test1.txt");
            //file1.Setup(d => d.InputStream).Returns(_stream);
            //file1.Setup(d => d.ContentType).Returns("text/plain");

            ////Mock<HttpPostedFileBase> file2 = new Mock<HttpPostedFileBase>();
            ////file2.Expect(d => d.FileName).Returns("test2.txt");
            ////file2.Expect(d => d.InputStream).Returns(new MemoryStream(enc.GetBytes(Resources.UploadTestFiles.test2)));

            //cc.Setup(d => d.HttpContext.Request.Files.Count).Returns(1);
            //cc.Setup(d => d.HttpContext.Request.Files[0]).Returns(file1.Object);

            ////cc.Expect(d => d.HttpContext.Request.Files[1]).Returns(file2.Object);
            //c.ControllerContext = cc.Object;
            //List<HttpPostedFileBase> files = new List<HttpPostedFileBase>();
            //files.Add(file1.Object);
            //ActionResult r = c.Upload(files);
            //Assert.IsInstanceOfType(r, typeof(ContentResult));
            //Assert.AreNotEqual("Uploaded 2 files.<br/>\nFile test1.txt: Contents of test file 1<br/>\nFile test2.txt: Contents of test file 2<br/>", ((ContentResult)r).Content);
        }


        //[TestMethod]
        //public void FileUploadTest()
        //{
        //    // Other stuff

        //    #region Mock HttpPostedFileBase
        //    HttpPostedFile f;
        //    f.InputStream = _stream;
        //    var context = new Mock<HttpContextBase>();
        //    var request = new Mock<HttpRequestBase>();
        //    var files = new Mock<HttpFileCollectionBase>();
        //    var file = new Mock<HttpPostedFileBase>();
        //    context.Setup(x => x.Request).Returns(request.Object);

        //    files.Setup(x => x.Count).Returns(1);

        //    // The required properties from my Controller side
        //    file.Setup(x => x.InputStream).Returns(_stream);
        //    file.Setup(x => x.ContentLength).Returns((int)_stream.Length);
        //    file.Setup(x => x.FileName).Returns(_stream.Name);

        //    files.Setup(x => x.Get(0).InputStream).Returns(file.Object.InputStream);
        //    request.Setup(x => x.Files).Returns(files.Object);
        //    request.Setup(x => x.Files[0]).Returns(file.Object);

        //    _controller.ControllerContext = new ControllerContext(
        //                             context.Object, new RouteData(), _controller);
        //    _controller.Upload(files);
        //    #endregion
        //    // The rest...
        //}
        //[TestMethod()]
        //public void SubmitTest()
        //{
        //    Assert.Fail();
        //}
    }
}