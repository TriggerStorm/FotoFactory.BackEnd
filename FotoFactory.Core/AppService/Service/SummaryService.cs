using FotoFactory.CoreEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FotoFactory.Core.AppService.Service
{
    public class SummaryService : ISummaryService
    {
        public Summary GetSummary(List<WorkSpace> workSpaces)
        {
            List<WorkSpace>  summaryWorkSpaces = new List<WorkSpace>(); 
            
            Summary summary = new Summary();

            summary.TotalPrice = 0;//setting price at zero

            foreach (WorkSpace workSpace in workSpaces)
            {
                if (workSpace.WorkSpacePosters.Count != 0)
                {
                    List<WorkSpacePoster> wsp = workSpace.WorkSpacePosters;
                    
                    summaryWorkSpaces.Add(workSpace);

                    foreach (WorkSpacePoster workSpacePoster in wsp)
                    {
                        summary.TotalPrice += workSpacePoster.Size.PosterPrice;
                        if (workSpacePoster.Frame.FrameId != 7)
                        {
                            summary.TotalPrice += workSpacePoster.Size.FramePrice;
                        }
                    }
                }
            }
            summary.SummaryWorkSpaces = summaryWorkSpaces;
            return summary;
        }
    }
}
