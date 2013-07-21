using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cloudwords.NET.Classes
{
    public static class Validate
    {
        public static string CreateProjectInput(string name, string description, string sourceLanguageCode, List<string> targetLanguagesCode,
                                   string bidDueDate, string deliveryDueDate, string reviewDueDate, string notes, int intendedUse,int? department,int? owner, string poNumber)
        {
            string error = string.Empty;
            DateTime dtBidDueDate= DateTime.Now;
            DateTime dtDeliveryDueDate = DateTime.Now;
            DateTime dtReviewDueDate = DateTime.Now;
            
            if (string.IsNullOrEmpty(name))
            {
                error = "Error:Name is required";
            }
            else
            {
                if (name.Length > 50)
                {
                    error = "Error: Name must be 50 characters or less in length";
                }
            }
            if (!string.IsNullOrEmpty(description))
            {
                if (description.Length > 50)
                {
                    error = "Error: Description must be 250 characters or less in length";
                }
            }
            if (string.IsNullOrEmpty(sourceLanguageCode))
            {
                error = "Error: sourceLanguageCode is required";
            }
            if (targetLanguagesCode ==null|| targetLanguagesCode.Count == 0)
            {
                error = "Error: targetLanguagesCode is required";
            }

            if (!string.IsNullOrEmpty(bidDueDate))
            {
                
                if (DateTime.TryParse(bidDueDate, out dtBidDueDate))
                {
                    if ((dtBidDueDate - DateTime.Now).TotalHours < 48)
                    {
                        error = "Error: bidDueDate must be 48 hours or more in the future";
                    }
                }
                else
                {
                    error = "Error: bidDueDate is invalid";
                }
            }

            if (!string.IsNullOrEmpty(deliveryDueDate))
            {
                if (DateTime.TryParse(deliveryDueDate, out dtDeliveryDueDate))
                {
                    if ((dtDeliveryDueDate - dtBidDueDate).TotalHours < 48)
                    {
                        error = "Error: deliveryDueDate must be 48 hours or more after the bidDueDate.";
                    }
                }
                else
                {
                    error = "Error: deliveryDueDate is invalid";
                }
            }
            if (!string.IsNullOrEmpty(reviewDueDate))
            {
                if (DateTime.TryParse(reviewDueDate, out dtReviewDueDate))
                {
                    if ((dtReviewDueDate - dtDeliveryDueDate).TotalHours <0 )
                    {
                        error = "Error: reviewDueDate must be after or on deliveryDueDate.";
                    }
                }
                else
                {
                    error = "Error: reviewDueDate is invalid";
                }
            }
            if (!string.IsNullOrEmpty(notes))
            {
                if (notes.Length > 1000)
                {
                    error = "Error: notes must be 1000 characters or less in length";
                }
            }
            if (department.HasValue)
            {
                if (department.Value < 1)
                {
                    error = "Error: invalid department ID";
                }
            }
            if (owner.HasValue)
            {
                if (owner.Value > 0)
                {
                    error = "Error: invalid owner ID";
                }
            }

            if (!string.IsNullOrEmpty(poNumber))
            {
                if (poNumber.Length > 45)
                {
                    error = "Error: poNumber must be 45 characters or less in length";
                }
            }
            return error;
        } 
    }
}
