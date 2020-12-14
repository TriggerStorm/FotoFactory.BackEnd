using System;
using System.Collections.Generic;
using System.Text;
using FotoFactory.CoreEntities;

namespace FotoFactory.Core.AppService
{
    public interface ISummaryService
    {
        Summary GetSummary(List<WorkSpace> workSpaces);
    }
}
