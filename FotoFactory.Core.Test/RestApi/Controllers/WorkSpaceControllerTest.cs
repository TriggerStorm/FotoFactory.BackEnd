
using System.Collections.Generic;
using FotoFactory.BackEnd.Controllers;
using FotoFactory.Core.AppService;
using FotoFactory.CoreEntities;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace FotoFactory.Core.Test.RestApi.Controllers
{
   public class WorkSpaceControllerTest
    {
        [Fact]

        public void GetAll_ReturnsAllWorkSpace_ThrowNewException()
        {
            var workSpaceServiceMock = new Mock<IWorkSpaceService>();
            var list = new List<WorkSpace>();
            workSpaceServiceMock.Setup(ws => ws.ReadAllWorkSpace(1)).Returns(list);
            //IAction actionResult = controllerMock.VerifyGet(userId , workSpaceId);
            WorkSpaceController controllerMock = new WorkSpaceController(workSpaceServiceMock.Object);
            var result = controllerMock.Get(1, 0);
            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(list, (result as OkObjectResult).Value);
        }

        //[Fact]
        //public void GetAll_WithZeroUserId_ThrowException()
        //{

        //}
    }
}
