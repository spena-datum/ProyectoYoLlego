using AsistenciaAdmin.Models;
using NPOI.HSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace AsistenciaAdmin.Services
{
    public class NPServices
    {
        private AsistenciaAdminContext db = new AsistenciaAdminContext();

        public string InsertDataExcel(HSSFWorkbook excel)
        {
            HSSFSheet ws = (HSSFSheet)excel.GetSheetAt(0);
            List<Cargas> newAccounts = new List<Cargas>();
            int startRow = 3;
            for (int i = startRow; i <= ws.LastRowNum; i++)
            {
                newAccounts.Add(new Cargas
                {
                    UsuarioId = ws.GetRow(startRow).GetCell(1).StringCellValue,
                    FechaHoraCarga = DateTime.Now,
                    CodigoMateria = ws.GetRow(startRow).GetCell(3).StringCellValue,
                    CarnetAlumno = ws.GetRow(startRow).GetCell(4).StringCellValue,
                    CorreoDocente = ws.GetRow(startRow).GetCell(5).StringCellValue,
                    CodigoAula = ws.GetRow(startRow).GetCell(6).StringCellValue,
                    HorarioClase = ws.GetRow(startRow).GetCell(7).StringCellValue,
                    Dias = ws.GetRow(startRow).GetCell(8).StringCellValue,
                    Ciclo = ws.GetRow(startRow).GetCell(9).StringCellValue
                });
                startRow++;
            }
            newAccounts.ToList();
            db.Cargas.AddRange(newAccounts);
            db.SaveChanges();

            return "Carga Correcta !";
        }
    }
}