﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Data.EntityClient;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml.Serialization;

[assembly: EdmSchemaAttribute()]
#region EDM Relationship Metadata

[assembly: EdmRelationshipAttribute("blogpostsModel", "FK_blogcomments_blogposts", "blogposts", System.Data.Metadata.Edm.RelationshipMultiplicity.One, typeof(blogpostsModel.blogpost), "blogcomments", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(blogpostsModel.blogcomment), true)]

#endregion

namespace blogpostsModel
{
    #region Contexts
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    public partial class blogdbEntities : ObjectContext
    {
        #region Constructors
    
        /// <summary>
        /// Initializes a new blogdbEntities object using the connection string found in the 'blogdbEntities' section of the application configuration file.
        /// </summary>
        public blogdbEntities() : base("name=blogdbEntities", "blogdbEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new blogdbEntities object.
        /// </summary>
        public blogdbEntities(string connectionString) : base(connectionString, "blogdbEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new blogdbEntities object.
        /// </summary>
        public blogdbEntities(EntityConnection connection) : base(connection, "blogdbEntities")
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
        public ObjectSet<blogcomment> blogcomments
        {
            get
            {
                if ((_blogcomments == null))
                {
                    _blogcomments = base.CreateObjectSet<blogcomment>("blogcomments");
                }
                return _blogcomments;
            }
        }
        private ObjectSet<blogcomment> _blogcomments;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<blogpost> blogposts
        {
            get
            {
                if ((_blogposts == null))
                {
                    _blogposts = base.CreateObjectSet<blogpost>("blogposts");
                }
                return _blogposts;
            }
        }
        private ObjectSet<blogpost> _blogposts;

        #endregion

        #region AddTo Methods
    
        /// <summary>
        /// Deprecated Method for adding a new object to the blogcomments EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToblogcomments(blogcomment blogcomment)
        {
            base.AddObject("blogcomments", blogcomment);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the blogposts EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToblogposts(blogpost blogpost)
        {
            base.AddObject("blogposts", blogpost);
        }

        #endregion

    }

    #endregion

    #region Entities
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="blogpostsModel", Name="blogcomment")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class blogcomment : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new blogcomment object.
        /// </summary>
        /// <param name="cID">Initial value of the cID property.</param>
        /// <param name="commentID">Initial value of the commentID property.</param>
        public static blogcomment Createblogcomment(global::System.Int32 cID, global::System.Int32 commentID)
        {
            blogcomment blogcomment = new blogcomment();
            blogcomment.cID = cID;
            blogcomment.commentID = commentID;
            return blogcomment;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 cID
        {
            get
            {
                return _cID;
            }
            set
            {
                if (_cID != value)
                {
                    OncIDChanging(value);
                    ReportPropertyChanging("cID");
                    _cID = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("cID");
                    OncIDChanged();
                }
            }
        }
        private global::System.Int32 _cID;
        partial void OncIDChanging(global::System.Int32 value);
        partial void OncIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String commentMsgText
        {
            get
            {
                return _commentMsgText;
            }
            set
            {
                OncommentMsgTextChanging(value);
                ReportPropertyChanging("commentMsgText");
                _commentMsgText = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("commentMsgText");
                OncommentMsgTextChanged();
            }
        }
        private global::System.String _commentMsgText;
        partial void OncommentMsgTextChanging(global::System.String value);
        partial void OncommentMsgTextChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 commentID
        {
            get
            {
                return _commentID;
            }
            set
            {
                OncommentIDChanging(value);
                ReportPropertyChanging("commentID");
                _commentID = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("commentID");
                OncommentIDChanged();
            }
        }
        private global::System.Int32 _commentID;
        partial void OncommentIDChanging(global::System.Int32 value);
        partial void OncommentIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String commentName
        {
            get
            {
                return _commentName;
            }
            set
            {
                OncommentNameChanging(value);
                ReportPropertyChanging("commentName");
                _commentName = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("commentName");
                OncommentNameChanged();
            }
        }
        private global::System.String _commentName;
        partial void OncommentNameChanging(global::System.String value);
        partial void OncommentNameChanged();

        #endregion

    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("blogpostsModel", "FK_blogcomments_blogposts", "blogposts")]
        public blogpost blogpost
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<blogpost>("blogpostsModel.FK_blogcomments_blogposts", "blogposts").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<blogpost>("blogpostsModel.FK_blogcomments_blogposts", "blogposts").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<blogpost> blogpostReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<blogpost>("blogpostsModel.FK_blogcomments_blogposts", "blogposts");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<blogpost>("blogpostsModel.FK_blogcomments_blogposts", "blogposts", value);
                }
            }
        }

        #endregion

    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="blogpostsModel", Name="blogpost")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class blogpost : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new blogpost object.
        /// </summary>
        /// <param name="blogID">Initial value of the blogID property.</param>
        public static blogpost Createblogpost(global::System.Int32 blogID)
        {
            blogpost blogpost = new blogpost();
            blogpost.blogID = blogID;
            return blogpost;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 blogID
        {
            get
            {
                return _blogID;
            }
            set
            {
                if (_blogID != value)
                {
                    OnblogIDChanging(value);
                    ReportPropertyChanging("blogID");
                    _blogID = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("blogID");
                    OnblogIDChanged();
                }
            }
        }
        private global::System.Int32 _blogID;
        partial void OnblogIDChanging(global::System.Int32 value);
        partial void OnblogIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String blogMsgText
        {
            get
            {
                return _blogMsgText;
            }
            set
            {
                OnblogMsgTextChanging(value);
                ReportPropertyChanging("blogMsgText");
                _blogMsgText = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("blogMsgText");
                OnblogMsgTextChanged();
            }
        }
        private global::System.String _blogMsgText;
        partial void OnblogMsgTextChanging(global::System.String value);
        partial void OnblogMsgTextChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.DateTime> lastedited
        {
            get
            {
                return _lastedited;
            }
            set
            {
                OnlasteditedChanging(value);
                ReportPropertyChanging("lastedited");
                _lastedited = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("lastedited");
                OnlasteditedChanged();
            }
        }
        private Nullable<global::System.DateTime> _lastedited;
        partial void OnlasteditedChanging(Nullable<global::System.DateTime> value);
        partial void OnlasteditedChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.DateTime> posted
        {
            get
            {
                return _posted;
            }
            set
            {
                OnpostedChanging(value);
                ReportPropertyChanging("posted");
                _posted = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("posted");
                OnpostedChanged();
            }
        }
        private Nullable<global::System.DateTime> _posted;
        partial void OnpostedChanging(Nullable<global::System.DateTime> value);
        partial void OnpostedChanged();

        #endregion

    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("blogpostsModel", "FK_blogcomments_blogposts", "blogcomments")]
        public EntityCollection<blogcomment> blogcomments
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<blogcomment>("blogpostsModel.FK_blogcomments_blogposts", "blogcomments");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<blogcomment>("blogpostsModel.FK_blogcomments_blogposts", "blogcomments", value);
                }
            }
        }

        #endregion

    }

    #endregion

    
}
