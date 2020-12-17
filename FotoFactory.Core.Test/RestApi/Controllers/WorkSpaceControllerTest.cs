
using System.Collections.Generic;
using FluentAssertions;
using FotoFactory.BackEnd.Controllers;
using FotoFactory.Core.AppService;
using FotoFactory.CoreEntities;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;
using Xunit.Sdk;

namespace FotoFactory.Core.Test.RestApi.Controllers
{
   public class WorkSpaceControllerTest
    {
        [Fact]

        public void WithValidUserData__GetByUserId_ShouldReturnListOfAllWorkSpaceOfTheUser()
        {
            //given
            var workSpaceServiceMock = new Mock<IWorkSpaceService>();
            var list = new List<WorkSpace>();
            
            workSpaceServiceMock.Setup(ws => ws.ReadAllWorkSpace(1)).Returns(list);
            WorkSpaceController testController = new WorkSpaceController(workSpaceServiceMock.Object);

            //when
            var result = testController.Get(1, 0);
            
            //then
            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(list, (result as OkObjectResult).Value);
        }

        [Fact]
        public void Get_WithInvalidUserId_ThrowException()
        {
            //given
            var workSpaceServiceMock = new Mock<IWorkSpaceService>();
            WorkSpaceController testController = new WorkSpaceController(workSpaceServiceMock.Object);
            var list = new List<WorkSpace>();
            workSpaceServiceMock.Setup(ws => ws.ReadAllWorkSpace(0)).Returns(list);
            //when
            var result = testController.Get(0, 0);
            //then
            Assert.IsType<BadRequestResult>(result);
            Assert.Equal(400, (result as BadRequestResult).StatusCode);

        }
        [Fact]
        public void ValidUserId_InvalidWorkSpaceId_Get_ShouldReturn_ListOfWorkSpace()
        {
            //given
            var workSpaceServiceMock = new Mock<IWorkSpaceService>();
            WorkSpaceController controller = new WorkSpaceController(workSpaceServiceMock.Object);
            var list= new List<WorkSpace>();
            workSpaceServiceMock.Setup(ws => ws.ReadAllWorkSpace(1)).Returns(list);
            
            //when
            var result = controller.Get(1, 0);
            
            //then
            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(list, (result as OkObjectResult).Value);
           
        }

        //[Fact]
        //public void IfNameIsNull_InPost_ShouldThrowException()
        //{
        //    //given
        //    var workSpaceServiceMock = new Mock<IWorkSpaceService>();
        //    WorkSpaceController controller = new WorkSpaceController(workSpaceServiceMock.Object);
        //    var testWorkSpace = new WorkSpace() { WorkSpaceId = 10, Name = null, };
        //    workSpaceServiceMock.Setup(ws => ws.CreateWorkSpace(null, "", 1)).Returns(testWorkSpace);
        //    //when
        //    var result = controller.Post(new JObject("", ""));
        //    //then
        //    Assert.IsType<StatusCodeResult>(result);
        //    Assert.Equal(500, (result as StatusCodeResult).StatusCode);
        //}

        //[Fact]
        //public void IfNameIsValid_InPost_AddName()
        //{
        //    //given
        //    var workSpaceServiceMock = new Mock<IWorkSpaceService>();
        //    WorkSpaceController controller = new WorkSpaceController(workSpaceServiceMock.Object);
        //    var testWorkSpace = new WorkSpace() { };
        //    workSpaceServiceMock.Setup(ws => ws.CreateWorkSpace(null, "", 1)).Returns(testWorkSpace);
        //    //when
        //    var result = controller.Post(new JObject("xyz", ""));
        //    //then
        //    Assert.IsType<StatusCodeResult>(result);
        //    Assert.Equal(testWorkSpace, (result as StatusCodeResult).StatusCode);
        //}

        [Fact]
        public void Delete_IdGivenIsLessThan1_ThrowException()
        {
            //given
            var workSpaceServiceMock = new Mock<IWorkSpaceService>();
            WorkSpaceController controller = new WorkSpaceController(workSpaceServiceMock.Object);
            var testWorkSpace = new WorkSpace();
            
            //when
            //workSpaceServiceMock.Setup(ws => ws.DeleteWorkSpace(-1)).Returns(testWorkSpace);
            var result = controller.Delete(-1);

            //then
            Assert.IsType<BadRequestResult>(result);
            Assert.Equal(400, (result as BadRequestResult).StatusCode);

        }
    }
}
