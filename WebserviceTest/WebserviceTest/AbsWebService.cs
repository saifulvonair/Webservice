//######################################################################
//# FILENAME: ApplicationInstanceChecker
//#
//# DESCRIPTION:
//# 
//#
//# AUTHOR:		Mohammad Saiful Alam
//# POSITION:	Senior General Manager
//# E-MAIL:		saiful.alam@ bjitgroup.com
//# CREATE DATE: ...
//#
//# Copyright (c): Free to use
//######################################################################

using System;
using System.ComponentModel;
using System.Net;
using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace CallWebService
{
    public abstract class AbsWebService: IWebService
    {
        protected Label mProgress;
        protected DateTime start;
        protected string downloadLocation;
        protected string url;
        protected IDelegeateObserver mDelegeateObserver;
        //
        public Label Progress
        {
            get
            {
                return mProgress;
            }

            set
            {
                mProgress = value;
            }
        }
        //
        public string URL { get { return url; } }
        //
        object mObject;
        public object Tag
        {
            get
            {
                return mObject;
            }

            set
            {
                mObject = value;
            }
        }
       
        public string Status
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IDelegeateObserver DelegeateObserver
        {
            get
            {
                return mDelegeateObserver;
            }

            set
            {
                mDelegeateObserver = value;
            }
        }

        //
        public AbsWebService(Label progress)
        {
            this.mProgress = progress;
            NetworkChange.NetworkAvailabilityChanged += OnAvailabilityChangeHandler;
        }

        public void cancel()
        {
            
        }
              
        //
        void OnAvailabilityChangeHandler(object sender, NetworkAvailabilityEventArgs e)
        {
            if (mDelegeateObserver != null)
            {
                uodateStatus("Network: " + e.IsAvailable.ToString());
                mDelegeateObserver.Invoke(e);
            }
        }

        //
        protected void uodateStatus(String message)
        {
            if (this.Progress != null)
            {

                if (this.Progress.InvokeRequired)
                {
                    this.Progress.BeginInvoke((MethodInvoker)delegate
                    {
                        this.Progress.Text = message;
                        return;
                    });
                }
                else
                {
                    this.Progress.Text = message;
                }
            }
        }

        abstract public void execute(ApiCallArgument apiArgument, IDelegeateObserver observer);

        public void notifyObserver(object responseAsType)
        {
            if (mDelegeateObserver != null)
            {
                mDelegeateObserver.Invoke(responseAsType);
            }
        }
       
    }
}
