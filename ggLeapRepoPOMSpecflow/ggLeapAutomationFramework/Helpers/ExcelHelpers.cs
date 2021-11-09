
using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace ggLeapAutomationFramework.Helpers
{
    public class ExcelHelpers
    {
        public static List<Datacollection> dataCol = new List<Datacollection>();

        //This Method used for Storing all the excel values into the in-memory collections
        public static void PopulateInCollection(string fileName)
        {
            DataTable table = ExcelToDataTable(fileName);

            //Iterate through the rows and columns of the table
            for (int row = 1; row <= table.Rows.Count; row++)
            {
                for (int col = 0; col <= table.Columns.Count; col++)
                {
                    Datacollection dtTable = new Datacollection()
                    {
                        rowNumber = row,
                        colName = table.Columns[col].ColumnName,
                        colValue = table.Rows[row - 1][col].ToString()
                    };
                    //Add all the details for each row
                    dataCol.Add(dtTable);
                }
            }

        }
        //private static DataTable ExcelToDataTable(string fileName)
        //{
        //    //Open File and retrun as Stream
        //    FileStream stream = File.Open(fileName, FileMode.Open, FileAccess.Read);

        //    //CreateOpenXmlReader via ExcelPageFactory
        //    IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream); //read .xlsx file

        //    //Return as DataSet
        //    DataSet result = excelReader.AsDataSet();

        //    //Get all the tables
        //    DataTableCollection table = result.Tables;

        //    //Store it in DataTable
        //    DataTable resultTable = table["Sheet1"];

        //    return resultTable;

        //}

        public static DataTable ExcelToDataTable(string fileName)
        { 
            using (var stream = File.Open(fileName, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (data) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true
                        }
                    });

                    //Get all the tables
                    DataTableCollection table = result.Tables;

                    //Store it in DataTable
                    DataTable resultTable = table["Sheet1"];
                    return resultTable;
                }
            }
        }
        public static string ReadData(int rowNumber, string columnName)
        {
            try
            {
                //Retrieving Data using LINQ to reduce mucb Iterations
                string data = (from colData in dataCol
                               where colData.colName == columnName && colData.rowNumber == rowNumber
                               select colData.colValue).SingleOrDefault();

                return data.ToString();
            }
            catch(Exception e)
            {
                Console.WriteLine("Excpetion is : " + e);
                return null;
            }
        }


    }

    //Custom Class
    public class Datacollection
    {
        public int rowNumber {get; set;}
        public string colName { get; set; }
        public string colValue { get; set; }

    }
}
