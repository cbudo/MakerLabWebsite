﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RoseMakerSpace
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="333_MakerLab")]
	public partial class MakerLabDBDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertExternal_Resource(External_Resource instance);
    partial void UpdateExternal_Resource(External_Resource instance);
    partial void DeleteExternal_Resource(External_Resource instance);
    partial void InsertMaker_Lab_Part(Maker_Lab_Part instance);
    partial void UpdateMaker_Lab_Part(Maker_Lab_Part instance);
    partial void DeleteMaker_Lab_Part(Maker_Lab_Part instance);
    partial void InsertMaker_Lab_Tool(Maker_Lab_Tool instance);
    partial void UpdateMaker_Lab_Tool(Maker_Lab_Tool instance);
    partial void DeleteMaker_Lab_Tool(Maker_Lab_Tool instance);
    partial void InsertProject(Project instance);
    partial void UpdateProject(Project instance);
    partial void DeleteProject(Project instance);
    partial void InsertSkill(Skill instance);
    partial void UpdateSkill(Skill instance);
    partial void DeleteSkill(Skill instance);
    partial void InsertStudent(Student instance);
    partial void UpdateStudent(Student instance);
    partial void DeleteStudent(Student instance);
    #endregion
		
		public MakerLabDBDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["_333_MakerLabConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public MakerLabDBDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public MakerLabDBDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public MakerLabDBDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public MakerLabDBDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<External_Resource> External_Resources
		{
			get
			{
				return this.GetTable<External_Resource>();
			}
		}
		
		public System.Data.Linq.Table<Leader> Leaders
		{
			get
			{
				return this.GetTable<Leader>();
			}
		}
		
		public System.Data.Linq.Table<Student_Training> Student_Trainings
		{
			get
			{
				return this.GetTable<Student_Training>();
			}
		}
		
		public System.Data.Linq.Table<Maker_Lab_Part> Maker_Lab_Parts
		{
			get
			{
				return this.GetTable<Maker_Lab_Part>();
			}
		}
		
		public System.Data.Linq.Table<Maker_Lab_Tool> Maker_Lab_Tools
		{
			get
			{
				return this.GetTable<Maker_Lab_Tool>();
			}
		}
		
		public System.Data.Linq.Table<Project> Projects
		{
			get
			{
				return this.GetTable<Project>();
			}
		}
		
		public System.Data.Linq.Table<Project_Ext_Resource> Project_Ext_Resources
		{
			get
			{
				return this.GetTable<Project_Ext_Resource>();
			}
		}
		
		public System.Data.Linq.Table<Project_MLPart> Project_MLParts
		{
			get
			{
				return this.GetTable<Project_MLPart>();
			}
		}
		
		public System.Data.Linq.Table<Project_MLTool> Project_MLTools
		{
			get
			{
				return this.GetTable<Project_MLTool>();
			}
		}
		
		public System.Data.Linq.Table<Skill> Skills
		{
			get
			{
				return this.GetTable<Skill>();
			}
		}
		
		public System.Data.Linq.Table<Student> Students
		{
			get
			{
				return this.GetTable<Student>();
			}
		}
		
		public System.Data.Linq.Table<Student_Project> Student_Projects
		{
			get
			{
				return this.GetTable<Student_Project>();
			}
		}
		
		public System.Data.Linq.Table<Student_Skill> Student_Skills
		{
			get
			{
				return this.GetTable<Student_Skill>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.External_Resource")]
	public partial class External_Resource : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private string _Name;
		
		private string _Location;
		
		private string _Description;
		
		private int _Total;
		
		private System.Nullable<byte> _Access_Level;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnLocationChanging(string value);
    partial void OnLocationChanged();
    partial void OnDescriptionChanging(string value);
    partial void OnDescriptionChanged();
    partial void OnTotalChanging(int value);
    partial void OnTotalChanged();
    partial void OnAccess_LevelChanging(System.Nullable<byte> value);
    partial void OnAccess_LevelChanged();
    #endregion
		
		public External_Resource()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(30) NOT NULL", CanBeNull=false)]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Location", DbType="NVarChar(30) NOT NULL", CanBeNull=false)]
		public string Location
		{
			get
			{
				return this._Location;
			}
			set
			{
				if ((this._Location != value))
				{
					this.OnLocationChanging(value);
					this.SendPropertyChanging();
					this._Location = value;
					this.SendPropertyChanged("Location");
					this.OnLocationChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Description", DbType="NVarChar(MAX) NOT NULL", CanBeNull=false)]
		public string Description
		{
			get
			{
				return this._Description;
			}
			set
			{
				if ((this._Description != value))
				{
					this.OnDescriptionChanging(value);
					this.SendPropertyChanging();
					this._Description = value;
					this.SendPropertyChanged("Description");
					this.OnDescriptionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Total", DbType="Int NOT NULL")]
		public int Total
		{
			get
			{
				return this._Total;
			}
			set
			{
				if ((this._Total != value))
				{
					this.OnTotalChanging(value);
					this.SendPropertyChanging();
					this._Total = value;
					this.SendPropertyChanged("Total");
					this.OnTotalChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Access_Level", DbType="TinyInt")]
		public System.Nullable<byte> Access_Level
		{
			get
			{
				return this._Access_Level;
			}
			set
			{
				if ((this._Access_Level != value))
				{
					this.OnAccess_LevelChanging(value);
					this.SendPropertyChanging();
					this._Access_Level = value;
					this.SendPropertyChanged("Access_Level");
					this.OnAccess_LevelChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Leader")]
	public partial class Leader
	{
		
		private System.Nullable<int> _Student_ID;
		
		private string _Position_Held;
		
		private System.Nullable<int> _Position_Year;
		
		public Leader()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Student_ID", DbType="Int")]
		public System.Nullable<int> Student_ID
		{
			get
			{
				return this._Student_ID;
			}
			set
			{
				if ((this._Student_ID != value))
				{
					this._Student_ID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Position_Held", DbType="Char(20)")]
		public string Position_Held
		{
			get
			{
				return this._Position_Held;
			}
			set
			{
				if ((this._Position_Held != value))
				{
					this._Position_Held = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Position_Year", DbType="Int")]
		public System.Nullable<int> Position_Year
		{
			get
			{
				return this._Position_Year;
			}
			set
			{
				if ((this._Position_Year != value))
				{
					this._Position_Year = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Student_Training")]
	public partial class Student_Training
	{
		
		private System.Nullable<int> _Student_ID;
		
		private System.Nullable<int> _MakerLab_Tool_ID;
		
		private string _Student_Training1;
		
		public Student_Training()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Student_ID", DbType="Int")]
		public System.Nullable<int> Student_ID
		{
			get
			{
				return this._Student_ID;
			}
			set
			{
				if ((this._Student_ID != value))
				{
					this._Student_ID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MakerLab_Tool_ID", DbType="Int")]
		public System.Nullable<int> MakerLab_Tool_ID
		{
			get
			{
				return this._MakerLab_Tool_ID;
			}
			set
			{
				if ((this._MakerLab_Tool_ID != value))
				{
					this._MakerLab_Tool_ID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="Student_Training", Storage="_Student_Training1", DbType="Char(30)")]
		public string Student_Training1
		{
			get
			{
				return this._Student_Training1;
			}
			set
			{
				if ((this._Student_Training1 != value))
				{
					this._Student_Training1 = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Maker_Lab_Part")]
	public partial class Maker_Lab_Part : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private string _Name;
		
		private int _Quantity;
		
		private int _Buy_More_at;
		
		private string _Purchase_Loc;
		
		private System.Nullable<decimal> _Last_Price;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnQuantityChanging(int value);
    partial void OnQuantityChanged();
    partial void OnBuy_More_atChanging(int value);
    partial void OnBuy_More_atChanged();
    partial void OnPurchase_LocChanging(string value);
    partial void OnPurchase_LocChanged();
    partial void OnLast_PriceChanging(System.Nullable<decimal> value);
    partial void OnLast_PriceChanged();
    #endregion
		
		public Maker_Lab_Part()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(30) NOT NULL", CanBeNull=false)]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Quantity", DbType="Int NOT NULL")]
		public int Quantity
		{
			get
			{
				return this._Quantity;
			}
			set
			{
				if ((this._Quantity != value))
				{
					this.OnQuantityChanging(value);
					this.SendPropertyChanging();
					this._Quantity = value;
					this.SendPropertyChanged("Quantity");
					this.OnQuantityChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Buy_More_at", DbType="Int NOT NULL")]
		public int Buy_More_at
		{
			get
			{
				return this._Buy_More_at;
			}
			set
			{
				if ((this._Buy_More_at != value))
				{
					this.OnBuy_More_atChanging(value);
					this.SendPropertyChanging();
					this._Buy_More_at = value;
					this.SendPropertyChanged("Buy_More_at");
					this.OnBuy_More_atChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Purchase_Loc", DbType="NVarChar(MAX) NOT NULL", CanBeNull=false)]
		public string Purchase_Loc
		{
			get
			{
				return this._Purchase_Loc;
			}
			set
			{
				if ((this._Purchase_Loc != value))
				{
					this.OnPurchase_LocChanging(value);
					this.SendPropertyChanging();
					this._Purchase_Loc = value;
					this.SendPropertyChanged("Purchase_Loc");
					this.OnPurchase_LocChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Last_Price", DbType="Decimal(7,2)")]
		public System.Nullable<decimal> Last_Price
		{
			get
			{
				return this._Last_Price;
			}
			set
			{
				if ((this._Last_Price != value))
				{
					this.OnLast_PriceChanging(value);
					this.SendPropertyChanging();
					this._Last_Price = value;
					this.SendPropertyChanged("Last_Price");
					this.OnLast_PriceChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Maker_Lab_Tool")]
	public partial class Maker_Lab_Tool : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private string _Name;
		
		private string _Description;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnDescriptionChanging(string value);
    partial void OnDescriptionChanged();
    #endregion
		
		public Maker_Lab_Tool()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(30) NOT NULL", CanBeNull=false)]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Description", DbType="NVarChar(MAX) NOT NULL", CanBeNull=false)]
		public string Description
		{
			get
			{
				return this._Description;
			}
			set
			{
				if ((this._Description != value))
				{
					this.OnDescriptionChanging(value);
					this.SendPropertyChanging();
					this._Description = value;
					this.SendPropertyChanged("Description");
					this.OnDescriptionChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Project")]
	public partial class Project : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private string _Name;
		
		private string _Description;
		
		private string _Image_Gallery;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnDescriptionChanging(string value);
    partial void OnDescriptionChanged();
    partial void OnImage_GalleryChanging(string value);
    partial void OnImage_GalleryChanged();
    #endregion
		
		public Project()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(30) NOT NULL", CanBeNull=false)]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Description", DbType="NVarChar(MAX) NOT NULL", CanBeNull=false)]
		public string Description
		{
			get
			{
				return this._Description;
			}
			set
			{
				if ((this._Description != value))
				{
					this.OnDescriptionChanging(value);
					this.SendPropertyChanging();
					this._Description = value;
					this.SendPropertyChanged("Description");
					this.OnDescriptionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Image_Gallery", DbType="NVarChar(MAX)")]
		public string Image_Gallery
		{
			get
			{
				return this._Image_Gallery;
			}
			set
			{
				if ((this._Image_Gallery != value))
				{
					this.OnImage_GalleryChanging(value);
					this.SendPropertyChanging();
					this._Image_Gallery = value;
					this.SendPropertyChanged("Image_Gallery");
					this.OnImage_GalleryChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Project_Ext_Resource")]
	public partial class Project_Ext_Resource
	{
		
		private System.Nullable<int> _Resource_ID;
		
		private System.Nullable<int> _Project_ID;
		
		public Project_Ext_Resource()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Resource_ID", DbType="Int")]
		public System.Nullable<int> Resource_ID
		{
			get
			{
				return this._Resource_ID;
			}
			set
			{
				if ((this._Resource_ID != value))
				{
					this._Resource_ID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Project_ID", DbType="Int")]
		public System.Nullable<int> Project_ID
		{
			get
			{
				return this._Project_ID;
			}
			set
			{
				if ((this._Project_ID != value))
				{
					this._Project_ID = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Project_MLPart")]
	public partial class Project_MLPart
	{
		
		private System.Nullable<int> _MLPart_ID;
		
		private System.Nullable<int> _Project_ID;
		
		public Project_MLPart()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MLPart_ID", DbType="Int")]
		public System.Nullable<int> MLPart_ID
		{
			get
			{
				return this._MLPart_ID;
			}
			set
			{
				if ((this._MLPart_ID != value))
				{
					this._MLPart_ID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Project_ID", DbType="Int")]
		public System.Nullable<int> Project_ID
		{
			get
			{
				return this._Project_ID;
			}
			set
			{
				if ((this._Project_ID != value))
				{
					this._Project_ID = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Project_MLTool")]
	public partial class Project_MLTool
	{
		
		private System.Nullable<int> _MLTool_ID;
		
		private System.Nullable<int> _Project_ID;
		
		public Project_MLTool()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MLTool_ID", DbType="Int")]
		public System.Nullable<int> MLTool_ID
		{
			get
			{
				return this._MLTool_ID;
			}
			set
			{
				if ((this._MLTool_ID != value))
				{
					this._MLTool_ID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Project_ID", DbType="Int")]
		public System.Nullable<int> Project_ID
		{
			get
			{
				return this._Project_ID;
			}
			set
			{
				if ((this._Project_ID != value))
				{
					this._Project_ID = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Skill")]
	public partial class Skill : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private string _Name;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    #endregion
		
		public Skill()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(30) NOT NULL", CanBeNull=false)]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Student")]
	public partial class Student : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _StudentID;
		
		private string _Email;
		
		private string _Name;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnStudentIDChanging(int value);
    partial void OnStudentIDChanged();
    partial void OnEmailChanging(string value);
    partial void OnEmailChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    #endregion
		
		public Student()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_StudentID", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int StudentID
		{
			get
			{
				return this._StudentID;
			}
			set
			{
				if ((this._StudentID != value))
				{
					this.OnStudentIDChanging(value);
					this.SendPropertyChanging();
					this._StudentID = value;
					this.SendPropertyChanged("StudentID");
					this.OnStudentIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Email", DbType="NVarChar(25) NOT NULL", CanBeNull=false)]
		public string Email
		{
			get
			{
				return this._Email;
			}
			set
			{
				if ((this._Email != value))
				{
					this.OnEmailChanging(value);
					this.SendPropertyChanging();
					this._Email = value;
					this.SendPropertyChanged("Email");
					this.OnEmailChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(MAX) NOT NULL", CanBeNull=false)]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Student_Project")]
	public partial class Student_Project
	{
		
		private System.Nullable<int> _Student_ID;
		
		private System.Nullable<int> _Project_ID;
		
		private System.Nullable<System.DateTime> _Last_update;
		
		public Student_Project()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Student_ID", DbType="Int")]
		public System.Nullable<int> Student_ID
		{
			get
			{
				return this._Student_ID;
			}
			set
			{
				if ((this._Student_ID != value))
				{
					this._Student_ID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Project_ID", DbType="Int")]
		public System.Nullable<int> Project_ID
		{
			get
			{
				return this._Project_ID;
			}
			set
			{
				if ((this._Project_ID != value))
				{
					this._Project_ID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Last_update", DbType="SmallDateTime")]
		public System.Nullable<System.DateTime> Last_update
		{
			get
			{
				return this._Last_update;
			}
			set
			{
				if ((this._Last_update != value))
				{
					this._Last_update = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Student_Skill")]
	public partial class Student_Skill
	{
		
		private System.Nullable<int> _Student_ID;
		
		private System.Nullable<int> _Student_Skill1;
		
		public Student_Skill()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Student_ID", DbType="Int")]
		public System.Nullable<int> Student_ID
		{
			get
			{
				return this._Student_ID;
			}
			set
			{
				if ((this._Student_ID != value))
				{
					this._Student_ID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="Student_Skill", Storage="_Student_Skill1", DbType="Int")]
		public System.Nullable<int> Student_Skill1
		{
			get
			{
				return this._Student_Skill1;
			}
			set
			{
				if ((this._Student_Skill1 != value))
				{
					this._Student_Skill1 = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
