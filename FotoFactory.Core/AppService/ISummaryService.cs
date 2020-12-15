using System;
using System.Collections.Generic;
using System.Text;
using FotoFactory.CoreEntities;

namespace FotoFactory.Core.AppService
{
    public interface ISummaryService
    {
        List<Summary> GetSummaryList(List<WorkSpace> workSpaces);
        //void ExportToCSV(List<Summary> allSummaries);
    }
}
