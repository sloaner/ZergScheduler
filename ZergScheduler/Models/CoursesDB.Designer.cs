﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Data.EntityClient;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Runtime.Serialization;

[assembly: EdmSchemaAttribute()]
#region EDM Relationship Metadata

[assembly: EdmRelationshipAttribute("ZergRushModel", "FK_Course_Department", "Department", System.Data.Metadata.Edm.RelationshipMultiplicity.One, typeof(ZergScheduler.Models.Department), "Course", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(ZergScheduler.Models.Course), true)]

#endregion

namespace ZergScheduler.Models
{
    #region Contexts
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    public partial class ZergRushEntities : ObjectContext
    {
        #region Constructors
    
        /// <summary>
        /// Initializes a new ZergRushEntities object using the connection string found in the 'ZergRushEntities' section of the application configuration file.
        /// </summary>
        public ZergRushEntities() : base("name=ZergRushEntities", "ZergRushEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new ZergRushEntities object.
        /// </summary>
        public ZergRushEntities(string connectionString) : base(connectionString, "ZergRushEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new ZergRushEntities object.
        /// </summary>
        public ZergRushEntities(EntityConnection connection) : base(connection, "ZergRushEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        #endregion
    
        #region Partial Methods
    
        partial void OnContextCreated();
    
        #endregion
    
        #region ObjectSet Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<Course> Courses
        {
            get
            {
                if ((_Courses == null))
                {
                    _Courses = base.CreateObjectSet<Course>("Courses");
                }
                return _Courses;
            }
        }
        private ObjectSet<Course> _Courses;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<Department> Departments
        {
            get
            {
                if ((_Departments == null))
                {
                    _Departments = base.CreateObjectSet<Department>("Departments");
                }
                return _Departments;
            }
        }
        private ObjectSet<Department> _Departments;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<GEP> GEPs
        {
            get
            {
                if ((_GEPs == null))
                {
                    _GEPs = base.CreateObjectSet<GEP>("GEPs");
                }
                return _GEPs;
            }
        }
        private ObjectSet<GEP> _GEPs;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<GFR> GFRs
        {
            get
            {
                if ((_GFRs == null))
                {
                    _GFRs = base.CreateObjectSet<GFR>("GFRs");
                }
                return _GFRs;
            }
        }
        private ObjectSet<GFR> _GFRs;

        #endregion
        #region AddTo Methods
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Courses EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToCourses(Course course)
        {
            base.AddObject("Courses", course);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Departments EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToDepartments(Department department)
        {
            base.AddObject("Departments", department);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the GEPs EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToGEPs(GEP gEP)
        {
            base.AddObject("GEPs", gEP);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the GFRs EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToGFRs(GFR gFR)
        {
            base.AddObject("GFRs", gFR);
        }

        #endregion
    }
    

    #endregion
    
    #region Entities
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="ZergRushModel", Name="Course")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Course : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new Course object.
        /// </summary>
        /// <param name="course_id">Initial value of the course_id property.</param>
        /// <param name="dept_id">Initial value of the dept_id property.</param>
        public static Course CreateCourse(global::System.String course_id, global::System.String dept_id)
        {
            Course course = new Course();
            course.course_id = course_id;
            course.dept_id = dept_id;
            return course;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String course_id
        {
            get
            {
                return _course_id;
            }
            set
            {
                if (_course_id != value)
                {
                    Oncourse_idChanging(value);
                    ReportPropertyChanging("course_id");
                    _course_id = StructuralObject.SetValidValue(value, false);
                    ReportPropertyChanged("course_id");
                    Oncourse_idChanged();
                }
            }
        }
        private global::System.String _course_id;
        partial void Oncourse_idChanging(global::System.String value);
        partial void Oncourse_idChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String dept_id
        {
            get
            {
                return _dept_id;
            }
            set
            {
                Ondept_idChanging(value);
                ReportPropertyChanging("dept_id");
                _dept_id = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("dept_id");
                Ondept_idChanged();
            }
        }
        private global::System.String _dept_id;
        partial void Ondept_idChanging(global::System.String value);
        partial void Ondept_idChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String course_no
        {
            get
            {
                return _course_no;
            }
            set
            {
                Oncourse_noChanging(value);
                ReportPropertyChanging("course_no");
                _course_no = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("course_no");
                Oncourse_noChanged();
            }
        }
        private global::System.String _course_no;
        partial void Oncourse_noChanging(global::System.String value);
        partial void Oncourse_noChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String title
        {
            get
            {
                return _title;
            }
            set
            {
                OntitleChanging(value);
                ReportPropertyChanging("title");
                _title = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("title");
                OntitleChanged();
            }
        }
        private global::System.String _title;
        partial void OntitleChanging(global::System.String value);
        partial void OntitleChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String description
        {
            get
            {
                return _description;
            }
            set
            {
                OndescriptionChanging(value);
                ReportPropertyChanging("description");
                _description = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("description");
                OndescriptionChanged();
            }
        }
        private global::System.String _description;
        partial void OndescriptionChanging(global::System.String value);
        partial void OndescriptionChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Int32> credits
        {
            get
            {
                return _credits;
            }
            set
            {
                OncreditsChanging(value);
                ReportPropertyChanging("credits");
                _credits = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("credits");
                OncreditsChanged();
            }
        }
        private Nullable<global::System.Int32> _credits;
        partial void OncreditsChanging(Nullable<global::System.Int32> value);
        partial void OncreditsChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String career
        {
            get
            {
                return _career;
            }
            set
            {
                OncareerChanging(value);
                ReportPropertyChanging("career");
                _career = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("career");
                OncareerChanged();
            }
        }
        private global::System.String _career;
        partial void OncareerChanging(global::System.String value);
        partial void OncareerChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Int32> gfr
        {
            get
            {
                return _gfr;
            }
            set
            {
                OngfrChanging(value);
                ReportPropertyChanging("gfr");
                _gfr = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("gfr");
                OngfrChanged();
            }
        }
        private Nullable<global::System.Int32> _gfr;
        partial void OngfrChanging(Nullable<global::System.Int32> value);
        partial void OngfrChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Int32> gep
        {
            get
            {
                return _gep;
            }
            set
            {
                OngepChanging(value);
                ReportPropertyChanging("gep");
                _gep = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("gep");
                OngepChanged();
            }
        }
        private Nullable<global::System.Int32> _gep;
        partial void OngepChanging(Nullable<global::System.Int32> value);
        partial void OngepChanged();

        #endregion
    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("ZergRushModel", "FK_Course_Department", "Department")]
        public Department Department
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Department>("ZergRushModel.FK_Course_Department", "Department").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Department>("ZergRushModel.FK_Course_Department", "Department").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<Department> DepartmentReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Department>("ZergRushModel.FK_Course_Department", "Department");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<Department>("ZergRushModel.FK_Course_Department", "Department", value);
                }
            }
        }

        #endregion
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="ZergRushModel", Name="Department")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Department : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new Department object.
        /// </summary>
        /// <param name="dept_id">Initial value of the dept_id property.</param>
        /// <param name="dept_title">Initial value of the dept_title property.</param>
        public static Department CreateDepartment(global::System.String dept_id, global::System.String dept_title)
        {
            Department department = new Department();
            department.dept_id = dept_id;
            department.dept_title = dept_title;
            return department;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String dept_id
        {
            get
            {
                return _dept_id;
            }
            set
            {
                if (_dept_id != value)
                {
                    Ondept_idChanging(value);
                    ReportPropertyChanging("dept_id");
                    _dept_id = StructuralObject.SetValidValue(value, false);
                    ReportPropertyChanged("dept_id");
                    Ondept_idChanged();
                }
            }
        }
        private global::System.String _dept_id;
        partial void Ondept_idChanging(global::System.String value);
        partial void Ondept_idChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String dept_title
        {
            get
            {
                return _dept_title;
            }
            set
            {
                Ondept_titleChanging(value);
                ReportPropertyChanging("dept_title");
                _dept_title = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("dept_title");
                Ondept_titleChanged();
            }
        }
        private global::System.String _dept_title;
        partial void Ondept_titleChanging(global::System.String value);
        partial void Ondept_titleChanged();

        #endregion
    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("ZergRushModel", "FK_Course_Department", "Course")]
        public EntityCollection<Course> Courses
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<Course>("ZergRushModel.FK_Course_Department", "Course");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<Course>("ZergRushModel.FK_Course_Department", "Course", value);
                }
            }
        }

        #endregion
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="ZergRushModel", Name="GEP")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class GEP : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new GEP object.
        /// </summary>
        /// <param name="value">Initial value of the value property.</param>
        /// <param name="id">Initial value of the id property.</param>
        /// <param name="name">Initial value of the name property.</param>
        public static GEP CreateGEP(global::System.Int32 value, global::System.String id, global::System.String name)
        {
            GEP gEP = new GEP();
            gEP.value = value;
            gEP.id = id;
            gEP.name = name;
            return gEP;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 value
        {
            get
            {
                return _value;
            }
            set
            {
                if (_value != value)
                {
                    OnvalueChanging(value);
                    ReportPropertyChanging("value");
                    _value = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("value");
                    OnvalueChanged();
                }
            }
        }
        private global::System.Int32 _value;
        partial void OnvalueChanging(global::System.Int32 value);
        partial void OnvalueChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String id
        {
            get
            {
                return _id;
            }
            set
            {
                OnidChanging(value);
                ReportPropertyChanging("id");
                _id = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("id");
                OnidChanged();
            }
        }
        private global::System.String _id;
        partial void OnidChanging(global::System.String value);
        partial void OnidChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String name
        {
            get
            {
                return _name;
            }
            set
            {
                OnnameChanging(value);
                ReportPropertyChanging("name");
                _name = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("name");
                OnnameChanged();
            }
        }
        private global::System.String _name;
        partial void OnnameChanging(global::System.String value);
        partial void OnnameChanged();

        #endregion
    
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="ZergRushModel", Name="GFR")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class GFR : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new GFR object.
        /// </summary>
        /// <param name="value">Initial value of the value property.</param>
        /// <param name="id">Initial value of the id property.</param>
        /// <param name="name">Initial value of the name property.</param>
        public static GFR CreateGFR(global::System.Int32 value, global::System.String id, global::System.String name)
        {
            GFR gFR = new GFR();
            gFR.value = value;
            gFR.id = id;
            gFR.name = name;
            return gFR;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 value
        {
            get
            {
                return _value;
            }
            set
            {
                if (_value != value)
                {
                    OnvalueChanging(value);
                    ReportPropertyChanging("value");
                    _value = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("value");
                    OnvalueChanged();
                }
            }
        }
        private global::System.Int32 _value;
        partial void OnvalueChanging(global::System.Int32 value);
        partial void OnvalueChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String id
        {
            get
            {
                return _id;
            }
            set
            {
                OnidChanging(value);
                ReportPropertyChanging("id");
                _id = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("id");
                OnidChanged();
            }
        }
        private global::System.String _id;
        partial void OnidChanging(global::System.String value);
        partial void OnidChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String name
        {
            get
            {
                return _name;
            }
            set
            {
                OnnameChanging(value);
                ReportPropertyChanging("name");
                _name = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("name");
                OnnameChanged();
            }
        }
        private global::System.String _name;
        partial void OnnameChanging(global::System.String value);
        partial void OnnameChanged();

        #endregion
    
    }

    #endregion
    
}
