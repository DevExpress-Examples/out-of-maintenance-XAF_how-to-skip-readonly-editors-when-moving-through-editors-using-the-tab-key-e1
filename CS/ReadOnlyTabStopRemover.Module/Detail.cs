using System;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;

namespace ReadOnlyTabStopRemover.Module
{
    [NavigationItem(true)]
    public class Detail : BaseObject
    {
        public Detail(Session session) : base (session)
        {

        }

        #region DocumentNumber

        private string _property;

        [Size(10)]
        public string DocumentNumber
        {
            get
            {
                return _property;
            }
            set
            {
                SetPropertyValue<string>("DocumentNumber", ref _property, value);
            }
        }

        #endregion

        #region DocumentNumberRO

        public string DocumentNumberRO
        {
            get
            {
                return this.DocumentNumber;
            }
        }

        #endregion

        #region DocumentReference

        private string _documentReference;

        [Size(10)]
        public string DocumentReference
        {
            get
            {
                return _documentReference;
            }
            set
            {
                SetPropertyValue<string>("DocumentReference", ref _documentReference, value);
            }
        }

        #endregion

        #region DocumentReferenceRO

        public string DocumentReferenceRO
        {
            get
            {
                return this.DocumentReference;
            }
        }

        #endregion

        #region DocumentDate

        private DateTime _documentDate;

        public DateTime DocumentDate
        {
            get
            {
                return _documentDate;
            }
            set
            {
                SetPropertyValue<DateTime>("DocumentDate", ref _documentDate, value);
            }
        }

        #endregion

        #region DocumentDateRO

        public DateTime DocumentDateRO
        {
            get
            {
                return this.DocumentDate;
            }
        }

        #endregion
    }
}
