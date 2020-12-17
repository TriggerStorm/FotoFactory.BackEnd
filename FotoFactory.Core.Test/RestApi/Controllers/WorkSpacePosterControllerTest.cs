using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using FotoFactory.BackEnd.Controllers;
using FotoFactory.Core.AppService;
using FotoFactory.Core.AppService.Service;
using FotoFactory.CoreEntities;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using Collection = FotoFactory.CoreEntities.Collection;

namespace FotoFactory.Core.Test.RestApi.Controllers
{
    public class WorkSpacePosterControllerTest
    {
        [Fact]
        public void Get_ShouldReadWspAsList()
        {
            //arrange
            var workSpacePosterMock = new Mock<IWorkSpacePosterService>();
            var list = new List<WorkSpacePoster>();
            WorkSpacePosterController controller = new WorkSpacePosterController(workSpacePosterMock.Object);


            //act
            workSpacePosterMock.Setup(ws => ws.ReadAllWorkSpacePoster()).Returns(list);
            var listResult = controller.Get();
            //assert
            Assert.IsType<OkObjectResult>(listResult);
            Assert.Equal(list, (listResult as OkObjectResult).Value);
        }

        [Fact]
        public void ValidId_GetById_ShouldReturnWSP()
        {
            //arrange
            var workSpacePosterMock = new Mock<IWorkSpacePosterService>();
            WorkSpacePosterController controller = new WorkSpacePosterController(workSpacePosterMock.Object);
            var tempWorkSpace = new WorkSpacePoster();
            //act
            workSpacePosterMock.Setup(ws => ws.ReadWorkSpacePosterById(1)).Returns(tempWorkSpace);
            var result = controller.Get(1);
            //assert
            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(tempWorkSpace, (result as OkObjectResult).Value);
        }
    }
}
