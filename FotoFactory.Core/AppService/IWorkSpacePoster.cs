using System;
using System.Collections.Generic;
using System.Text;
using FotoFactory.CoreEntities;

namespace FotoFactory.Core.AppService
{
    public interface IWorkSpacePoster
    {
        WorkSpacePoster CreateWorkSpacePoster();
    }
}
