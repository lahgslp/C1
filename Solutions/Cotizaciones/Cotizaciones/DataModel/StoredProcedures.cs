


  
using System;
using SubSonic;
using SubSonic.Schema;
using SubSonic.DataProviders;
using System.Data;

namespace Cotizaciones.DataModel{
	public partial class FersumDB{

        public StoredProcedure Fersum_Del_RemoveFloatingQuotationSectionsByQuotationID(int QuotationID){
            StoredProcedure sp=new StoredProcedure("Fersum_Del_RemoveFloatingQuotationSectionsByQuotationID",this.Provider);
            sp.Command.AddParameter("QuotationID",QuotationID,DbType.Int32);
            return sp;
        }
        public StoredProcedure Fersum_Del_RemoveQuotationSectionDetailByQuotationID(int QuotationID,int QuotationSectionDetailID){
            StoredProcedure sp=new StoredProcedure("Fersum_Del_RemoveQuotationSectionDetailByQuotationID",this.Provider);
            sp.Command.AddParameter("QuotationID",QuotationID,DbType.Int32);
            sp.Command.AddParameter("QuotationSectionDetailID",QuotationSectionDetailID,DbType.Int32);
            return sp;
        }
        public StoredProcedure Fersum_Del_RemoveQuotationSectionDetailByQuotationSectionDetailID(int QuotationID,int QuotationSectionDetailID){
            StoredProcedure sp=new StoredProcedure("Fersum_Del_RemoveQuotationSectionDetailByQuotationSectionDetailID",this.Provider);
            sp.Command.AddParameter("QuotationID",QuotationID,DbType.Int32);
            sp.Command.AddParameter("QuotationSectionDetailID",QuotationSectionDetailID,DbType.Int32);
            return sp;
        }
        public StoredProcedure Fersum_Ins_CloneQuotation(int QuotationID,string User){
            StoredProcedure sp=new StoredProcedure("Fersum_Ins_CloneQuotation",this.Provider);
            sp.Command.AddParameter("QuotationID",QuotationID,DbType.Int32);
            sp.Command.AddParameter("User",User,DbType.AnsiString);
            return sp;
        }
        public StoredProcedure Fersum_Sel_GetCompanyInfo(){
            StoredProcedure sp=new StoredProcedure("Fersum_Sel_GetCompanyInfo",this.Provider);
            return sp;
        }
        public StoredProcedure Fersum_Sel_GetCustomerInfo(){
            StoredProcedure sp=new StoredProcedure("Fersum_Sel_GetCustomerInfo",this.Provider);
            return sp;
        }
        public StoredProcedure Fersum_Sel_GetMyQuotations(string Creator,string DateFrom,string DateTo,int SectionTypeID,int PipeDiameterTypeID,int QuotationID,int CustomerID,int CustomerContactID,int QuotationStatusTypeID,int CompanyID){
            StoredProcedure sp=new StoredProcedure("Fersum_Sel_GetMyQuotations",this.Provider);
            sp.Command.AddParameter("Creator",Creator,DbType.AnsiString);
            sp.Command.AddParameter("DateFrom",DateFrom,DbType.AnsiString);
            sp.Command.AddParameter("DateTo",DateTo,DbType.AnsiString);
            sp.Command.AddParameter("SectionTypeID",SectionTypeID,DbType.Int32);
            sp.Command.AddParameter("PipeDiameterTypeID",PipeDiameterTypeID,DbType.Int32);
            sp.Command.AddParameter("QuotationID",QuotationID,DbType.Int32);
            sp.Command.AddParameter("CustomerID",CustomerID,DbType.Int32);
            sp.Command.AddParameter("CustomerContactID",CustomerContactID,DbType.Int32);
            sp.Command.AddParameter("QuotationStatusTypeID",QuotationStatusTypeID,DbType.Int32);
            sp.Command.AddParameter("CompanyID",CompanyID,DbType.Int32);
            return sp;
        }
        public StoredProcedure Fersum_Sel_GetMyQuotationsReferenceData(){
            StoredProcedure sp=new StoredProcedure("Fersum_Sel_GetMyQuotationsReferenceData",this.Provider);
            return sp;
        }
        public StoredProcedure Fersum_Sel_GetProductDetails(){
            StoredProcedure sp=new StoredProcedure("Fersum_Sel_GetProductDetails",this.Provider);
            return sp;
        }
        public StoredProcedure Fersum_Sel_GetProductSpecs(){
            StoredProcedure sp=new StoredProcedure("Fersum_Sel_GetProductSpecs",this.Provider);
            return sp;
        }
        public StoredProcedure Fersum_Sel_GetQuotationConditionsByQuotationID(int QuotationID){
            StoredProcedure sp=new StoredProcedure("Fersum_Sel_GetQuotationConditionsByQuotationID",this.Provider);
            sp.Command.AddParameter("QuotationID",QuotationID,DbType.Int32);
            return sp;
        }
        public StoredProcedure Fersum_Sel_GetQuotationConditionsReferenceData(){
            StoredProcedure sp=new StoredProcedure("Fersum_Sel_GetQuotationConditionsReferenceData",this.Provider);
            return sp;
        }
        public StoredProcedure Fersum_Sel_GetQuotationData(int QuotationID){
            StoredProcedure sp=new StoredProcedure("Fersum_Sel_GetQuotationData",this.Provider);
            sp.Command.AddParameter("QuotationID",QuotationID,DbType.Int32);
            return sp;
        }
        public StoredProcedure Fersum_Sel_GetQuotationFinishReferenceData(){
            StoredProcedure sp=new StoredProcedure("Fersum_Sel_GetQuotationFinishReferenceData",this.Provider);
            return sp;
        }
        public StoredProcedure Fersum_Sel_GetQuotationProductSelectionByQuotationID(int QuotationID){
            StoredProcedure sp=new StoredProcedure("Fersum_Sel_GetQuotationProductSelectionByQuotationID",this.Provider);
            sp.Command.AddParameter("QuotationID",QuotationID,DbType.Int32);
            return sp;
        }
        public StoredProcedure Fersum_Sel_GetQuotationSectionID(int QuotationID,int SectionTypeID){
            StoredProcedure sp=new StoredProcedure("Fersum_Sel_GetQuotationSectionID",this.Provider);
            sp.Command.AddParameter("QuotationID",QuotationID,DbType.Int32);
            sp.Command.AddParameter("SectionTypeID",SectionTypeID,DbType.Int32);
            return sp;
        }
        public StoredProcedure Fersum_Sel_GetQuotationsReport(string DateFrom,string DateTo){
            StoredProcedure sp=new StoredProcedure("Fersum_Sel_GetQuotationsReport",this.Provider);
            sp.Command.AddParameter("DateFrom",DateFrom,DbType.AnsiString);
            sp.Command.AddParameter("DateTo",DateTo,DbType.AnsiString);
            return sp;
        }
        public StoredProcedure Fersum_Upd_CustomerContact(int QuotationID){
            StoredProcedure sp=new StoredProcedure("Fersum_Upd_CustomerContact",this.Provider);
            sp.Command.AddParameter("QuotationID",QuotationID,DbType.Int32);
            return sp;
        }
        public StoredProcedure Fersum_Upd_UserCompanyPreferences(int UserID,int CompanyID,string CC,string Signature,string EmailAddress,string Modifier){
            StoredProcedure sp=new StoredProcedure("Fersum_Upd_UserCompanyPreferences",this.Provider);
            sp.Command.AddParameter("UserID",UserID,DbType.Int32);
            sp.Command.AddParameter("CompanyID",CompanyID,DbType.Int32);
            sp.Command.AddParameter("CC",CC,DbType.AnsiString);
            sp.Command.AddParameter("Signature",Signature,DbType.AnsiString);
            sp.Command.AddParameter("EmailAddress",EmailAddress,DbType.AnsiString);
            sp.Command.AddParameter("Modifier",Modifier,DbType.AnsiString);
            return sp;
        }
	
	}
	
}
 