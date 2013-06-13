﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NModel;
using NDAL;
namespace NBiz
{
    public class BizSupplier : BLLBase<NModel.Supplier>
    {
        private DALSupplier dalSupplier;
       public DALSupplier DalSupplier {
           get {
               if (dalSupplier == null) dalSupplier = new DALSupplier();
               return dalSupplier;
           }
           set { dalSupplier = value;
           }
       }
        public void ImportSupplierFromExcel(System.IO.Stream stream, out string errmsg)
        {
            IDataTableConverter<Supplier> supplierReader = new SupplierDataConverter();
            ImportToDatabaseFromExcel<Supplier> importor = new ImportToDatabaseFromExcel<Supplier>(supplierReader, this);
            importor.ImportXslData(stream, out errmsg);
        }
        public IList<Supplier> ReadSupplierListFromExcel(System.IO.Stream stream, out string errmsg)
        {
            IDataTableConverter<Supplier> supplierReader = new SupplierDataConverter();
            ImportToDatabaseFromExcel<Supplier> importor = new ImportToDatabaseFromExcel<Supplier>(supplierReader, this);
            return importor.ReadList(stream, out errmsg);
        }

        public Supplier GetByCode(string supplierCode)
        {
            
            return DalSupplier.GetOneByCode(supplierCode);
        }
        public Supplier GetByName(string supplierName)
        {
            return DalSupplier.GetOneByName(supplierName);
        }
        public IList<Supplier> GetListByCodeList(IList<string> supplierCodeList,out IList<string>  supplierCodeListNotExists )
        {
            supplierCodeListNotExists = new List<string>();
            IList<Supplier> existsSupplierList = new List<Supplier>();
            foreach (string supplierCode in supplierCodeList)
            {
                //如果返回为空
                Supplier supplier = GetByCode(supplierCode);
                if (supplier != null)
                {
                    existsSupplierList.Add(supplier);
                }
                else
                {
                    supplierCodeListNotExists.Add(supplierCode);
                }
                
            }
            return existsSupplierList;
        }
        public override IList<Supplier> SaveList(IList<Supplier> list, out string errMsg)
        {
            errMsg = string.Empty;
            DalSupplier.SaveList(list);
            return list;
        }
        public IList<Supplier> GetListAllPaged(int pageIndex, int pageSize, out int totalRerord)
        {
            return DalSupplier.GetList("select s from Supplier s", pageIndex, pageSize, out totalRerord);
        }
        public IList<Supplier> Search(string name, int pageIndex, int pageSize, out int recordCount)
        {
            return DalSupplier.Search(name, pageIndex, pageSize, out recordCount);
        }


        public List<string> supplierCodeListNotExists { get; set; }
    }
}
