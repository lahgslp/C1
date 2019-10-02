



















using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SubSonic.DataProviders;
using SubSonic.Extensions;
using System.Linq.Expressions;
using SubSonic.Schema;
using System.Collections;
using SubSonic;
using SubSonic.Repository;
using System.ComponentModel;
using System.Data.Common;

namespace Cotizaciones.DataModel
{

    
    
    /// <summary>
    /// A class which represents the UnitType table in the Fersum Database.
    /// </summary>
    public partial class UnitType: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<UnitType> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<UnitType>(new Cotizaciones.DataModel.FersumDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<UnitType> testlist){
            SetTestRepo();
            _testRepo._items = testlist;
        }
        public static void Setup(UnitType item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                UnitType item=new UnitType();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<UnitType> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        Cotizaciones.DataModel.FersumDB _db;
        public UnitType(string connectionString, string providerName) {

            _db=new Cotizaciones.DataModel.FersumDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                UnitType.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<UnitType>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public UnitType(){
             _db=new Cotizaciones.DataModel.FersumDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public UnitType(Expression<Func<UnitType, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<UnitType> GetRepo(string connectionString, string providerName){
            Cotizaciones.DataModel.FersumDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new Cotizaciones.DataModel.FersumDB();
            }else{
                db=new Cotizaciones.DataModel.FersumDB(connectionString, providerName);
            }
            IRepository<UnitType> _repo;
            
            if(db.TestMode){
                UnitType.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<UnitType>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<UnitType> GetRepo(){
            return GetRepo("","");
        }
        
        public static UnitType SingleOrDefault(Expression<Func<UnitType, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            UnitType single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static UnitType SingleOrDefault(Expression<Func<UnitType, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            UnitType single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<UnitType, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<UnitType, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<UnitType> Find(Expression<Func<UnitType, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<UnitType> Find(Expression<Func<UnitType, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<UnitType> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<UnitType> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<UnitType> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<UnitType> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<UnitType> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<UnitType> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "UnitTypeID";
        }

        public object KeyValue()
        {
            return this.UnitTypeID;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
            return this.ShortName.ToString();
        }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(UnitType)){
                UnitType compare=(UnitType)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }


        
        public override int GetHashCode() {
            return this.UnitTypeID;
        }
        

        public string DescriptorValue()
        {
            return this.ShortName.ToString();
        }

        public string DescriptorColumn() {
            return "ShortName";
        }
        public static string GetKeyColumn()
        {
            return "UnitTypeID";
        }        
        public static string GetDescriptorColumn()
        {
            return "ShortName";
        }
        
        #region ' Foreign Keys '

        public IQueryable<QuotationSectionDetail> QuotationSectionDetails
        {
            get
            {
                
                  var repo=Cotizaciones.DataModel.QuotationSectionDetail.GetRepo();
                  return from items in repo.GetAll()
                       where items.UnitTypeID == _UnitTypeID
                       select items;
            }
        }


        #endregion
        


        int _UnitTypeID;
        public int UnitTypeID
        {
            get { return _UnitTypeID; }
            set
            {
                if(_UnitTypeID!=value){
                    _UnitTypeID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="UnitTypeID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _ShortName;
        public string ShortName
        {
            get { return _ShortName; }
            set
            {
                if(_ShortName!=value){
                    _ShortName=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ShortName");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _Description;
        public string Description
        {
            get { return _Description; }
            set
            {
                if(_Description!=value){
                    _Description=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Description");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _Active;
        public string Active
        {
            get { return _Active; }
            set
            {
                if(_Active!=value){
                    _Active=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Active");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _Creator;
        public string Creator
        {
            get { return _Creator; }
            set
            {
                if(_Creator!=value){
                    _Creator=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Creator");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        DateTime _Created;
        public DateTime Created
        {
            get { return _Created; }
            set
            {
                if(_Created!=value){
                    _Created=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Created");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _Modifier;
        public string Modifier
        {
            get { return _Modifier; }
            set
            {
                if(_Modifier!=value){
                    _Modifier=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Modifier");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        DateTime? _Modified;
        public DateTime? Modified
        {
            get { return _Modified; }
            set
            {
                if(_Modified!=value){
                    _Modified=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Modified");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }




        public DbCommand GetUpdateCommand() {

            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        


            
            if(this._dirtyColumns.Count>0)
                _repo.Update(this,provider);
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        

       
        public void Add(IDataProvider provider){





            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
        
        
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        


        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
            
        }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<UnitType, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            

        }

        


        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 

    
    
    /// <summary>
    /// A class which represents the User table in the Fersum Database.
    /// </summary>
    public partial class User: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<User> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<User>(new Cotizaciones.DataModel.FersumDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<User> testlist){
            SetTestRepo();
            _testRepo._items = testlist;
        }
        public static void Setup(User item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                User item=new User();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<User> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        Cotizaciones.DataModel.FersumDB _db;
        public User(string connectionString, string providerName) {

            _db=new Cotizaciones.DataModel.FersumDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                User.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<User>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public User(){
             _db=new Cotizaciones.DataModel.FersumDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public User(Expression<Func<User, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<User> GetRepo(string connectionString, string providerName){
            Cotizaciones.DataModel.FersumDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new Cotizaciones.DataModel.FersumDB();
            }else{
                db=new Cotizaciones.DataModel.FersumDB(connectionString, providerName);
            }
            IRepository<User> _repo;
            
            if(db.TestMode){
                User.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<User>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<User> GetRepo(){
            return GetRepo("","");
        }
        
        public static User SingleOrDefault(Expression<Func<User, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            User single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static User SingleOrDefault(Expression<Func<User, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            User single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<User, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<User, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<User> Find(Expression<Func<User, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<User> Find(Expression<Func<User, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<User> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<User> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<User> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<User> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<User> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<User> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "UserID";
        }

        public object KeyValue()
        {
            return this.UserID;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
            return this.ShortName.ToString();
        }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(User)){
                User compare=(User)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }


        
        public override int GetHashCode() {
            return this.UserID;
        }
        

        public string DescriptorValue()
        {
            return this.ShortName.ToString();
        }

        public string DescriptorColumn() {
            return "ShortName";
        }
        public static string GetKeyColumn()
        {
            return "UserID";
        }        
        public static string GetDescriptorColumn()
        {
            return "ShortName";
        }
        
        #region ' Foreign Keys '

        public IQueryable<UserCompanyPreference> UserCompanyPreferences
        {
            get
            {
                
                  var repo=Cotizaciones.DataModel.UserCompanyPreference.GetRepo();
                  return from items in repo.GetAll()
                       where items.UserID == _UserID
                       select items;
            }
        }


        public IQueryable<UserPreference> UserPreferences
        {
            get
            {
                
                  var repo=Cotizaciones.DataModel.UserPreference.GetRepo();
                  return from items in repo.GetAll()
                       where items.UserID == _UserID
                       select items;
            }
        }


        #endregion
        


        int _UserID;
        public int UserID
        {
            get { return _UserID; }
            set
            {
                if(_UserID!=value){
                    _UserID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="UserID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _ShortName;
        public string ShortName
        {
            get { return _ShortName; }
            set
            {
                if(_ShortName!=value){
                    _ShortName=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ShortName");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _Password;
        public string Password
        {
            get { return _Password; }
            set
            {
                if(_Password!=value){
                    _Password=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Password");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _FullName;
        public string FullName
        {
            get { return _FullName; }
            set
            {
                if(_FullName!=value){
                    _FullName=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="FullName");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _Active;
        public string Active
        {
            get { return _Active; }
            set
            {
                if(_Active!=value){
                    _Active=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Active");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _Creator;
        public string Creator
        {
            get { return _Creator; }
            set
            {
                if(_Creator!=value){
                    _Creator=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Creator");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        DateTime _Created;
        public DateTime Created
        {
            get { return _Created; }
            set
            {
                if(_Created!=value){
                    _Created=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Created");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _Modifier;
        public string Modifier
        {
            get { return _Modifier; }
            set
            {
                if(_Modifier!=value){
                    _Modifier=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Modifier");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        DateTime? _Modified;
        public DateTime? Modified
        {
            get { return _Modified; }
            set
            {
                if(_Modified!=value){
                    _Modified=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Modified");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }




        public DbCommand GetUpdateCommand() {

            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        


            
            if(this._dirtyColumns.Count>0)
                _repo.Update(this,provider);
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        

       
        public void Add(IDataProvider provider){





            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
        
        
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        


        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
            
        }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<User, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            

        }

        


        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 

    
    
    /// <summary>
    /// A class which represents the InvoiceMethodType table in the Fersum Database.
    /// </summary>
    public partial class InvoiceMethodType: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<InvoiceMethodType> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<InvoiceMethodType>(new Cotizaciones.DataModel.FersumDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<InvoiceMethodType> testlist){
            SetTestRepo();
            _testRepo._items = testlist;
        }
        public static void Setup(InvoiceMethodType item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                InvoiceMethodType item=new InvoiceMethodType();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<InvoiceMethodType> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        Cotizaciones.DataModel.FersumDB _db;
        public InvoiceMethodType(string connectionString, string providerName) {

            _db=new Cotizaciones.DataModel.FersumDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                InvoiceMethodType.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<InvoiceMethodType>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public InvoiceMethodType(){
             _db=new Cotizaciones.DataModel.FersumDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public InvoiceMethodType(Expression<Func<InvoiceMethodType, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<InvoiceMethodType> GetRepo(string connectionString, string providerName){
            Cotizaciones.DataModel.FersumDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new Cotizaciones.DataModel.FersumDB();
            }else{
                db=new Cotizaciones.DataModel.FersumDB(connectionString, providerName);
            }
            IRepository<InvoiceMethodType> _repo;
            
            if(db.TestMode){
                InvoiceMethodType.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<InvoiceMethodType>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<InvoiceMethodType> GetRepo(){
            return GetRepo("","");
        }
        
        public static InvoiceMethodType SingleOrDefault(Expression<Func<InvoiceMethodType, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            InvoiceMethodType single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static InvoiceMethodType SingleOrDefault(Expression<Func<InvoiceMethodType, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            InvoiceMethodType single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<InvoiceMethodType, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<InvoiceMethodType, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<InvoiceMethodType> Find(Expression<Func<InvoiceMethodType, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<InvoiceMethodType> Find(Expression<Func<InvoiceMethodType, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<InvoiceMethodType> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<InvoiceMethodType> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<InvoiceMethodType> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<InvoiceMethodType> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<InvoiceMethodType> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<InvoiceMethodType> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "InvoiceMethodTypeID";
        }

        public object KeyValue()
        {
            return this.InvoiceMethodTypeID;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
            return this.ShortName.ToString();
        }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(InvoiceMethodType)){
                InvoiceMethodType compare=(InvoiceMethodType)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }


        
        public override int GetHashCode() {
            return this.InvoiceMethodTypeID;
        }
        

        public string DescriptorValue()
        {
            return this.ShortName.ToString();
        }

        public string DescriptorColumn() {
            return "ShortName";
        }
        public static string GetKeyColumn()
        {
            return "InvoiceMethodTypeID";
        }        
        public static string GetDescriptorColumn()
        {
            return "ShortName";
        }
        
        #region ' Foreign Keys '

        #endregion
        


        int _InvoiceMethodTypeID;
        public int InvoiceMethodTypeID
        {
            get { return _InvoiceMethodTypeID; }
            set
            {
                if(_InvoiceMethodTypeID!=value){
                    _InvoiceMethodTypeID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="InvoiceMethodTypeID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _ShortName;
        public string ShortName
        {
            get { return _ShortName; }
            set
            {
                if(_ShortName!=value){
                    _ShortName=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ShortName");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _Description;
        public string Description
        {
            get { return _Description; }
            set
            {
                if(_Description!=value){
                    _Description=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Description");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _Active;
        public string Active
        {
            get { return _Active; }
            set
            {
                if(_Active!=value){
                    _Active=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Active");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _Creator;
        public string Creator
        {
            get { return _Creator; }
            set
            {
                if(_Creator!=value){
                    _Creator=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Creator");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        DateTime _Created;
        public DateTime Created
        {
            get { return _Created; }
            set
            {
                if(_Created!=value){
                    _Created=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Created");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _Modifier;
        public string Modifier
        {
            get { return _Modifier; }
            set
            {
                if(_Modifier!=value){
                    _Modifier=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Modifier");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        DateTime? _Modified;
        public DateTime? Modified
        {
            get { return _Modified; }
            set
            {
                if(_Modified!=value){
                    _Modified=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Modified");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }




        public DbCommand GetUpdateCommand() {

            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        


            
            if(this._dirtyColumns.Count>0)
                _repo.Update(this,provider);
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        

       
        public void Add(IDataProvider provider){





            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
        
        
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        


        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
            
        }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<InvoiceMethodType, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            

        }

        


        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 

    
    
    /// <summary>
    /// A class which represents the ValidPeriodType table in the Fersum Database.
    /// </summary>
    public partial class ValidPeriodType: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<ValidPeriodType> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<ValidPeriodType>(new Cotizaciones.DataModel.FersumDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<ValidPeriodType> testlist){
            SetTestRepo();
            _testRepo._items = testlist;
        }
        public static void Setup(ValidPeriodType item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                ValidPeriodType item=new ValidPeriodType();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<ValidPeriodType> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        Cotizaciones.DataModel.FersumDB _db;
        public ValidPeriodType(string connectionString, string providerName) {

            _db=new Cotizaciones.DataModel.FersumDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                ValidPeriodType.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<ValidPeriodType>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public ValidPeriodType(){
             _db=new Cotizaciones.DataModel.FersumDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public ValidPeriodType(Expression<Func<ValidPeriodType, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<ValidPeriodType> GetRepo(string connectionString, string providerName){
            Cotizaciones.DataModel.FersumDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new Cotizaciones.DataModel.FersumDB();
            }else{
                db=new Cotizaciones.DataModel.FersumDB(connectionString, providerName);
            }
            IRepository<ValidPeriodType> _repo;
            
            if(db.TestMode){
                ValidPeriodType.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<ValidPeriodType>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<ValidPeriodType> GetRepo(){
            return GetRepo("","");
        }
        
        public static ValidPeriodType SingleOrDefault(Expression<Func<ValidPeriodType, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            ValidPeriodType single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static ValidPeriodType SingleOrDefault(Expression<Func<ValidPeriodType, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            ValidPeriodType single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<ValidPeriodType, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<ValidPeriodType, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<ValidPeriodType> Find(Expression<Func<ValidPeriodType, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<ValidPeriodType> Find(Expression<Func<ValidPeriodType, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<ValidPeriodType> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<ValidPeriodType> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<ValidPeriodType> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<ValidPeriodType> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<ValidPeriodType> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<ValidPeriodType> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "ValidPeriodTypeID";
        }

        public object KeyValue()
        {
            return this.ValidPeriodTypeID;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
            return this.ShortName.ToString();
        }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(ValidPeriodType)){
                ValidPeriodType compare=(ValidPeriodType)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }


        
        public override int GetHashCode() {
            return this.ValidPeriodTypeID;
        }
        

        public string DescriptorValue()
        {
            return this.ShortName.ToString();
        }

        public string DescriptorColumn() {
            return "ShortName";
        }
        public static string GetKeyColumn()
        {
            return "ValidPeriodTypeID";
        }        
        public static string GetDescriptorColumn()
        {
            return "ShortName";
        }
        
        #region ' Foreign Keys '

        #endregion
        


        int _ValidPeriodTypeID;
        public int ValidPeriodTypeID
        {
            get { return _ValidPeriodTypeID; }
            set
            {
                if(_ValidPeriodTypeID!=value){
                    _ValidPeriodTypeID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ValidPeriodTypeID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _ShortName;
        public string ShortName
        {
            get { return _ShortName; }
            set
            {
                if(_ShortName!=value){
                    _ShortName=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ShortName");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _Description;
        public string Description
        {
            get { return _Description; }
            set
            {
                if(_Description!=value){
                    _Description=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Description");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _Active;
        public string Active
        {
            get { return _Active; }
            set
            {
                if(_Active!=value){
                    _Active=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Active");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _Creator;
        public string Creator
        {
            get { return _Creator; }
            set
            {
                if(_Creator!=value){
                    _Creator=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Creator");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        DateTime _Created;
        public DateTime Created
        {
            get { return _Created; }
            set
            {
                if(_Created!=value){
                    _Created=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Created");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _Modifier;
        public string Modifier
        {
            get { return _Modifier; }
            set
            {
                if(_Modifier!=value){
                    _Modifier=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Modifier");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        DateTime? _Modified;
        public DateTime? Modified
        {
            get { return _Modified; }
            set
            {
                if(_Modified!=value){
                    _Modified=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Modified");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }




        public DbCommand GetUpdateCommand() {

            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        


            
            if(this._dirtyColumns.Count>0)
                _repo.Update(this,provider);
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        

       
        public void Add(IDataProvider provider){





            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
        
        
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        


        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
            
        }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<ValidPeriodType, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            

        }

        


        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 

    
    
    /// <summary>
    /// A class which represents the Customer table in the Fersum Database.
    /// </summary>
    public partial class Customer: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<Customer> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<Customer>(new Cotizaciones.DataModel.FersumDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<Customer> testlist){
            SetTestRepo();
            _testRepo._items = testlist;
        }
        public static void Setup(Customer item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                Customer item=new Customer();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<Customer> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        Cotizaciones.DataModel.FersumDB _db;
        public Customer(string connectionString, string providerName) {

            _db=new Cotizaciones.DataModel.FersumDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                Customer.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<Customer>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public Customer(){
             _db=new Cotizaciones.DataModel.FersumDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public Customer(Expression<Func<Customer, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<Customer> GetRepo(string connectionString, string providerName){
            Cotizaciones.DataModel.FersumDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new Cotizaciones.DataModel.FersumDB();
            }else{
                db=new Cotizaciones.DataModel.FersumDB(connectionString, providerName);
            }
            IRepository<Customer> _repo;
            
            if(db.TestMode){
                Customer.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<Customer>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<Customer> GetRepo(){
            return GetRepo("","");
        }
        
        public static Customer SingleOrDefault(Expression<Func<Customer, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            Customer single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static Customer SingleOrDefault(Expression<Func<Customer, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            Customer single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<Customer, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<Customer, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<Customer> Find(Expression<Func<Customer, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<Customer> Find(Expression<Func<Customer, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<Customer> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<Customer> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<Customer> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<Customer> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<Customer> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<Customer> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "CustomerID";
        }

        public object KeyValue()
        {
            return this.CustomerID;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
            return this.ShortName.ToString();
        }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(Customer)){
                Customer compare=(Customer)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }


        
        public override int GetHashCode() {
            return this.CustomerID;
        }
        

        public string DescriptorValue()
        {
            return this.ShortName.ToString();
        }

        public string DescriptorColumn() {
            return "ShortName";
        }
        public static string GetKeyColumn()
        {
            return "CustomerID";
        }        
        public static string GetDescriptorColumn()
        {
            return "ShortName";
        }
        
        #region ' Foreign Keys '

        public IQueryable<CustomerContact> CustomerContacts
        {
            get
            {
                
                  var repo=Cotizaciones.DataModel.CustomerContact.GetRepo();
                  return from items in repo.GetAll()
                       where items.CustomerID == _CustomerID
                       select items;
            }
        }


        public IQueryable<Quotation> Quotations
        {
            get
            {
                
                  var repo=Cotizaciones.DataModel.Quotation.GetRepo();
                  return from items in repo.GetAll()
                       where items.CustomerID == _CustomerID
                       select items;
            }
        }


        #endregion
        


        int _CustomerID;
        public int CustomerID
        {
            get { return _CustomerID; }
            set
            {
                if(_CustomerID!=value){
                    _CustomerID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="CustomerID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _ShortName;
        public string ShortName
        {
            get { return _ShortName; }
            set
            {
                if(_ShortName!=value){
                    _ShortName=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ShortName");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _Description;
        public string Description
        {
            get { return _Description; }
            set
            {
                if(_Description!=value){
                    _Description=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Description");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _Active;
        public string Active
        {
            get { return _Active; }
            set
            {
                if(_Active!=value){
                    _Active=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Active");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _Creator;
        public string Creator
        {
            get { return _Creator; }
            set
            {
                if(_Creator!=value){
                    _Creator=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Creator");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        DateTime _Created;
        public DateTime Created
        {
            get { return _Created; }
            set
            {
                if(_Created!=value){
                    _Created=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Created");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _Modifier;
        public string Modifier
        {
            get { return _Modifier; }
            set
            {
                if(_Modifier!=value){
                    _Modifier=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Modifier");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        DateTime? _Modified;
        public DateTime? Modified
        {
            get { return _Modified; }
            set
            {
                if(_Modified!=value){
                    _Modified=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Modified");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }




        public DbCommand GetUpdateCommand() {

            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        


            
            if(this._dirtyColumns.Count>0)
                _repo.Update(this,provider);
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        

       
        public void Add(IDataProvider provider){





            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
        
        
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        


        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
            
        }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<Customer, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            

        }

        


        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 

    
    
    /// <summary>
    /// A class which represents the Company table in the Fersum Database.
    /// </summary>
    public partial class Company: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<Company> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<Company>(new Cotizaciones.DataModel.FersumDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<Company> testlist){
            SetTestRepo();
            _testRepo._items = testlist;
        }
        public static void Setup(Company item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                Company item=new Company();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<Company> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        Cotizaciones.DataModel.FersumDB _db;
        public Company(string connectionString, string providerName) {

            _db=new Cotizaciones.DataModel.FersumDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                Company.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<Company>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public Company(){
             _db=new Cotizaciones.DataModel.FersumDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public Company(Expression<Func<Company, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<Company> GetRepo(string connectionString, string providerName){
            Cotizaciones.DataModel.FersumDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new Cotizaciones.DataModel.FersumDB();
            }else{
                db=new Cotizaciones.DataModel.FersumDB(connectionString, providerName);
            }
            IRepository<Company> _repo;
            
            if(db.TestMode){
                Company.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<Company>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<Company> GetRepo(){
            return GetRepo("","");
        }
        
        public static Company SingleOrDefault(Expression<Func<Company, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            Company single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static Company SingleOrDefault(Expression<Func<Company, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            Company single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<Company, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<Company, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<Company> Find(Expression<Func<Company, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<Company> Find(Expression<Func<Company, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<Company> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<Company> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<Company> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<Company> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<Company> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<Company> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "CompanyID";
        }

        public object KeyValue()
        {
            return this.CompanyID;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
            return this.CompanyName.ToString();
        }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(Company)){
                Company compare=(Company)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }


        
        public override int GetHashCode() {
            return this.CompanyID;
        }
        

        public string DescriptorValue()
        {
            return this.CompanyName.ToString();
        }

        public string DescriptorColumn() {
            return "CompanyName";
        }
        public static string GetKeyColumn()
        {
            return "CompanyID";
        }        
        public static string GetDescriptorColumn()
        {
            return "CompanyName";
        }
        
        #region ' Foreign Keys '

        public IQueryable<UserCompanyPreference> UserCompanyPreferences
        {
            get
            {
                
                  var repo=Cotizaciones.DataModel.UserCompanyPreference.GetRepo();
                  return from items in repo.GetAll()
                       where items.CompanyID == _CompanyID
                       select items;
            }
        }


        #endregion
        


        int _CompanyID;
        public int CompanyID
        {
            get { return _CompanyID; }
            set
            {
                if(_CompanyID!=value){
                    _CompanyID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="CompanyID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _CompanyName;
        public string CompanyName
        {
            get { return _CompanyName; }
            set
            {
                if(_CompanyName!=value){
                    _CompanyName=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="CompanyName");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _CompanyFullName;
        public string CompanyFullName
        {
            get { return _CompanyFullName; }
            set
            {
                if(_CompanyFullName!=value){
                    _CompanyFullName=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="CompanyFullName");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _CompanyCity;
        public string CompanyCity
        {
            get { return _CompanyCity; }
            set
            {
                if(_CompanyCity!=value){
                    _CompanyCity=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="CompanyCity");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _LogoFilePath;
        public string LogoFilePath
        {
            get { return _LogoFilePath; }
            set
            {
                if(_LogoFilePath!=value){
                    _LogoFilePath=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="LogoFilePath");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _Active;
        public string Active
        {
            get { return _Active; }
            set
            {
                if(_Active!=value){
                    _Active=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Active");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _Creator;
        public string Creator
        {
            get { return _Creator; }
            set
            {
                if(_Creator!=value){
                    _Creator=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Creator");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        DateTime _Created;
        public DateTime Created
        {
            get { return _Created; }
            set
            {
                if(_Created!=value){
                    _Created=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Created");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _Modifier;
        public string Modifier
        {
            get { return _Modifier; }
            set
            {
                if(_Modifier!=value){
                    _Modifier=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Modifier");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        DateTime? _Modified;
        public DateTime? Modified
        {
            get { return _Modified; }
            set
            {
                if(_Modified!=value){
                    _Modified=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Modified");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _LogoSize;
        public string LogoSize
        {
            get { return _LogoSize; }
            set
            {
                if(_LogoSize!=value){
                    _LogoSize=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="LogoSize");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _FontName;
        public string FontName
        {
            get { return _FontName; }
            set
            {
                if(_FontName!=value){
                    _FontName=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="FontName");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }




        public DbCommand GetUpdateCommand() {

            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        


            
            if(this._dirtyColumns.Count>0)
                _repo.Update(this,provider);
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        

       
        public void Add(IDataProvider provider){





            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
        
        
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        


        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
            
        }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<Company, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            

        }

        


        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 

    
    
    /// <summary>
    /// A class which represents the ConfigurationKey table in the Fersum Database.
    /// </summary>
    public partial class ConfigurationKey: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<ConfigurationKey> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<ConfigurationKey>(new Cotizaciones.DataModel.FersumDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<ConfigurationKey> testlist){
            SetTestRepo();
            _testRepo._items = testlist;
        }
        public static void Setup(ConfigurationKey item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                ConfigurationKey item=new ConfigurationKey();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<ConfigurationKey> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        Cotizaciones.DataModel.FersumDB _db;
        public ConfigurationKey(string connectionString, string providerName) {

            _db=new Cotizaciones.DataModel.FersumDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                ConfigurationKey.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<ConfigurationKey>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public ConfigurationKey(){
             _db=new Cotizaciones.DataModel.FersumDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public ConfigurationKey(Expression<Func<ConfigurationKey, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<ConfigurationKey> GetRepo(string connectionString, string providerName){
            Cotizaciones.DataModel.FersumDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new Cotizaciones.DataModel.FersumDB();
            }else{
                db=new Cotizaciones.DataModel.FersumDB(connectionString, providerName);
            }
            IRepository<ConfigurationKey> _repo;
            
            if(db.TestMode){
                ConfigurationKey.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<ConfigurationKey>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<ConfigurationKey> GetRepo(){
            return GetRepo("","");
        }
        
        public static ConfigurationKey SingleOrDefault(Expression<Func<ConfigurationKey, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            ConfigurationKey single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static ConfigurationKey SingleOrDefault(Expression<Func<ConfigurationKey, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            ConfigurationKey single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<ConfigurationKey, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<ConfigurationKey, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<ConfigurationKey> Find(Expression<Func<ConfigurationKey, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<ConfigurationKey> Find(Expression<Func<ConfigurationKey, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<ConfigurationKey> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<ConfigurationKey> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<ConfigurationKey> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<ConfigurationKey> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<ConfigurationKey> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<ConfigurationKey> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "ConfigurationKeyID";
        }

        public object KeyValue()
        {
            return this.ConfigurationKeyID;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
            return this.Name.ToString();
        }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(ConfigurationKey)){
                ConfigurationKey compare=(ConfigurationKey)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }


        
        public override int GetHashCode() {
            return this.ConfigurationKeyID;
        }
        

        public string DescriptorValue()
        {
            return this.Name.ToString();
        }

        public string DescriptorColumn() {
            return "Name";
        }
        public static string GetKeyColumn()
        {
            return "ConfigurationKeyID";
        }        
        public static string GetDescriptorColumn()
        {
            return "Name";
        }
        
        #region ' Foreign Keys '

        #endregion
        


        int _ConfigurationKeyID;
        public int ConfigurationKeyID
        {
            get { return _ConfigurationKeyID; }
            set
            {
                if(_ConfigurationKeyID!=value){
                    _ConfigurationKeyID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ConfigurationKeyID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _Name;
        public string Name
        {
            get { return _Name; }
            set
            {
                if(_Name!=value){
                    _Name=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Name");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _Value;
        public string Value
        {
            get { return _Value; }
            set
            {
                if(_Value!=value){
                    _Value=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Value");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _Active;
        public string Active
        {
            get { return _Active; }
            set
            {
                if(_Active!=value){
                    _Active=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Active");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _Creator;
        public string Creator
        {
            get { return _Creator; }
            set
            {
                if(_Creator!=value){
                    _Creator=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Creator");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        DateTime _Created;
        public DateTime Created
        {
            get { return _Created; }
            set
            {
                if(_Created!=value){
                    _Created=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Created");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _Modifier;
        public string Modifier
        {
            get { return _Modifier; }
            set
            {
                if(_Modifier!=value){
                    _Modifier=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Modifier");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        DateTime? _Modified;
        public DateTime? Modified
        {
            get { return _Modified; }
            set
            {
                if(_Modified!=value){
                    _Modified=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Modified");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }




        public DbCommand GetUpdateCommand() {

            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        


            
            if(this._dirtyColumns.Count>0)
                _repo.Update(this,provider);
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        

       
        public void Add(IDataProvider provider){





            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
        
        
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        


        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
            
        }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<ConfigurationKey, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            

        }

        


        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 

    
    
    /// <summary>
    /// A class which represents the CurrencyType table in the Fersum Database.
    /// </summary>
    public partial class CurrencyType: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<CurrencyType> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<CurrencyType>(new Cotizaciones.DataModel.FersumDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<CurrencyType> testlist){
            SetTestRepo();
            _testRepo._items = testlist;
        }
        public static void Setup(CurrencyType item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                CurrencyType item=new CurrencyType();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<CurrencyType> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        Cotizaciones.DataModel.FersumDB _db;
        public CurrencyType(string connectionString, string providerName) {

            _db=new Cotizaciones.DataModel.FersumDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                CurrencyType.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<CurrencyType>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public CurrencyType(){
             _db=new Cotizaciones.DataModel.FersumDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public CurrencyType(Expression<Func<CurrencyType, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<CurrencyType> GetRepo(string connectionString, string providerName){
            Cotizaciones.DataModel.FersumDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new Cotizaciones.DataModel.FersumDB();
            }else{
                db=new Cotizaciones.DataModel.FersumDB(connectionString, providerName);
            }
            IRepository<CurrencyType> _repo;
            
            if(db.TestMode){
                CurrencyType.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<CurrencyType>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<CurrencyType> GetRepo(){
            return GetRepo("","");
        }
        
        public static CurrencyType SingleOrDefault(Expression<Func<CurrencyType, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            CurrencyType single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static CurrencyType SingleOrDefault(Expression<Func<CurrencyType, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            CurrencyType single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<CurrencyType, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<CurrencyType, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<CurrencyType> Find(Expression<Func<CurrencyType, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<CurrencyType> Find(Expression<Func<CurrencyType, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<CurrencyType> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<CurrencyType> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<CurrencyType> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<CurrencyType> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<CurrencyType> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<CurrencyType> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "CurrencyTypeID";
        }

        public object KeyValue()
        {
            return this.CurrencyTypeID;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
            return this.ShortName.ToString();
        }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(CurrencyType)){
                CurrencyType compare=(CurrencyType)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }


        
        public override int GetHashCode() {
            return this.CurrencyTypeID;
        }
        

        public string DescriptorValue()
        {
            return this.ShortName.ToString();
        }

        public string DescriptorColumn() {
            return "ShortName";
        }
        public static string GetKeyColumn()
        {
            return "CurrencyTypeID";
        }        
        public static string GetDescriptorColumn()
        {
            return "ShortName";
        }
        
        #region ' Foreign Keys '

        #endregion
        


        int _CurrencyTypeID;
        public int CurrencyTypeID
        {
            get { return _CurrencyTypeID; }
            set
            {
                if(_CurrencyTypeID!=value){
                    _CurrencyTypeID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="CurrencyTypeID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _ShortName;
        public string ShortName
        {
            get { return _ShortName; }
            set
            {
                if(_ShortName!=value){
                    _ShortName=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ShortName");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _Description;
        public string Description
        {
            get { return _Description; }
            set
            {
                if(_Description!=value){
                    _Description=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Description");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _Active;
        public string Active
        {
            get { return _Active; }
            set
            {
                if(_Active!=value){
                    _Active=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Active");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _Creator;
        public string Creator
        {
            get { return _Creator; }
            set
            {
                if(_Creator!=value){
                    _Creator=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Creator");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        DateTime _Created;
        public DateTime Created
        {
            get { return _Created; }
            set
            {
                if(_Created!=value){
                    _Created=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Created");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _Modifier;
        public string Modifier
        {
            get { return _Modifier; }
            set
            {
                if(_Modifier!=value){
                    _Modifier=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Modifier");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        DateTime? _Modified;
        public DateTime? Modified
        {
            get { return _Modified; }
            set
            {
                if(_Modified!=value){
                    _Modified=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Modified");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }




        public DbCommand GetUpdateCommand() {

            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        


            
            if(this._dirtyColumns.Count>0)
                _repo.Update(this,provider);
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        

       
        public void Add(IDataProvider provider){





            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
        
        
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        


        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
            
        }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<CurrencyType, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            

        }

        


        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 

    
    
    /// <summary>
    /// A class which represents the PaymentType table in the Fersum Database.
    /// </summary>
    public partial class PaymentType: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<PaymentType> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<PaymentType>(new Cotizaciones.DataModel.FersumDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<PaymentType> testlist){
            SetTestRepo();
            _testRepo._items = testlist;
        }
        public static void Setup(PaymentType item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                PaymentType item=new PaymentType();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<PaymentType> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        Cotizaciones.DataModel.FersumDB _db;
        public PaymentType(string connectionString, string providerName) {

            _db=new Cotizaciones.DataModel.FersumDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                PaymentType.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<PaymentType>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public PaymentType(){
             _db=new Cotizaciones.DataModel.FersumDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public PaymentType(Expression<Func<PaymentType, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<PaymentType> GetRepo(string connectionString, string providerName){
            Cotizaciones.DataModel.FersumDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new Cotizaciones.DataModel.FersumDB();
            }else{
                db=new Cotizaciones.DataModel.FersumDB(connectionString, providerName);
            }
            IRepository<PaymentType> _repo;
            
            if(db.TestMode){
                PaymentType.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<PaymentType>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<PaymentType> GetRepo(){
            return GetRepo("","");
        }
        
        public static PaymentType SingleOrDefault(Expression<Func<PaymentType, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            PaymentType single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static PaymentType SingleOrDefault(Expression<Func<PaymentType, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            PaymentType single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<PaymentType, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<PaymentType, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<PaymentType> Find(Expression<Func<PaymentType, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<PaymentType> Find(Expression<Func<PaymentType, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<PaymentType> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<PaymentType> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<PaymentType> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<PaymentType> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<PaymentType> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<PaymentType> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "PaymentTypeID";
        }

        public object KeyValue()
        {
            return this.PaymentTypeID;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
            return this.ShortName.ToString();
        }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(PaymentType)){
                PaymentType compare=(PaymentType)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }


        
        public override int GetHashCode() {
            return this.PaymentTypeID;
        }
        

        public string DescriptorValue()
        {
            return this.ShortName.ToString();
        }

        public string DescriptorColumn() {
            return "ShortName";
        }
        public static string GetKeyColumn()
        {
            return "PaymentTypeID";
        }        
        public static string GetDescriptorColumn()
        {
            return "ShortName";
        }
        
        #region ' Foreign Keys '

        #endregion
        


        int _PaymentTypeID;
        public int PaymentTypeID
        {
            get { return _PaymentTypeID; }
            set
            {
                if(_PaymentTypeID!=value){
                    _PaymentTypeID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="PaymentTypeID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _ShortName;
        public string ShortName
        {
            get { return _ShortName; }
            set
            {
                if(_ShortName!=value){
                    _ShortName=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ShortName");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _Description;
        public string Description
        {
            get { return _Description; }
            set
            {
                if(_Description!=value){
                    _Description=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Description");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _Active;
        public string Active
        {
            get { return _Active; }
            set
            {
                if(_Active!=value){
                    _Active=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Active");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _Creator;
        public string Creator
        {
            get { return _Creator; }
            set
            {
                if(_Creator!=value){
                    _Creator=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Creator");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        DateTime _Created;
        public DateTime Created
        {
            get { return _Created; }
            set
            {
                if(_Created!=value){
                    _Created=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Created");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _Modifier;
        public string Modifier
        {
            get { return _Modifier; }
            set
            {
                if(_Modifier!=value){
                    _Modifier=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Modifier");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        DateTime? _Modified;
        public DateTime? Modified
        {
            get { return _Modified; }
            set
            {
                if(_Modified!=value){
                    _Modified=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Modified");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }




        public DbCommand GetUpdateCommand() {

            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        


            
            if(this._dirtyColumns.Count>0)
                _repo.Update(this,provider);
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        

       
        public void Add(IDataProvider provider){





            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
        
        
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        


        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
            
        }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<PaymentType, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            

        }

        


        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 

    
    
    /// <summary>
    /// A class which represents the PipeSpecification table in the Fersum Database.
    /// </summary>
    public partial class PipeSpecification: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<PipeSpecification> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<PipeSpecification>(new Cotizaciones.DataModel.FersumDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<PipeSpecification> testlist){
            SetTestRepo();
            _testRepo._items = testlist;
        }
        public static void Setup(PipeSpecification item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                PipeSpecification item=new PipeSpecification();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<PipeSpecification> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        Cotizaciones.DataModel.FersumDB _db;
        public PipeSpecification(string connectionString, string providerName) {

            _db=new Cotizaciones.DataModel.FersumDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                PipeSpecification.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<PipeSpecification>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public PipeSpecification(){
             _db=new Cotizaciones.DataModel.FersumDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public PipeSpecification(Expression<Func<PipeSpecification, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<PipeSpecification> GetRepo(string connectionString, string providerName){
            Cotizaciones.DataModel.FersumDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new Cotizaciones.DataModel.FersumDB();
            }else{
                db=new Cotizaciones.DataModel.FersumDB(connectionString, providerName);
            }
            IRepository<PipeSpecification> _repo;
            
            if(db.TestMode){
                PipeSpecification.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<PipeSpecification>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<PipeSpecification> GetRepo(){
            return GetRepo("","");
        }
        
        public static PipeSpecification SingleOrDefault(Expression<Func<PipeSpecification, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            PipeSpecification single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static PipeSpecification SingleOrDefault(Expression<Func<PipeSpecification, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            PipeSpecification single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<PipeSpecification, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<PipeSpecification, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<PipeSpecification> Find(Expression<Func<PipeSpecification, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<PipeSpecification> Find(Expression<Func<PipeSpecification, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<PipeSpecification> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<PipeSpecification> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<PipeSpecification> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<PipeSpecification> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<PipeSpecification> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<PipeSpecification> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "PipeSpecificationID";
        }

        public object KeyValue()
        {
            return this.PipeSpecificationID;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
            return this.PipeSchedule.ToString();
        }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(PipeSpecification)){
                PipeSpecification compare=(PipeSpecification)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }


        
        public override int GetHashCode() {
            return this.PipeSpecificationID;
        }
        

        public string DescriptorValue()
        {
            return this.PipeSchedule.ToString();
        }

        public string DescriptorColumn() {
            return "PipeSchedule";
        }
        public static string GetKeyColumn()
        {
            return "PipeSpecificationID";
        }        
        public static string GetDescriptorColumn()
        {
            return "PipeSchedule";
        }
        
        #region ' Foreign Keys '

        public IQueryable<PipeDiameterType> PipeDiameterTypes
        {
            get
            {
                
                  var repo=Cotizaciones.DataModel.PipeDiameterType.GetRepo();
                  return from items in repo.GetAll()
                       where items.PipeDiameterTypeID == _PipeDiameterTypeID
                       select items;
            }
        }


        #endregion
        


        int _PipeSpecificationID;
        public int PipeSpecificationID
        {
            get { return _PipeSpecificationID; }
            set
            {
                if(_PipeSpecificationID!=value){
                    _PipeSpecificationID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="PipeSpecificationID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        decimal _WallThicknessInches;
        public decimal WallThicknessInches
        {
            get { return _WallThicknessInches; }
            set
            {
                if(_WallThicknessInches!=value){
                    _WallThicknessInches=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="WallThicknessInches");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _PipeSchedule;
        public string PipeSchedule
        {
            get { return _PipeSchedule; }
            set
            {
                if(_PipeSchedule!=value){
                    _PipeSchedule=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="PipeSchedule");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _PipeClass;
        public string PipeClass
        {
            get { return _PipeClass; }
            set
            {
                if(_PipeClass!=value){
                    _PipeClass=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="PipeClass");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        int _PipeDiameterTypeID;
        public int PipeDiameterTypeID
        {
            get { return _PipeDiameterTypeID; }
            set
            {
                if(_PipeDiameterTypeID!=value){
                    _PipeDiameterTypeID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="PipeDiameterTypeID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _Active;
        public string Active
        {
            get { return _Active; }
            set
            {
                if(_Active!=value){
                    _Active=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Active");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _Creator;
        public string Creator
        {
            get { return _Creator; }
            set
            {
                if(_Creator!=value){
                    _Creator=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Creator");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        DateTime _Created;
        public DateTime Created
        {
            get { return _Created; }
            set
            {
                if(_Created!=value){
                    _Created=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Created");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _Modifier;
        public string Modifier
        {
            get { return _Modifier; }
            set
            {
                if(_Modifier!=value){
                    _Modifier=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Modifier");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        DateTime? _Modified;
        public DateTime? Modified
        {
            get { return _Modified; }
            set
            {
                if(_Modified!=value){
                    _Modified=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Modified");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }




        public DbCommand GetUpdateCommand() {

            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        


            
            if(this._dirtyColumns.Count>0)
                _repo.Update(this,provider);
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        

       
        public void Add(IDataProvider provider){





            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
        
        
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        


        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
            
        }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<PipeSpecification, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            

        }

        


        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 

    
    
    /// <summary>
    /// A class which represents the Quotation table in the Fersum Database.
    /// </summary>
    public partial class Quotation: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<Quotation> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<Quotation>(new Cotizaciones.DataModel.FersumDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<Quotation> testlist){
            SetTestRepo();
            _testRepo._items = testlist;
        }
        public static void Setup(Quotation item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                Quotation item=new Quotation();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<Quotation> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        Cotizaciones.DataModel.FersumDB _db;
        public Quotation(string connectionString, string providerName) {

            _db=new Cotizaciones.DataModel.FersumDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                Quotation.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<Quotation>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public Quotation(){
             _db=new Cotizaciones.DataModel.FersumDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public Quotation(Expression<Func<Quotation, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<Quotation> GetRepo(string connectionString, string providerName){
            Cotizaciones.DataModel.FersumDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new Cotizaciones.DataModel.FersumDB();
            }else{
                db=new Cotizaciones.DataModel.FersumDB(connectionString, providerName);
            }
            IRepository<Quotation> _repo;
            
            if(db.TestMode){
                Quotation.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<Quotation>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<Quotation> GetRepo(){
            return GetRepo("","");
        }
        
        public static Quotation SingleOrDefault(Expression<Func<Quotation, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            Quotation single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static Quotation SingleOrDefault(Expression<Func<Quotation, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            Quotation single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<Quotation, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<Quotation, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<Quotation> Find(Expression<Func<Quotation, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<Quotation> Find(Expression<Func<Quotation, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<Quotation> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<Quotation> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<Quotation> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<Quotation> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<Quotation> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<Quotation> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "QuotationID";
        }

        public object KeyValue()
        {
            return this.QuotationID;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
            return this.EmailTo.ToString();
        }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(Quotation)){
                Quotation compare=(Quotation)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }


        
        public override int GetHashCode() {
            return this.QuotationID;
        }
        

        public string DescriptorValue()
        {
            return this.EmailTo.ToString();
        }

        public string DescriptorColumn() {
            return "EmailTo";
        }
        public static string GetKeyColumn()
        {
            return "QuotationID";
        }        
        public static string GetDescriptorColumn()
        {
            return "EmailTo";
        }
        
        #region ' Foreign Keys '

        public IQueryable<Customer> Customers
        {
            get
            {
                
                  var repo=Cotizaciones.DataModel.Customer.GetRepo();
                  return from items in repo.GetAll()
                       where items.CustomerID == _CustomerID
                       select items;
            }
        }


        public IQueryable<CustomerContact> CustomerContacts
        {
            get
            {
                
                  var repo=Cotizaciones.DataModel.CustomerContact.GetRepo();
                  return from items in repo.GetAll()
                       where items.CustomerContactID == _CustomerContactID
                       select items;
            }
        }


        public IQueryable<QuotationStatusType> QuotationStatusTypes
        {
            get
            {
                
                  var repo=Cotizaciones.DataModel.QuotationStatusType.GetRepo();
                  return from items in repo.GetAll()
                       where items.QuotationStatustypeID == _QuotationStatusTypeID
                       select items;
            }
        }


        public IQueryable<QuotationAttachment> QuotationAttachments
        {
            get
            {
                
                  var repo=Cotizaciones.DataModel.QuotationAttachment.GetRepo();
                  return from items in repo.GetAll()
                       where items.QuotationID == _QuotationID
                       select items;
            }
        }


        public IQueryable<QuotationSection> QuotationSections
        {
            get
            {
                
                  var repo=Cotizaciones.DataModel.QuotationSection.GetRepo();
                  return from items in repo.GetAll()
                       where items.QuotationID == _QuotationID
                       select items;
            }
        }


        #endregion
        


        int _QuotationID;
        public int QuotationID
        {
            get { return _QuotationID; }
            set
            {
                if(_QuotationID!=value){
                    _QuotationID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="QuotationID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        int? _CustomerID;
        public int? CustomerID
        {
            get { return _CustomerID; }
            set
            {
                if(_CustomerID!=value){
                    _CustomerID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="CustomerID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        int? _CustomerContactID;
        public int? CustomerContactID
        {
            get { return _CustomerContactID; }
            set
            {
                if(_CustomerContactID!=value){
                    _CustomerContactID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="CustomerContactID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _EmailTo;
        public string EmailTo
        {
            get { return _EmailTo; }
            set
            {
                if(_EmailTo!=value){
                    _EmailTo=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="EmailTo");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        int? _ClonedFromQuotationID;
        public int? ClonedFromQuotationID
        {
            get { return _ClonedFromQuotationID; }
            set
            {
                if(_ClonedFromQuotationID!=value){
                    _ClonedFromQuotationID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ClonedFromQuotationID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _ValidPeriodDescription;
        public string ValidPeriodDescription
        {
            get { return _ValidPeriodDescription; }
            set
            {
                if(_ValidPeriodDescription!=value){
                    _ValidPeriodDescription=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ValidPeriodDescription");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _PaymentDescription;
        public string PaymentDescription
        {
            get { return _PaymentDescription; }
            set
            {
                if(_PaymentDescription!=value){
                    _PaymentDescription=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="PaymentDescription");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _Notes;
        public string Notes
        {
            get { return _Notes; }
            set
            {
                if(_Notes!=value){
                    _Notes=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Notes");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        int _QuotationStatusTypeID;
        public int QuotationStatusTypeID
        {
            get { return _QuotationStatusTypeID; }
            set
            {
                if(_QuotationStatusTypeID!=value){
                    _QuotationStatusTypeID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="QuotationStatusTypeID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _Active;
        public string Active
        {
            get { return _Active; }
            set
            {
                if(_Active!=value){
                    _Active=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Active");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _Creator;
        public string Creator
        {
            get { return _Creator; }
            set
            {
                if(_Creator!=value){
                    _Creator=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Creator");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        DateTime _Created;
        public DateTime Created
        {
            get { return _Created; }
            set
            {
                if(_Created!=value){
                    _Created=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Created");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _Modifier;
        public string Modifier
        {
            get { return _Modifier; }
            set
            {
                if(_Modifier!=value){
                    _Modifier=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Modifier");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        DateTime? _Modified;
        public DateTime? Modified
        {
            get { return _Modified; }
            set
            {
                if(_Modified!=value){
                    _Modified=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Modified");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _InvoiceMethodDescription;
        public string InvoiceMethodDescription
        {
            get { return _InvoiceMethodDescription; }
            set
            {
                if(_InvoiceMethodDescription!=value){
                    _InvoiceMethodDescription=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="InvoiceMethodDescription");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        int? _CompanyID;
        public int? CompanyID
        {
            get { return _CompanyID; }
            set
            {
                if(_CompanyID!=value){
                    _CompanyID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="CompanyID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _FootNoteDescription;
        public string FootNoteDescription
        {
            get { return _FootNoteDescription; }
            set
            {
                if(_FootNoteDescription!=value){
                    _FootNoteDescription=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="FootNoteDescription");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }




        public DbCommand GetUpdateCommand() {

            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        


            
            if(this._dirtyColumns.Count>0)
                _repo.Update(this,provider);
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        

       
        public void Add(IDataProvider provider){





            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
        
        
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        


        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
            
        }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<Quotation, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            

        }

        


        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 

    
    
    /// <summary>
    /// A class which represents the QuotationSection table in the Fersum Database.
    /// </summary>
    public partial class QuotationSection: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<QuotationSection> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<QuotationSection>(new Cotizaciones.DataModel.FersumDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<QuotationSection> testlist){
            SetTestRepo();
            _testRepo._items = testlist;
        }
        public static void Setup(QuotationSection item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                QuotationSection item=new QuotationSection();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<QuotationSection> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        Cotizaciones.DataModel.FersumDB _db;
        public QuotationSection(string connectionString, string providerName) {

            _db=new Cotizaciones.DataModel.FersumDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                QuotationSection.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<QuotationSection>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public QuotationSection(){
             _db=new Cotizaciones.DataModel.FersumDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public QuotationSection(Expression<Func<QuotationSection, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<QuotationSection> GetRepo(string connectionString, string providerName){
            Cotizaciones.DataModel.FersumDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new Cotizaciones.DataModel.FersumDB();
            }else{
                db=new Cotizaciones.DataModel.FersumDB(connectionString, providerName);
            }
            IRepository<QuotationSection> _repo;
            
            if(db.TestMode){
                QuotationSection.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<QuotationSection>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<QuotationSection> GetRepo(){
            return GetRepo("","");
        }
        
        public static QuotationSection SingleOrDefault(Expression<Func<QuotationSection, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            QuotationSection single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static QuotationSection SingleOrDefault(Expression<Func<QuotationSection, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            QuotationSection single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<QuotationSection, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<QuotationSection, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<QuotationSection> Find(Expression<Func<QuotationSection, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<QuotationSection> Find(Expression<Func<QuotationSection, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<QuotationSection> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<QuotationSection> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<QuotationSection> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<QuotationSection> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<QuotationSection> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<QuotationSection> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "QuotationSectionID";
        }

        public object KeyValue()
        {
            return this.QuotationSectionID;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
            return this.Active.ToString();
        }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(QuotationSection)){
                QuotationSection compare=(QuotationSection)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }


        
        public override int GetHashCode() {
            return this.QuotationSectionID;
        }
        

        public string DescriptorValue()
        {
            return this.Active.ToString();
        }

        public string DescriptorColumn() {
            return "Active";
        }
        public static string GetKeyColumn()
        {
            return "QuotationSectionID";
        }        
        public static string GetDescriptorColumn()
        {
            return "Active";
        }
        
        #region ' Foreign Keys '

        public IQueryable<Quotation> Quotations
        {
            get
            {
                
                  var repo=Cotizaciones.DataModel.Quotation.GetRepo();
                  return from items in repo.GetAll()
                       where items.QuotationID == _QuotationID
                       select items;
            }
        }


        public IQueryable<SectionType> SectionTypes
        {
            get
            {
                
                  var repo=Cotizaciones.DataModel.SectionType.GetRepo();
                  return from items in repo.GetAll()
                       where items.SectionTypeID == _SectionTypeID
                       select items;
            }
        }


        public IQueryable<QuotationSectionDetail> QuotationSectionDetails
        {
            get
            {
                
                  var repo=Cotizaciones.DataModel.QuotationSectionDetail.GetRepo();
                  return from items in repo.GetAll()
                       where items.QuotationSectionID == _QuotationSectionID
                       select items;
            }
        }


        #endregion
        


        int _QuotationSectionID;
        public int QuotationSectionID
        {
            get { return _QuotationSectionID; }
            set
            {
                if(_QuotationSectionID!=value){
                    _QuotationSectionID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="QuotationSectionID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        int _QuotationID;
        public int QuotationID
        {
            get { return _QuotationID; }
            set
            {
                if(_QuotationID!=value){
                    _QuotationID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="QuotationID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        int _SectionTypeID;
        public int SectionTypeID
        {
            get { return _SectionTypeID; }
            set
            {
                if(_SectionTypeID!=value){
                    _SectionTypeID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="SectionTypeID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _Active;
        public string Active
        {
            get { return _Active; }
            set
            {
                if(_Active!=value){
                    _Active=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Active");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _Creator;
        public string Creator
        {
            get { return _Creator; }
            set
            {
                if(_Creator!=value){
                    _Creator=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Creator");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        DateTime _Created;
        public DateTime Created
        {
            get { return _Created; }
            set
            {
                if(_Created!=value){
                    _Created=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Created");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _Modifier;
        public string Modifier
        {
            get { return _Modifier; }
            set
            {
                if(_Modifier!=value){
                    _Modifier=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Modifier");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        DateTime? _Modified;
        public DateTime? Modified
        {
            get { return _Modified; }
            set
            {
                if(_Modified!=value){
                    _Modified=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Modified");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _SectionDescription;
        public string SectionDescription
        {
            get { return _SectionDescription; }
            set
            {
                if(_SectionDescription!=value){
                    _SectionDescription=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="SectionDescription");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }




        public DbCommand GetUpdateCommand() {

            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        


            
            if(this._dirtyColumns.Count>0)
                _repo.Update(this,provider);
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        

       
        public void Add(IDataProvider provider){





            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
        
        
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        


        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
            
        }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<QuotationSection, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            

        }

        


        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 

    
    
    /// <summary>
    /// A class which represents the QuotationSectionDetail table in the Fersum Database.
    /// </summary>
    public partial class QuotationSectionDetail: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<QuotationSectionDetail> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<QuotationSectionDetail>(new Cotizaciones.DataModel.FersumDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<QuotationSectionDetail> testlist){
            SetTestRepo();
            _testRepo._items = testlist;
        }
        public static void Setup(QuotationSectionDetail item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                QuotationSectionDetail item=new QuotationSectionDetail();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<QuotationSectionDetail> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        Cotizaciones.DataModel.FersumDB _db;
        public QuotationSectionDetail(string connectionString, string providerName) {

            _db=new Cotizaciones.DataModel.FersumDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                QuotationSectionDetail.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<QuotationSectionDetail>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public QuotationSectionDetail(){
             _db=new Cotizaciones.DataModel.FersumDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public QuotationSectionDetail(Expression<Func<QuotationSectionDetail, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<QuotationSectionDetail> GetRepo(string connectionString, string providerName){
            Cotizaciones.DataModel.FersumDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new Cotizaciones.DataModel.FersumDB();
            }else{
                db=new Cotizaciones.DataModel.FersumDB(connectionString, providerName);
            }
            IRepository<QuotationSectionDetail> _repo;
            
            if(db.TestMode){
                QuotationSectionDetail.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<QuotationSectionDetail>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<QuotationSectionDetail> GetRepo(){
            return GetRepo("","");
        }
        
        public static QuotationSectionDetail SingleOrDefault(Expression<Func<QuotationSectionDetail, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            QuotationSectionDetail single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static QuotationSectionDetail SingleOrDefault(Expression<Func<QuotationSectionDetail, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            QuotationSectionDetail single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<QuotationSectionDetail, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<QuotationSectionDetail, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<QuotationSectionDetail> Find(Expression<Func<QuotationSectionDetail, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<QuotationSectionDetail> Find(Expression<Func<QuotationSectionDetail, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<QuotationSectionDetail> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<QuotationSectionDetail> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<QuotationSectionDetail> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<QuotationSectionDetail> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<QuotationSectionDetail> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<QuotationSectionDetail> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "QuotationSectionDetailID";
        }

        public object KeyValue()
        {
            return this.QuotationSectionDetailID;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
            return this.DeliveryDescription.ToString();
        }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(QuotationSectionDetail)){
                QuotationSectionDetail compare=(QuotationSectionDetail)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }


        
        public override int GetHashCode() {
            return this.QuotationSectionDetailID;
        }
        

        public string DescriptorValue()
        {
            return this.DeliveryDescription.ToString();
        }

        public string DescriptorColumn() {
            return "DeliveryDescription";
        }
        public static string GetKeyColumn()
        {
            return "QuotationSectionDetailID";
        }        
        public static string GetDescriptorColumn()
        {
            return "DeliveryDescription";
        }
        
        #region ' Foreign Keys '

        public IQueryable<QuotationSection> QuotationSections
        {
            get
            {
                
                  var repo=Cotizaciones.DataModel.QuotationSection.GetRepo();
                  return from items in repo.GetAll()
                       where items.QuotationSectionID == _QuotationSectionID
                       select items;
            }
        }


        public IQueryable<UnitType> UnitTypes
        {
            get
            {
                
                  var repo=Cotizaciones.DataModel.UnitType.GetRepo();
                  return from items in repo.GetAll()
                       where items.UnitTypeID == _UnitTypeID
                       select items;
            }
        }


        #endregion
        


        int _QuotationSectionDetailID;
        public int QuotationSectionDetailID
        {
            get { return _QuotationSectionDetailID; }
            set
            {
                if(_QuotationSectionDetailID!=value){
                    _QuotationSectionDetailID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="QuotationSectionDetailID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        int _QuotationSectionID;
        public int QuotationSectionID
        {
            get { return _QuotationSectionID; }
            set
            {
                if(_QuotationSectionID!=value){
                    _QuotationSectionID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="QuotationSectionID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        decimal _Quantity;
        public decimal Quantity
        {
            get { return _Quantity; }
            set
            {
                if(_Quantity!=value){
                    _Quantity=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Quantity");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        decimal _Price;
        public decimal Price
        {
            get { return _Price; }
            set
            {
                if(_Price!=value){
                    _Price=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Price");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _DeliveryDescription;
        public string DeliveryDescription
        {
            get { return _DeliveryDescription; }
            set
            {
                if(_DeliveryDescription!=value){
                    _DeliveryDescription=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="DeliveryDescription");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _DeliveryTimeDescription;
        public string DeliveryTimeDescription
        {
            get { return _DeliveryTimeDescription; }
            set
            {
                if(_DeliveryTimeDescription!=value){
                    _DeliveryTimeDescription=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="DeliveryTimeDescription");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _CurrencyDescription;
        public string CurrencyDescription
        {
            get { return _CurrencyDescription; }
            set
            {
                if(_CurrencyDescription!=value){
                    _CurrencyDescription=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="CurrencyDescription");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        int _UnitTypeID;
        public int UnitTypeID
        {
            get { return _UnitTypeID; }
            set
            {
                if(_UnitTypeID!=value){
                    _UnitTypeID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="UnitTypeID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _Active;
        public string Active
        {
            get { return _Active; }
            set
            {
                if(_Active!=value){
                    _Active=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Active");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _Creator;
        public string Creator
        {
            get { return _Creator; }
            set
            {
                if(_Creator!=value){
                    _Creator=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Creator");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        DateTime _Created;
        public DateTime Created
        {
            get { return _Created; }
            set
            {
                if(_Created!=value){
                    _Created=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Created");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _Modifier;
        public string Modifier
        {
            get { return _Modifier; }
            set
            {
                if(_Modifier!=value){
                    _Modifier=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Modifier");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        DateTime? _Modified;
        public DateTime? Modified
        {
            get { return _Modified; }
            set
            {
                if(_Modified!=value){
                    _Modified=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Modified");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        int _PipeSpecificationID;
        public int PipeSpecificationID
        {
            get { return _PipeSpecificationID; }
            set
            {
                if(_PipeSpecificationID!=value){
                    _PipeSpecificationID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="PipeSpecificationID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _Weight;
        public string Weight
        {
            get { return _Weight; }
            set
            {
                if(_Weight!=value){
                    _Weight=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Weight");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }




        public DbCommand GetUpdateCommand() {

            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        


            
            if(this._dirtyColumns.Count>0)
                _repo.Update(this,provider);
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        

       
        public void Add(IDataProvider provider){





            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
        
        
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        


        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
            
        }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<QuotationSectionDetail, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            

        }

        


        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 

    
    
    /// <summary>
    /// A class which represents the UserPreferences table in the Fersum Database.
    /// </summary>
    public partial class UserPreference: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<UserPreference> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<UserPreference>(new Cotizaciones.DataModel.FersumDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<UserPreference> testlist){
            SetTestRepo();
            _testRepo._items = testlist;
        }
        public static void Setup(UserPreference item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                UserPreference item=new UserPreference();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<UserPreference> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        Cotizaciones.DataModel.FersumDB _db;
        public UserPreference(string connectionString, string providerName) {

            _db=new Cotizaciones.DataModel.FersumDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                UserPreference.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<UserPreference>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public UserPreference(){
             _db=new Cotizaciones.DataModel.FersumDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public UserPreference(Expression<Func<UserPreference, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<UserPreference> GetRepo(string connectionString, string providerName){
            Cotizaciones.DataModel.FersumDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new Cotizaciones.DataModel.FersumDB();
            }else{
                db=new Cotizaciones.DataModel.FersumDB(connectionString, providerName);
            }
            IRepository<UserPreference> _repo;
            
            if(db.TestMode){
                UserPreference.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<UserPreference>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<UserPreference> GetRepo(){
            return GetRepo("","");
        }
        
        public static UserPreference SingleOrDefault(Expression<Func<UserPreference, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            UserPreference single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static UserPreference SingleOrDefault(Expression<Func<UserPreference, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            UserPreference single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<UserPreference, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<UserPreference, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<UserPreference> Find(Expression<Func<UserPreference, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<UserPreference> Find(Expression<Func<UserPreference, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<UserPreference> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<UserPreference> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<UserPreference> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<UserPreference> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<UserPreference> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<UserPreference> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "UserID";
        }

        public object KeyValue()
        {
            return this.UserID;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
            return this.GreetingsMessage.ToString();
        }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(UserPreference)){
                UserPreference compare=(UserPreference)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }


        
        public override int GetHashCode() {
            return this.UserID;
        }
        

        public string DescriptorValue()
        {
            return this.GreetingsMessage.ToString();
        }

        public string DescriptorColumn() {
            return "GreetingsMessage";
        }
        public static string GetKeyColumn()
        {
            return "UserID";
        }        
        public static string GetDescriptorColumn()
        {
            return "GreetingsMessage";
        }
        
        #region ' Foreign Keys '

        public IQueryable<User> Users
        {
            get
            {
                
                  var repo=Cotizaciones.DataModel.User.GetRepo();
                  return from items in repo.GetAll()
                       where items.UserID == _UserID
                       select items;
            }
        }


        #endregion
        


        int _UserID;
        public int UserID
        {
            get { return _UserID; }
            set
            {
                if(_UserID!=value){
                    _UserID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="UserID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _GreetingsMessage;
        public string GreetingsMessage
        {
            get { return _GreetingsMessage; }
            set
            {
                if(_GreetingsMessage!=value){
                    _GreetingsMessage=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="GreetingsMessage");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _DefaultNotes;
        public string DefaultNotes
        {
            get { return _DefaultNotes; }
            set
            {
                if(_DefaultNotes!=value){
                    _DefaultNotes=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="DefaultNotes");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _Active;
        public string Active
        {
            get { return _Active; }
            set
            {
                if(_Active!=value){
                    _Active=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Active");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _Creator;
        public string Creator
        {
            get { return _Creator; }
            set
            {
                if(_Creator!=value){
                    _Creator=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Creator");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        DateTime _Created;
        public DateTime Created
        {
            get { return _Created; }
            set
            {
                if(_Created!=value){
                    _Created=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Created");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _Modifier;
        public string Modifier
        {
            get { return _Modifier; }
            set
            {
                if(_Modifier!=value){
                    _Modifier=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Modifier");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        DateTime? _Modified;
        public DateTime? Modified
        {
            get { return _Modified; }
            set
            {
                if(_Modified!=value){
                    _Modified=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Modified");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _DefaultFootNotes;
        public string DefaultFootNotes
        {
            get { return _DefaultFootNotes; }
            set
            {
                if(_DefaultFootNotes!=value){
                    _DefaultFootNotes=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="DefaultFootNotes");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        int? _DefaultCompanyID;
        public int? DefaultCompanyID
        {
            get { return _DefaultCompanyID; }
            set
            {
                if(_DefaultCompanyID!=value){
                    _DefaultCompanyID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="DefaultCompanyID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }




        public DbCommand GetUpdateCommand() {

            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        


            
            if(this._dirtyColumns.Count>0)
                _repo.Update(this,provider);
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        

       
        public void Add(IDataProvider provider){





            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
        
        
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        


        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
            
        }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<UserPreference, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            

        }

        


        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 

    
    
    /// <summary>
    /// A class which represents the UserCompanyPreferences table in the Fersum Database.
    /// </summary>
    public partial class UserCompanyPreference: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<UserCompanyPreference> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<UserCompanyPreference>(new Cotizaciones.DataModel.FersumDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<UserCompanyPreference> testlist){
            SetTestRepo();
            _testRepo._items = testlist;
        }
        public static void Setup(UserCompanyPreference item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                UserCompanyPreference item=new UserCompanyPreference();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<UserCompanyPreference> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        Cotizaciones.DataModel.FersumDB _db;
        public UserCompanyPreference(string connectionString, string providerName) {

            _db=new Cotizaciones.DataModel.FersumDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                UserCompanyPreference.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<UserCompanyPreference>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public UserCompanyPreference(){
             _db=new Cotizaciones.DataModel.FersumDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public UserCompanyPreference(Expression<Func<UserCompanyPreference, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<UserCompanyPreference> GetRepo(string connectionString, string providerName){
            Cotizaciones.DataModel.FersumDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new Cotizaciones.DataModel.FersumDB();
            }else{
                db=new Cotizaciones.DataModel.FersumDB(connectionString, providerName);
            }
            IRepository<UserCompanyPreference> _repo;
            
            if(db.TestMode){
                UserCompanyPreference.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<UserCompanyPreference>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<UserCompanyPreference> GetRepo(){
            return GetRepo("","");
        }
        
        public static UserCompanyPreference SingleOrDefault(Expression<Func<UserCompanyPreference, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            UserCompanyPreference single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static UserCompanyPreference SingleOrDefault(Expression<Func<UserCompanyPreference, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            UserCompanyPreference single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<UserCompanyPreference, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<UserCompanyPreference, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<UserCompanyPreference> Find(Expression<Func<UserCompanyPreference, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<UserCompanyPreference> Find(Expression<Func<UserCompanyPreference, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<UserCompanyPreference> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<UserCompanyPreference> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<UserCompanyPreference> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<UserCompanyPreference> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<UserCompanyPreference> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<UserCompanyPreference> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "CompanyID";
        }

        public object KeyValue()
        {
            return this.CompanyID;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
            return this.CC.ToString();
        }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(UserCompanyPreference)){
                UserCompanyPreference compare=(UserCompanyPreference)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }


        
        public override int GetHashCode() {
            return this.CompanyID;
        }
        

        public string DescriptorValue()
        {
            return this.CC.ToString();
        }

        public string DescriptorColumn() {
            return "CC";
        }
        public static string GetKeyColumn()
        {
            return "CompanyID";
        }        
        public static string GetDescriptorColumn()
        {
            return "CC";
        }
        
        #region ' Foreign Keys '

        public IQueryable<Company> Companies
        {
            get
            {
                
                  var repo=Cotizaciones.DataModel.Company.GetRepo();
                  return from items in repo.GetAll()
                       where items.CompanyID == _CompanyID
                       select items;
            }
        }


        public IQueryable<User> Users
        {
            get
            {
                
                  var repo=Cotizaciones.DataModel.User.GetRepo();
                  return from items in repo.GetAll()
                       where items.UserID == _UserID
                       select items;
            }
        }


        #endregion
        


        int _UserID;
        public int UserID
        {
            get { return _UserID; }
            set
            {
                if(_UserID!=value){
                    _UserID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="UserID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        int _CompanyID;
        public int CompanyID
        {
            get { return _CompanyID; }
            set
            {
                if(_CompanyID!=value){
                    _CompanyID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="CompanyID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _CC;
        public string CC
        {
            get { return _CC; }
            set
            {
                if(_CC!=value){
                    _CC=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="CC");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _Signature;
        public string Signature
        {
            get { return _Signature; }
            set
            {
                if(_Signature!=value){
                    _Signature=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Signature");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _EmailAddress;
        public string EmailAddress
        {
            get { return _EmailAddress; }
            set
            {
                if(_EmailAddress!=value){
                    _EmailAddress=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="EmailAddress");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _Active;
        public string Active
        {
            get { return _Active; }
            set
            {
                if(_Active!=value){
                    _Active=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Active");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _Creator;
        public string Creator
        {
            get { return _Creator; }
            set
            {
                if(_Creator!=value){
                    _Creator=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Creator");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        DateTime _Created;
        public DateTime Created
        {
            get { return _Created; }
            set
            {
                if(_Created!=value){
                    _Created=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Created");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _Modifier;
        public string Modifier
        {
            get { return _Modifier; }
            set
            {
                if(_Modifier!=value){
                    _Modifier=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Modifier");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        DateTime? _Modified;
        public DateTime? Modified
        {
            get { return _Modified; }
            set
            {
                if(_Modified!=value){
                    _Modified=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Modified");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }




        public DbCommand GetUpdateCommand() {

            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        


            
            if(this._dirtyColumns.Count>0)
                _repo.Update(this,provider);
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        

       
        public void Add(IDataProvider provider){





            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
        
        
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        


        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
            
        }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<UserCompanyPreference, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            

        }

        


        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 

    
    
    /// <summary>
    /// A class which represents the CustomerContact table in the Fersum Database.
    /// </summary>
    public partial class CustomerContact: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<CustomerContact> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<CustomerContact>(new Cotizaciones.DataModel.FersumDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<CustomerContact> testlist){
            SetTestRepo();
            _testRepo._items = testlist;
        }
        public static void Setup(CustomerContact item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                CustomerContact item=new CustomerContact();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<CustomerContact> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        Cotizaciones.DataModel.FersumDB _db;
        public CustomerContact(string connectionString, string providerName) {

            _db=new Cotizaciones.DataModel.FersumDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                CustomerContact.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<CustomerContact>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public CustomerContact(){
             _db=new Cotizaciones.DataModel.FersumDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public CustomerContact(Expression<Func<CustomerContact, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<CustomerContact> GetRepo(string connectionString, string providerName){
            Cotizaciones.DataModel.FersumDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new Cotizaciones.DataModel.FersumDB();
            }else{
                db=new Cotizaciones.DataModel.FersumDB(connectionString, providerName);
            }
            IRepository<CustomerContact> _repo;
            
            if(db.TestMode){
                CustomerContact.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<CustomerContact>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<CustomerContact> GetRepo(){
            return GetRepo("","");
        }
        
        public static CustomerContact SingleOrDefault(Expression<Func<CustomerContact, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            CustomerContact single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static CustomerContact SingleOrDefault(Expression<Func<CustomerContact, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            CustomerContact single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<CustomerContact, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<CustomerContact, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<CustomerContact> Find(Expression<Func<CustomerContact, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<CustomerContact> Find(Expression<Func<CustomerContact, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<CustomerContact> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<CustomerContact> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<CustomerContact> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<CustomerContact> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<CustomerContact> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<CustomerContact> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "CustomerContactID";
        }

        public object KeyValue()
        {
            return this.CustomerContactID;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
            return this.ContactName.ToString();
        }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(CustomerContact)){
                CustomerContact compare=(CustomerContact)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }


        
        public override int GetHashCode() {
            return this.CustomerContactID;
        }
        

        public string DescriptorValue()
        {
            return this.ContactName.ToString();
        }

        public string DescriptorColumn() {
            return "ContactName";
        }
        public static string GetKeyColumn()
        {
            return "CustomerContactID";
        }        
        public static string GetDescriptorColumn()
        {
            return "ContactName";
        }
        
        #region ' Foreign Keys '

        public IQueryable<Customer> Customers
        {
            get
            {
                
                  var repo=Cotizaciones.DataModel.Customer.GetRepo();
                  return from items in repo.GetAll()
                       where items.CustomerID == _CustomerID
                       select items;
            }
        }


        public IQueryable<Quotation> Quotations
        {
            get
            {
                
                  var repo=Cotizaciones.DataModel.Quotation.GetRepo();
                  return from items in repo.GetAll()
                       where items.CustomerContactID == _CustomerContactID
                       select items;
            }
        }


        #endregion
        


        int _CustomerContactID;
        public int CustomerContactID
        {
            get { return _CustomerContactID; }
            set
            {
                if(_CustomerContactID!=value){
                    _CustomerContactID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="CustomerContactID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _ContactName;
        public string ContactName
        {
            get { return _ContactName; }
            set
            {
                if(_ContactName!=value){
                    _ContactName=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ContactName");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _Email;
        public string Email
        {
            get { return _Email; }
            set
            {
                if(_Email!=value){
                    _Email=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Email");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        int _CustomerID;
        public int CustomerID
        {
            get { return _CustomerID; }
            set
            {
                if(_CustomerID!=value){
                    _CustomerID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="CustomerID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _Active;
        public string Active
        {
            get { return _Active; }
            set
            {
                if(_Active!=value){
                    _Active=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Active");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _Creator;
        public string Creator
        {
            get { return _Creator; }
            set
            {
                if(_Creator!=value){
                    _Creator=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Creator");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        DateTime _Created;
        public DateTime Created
        {
            get { return _Created; }
            set
            {
                if(_Created!=value){
                    _Created=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Created");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _Modifier;
        public string Modifier
        {
            get { return _Modifier; }
            set
            {
                if(_Modifier!=value){
                    _Modifier=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Modifier");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        DateTime? _Modified;
        public DateTime? Modified
        {
            get { return _Modified; }
            set
            {
                if(_Modified!=value){
                    _Modified=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Modified");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }




        public DbCommand GetUpdateCommand() {

            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        


            
            if(this._dirtyColumns.Count>0)
                _repo.Update(this,provider);
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        

       
        public void Add(IDataProvider provider){





            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
        
        
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        


        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
            
        }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<CustomerContact, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            

        }

        


        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 

    
    
    /// <summary>
    /// A class which represents the QuotationAttachment table in the Fersum Database.
    /// </summary>
    public partial class QuotationAttachment: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<QuotationAttachment> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<QuotationAttachment>(new Cotizaciones.DataModel.FersumDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<QuotationAttachment> testlist){
            SetTestRepo();
            _testRepo._items = testlist;
        }
        public static void Setup(QuotationAttachment item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                QuotationAttachment item=new QuotationAttachment();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<QuotationAttachment> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        Cotizaciones.DataModel.FersumDB _db;
        public QuotationAttachment(string connectionString, string providerName) {

            _db=new Cotizaciones.DataModel.FersumDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                QuotationAttachment.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<QuotationAttachment>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public QuotationAttachment(){
             _db=new Cotizaciones.DataModel.FersumDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public QuotationAttachment(Expression<Func<QuotationAttachment, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<QuotationAttachment> GetRepo(string connectionString, string providerName){
            Cotizaciones.DataModel.FersumDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new Cotizaciones.DataModel.FersumDB();
            }else{
                db=new Cotizaciones.DataModel.FersumDB(connectionString, providerName);
            }
            IRepository<QuotationAttachment> _repo;
            
            if(db.TestMode){
                QuotationAttachment.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<QuotationAttachment>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<QuotationAttachment> GetRepo(){
            return GetRepo("","");
        }
        
        public static QuotationAttachment SingleOrDefault(Expression<Func<QuotationAttachment, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            QuotationAttachment single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static QuotationAttachment SingleOrDefault(Expression<Func<QuotationAttachment, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            QuotationAttachment single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<QuotationAttachment, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<QuotationAttachment, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<QuotationAttachment> Find(Expression<Func<QuotationAttachment, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<QuotationAttachment> Find(Expression<Func<QuotationAttachment, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<QuotationAttachment> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<QuotationAttachment> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<QuotationAttachment> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<QuotationAttachment> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<QuotationAttachment> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<QuotationAttachment> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "QuotationAttachmentID";
        }

        public object KeyValue()
        {
            return this.QuotationAttachmentID;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
            return this.ExternalFileName.ToString();
        }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(QuotationAttachment)){
                QuotationAttachment compare=(QuotationAttachment)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }


        
        public override int GetHashCode() {
            return this.QuotationAttachmentID;
        }
        

        public string DescriptorValue()
        {
            return this.ExternalFileName.ToString();
        }

        public string DescriptorColumn() {
            return "ExternalFileName";
        }
        public static string GetKeyColumn()
        {
            return "QuotationAttachmentID";
        }        
        public static string GetDescriptorColumn()
        {
            return "ExternalFileName";
        }
        
        #region ' Foreign Keys '

        public IQueryable<Quotation> Quotations
        {
            get
            {
                
                  var repo=Cotizaciones.DataModel.Quotation.GetRepo();
                  return from items in repo.GetAll()
                       where items.QuotationID == _QuotationID
                       select items;
            }
        }


        #endregion
        


        int _QuotationAttachmentID;
        public int QuotationAttachmentID
        {
            get { return _QuotationAttachmentID; }
            set
            {
                if(_QuotationAttachmentID!=value){
                    _QuotationAttachmentID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="QuotationAttachmentID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        int _QuotationID;
        public int QuotationID
        {
            get { return _QuotationID; }
            set
            {
                if(_QuotationID!=value){
                    _QuotationID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="QuotationID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _ExternalFileName;
        public string ExternalFileName
        {
            get { return _ExternalFileName; }
            set
            {
                if(_ExternalFileName!=value){
                    _ExternalFileName=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ExternalFileName");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _Active;
        public string Active
        {
            get { return _Active; }
            set
            {
                if(_Active!=value){
                    _Active=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Active");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _Creator;
        public string Creator
        {
            get { return _Creator; }
            set
            {
                if(_Creator!=value){
                    _Creator=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Creator");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        DateTime _Created;
        public DateTime Created
        {
            get { return _Created; }
            set
            {
                if(_Created!=value){
                    _Created=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Created");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _Modifier;
        public string Modifier
        {
            get { return _Modifier; }
            set
            {
                if(_Modifier!=value){
                    _Modifier=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Modifier");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        DateTime? _Modified;
        public DateTime? Modified
        {
            get { return _Modified; }
            set
            {
                if(_Modified!=value){
                    _Modified=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Modified");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _QuotationFileIndicator;
        public string QuotationFileIndicator
        {
            get { return _QuotationFileIndicator; }
            set
            {
                if(_QuotationFileIndicator!=value){
                    _QuotationFileIndicator=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="QuotationFileIndicator");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }




        public DbCommand GetUpdateCommand() {

            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        


            
            if(this._dirtyColumns.Count>0)
                _repo.Update(this,provider);
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        

       
        public void Add(IDataProvider provider){





            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
        
        
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        


        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
            
        }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<QuotationAttachment, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            

        }

        


        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 

    
    
    /// <summary>
    /// A class which represents the DeliveryTimeType table in the Fersum Database.
    /// </summary>
    public partial class DeliveryTimeType: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<DeliveryTimeType> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<DeliveryTimeType>(new Cotizaciones.DataModel.FersumDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<DeliveryTimeType> testlist){
            SetTestRepo();
            _testRepo._items = testlist;
        }
        public static void Setup(DeliveryTimeType item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                DeliveryTimeType item=new DeliveryTimeType();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<DeliveryTimeType> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        Cotizaciones.DataModel.FersumDB _db;
        public DeliveryTimeType(string connectionString, string providerName) {

            _db=new Cotizaciones.DataModel.FersumDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                DeliveryTimeType.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<DeliveryTimeType>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public DeliveryTimeType(){
             _db=new Cotizaciones.DataModel.FersumDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public DeliveryTimeType(Expression<Func<DeliveryTimeType, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<DeliveryTimeType> GetRepo(string connectionString, string providerName){
            Cotizaciones.DataModel.FersumDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new Cotizaciones.DataModel.FersumDB();
            }else{
                db=new Cotizaciones.DataModel.FersumDB(connectionString, providerName);
            }
            IRepository<DeliveryTimeType> _repo;
            
            if(db.TestMode){
                DeliveryTimeType.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<DeliveryTimeType>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<DeliveryTimeType> GetRepo(){
            return GetRepo("","");
        }
        
        public static DeliveryTimeType SingleOrDefault(Expression<Func<DeliveryTimeType, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            DeliveryTimeType single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static DeliveryTimeType SingleOrDefault(Expression<Func<DeliveryTimeType, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            DeliveryTimeType single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<DeliveryTimeType, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<DeliveryTimeType, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<DeliveryTimeType> Find(Expression<Func<DeliveryTimeType, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<DeliveryTimeType> Find(Expression<Func<DeliveryTimeType, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<DeliveryTimeType> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<DeliveryTimeType> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<DeliveryTimeType> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<DeliveryTimeType> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<DeliveryTimeType> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<DeliveryTimeType> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "DeliveryTimeTypeID";
        }

        public object KeyValue()
        {
            return this.DeliveryTimeTypeID;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
            return this.ShortName.ToString();
        }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(DeliveryTimeType)){
                DeliveryTimeType compare=(DeliveryTimeType)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }


        
        public override int GetHashCode() {
            return this.DeliveryTimeTypeID;
        }
        

        public string DescriptorValue()
        {
            return this.ShortName.ToString();
        }

        public string DescriptorColumn() {
            return "ShortName";
        }
        public static string GetKeyColumn()
        {
            return "DeliveryTimeTypeID";
        }        
        public static string GetDescriptorColumn()
        {
            return "ShortName";
        }
        
        #region ' Foreign Keys '

        #endregion
        


        int _DeliveryTimeTypeID;
        public int DeliveryTimeTypeID
        {
            get { return _DeliveryTimeTypeID; }
            set
            {
                if(_DeliveryTimeTypeID!=value){
                    _DeliveryTimeTypeID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="DeliveryTimeTypeID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _ShortName;
        public string ShortName
        {
            get { return _ShortName; }
            set
            {
                if(_ShortName!=value){
                    _ShortName=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ShortName");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _Description;
        public string Description
        {
            get { return _Description; }
            set
            {
                if(_Description!=value){
                    _Description=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Description");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _Active;
        public string Active
        {
            get { return _Active; }
            set
            {
                if(_Active!=value){
                    _Active=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Active");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _Creator;
        public string Creator
        {
            get { return _Creator; }
            set
            {
                if(_Creator!=value){
                    _Creator=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Creator");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        DateTime _Created;
        public DateTime Created
        {
            get { return _Created; }
            set
            {
                if(_Created!=value){
                    _Created=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Created");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _Modifier;
        public string Modifier
        {
            get { return _Modifier; }
            set
            {
                if(_Modifier!=value){
                    _Modifier=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Modifier");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        DateTime? _Modified;
        public DateTime? Modified
        {
            get { return _Modified; }
            set
            {
                if(_Modified!=value){
                    _Modified=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Modified");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }




        public DbCommand GetUpdateCommand() {

            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        


            
            if(this._dirtyColumns.Count>0)
                _repo.Update(this,provider);
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        

       
        public void Add(IDataProvider provider){





            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
        
        
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        


        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
            
        }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<DeliveryTimeType, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            

        }

        


        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 

    
    
    /// <summary>
    /// A class which represents the DeliveryType table in the Fersum Database.
    /// </summary>
    public partial class DeliveryType: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<DeliveryType> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<DeliveryType>(new Cotizaciones.DataModel.FersumDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<DeliveryType> testlist){
            SetTestRepo();
            _testRepo._items = testlist;
        }
        public static void Setup(DeliveryType item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                DeliveryType item=new DeliveryType();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<DeliveryType> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        Cotizaciones.DataModel.FersumDB _db;
        public DeliveryType(string connectionString, string providerName) {

            _db=new Cotizaciones.DataModel.FersumDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                DeliveryType.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<DeliveryType>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public DeliveryType(){
             _db=new Cotizaciones.DataModel.FersumDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public DeliveryType(Expression<Func<DeliveryType, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<DeliveryType> GetRepo(string connectionString, string providerName){
            Cotizaciones.DataModel.FersumDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new Cotizaciones.DataModel.FersumDB();
            }else{
                db=new Cotizaciones.DataModel.FersumDB(connectionString, providerName);
            }
            IRepository<DeliveryType> _repo;
            
            if(db.TestMode){
                DeliveryType.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<DeliveryType>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<DeliveryType> GetRepo(){
            return GetRepo("","");
        }
        
        public static DeliveryType SingleOrDefault(Expression<Func<DeliveryType, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            DeliveryType single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static DeliveryType SingleOrDefault(Expression<Func<DeliveryType, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            DeliveryType single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<DeliveryType, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<DeliveryType, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<DeliveryType> Find(Expression<Func<DeliveryType, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<DeliveryType> Find(Expression<Func<DeliveryType, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<DeliveryType> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<DeliveryType> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<DeliveryType> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<DeliveryType> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<DeliveryType> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<DeliveryType> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "DeliveryTypeID";
        }

        public object KeyValue()
        {
            return this.DeliveryTypeID;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
            return this.ShortName.ToString();
        }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(DeliveryType)){
                DeliveryType compare=(DeliveryType)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }


        
        public override int GetHashCode() {
            return this.DeliveryTypeID;
        }
        

        public string DescriptorValue()
        {
            return this.ShortName.ToString();
        }

        public string DescriptorColumn() {
            return "ShortName";
        }
        public static string GetKeyColumn()
        {
            return "DeliveryTypeID";
        }        
        public static string GetDescriptorColumn()
        {
            return "ShortName";
        }
        
        #region ' Foreign Keys '

        #endregion
        


        int _DeliveryTypeID;
        public int DeliveryTypeID
        {
            get { return _DeliveryTypeID; }
            set
            {
                if(_DeliveryTypeID!=value){
                    _DeliveryTypeID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="DeliveryTypeID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _ShortName;
        public string ShortName
        {
            get { return _ShortName; }
            set
            {
                if(_ShortName!=value){
                    _ShortName=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ShortName");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _Description;
        public string Description
        {
            get { return _Description; }
            set
            {
                if(_Description!=value){
                    _Description=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Description");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _Active;
        public string Active
        {
            get { return _Active; }
            set
            {
                if(_Active!=value){
                    _Active=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Active");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _Creator;
        public string Creator
        {
            get { return _Creator; }
            set
            {
                if(_Creator!=value){
                    _Creator=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Creator");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        DateTime _Created;
        public DateTime Created
        {
            get { return _Created; }
            set
            {
                if(_Created!=value){
                    _Created=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Created");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _Modifier;
        public string Modifier
        {
            get { return _Modifier; }
            set
            {
                if(_Modifier!=value){
                    _Modifier=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Modifier");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        DateTime? _Modified;
        public DateTime? Modified
        {
            get { return _Modified; }
            set
            {
                if(_Modified!=value){
                    _Modified=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Modified");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }




        public DbCommand GetUpdateCommand() {

            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        


            
            if(this._dirtyColumns.Count>0)
                _repo.Update(this,provider);
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        

       
        public void Add(IDataProvider provider){





            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
        
        
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        


        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
            
        }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<DeliveryType, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            

        }

        


        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 

    
    
    /// <summary>
    /// A class which represents the PipeDiameterType table in the Fersum Database.
    /// </summary>
    public partial class PipeDiameterType: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<PipeDiameterType> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<PipeDiameterType>(new Cotizaciones.DataModel.FersumDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<PipeDiameterType> testlist){
            SetTestRepo();
            _testRepo._items = testlist;
        }
        public static void Setup(PipeDiameterType item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                PipeDiameterType item=new PipeDiameterType();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<PipeDiameterType> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        Cotizaciones.DataModel.FersumDB _db;
        public PipeDiameterType(string connectionString, string providerName) {

            _db=new Cotizaciones.DataModel.FersumDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                PipeDiameterType.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<PipeDiameterType>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public PipeDiameterType(){
             _db=new Cotizaciones.DataModel.FersumDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public PipeDiameterType(Expression<Func<PipeDiameterType, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<PipeDiameterType> GetRepo(string connectionString, string providerName){
            Cotizaciones.DataModel.FersumDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new Cotizaciones.DataModel.FersumDB();
            }else{
                db=new Cotizaciones.DataModel.FersumDB(connectionString, providerName);
            }
            IRepository<PipeDiameterType> _repo;
            
            if(db.TestMode){
                PipeDiameterType.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<PipeDiameterType>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<PipeDiameterType> GetRepo(){
            return GetRepo("","");
        }
        
        public static PipeDiameterType SingleOrDefault(Expression<Func<PipeDiameterType, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            PipeDiameterType single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static PipeDiameterType SingleOrDefault(Expression<Func<PipeDiameterType, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            PipeDiameterType single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<PipeDiameterType, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<PipeDiameterType, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<PipeDiameterType> Find(Expression<Func<PipeDiameterType, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<PipeDiameterType> Find(Expression<Func<PipeDiameterType, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<PipeDiameterType> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<PipeDiameterType> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<PipeDiameterType> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<PipeDiameterType> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<PipeDiameterType> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<PipeDiameterType> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "PipeDiameterTypeID";
        }

        public object KeyValue()
        {
            return this.PipeDiameterTypeID;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
            return this.ShortName.ToString();
        }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(PipeDiameterType)){
                PipeDiameterType compare=(PipeDiameterType)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }


        
        public override int GetHashCode() {
            return this.PipeDiameterTypeID;
        }
        

        public string DescriptorValue()
        {
            return this.ShortName.ToString();
        }

        public string DescriptorColumn() {
            return "ShortName";
        }
        public static string GetKeyColumn()
        {
            return "PipeDiameterTypeID";
        }        
        public static string GetDescriptorColumn()
        {
            return "ShortName";
        }
        
        #region ' Foreign Keys '

        public IQueryable<PipeSpecification> PipeSpecifications
        {
            get
            {
                
                  var repo=Cotizaciones.DataModel.PipeSpecification.GetRepo();
                  return from items in repo.GetAll()
                       where items.PipeDiameterTypeID == _PipeDiameterTypeID
                       select items;
            }
        }


        #endregion
        


        int _PipeDiameterTypeID;
        public int PipeDiameterTypeID
        {
            get { return _PipeDiameterTypeID; }
            set
            {
                if(_PipeDiameterTypeID!=value){
                    _PipeDiameterTypeID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="PipeDiameterTypeID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _ShortName;
        public string ShortName
        {
            get { return _ShortName; }
            set
            {
                if(_ShortName!=value){
                    _ShortName=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ShortName");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _Description;
        public string Description
        {
            get { return _Description; }
            set
            {
                if(_Description!=value){
                    _Description=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Description");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        decimal _ExternalDiameterInches;
        public decimal ExternalDiameterInches
        {
            get { return _ExternalDiameterInches; }
            set
            {
                if(_ExternalDiameterInches!=value){
                    _ExternalDiameterInches=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ExternalDiameterInches");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _Active;
        public string Active
        {
            get { return _Active; }
            set
            {
                if(_Active!=value){
                    _Active=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Active");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _Creator;
        public string Creator
        {
            get { return _Creator; }
            set
            {
                if(_Creator!=value){
                    _Creator=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Creator");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        DateTime _Created;
        public DateTime Created
        {
            get { return _Created; }
            set
            {
                if(_Created!=value){
                    _Created=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Created");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _Modifier;
        public string Modifier
        {
            get { return _Modifier; }
            set
            {
                if(_Modifier!=value){
                    _Modifier=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Modifier");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        DateTime? _Modified;
        public DateTime? Modified
        {
            get { return _Modified; }
            set
            {
                if(_Modified!=value){
                    _Modified=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Modified");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }




        public DbCommand GetUpdateCommand() {

            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        


            
            if(this._dirtyColumns.Count>0)
                _repo.Update(this,provider);
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        

       
        public void Add(IDataProvider provider){





            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
        
        
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        


        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
            
        }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<PipeDiameterType, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            

        }

        


        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 

    
    
    /// <summary>
    /// A class which represents the QuotationStatusType table in the Fersum Database.
    /// </summary>
    public partial class QuotationStatusType: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<QuotationStatusType> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<QuotationStatusType>(new Cotizaciones.DataModel.FersumDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<QuotationStatusType> testlist){
            SetTestRepo();
            _testRepo._items = testlist;
        }
        public static void Setup(QuotationStatusType item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                QuotationStatusType item=new QuotationStatusType();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<QuotationStatusType> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        Cotizaciones.DataModel.FersumDB _db;
        public QuotationStatusType(string connectionString, string providerName) {

            _db=new Cotizaciones.DataModel.FersumDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                QuotationStatusType.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<QuotationStatusType>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public QuotationStatusType(){
             _db=new Cotizaciones.DataModel.FersumDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public QuotationStatusType(Expression<Func<QuotationStatusType, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<QuotationStatusType> GetRepo(string connectionString, string providerName){
            Cotizaciones.DataModel.FersumDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new Cotizaciones.DataModel.FersumDB();
            }else{
                db=new Cotizaciones.DataModel.FersumDB(connectionString, providerName);
            }
            IRepository<QuotationStatusType> _repo;
            
            if(db.TestMode){
                QuotationStatusType.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<QuotationStatusType>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<QuotationStatusType> GetRepo(){
            return GetRepo("","");
        }
        
        public static QuotationStatusType SingleOrDefault(Expression<Func<QuotationStatusType, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            QuotationStatusType single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static QuotationStatusType SingleOrDefault(Expression<Func<QuotationStatusType, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            QuotationStatusType single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<QuotationStatusType, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<QuotationStatusType, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<QuotationStatusType> Find(Expression<Func<QuotationStatusType, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<QuotationStatusType> Find(Expression<Func<QuotationStatusType, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<QuotationStatusType> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<QuotationStatusType> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<QuotationStatusType> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<QuotationStatusType> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<QuotationStatusType> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<QuotationStatusType> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "QuotationStatustypeID";
        }

        public object KeyValue()
        {
            return this.QuotationStatustypeID;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
            return this.ShortName.ToString();
        }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(QuotationStatusType)){
                QuotationStatusType compare=(QuotationStatusType)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }


        
        public override int GetHashCode() {
            return this.QuotationStatustypeID;
        }
        

        public string DescriptorValue()
        {
            return this.ShortName.ToString();
        }

        public string DescriptorColumn() {
            return "ShortName";
        }
        public static string GetKeyColumn()
        {
            return "QuotationStatustypeID";
        }        
        public static string GetDescriptorColumn()
        {
            return "ShortName";
        }
        
        #region ' Foreign Keys '

        public IQueryable<Quotation> Quotations
        {
            get
            {
                
                  var repo=Cotizaciones.DataModel.Quotation.GetRepo();
                  return from items in repo.GetAll()
                       where items.QuotationStatusTypeID == _QuotationStatustypeID
                       select items;
            }
        }


        #endregion
        


        int _QuotationStatustypeID;
        public int QuotationStatustypeID
        {
            get { return _QuotationStatustypeID; }
            set
            {
                if(_QuotationStatustypeID!=value){
                    _QuotationStatustypeID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="QuotationStatustypeID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _ShortName;
        public string ShortName
        {
            get { return _ShortName; }
            set
            {
                if(_ShortName!=value){
                    _ShortName=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ShortName");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _Description;
        public string Description
        {
            get { return _Description; }
            set
            {
                if(_Description!=value){
                    _Description=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Description");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _Active;
        public string Active
        {
            get { return _Active; }
            set
            {
                if(_Active!=value){
                    _Active=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Active");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _Creator;
        public string Creator
        {
            get { return _Creator; }
            set
            {
                if(_Creator!=value){
                    _Creator=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Creator");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        DateTime _Created;
        public DateTime Created
        {
            get { return _Created; }
            set
            {
                if(_Created!=value){
                    _Created=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Created");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _Modifier;
        public string Modifier
        {
            get { return _Modifier; }
            set
            {
                if(_Modifier!=value){
                    _Modifier=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Modifier");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        DateTime? _Modified;
        public DateTime? Modified
        {
            get { return _Modified; }
            set
            {
                if(_Modified!=value){
                    _Modified=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Modified");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }




        public DbCommand GetUpdateCommand() {

            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        


            
            if(this._dirtyColumns.Count>0)
                _repo.Update(this,provider);
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        

       
        public void Add(IDataProvider provider){





            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
        
        
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        


        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
            
        }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<QuotationStatusType, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            

        }

        


        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 

    
    
    /// <summary>
    /// A class which represents the SectionType table in the Fersum Database.
    /// </summary>
    public partial class SectionType: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<SectionType> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<SectionType>(new Cotizaciones.DataModel.FersumDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<SectionType> testlist){
            SetTestRepo();
            _testRepo._items = testlist;
        }
        public static void Setup(SectionType item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                SectionType item=new SectionType();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<SectionType> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        Cotizaciones.DataModel.FersumDB _db;
        public SectionType(string connectionString, string providerName) {

            _db=new Cotizaciones.DataModel.FersumDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                SectionType.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<SectionType>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public SectionType(){
             _db=new Cotizaciones.DataModel.FersumDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public SectionType(Expression<Func<SectionType, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<SectionType> GetRepo(string connectionString, string providerName){
            Cotizaciones.DataModel.FersumDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new Cotizaciones.DataModel.FersumDB();
            }else{
                db=new Cotizaciones.DataModel.FersumDB(connectionString, providerName);
            }
            IRepository<SectionType> _repo;
            
            if(db.TestMode){
                SectionType.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<SectionType>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<SectionType> GetRepo(){
            return GetRepo("","");
        }
        
        public static SectionType SingleOrDefault(Expression<Func<SectionType, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            SectionType single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static SectionType SingleOrDefault(Expression<Func<SectionType, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            SectionType single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<SectionType, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<SectionType, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<SectionType> Find(Expression<Func<SectionType, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<SectionType> Find(Expression<Func<SectionType, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<SectionType> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<SectionType> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<SectionType> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<SectionType> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<SectionType> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<SectionType> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "SectionTypeID";
        }

        public object KeyValue()
        {
            return this.SectionTypeID;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
            return this.ShortName.ToString();
        }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(SectionType)){
                SectionType compare=(SectionType)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }


        
        public override int GetHashCode() {
            return this.SectionTypeID;
        }
        

        public string DescriptorValue()
        {
            return this.ShortName.ToString();
        }

        public string DescriptorColumn() {
            return "ShortName";
        }
        public static string GetKeyColumn()
        {
            return "SectionTypeID";
        }        
        public static string GetDescriptorColumn()
        {
            return "ShortName";
        }
        
        #region ' Foreign Keys '

        public IQueryable<QuotationSection> QuotationSections
        {
            get
            {
                
                  var repo=Cotizaciones.DataModel.QuotationSection.GetRepo();
                  return from items in repo.GetAll()
                       where items.SectionTypeID == _SectionTypeID
                       select items;
            }
        }


        #endregion
        


        int _SectionTypeID;
        public int SectionTypeID
        {
            get { return _SectionTypeID; }
            set
            {
                if(_SectionTypeID!=value){
                    _SectionTypeID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="SectionTypeID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _ShortName;
        public string ShortName
        {
            get { return _ShortName; }
            set
            {
                if(_ShortName!=value){
                    _ShortName=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ShortName");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _Description;
        public string Description
        {
            get { return _Description; }
            set
            {
                if(_Description!=value){
                    _Description=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Description");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _Active;
        public string Active
        {
            get { return _Active; }
            set
            {
                if(_Active!=value){
                    _Active=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Active");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _Creator;
        public string Creator
        {
            get { return _Creator; }
            set
            {
                if(_Creator!=value){
                    _Creator=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Creator");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        DateTime _Created;
        public DateTime Created
        {
            get { return _Created; }
            set
            {
                if(_Created!=value){
                    _Created=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Created");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _Modifier;
        public string Modifier
        {
            get { return _Modifier; }
            set
            {
                if(_Modifier!=value){
                    _Modifier=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Modifier");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        DateTime? _Modified;
        public DateTime? Modified
        {
            get { return _Modified; }
            set
            {
                if(_Modified!=value){
                    _Modified=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Modified");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }




        public DbCommand GetUpdateCommand() {

            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        


            
            if(this._dirtyColumns.Count>0)
                _repo.Update(this,provider);
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        

       
        public void Add(IDataProvider provider){





            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
        
        
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        


        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
            
        }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<SectionType, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            

        }

        


        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 

}
