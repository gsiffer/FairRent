using FairRent.Business;
using FairRent.Common;
using FairRent.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FairRent
{
    class ClientViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private Client displayClient;
        public Client DisplayClient
        {
            get => displayClient;
            set => displayClient = value;
        }

        private readonly DataTable dtClients;
        public DataTable DtClients => dtClients;

        public ClientViewModel()
        {
            dtClients = ClientValidation.GetClients();
        }

        //private void AddAutoIndexColumn()
        //{
        //    DataColumn idx = new DataColumn();
        //    idx.ColumnName = "idx";
        //    idx.DataType = typeof(int);
        //    idx.AutoIncrement = true;
        //    idx.AutoIncrementSeed = 0;
        //    idx.AutoIncrementStep = 1;
        //    dtClients.Columns.Add(idx);
        //}
    }
}
