namespace INFOLINK.DBHelper
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Data;
    using System.IO;
    using System.Text.RegularExpressions;
    using NPOI.SS.UserModel;
    using NPOI.XSSF.UserModel;
    using INFOLINK.ShareLibs;
    using MySqlConnector;

    public class ExcelSeedHandler : SeedHandler
    {
        private XSSFWorkbook excel = null;

        private Dictionary<string, int> columnHeaders = new Dictionary<string, int>();

        private List<string> commandStrings = new List<string>();

        private MySqlConnection connection = null;

        private bool isResetTable = false;

        public ExcelSeedHandler(string connectionString, string pathOFEntity) : base(connectionString, pathOFEntity)
        {
            using (FileStream stream = new FileStream(pathOFEntity, FileMode.Open, FileAccess.ReadWrite))
            {
                this.excel = new XSSFWorkbook(stream);
            }
        }

        public override bool OpenDBConnection()
        {
            bool result = false;

            try
            {
                this.CloseConnection();
                this.connection = new MySqlConnection(this.connectString);
                this.connection.Open();
                result = true;
            }
            catch (Exception ex)
            {
                Logger.Log(Logger.Level.Error, ex.Message);
            }

            return result;
        }

        public override bool CloseConnection()
        {
            bool result = false;

            try
            {
                if (this.connection != null)
                {
                    this.connection.Close();
                    this.connection.Dispose();
                    this.connection = null;
                }

                result = true;
            }
            catch (Exception ex)
            {
                Logger.Log(Logger.Level.Error, ex.Message);
            }

            return result;
        }

        public override bool DumpDataToDB()
        {
            Logger.Log(Logger.Level.Info, this.entity);
            return true;
        }

        /// <summary>
        /// To dump data to database
        /// </summary>
        /// <param name="targetTable">the specific table</param>
        /// <returns>true for success and false for fail</returns>
        public override bool DumpDataToDB(string targetTable, bool isReset, out int effectedRow)
        {
            bool result = false;
            bool isTargetTable = false;
            effectedRow = 0;

            if (!string.IsNullOrEmpty(targetTable))
            {
                isTargetTable = true;
                targetTable = targetTable.Trim();
            }

            try
            {               
                this.isResetTable = isReset;
                int countSheet = this.excel.NumberOfSheets;

                for (int index = 0; index < countSheet; index++)
                {
                    ISheet sheet = this.excel.GetSheetAt(index);
                    
                    if (isTargetTable && !sheet.SheetName.Equals(targetTable))
                    {
                        Logger.Log(Logger.Level.Warning, sheet.SheetName + "  is not " + targetTable);
                        continue;
                    }

                    if (!this.ParseSheet(sheet))
                    {
                        Logger.Log(Logger.Level.Error, sheet.SheetName + " parsing is fail");
                        continue;
                    }

                    this.ExecuteSeed(sheet.SheetName, out effectedRow);
                }

                result = true;
            }
            catch(Exception ex)
            {
                Logger.Log(Logger.Level.Error, ex.Message);
            }

            return result;
        }

        /// <summary>
        /// To parset sheet
        /// </summary>
        /// <param name="sheet">the instance of sheet</param>
        /// <returns>true for success and false for fail</returns>
        private bool ParseSheet(ISheet sheet)
        {
            bool result = false;

            try
            {
                Logger.Log(Logger.Level.Info, "Sheet Name=" + sheet.SheetName);
                this.commandStrings.Clear();
                this.SetupColumnHeaders(sheet);
                int totalRow = sheet.LastRowNum + 1;
                //Logger.Log(Logger.Level.Info, "total Row = " + totalRow);

                Func<IRow, string, bool, string> processWords = (IRow row, string syntax, bool isHeader) =>
                {
                    foreach (KeyValuePair<string, int> header in this.columnHeaders)
                    {
                        string cellValue = "''";

                        if (row.GetCell(header.Value) != null)
                        {
                            cellValue = string.IsNullOrEmpty(row.GetCell(header.Value).ToString()) ? cellValue : string.Format("'{0}'", row.GetCell(header.Value).ToString().Trim());
                        }

                        syntax += string.Format("{0},", isHeader == true? header.Key : cellValue);
                    }

                    syntax = syntax.Remove(syntax.Length - 1, 1);
                    return syntax;
                };

                for (int rowIndex = 1; rowIndex < totalRow; rowIndex++)
                {
                    try
                    {
                        string syntax = string.Format("insert into {0} (", sheet.SheetName);
                        IRow row = sheet.GetRow(rowIndex);
                        syntax = processWords(row, syntax, true) + ") values (";
                        syntax = processWords(row, syntax, false) + ")";
                        this.commandStrings.Add(syntax);
                    }
                    catch(Exception ex)
                    {
                        Logger.Log(Logger.Level.Error, ex.Message);
                    }
                }

                result = true;   
            }
            catch(Exception ex)
            {
                Logger.Log(Logger.Level.Error, ex.Message);
            }

            return result;
        }

        /// <summary>
        /// To parset sheet
        /// </summary>
        /// <param name="sheet">the instance of sheet</param>
        /// <returns>true for success and false for fail</returns>
        private bool ExecuteSeed(string tableName, out int successRows)
        {
            bool result = false;

            successRows = 0;

            try
            {
                if (this.connection == null)
                {
                    this.OpenDBConnection();
                }

                if (this.isResetTable)
                {
                    string command = string.Format("delete from {0}", tableName);
                    MySqlCommand mysqlCommand = new MySqlCommand(command, this.connection);
                    mysqlCommand.ExecuteNonQuery();

                }

                int counter = 0;

                foreach (string command in this.commandStrings)
                {
                    MySqlCommand mysqlCommand = new MySqlCommand(command, this.connection);
                    int dbResult = mysqlCommand.ExecuteNonQuery();
                    successRows += dbResult;
                    counter += 1;
                    Logger.Log(Logger.Level.Info, string.Format("[{2}] effected row count={0}, command={1}", dbResult.ToString(), command, counter));
                }

                result = true;
            }
            catch (Exception ex)
            {
                Logger.Log(Logger.Level.Error, ex.Message);
            }

            return result;
        }

        /// <summary>
        /// To setup column header dict data
        /// </summary>
        /// <param name="sheet">the instance of sheet</param>
        /// <returns>true for success and false for fail</returns>
        private bool SetupColumnHeaders(ISheet sheet)
        {

            bool result = false;

            try
            {
                int headerRowIndex = 0;
                this.columnHeaders.Clear();
                IRow row       = sheet.GetRow(headerRowIndex);
                int cellNumber = row.LastCellNum;

                for (int columnIndex = 0; columnIndex < cellNumber; columnIndex++)
                {
                    string cellValue = string.Empty;

                    if (row.GetCell(columnIndex) != null)
                    {
                        cellValue = row.GetCell(columnIndex).ToString().Trim();
                        this.columnHeaders.Add(cellValue, columnIndex);
                    }
                }

                result = true;
            }
            catch (Exception ex)
            {
                Logger.Log(Logger.Level.Error, ex.Message);
            }

            return result;
        }
    }
}