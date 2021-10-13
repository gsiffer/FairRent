using FairRent.Business;
using FairRent.Common;
using FairRent.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FairRent
{
    class WorkSheetViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public const int DEFAULT_MULTIPLIER = 1;

        private WorkSheet displayWorkSheet;
        public WorkSheet DisplayWorkSheet
        {
            get { return displayWorkSheet; }
            set
            {
                displayWorkSheet = new WorkSheet
                {
                    ID = value.ID,
                    PlateNumber = value.PlateNumber,
                    ClientName = value.ClientName,
                    Phone1 = value.Phone1,
                    Discount = value.Discount,
                    Multiplier = value.Multiplier,
                    EmailAddress = value.EmailAddress,
                    CarManufacturer = value.CarManufacturer,
                    CarType = value.CarType,
                    InspectionDate = value.InspectionDate,
                    Odometer = value.Odometer,
                    IsActive = value.IsActive,
                    CreateDate = value.CreateDate,
                    Notes = value.Notes,
                    NetHourFee = value.NetHourFee,
                    Tax = value.Tax,
                    Parts = value.Parts,
                    WorkFees = value.WorkFees
                };

                OnPropertyChanged();
            }
        }

        private readonly WorkSheetList workSheets;
        public WorkSheetList WorkSheets => workSheets;
       
        public WorkSheetViewModel()
        {
            workSheets = new WorkSheetList();
        }
        public WorkSheetViewModel(string plateNumber)
        {
            workSheets = WorkSheetValidation.GetWorkSheets(plateNumber);

            if (workSheets.Count != 0)
            {
                //DisplayWorkSheet = clearEmptyPartsAndWorkFeesLines(contractorFeeToNetTotalFee(workSheets[0]));
                DisplayWorkSheet = contractorFeeToNetTotalFee(clearEmptyPartsAndWorkFeesLines(workSheets))[0];
                PartViewModel();
                WorkFeeViewModel();
            }
            else
            {
                DisplayWorkSheet = new WorkSheet();
            }
        }

        private Part displayPart;
        public Part DisplayPart
        {
            get { return displayPart; }
            set
            {
                displayPart = new Part
                {
                    PartID = value.PartID,
                    PartName = value.PartName,
                    Pieces = value.Pieces,
                    NetPrice = value.NetPrice,
                    Multiplier = value.Multiplier,
                    Tax = value.Tax,
                    PartDiscount = value.PartDiscount
                };

                OnPropertyChanged();

            }
        }

        public void updatePartsTotals() => OnPropertyChanged("DisplayPart");

        private PartsList parts;
        public PartsList Parts => parts;
        public BindingSource PartsSource { get; set; }
        public void PartViewModel()
        {
            parts = displayWorkSheet.Parts;
            PartsSource = new BindingSource();
            PartsSource.DataSource = parts;
            PartsSource.ListChanged += WorkSheetSource_ListChanged;
            DisplayPart = new Part
            {
                Multiplier = DisplayWorkSheet.Multiplier,
                PartDiscount = DisplayWorkSheet.Discount,
                Tax = DisplayWorkSheet.Tax
            };

            OnPropertyChanged("TotalParts");
        }

        private WorkFee displayWorkFee;
        public WorkFee DisplayWorkFee
        {
            get { return displayWorkFee; }
            set
            {
                displayWorkFee = new WorkFee
                {
                    WorkID = value.WorkID,
                    WorkName = value.WorkName,
                    WorkHour = value.WorkHour,
                    NetHourFee = value.NetHourFee,
                    NetTotalFee = value.NetTotalFee,
                    WorkDiscount = value.WorkDiscount,
                    IsContractor = value.IsContractor,
                    ContractorFee = value.ContractorFee
                };

                OnPropertyChanged();
            }
        }

        public void updateWorkFeesTotals() => OnPropertyChanged("DisplayWorkFee");

        private WorkFeeList workFees;
        public WorkFeeList WorkFees => workFees;
        public BindingSource WorkFeesSource { get; set; }
        public void WorkFeeViewModel()
        {
            workFees = displayWorkSheet.WorkFees;
            WorkFeesSource = new BindingSource();
            WorkFeesSource.DataSource = workFees;
            WorkFeesSource.ListChanged += WorkSheetSource_ListChanged;
            DisplayWorkFee = new WorkFee
            {
                NetHourFee = DisplayWorkSheet.NetHourFee,
                WorkDiscount = DisplayWorkSheet.Discount,
            };

            OnPropertyChanged("WorkTotal");
        }

        public decimal TotalParts => parts.TotalParts;

        public decimal WorkTotal => workFees.WorkTotal;

        public decimal Total => TotalParts + WorkTotal;

        private void WorkSheetSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            OnPropertyChanged("TotalParts");
            OnPropertyChanged("WorkTotal");
        }

        public WorkSheetList clearEmptyPartsAndWorkFeesLines(WorkSheetList workSheets)
        {
            //var list = new List<int>(Enumerable.Range(1, 10));
            //for (int i = list.Count - 1; i >= 0; i--)
            //{
            //    if (list[i] > 5)
            //        list.RemoveAt(i);
            //}

            foreach (WorkSheet workSheet in workSheets)
            {
                workSheet.WorkFees.RemoveAll(item => string.IsNullOrWhiteSpace(item.WorkName));
                workSheet.Parts.RemoveAll(item => string.IsNullOrWhiteSpace(item.PartName));   //item.Value == someValue);
            }

            return workSheets;
        }

        public WorkSheetList contractorFeeToNetTotalFee(WorkSheetList workSheets)
        {
            foreach (WorkSheet workSheet in workSheets)
            {
                foreach (WorkFee workFee in workSheet.WorkFees)
                {
                    if (workFee.IsContractor)
                    {
                        workFee.NetHourFee = 0;
                        workFee.WorkDiscount = 0;
                        workFee.NetTotalFee = workFee.ContractorFee;
                    }
                    else
                    {
                        workFee.NetTotalFee = workFee.WorkHour * workFee.NetHourFee;
                    }
                }
            }

            return workSheets;
        }

    }
}

