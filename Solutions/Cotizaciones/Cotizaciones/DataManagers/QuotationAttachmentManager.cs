using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cotizaciones.DataModel;
using SubSonic.Schema;
using System.Collections;

namespace Cotizaciones.DataManagers
{
    static class QuotationAttachmentManager
    {
        public static ArrayList GetQuotationAttachments(int QuotationID)
        {
            FersumDB db = new FersumDB();
            var result = from qa in db.QuotationAttachments
                         where qa.QuotationID == QuotationID
                         orderby qa.QuotationAttachmentID
                         select qa;
            ArrayList attachments = new ArrayList();
            foreach (var item in result)
            {
                attachments.Add(item);
            }
            return attachments;
        }

        public static QuotationAttachment GetQuotationAttachment(int QuotationID)
        {
            FersumDB db = new FersumDB();
            var result = from qa in db.QuotationAttachments
                         where qa.QuotationID == QuotationID && qa.QuotationFileIndicator == "Y"
                         select qa;
            ArrayList attachments = new ArrayList();
            foreach (var item in result)
            {
                return item;
            }
            return null;
        }

        public static QuotationAttachment GetQuotationAttachmentByName(int QuotationID, string AttachmentName)
        {
            FersumDB db = new FersumDB();
            var result = from qa in db.QuotationAttachments
                         where qa.QuotationID == QuotationID && qa.ExternalFileName == AttachmentName
                         select qa;
            ArrayList attachments = new ArrayList();
            foreach (var item in result)
            {
                return item;
            }
            return null;
        }

        public static QuotationAttachment AddQuotationAttachment(int quotationID, string fileName, string user)
        {
            return AddQuotationAttachment(quotationID, fileName, user, "N");
        }

        public static QuotationAttachment AddQuotationAttachment(int quotationID, string fileName, string user, string QuotationFileIndicator)
        {
            QuotationAttachment qa = new QuotationAttachment();
            qa.QuotationID = quotationID;
            qa.ExternalFileName = fileName;
            qa.QuotationFileIndicator = QuotationFileIndicator;
            qa.Active = "A";
            qa.Creator = user;
            qa.Created = DateTime.Now;
            qa.Save();
            return qa;
        }

        public static void RemoveQuotationAttachment(int quotationID, int quotationAttachmentID)
        {
            QuotationAttachment qa = new QuotationAttachment();
            qa.QuotationID = quotationID;
            qa.QuotationAttachmentID = quotationAttachmentID;
            qa.Delete();
        }

        public static QuotationAttachment GetQuotationAttachmentByName(ArrayList quotationAttachments, string fileName)
        {
            foreach (QuotationAttachment qa in quotationAttachments)
            {
                if (qa.ExternalFileName == Utilities.GetFileName(fileName))
                {
                    return qa;
                }
            }
            return null;
        }

        public static int GetQuotationAttachmentIndex(ArrayList quotationAttachments, string fileName)
        {
            for (int index = 0; index < quotationAttachments.Count; index++)
            {
                QuotationAttachment qa = (QuotationAttachment)quotationAttachments[index];
                if (qa.ExternalFileName == fileName)
                {
                    return index;
                }
            }
            return -1;
        }

    }
}
