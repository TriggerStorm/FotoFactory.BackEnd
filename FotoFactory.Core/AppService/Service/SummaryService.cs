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

            Summary summary = new Summary()
            {
                TotalPrice = 0
            };

            foreach (WorkSpace workSpace in workSpaces)
            {
                if (workSpace.WorkSpacePosters.Count != 0)
                {
                    summary.SummaryWorkSpaces.Add(workSpace);

                    foreach (WorkSpacePoster workSpacePoster in workSpace.WorkSpacePosters)
                    {
                        // summary.TotalPrice = summary.TotalPrice + poster;
                        summary.TotalPrice += workSpacePoster.Size.PosterPrice;

                        if (workSpacePoster.Frame.FrameId != 7)
                        {
                            summary.TotalPrice += workSpacePoster.Size.FramePrice;
                        }
                    }
                }
            }
            return summary;
        }
    }
}
