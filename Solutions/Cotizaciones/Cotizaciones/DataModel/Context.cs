






















using System;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using SubSonic.DataProviders;
using SubSonic.Extensions;
using SubSonic.Linq.Structure;
using SubSonic.Query;
using SubSonic.Schema;
using System.Data.Common;
using System.Collections.Generic;
using Cotizaciones.Common;

namespace Cotizaciones.DataModel
{
    public partial class FersumDB : IQuerySurface
    {

        public IDataProvider DataProvider;
        public DbQueryProvider provider;
        
        public bool TestMode
		{
            get
			{
                return DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            }
        }

        public FersumDB() 
        { 
            DataProvider = ProviderFactory.GetProvider(ConfigurationHelper.ConnectionStringName);
            Init();
        }

        public FersumDB(string connectionStringName)
        {
            DataProvider = ProviderFactory.GetProvider(connectionStringName);
            Init();
        }

		public FersumDB(string connectionString, string providerName)
        {
            DataProvider = ProviderFactory.GetProvider(connectionString,providerName);
            Init();
        }

		public ITable FindByPrimaryKey(string pkName)
        {
            return DataProvider.Schema.Tables.SingleOrDefault(x => x.PrimaryKey.Name.Equals(pkName, StringComparison.InvariantCultureIgnoreCase));
        }

        public Query<T> GetQuery<T>()
        {
            return new Query<T>(provider);
        }
        
        public ITable FindTable(string tableName)
        {
            return DataProvider.FindTable(tableName);
        }
               
        public IDataProvider Provider
        {
            get { return DataProvider; }
            set {DataProvider=value;}
        }
        
        public DbQueryProvider QueryProvider
        {
            get { return provider; }
        }
        
        BatchQuery _batch = null;
        public void Queue<T>(IQueryable<T> qry)
        {
            if (_batch == null)
                _batch = new BatchQuery(Provider, QueryProvider);
            _batch.Queue(qry);
        }

        public void Queue(ISqlQuery qry)
        {
            if (_batch == null)
                _batch = new BatchQuery(Provider, QueryProvider);
            _batch.Queue(qry);
        }

        public void ExecuteTransaction(IList<DbCommand> commands)
		{
            if(!TestMode)
			{
                using(var connection = commands[0].Connection)
				{
                   if (connection.State == ConnectionState.Closed)
                        connection.Open();
                   
                   using (var trans = connection.BeginTransaction()) 
				   {
                        foreach (var cmd in commands) 
						{
                            cmd.Transaction = trans;
                            cmd.Connection = connection;
                            cmd.ExecuteNonQuery();
                        }
                        trans.Commit();
                    }
                    connection.Close();
                }
            }
        }

        public IDataReader ExecuteBatch()
        {
            if (_batch == null)
                throw new InvalidOperationException("There's nothing in the queue");
            if(!TestMode)
                return _batch.ExecuteReader();
            return null;
        }
			

        public Query<UnitType> UnitTypes { get; set; }

        public Query<User> Users { get; set; }

        public Query<InvoiceMethodType> InvoiceMethodTypes { get; set; }

        public Query<ValidPeriodType> ValidPeriodTypes { get; set; }

        public Query<Customer> Customers { get; set; }

        public Query<Company> Companies { get; set; }

        public Query<ConfigurationKey> ConfigurationKeys { get; set; }

        public Query<CurrencyType> CurrencyTypes { get; set; }

        public Query<PaymentType> PaymentTypes { get; set; }

        public Query<PipeSpecification> PipeSpecifications { get; set; }

        public Query<Quotation> Quotations { get; set; }

        public Query<QuotationSection> QuotationSections { get; set; }

        public Query<QuotationSectionDetail> QuotationSectionDetails { get; set; }

        public Query<UserPreference> UserPreferences { get; set; }

        public Query<UserCompanyPreference> UserCompanyPreferences { get; set; }

        public Query<CustomerContact> CustomerContacts { get; set; }

        public Query<QuotationAttachment> QuotationAttachments { get; set; }

        public Query<DeliveryTimeType> DeliveryTimeTypes { get; set; }

        public Query<DeliveryType> DeliveryTypes { get; set; }

        public Query<PipeDiameterType> PipeDiameterTypes { get; set; }

        public Query<QuotationStatusType> QuotationStatusTypes { get; set; }

        public Query<SectionType> SectionTypes { get; set; }


			

        #region ' Aggregates and SubSonic Queries '
        public Select SelectColumns(params string[] columns)
        {
            return new Select(DataProvider, columns);
        }

        public Select Select
        {
            get { return new Select(this.Provider); }
        }

        public Insert Insert
		{
            get { return new Insert(this.Provider); }
        }

        public Update<T> Update<T>() where T:new()
		{
            return new Update<T>(this.Provider);
        }

        public SqlQuery Delete<T>(Expression<Func<T,bool>> column) where T:new()
        {
            LambdaExpression lamda = column;
            SqlQuery result = new Delete<T>(this.Provider);
            result = result.From<T>();
            result.Constraints=lamda.ParseConstraints().ToList();
            return result;
        }

        public SqlQuery Max<T>(Expression<Func<T,object>> column)
        {
            LambdaExpression lamda = column;
            string colName = lamda.ParseObjectValue();
            string objectName = typeof(T).Name;
            string tableName = DataProvider.FindTable(objectName).Name;
            return new Select(DataProvider, new Aggregate(colName, AggregateFunction.Max)).From(tableName);
        }

        public SqlQuery Min<T>(Expression<Func<T,object>> column)
        {
            LambdaExpression lamda = column;
            string colName = lamda.ParseObjectValue();
            string objectName = typeof(T).Name;
            string tableName = this.Provider.FindTable(objectName).Name;
            return new Select(this.Provider, new Aggregate(colName, AggregateFunction.Min)).From(tableName);
        }

        public SqlQuery Sum<T>(Expression<Func<T,object>> column)
        {
            LambdaExpression lamda = column;
            string colName = lamda.ParseObjectValue();
            string objectName = typeof(T).Name;
            string tableName = this.Provider.FindTable(objectName).Name;
            return new Select(this.Provider, new Aggregate(colName, AggregateFunction.Sum)).From(tableName);
        }

        public SqlQuery Avg<T>(Expression<Func<T,object>> column)
        {
            LambdaExpression lamda = column;
            string colName = lamda.ParseObjectValue();
            string objectName = typeof(T).Name;
            string tableName = this.Provider.FindTable(objectName).Name;
            return new Select(this.Provider, new Aggregate(colName, AggregateFunction.Avg)).From(tableName);
        }

        public SqlQuery Count<T>(Expression<Func<T,object>> column)
        {
            LambdaExpression lamda = column;
            string colName = lamda.ParseObjectValue();
            string objectName = typeof(T).Name;
            string tableName = this.Provider.FindTable(objectName).Name;
            return new Select(this.Provider, new Aggregate(colName, AggregateFunction.Count)).From(tableName);
        }

        public SqlQuery Variance<T>(Expression<Func<T,object>> column)
        {
            LambdaExpression lamda = column;
            string colName = lamda.ParseObjectValue();
            string objectName = typeof(T).Name;
            string tableName = this.Provider.FindTable(objectName).Name;
            return new Select(this.Provider, new Aggregate(colName, AggregateFunction.Var)).From(tableName);
        }

        public SqlQuery StandardDeviation<T>(Expression<Func<T,object>> column)
        {
            LambdaExpression lamda = column;
            string colName = lamda.ParseObjectValue();
            string objectName = typeof(T).Name;
            string tableName = this.Provider.FindTable(objectName).Name;
            return new Select(this.Provider, new Aggregate(colName, AggregateFunction.StDev)).From(tableName);
        }

        #endregion

        void Init()
        {
            provider = new DbQueryProvider(this.Provider);


            #region ' Query Defs '

            UnitTypes = new Query<UnitType>(provider);


            Users = new Query<User>(provider);


            InvoiceMethodTypes = new Query<InvoiceMethodType>(provider);


            ValidPeriodTypes = new Query<ValidPeriodType>(provider);


            Customers = new Query<Customer>(provider);


            Companies = new Query<Company>(provider);


            ConfigurationKeys = new Query<ConfigurationKey>(provider);


            CurrencyTypes = new Query<CurrencyType>(provider);


            PaymentTypes = new Query<PaymentType>(provider);


            PipeSpecifications = new Query<PipeSpecification>(provider);


            Quotations = new Query<Quotation>(provider);


            QuotationSections = new Query<QuotationSection>(provider);


            QuotationSectionDetails = new Query<QuotationSectionDetail>(provider);


            UserPreferences = new Query<UserPreference>(provider);


            UserCompanyPreferences = new Query<UserCompanyPreference>(provider);


            CustomerContacts = new Query<CustomerContact>(provider);


            QuotationAttachments = new Query<QuotationAttachment>(provider);


            DeliveryTimeTypes = new Query<DeliveryTimeType>(provider);


            DeliveryTypes = new Query<DeliveryType>(provider);


            PipeDiameterTypes = new Query<PipeDiameterType>(provider);


            QuotationStatusTypes = new Query<QuotationStatusType>(provider);


            SectionTypes = new Query<SectionType>(provider);


            #endregion



            #region ' Schemas '
        	if(DataProvider.Schema.Tables.Count == 0)
			{

            	DataProvider.Schema.Tables.Add(new UnitTypeTable(DataProvider));

            	DataProvider.Schema.Tables.Add(new UserTable(DataProvider));

            	DataProvider.Schema.Tables.Add(new InvoiceMethodTypeTable(DataProvider));

            	DataProvider.Schema.Tables.Add(new ValidPeriodTypeTable(DataProvider));

            	DataProvider.Schema.Tables.Add(new CustomerTable(DataProvider));

            	DataProvider.Schema.Tables.Add(new CompanyTable(DataProvider));

            	DataProvider.Schema.Tables.Add(new ConfigurationKeyTable(DataProvider));

            	DataProvider.Schema.Tables.Add(new CurrencyTypeTable(DataProvider));

            	DataProvider.Schema.Tables.Add(new PaymentTypeTable(DataProvider));

            	DataProvider.Schema.Tables.Add(new PipeSpecificationTable(DataProvider));

            	DataProvider.Schema.Tables.Add(new QuotationTable(DataProvider));

            	DataProvider.Schema.Tables.Add(new QuotationSectionTable(DataProvider));

            	DataProvider.Schema.Tables.Add(new QuotationSectionDetailTable(DataProvider));

            	DataProvider.Schema.Tables.Add(new UserPreferencesTable(DataProvider));

            	DataProvider.Schema.Tables.Add(new UserCompanyPreferencesTable(DataProvider));

            	DataProvider.Schema.Tables.Add(new CustomerContactTable(DataProvider));

            	DataProvider.Schema.Tables.Add(new QuotationAttachmentTable(DataProvider));

            	DataProvider.Schema.Tables.Add(new DeliveryTimeTypeTable(DataProvider));

            	DataProvider.Schema.Tables.Add(new DeliveryTypeTable(DataProvider));

            	DataProvider.Schema.Tables.Add(new PipeDiameterTypeTable(DataProvider));

            	DataProvider.Schema.Tables.Add(new QuotationStatusTypeTable(DataProvider));

            	DataProvider.Schema.Tables.Add(new SectionTypeTable(DataProvider));

            }
            #endregion
        }
    }
}