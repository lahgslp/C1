


using System;
using SubSonic.Schema;
using System.Collections.Generic;
using SubSonic.DataProviders;
using System.Data;

namespace Cotizaciones.DataModel {
	
        /// <summary>
        /// Table: Customer
        /// Primary Key: CustomerID
        /// </summary>

        public class CustomerTable: DatabaseTable {
            
            public CustomerTable(IDataProvider provider):base("Customer",provider){
                ClassName = "Customer";
                SchemaName = "dbo";
                

                Columns.Add(new DatabaseColumn("CustomerID", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = true,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("ShortName", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 20
                });

                Columns.Add(new DatabaseColumn("Description", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 100
                });

                Columns.Add(new DatabaseColumn("Active", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiStringFixedLength,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 1
                });

                Columns.Add(new DatabaseColumn("Creator", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 20
                });

                Columns.Add(new DatabaseColumn("Created", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("Modifier", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 20
                });

                Columns.Add(new DatabaseColumn("Modified", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });
                    
                
                
            }
            
            public IColumn CustomerID{
                get{
                    return this.GetColumn("CustomerID");
                }
            }
				
   			public static string CustomerIDColumn{
			      get{
        			return "CustomerID";
      			}
		    }
            
            public IColumn ShortName{
                get{
                    return this.GetColumn("ShortName");
                }
            }
				
   			public static string ShortNameColumn{
			      get{
        			return "ShortName";
      			}
		    }
            
            public IColumn Description{
                get{
                    return this.GetColumn("Description");
                }
            }
				
   			public static string DescriptionColumn{
			      get{
        			return "Description";
      			}
		    }
            
            public IColumn Active{
                get{
                    return this.GetColumn("Active");
                }
            }
				
   			public static string ActiveColumn{
			      get{
        			return "Active";
      			}
		    }
            
            public IColumn Creator{
                get{
                    return this.GetColumn("Creator");
                }
            }
				
   			public static string CreatorColumn{
			      get{
        			return "Creator";
      			}
		    }
            
            public IColumn Created{
                get{
                    return this.GetColumn("Created");
                }
            }
				
   			public static string CreatedColumn{
			      get{
        			return "Created";
      			}
		    }
            
            public IColumn Modifier{
                get{
                    return this.GetColumn("Modifier");
                }
            }
				
   			public static string ModifierColumn{
			      get{
        			return "Modifier";
      			}
		    }
            
            public IColumn Modified{
                get{
                    return this.GetColumn("Modified");
                }
            }
				
   			public static string ModifiedColumn{
			      get{
        			return "Modified";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: CustomerContact
        /// Primary Key: CustomerContactID
        /// </summary>

        public class CustomerContactTable: DatabaseTable {
            
            public CustomerContactTable(IDataProvider provider):base("CustomerContact",provider){
                ClassName = "CustomerContact";
                SchemaName = "dbo";
                

                Columns.Add(new DatabaseColumn("CustomerContactID", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = true,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("ContactName", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 100
                });

                Columns.Add(new DatabaseColumn("Email", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50
                });

                Columns.Add(new DatabaseColumn("Phone", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50
                });

                Columns.Add(new DatabaseColumn("Extension", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 20
                });

                Columns.Add(new DatabaseColumn("CustomerID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = true,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("Active", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiStringFixedLength,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 1
                });

                Columns.Add(new DatabaseColumn("Creator", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 20
                });

                Columns.Add(new DatabaseColumn("Created", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("Modifier", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 20
                });

                Columns.Add(new DatabaseColumn("Modified", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });
                    
                
                
            }
            
            public IColumn CustomerContactID{
                get{
                    return this.GetColumn("CustomerContactID");
                }
            }
				
   			public static string CustomerContactIDColumn{
			      get{
        			return "CustomerContactID";
      			}
		    }
            
            public IColumn ContactName{
                get{
                    return this.GetColumn("ContactName");
                }
            }
				
   			public static string ContactNameColumn{
			      get{
        			return "ContactName";
      			}
		    }
            
            public IColumn Email{
                get{
                    return this.GetColumn("Email");
                }
            }
				
   			public static string EmailColumn{
			      get{
        			return "Email";
      			}
		    }
            
            public IColumn Phone{
                get{
                    return this.GetColumn("Phone");
                }
            }
				
   			public static string PhoneColumn{
			      get{
        			return "Phone";
      			}
		    }
            
            public IColumn Extension{
                get{
                    return this.GetColumn("Extension");
                }
            }
				
   			public static string ExtensionColumn{
			      get{
        			return "Extension";
      			}
		    }
            
            public IColumn CustomerID{
                get{
                    return this.GetColumn("CustomerID");
                }
            }
				
   			public static string CustomerIDColumn{
			      get{
        			return "CustomerID";
      			}
		    }
            
            public IColumn Active{
                get{
                    return this.GetColumn("Active");
                }
            }
				
   			public static string ActiveColumn{
			      get{
        			return "Active";
      			}
		    }
            
            public IColumn Creator{
                get{
                    return this.GetColumn("Creator");
                }
            }
				
   			public static string CreatorColumn{
			      get{
        			return "Creator";
      			}
		    }
            
            public IColumn Created{
                get{
                    return this.GetColumn("Created");
                }
            }
				
   			public static string CreatedColumn{
			      get{
        			return "Created";
      			}
		    }
            
            public IColumn Modifier{
                get{
                    return this.GetColumn("Modifier");
                }
            }
				
   			public static string ModifierColumn{
			      get{
        			return "Modifier";
      			}
		    }
            
            public IColumn Modified{
                get{
                    return this.GetColumn("Modified");
                }
            }
				
   			public static string ModifiedColumn{
			      get{
        			return "Modified";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: InvoiceMethodType
        /// Primary Key: InvoiceMethodTypeID
        /// </summary>

        public class InvoiceMethodTypeTable: DatabaseTable {
            
            public InvoiceMethodTypeTable(IDataProvider provider):base("InvoiceMethodType",provider){
                ClassName = "InvoiceMethodType";
                SchemaName = "dbo";
                

                Columns.Add(new DatabaseColumn("InvoiceMethodTypeID", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("ShortName", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 20
                });

                Columns.Add(new DatabaseColumn("Description", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 256
                });

                Columns.Add(new DatabaseColumn("Active", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiStringFixedLength,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 1
                });

                Columns.Add(new DatabaseColumn("Creator", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 20
                });

                Columns.Add(new DatabaseColumn("Created", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("Modifier", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 20
                });

                Columns.Add(new DatabaseColumn("Modified", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });
                    
                
                
            }
            
            public IColumn InvoiceMethodTypeID{
                get{
                    return this.GetColumn("InvoiceMethodTypeID");
                }
            }
				
   			public static string InvoiceMethodTypeIDColumn{
			      get{
        			return "InvoiceMethodTypeID";
      			}
		    }
            
            public IColumn ShortName{
                get{
                    return this.GetColumn("ShortName");
                }
            }
				
   			public static string ShortNameColumn{
			      get{
        			return "ShortName";
      			}
		    }
            
            public IColumn Description{
                get{
                    return this.GetColumn("Description");
                }
            }
				
   			public static string DescriptionColumn{
			      get{
        			return "Description";
      			}
		    }
            
            public IColumn Active{
                get{
                    return this.GetColumn("Active");
                }
            }
				
   			public static string ActiveColumn{
			      get{
        			return "Active";
      			}
		    }
            
            public IColumn Creator{
                get{
                    return this.GetColumn("Creator");
                }
            }
				
   			public static string CreatorColumn{
			      get{
        			return "Creator";
      			}
		    }
            
            public IColumn Created{
                get{
                    return this.GetColumn("Created");
                }
            }
				
   			public static string CreatedColumn{
			      get{
        			return "Created";
      			}
		    }
            
            public IColumn Modifier{
                get{
                    return this.GetColumn("Modifier");
                }
            }
				
   			public static string ModifierColumn{
			      get{
        			return "Modifier";
      			}
		    }
            
            public IColumn Modified{
                get{
                    return this.GetColumn("Modified");
                }
            }
				
   			public static string ModifiedColumn{
			      get{
        			return "Modified";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: UnitType
        /// Primary Key: UnitTypeID
        /// </summary>

        public class UnitTypeTable: DatabaseTable {
            
            public UnitTypeTable(IDataProvider provider):base("UnitType",provider){
                ClassName = "UnitType";
                SchemaName = "dbo";
                

                Columns.Add(new DatabaseColumn("UnitTypeID", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = true,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("ShortName", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 20
                });

                Columns.Add(new DatabaseColumn("Description", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 100
                });

                Columns.Add(new DatabaseColumn("Active", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiStringFixedLength,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 1
                });

                Columns.Add(new DatabaseColumn("Creator", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 20
                });

                Columns.Add(new DatabaseColumn("Created", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("Modifier", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 20
                });

                Columns.Add(new DatabaseColumn("Modified", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });
                    
                
                
            }
            
            public IColumn UnitTypeID{
                get{
                    return this.GetColumn("UnitTypeID");
                }
            }
				
   			public static string UnitTypeIDColumn{
			      get{
        			return "UnitTypeID";
      			}
		    }
            
            public IColumn ShortName{
                get{
                    return this.GetColumn("ShortName");
                }
            }
				
   			public static string ShortNameColumn{
			      get{
        			return "ShortName";
      			}
		    }
            
            public IColumn Description{
                get{
                    return this.GetColumn("Description");
                }
            }
				
   			public static string DescriptionColumn{
			      get{
        			return "Description";
      			}
		    }
            
            public IColumn Active{
                get{
                    return this.GetColumn("Active");
                }
            }
				
   			public static string ActiveColumn{
			      get{
        			return "Active";
      			}
		    }
            
            public IColumn Creator{
                get{
                    return this.GetColumn("Creator");
                }
            }
				
   			public static string CreatorColumn{
			      get{
        			return "Creator";
      			}
		    }
            
            public IColumn Created{
                get{
                    return this.GetColumn("Created");
                }
            }
				
   			public static string CreatedColumn{
			      get{
        			return "Created";
      			}
		    }
            
            public IColumn Modifier{
                get{
                    return this.GetColumn("Modifier");
                }
            }
				
   			public static string ModifierColumn{
			      get{
        			return "Modifier";
      			}
		    }
            
            public IColumn Modified{
                get{
                    return this.GetColumn("Modified");
                }
            }
				
   			public static string ModifiedColumn{
			      get{
        			return "Modified";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: QuotationSection
        /// Primary Key: QuotationSectionID
        /// </summary>

        public class QuotationSectionTable: DatabaseTable {
            
            public QuotationSectionTable(IDataProvider provider):base("QuotationSection",provider){
                ClassName = "QuotationSection";
                SchemaName = "dbo";
                

                Columns.Add(new DatabaseColumn("QuotationSectionID", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = true,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("QuotationID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = true,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("SectionTypeID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = true,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("Active", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiStringFixedLength,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 1
                });

                Columns.Add(new DatabaseColumn("Creator", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 20
                });

                Columns.Add(new DatabaseColumn("Created", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("Modifier", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 20
                });

                Columns.Add(new DatabaseColumn("Modified", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("SectionDescription", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 512
                });
                    
                
                
            }
            
            public IColumn QuotationSectionID{
                get{
                    return this.GetColumn("QuotationSectionID");
                }
            }
				
   			public static string QuotationSectionIDColumn{
			      get{
        			return "QuotationSectionID";
      			}
		    }
            
            public IColumn QuotationID{
                get{
                    return this.GetColumn("QuotationID");
                }
            }
				
   			public static string QuotationIDColumn{
			      get{
        			return "QuotationID";
      			}
		    }
            
            public IColumn SectionTypeID{
                get{
                    return this.GetColumn("SectionTypeID");
                }
            }
				
   			public static string SectionTypeIDColumn{
			      get{
        			return "SectionTypeID";
      			}
		    }
            
            public IColumn Active{
                get{
                    return this.GetColumn("Active");
                }
            }
				
   			public static string ActiveColumn{
			      get{
        			return "Active";
      			}
		    }
            
            public IColumn Creator{
                get{
                    return this.GetColumn("Creator");
                }
            }
				
   			public static string CreatorColumn{
			      get{
        			return "Creator";
      			}
		    }
            
            public IColumn Created{
                get{
                    return this.GetColumn("Created");
                }
            }
				
   			public static string CreatedColumn{
			      get{
        			return "Created";
      			}
		    }
            
            public IColumn Modifier{
                get{
                    return this.GetColumn("Modifier");
                }
            }
				
   			public static string ModifierColumn{
			      get{
        			return "Modifier";
      			}
		    }
            
            public IColumn Modified{
                get{
                    return this.GetColumn("Modified");
                }
            }
				
   			public static string ModifiedColumn{
			      get{
        			return "Modified";
      			}
		    }
            
            public IColumn SectionDescription{
                get{
                    return this.GetColumn("SectionDescription");
                }
            }
				
   			public static string SectionDescriptionColumn{
			      get{
        			return "SectionDescription";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: Users
        /// Primary Key: UserID
        /// </summary>

        public class UsersTable: DatabaseTable {
            
            public UsersTable(IDataProvider provider):base("Users",provider){
                ClassName = "User";
                SchemaName = "dbo";
                

                Columns.Add(new DatabaseColumn("UserID", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("ShortName", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 20
                });

                Columns.Add(new DatabaseColumn("Password", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 20
                });

                Columns.Add(new DatabaseColumn("FullName", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 100
                });

                Columns.Add(new DatabaseColumn("Email", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 100
                });

                Columns.Add(new DatabaseColumn("Active", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiStringFixedLength,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 1
                });

                Columns.Add(new DatabaseColumn("Creator", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 20
                });

                Columns.Add(new DatabaseColumn("Created", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("Modifier", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 20
                });

                Columns.Add(new DatabaseColumn("Modified", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("NotifyToEmail", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 100
                });
                    
                
                
            }
            
            public IColumn UserID{
                get{
                    return this.GetColumn("UserID");
                }
            }
				
   			public static string UserIDColumn{
			      get{
        			return "UserID";
      			}
		    }
            
            public IColumn ShortName{
                get{
                    return this.GetColumn("ShortName");
                }
            }
				
   			public static string ShortNameColumn{
			      get{
        			return "ShortName";
      			}
		    }
            
            public IColumn Password{
                get{
                    return this.GetColumn("Password");
                }
            }
				
   			public static string PasswordColumn{
			      get{
        			return "Password";
      			}
		    }
            
            public IColumn FullName{
                get{
                    return this.GetColumn("FullName");
                }
            }
				
   			public static string FullNameColumn{
			      get{
        			return "FullName";
      			}
		    }
            
            public IColumn Email{
                get{
                    return this.GetColumn("Email");
                }
            }
				
   			public static string EmailColumn{
			      get{
        			return "Email";
      			}
		    }
            
            public IColumn Active{
                get{
                    return this.GetColumn("Active");
                }
            }
				
   			public static string ActiveColumn{
			      get{
        			return "Active";
      			}
		    }
            
            public IColumn Creator{
                get{
                    return this.GetColumn("Creator");
                }
            }
				
   			public static string CreatorColumn{
			      get{
        			return "Creator";
      			}
		    }
            
            public IColumn Created{
                get{
                    return this.GetColumn("Created");
                }
            }
				
   			public static string CreatedColumn{
			      get{
        			return "Created";
      			}
		    }
            
            public IColumn Modifier{
                get{
                    return this.GetColumn("Modifier");
                }
            }
				
   			public static string ModifierColumn{
			      get{
        			return "Modifier";
      			}
		    }
            
            public IColumn Modified{
                get{
                    return this.GetColumn("Modified");
                }
            }
				
   			public static string ModifiedColumn{
			      get{
        			return "Modified";
      			}
		    }
            
            public IColumn NotifyToEmail{
                get{
                    return this.GetColumn("NotifyToEmail");
                }
            }
				
   			public static string NotifyToEmailColumn{
			      get{
        			return "NotifyToEmail";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: PipeDiameterType
        /// Primary Key: PipeDiameterTypeID
        /// </summary>

        public class PipeDiameterTypeTable: DatabaseTable {
            
            public PipeDiameterTypeTable(IDataProvider provider):base("PipeDiameterType",provider){
                ClassName = "PipeDiameterType";
                SchemaName = "dbo";
                

                Columns.Add(new DatabaseColumn("PipeDiameterTypeID", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = true,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("ShortName", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 20
                });

                Columns.Add(new DatabaseColumn("Description", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 100
                });

                Columns.Add(new DatabaseColumn("ExternalDiameterInches", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("Active", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiStringFixedLength,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 1
                });

                Columns.Add(new DatabaseColumn("Creator", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 20
                });

                Columns.Add(new DatabaseColumn("Created", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("Modifier", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 20
                });

                Columns.Add(new DatabaseColumn("Modified", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });
                    
                
                
            }
            
            public IColumn PipeDiameterTypeID{
                get{
                    return this.GetColumn("PipeDiameterTypeID");
                }
            }
				
   			public static string PipeDiameterTypeIDColumn{
			      get{
        			return "PipeDiameterTypeID";
      			}
		    }
            
            public IColumn ShortName{
                get{
                    return this.GetColumn("ShortName");
                }
            }
				
   			public static string ShortNameColumn{
			      get{
        			return "ShortName";
      			}
		    }
            
            public IColumn Description{
                get{
                    return this.GetColumn("Description");
                }
            }
				
   			public static string DescriptionColumn{
			      get{
        			return "Description";
      			}
		    }
            
            public IColumn ExternalDiameterInches{
                get{
                    return this.GetColumn("ExternalDiameterInches");
                }
            }
				
   			public static string ExternalDiameterInchesColumn{
			      get{
        			return "ExternalDiameterInches";
      			}
		    }
            
            public IColumn Active{
                get{
                    return this.GetColumn("Active");
                }
            }
				
   			public static string ActiveColumn{
			      get{
        			return "Active";
      			}
		    }
            
            public IColumn Creator{
                get{
                    return this.GetColumn("Creator");
                }
            }
				
   			public static string CreatorColumn{
			      get{
        			return "Creator";
      			}
		    }
            
            public IColumn Created{
                get{
                    return this.GetColumn("Created");
                }
            }
				
   			public static string CreatedColumn{
			      get{
        			return "Created";
      			}
		    }
            
            public IColumn Modifier{
                get{
                    return this.GetColumn("Modifier");
                }
            }
				
   			public static string ModifierColumn{
			      get{
        			return "Modifier";
      			}
		    }
            
            public IColumn Modified{
                get{
                    return this.GetColumn("Modified");
                }
            }
				
   			public static string ModifiedColumn{
			      get{
        			return "Modified";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: PipeSpecification
        /// Primary Key: PipeSpecificationID
        /// </summary>

        public class PipeSpecificationTable: DatabaseTable {
            
            public PipeSpecificationTable(IDataProvider provider):base("PipeSpecification",provider){
                ClassName = "PipeSpecification";
                SchemaName = "dbo";
                

                Columns.Add(new DatabaseColumn("PipeSpecificationID", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("WallThicknessInches", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("PipeSchedule", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 10
                });

                Columns.Add(new DatabaseColumn("PipeClass", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 10
                });

                Columns.Add(new DatabaseColumn("PipeDiameterTypeID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = true,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("Active", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiStringFixedLength,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 1
                });

                Columns.Add(new DatabaseColumn("Creator", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 20
                });

                Columns.Add(new DatabaseColumn("Created", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("Modifier", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 20
                });

                Columns.Add(new DatabaseColumn("Modified", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });
                    
                
                
            }
            
            public IColumn PipeSpecificationID{
                get{
                    return this.GetColumn("PipeSpecificationID");
                }
            }
				
   			public static string PipeSpecificationIDColumn{
			      get{
        			return "PipeSpecificationID";
      			}
		    }
            
            public IColumn WallThicknessInches{
                get{
                    return this.GetColumn("WallThicknessInches");
                }
            }
				
   			public static string WallThicknessInchesColumn{
			      get{
        			return "WallThicknessInches";
      			}
		    }
            
            public IColumn PipeSchedule{
                get{
                    return this.GetColumn("PipeSchedule");
                }
            }
				
   			public static string PipeScheduleColumn{
			      get{
        			return "PipeSchedule";
      			}
		    }
            
            public IColumn PipeClass{
                get{
                    return this.GetColumn("PipeClass");
                }
            }
				
   			public static string PipeClassColumn{
			      get{
        			return "PipeClass";
      			}
		    }
            
            public IColumn PipeDiameterTypeID{
                get{
                    return this.GetColumn("PipeDiameterTypeID");
                }
            }
				
   			public static string PipeDiameterTypeIDColumn{
			      get{
        			return "PipeDiameterTypeID";
      			}
		    }
            
            public IColumn Active{
                get{
                    return this.GetColumn("Active");
                }
            }
				
   			public static string ActiveColumn{
			      get{
        			return "Active";
      			}
		    }
            
            public IColumn Creator{
                get{
                    return this.GetColumn("Creator");
                }
            }
				
   			public static string CreatorColumn{
			      get{
        			return "Creator";
      			}
		    }
            
            public IColumn Created{
                get{
                    return this.GetColumn("Created");
                }
            }
				
   			public static string CreatedColumn{
			      get{
        			return "Created";
      			}
		    }
            
            public IColumn Modifier{
                get{
                    return this.GetColumn("Modifier");
                }
            }
				
   			public static string ModifierColumn{
			      get{
        			return "Modifier";
      			}
		    }
            
            public IColumn Modified{
                get{
                    return this.GetColumn("Modified");
                }
            }
				
   			public static string ModifiedColumn{
			      get{
        			return "Modified";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: DeliveryType
        /// Primary Key: DeliveryTypeID
        /// </summary>

        public class DeliveryTypeTable: DatabaseTable {
            
            public DeliveryTypeTable(IDataProvider provider):base("DeliveryType",provider){
                ClassName = "DeliveryType";
                SchemaName = "dbo";
                

                Columns.Add(new DatabaseColumn("DeliveryTypeID", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("ShortName", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 20
                });

                Columns.Add(new DatabaseColumn("Description", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 256
                });

                Columns.Add(new DatabaseColumn("Active", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiStringFixedLength,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 1
                });

                Columns.Add(new DatabaseColumn("Creator", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 20
                });

                Columns.Add(new DatabaseColumn("Created", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("Modifier", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 20
                });

                Columns.Add(new DatabaseColumn("Modified", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });
                    
                
                
            }
            
            public IColumn DeliveryTypeID{
                get{
                    return this.GetColumn("DeliveryTypeID");
                }
            }
				
   			public static string DeliveryTypeIDColumn{
			      get{
        			return "DeliveryTypeID";
      			}
		    }
            
            public IColumn ShortName{
                get{
                    return this.GetColumn("ShortName");
                }
            }
				
   			public static string ShortNameColumn{
			      get{
        			return "ShortName";
      			}
		    }
            
            public IColumn Description{
                get{
                    return this.GetColumn("Description");
                }
            }
				
   			public static string DescriptionColumn{
			      get{
        			return "Description";
      			}
		    }
            
            public IColumn Active{
                get{
                    return this.GetColumn("Active");
                }
            }
				
   			public static string ActiveColumn{
			      get{
        			return "Active";
      			}
		    }
            
            public IColumn Creator{
                get{
                    return this.GetColumn("Creator");
                }
            }
				
   			public static string CreatorColumn{
			      get{
        			return "Creator";
      			}
		    }
            
            public IColumn Created{
                get{
                    return this.GetColumn("Created");
                }
            }
				
   			public static string CreatedColumn{
			      get{
        			return "Created";
      			}
		    }
            
            public IColumn Modifier{
                get{
                    return this.GetColumn("Modifier");
                }
            }
				
   			public static string ModifierColumn{
			      get{
        			return "Modifier";
      			}
		    }
            
            public IColumn Modified{
                get{
                    return this.GetColumn("Modified");
                }
            }
				
   			public static string ModifiedColumn{
			      get{
        			return "Modified";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: PaymentType
        /// Primary Key: PaymentTypeID
        /// </summary>

        public class PaymentTypeTable: DatabaseTable {
            
            public PaymentTypeTable(IDataProvider provider):base("PaymentType",provider){
                ClassName = "PaymentType";
                SchemaName = "dbo";
                

                Columns.Add(new DatabaseColumn("PaymentTypeID", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("ShortName", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 20
                });

                Columns.Add(new DatabaseColumn("Description", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 256
                });

                Columns.Add(new DatabaseColumn("Active", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiStringFixedLength,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 1
                });

                Columns.Add(new DatabaseColumn("Creator", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 20
                });

                Columns.Add(new DatabaseColumn("Created", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("Modifier", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 20
                });

                Columns.Add(new DatabaseColumn("Modified", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });
                    
                
                
            }
            
            public IColumn PaymentTypeID{
                get{
                    return this.GetColumn("PaymentTypeID");
                }
            }
				
   			public static string PaymentTypeIDColumn{
			      get{
        			return "PaymentTypeID";
      			}
		    }
            
            public IColumn ShortName{
                get{
                    return this.GetColumn("ShortName");
                }
            }
				
   			public static string ShortNameColumn{
			      get{
        			return "ShortName";
      			}
		    }
            
            public IColumn Description{
                get{
                    return this.GetColumn("Description");
                }
            }
				
   			public static string DescriptionColumn{
			      get{
        			return "Description";
      			}
		    }
            
            public IColumn Active{
                get{
                    return this.GetColumn("Active");
                }
            }
				
   			public static string ActiveColumn{
			      get{
        			return "Active";
      			}
		    }
            
            public IColumn Creator{
                get{
                    return this.GetColumn("Creator");
                }
            }
				
   			public static string CreatorColumn{
			      get{
        			return "Creator";
      			}
		    }
            
            public IColumn Created{
                get{
                    return this.GetColumn("Created");
                }
            }
				
   			public static string CreatedColumn{
			      get{
        			return "Created";
      			}
		    }
            
            public IColumn Modifier{
                get{
                    return this.GetColumn("Modifier");
                }
            }
				
   			public static string ModifierColumn{
			      get{
        			return "Modifier";
      			}
		    }
            
            public IColumn Modified{
                get{
                    return this.GetColumn("Modified");
                }
            }
				
   			public static string ModifiedColumn{
			      get{
        			return "Modified";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: QuotationStatusType
        /// Primary Key: QuotationStatustypeID
        /// </summary>

        public class QuotationStatusTypeTable: DatabaseTable {
            
            public QuotationStatusTypeTable(IDataProvider provider):base("QuotationStatusType",provider){
                ClassName = "QuotationStatusType";
                SchemaName = "dbo";
                

                Columns.Add(new DatabaseColumn("QuotationStatustypeID", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = true,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("ShortName", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 20
                });

                Columns.Add(new DatabaseColumn("Description", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 100
                });

                Columns.Add(new DatabaseColumn("Active", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiStringFixedLength,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 1
                });

                Columns.Add(new DatabaseColumn("Creator", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 20
                });

                Columns.Add(new DatabaseColumn("Created", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("Modifier", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 20
                });

                Columns.Add(new DatabaseColumn("Modified", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });
                    
                
                
            }
            
            public IColumn QuotationStatustypeID{
                get{
                    return this.GetColumn("QuotationStatustypeID");
                }
            }
				
   			public static string QuotationStatustypeIDColumn{
			      get{
        			return "QuotationStatustypeID";
      			}
		    }
            
            public IColumn ShortName{
                get{
                    return this.GetColumn("ShortName");
                }
            }
				
   			public static string ShortNameColumn{
			      get{
        			return "ShortName";
      			}
		    }
            
            public IColumn Description{
                get{
                    return this.GetColumn("Description");
                }
            }
				
   			public static string DescriptionColumn{
			      get{
        			return "Description";
      			}
		    }
            
            public IColumn Active{
                get{
                    return this.GetColumn("Active");
                }
            }
				
   			public static string ActiveColumn{
			      get{
        			return "Active";
      			}
		    }
            
            public IColumn Creator{
                get{
                    return this.GetColumn("Creator");
                }
            }
				
   			public static string CreatorColumn{
			      get{
        			return "Creator";
      			}
		    }
            
            public IColumn Created{
                get{
                    return this.GetColumn("Created");
                }
            }
				
   			public static string CreatedColumn{
			      get{
        			return "Created";
      			}
		    }
            
            public IColumn Modifier{
                get{
                    return this.GetColumn("Modifier");
                }
            }
				
   			public static string ModifierColumn{
			      get{
        			return "Modifier";
      			}
		    }
            
            public IColumn Modified{
                get{
                    return this.GetColumn("Modified");
                }
            }
				
   			public static string ModifiedColumn{
			      get{
        			return "Modified";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: DeliveryTimeType
        /// Primary Key: DeliveryTimeTypeID
        /// </summary>

        public class DeliveryTimeTypeTable: DatabaseTable {
            
            public DeliveryTimeTypeTable(IDataProvider provider):base("DeliveryTimeType",provider){
                ClassName = "DeliveryTimeType";
                SchemaName = "dbo";
                

                Columns.Add(new DatabaseColumn("DeliveryTimeTypeID", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("ShortName", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 20
                });

                Columns.Add(new DatabaseColumn("Description", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 256
                });

                Columns.Add(new DatabaseColumn("Active", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiStringFixedLength,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 1
                });

                Columns.Add(new DatabaseColumn("Creator", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 20
                });

                Columns.Add(new DatabaseColumn("Created", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("Modifier", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 20
                });

                Columns.Add(new DatabaseColumn("Modified", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });
                    
                
                
            }
            
            public IColumn DeliveryTimeTypeID{
                get{
                    return this.GetColumn("DeliveryTimeTypeID");
                }
            }
				
   			public static string DeliveryTimeTypeIDColumn{
			      get{
        			return "DeliveryTimeTypeID";
      			}
		    }
            
            public IColumn ShortName{
                get{
                    return this.GetColumn("ShortName");
                }
            }
				
   			public static string ShortNameColumn{
			      get{
        			return "ShortName";
      			}
		    }
            
            public IColumn Description{
                get{
                    return this.GetColumn("Description");
                }
            }
				
   			public static string DescriptionColumn{
			      get{
        			return "Description";
      			}
		    }
            
            public IColumn Active{
                get{
                    return this.GetColumn("Active");
                }
            }
				
   			public static string ActiveColumn{
			      get{
        			return "Active";
      			}
		    }
            
            public IColumn Creator{
                get{
                    return this.GetColumn("Creator");
                }
            }
				
   			public static string CreatorColumn{
			      get{
        			return "Creator";
      			}
		    }
            
            public IColumn Created{
                get{
                    return this.GetColumn("Created");
                }
            }
				
   			public static string CreatedColumn{
			      get{
        			return "Created";
      			}
		    }
            
            public IColumn Modifier{
                get{
                    return this.GetColumn("Modifier");
                }
            }
				
   			public static string ModifierColumn{
			      get{
        			return "Modifier";
      			}
		    }
            
            public IColumn Modified{
                get{
                    return this.GetColumn("Modified");
                }
            }
				
   			public static string ModifiedColumn{
			      get{
        			return "Modified";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: QuotationSectionDetail
        /// Primary Key: QuotationSectionDetailID
        /// </summary>

        public class QuotationSectionDetailTable: DatabaseTable {
            
            public QuotationSectionDetailTable(IDataProvider provider):base("QuotationSectionDetail",provider){
                ClassName = "QuotationSectionDetail";
                SchemaName = "dbo";
                

                Columns.Add(new DatabaseColumn("QuotationSectionDetailID", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("QuotationSectionID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = true,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("PipeSpecificationID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("Quantity", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("Price", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("DeliveryDescription", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 256
                });

                Columns.Add(new DatabaseColumn("DeliveryTimeDescription", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 256
                });

                Columns.Add(new DatabaseColumn("CurrencyDescription", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50
                });

                Columns.Add(new DatabaseColumn("UnitTypeID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = true,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("Active", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiStringFixedLength,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 1
                });

                Columns.Add(new DatabaseColumn("Creator", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 20
                });

                Columns.Add(new DatabaseColumn("Created", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("Modifier", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 20
                });

                Columns.Add(new DatabaseColumn("Modified", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });
                    
                
                
            }
            
            public IColumn QuotationSectionDetailID{
                get{
                    return this.GetColumn("QuotationSectionDetailID");
                }
            }
				
   			public static string QuotationSectionDetailIDColumn{
			      get{
        			return "QuotationSectionDetailID";
      			}
		    }
            
            public IColumn QuotationSectionID{
                get{
                    return this.GetColumn("QuotationSectionID");
                }
            }
				
   			public static string QuotationSectionIDColumn{
			      get{
        			return "QuotationSectionID";
      			}
		    }
            
            public IColumn PipeSpecificationID{
                get{
                    return this.GetColumn("PipeSpecificationID");
                }
            }
				
   			public static string PipeSpecificationIDColumn{
			      get{
        			return "PipeSpecificationID";
      			}
		    }
            
            public IColumn Quantity{
                get{
                    return this.GetColumn("Quantity");
                }
            }
				
   			public static string QuantityColumn{
			      get{
        			return "Quantity";
      			}
		    }
            
            public IColumn Price{
                get{
                    return this.GetColumn("Price");
                }
            }
				
   			public static string PriceColumn{
			      get{
        			return "Price";
      			}
		    }
            
            public IColumn DeliveryDescription{
                get{
                    return this.GetColumn("DeliveryDescription");
                }
            }
				
   			public static string DeliveryDescriptionColumn{
			      get{
        			return "DeliveryDescription";
      			}
		    }
            
            public IColumn DeliveryTimeDescription{
                get{
                    return this.GetColumn("DeliveryTimeDescription");
                }
            }
				
   			public static string DeliveryTimeDescriptionColumn{
			      get{
        			return "DeliveryTimeDescription";
      			}
		    }
            
            public IColumn CurrencyDescription{
                get{
                    return this.GetColumn("CurrencyDescription");
                }
            }
				
   			public static string CurrencyDescriptionColumn{
			      get{
        			return "CurrencyDescription";
      			}
		    }
            
            public IColumn UnitTypeID{
                get{
                    return this.GetColumn("UnitTypeID");
                }
            }
				
   			public static string UnitTypeIDColumn{
			      get{
        			return "UnitTypeID";
      			}
		    }
            
            public IColumn Active{
                get{
                    return this.GetColumn("Active");
                }
            }
				
   			public static string ActiveColumn{
			      get{
        			return "Active";
      			}
		    }
            
            public IColumn Creator{
                get{
                    return this.GetColumn("Creator");
                }
            }
				
   			public static string CreatorColumn{
			      get{
        			return "Creator";
      			}
		    }
            
            public IColumn Created{
                get{
                    return this.GetColumn("Created");
                }
            }
				
   			public static string CreatedColumn{
			      get{
        			return "Created";
      			}
		    }
            
            public IColumn Modifier{
                get{
                    return this.GetColumn("Modifier");
                }
            }
				
   			public static string ModifierColumn{
			      get{
        			return "Modifier";
      			}
		    }
            
            public IColumn Modified{
                get{
                    return this.GetColumn("Modified");
                }
            }
				
   			public static string ModifiedColumn{
			      get{
        			return "Modified";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: Quotation
        /// Primary Key: QuotationID
        /// </summary>

        public class QuotationTable: DatabaseTable {
            
            public QuotationTable(IDataProvider provider):base("Quotation",provider){
                ClassName = "Quotation";
                SchemaName = "dbo";
                

                Columns.Add(new DatabaseColumn("QuotationID", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = true,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("CustomerID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = true,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("CustomerContactID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = true,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("EmailTo", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50
                });

                Columns.Add(new DatabaseColumn("ClonedFromQuotationID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("ValidPeriodDescription", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50
                });

                Columns.Add(new DatabaseColumn("PaymentDescription", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 256
                });

                Columns.Add(new DatabaseColumn("PDFFileName", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 256
                });

                Columns.Add(new DatabaseColumn("Notes", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 1024
                });

                Columns.Add(new DatabaseColumn("QuotationStatusTypeID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = true,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("Active", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiStringFixedLength,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 1
                });

                Columns.Add(new DatabaseColumn("Creator", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 20
                });

                Columns.Add(new DatabaseColumn("Created", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("Modifier", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 20
                });

                Columns.Add(new DatabaseColumn("Modified", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("InvoiceMethodDescription", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 256
                });
                    
                
                
            }
            
            public IColumn QuotationID{
                get{
                    return this.GetColumn("QuotationID");
                }
            }
				
   			public static string QuotationIDColumn{
			      get{
        			return "QuotationID";
      			}
		    }
            
            public IColumn CustomerID{
                get{
                    return this.GetColumn("CustomerID");
                }
            }
				
   			public static string CustomerIDColumn{
			      get{
        			return "CustomerID";
      			}
		    }
            
            public IColumn CustomerContactID{
                get{
                    return this.GetColumn("CustomerContactID");
                }
            }
				
   			public static string CustomerContactIDColumn{
			      get{
        			return "CustomerContactID";
      			}
		    }
            
            public IColumn EmailTo{
                get{
                    return this.GetColumn("EmailTo");
                }
            }
				
   			public static string EmailToColumn{
			      get{
        			return "EmailTo";
      			}
		    }
            
            public IColumn ClonedFromQuotationID{
                get{
                    return this.GetColumn("ClonedFromQuotationID");
                }
            }
				
   			public static string ClonedFromQuotationIDColumn{
			      get{
        			return "ClonedFromQuotationID";
      			}
		    }
            
            public IColumn ValidPeriodDescription{
                get{
                    return this.GetColumn("ValidPeriodDescription");
                }
            }
				
   			public static string ValidPeriodDescriptionColumn{
			      get{
        			return "ValidPeriodDescription";
      			}
		    }
            
            public IColumn PaymentDescription{
                get{
                    return this.GetColumn("PaymentDescription");
                }
            }
				
   			public static string PaymentDescriptionColumn{
			      get{
        			return "PaymentDescription";
      			}
		    }
            
            public IColumn PDFFileName{
                get{
                    return this.GetColumn("PDFFileName");
                }
            }
				
   			public static string PDFFileNameColumn{
			      get{
        			return "PDFFileName";
      			}
		    }
            
            public IColumn Notes{
                get{
                    return this.GetColumn("Notes");
                }
            }
				
   			public static string NotesColumn{
			      get{
        			return "Notes";
      			}
		    }
            
            public IColumn QuotationStatusTypeID{
                get{
                    return this.GetColumn("QuotationStatusTypeID");
                }
            }
				
   			public static string QuotationStatusTypeIDColumn{
			      get{
        			return "QuotationStatusTypeID";
      			}
		    }
            
            public IColumn Active{
                get{
                    return this.GetColumn("Active");
                }
            }
				
   			public static string ActiveColumn{
			      get{
        			return "Active";
      			}
		    }
            
            public IColumn Creator{
                get{
                    return this.GetColumn("Creator");
                }
            }
				
   			public static string CreatorColumn{
			      get{
        			return "Creator";
      			}
		    }
            
            public IColumn Created{
                get{
                    return this.GetColumn("Created");
                }
            }
				
   			public static string CreatedColumn{
			      get{
        			return "Created";
      			}
		    }
            
            public IColumn Modifier{
                get{
                    return this.GetColumn("Modifier");
                }
            }
				
   			public static string ModifierColumn{
			      get{
        			return "Modifier";
      			}
		    }
            
            public IColumn Modified{
                get{
                    return this.GetColumn("Modified");
                }
            }
				
   			public static string ModifiedColumn{
			      get{
        			return "Modified";
      			}
		    }
            
            public IColumn InvoiceMethodDescription{
                get{
                    return this.GetColumn("InvoiceMethodDescription");
                }
            }
				
   			public static string InvoiceMethodDescriptionColumn{
			      get{
        			return "InvoiceMethodDescription";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: ValidPeriodType
        /// Primary Key: ValidPeriodTypeID
        /// </summary>

        public class ValidPeriodTypeTable: DatabaseTable {
            
            public ValidPeriodTypeTable(IDataProvider provider):base("ValidPeriodType",provider){
                ClassName = "ValidPeriodType";
                SchemaName = "dbo";
                

                Columns.Add(new DatabaseColumn("ValidPeriodTypeID", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("ShortName", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 20
                });

                Columns.Add(new DatabaseColumn("Description", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 256
                });

                Columns.Add(new DatabaseColumn("Active", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiStringFixedLength,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 1
                });

                Columns.Add(new DatabaseColumn("Creator", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 20
                });

                Columns.Add(new DatabaseColumn("Created", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("Modifier", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 20
                });

                Columns.Add(new DatabaseColumn("Modified", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });
                    
                
                
            }
            
            public IColumn ValidPeriodTypeID{
                get{
                    return this.GetColumn("ValidPeriodTypeID");
                }
            }
				
   			public static string ValidPeriodTypeIDColumn{
			      get{
        			return "ValidPeriodTypeID";
      			}
		    }
            
            public IColumn ShortName{
                get{
                    return this.GetColumn("ShortName");
                }
            }
				
   			public static string ShortNameColumn{
			      get{
        			return "ShortName";
      			}
		    }
            
            public IColumn Description{
                get{
                    return this.GetColumn("Description");
                }
            }
				
   			public static string DescriptionColumn{
			      get{
        			return "Description";
      			}
		    }
            
            public IColumn Active{
                get{
                    return this.GetColumn("Active");
                }
            }
				
   			public static string ActiveColumn{
			      get{
        			return "Active";
      			}
		    }
            
            public IColumn Creator{
                get{
                    return this.GetColumn("Creator");
                }
            }
				
   			public static string CreatorColumn{
			      get{
        			return "Creator";
      			}
		    }
            
            public IColumn Created{
                get{
                    return this.GetColumn("Created");
                }
            }
				
   			public static string CreatedColumn{
			      get{
        			return "Created";
      			}
		    }
            
            public IColumn Modifier{
                get{
                    return this.GetColumn("Modifier");
                }
            }
				
   			public static string ModifierColumn{
			      get{
        			return "Modifier";
      			}
		    }
            
            public IColumn Modified{
                get{
                    return this.GetColumn("Modified");
                }
            }
				
   			public static string ModifiedColumn{
			      get{
        			return "Modified";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: SectionType
        /// Primary Key: SectionTypeID
        /// </summary>

        public class SectionTypeTable: DatabaseTable {
            
            public SectionTypeTable(IDataProvider provider):base("SectionType",provider){
                ClassName = "SectionType";
                SchemaName = "dbo";
                

                Columns.Add(new DatabaseColumn("SectionTypeID", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = true,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("ShortName", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 20
                });

                Columns.Add(new DatabaseColumn("Description", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 1024
                });

                Columns.Add(new DatabaseColumn("Active", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiStringFixedLength,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 1
                });

                Columns.Add(new DatabaseColumn("Creator", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 20
                });

                Columns.Add(new DatabaseColumn("Created", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("Modifier", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 20
                });

                Columns.Add(new DatabaseColumn("Modified", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });
                    
                
                
            }
            
            public IColumn SectionTypeID{
                get{
                    return this.GetColumn("SectionTypeID");
                }
            }
				
   			public static string SectionTypeIDColumn{
			      get{
        			return "SectionTypeID";
      			}
		    }
            
            public IColumn ShortName{
                get{
                    return this.GetColumn("ShortName");
                }
            }
				
   			public static string ShortNameColumn{
			      get{
        			return "ShortName";
      			}
		    }
            
            public IColumn Description{
                get{
                    return this.GetColumn("Description");
                }
            }
				
   			public static string DescriptionColumn{
			      get{
        			return "Description";
      			}
		    }
            
            public IColumn Active{
                get{
                    return this.GetColumn("Active");
                }
            }
				
   			public static string ActiveColumn{
			      get{
        			return "Active";
      			}
		    }
            
            public IColumn Creator{
                get{
                    return this.GetColumn("Creator");
                }
            }
				
   			public static string CreatorColumn{
			      get{
        			return "Creator";
      			}
		    }
            
            public IColumn Created{
                get{
                    return this.GetColumn("Created");
                }
            }
				
   			public static string CreatedColumn{
			      get{
        			return "Created";
      			}
		    }
            
            public IColumn Modifier{
                get{
                    return this.GetColumn("Modifier");
                }
            }
				
   			public static string ModifierColumn{
			      get{
        			return "Modifier";
      			}
		    }
            
            public IColumn Modified{
                get{
                    return this.GetColumn("Modified");
                }
            }
				
   			public static string ModifiedColumn{
			      get{
        			return "Modified";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: CurrencyType
        /// Primary Key: CurrencyTypeID
        /// </summary>

        public class CurrencyTypeTable: DatabaseTable {
            
            public CurrencyTypeTable(IDataProvider provider):base("CurrencyType",provider){
                ClassName = "CurrencyType";
                SchemaName = "dbo";
                

                Columns.Add(new DatabaseColumn("CurrencyTypeID", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("ShortName", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 20
                });

                Columns.Add(new DatabaseColumn("Description", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 100
                });

                Columns.Add(new DatabaseColumn("Active", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiStringFixedLength,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 1
                });

                Columns.Add(new DatabaseColumn("Creator", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 20
                });

                Columns.Add(new DatabaseColumn("Created", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("Modifier", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 20
                });

                Columns.Add(new DatabaseColumn("Modified", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });
                    
                
                
            }
            
            public IColumn CurrencyTypeID{
                get{
                    return this.GetColumn("CurrencyTypeID");
                }
            }
				
   			public static string CurrencyTypeIDColumn{
			      get{
        			return "CurrencyTypeID";
      			}
		    }
            
            public IColumn ShortName{
                get{
                    return this.GetColumn("ShortName");
                }
            }
				
   			public static string ShortNameColumn{
			      get{
        			return "ShortName";
      			}
		    }
            
            public IColumn Description{
                get{
                    return this.GetColumn("Description");
                }
            }
				
   			public static string DescriptionColumn{
			      get{
        			return "Description";
      			}
		    }
            
            public IColumn Active{
                get{
                    return this.GetColumn("Active");
                }
            }
				
   			public static string ActiveColumn{
			      get{
        			return "Active";
      			}
		    }
            
            public IColumn Creator{
                get{
                    return this.GetColumn("Creator");
                }
            }
				
   			public static string CreatorColumn{
			      get{
        			return "Creator";
      			}
		    }
            
            public IColumn Created{
                get{
                    return this.GetColumn("Created");
                }
            }
				
   			public static string CreatedColumn{
			      get{
        			return "Created";
      			}
		    }
            
            public IColumn Modifier{
                get{
                    return this.GetColumn("Modifier");
                }
            }
				
   			public static string ModifierColumn{
			      get{
        			return "Modifier";
      			}
		    }
            
            public IColumn Modified{
                get{
                    return this.GetColumn("Modified");
                }
            }
				
   			public static string ModifiedColumn{
			      get{
        			return "Modified";
      			}
		    }
            
                    
        }
        
}