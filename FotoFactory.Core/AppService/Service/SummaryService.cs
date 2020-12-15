using FotoFactory.CoreEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FotoFactory.Core.AppService.Service
{
    public class SummaryService : ISummaryService
    {

        public List<Summary> GetSummaryList(List<WorkSpace> workSpaces)
        {
            List<Summary>  allSummaries = new List<Summary>();
            double totalPrice = 0;//setting cost at zero
            Summary title = new Summary() {PosterName = "SUMMARY" };
            allSummaries.Add(title);
            Summary blank = new Summary() { PosterName = "" };
            allSummaries.Add(blank);

            foreach (WorkSpace workSpace in workSpaces)
            {
                if (workSpace.WorkSpacePosters.Count != 0)
                {
                    Summary workSpaceName = new Summary() { PosterName = workSpace.Name };
                    allSummaries.Add(workSpaceName);
                    List<WorkSpacePoster> wsp = workSpace.WorkSpacePosters;
                    
                   // summaryWorkSpaces.Add(workSpace);


                    foreach (WorkSpacePoster workSpacePoster in workSpace.WorkSpacePosters)
                    {

                        double posterAndFramePrice = 0;
                        if (workSpacePoster.Frame.FrameType == "NOFRAME")
                        {
                            posterAndFramePrice = workSpacePoster.Size.PosterPrice;
                        }
                        else

                        {
                            posterAndFramePrice = workSpacePoster.Size.PosterPrice + workSpacePoster.Size.FramePrice;
                        }
                        totalPrice += posterAndFramePrice;
                        Summary posterDetails = new Summary()
                        {
                            PosterName = workSpacePoster.Poster.PosterName,
                            SKUCode = workSpacePoster.Poster.PosterSku,
                            Size = workSpacePoster.Size.Dimensions,
                            Frame = workSpacePoster.Frame.FrameType,
                            Price = posterAndFramePrice.ToString()
                        };
                        allSummaries.Add(posterDetails);
                    }
                    allSummaries.Add(blank);
                }
            }

            Summary totalPriceSummary = new Summary()
            {
                Frame = "TOTAL PRICE",
                Price = totalPrice.ToString()
            };
            allSummaries.Add(totalPriceSummary);
            return allSummaries;

        }
    }
}
