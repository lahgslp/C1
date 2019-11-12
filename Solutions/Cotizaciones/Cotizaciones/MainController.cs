using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cotizaciones.Views;
using Cotizaciones.Enums;

namespace Cotizaciones
{
    public sealed class MainController
    {
        private static volatile MainController instance;
        private static object syncRoot = new Object();

        public delegate void ViewHandler();
        public delegate void StatusBarHandler(StatusBarElements barElement, string message);
        public ViewHandler Handler;
        public StatusBarHandler BarHandler;
        BaseView currentControl;

        public static MainController Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new MainController();
                        }
                    }
                }

                return instance;
            }
        }

        private void RefreshView()
        {
            this.Handler();
        }

        public Control GetNextControl(bool readOnlyMode)
        {
            if (currentControl == null)
            {
                currentControl = new MyQuotationsView(readOnlyMode);
            }
            return currentControl;
        }

        public void Next(BaseView nextControl)
        {
            currentControl = nextControl;
            this.RefreshView();
        }

        public void ChangeStatusBar(StatusBarElements barElement, string message)
        {
            this.BarHandler(barElement, message);
        }
    }
}